using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CP1Enterprise_EntityFramework_FIAP.Web.Data;
using CP1Enterprise_EntityFramework_FIAP.Web.Entities;
using CP1Enterprise_EntityFramework_FIAP.Web.Validations;

namespace CP1Enterprise_EntityFramework_FIAP.Web.Controllers
{
    public class IdiomaController : Controller
    {
        private readonly ScryfallDbContext _context;


        public IdiomaController(ScryfallDbContext context)
        {
            _context = context;
        }

        // GET: Idioma
        public async Task<IActionResult> Index()
        {
            return _context.Idiomas != null ?
                        View(await _context.Idiomas.Where(x => x.EstaAtivo == true).ToListAsync()) :
                        Problem("Entity set 'ScryfallDbContext.Idiomas'  is null.");
        }

        public async Task<IActionResult> IndexAll()
        {
            return _context.Idiomas != null ?
                View(await _context.Idiomas.ToListAsync()) :
                Problem("Entity set 'ScryfallDbContext.Idiomas'  is null.");
        }

        // GET: Idioma/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Idiomas == null)
            {
                return NotFound();
            }

            var idioma = await _context.Idiomas
                .FirstOrDefaultAsync(m => m.IdiomaId == id);
            if (idioma == null)
            {
                return NotFound();
            }

            return View(idioma);
        }

        // GET: idioma/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Idioma/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdiomaId,Nome")] Idioma idioma)
        {

            if (!ModelState.IsValid) return View(idioma);

            _context.Add(idioma);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Idioma/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Idiomas == null)
            {
                return NotFound();
            }

            var idioma = await _context.Idiomas.FindAsync(id);
            if (idioma == null)
            {
                return NotFound();
            }
            return View(idioma);
        }

        // POST: Idioma/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdiomaId,Nome")] Idioma idioma)
        {
            if (id != idioma.IdiomaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(idioma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IdiomaExists(idioma.IdiomaId))
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
            return View(idioma);
        }

        // GET: Idioma/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Idiomas == null)
            {
                return NotFound();
            }

            var idioma = await _context.Idiomas
                .FirstOrDefaultAsync(m => m.IdiomaId == id);
            if (idioma == null)
            {
                return NotFound();
            }

            return View(idioma);
        }

        // POST: Idioma/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Idiomas == null)
            {
                return Problem("Entity set 'ScryfallDbContext.Idiomas'  is null.");
            }
            var idioma = await _context.Idiomas.FindAsync(id);
            if (idioma != null)
            {
                _context.Idiomas.Remove(idioma);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IdiomaExists(int id)
        {
            return (_context.Idiomas?.Any(e => e.IdiomaId == id)).GetValueOrDefault();
        }
    }
}
