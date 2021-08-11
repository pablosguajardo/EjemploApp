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
    public class FormaDePagoController : Controller
    {
        private readonly EjAppContext _context;

        public FormaDePagoController(EjAppContext context)
        {
            _context = context;
        }

        // GET: FormaDePago
        public async Task<IActionResult> Index()
        {
            return View(await _context.FormaDePago.ToListAsync());
        }

        // GET: FormaDePago/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formaDePago = await _context.FormaDePago
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formaDePago == null)
            {
                return NotFound();
            }

            return View(formaDePago);
        }

        // GET: FormaDePago/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FormaDePago/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripción")] FormaDePago formaDePago)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formaDePago);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(formaDePago);
        }

        // GET: FormaDePago/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formaDePago = await _context.FormaDePago.FindAsync(id);
            if (formaDePago == null)
            {
                return NotFound();
            }
            return View(formaDePago);
        }

        // POST: FormaDePago/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripción")] FormaDePago formaDePago)
        {
            if (id != formaDePago.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formaDePago);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormaDePagoExists(formaDePago.Id))
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
            return View(formaDePago);
        }

        // GET: FormaDePago/Delete/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formaDePago = await _context.FormaDePago
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formaDePago == null)
            {
                return NotFound();
            }

            return View(formaDePago);
        }

        // POST: FormaDePago/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formaDePago = await _context.FormaDePago.FindAsync(id);
            _context.FormaDePago.Remove(formaDePago);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormaDePagoExists(int id)
        {
            return _context.FormaDePago.Any(e => e.Id == id);
        }
    }
}
