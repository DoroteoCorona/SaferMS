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
    public class AutorizacionesController : Controller
    {
        private readonly Safer3Context _context;

        public AutorizacionesController(Safer3Context context)
        {
            _context = context;
        }

        // GET: RegistroObservaciones
        public async Task<IActionResult> Index()
        {
            var safer3Context = _context.RegistroObservacions.Include(r => r.IdAreaNavigation).Include(r => r.IdAspectoNavigation).Include(r => r.IdComportamientoNavigation).Include(r => r.IdDepartamentoNavigation);
            return View(await safer3Context.ToListAsync());
        }

        // GET: RegistroObservaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroObservacion = await _context.RegistroObservacions
                .Include(r => r.IdAreaNavigation)
                .Include(r => r.IdAspectoNavigation)
                .Include(r => r.IdComportamientoNavigation)
                .Include(r => r.IdDepartamentoNavigation)
                .FirstOrDefaultAsync(m => m.IdObservacion == id);
            if (registroObservacion == null)
            {
                return NotFound();
            }

            return View(registroObservacion);
        }

        // GET: RegistroObservaciones/Create
        public IActionResult Create()
        {
            ViewData["IdArea"] = new SelectList(_context.Areas, "IdArea", "NomArea");
            ViewData["IdAspecto"] = new SelectList(_context.Aspectos, "IdAspecto", "NomAspecto");
            ViewData["IdComportamiento"] = new SelectList(_context.Comportamientos, "IdComportamiento", "NomComportamiento");
            ViewData["IdDepartamento"] = new SelectList(_context.Departamentos, "IdDepartamento", "NomDepartamento");
            return View();
        }

        // POST: RegistroObservaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdObservacion,FechaCreacion,UsuarioCreacion,IdArea,ObservacionA,PersonasRetroalimentadas,DescripcionObservacion,AccionesRealizadas,TipoObservacion,IdAspecto,IdComportamiento,Criticidad,IdDepartamento,PlanAccion,TiempoSolucion,PresupuestoRequerido,FechaCompromiso,ComentariosObservacion")] RegistroObservacion registroObservacion)

        {
            if (ModelState.IsValid)
            {
                _context.Add(registroObservacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdArea"] = new SelectList(_context.Areas, "IdArea", "NomArea", registroObservacion.IdArea);
            ViewData["IdAspecto"] = new SelectList(_context.Aspectos, "IdAspecto", "NomAspecto", registroObservacion.IdAspecto);
            ViewData["IdComportamiento"] = new SelectList(_context.Comportamientos, "IdComportamiento", "NomComportamiento", registroObservacion.IdComportamiento);
            ViewData["IdDepartamento"] = new SelectList(_context.Departamentos, "IdDepartamento", "NomDepartamento", registroObservacion.IdDepartamento);

            return View(registroObservacion);
        }

        // GET: RegistroObservaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroObservacion = await _context.RegistroObservacions.FindAsync(id);
            if (registroObservacion == null)
            {
                return NotFound();
            }
            ViewData["IdArea"] = new SelectList(_context.Areas, "IdArea", "NomArea", registroObservacion.IdArea);
            ViewData["IdAspecto"] = new SelectList(_context.Aspectos, "IdAspecto", "NomAspecto", registroObservacion.IdAspecto);
            ViewData["IdComportamiento"] = new SelectList(_context.Comportamientos, "IdComportamiento", "NomComportamiento", registroObservacion.IdComportamiento);
            ViewData["IdDepartamento"] = new SelectList(_context.Departamentos, "IdDepartamento", "NomDepartamento", registroObservacion.IdDepartamento);
            return View(registroObservacion);
        }

        // POST: RegistroObservaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdObservacion,FechaCreacion,UsuarioCreacion,IdArea,ObservacionA,PersonasRetroalimentadas,DescripcionObservacion,AccionesRealizadas,TipoObservacion,IdAspecto,IdComportamiento,Criticidad,IdDepartamento,PlanAccion,TiempoSolucion,PresupuestoRequerido,FechaCompromiso,ComentariosObservacion")] RegistroObservacion registroObservacion)
        {
            if (id != registroObservacion.IdObservacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registroObservacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistroObservacionExists(registroObservacion.IdObservacion))
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
            ViewData["IdArea"] = new SelectList(_context.Areas, "IdArea", "NomArea", registroObservacion.IdArea);
            ViewData["IdAspecto"] = new SelectList(_context.Aspectos, "IdAspecto", "NomAspecto", registroObservacion.IdAspecto);
            ViewData["IdComportamiento"] = new SelectList(_context.Comportamientos, "IdComportamiento", "NomComportamiento", registroObservacion.IdComportamiento);
            ViewData["IdDepartamento"] = new SelectList(_context.Departamentos, "IdDepartamento", "NomDepartamento", registroObservacion.IdDepartamento);
            return View(registroObservacion);
        }

        // GET: RegistroObservaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroObservacion = await _context.RegistroObservacions
                .Include(r => r.IdAreaNavigation)
                .Include(r => r.IdAspectoNavigation)
                .Include(r => r.IdComportamientoNavigation)
                .Include(r => r.IdDepartamentoNavigation)
                .FirstOrDefaultAsync(m => m.IdObservacion == id);
            if (registroObservacion == null)
            {
                return NotFound();
            }

            return View(registroObservacion);
        }

        // POST: RegistroObservaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registroObservacion = await _context.RegistroObservacions.FindAsync(id);
            _context.RegistroObservacions.Remove(registroObservacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistroObservacionExists(int id)
        {
            return _context.RegistroObservacions.Any(e => e.IdObservacion == id);
        }
    }
}
