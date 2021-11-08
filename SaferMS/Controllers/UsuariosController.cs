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
    public class UsuariosController : Controller
    {
        private readonly Safer3Context _context;

        public UsuariosController(Safer3Context context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            var safer3Context = _context.Usuarios.Include(u => u.IdUsuario1).Include(u => u.IdUsuario2).Include(u => u.IdUsuarioNavigation);
            return View(await safer3Context.ToListAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .Include(u => u.IdUsuario1)
                .Include(u => u.IdUsuario2)
                .Include(u => u.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            ViewData["IdUsuario"] = new SelectList(_context.Puestos, "IdPuesto", "NomPuesto");
            ViewData["IdUsuario"] = new SelectList(_context.Sexos, "IdSexo", "Genero");
            ViewData["IdUsuario"] = new SelectList(_context.Departamentos, "IdDepartamento", "NomDepartamento");
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuario,Nombre,Apellidos,NumEmpleado,Email,Idsexo,IdPuesto,Posición,IdDepartamento,Privilegio,Contraseña")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUsuario"] = new SelectList(_context.Puestos, "IdPuesto", "NomPuesto", usuario.IdUsuario);
            ViewData["IdUsuario"] = new SelectList(_context.Sexos, "IdSexo", "Genero", usuario.IdUsuario);
            ViewData["IdUsuario"] = new SelectList(_context.Departamentos, "IdDepartamento", "NomDepartamento", usuario.IdUsuario);
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewData["IdUsuario"] = new SelectList(_context.Puestos, "IdPuesto", "NomPuesto", usuario.IdUsuario);
            ViewData["IdUsuario"] = new SelectList(_context.Sexos, "IdSexo", "Genero", usuario.IdUsuario);
            ViewData["IdUsuario"] = new SelectList(_context.Departamentos, "IdDepartamento", "NomDepartamento", usuario.IdUsuario);
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUsuario,Nombre,Apellidos,NumEmpleado,Email,Idsexo,IdPuesto,Posición,IdDepartamento,Privilegio,Contraseña")] Usuario usuario)
        {
            if (id != usuario.IdUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.IdUsuario))
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
            ViewData["IdUsuario"] = new SelectList(_context.Puestos, "IdPuesto", "NomPuesto", usuario.IdUsuario);
            ViewData["IdUsuario"] = new SelectList(_context.Sexos, "IdSexo", "Genero", usuario.IdUsuario);
            ViewData["IdUsuario"] = new SelectList(_context.Departamentos, "IdDepartamento", "NomDepartamento", usuario.IdUsuario);
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .Include(u => u.IdUsuario1)
                .Include(u => u.IdUsuario2)
                .Include(u => u.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.IdUsuario == id);
        }
    }
}
