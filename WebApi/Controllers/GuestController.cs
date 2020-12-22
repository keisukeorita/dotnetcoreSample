using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
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

        // PUT: api/Guest/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGuest(long id, Guest Guest)
        {
            if (id != Guest.id)
            {
                return BadRequest();
            }

            _context.Entry(Guest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuestExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        private bool GuestExists(long id) =>     
        _context.Guest.Any(e => e.id == id);

    }
}
