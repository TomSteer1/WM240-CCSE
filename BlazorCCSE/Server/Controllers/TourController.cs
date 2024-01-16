using BlazorCCSE.Server.Data;
using BlazorCCSE.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorCCSE.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/{id}")]
    public class TourController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<TourController> _logger;

        public TourController(ILogger<TourController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<Tour> GetSpecific(string id) {
            // Pull Tours from database
            Console.WriteLine("Fetching " + id);
            return await _context.Tours.FirstOrDefaultAsync<Tour>(i => i.id == id);
        }
    }
}
