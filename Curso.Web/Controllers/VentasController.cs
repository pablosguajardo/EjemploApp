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
    public class VentasController : Controller
    {
        private readonly EjAppContext _context;

        public VentasController(EjAppContext context)
        {
            _context = context;
        }

        // GET: Ventas
        public async Task<IActionResult> Index()
        {
            var ejAppContext = _context.Ventas.Include(v => v.IdVentasDetalleNavigation).Include(v => v.Client);
            return View(await ejAppContext.ToListAsync());
        }

        // GET: Ventas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventas = await _context.Ventas
                .Include(v => v.IdVentasDetalleNavigation)
                .Include(v => v.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ventas == null)
            {
                return NotFound();
            }

            return View(ventas);
        }

        // GET: Ventas/Create
        public IActionResult Create()
        {
            ViewData["IdVentasDetalle"] = new SelectList(_context.VentasDetalle, "IdDetalleVenta", "IdDetalleVenta");
            ViewData["ClientId"] = new SelectList(_context.Clientes, "Id", "Id");
            return View();
        }

        // POST: Ventas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClientId,Total,Fecha,Descripcion,IdVentasDetalle")] Ventas ventas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ventas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdVentasDetalle"] = new SelectList(_context.VentasDetalle, "IdDetalleVenta", "IdDetalleVenta", ventas.IdVentasDetalle);
            ViewData["ClientId"] = new SelectList(_context.Clientes, "Id", "Id", ventas.ClientId);
            return View(ventas);
        }

        // GET: Ventas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventas = await _context.Ventas.FindAsync(id);
            if (ventas == null)
            {
                return NotFound();
            }
            ViewData["IdVentasDetalle"] = new SelectList(_context.VentasDetalle, "IdDetalleVenta", "IdDetalleVenta", ventas.IdVentasDetalle);
            ViewData["ClientId"] = new SelectList(_context.Clientes, "Id", "Id", ventas.ClientId);
            return View(ventas);
        }

        // POST: Ventas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClientId,Total,Fecha,Borrado,Descripcion,IdVentasDetalle")] Ventas ventas)
        {
            if (id != ventas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ventas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentasExists(ventas.Id))
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
            ViewData["IdVentasDetalle"] = new SelectList(_context.VentasDetalle, "IdDetalleVenta", "IdDetalleVenta", ventas.IdVentasDetalle);
            ViewData["ClientId"] = new SelectList(_context.Clientes, "Id", "Id", ventas.ClientId);
            return View(ventas);
        }

        // GET: Ventas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventas = await _context.Ventas
                .Include(v => v.IdVentasDetalleNavigation)
                .Include(v => v.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ventas == null)
            {
                return NotFound();
            }

            return View(ventas);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ventas = await _context.Ventas.FindAsync(id);
            _context.Ventas.Remove(ventas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentasExists(int id)
        {
            return _context.Ventas.Any(e => e.Id == id);
        }
    }
}
