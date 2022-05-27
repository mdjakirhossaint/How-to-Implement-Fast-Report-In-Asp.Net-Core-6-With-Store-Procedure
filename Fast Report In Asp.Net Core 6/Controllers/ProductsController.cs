#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FastReportIntegrateWithStoreProcedureInAspNetCore6.Data;
using FastReportIntegrateWithStoreProcedureInAspNetCore6.Entity;

namespace FastReportIntegrateWithStoreProcedureInAspNetCore6.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Products.Include(t => t.TblCategory);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProduct = await _context.Products
                .Include(t => t.TblCategory)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tblProduct == null)
            {
                return NotFound();
            }

            return View(tblProduct);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["TblCategoryID"] = new SelectList(_context.Categories, "ID", "CategoryName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TblProduct tblProduct)
        {
           
              _context.Add(tblProduct);
              await _context.SaveChangesAsync();
              return RedirectToAction(nameof(Index));

            ViewData["TblCategoryID"] = new SelectList(_context.Categories, "ID", "CategoryName", tblProduct.TblCategoryID);
            return View(tblProduct);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProduct = await _context.Products.FindAsync(id);
            if (tblProduct == null)
            {
                return NotFound();
            }
            ViewData["TblCategoryID"] = new SelectList(_context.Categories, "ID", "ID", tblProduct.TblCategoryID);
            return View(tblProduct);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,TblProduct tblProduct)
        {
            if (id != tblProduct.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblProductExists(tblProduct.ID))
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
            ViewData["TblCategoryID"] = new SelectList(_context.Categories, "ID", "ID", tblProduct.TblCategoryID);
            return View(tblProduct);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProduct = await _context.Products
                .Include(t => t.TblCategory)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tblProduct == null)
            {
                return NotFound();
            }

            return View(tblProduct);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblProduct = await _context.Products.FindAsync(id);
            _context.Products.Remove(tblProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblProductExists(int id)
        {
            return _context.Products.Any(e => e.ID == id);
        }
    }
}
