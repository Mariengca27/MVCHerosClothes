using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HerosMvc.Models;

namespace HerosMvc.Controllers
{
    public class RoupasHerosController : Controller
    {
        private readonly Context _context;

        public RoupasHerosController(Context context)
        {
            _context = context;
        }

        // GET: RoupasHeros
        public async Task<IActionResult> Index()
        {
              return _context.RoupasHeros != null ? 
                          View(await _context.RoupasHeros.ToListAsync()) :
                          Problem("Entity set 'Context.RoupasHeros'  is null.");
        }

        // GET: RoupasHeros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RoupasHeros == null)
            {
                return NotFound();
            }

            var roupasHeros = await _context.RoupasHeros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roupasHeros == null)
            {
                return NotFound();
            }

            return View(roupasHeros);
        }

        // GET: RoupasHeros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoupasHeros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] RoupasHeros roupasHeros)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roupasHeros);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roupasHeros);
        }

        // GET: RoupasHeros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RoupasHeros == null)
            {
                return NotFound();
            }

            var roupasHeros = await _context.RoupasHeros.FindAsync(id);
            if (roupasHeros == null)
            {
                return NotFound();
            }
            return View(roupasHeros);
        }

        // POST: RoupasHeros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] RoupasHeros roupasHeros)
        {
            if (id != roupasHeros.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roupasHeros);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoupasHerosExists(roupasHeros.Id))
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
            return View(roupasHeros);
        }

        // GET: RoupasHeros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RoupasHeros == null)
            {
                return NotFound();
            }

            var roupasHeros = await _context.RoupasHeros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roupasHeros == null)
            {
                return NotFound();
            }

            return View(roupasHeros);
        }

        // POST: RoupasHeros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RoupasHeros == null)
            {
                return Problem("Entity set 'Context.RoupasHeros'  is null.");
            }
            var roupasHeros = await _context.RoupasHeros.FindAsync(id);
            if (roupasHeros != null)
            {
                _context.RoupasHeros.Remove(roupasHeros);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoupasHerosExists(int id)
        {
          return (_context.RoupasHeros?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
