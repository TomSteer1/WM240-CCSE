using BlazorCCSE.Server.Data;
using BlazorCCSE.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorCCSE.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/{id}")]
    public class HotelController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HotelController> _logger;

        public HotelController(ILogger<HotelController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<Hotel> GetSpecific(Guid id) {
            // Pull hotels from database
            Console.WriteLine("Fetching " + id);
            return await _context.Hotels.FirstOrDefaultAsync<Hotel>(i => i.id == id);
        }
    }
}
