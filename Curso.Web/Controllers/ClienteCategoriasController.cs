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
    public class ClienteCategoriasController : Controller
    {
        private readonly EjAppContext _context;

        public ClienteCategoriasController(EjAppContext context)
        {
            _context = context;
        }

        // GET: ClienteCategorias
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClienteCategoria.ToListAsync());
        }

        // GET: ClienteCategorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteCategoria = await _context.ClienteCategoria
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clienteCategoria == null)
            {
                return NotFound();
            }

            return View(clienteCategoria);
        }

        // GET: ClienteCategorias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClienteCategorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Categoria")] ClienteCategoria clienteCategoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clienteCategoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clienteCategoria);
        }

        // GET: ClienteCategorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteCategoria = await _context.ClienteCategoria.FindAsync(id);
            if (clienteCategoria == null)
            {
                return NotFound();
            }
            return View(clienteCategoria);
        }

        // POST: ClienteCategorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Categoria")] ClienteCategoria clienteCategoria)
        {
            if (id != clienteCategoria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clienteCategoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteCategoriaExists(clienteCategoria.Id))
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
            return View(clienteCategoria);
        }

        // GET: ClienteCategorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteCategoria = await _context.ClienteCategoria
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clienteCategoria == null)
            {
                return NotFound();
            }

            return View(clienteCategoria);
        }

        // POST: ClienteCategorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clienteCategoria = await _context.ClienteCategoria.FindAsync(id);
            _context.ClienteCategoria.Remove(clienteCategoria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteCategoriaExists(int id)
        {
            return _context.ClienteCategoria.Any(e => e.Id == id);
        }
    }
}
