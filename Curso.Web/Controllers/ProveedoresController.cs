using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Curso.DataAccess.Models;
using Microsoft.AspNetCore.Authorization;

namespace Curso.Web.Controllers
{
    public class ProveedoresController : Controller
    {
        private readonly EjAppContext _context;

        public ProveedoresController(EjAppContext context)
        {
            _context = context;
        }

        // GET: Proveedores
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var ejAppContext = _context.Proveedores.Include(p => p.IdCategoriaProveedoresNavigation);
            return View(await ejAppContext.ToListAsync());
        }

        // GET: Proveedores/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveedores = await _context.Proveedores
                .Include(p => p.IdCategoriaProveedoresNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proveedores == null)
            {
                return NotFound();
            }

            return View(proveedores);
        }

        // GET: Proveedores/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["IdCategoriaProveedores"] = new SelectList(_context.ProveedoresCategoria, "IdCategoriaProveedores", "NombreCategoria");
            return View();
        }

        // POST: Proveedores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,Nombre,FechaInscripcion,IdTipoProveedores,IdCategoriaProveedores")] Proveedores proveedores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proveedores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCategoriaProveedores"] = new SelectList(_context.ProveedoresCategoria, "IdCategoriaProveedores", "NombreCategoria", proveedores.IdCategoriaProveedores);
            return View(proveedores);
        }

        // GET: Proveedores/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveedores = await _context.Proveedores.FindAsync(id);
            if (proveedores == null)
            {
                return NotFound();
            }
            ViewData["IdCategoriaProveedores"] = new SelectList(_context.ProveedoresCategoria, "IdCategoriaProveedores", "NombreCategoria", proveedores.IdCategoriaProveedores);
            return View(proveedores);
        }

        // POST: Proveedores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,FechaInscripcion,IdTipoProveedores,IdCategoriaProveedores")] Proveedores proveedores)
        {
            if (id != proveedores.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proveedores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProveedoresExists(proveedores.Id))
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
            ViewData["IdCategoriaProveedores"] = new SelectList(_context.ProveedoresCategoria, "IdCategoriaProveedores", "NombreCategoria", proveedores.IdCategoriaProveedores);
            return View(proveedores);
        }

        // GET: Proveedores/Delete/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveedores = await _context.Proveedores
                .Include(p => p.IdCategoriaProveedoresNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proveedores == null)
            {
                return NotFound();
            }

            return View(proveedores);
        }

        // POST: Proveedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proveedores = await _context.Proveedores.FindAsync(id);
            _context.Proveedores.Remove(proveedores);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProveedoresExists(int id)
        {
            return _context.Proveedores.Any(e => e.Id == id);
        }
    }
}
