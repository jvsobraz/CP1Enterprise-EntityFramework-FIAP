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
using CP1Enterprise_EntityFramework_FIAP.Persistence;

namespace CP1Enterprise_EntityFramework_FIAP.Web.Controllers
{
    public class LinksController : Controller
    {
        private readonly OracleDbContext _context;


        public LinksController(OracleDbContext context)
        {
            _context = context;
        }

        // GET: Links
        public async Task<IActionResult> Index()
        {
            return _context.Links != null ?
                        View(await _context.Links.Where(x => x.EstaAtivo == true).ToListAsync()) :
                        Problem("Entity set 'OracleDbContext.Links'  is null.");
        }

        public async Task<IActionResult> IndexAll()
        {
            return _context.Links != null ?
                View(await _context.Links.ToListAsync()) :
                Problem("Entity set 'ScryfallDbContext.Links'  is null.");
        }

        // GET: Links/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Links == null)
            {
                return NotFound();
            }

            var links = await _context.Links
                .FirstOrDefaultAsync(m => m.LinksId == id);
            if (links == null)
            {
                return NotFound();
            }

            return View(links);
        }

        // GET: Links/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Links/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LinksId,Url")] Links links)
        {

            if (!ModelState.IsValid) return View(links);

            _context.Add(links);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Links/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Links == null)
            {
                return NotFound();
            }

            var links = await _context.Links.FindAsync(id);
            if (links == null)
            {
                return NotFound();
            }
            return View(links);
        }

        // POST: Links/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LinksId,Url")] Links links)
        {
            if (id != links.LinksId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(links);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartaExists(links.LinksId))
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
            return View(links);
        }

        // GET: Links/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Links == null)
            {
                return NotFound();
            }

            var links = await _context.Links
                .FirstOrDefaultAsync(m => m.LinksId == id);
            if (links == null)
            {
                return NotFound();
            }

            return View(links);
        }

        // POST: Links/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Links == null)
            {
                return Problem("Entity set 'OracleDbContext.Links'  is null.");
            }
            var links = await _context.Links.FindAsync(id);
            if (links != null)
            {
                _context.Cartas.Remove(links);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LinksExists(int id)
        {
            return (_context.Links?.Any(e => e.LinksId == id)).GetValueOrDefault();
        }
    }
}
