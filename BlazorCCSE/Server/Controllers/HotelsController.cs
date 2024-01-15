using BlazorCCSE.Server.Data;
using BlazorCCSE.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorCCSE.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HotelsController> _logger;

        public HotelsController(ILogger<HotelsController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<List<Hotel>> Get() {
            // Pull hotels from database
            //return await _context.Hotels.FirstOrDefaultAsync<Hotel>(i => i.ID == id);
            return await _context.Hotels.ToListAsync<Hotel>();
            
        }
    }
}
