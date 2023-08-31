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
    public class IlustradorController : Controller
    {
        private readonly ScryfallDbContext _context;


        public IlustradorController(ScryfallDbContext context)
        {
            _context = context;
        }

        // GET: Ilustrador
        public async Task<IActionResult> Index()
        {
            return _context.Ilustradores != null ?
                        View(await _context.Ilustradores.Where(x => x.EstaAtivo == true).ToListAsync()) :
                        Problem("Entity set 'ScryfallDbContext.Ilustradores'  is null.");
        }

        public async Task<IActionResult> IndexAll()
        {
            return _context.Ilustradores != null ?
                View(await _context.Ilustradores.ToListAsync()) :
                Problem("Entity set 'ScryfallDbContext.Ilustradores'  is null.");
        }

        // GET: Ilustrador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ilustradores == null)
            {
                return NotFound();
            }

            var ilustrador = await _context.Ilustradores
                .FirstOrDefaultAsync(m => m.IlustradorId == id);
            if (ilustrador == null)
            {
                return NotFound();
            }

            return View(ilustrador);
        }

        // GET: Ilustrador/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ilustrador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IlustradorId,Nome")] Ilustrador ilustrador)
        {

            if (!ModelState.IsValid) return View(ilustrador);

            _context.Add(ilustrador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Ilustrador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ilustradores == null)
            {
                return NotFound();
            }

            var ilustrador = await _context.Ilustradores.FindAsync(id);
            if (ilustrador == null)
            {
                return NotFound();
            }
            return View(ilustrador);
        }

        // POST: Ilustrador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IlustradorId,Nome")] Ilustrador ilustrador)
        {
            if (id != ilustrador.IlustradorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ilustrador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartaExists(ilustrador.IlustradorId))
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
            return View(ilustrador);
        }

        // GET: Ilustrador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ilustradores == null)
            {
                return NotFound();
            }

            var ilustrador = await _context.Ilustradores
                .FirstOrDefaultAsync(m => m.IlustradorId == id);
            if (ilustrador == null)
            {
                return NotFound();
            }

            return View(ilustrador);
        }

        // POST: Ilustrador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ilustradores == null)
            {
                return Problem("Entity set 'ScryfallDbContext.Ilustradores'  is null.");
            }
            var ilustrador = await _context.Ilustradores.FindAsync(id);
            if (ilustrador != null)
            {
                _context.Cartas.Remove(ilustrador);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IlustradorExists(int id)
        {
            return (_context.Ilustradores?.Any(e => e.IlustradorId == id)).GetValueOrDefault();
        }
    }
}
