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
    public class ClienteTipoesController : Controller
    {
        private readonly EjAppContext _context;

        public ClienteTipoesController(EjAppContext context)
        {
            _context = context;
        }

        // GET: ClienteTipoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClienteTipo.ToListAsync());
        }

        // GET: ClienteTipoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteTipo = await _context.ClienteTipo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clienteTipo == null)
            {
                return NotFound();
            }

            return View(clienteTipo);
        }

        // GET: ClienteTipoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClienteTipoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,CategoriaId,Detalles,Borrado")] ClienteTipo clienteTipo)
        {
            if (ModelState.IsValid)
            {
                clienteTipo.Borrado = false;
                _context.Add(clienteTipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clienteTipo);
        }

        // GET: ClienteTipoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteTipo = await _context.ClienteTipo.FindAsync(id);
            if (clienteTipo == null)
            {
                return NotFound();
            }
            return View(clienteTipo);
        }

        // POST: ClienteTipoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,CategoriaId,Detalles,Borrado")] ClienteTipo clienteTipo)
        {
            if (id != clienteTipo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                clienteTipo.Borrado = false;
                try
                {
                    _context.Update(clienteTipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteTipoExists(clienteTipo.Id))
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
            return View(clienteTipo);
        }

        // GET: ClienteTipoes/Delete/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteTipo = await _context.ClienteTipo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clienteTipo == null)
            {
                return NotFound();
            }

            return View(clienteTipo);
        }

        // POST: ClienteTipoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clienteTipo = await _context.ClienteTipo.FindAsync(id);
            _context.ClienteTipo.Remove(clienteTipo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteTipoExists(int id)
        {
            return _context.ClienteTipo.Any(e => e.Id == id);
        }
    }
}
