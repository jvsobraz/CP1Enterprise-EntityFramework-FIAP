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
    public class RegrasEspeciaisController : Controller
    {
        private readonly OracleDbContext _context;


        public RegrasEspeciaisController(OracleDbContext context)
        {
            _context = context;
        }

        // GET: RegrasEspeciais
        public async Task<IActionResult> Index()
        {
            return _context.RegrasEspeciais != null ?
                        View(await _context.RegrasEspeciais.Where(x => x.EstaAtivo == true).ToListAsync()) :
                        Problem("Entity set 'OracleDbContext.RegrasEspeciais'  is null.");
        }

        public async Task<IActionResult> IndexAll()
        {
            return _context.RegrasEspeciais != null ?
                View(await _context.RegrasEspeciais.ToListAsync()) :
                Problem("Entity set 'OracleDbContext.RegrasEspeciais'  is null.");
        }

        // GET: RegrasEspeciais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RegrasEspeciais == null)
            {
                return NotFound();
            }

            var regrasEspeciais = await _context.RegrasEspeciais
                .FirstOrDefaultAsync(m => m.RegrasEspeciaisId == id);
            if (regrasEspeciais == null)
            {
                return NotFound();
            }

            return View(regrasEspeciais);
        }

        // GET: RegrasEspeciais/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RegrasEspeciais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RegrasEspeciaisId,Descricao,Data")] RegrasEspeciais regrasEspeciais)
        {

            if (!ModelState.IsValid) return View(regrasEspeciais);

            _context.Add(regrasEspeciais);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: RegrasEspeciais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RegrasEspeciais == null)
            {
                return NotFound();
            }

            var regrasEspeciais = await _context.RegrasEspeciais.FindAsync(id);
            if (regrasEspeciais == null)
            {
                return NotFound();
            }
            return View(regrasEspeciais);
        }

        // POST: RegrasEspeciais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RegrasEspeciaisId,Descricao,Data")] RegrasEspeciais regrasEspeciais)
        {
            if (id != regrasEspeciais.RegrasEspeciaisId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(regrasEspeciais);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegrasEspeciaisExists(regrasEspeciais.RegrasEspeciaisId))
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
            return View(regrasEspeciais);
        }

        // GET: RegrasEspeciais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RegrasEspeciais == null)
            {
                return NotFound();
            }

            var regrasEspeciais = await _context.RegrasEspeciais
                .FirstOrDefaultAsync(m => m.RegrasEspeciaisId == id);
            if (regrasEspeciais == null)
            {
                return NotFound();
            }

            return View(regrasEspeciais);
        }

        // POST: RegrasEspeciais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RegrasEspeciais == null)
            {
                return Problem("Entity set 'OracleDbContext.RegrasEspeciais'  is null.");
            }
            var regrasEspeciais = await _context.RegrasEspeciais.FindAsync(id);
            if (regrasEspeciais != null)
            {
                _context.Cartas.Remove(regrasEspeciais);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegrasEspeciaisExists(int id)
        {
            return (_context.RegrasEspeciais?.Any(e => e.RegrasEspeciaisId == id)).GetValueOrDefault();
        }
    }
}
