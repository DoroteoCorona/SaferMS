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
    public class ComportamientosController : Controller
    {
        private readonly Safer3Context _context;

        public ComportamientosController(Safer3Context context)
        {
            _context = context;
        }

        // GET: Comportamientos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Comportamientos.ToListAsync());
        }

        // GET: Comportamientos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comportamiento = await _context.Comportamientos
                .FirstOrDefaultAsync(m => m.IdComportamiento == id);
            if (comportamiento == null)
            {
                return NotFound();
            }

            return View(comportamiento);
        }

        // GET: Comportamientos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Comportamientos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdComportamiento,NomComportamiento")] Comportamiento comportamiento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comportamiento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(comportamiento);
        }

        // GET: Comportamientos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comportamiento = await _context.Comportamientos.FindAsync(id);
            if (comportamiento == null)
            {
                return NotFound();
            }
            return View(comportamiento);
        }

        // POST: Comportamientos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdComportamiento,NomComportamiento")] Comportamiento comportamiento)
        {
            if (id != comportamiento.IdComportamiento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comportamiento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComportamientoExists(comportamiento.IdComportamiento))
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
            return View(comportamiento);
        }

        // GET: Comportamientos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comportamiento = await _context.Comportamientos
                .FirstOrDefaultAsync(m => m.IdComportamiento == id);
            if (comportamiento == null)
            {
                return NotFound();
            }

            return View(comportamiento);
        }

        // POST: Comportamientos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comportamiento = await _context.Comportamientos.FindAsync(id);
            _context.Comportamientos.Remove(comportamiento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComportamientoExists(int id)
        {
            return _context.Comportamientos.Any(e => e.IdComportamiento == id);
        }
    }
}
