#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AvoidScurvyMVCApplication.Models;

namespace AvoidScurvyMVCApplication.Controllers
{
    public class ProductViewingsController : Controller
    {
        private readonly AvoidScurvyContext _context;

        public ProductViewingsController(AvoidScurvyContext context)
        {
            _context = context;
        }

        // GET: ProductViewings
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductViewings.ToListAsync());
        }

        // GET: ProductViewings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productViewing = await _context.ProductViewings
                .FirstOrDefaultAsync(m => m.ProductViewingId == id);
            if (productViewing == null)
            {
                return NotFound();
            }

            return View(productViewing);
        }

        // GET: ProductViewings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductViewings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductViewingId,ProductId,ViewingTime,StoreName,PricePerServing")] ProductViewing productViewing)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productViewing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productViewing);
        }

        // GET: ProductViewings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productViewing = await _context.ProductViewings.FindAsync(id);
            if (productViewing == null)
            {
                return NotFound();
            }
            return View(productViewing);
        }

        // POST: ProductViewings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductViewingId,ProductId,ViewingTime,StoreName,PricePerServing")] ProductViewing productViewing)
        {
            if (id != productViewing.ProductViewingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productViewing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductViewingExists(productViewing.ProductViewingId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(productViewing);
        }

        // GET: ProductViewings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productViewing = await _context.ProductViewings
                .FirstOrDefaultAsync(m => m.ProductViewingId == id);
            if (productViewing == null)
            {
                return NotFound();
            }

            return View(productViewing);
        }

        // POST: ProductViewings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productViewing = await _context.ProductViewings.FindAsync(id);
            _context.ProductViewings.Remove(productViewing);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductViewingExists(int id)
        {
            return _context.ProductViewings.Any(e => e.ProductViewingId == id);
        }
    }
}
