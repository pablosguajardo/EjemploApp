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
    public class ProveedoresCategoriasController : Controller
    {
        private readonly EjAppContext _context;

        public ProveedoresCategoriasController(EjAppContext context)
        {
            _context = context;
        }

        // GET: ProveedoresCategorias
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProveedoresCategoria.ToListAsync());
        }

        // GET: ProveedoresCategorias/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveedoresCategoria = await _context.ProveedoresCategoria
                .FirstOrDefaultAsync(m => m.IdCategoriaProveedores == id);
            if (proveedoresCategoria == null)
            {
                return NotFound();
            }

            return View(proveedoresCategoria);
        }

        // GET: ProveedoresCategorias/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProveedoresCategorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("IdCategoriaProveedores,NombreCategoria,DescripcionCategoria,Comentarios")] ProveedoresCategoria proveedoresCategoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proveedoresCategoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proveedoresCategoria);
        }

        // GET: ProveedoresCategorias/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveedoresCategoria = await _context.ProveedoresCategoria.FindAsync(id);
            if (proveedoresCategoria == null)
            {
                return NotFound();
            }
            return View(proveedoresCategoria);
        }

        // POST: ProveedoresCategorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("IdCategoriaProveedores,NombreCategoria,DescripcionCategoria,Comentarios")] ProveedoresCategoria proveedoresCategoria)
        {
            if (id != proveedoresCategoria.IdCategoriaProveedores)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proveedoresCategoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProveedoresCategoriaExists(proveedoresCategoria.IdCategoriaProveedores))
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
            return View(proveedoresCategoria);
        }

        // GET: ProveedoresCategorias/Delete/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveedoresCategoria = await _context.ProveedoresCategoria
                .FirstOrDefaultAsync(m => m.IdCategoriaProveedores == id);
            if (proveedoresCategoria == null)
            {
                return NotFound();
            }

            return View(proveedoresCategoria);
        }

        // POST: ProveedoresCategorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proveedoresCategoria = await _context.ProveedoresCategoria.FindAsync(id);
            _context.ProveedoresCategoria.Remove(proveedoresCategoria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProveedoresCategoriaExists(int id)
        {
            return _context.ProveedoresCategoria.Any(e => e.IdCategoriaProveedores == id);
        }
    }
}
