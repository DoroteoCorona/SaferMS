using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SaferMS.Models.DB;

namespace SaferMS.Controllers
{
    public class AspectosController : Controller
    {
        private readonly Safer3Context _context;

        public AspectosController(Safer3Context context)
        {
            _context = context;
        }

        // GET: Aspectos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Aspectos.ToListAsync());
        }

        // GET: Aspectos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aspecto = await _context.Aspectos
                .FirstOrDefaultAsync(m => m.IdAspecto == id);
            if (aspecto == null)
            {
                return NotFound();
            }

            return View(aspecto);
        }

        // GET: Aspectos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aspectos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAspecto,NomAspecto")] Aspecto aspecto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aspecto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aspecto);
        }

        // GET: Aspectos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aspecto = await _context.Aspectos.FindAsync(id);
            if (aspecto == null)
            {
                return NotFound();
            }
            return View(aspecto);
        }

        // POST: Aspectos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAspecto,NomAspecto")] Aspecto aspecto)
        {
            if (id != aspecto.IdAspecto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aspecto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AspectoExists(aspecto.IdAspecto))
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
            return View(aspecto);
        }

        // GET: Aspectos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aspecto = await _context.Aspectos
                .FirstOrDefaultAsync(m => m.IdAspecto == id);
            if (aspecto == null)
            {
                return NotFound();
            }

            return View(aspecto);
        }

        // POST: Aspectos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aspecto = await _context.Aspectos.FindAsync(id);
            _context.Aspectos.Remove(aspecto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AspectoExists(int id)
        {
            return _context.Aspectos.Any(e => e.IdAspecto == id);
        }
    }
}
