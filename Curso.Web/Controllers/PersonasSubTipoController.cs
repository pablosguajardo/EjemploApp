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
    public class PersonasSubTipoController : Controller
    {
        private readonly EjAppContext _context;

        public PersonasSubTipoController(EjAppContext context)
        {
            _context = context;
        }

        // GET: PersonasSubTipo
        public async Task<IActionResult> Index()
        {
            var ejAppContext = _context.PersonasSubTipo.Include(p => p.IdPersonasTipoNavigation);
            return View(await ejAppContext.ToListAsync());
        }

        // GET: PersonasSubTipo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personasSubTipo = await _context.PersonasSubTipo
                .Include(p => p.IdPersonasTipoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personasSubTipo == null)
            {
                return NotFound();
            }

            return View(personasSubTipo);
        }

        // GET: PersonasSubTipo/Create
        public IActionResult Create()
        {
            ViewData["IdPersonasTipo"] = new SelectList(_context.PersonasTipo, "Id", "Nombre");
            return View();
        }

        // POST: PersonasSubTipo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,IdPersonasTipo")] PersonasSubTipo personasSubTipo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personasSubTipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPersonasTipo"] = new SelectList(_context.PersonasTipo, "Id", "Nombre", personasSubTipo.IdPersonasTipo);
            return View(personasSubTipo);
        }

        // GET: PersonasSubTipo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personasSubTipo = await _context.PersonasSubTipo.FindAsync(id);
            if (personasSubTipo == null)
            {
                return NotFound();
            }
            ViewData["IdPersonasTipo"] = new SelectList(_context.PersonasTipo, "Id", "Nombre", personasSubTipo.IdPersonasTipo);
            return View(personasSubTipo);
        }

        // POST: PersonasSubTipo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,IdPersonasTipo")] PersonasSubTipo personasSubTipo)
        {
            if (id != personasSubTipo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personasSubTipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonasSubTipoExists(personasSubTipo.Id))
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
            ViewData["IdPersonasTipo"] = new SelectList(_context.PersonasTipo, "Id", "Nombre", personasSubTipo.IdPersonasTipo);
            return View(personasSubTipo);
        }

        // GET: PersonasSubTipo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personasSubTipo = await _context.PersonasSubTipo
                .Include(p => p.IdPersonasTipoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personasSubTipo == null)
            {
                return NotFound();
            }

            return View(personasSubTipo);
        }

        // POST: PersonasSubTipo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personasSubTipo = await _context.PersonasSubTipo.FindAsync(id);
            _context.PersonasSubTipo.Remove(personasSubTipo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public JsonResult GetSubTipo(int id, int selectedIdValue)
        {
            List<SelectListItem> subTipo = new List<SelectListItem>();
            subTipo.Add(new SelectListItem() { Text = "Seleccionar", Value = "0", Selected = (selectedIdValue==0 ? true : false) });
            if (id > 0)
            {
                subTipo.AddRange(new SelectList(_context.PersonasSubTipo.Where(x => x.IdPersonasTipo == id).ToList().Select(c => new
                {
                    Id = c.Id,
                    Nombre = c.Nombre,
                    Selected = (selectedIdValue == c.Id ? true : false)
                }), "Id", "Nombre", null
              ).ToList());
            }
            return Json(subTipo);
        }


        private bool PersonasSubTipoExists(int id)
        {
            return _context.PersonasSubTipo.Any(e => e.Id == id);
        }
    }
}
