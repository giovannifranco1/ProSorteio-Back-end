using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProSorteio.Models;
using TodoApp.Data;

namespace FicticiusEventos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SweepstakeController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public SweepstakeController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Sweepstake
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sweepstake>>> GetSweepstakes()
        {
            return await _context.Sweepstakes.ToListAsync();
        }

        // GET: api/Sweepstake/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sweepstake>> GetSweepstake(int id)
        {
            var sweepstake = await _context.Sweepstakes.FindAsync(id);

            if (sweepstake == null)
            {
                return NotFound();
            }

            return sweepstake;
        }

        // PUT: api/Sweepstake/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSweepstake(int id, Sweepstake sweepstake)
        {
            if (id != sweepstake.Id)
            {
                return BadRequest();
            }

            _context.Entry(sweepstake).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SweepstakeExists(id))
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

        // POST: api/Sweepstake
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sweepstake>> PostSweepstake(Sweepstake sweepstake)
        {
            _context.Sweepstakes.Add(sweepstake);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSweepstake", new { id = sweepstake.Id }, sweepstake);
        }

        // DELETE: api/Sweepstake/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSweepstake(int id)
        {
            var sweepstake = await _context.Sweepstakes.FindAsync(id);
            if (sweepstake == null)
            {
                return NotFound();
            }

            _context.Sweepstakes.Remove(sweepstake);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SweepstakeExists(int id)
        {
            return _context.Sweepstakes.Any(e => e.Id == id);
        }
    }
}
