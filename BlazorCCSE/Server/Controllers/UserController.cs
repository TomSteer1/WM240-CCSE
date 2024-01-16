using BlazorCCSE.Server.Data;
using BlazorCCSE.Server.Models;
using BlazorCCSE.Shared;
using Duende.IdentityServer.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BlazorCCSE.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<UserController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public UserController(ILogger<UserController> logger, ApplicationDbContext context,
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

        [HttpGet]
        [Authorize]
        [Route("booking/tour/get")]
        public async Task<List<TourBooking>> GetTours()
        {
            // Gets the authorized user
            ClaimsPrincipal currentUser = this.User;
            ApplicationUser user = await _userManager.FindByIdAsync(currentUser.GetSubjectId());
            if (user == null)
            {
                return null;
            }

            // Pull bookings from database
            List<TourBooking> bookings = await _context.TourBookings.Where(i => i.userID == user.Id).ToListAsync<TourBooking>();
            List<TourBooking> returnData = new List<TourBooking>();
            // Map tour to booking
            foreach (TourBooking booking in bookings)
            {
                if(booking.packageID is null)
                { 
                    booking.tour = await _context.Tours.FirstOrDefaultAsync<Tour>(i => i.id == booking.tourID);
                    returnData.Add(booking);
                }
            }
            return returnData;
        }

        [HttpGet]
        [Authorize]
        [Route("booking/hotel/get")]
        public async Task<List<HotelBooking>> GetHotels()
        {
            // Gets the authorized user
            ClaimsPrincipal currentUser = this.User;
            ApplicationUser user = await _userManager.FindByIdAsync(currentUser.GetSubjectId());
            if (user == null)
            {
                return null;
            }

            // Pull bookings from database
            List<HotelBooking> bookings = await _context.HotelBookings.Where(i => i.userID == user.Id).ToListAsync<HotelBooking>();
            List<HotelBooking> returnData = new List<HotelBooking>();
            // Map hotel to booking
            foreach (HotelBooking booking in bookings)
            {
                if(booking.packageID is null)
                {
                    booking.hotel = await _context.Hotels.FirstOrDefaultAsync<Hotel>(i => i.id == booking.hotelID);
                    returnData.Add(booking);
                }
            }
            return returnData;
        }

        [HttpGet]
        [Authorize]
        [Route("booking/package/get")]
        public async Task<List<PackageBooking>> GetPackages()
        {
            // Gets the authorized user
            ClaimsPrincipal currentUser = this.User;
            ApplicationUser user = await _userManager.FindByIdAsync(currentUser.GetSubjectId());
            if (user == null)
            {
                return null;
            }

            // Pull bookings from database
            List<PackageBooking> bookings = await _context.PackageBookings.Where(i => i.userID == user.Id).ToListAsync<PackageBooking>();
            // Map tour to booking
            foreach (PackageBooking booking in bookings)
            {
                booking.hotelBooking = await _context.HotelBookings.FirstOrDefaultAsync<HotelBooking>(i => i.id == booking.hotelBookingID);
                booking.tourBooking = await _context.TourBookings.FirstOrDefaultAsync<TourBooking>(i => i.id == booking.tourBookingID);
                booking.tourBooking.tour = await _context.Tours.FirstOrDefaultAsync<Tour>(i => i.id == booking.tourBooking.tourID);
                booking.hotelBooking.hotel = await _context.Hotels.FirstOrDefaultAsync<Hotel>(i => i.id == booking.hotelBooking.hotelID);
            }
            return bookings;
        }
    }
}
