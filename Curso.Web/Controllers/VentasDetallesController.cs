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
    public class VentasDetallesController : Controller
    {
        private readonly EjAppContext _context;

        public VentasDetallesController(EjAppContext context)
        {
            _context = context;
        }

        // GET: VentasDetalles
        public async Task<IActionResult> Index()
        {
            return View(await _context.VentasDetalle.ToListAsync());
        }

        // GET: VentasDetalles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventasDetalle = await _context.VentasDetalle
                .FirstOrDefaultAsync(m => m.IdDetalleVenta == id);
            if (ventasDetalle == null)
            {
                return NotFound();
            }

            return View(ventasDetalle);
        }

        // GET: VentasDetalles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VentasDetalles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDetalleVenta,Subtotal,Cantidad,IdCompra,PrecioUnitario,IdProducto")] VentasDetalle ventasDetalle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ventasDetalle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ventasDetalle);
        }

        // GET: VentasDetalles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventasDetalle = await _context.VentasDetalle.FindAsync(id);
            if (ventasDetalle == null)
            {
                return NotFound();
            }
            return View(ventasDetalle);
        }

        // POST: VentasDetalles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDetalleVenta,Subtotal,Cantidad,IdCompra,PrecioUnitario,IdProducto")] VentasDetalle ventasDetalle)
        {
            if (id != ventasDetalle.IdDetalleVenta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ventasDetalle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentasDetalleExists(ventasDetalle.IdDetalleVenta))
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
            return View(ventasDetalle);
        }

        // GET: VentasDetalles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventasDetalle = await _context.VentasDetalle
                .FirstOrDefaultAsync(m => m.IdDetalleVenta == id);
            if (ventasDetalle == null)
            {
                return NotFound();
            }

            return View(ventasDetalle);
        }

        // POST: VentasDetalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ventasDetalle = await _context.VentasDetalle.FindAsync(id);
            _context.VentasDetalle.Remove(ventasDetalle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentasDetalleExists(int id)
        {
            return _context.VentasDetalle.Any(e => e.IdDetalleVenta == id);
        }
    }
}
