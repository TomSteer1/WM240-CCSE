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
            Console.Write("Start Date: " + booking.startDate + " End Date: " + booking.endDate + " Tour ID: " + booking.tourID);
            if(booking == null || booking.startDate == null || booking.endDate == null || booking.endDate < booking.startDate || booking.tourID == null || booking.startDate < System.DateTime.Now.AddDays(-1))
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
            Console.Write("Start Date: " + booking.startDate + " End Date: " + booking.endDate + " Hotel ID: " + booking.hotelID);
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
                    totalBookings += 1;
                }
            }
            if (totalBookings >= requestedTour.spaces)
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
        [Authorize]
        [Route("tour/create")]
        public async Task<IActionResult> CreateTour([FromBody] TourBooking booking)
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
                return Conflict();
            }
            Tour requestedTour = _context.Tours.FirstOrDefault<Tour>(i => i.id == booking.tourID);
            // Check tour length of booking and ensure the time is set to 00:00:00
            if (booking.startDate.Date.AddDays(requestedTour.length) != booking.endDate.Date)
            {
                return BadRequest();
            }
            TourBooking tourBooking = new TourBooking();
            tourBooking.tourID = requestedTour.id;
            tourBooking.startDate = booking.startDate.Date;
            tourBooking.endDate = booking.endDate.Date;
            tourBooking.totalCost = requestedTour.cost;
            tourBooking.tour = requestedTour;
            tourBooking.userID = currentUser.GetSubjectId();
            tourBooking.forename = user.forename;
            tourBooking.surname = user.surname;

            Console.WriteLine("Booking Tour: " + tourBooking.tourID + " Start Date: " + tourBooking.startDate + " End Date: " + tourBooking.endDate + " Total Cost: " + tourBooking.totalCost);
            await _context.TourBookings.AddAsync(tourBooking);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        [Route("hotel/create")]
        public async Task<IActionResult> CreateHotel([FromBody] HotelBooking booking)
        {
            // Get the user
            ClaimsPrincipal currentUser = this.User;
            ApplicationUser user = await _userManager.FindByIdAsync(currentUser.GetSubjectId());

            if (!CheckAvailability(booking))
            {
                return Conflict();
            }
            Hotel requestedHotel = _context.Hotels.FirstOrDefault<Hotel>(i => i.id == booking.hotelID);
            // Create the booking and ensure the time is set to 00:00:00
            // Check room type is valid
            if (!RoomTypes.doubleRoom.Equals(booking.roomType) && !RoomTypes.familyRoom.Equals(booking.roomType) && !RoomTypes.singleRoom.Equals(booking.roomType))
            {
                return BadRequest();
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
            return Ok();
        }

        [HttpGet]
        [Route("tour/get")]
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
        [Route("hotel/get/{id}")]
        public async Task<HotelBooking> GetHotelBookings(Guid id)
        {
            var booking = await _context.HotelBookings.Where<HotelBooking>(i => i.id == id).FirstOrDefaultAsync<HotelBooking>();
            // Get user
            ClaimsPrincipal currentUser = this.User;
            ApplicationUser user = await _userManager.FindByIdAsync(currentUser.GetSubjectId());
            booking.hotel = _context.Hotels.FirstOrDefault<Hotel>(i => i.id == booking.hotelID);
            if(booking.userID == currentUser.GetSubjectId())
            {
                return booking;
            }
            if (await _userManager.IsInRoleAsync(user, "admin"))
            {
                return booking;
            }
            return null;
        }   

        [HttpGet]
        [Route("package/get")]
        public async Task<List<PackageBooking>> GetPackageBookings()
        {
            var bookings = await _context.PackaegBookings.ToListAsync<PackageBooking>();
            foreach(PackageBooking booking in bookings)
            {
                booking.tourBooking = _context.TourBookings.FirstOrDefault<TourBooking>(i => i.id == booking.tourBookingID);
                booking.hotelBooking = _context.HotelBookings.FirstOrDefault<HotelBooking>(i => i.id == booking.hotelBookingID);
                var user = await _userManager.FindByIdAsync(booking.userID);
                if (user != null)
                {
                    booking.forename = user.forename;
                    booking.surname = user.surname;
                }
            }
            return bookings;
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
            // Check the user is the owner of the booking
            if (booking.userID != currentUser.GetSubjectId())
            {
                return BadRequest();
            }
            // Check the payment is valid
            if (payment.amount <= 0 || payment.amount > booking.totalCost)
            {
                return BadRequest();
            }
            // Add payment to booking
            booking.totalPaid += payment.amount;
            // Save changes
            _context.HotelBookings.Update(booking);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        [Route("hotel/cancel/{id:Guid}")]
        public async Task<IActionResult> cancelHotel(Guid id)
        {
            // Get the user
            ClaimsPrincipal currentUser = this.User;
            ApplicationUser user = await _userManager.FindByIdAsync(currentUser.GetSubjectId());
            if (user == null)
            {
                return BadRequest();
            }
            HotelBooking booking = await _context.HotelBookings.FirstOrDefaultAsync<HotelBooking>(i => i.id == id);
            if (booking == null)
            {
                return BadRequest();
            }
            // Check the user is the owner of the booking
            if (booking.userID != currentUser.GetSubjectId())
            {
                return BadRequest();
            }
            // Check the booking is not in the past
            if (booking.startDate < System.DateTime.Now)
            {
                return BadRequest();
            }
            // Cancel the booking
            _context.HotelBookings.Remove(booking);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
