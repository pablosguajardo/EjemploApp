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
    public class PersonasTipoController : Controller
    {
        private readonly AppCursoContext _context;

        public PersonasTipoController(AppCursoContext context)
        {
            _context = context;
        }

        // GET: PersonasTipoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersonasTipo.ToListAsync());
        }

        // GET: PersonasTipoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personasTipo = await _context.PersonasTipo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personasTipo == null)
            {
                return NotFound();
            }

            return View(personasTipo);
        }

        // GET: PersonasTipoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonasTipoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion")] PersonasTipo personasTipo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personasTipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personasTipo);
        }

        // GET: PersonasTipoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personasTipo = await _context.PersonasTipo.FindAsync(id);
            if (personasTipo == null)
            {
                return NotFound();
            }
            return View(personasTipo);
        }

        // POST: PersonasTipoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion")] PersonasTipo personasTipo)
        {
            if (id != personasTipo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personasTipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonasTipoExists(personasTipo.Id))
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
            return View(personasTipo);
        }

        // GET: PersonasTipoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personasTipo = await _context.PersonasTipo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personasTipo == null)
            {
                return NotFound();
            }

            return View(personasTipo);
        }

        // POST: PersonasTipoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personasTipo = await _context.PersonasTipo.FindAsync(id);
            _context.PersonasTipo.Remove(personasTipo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonasTipoExists(int id)
        {
            return _context.PersonasTipo.Any(e => e.Id == id);
        }
    }
}
