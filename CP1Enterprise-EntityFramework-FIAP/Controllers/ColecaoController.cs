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
    public class ColecaoController : Controller
    {
        private readonly ScryfallDbContext _context;


        public ColecaoController(ScryfallDbContext context)
        {
            _context = context;
        }

        // GET: Colecao
        public async Task<IActionResult> Index()
        {
            return _context.Colecoes != null ?
                        View(await _context.Colecoes.Where(x => x.EstaAtivo == true).ToListAsync()) :
                        Problem("Entity set 'ScryfallDbContext.Colecoes'  is null.");
        }

        public async Task<IActionResult> IndexAll()
        {
            return _context.Colecoes != null ?
                View(await _context.Colecoes.ToListAsync()) :
                Problem("Entity set 'ScryfallDbContext.Colecoes'  is null.");
        }

        // GET: Colecao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Colecoes == null)
            {
                return NotFound();
            }

            var colecao = await _context.Colecoes
                .FirstOrDefaultAsync(m => m.ColecaoId == id);
            if (colecao == null)
            {
                return NotFound();
            }

            return View(colecao);
        }

        // GET: Colecao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: colecao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ColecaoId,Nome,Ano,LogoUrl")] Colecao colecao)
        {

            if (!ModelState.IsValid) return View(colecao);

            _context.Add(colecao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Colecao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Colecoes == null)
            {
                return NotFound();
            }

            var colecao = await _context.Colecoes.FindAsync(id);
            if (colecao == null)
            {
                return NotFound();
            }
            return View(colecao);
        }

        // POST: Colecao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ColecaoId,Nome,Ano,LogoUrl")] Colecao colecao)
        {
            if (id != colecao.ColecaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(colecao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColecaoExists(colecao.ColecaoId))
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
            return View(colecao);
        }

        // GET: Colecao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Colecoes == null)
            {
                return NotFound();
            }

            var colecao = await _context.Colecoes
                .FirstOrDefaultAsync(m => m.ColecaoId == id);
            if (colecao == null)
            {
                return NotFound();
            }

            return View(colecao);
        }

        // POST: Colecao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Colecoes == null)
            {
                return Problem("Entity set 'ScryfallDbContext.Cartas'  is null.");
            }
            var colecao = await _context.Cartas.FindAsync(id);
            if (colecao != null)
            {
                _context.Colecoes.Remove(colecao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ColecaoExists(int id)
        {
            return (_context.Colecoes?.Any(e => e.ColecaoId == id)).GetValueOrDefault();
        }
    }
}
