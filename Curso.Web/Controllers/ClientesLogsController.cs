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
    public class ClientesLogsController : Controller
    {
        private readonly EjAppContext _context;

        public ClientesLogsController(EjAppContext context)
        {
            _context = context;
        }

        // GET: ClientesLogs
        public async Task<IActionResult> Index()
        {
            var ejAppContext = _context.ClientesLog.Include(c => c.IdClienteNavigation).Include(c => c.IdUsuarioNavigation);
            return View(await ejAppContext.ToListAsync());
        }

        // GET: ClientesLogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientesLog = await _context.ClientesLog
                .Include(c => c.IdClienteNavigation)
                .Include(c => c.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientesLog == null)
            {
                return NotFound();
            }

            return View(clientesLog);
        }

        // GET: ClientesLogs/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Apellido");
            ViewData["IdUsuario"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            return View();
        }

        // POST: ClientesLogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Apellido,Nombre,Direccion,Email,ClienteTipoId,ClienteCategoriaId,IdCliente,IdUsuario")] ClientesLog clientesLog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientesLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Apellido", clientesLog.IdCliente);
            ViewData["IdUsuario"] = new SelectList(_context.AspNetUsers, "Id", "Id", clientesLog.IdUsuario);
            return View(clientesLog);
        }

        // GET: ClientesLogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientesLog = await _context.ClientesLog.FindAsync(id);
            if (clientesLog == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Apellido", clientesLog.IdCliente);
            ViewData["IdUsuario"] = new SelectList(_context.AspNetUsers, "Id", "Id", clientesLog.IdUsuario);
            return View(clientesLog);
        }

        // POST: ClientesLogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Apellido,Nombre,Direccion,Email,ClienteTipoId,ClienteCategoriaId,IdCliente,IdUsuario")] ClientesLog clientesLog)
        {
            if (id != clientesLog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientesLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientesLogExists(clientesLog.Id))
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
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Apellido", clientesLog.IdCliente);
            ViewData["IdUsuario"] = new SelectList(_context.AspNetUsers, "Id", "Id", clientesLog.IdUsuario);
            return View(clientesLog);
        }

        // GET: ClientesLogs/Delete/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientesLog = await _context.ClientesLog
                .Include(c => c.IdClienteNavigation)
                .Include(c => c.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientesLog == null)
            {
                return NotFound();
            }

            return View(clientesLog);
        }

        // POST: ClientesLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientesLog = await _context.ClientesLog.FindAsync(id);
            _context.ClientesLog.Remove(clientesLog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientesLogExists(int id)
        {
            return _context.ClientesLog.Any(e => e.Id == id);
        }
    }
}
