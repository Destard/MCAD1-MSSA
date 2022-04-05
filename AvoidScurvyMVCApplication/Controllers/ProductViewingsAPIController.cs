#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AvoidScurvyMVCApplication.Models;

namespace AvoidScurvyMVCApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductViewingsAPIController : ControllerBase
    {
        private readonly AvoidScurvyContext _context;

        public ProductViewingsAPIController(AvoidScurvyContext context)
        {
            _context = context;
        }

        // GET: api/ProductViewingsAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductViewing>>> GetProductViewings()
        {
            return await _context.ProductViewings.ToListAsync();
        }

        // GET: api/ProductViewingsAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductViewing>> GetProductViewing(int id)
        {
            var productViewing = await _context.ProductViewings.FindAsync(id);

            if (productViewing == null)
            {
                return NotFound();
            }

            return productViewing;
        }

        // PUT: api/ProductViewingsAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductViewing(int id, ProductViewing productViewing)
        {
            if (id != productViewing.ProductViewingId)
            {
                return BadRequest();
            }

            _context.Entry(productViewing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductViewingExists(id))
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

        // POST: api/ProductViewingsAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductViewing>> PostProductViewing([FromBody] ProductViewing productViewing)
        {
            _context.ProductViewings.Add(productViewing);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductViewing", new { id = productViewing.ProductViewingId }, productViewing);
        }

        // DELETE: api/ProductViewingsAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductViewing(int id)
        {
            var productViewing = await _context.ProductViewings.FindAsync(id);
            if (productViewing == null)
            {
                return NotFound();
            }

            _context.ProductViewings.Remove(productViewing);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductViewingExists(int id)
        {
            return _context.ProductViewings.Any(e => e.ProductViewingId == id);
        }
    }
}
