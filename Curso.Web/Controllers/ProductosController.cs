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
    public class ProductosController : Controller
    {
        private readonly EjAppContext _context;

        public ProductosController(EjAppContext context)
        {
            _context = context;
        }

        // GET: Productos
        public async Task<IActionResult> Index()
        {
            var ejAppContext = _context.Productos.Include(p => p.IdProductoCategoriaNavigation).Include(p => p.IdProductoTipoNavigation);
            return View(await ejAppContext.ToListAsync());
        }

        // GET: Productos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productos = await _context.Productos
                .Include(p => p.IdProductoCategoriaNavigation)
                .Include(p => p.IdProductoTipoNavigation)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (productos == null)
            {
                return NotFound();
            }

            return View(productos);
        }

        // GET: Productos/Create
        public IActionResult Create()
        {
            ViewData["IdProductoCategoria"] = new SelectList(_context.CategoriaProducto, "IdCategoriaProducto", "Categoria");
            ViewData["IdProductoTipo"] = new SelectList(_context.ProductoTipo, "IdProductoTipo", "Descripcion");
            return View();
        }

        // POST: Productos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,Nombre,Marca,Precio,IdProductoTipo,IdProductoCategoria")] Productos productos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProductoCategoria"] = new SelectList(_context.CategoriaProducto, "IdCategoriaProducto", "Categoria", productos.IdProductoCategoria);
            ViewData["IdProductoTipo"] = new SelectList(_context.ProductoTipo, "IdProductoTipo", "Descripcion", productos.IdProductoTipo);
            return View(productos);
        }

        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productos = await _context.Productos.FindAsync(id);
            if (productos == null)
            {
                return NotFound();
            }
            ViewData["IdProductoCategoria"] = new SelectList(_context.CategoriaProducto, "IdCategoriaProducto", "Categoria", productos.IdProductoCategoria);
            ViewData["IdProductoTipo"] = new SelectList(_context.ProductoTipo, "IdProductoTipo", "Descripcion", productos.IdProductoTipo);
            return View(productos);
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,Nombre,Marca,Precio,IdProductoTipo,IdProductoCategoria")] Productos productos)
        {
            if (id != productos.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductosExists(productos.ProductId))
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
            ViewData["IdProductoCategoria"] = new SelectList(_context.CategoriaProducto, "IdCategoriaProducto", "Categoria", productos.IdProductoCategoria);
            ViewData["IdProductoTipo"] = new SelectList(_context.ProductoTipo, "IdProductoTipo", "Descripcion", productos.IdProductoTipo);
            return View(productos);
        }

        // GET: Productos/Delete/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productos = await _context.Productos
                .Include(p => p.IdProductoCategoriaNavigation)
                .Include(p => p.IdProductoTipoNavigation)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (productos == null)
            {
                return NotFound();
            }

            return View(productos);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Administrador")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productos = await _context.Productos.FindAsync(id);
            _context.Productos.Remove(productos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductosExists(int id)
        {
            return _context.Productos.Any(e => e.ProductId == id);
        }
    }
}
