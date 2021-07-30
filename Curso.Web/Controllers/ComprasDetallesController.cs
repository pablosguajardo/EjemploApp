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
    public class ComprasDetallesController : Controller
    {
        private readonly EjAppContext _context;

        public ComprasDetallesController(EjAppContext context)
        {
            _context = context;
        }

        // GET: ComprasDetalles
        public async Task<IActionResult> Index()
        {
            return View(await _context.ComprasDetalle.ToListAsync());
        }

        // GET: ComprasDetalles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comprasDetalle = await _context.ComprasDetalle
                .FirstOrDefaultAsync(m => m.IdComprasDetalle == id);
            if (comprasDetalle == null)
            {
                return NotFound();
            }

            return View(comprasDetalle);
        }

        // GET: ComprasDetalles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ComprasDetalles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdComprasDetalle,Descripcion")] ComprasDetalle comprasDetalle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comprasDetalle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(comprasDetalle);
        }

        // GET: ComprasDetalles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comprasDetalle = await _context.ComprasDetalle.FindAsync(id);
            if (comprasDetalle == null)
            {
                return NotFound();
            }
            return View(comprasDetalle);
        }

        // POST: ComprasDetalles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdComprasDetalle,Descripcion")] ComprasDetalle comprasDetalle)
        {
            if (id != comprasDetalle.IdComprasDetalle)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comprasDetalle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComprasDetalleExists(comprasDetalle.IdComprasDetalle))
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
            return View(comprasDetalle);
        }

        // GET: ComprasDetalles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comprasDetalle = await _context.ComprasDetalle
                .FirstOrDefaultAsync(m => m.IdComprasDetalle == id);
            if (comprasDetalle == null)
            {
                return NotFound();
            }

            return View(comprasDetalle);
        }

        // POST: ComprasDetalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comprasDetalle = await _context.ComprasDetalle.FindAsync(id);
            _context.ComprasDetalle.Remove(comprasDetalle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComprasDetalleExists(int id)
        {
            return _context.ComprasDetalle.Any(e => e.IdComprasDetalle == id);
        }
    }
}
