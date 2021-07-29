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
    public class ComprasController : Controller
    {
        private readonly EjAppContext _context;

        public ComprasController(EjAppContext context)
        {
            _context = context;
        }

        // GET: Compras
        public async Task<IActionResult> Index()
        {
            var ejAppContext = _context.Compras.Include(c => c.IdCompraDetalleNavigation).Include(c => c.IdformapagoNavigation);
            return View(await ejAppContext.ToListAsync());
        }

        // GET: Compras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compras = await _context.Compras
                .Include(c => c.IdCompraDetalleNavigation)
                .Include(c => c.IdformapagoNavigation)
                .FirstOrDefaultAsync(m => m.IdCompras == id);
            if (compras == null)
            {
                return NotFound();
            }

            return View(compras);
        }

        // GET: Compras/Create
        public IActionResult Create()
        {
            ViewData["IdCompraDetalle"] = new SelectList(_context.ComprasDetalle, "IdComprasDetalle", "Descripcion");
            ViewData["Idformapago"] = new SelectList(_context.FormaDePago, "Id", "Descripción");
            return View();
        }

        // POST: Compras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCompras,NroCompra,FechaCompra,PuntoDeVenta,IdCompraDetalle,Idformapago")] Compras compras)
        {
            if (ModelState.IsValid)
            {
                _context.Add(compras);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCompraDetalle"] = new SelectList(_context.ComprasDetalle, "IdComprasDetalle", "Descripcion", compras.IdCompraDetalle);
            ViewData["Idformapago"] = new SelectList(_context.FormaDePago, "Id", "Descripción", compras.Idformapago);
            return View(compras);
        }

        // GET: Compras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compras = await _context.Compras.FindAsync(id);
            if (compras == null)
            {
                return NotFound();
            }
            ViewData["IdCompraDetalle"] = new SelectList(_context.ComprasDetalle, "IdComprasDetalle", "Descripcion", compras.IdCompraDetalle);
            ViewData["Idformapago"] = new SelectList(_context.FormaDePago, "Id", "Descripción", compras.Idformapago);
            return View(compras);
        }

        // POST: Compras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCompras,NroCompra,FechaCompra,PuntoDeVenta,IdCompraDetalle,Idformapago")] Compras compras)
        {
            if (id != compras.IdCompras)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compras);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComprasExists(compras.IdCompras))
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
            ViewData["IdCompraDetalle"] = new SelectList(_context.ComprasDetalle, "IdComprasDetalle", "Descripcion", compras.IdCompraDetalle);
            ViewData["Idformapago"] = new SelectList(_context.FormaDePago, "Id", "Descripción", compras.Idformapago);
            return View(compras);
        }

        // GET: Compras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compras = await _context.Compras
                .Include(c => c.IdCompraDetalleNavigation)
                .Include(c => c.IdformapagoNavigation)
                .FirstOrDefaultAsync(m => m.IdCompras == id);
            if (compras == null)
            {
                return NotFound();
            }

            return View(compras);
        }

        // POST: Compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var compras = await _context.Compras.FindAsync(id);
            _context.Compras.Remove(compras);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComprasExists(int id)
        {
            return _context.Compras.Any(e => e.IdCompras == id);
        }
    }
}
