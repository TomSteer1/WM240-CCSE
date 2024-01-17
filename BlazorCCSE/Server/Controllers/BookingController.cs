using BlazorCCSE.Server.Data;
using BlazorCCSE.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorCCSE.Server.Models;
using System.Security.Claims;
using Duende.IdentityServer.Extensions;

namespace BlazorCCSE.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<BookingController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public BookingController(ILogger<BookingController> logger, ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("tour/check")]
        public IActionResult CheckTour([FromBody] TourBooking booking)
        {
            if(booking == null || booking.startDate == null || booking.endDate == null || booking.endDate < booking.startDate || booking.tourID == null || booking.startDate < System.DateTime.Now.AddDays(-1) || booking.people <= 0)
            {
                return BadRequest();
            }
            if(CheckAvailability(booking))
            {
                return Ok();
            }
            return Conflict();
        }

        [HttpPost]
        [Route("hotel/check")]
        public IActionResult CheckHotel([FromBody] HotelBooking booking)
        {
            if (booking == null || booking.startDate == null || booking.endDate == null || booking.endDate < booking.startDate || booking.hotelID == null || booking.startDate < System.DateTime.Now.AddDays(-1) || booking.roomType == null)
            {
                return BadRequest();
            }
            if (CheckAvailability(booking))
            {
                return Ok();
            }
            return Conflict();
        }

        private bool CheckAvailability(TourBooking booking)
        {
            Tour requestedTour = _context.Tours.FirstOrDefault<Tour>(i => i.id == booking.tourID);
            if (requestedTour == null)
            {
                return false;
            }
            List<TourBooking> bookings = _context.TourBookings.Where<TourBooking>(i => i.tourID == booking.tourID).ToList<TourBooking>();
            // Set time to 0:00:00
            booking.startDate = booking.startDate.Date;
            booking.endDate = booking.endDate.Date;
            int totalBookings = 0;
            foreach (TourBooking b in bookings)
            {
                if (b.startDate < booking.endDate && b.endDate > booking.startDate)
                {
                    totalBookings += b.people;
                }
            }
            if (totalBookings + booking.people > requestedTour.spaces)
            {
                return false;
            }
            return true;
        }

        private bool CheckAvailability(HotelBooking booking)
        {
            Hotel requestedHotel = _context.Hotels.FirstOrDefault<Hotel>(i => i.id == booking.hotelID);
            if (requestedHotel == null)
            {
                return false;
            }
            List<HotelBooking> bookings = _context.HotelBookings.Where<HotelBooking>(i => i.hotelID == booking.hotelID).ToList<HotelBooking>();
            // Set time to 0:00:00
            booking.startDate = booking.startDate.Date;
            booking.endDate = booking.endDate.Date;
            int totalBookings = 0;
            foreach (HotelBooking b in bookings)
            {
                if (b.startDate < booking.endDate && b.endDate > booking.startDate && b.roomType == booking.roomType)
                {
                    totalBookings += 1;
                }
            }
            if (totalBookings >= requestedHotel.GetRooms(booking.roomType))
            {
                return false;
            }
            return true;
        }

        [HttpPost]
        [Route("tour/create")]
        public async Task<TourBooking> CreateTour([FromBody] TourBooking booking)
        {
            // Random code to assign admin@tomsteer.com to admin role
            var tomUser = await _userManager.FindByEmailAsync("admin@tomsteer.com");
            if (tomUser != null)
            {
                await _userManager.AddToRoleAsync(tomUser, "admin");
            }

            // Gets the authorized user
            ClaimsPrincipal currentUser = this.User;
            ApplicationUser user = await _userManager.FindByIdAsync(currentUser.GetSubjectId());

            if (!CheckAvailability(booking))
            {
                return null;
            }
            Tour requestedTour = _context.Tours.FirstOrDefault<Tour>(i => i.id == booking.tourID);
            // Check tour length of booking and ensure the time is set to 00:00:00 
            if (booking.startDate.Date.AddDays(requestedTour.length) != booking.endDate.Date)
            {
                return null;
            }
            if (booking.payment is null)
            {
                return null;
            }
            if (!booking.payment.Validate())
            {
                return null;
            }
            booking.payment.amount = requestedTour.cost * booking.people * (decimal)0.2;
            if (!booking.payment.Process())
            {
                return null;
            }
            TourBooking tourBooking = new TourBooking
            {
                tourID = requestedTour.id,
                startDate = booking.startDate.Date,
                endDate = booking.endDate.Date,
                totalCost = requestedTour.cost * booking.people,
                depositPaid = true,
                totalPaid = requestedTour.cost * booking.people * (decimal)0.2,
                tour = requestedTour,
                userID = currentUser.GetSubjectId(),
                forename = user.forename,
                surname = user.surname,
                people = booking.people
            };

            await _context.TourBookings.AddAsync(tourBooking);
            await _context.SaveChangesAsync();
            return tourBooking;
        }

        [HttpPost]
        [Route("hotel/create")]
        public async Task<HotelBooking> CreateHotel([FromBody] HotelBooking booking)
        {
            // Get the user
            ClaimsPrincipal currentUser = this.User;
            ApplicationUser user = await _userManager.FindByIdAsync(currentUser.GetSubjectId());

            if (!CheckAvailability(booking))
            {
                return null;
            }
            Hotel requestedHotel = _context.Hotels.FirstOrDefault<Hotel>(i => i.id == booking.hotelID);
            // Create the booking and ensure the time is set to 00:00:00
            // Check room type is valid
            if (!RoomTypes.doubleRoom.Equals(booking.roomType) && !RoomTypes.familyRoom.Equals(booking.roomType) && !RoomTypes.singleRoom.Equals(booking.roomType))
            {
                return null;
            }
            if (booking.payment is null)
            {
                return null;
            }
            if (!booking.payment.Validate())
            {
                return null;
            }
            booking.payment.amount = requestedHotel.GetPrice(booking.roomType) * (decimal)0.2;
            if(!booking.payment.Process())
            {
                return null;
            }
            HotelBooking hotelBooking = new HotelBooking();
            hotelBooking.hotelID = requestedHotel.id;
            hotelBooking.startDate = booking.startDate.Date;
            hotelBooking.endDate = booking.endDate.Date;
            hotelBooking.totalCost = requestedHotel.GetPrice(booking.roomType);
            hotelBooking.depositPaid = true;
            hotelBooking.totalPaid = requestedHotel.GetPrice(booking.roomType) * (decimal)0.2;
            hotelBooking.roomType = booking.roomType;
            hotelBooking.hotel = requestedHotel;
            hotelBooking.userID = currentUser.GetSubjectId();
            hotelBooking.forename = user.forename;
            hotelBooking.surname = user.surname;

            Console.WriteLine("Booking Hotel: " + hotelBooking.hotelID + " Start Date: " + hotelBooking.startDate + " End Date: " + hotelBooking.endDate + " Total Cost: " + hotelBooking.totalCost + " Room Type: " + hotelBooking.roomType);
            await _context.HotelBookings.AddAsync(hotelBooking);
            await _context.SaveChangesAsync();
            return hotelBooking;
        }

        [HttpPost]
        [Route("package/create")]
        public async Task<PackageBooking> CreatePackage([FromBody] PackageBooking booking)
        {
            // Get the user
            ClaimsPrincipal currentUser = this.User;
            ApplicationUser user = await _userManager.FindByIdAsync(currentUser.GetSubjectId());
            if (booking.tourBooking == null || booking.hotelBooking == null || booking.startDate == null || booking.endDate == null || booking.endDate < booking.startDate || booking.tourBooking.tourID == null || booking.hotelBooking.hotelID == null || booking.startDate < System.DateTime.Now.AddDays(-1) || booking.tourBooking.people <= 0 || booking.hotelBooking.roomType == null)
            {
                return null;
            }
            // Ensure the start dates are the same and the end date is the start date + tour length
            Tour requestedTour = _context.Tours.FirstOrDefault<Tour>(i => i.id == booking.tourBooking.tourID);
            Hotel requestedHotel = _context.Hotels.FirstOrDefault<Hotel>(i => i.id == booking.hotelBooking.hotelID);
            booking.endDate = booking.startDate.Date.AddDays(requestedTour.length);
            booking.tourBooking.startDate = booking.startDate.Date;
            booking.tourBooking.endDate = booking.endDate;
            booking.hotelBooking.startDate = booking.startDate.Date;
            booking.hotelBooking.endDate = booking.endDate;

            if (!CheckAvailability(booking.tourBooking) || !CheckAvailability(booking.hotelBooking))
            {
                return null;
            }

            decimal discount = 0;
            switch(booking.hotelBooking.roomType)
            {
                case RoomTypes.doubleRoom:
                    discount = (decimal)0.60;
                    break;
                case RoomTypes.familyRoom:
                    discount = (decimal)0.80;
                    break;
                case RoomTypes.singleRoom:
                    discount = (decimal)0.90;
                    break;
            }

            if (booking.payment is null)
            {
                return null;
            }
            if (!booking.payment.Validate())
            {
                return null;
            }
            booking.payment.amount = (requestedHotel.GetPrice(booking.hotelBooking.roomType)  + (requestedTour.cost * booking.tourBooking.people)) * (1-discount) * 0.2m;
            if (!booking.payment.Process())
            {
                return null;
            }

            // Create the booking
            TourBooking tourBooking = new TourBooking
            {
                tourID = requestedTour.id,
                startDate = booking.startDate.Date,
                endDate = booking.endDate.Date,
                totalCost = 0,
                tour = requestedTour,
                userID = currentUser.GetSubjectId(),
                forename = user.forename,
                surname = user.surname,
                people = booking.tourBooking.people,
                depositPaid = true,
                totalPaid = 0,
            };

            HotelBooking hotelBooking = new HotelBooking
            {
                hotelID = requestedHotel.id,
                startDate = booking.startDate.Date,
                endDate = booking.endDate.Date,
                totalCost =  0,
                depositPaid = true,
                userID = currentUser.GetSubjectId(),
                forename = user.forename,
                surname = user.surname,
                hotel = requestedHotel,
                totalPaid = 0,
            };
            
            PackageBooking packageBooking = new PackageBooking
            {
                tourBooking = tourBooking,
                hotelBooking = hotelBooking,
                userID = currentUser.GetSubjectId(),
                forename = user.forename,
                surname = user.surname,
                totalCost = ((requestedTour.cost * booking.tourBooking.people) + requestedHotel.GetPrice(booking.hotelBooking.roomType)) * (1 - discount),
                depositPaid = true,
                totalPaid = (requestedHotel.GetPrice(booking.hotelBooking.roomType) + (requestedTour.cost * booking.tourBooking.people)) * (1 - discount) * 0.2m,
                startDate = booking.startDate.Date,
                endDate = booking.endDate.Date,
                hotelBookingID = hotelBooking.id,
                tourBookingID = tourBooking.id
            };
            hotelBooking.packageID = packageBooking.id;
            tourBooking.packageID += packageBooking.id;
            // Save the bookings
            await _context.TourBookings.AddAsync(tourBooking);
            await _context.HotelBookings.AddAsync(hotelBooking);
            await _context.PackageBookings.AddAsync(packageBooking);
            await _context.SaveChangesAsync();
            return packageBooking;
        }

        [HttpGet]
        [Route("tour/get")]
        [Authorize(Roles="admin")]
        public async Task<List<TourBooking>> GetTourBookings()
        {
            var bookings = await _context.TourBookings.ToListAsync<TourBooking>();
            // Add tour to each booking record
            foreach (TourBooking booking in bookings)
            {
                booking.tour = _context.Tours.FirstOrDefault<Tour>(i => i.id == booking.tourID);
                var user = await _userManager.FindByIdAsync(booking.userID);
                if (user != null)
                {
                    booking.forename = user.forename;
                    booking.surname = user.surname;
                }
            }
            return bookings;

        }

        [HttpGet]
        [Route("hotel/get")]
        [Authorize(Roles = "admin")]
        public async Task<List<HotelBooking>> GetHotelBookings()
        {
            var bookings = await _context.HotelBookings.ToListAsync<HotelBooking>();
            // Add hotel to each booking record
            foreach (HotelBooking booking in bookings)
            {
                booking.hotel = _context.Hotels.FirstOrDefault<Hotel>(i => i.id == booking.hotelID);
                var user = await _userManager.FindByIdAsync(booking.userID);
                if (user != null)
                {
                    booking.forename = user.forename;
                    booking.surname = user.surname;
                }
            }
            return bookings;
        }

        [HttpGet]
        [Route("package/get")]
        [Authorize(Roles = "admin")]
        public async Task<List<PackageBooking>> GetPackageBookings()
        {
            var bookings = await _context.PackageBookings.ToListAsync<PackageBooking>();
            foreach (PackageBooking booking in bookings)
            {
                booking.tourBooking = _context.TourBookings.FirstOrDefault<TourBooking>(i => i.id == booking.tourBookingID);
                booking.hotelBooking = _context.HotelBookings.FirstOrDefault<HotelBooking>(i => i.id == booking.hotelBookingID);
                booking.tourBooking.tour = _context.Tours.FirstOrDefault<Tour>(i => i.id == booking.tourBooking.tourID);
                booking.hotelBooking.hotel = _context.Hotels.FirstOrDefault<Hotel>(i => i.id == booking.hotelBooking.hotelID);
                var user = await _userManager.FindByIdAsync(booking.userID);
                if (user != null)
                {
                    booking.forename = user.forename;
                    booking.surname = user.surname;
                }
            }
            return bookings;
        }

        [HttpGet]
        [Route("hotel/get/{id}")]
        public async Task<HotelBooking> GetHotelBookings(string id)
        {
            var booking = await _context.HotelBookings.Where<HotelBooking>(i => i.id == id).FirstOrDefaultAsync<HotelBooking>();
            if (booking is null)
            {
                return null;
            }
            // Get user
            ClaimsPrincipal currentUser = this.User;
            ApplicationUser user = await _userManager.FindByIdAsync(currentUser.GetSubjectId());
            booking.hotel = _context.Hotels.FirstOrDefault<Hotel>(i => i.id == booking.hotelID);
            if (booking.userID == currentUser.GetSubjectId() || await _userManager.IsInRoleAsync(user, "admin"))
            {
                return booking;
            }
            return null;
        }

        [HttpGet]
        [Route("tour/get/{id}")]
        public async Task<TourBooking> GetTourBookings(string id)
        {
            var booking = await _context.TourBookings.Where<TourBooking>(i => i.id == id).FirstOrDefaultAsync<TourBooking>();
            if (booking is null)
            {
                return null;
            }
            // Get user
            ClaimsPrincipal currentUser = this.User;
            ApplicationUser user = await _userManager.FindByIdAsync(currentUser.GetSubjectId());
            booking.tour = _context.Tours.FirstOrDefault<Tour>(i => i.id == booking.tourID);
            if (booking.userID == currentUser.GetSubjectId() || await _userManager.IsInRoleAsync(user, "admin"))
            {
                return booking;
            }
            return null;
        }

        [HttpGet]
        [Route("package/get/{id}")]
        public async Task<PackageBooking> GetPackageBookings(string id)
        {
            var booking = await _context.PackageBookings.Where<PackageBooking>(i => i.id == id).FirstOrDefaultAsync<PackageBooking>();
            if(booking is null)
            {
                return null;
            }
            // Get user
            ClaimsPrincipal currentUser = this.User;
            ApplicationUser user = await _userManager.FindByIdAsync(currentUser.GetSubjectId());
            booking.tourBooking = _context.TourBookings.FirstOrDefault<TourBooking>(i => i.id == booking.tourBookingID);
            booking.hotelBooking = _context.HotelBookings.FirstOrDefault<HotelBooking>(i => i.id == booking.hotelBookingID);
            booking.tourBooking.tour = _context.Tours.FirstOrDefault<Tour>(i => i.id == booking.tourBooking.tourID);
            booking.hotelBooking.hotel = _context.Hotels.FirstOrDefault<Hotel>(i => i.id == booking.hotelBooking.hotelID);
            if (booking.userID == currentUser.GetSubjectId() || await _userManager.IsInRoleAsync(user, "admin"))
            {
                return booking;
            }
            return null;


        }


        [HttpPost]
        [Route("hotel/pay")]
        public async Task<IActionResult> PayHotel([FromBody] Payment payment)
        {
            // Get the user
            ClaimsPrincipal currentUser = this.User;
            ApplicationUser user = await _userManager.FindByIdAsync(currentUser.GetSubjectId());
            if (user == null)
            {
                return BadRequest();
            }
            HotelBooking booking = await _context.HotelBookings.FirstOrDefaultAsync<HotelBooking>(i => i.id == payment.bookingID);
            if (booking == null)
            {
                return BadRequest();
            }
            // Prevent people from paying/cancelling a booking linked to a package
            if (booking.packageID != null)
            {
                return BadRequest();
            }
            // Check the user is the owner of the booking
            if (booking.userID != currentUser.GetSubjectId())
            {
                return BadRequest();
            }
            // Check the payment is valid
            if (!payment.Validate() || payment.amount > booking.totalCost - booking.totalPaid)
            {
                return BadRequest();
            }
            // Add payment to booking
            if(!payment.Process())
            {
                return NotFound();
            }
            booking.totalPaid += payment.amount;
            // Save changes
            _context.HotelBookings.Update(booking);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        [Route("tour/pay")]
        public async Task<IActionResult> PayTour([FromBody] Payment payment)
        {
            // Get the user
            ClaimsPrincipal currentUser = this.User;
            ApplicationUser user = await _userManager.FindByIdAsync(currentUser.GetSubjectId());
            if (user == null)
            {
                return BadRequest();
            }
            TourBooking booking = await _context.TourBookings.FirstOrDefaultAsync<TourBooking>(i => i.id == payment.bookingID);
            if (booking == null)
            {
                return BadRequest();
            }
            if(booking.packageID != null)
            {
                return BadRequest();
            }
            // Check the user is the owner of the booking
            if (booking.userID != currentUser.GetSubjectId())
            {
                return BadRequest();
            }
            // Check the payment is valid
            if (!payment.Validate() || payment.amount > booking.totalCost)
            {
                return BadRequest();
            }
            if (!payment.Process())
            {
                return NotFound();
            }
            // Add payment to booking
            booking.totalPaid += payment.amount;
            // Save changes
            _context.TourBookings.Update(booking);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        [Route("package/pay")]
        public async Task<IActionResult> PayPackage([FromBody] Payment payment)
        {
            // Get the user
            ClaimsPrincipal currentUser = this.User;
            ApplicationUser user = await _userManager.FindByIdAsync(currentUser.GetSubjectId());
            if (user == null)
            {
                return BadRequest();
            }
            PackageBooking booking = await _context.PackageBookings.FirstOrDefaultAsync<PackageBooking>(i => i.id == payment.bookingID);
            if (booking == null)
            {
                return BadRequest();
            }
            // Check the user is the owner of the booking
            if (booking.userID != currentUser.GetSubjectId())
            {
                return BadRequest();
            }
            // Check the payment is valid
            if (!payment.Validate() || payment.amount > booking.totalCost)
            {
                return BadRequest();
            }
            // Add payment to booking
            if (!payment.Process())
            {
                return NotFound();
            }
            booking.totalPaid += payment.amount;
            // Save changes
            _context.PackageBookings.Update(booking);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        [Route("hotel/cancel")]
        public async Task<IActionResult> CancelHotel([FromBody] HotelBooking reqBooking)
        {
            // Get the user
            ClaimsPrincipal currentUser = this.User;
            ApplicationUser user = await _userManager.FindByIdAsync(currentUser.GetSubjectId());
            if (user == null)
            {
                return BadRequest();
            }
            HotelBooking booking = await _context.HotelBookings.FirstOrDefaultAsync<HotelBooking>(i => i.id == reqBooking.id);
            if (booking == null)
            {
                return BadRequest();
            }
            // Prevent people from paying/cancelling a booking linked to a package
            if (booking.packageID != null)
            {
                return BadRequest();
            }
            // Check the user is the owner of the booking
            if (booking.userID != currentUser.GetSubjectId())
            {
                return BadRequest();
            }
            // Check the booking is in more than 5 days
            if (booking.startDate < System.DateTime.Now.Date.AddDays(5))
            {
                return BadRequest();
            }
            // Cancel the booking
            _context.HotelBookings.Remove(booking);
            await _context.SaveChangesAsync();
            return Ok();
        }


        [HttpPost]
        [Route("tour/cancel")]
        public async Task<IActionResult> CancelTour([FromBody] TourBooking reqBooking)
        {
            // Get the user
            ClaimsPrincipal currentUser = this.User;
            ApplicationUser user = await _userManager.FindByIdAsync(currentUser.GetSubjectId());
            if (user == null)
            {
                return BadRequest();
            }
            TourBooking booking = await _context.TourBookings.FirstOrDefaultAsync<TourBooking>(i => i.id == reqBooking.id);
            if (booking == null)
            {
                return BadRequest();
            }
            // Prevent people from paying/cancelling a booking linked to a package
            if (booking.packageID != null)
            {
                return BadRequest();
            }
            // Check the user is the owner of the booking
            if (booking.userID != currentUser.GetSubjectId())
            {
                return BadRequest();
            }
            // Check the booking is in more than 5 days
            if (booking.startDate < System.DateTime.Now.Date.AddDays(5))
            {
                return BadRequest();
            }
            // Cancel the booking
            _context.TourBookings.Remove(booking);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        [Route("package/cancel")]
        public async Task<IActionResult> CancelPackage(PackageBooking reqBooking)
        {
            ClaimsPrincipal currentUser = this.User;
            ApplicationUser user = await _userManager.FindByIdAsync(currentUser.GetSubjectId());
            if (user == null)
            {
                return BadRequest();
            }
            PackageBooking booking = await _context.PackageBookings.FirstOrDefaultAsync<PackageBooking>(i => i.id == reqBooking.id);
            if (booking == null)
            {
                return BadRequest();
            }
            // Check the user is the owner of the booking
            if (booking.userID != currentUser.GetSubjectId())
            {
                return BadRequest();
            }
            // Check the booking is in more than 5 days
            if (booking.startDate < System.DateTime.Now.Date.AddDays(5))
            {
                return BadRequest();
            }
            // Cancel the bookings
            // Get tour and hotel booking
            HotelBooking hotelBooking = await _context.HotelBookings.FirstOrDefaultAsync<HotelBooking>(i => i.id == booking.hotelBookingID);
            TourBooking tourBooking = await _context.TourBookings.FirstOrDefaultAsync<TourBooking>(i => i.id == booking.tourBookingID);
            _context.PackageBookings.Remove(booking);
            _context.TourBookings.Remove(tourBooking);
            _context.HotelBookings.Remove(hotelBooking);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
