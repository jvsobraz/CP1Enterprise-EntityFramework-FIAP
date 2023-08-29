using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HookingHotels.Web.Data;
using HookingHotels.Web.Entities;
using HookingHotels.Web.Validations;

namespace HookingHotels.Web.Controllers
{
    public class HospedeController : Controller
    {
        private readonly HookingDbContext _context;


        public HospedeController(HookingDbContext context)
        {
            _context = context;
        }

        // GET: Hospede
        public async Task<IActionResult> Index()
        {
            return _context.Hospedes != null ?
                        View(await _context.Hospedes.Where(x => x.EstaAtivo == true).ToListAsync()) :
                        Problem("Entity set 'HookingDbContext.Hospedes'  is null.");
        }

        public async Task<IActionResult> IndexAll()
        {
            return _context.Hospedes != null ?
                View(await _context.Hospedes.ToListAsync()) :
                Problem("Entity set 'HookingDbContext.Hospedes'  is null.");
        }

        // GET: Hospede/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Hospedes == null)
            {
                return NotFound();
            }

            var hospede = await _context.Hospedes
                .FirstOrDefaultAsync(m => m.HospedeId == id);
            if (hospede == null)
            {
                return NotFound();
            }

            return View(hospede);
        }

        // GET: Hospede/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hospede/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HospedeId,Nome,Email,Telefone,Endereco,EstaAtivo")] Hospede hospede)
        {

            if (!ModelState.IsValid) return View(hospede);

            _context.Add(hospede);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Hospede/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Hospedes == null)
            {
                return NotFound();
            }

            var hospede = await _context.Hospedes.FindAsync(id);
            if (hospede == null)
            {
                return NotFound();
            }
            return View(hospede);
        }

        // POST: Hospede/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HospedeId,Nome,Email,Telefone,Endereco,EstaAtivo")] Hospede hospede)
        {
            if (id != hospede.HospedeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hospede);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HospedeExists(hospede.HospedeId))
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
            return View(hospede);
        }

        // GET: Hospede/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Hospedes == null)
            {
                return NotFound();
            }

            var hospede = await _context.Hospedes
                .FirstOrDefaultAsync(m => m.HospedeId == id);
            if (hospede == null)
            {
                return NotFound();
            }

            return View(hospede);
        }

        // POST: Hospede/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Hospedes == null)
            {
                return Problem("Entity set 'HookingDbContext.Hospedes'  is null.");
            }
            var hospede = await _context.Hospedes.FindAsync(id);
            if (hospede != null)
            {
                _context.Hospedes.Remove(hospede);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HospedeExists(int id)
        {
            return (_context.Hospedes?.Any(e => e.HospedeId == id)).GetValueOrDefault();
        }
    }
}
