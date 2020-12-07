using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuestController : ControllerBase
    {
    
        private readonly MyContext _context;

        public GuestController(MyContext context)
        {
            _context = context;
        }

        // GET: api/Guest/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Guest>> GetGuest(int id)
        {
            
            var Guest = await _context.Guest.FindAsync(id);

            if (Guest == null)
            {
                return NotFound();
            }

            return Guest;
        }

    }
}
