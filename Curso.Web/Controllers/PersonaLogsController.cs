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
    public class PersonaLogsController : Controller
    {
        private readonly EjAppContext _context;

        public PersonaLogsController(EjAppContext context)
        {
            _context = context;
        }

        // GET: PersonaLogs
        public async Task<IActionResult> Index()
        {
            var ejAppContext = _context.PersonaLog.Include(p => p.IdPersonaNavigation);
            return View(await ejAppContext.ToListAsync());
        }

        // GET: PersonaLogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personaLog = await _context.PersonaLog
                .Include(p => p.IdPersonaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personaLog == null)
            {
                return NotFound();
            }

            return View(personaLog);
        }

        // GET: PersonaLogs/Create
        public IActionResult Create()
        {
            ViewData["IdPersona"] = new SelectList(_context.Personas, "Id", "Apellido");
            return View();
        }

        // POST: PersonaLogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Hermanos,FechaDeNacimiento,IdPersona,Direccion")] PersonaLog personaLog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personaLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPersona"] = new SelectList(_context.Personas, "Id", "Apellido", personaLog.IdPersona);
            return View(personaLog);
        }

        // GET: PersonaLogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personaLog = await _context.PersonaLog.FindAsync(id);
            if (personaLog == null)
            {
                return NotFound();
            }
            ViewData["IdPersona"] = new SelectList(_context.Personas, "Id", "Apellido", personaLog.IdPersona);
            return View(personaLog);
        }

        // POST: PersonaLogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Hermanos,FechaDeNacimiento,IdPersona,Direccion")] PersonaLog personaLog)
        {
            if (id != personaLog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personaLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonaLogExists(personaLog.Id))
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
            ViewData["IdPersona"] = new SelectList(_context.Personas, "Id", "Apellido", personaLog.IdPersona);
            return View(personaLog);
        }

        // GET: PersonaLogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personaLog = await _context.PersonaLog
                .Include(p => p.IdPersonaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personaLog == null)
            {
                return NotFound();
            }

            return View(personaLog);
        }

        // POST: PersonaLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personaLog = await _context.PersonaLog.FindAsync(id);
            _context.PersonaLog.Remove(personaLog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonaLogExists(int id)
        {
            return _context.PersonaLog.Any(e => e.Id == id);
        }
    }
}
