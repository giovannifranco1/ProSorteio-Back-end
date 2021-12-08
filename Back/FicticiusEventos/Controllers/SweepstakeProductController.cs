using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FicticiusEventos.Models;
using TodoApp.Data;

namespace FicticiusEventos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SweepstakeProductController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public SweepstakeProductController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/SweepstakeProduct
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SweepstakeProduct>>> GetSweepstakeProducts()
        {
            return await _context.SweepstakeProducts.ToListAsync();
        }

        // GET: api/SweepstakeProduct/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SweepstakeProduct>> GetSweepstakeProduct(int id)
        {
            var sweepstakeProduct = await _context.SweepstakeProducts.FindAsync(id);

            if (sweepstakeProduct == null)
            {
                return NotFound();
            }

            return sweepstakeProduct;
        }

        // PUT: api/SweepstakeProduct/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSweepstakeProduct(int id, SweepstakeProduct sweepstakeProduct)
        {
            if (id != sweepstakeProduct.Id)
            {
                return BadRequest();
            }

            _context.Entry(sweepstakeProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SweepstakeProductExists(id))
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

        // POST: api/SweepstakeProduct
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SweepstakeProduct>> PostSweepstakeProduct(SweepstakeProduct sweepstakeProduct)
        {
            _context.SweepstakeProducts.Add(sweepstakeProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSweepstakeProduct", new { id = sweepstakeProduct.Id }, sweepstakeProduct);
        }

        // DELETE: api/SweepstakeProduct/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSweepstakeProduct(int id)
        {
            var sweepstakeProduct = await _context.SweepstakeProducts.FindAsync(id);
            if (sweepstakeProduct == null)
            {
                return NotFound();
            }

            _context.SweepstakeProducts.Remove(sweepstakeProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SweepstakeProductExists(int id)
        {
            return _context.SweepstakeProducts.Any(e => e.Id == id);
        }
    }
}
