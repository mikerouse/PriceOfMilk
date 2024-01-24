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
    public class MilkTypesController : ControllerBase
    {
        private readonly MilkTypeContext _context;

        public MilkTypesController(MilkTypeContext context)
        {
            _context = context;
        }

        // GET: api/MilkTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MilkType>>> GetMilkTypes()
        {
            return await _context.MilkTypes.ToListAsync();
        }

        // GET: api/MilkTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MilkType>> GetMilkType(long id)
        {
            var milkType = await _context.MilkTypes.FindAsync(id);

            if (milkType == null)
            {
                return NotFound();
            }

            return milkType;
        }

        // PUT: api/MilkTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMilkType(long id, MilkType milkType)
        {
            if (id != milkType.Id)
            {
                return BadRequest();
            }

            _context.Entry(milkType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MilkTypeExists(id))
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

        // POST: api/MilkTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MilkType>> PostMilkType(MilkType milkType)
        {
            _context.MilkTypes.Add(milkType);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMilkType), new { id = milkType.Id }, milkType);
        }

        // DELETE: api/MilkTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMilkType(long id)
        {
            var milkType = await _context.MilkTypes.FindAsync(id);
            if (milkType == null)
            {
                return NotFound();
            }

            _context.MilkTypes.Remove(milkType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MilkTypeExists(long id)
        {
            return _context.MilkTypes.Any(e => e.Id == id);
        }
    }
}
