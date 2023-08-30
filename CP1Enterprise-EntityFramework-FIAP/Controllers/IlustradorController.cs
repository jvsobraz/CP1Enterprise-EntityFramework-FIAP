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
    public class HospedeController : Controller
    {
        private readonly ScryfallDbContext _context;


        public CartaController(ScryfallDbContext context)
        {
            _context = context;
        }

        // GET: Carta
        public async Task<IActionResult> Index()
        {
            return _context.Cartas != null ?
                        View(await _context.Cartas.Where(x => x.EstaAtivo == true).ToListAsync()) :
                        Problem("Entity set 'ScryfallDbContext.Cartas'  is null.");
        }

        public async Task<IActionResult> IndexAll()
        {
            return _context.Cartas != null ?
                View(await _context.Cartas.ToListAsync()) :
                Problem("Entity set 'ScryfallDbContext.Cartas'  is null.");
        }

        // GET: Carta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cartas == null)
            {
                return NotFound();
            }

            var carta = await _context.Cartas
                .FirstOrDefaultAsync(m => m.CartaId == id);
            if (carta == null)
            {
                return NotFound();
            }

            return View(carta);
        }

        // GET: carta/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: carta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CartaId,Nome,Tipo,Descricao,FotoUrl")] Carta carta)
        {

            if (!ModelState.IsValid) return View(carta);

            _context.Add(carta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Carta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cartas == null)
            {
                return NotFound();
            }

            var carta = await _context.Cartas.FindAsync(id);
            if (carta == null)
            {
                return NotFound();
            }
            return View(carta);
        }

        // POST: Carta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CartaId,Nome,Tipo,Descricao,FotoUrl")] Carta carta)
        {
            if (id != carta.CartaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartaExists(carta.CartaId))
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
            return View(carta);
        }

        // GET: Carta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cartas == null)
            {
                return NotFound();
            }

            var carta = await _context.Cartas
                .FirstOrDefaultAsync(m => m.CartaId == id);
            if (carta == null)
            {
                return NotFound();
            }

            return View(carta);
        }

        // POST: Carta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cartas == null)
            {
                return Problem("Entity set 'ScryfallDbContext.Cartas'  is null.");
            }
            var carta = await _context.Cartas.FindAsync(id);
            if (carta != null)
            {
                _context.Cartas.Remove(carta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartaExists(int id)
        {
            return (_context.Cartas?.Any(e => e.CartaId == id)).GetValueOrDefault();
        }
    }
}
