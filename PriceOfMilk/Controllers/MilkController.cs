using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PriceOfMilk.Models;

namespace PriceOfMilk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MilkController : ControllerBase
    {
        private readonly MilkContext _context;

        public MilkController(MilkContext context)
        {
            _context = context;
        }

        // GET: api/Milk
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Milk>>> GetMilks()
        {
            return await _context.Milks.ToListAsync();
        }

        // GET: api/Milk/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Milk>> GetMilk(long id)
        {
            var milk = await _context.Milks.FindAsync(id);

            if (milk == null)
            {
                return NotFound();
            }

            return milk;
        }

        // PUT: api/Milk/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMilk(long id, Milk milk)
        {
            if (id != milk.Id)
            {
                return BadRequest();
            }

            _context.Entry(milk).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MilkExists(id))
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

        // POST: api/Milk
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Milk>> PostMilk(Milk milk)
        {
            _context.Milks.Add(milk);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMilk), new { id = milk.Id }, milk);
        }

        // DELETE: api/Milk/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMilk(long id)
        {
            var milk = await _context.Milks.FindAsync(id);
            if (milk == null)
            {
                return NotFound();
            }

            _context.Milks.Remove(milk);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MilkExists(long id)
        {
            return _context.Milks.Any(e => e.Id == id);
        }
    }
}
