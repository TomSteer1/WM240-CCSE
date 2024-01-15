using BlazorCCSE.Server.Data;
using BlazorCCSE.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorCCSE.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToursController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ToursController> _logger;

        public ToursController(ILogger<ToursController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<List<Tour>> Get() {
            // Pull Tours from database
            //return await _context.Tours.FirstOrDefaultAsync<Hotel>(i => i.ID == id);
            return await _context.Tours.ToListAsync<Tour>();
            
        }
    }
}
