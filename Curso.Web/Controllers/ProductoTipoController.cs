using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Curso.DataAccess.Models;

namespace Curso.Web.Controllers
{
    public class ProductoTipoController : Controller
    {
        private readonly EjAppContext _context;

        public ProductoTipoController(EjAppContext context)
        {
            _context = context;
        }

        // GET: ProductoTipo
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductoTipo.ToListAsync());
        }

        // GET: ProductoTipo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productoTipo = await _context.ProductoTipo
                .FirstOrDefaultAsync(m => m.IdProductoTipo == id);
            if (productoTipo == null)
            {
                return NotFound();
            }

            return View(productoTipo);
        }

        // GET: ProductoTipo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductoTipo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProductoTipo,Descripcion")] ProductoTipo productoTipo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productoTipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productoTipo);
        }

        // GET: ProductoTipo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productoTipo = await _context.ProductoTipo.FindAsync(id);
            if (productoTipo == null)
            {
                return NotFound();
            }
            return View(productoTipo);
        }

        // POST: ProductoTipo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProductoTipo,Descripcion")] ProductoTipo productoTipo)
        {
            if (id != productoTipo.IdProductoTipo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productoTipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoTipoExists(productoTipo.IdProductoTipo))
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
            return View(productoTipo);
        }

        // GET: ProductoTipo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productoTipo = await _context.ProductoTipo
                .FirstOrDefaultAsync(m => m.IdProductoTipo == id);
            if (productoTipo == null)
            {
                return NotFound();
            }

            return View(productoTipo);
        }

        // POST: ProductoTipo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productoTipo = await _context.ProductoTipo.FindAsync(id);
            _context.ProductoTipo.Remove(productoTipo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoTipoExists(int id)
        {
            return _context.ProductoTipo.Any(e => e.IdProductoTipo == id);
        }
    }
}
