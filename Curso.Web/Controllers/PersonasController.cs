using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Curso.DataAccess.Models;
using Curso.Common.Utils;

namespace Curso.Web.Controllers
{
    public class PersonasController : Controller
    {
        private readonly EjAppContext _context;

        public PersonasController(EjAppContext context)
        {
            _context = context;
        }

        // GET: Personas
        public async Task<IActionResult> Index()
        {
            //string fecha = Helpers.GetDateTimeString();

            var EjAppContext = _context.Personas.Include(p => p.IdTipoPersonaNavigation);
            return View(await EjAppContext.ToListAsync());
        }

        // GET: Personas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personas = await _context.Personas
                .Include(p => p.IdTipoPersonaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personas == null)
            {
                return NotFound();
            }

            return View(personas);
        }

        // GET: Personas/Create
        public IActionResult Create()
        {
            ViewData["IdTipoPersona"] = new SelectList(_context.PersonasTipo, "Id", "Nombre");
            return View();
        }

        // POST: Personas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Hermanos,FechaDeNacimiento,IdTipoPersona")] Personas personas)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(personas);
                    await _context.SaveChangesAsync();

                    var log = new Logs();
                    log.IsError = false;
                    log.Description = "Persona creada";
                    log.Message = $"Persona creada a las {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}";
                    _context.Add(log);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex )
            {
                var log = new Logs();
                log.IsError = true;
                log.Description = "error en Create POST";
                log.Message = $"Error {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}: {ex.ToString()}";
                _context.Add(log);
                await _context.SaveChangesAsync();
            }
            ViewData["IdTipoPersona"] = new SelectList(_context.PersonasTipo, "Id", "Nombre", personas.IdTipoPersona);
            return View(personas);
        }

        // GET: Personas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personas = await _context.Personas.FindAsync(id);
            if (personas == null)
            {
                return NotFound();
            }
            ViewData["IdTipoPersona"] = new SelectList(_context.PersonasTipo, "Id", "Nombre", personas.IdTipoPersona);
            return View(personas);
        }

        // POST: Personas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Hermanos,FechaDeNacimiento,IdTipoPersona")] Personas personas)
        {
            if (id != personas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonasExists(personas.Id))
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
            ViewData["IdTipoPersona"] = new SelectList(_context.PersonasTipo, "Id", "Nombre", personas.IdTipoPersona);
            return View(personas);
        }

        // GET: Personas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personas = await _context.Personas
                .Include(p => p.IdTipoPersonaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personas == null)
            {
                return NotFound();
            }

            return View(personas);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personas = await _context.Personas.FindAsync(id);
            _context.Personas.Remove(personas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonasExists(int id)
        {
            return _context.Personas.Any(e => e.Id == id);
        }
    }
}
