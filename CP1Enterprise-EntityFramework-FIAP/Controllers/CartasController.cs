﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CP1Enterprise_EntityFramework_FIAP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CP1Enterprise_EntityFramework_FIAP.Models;
using CP1Enterprise_EntityFramework_FIAP.Persistence;

namespace scryrall_admin.Controllers
{
    public class CartasController : Controller
    {
        private readonly OracleDbContext _context;

        public CartasController(OracleDbContext context)
        {
            _context = context;
        }

        // GET: Cartas
        public async Task<IActionResult> Index()
        {
            return _context.Cartas != null ?
                        View(await _context.Cartas.ToListAsync()) :
                        Problem("Entity set 'OracleDbContext.Cartas'  is null.");
        }

        // GET: Cartas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cartas == null)
            {
                return NotFound();
            }
            var carta = await _context.Cartas
                .Include(c => c.Colecao)
                .Include(c => c.Ilustrador)
                .Include(c => c.Links)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carta == null)
            {
                return NotFound();
            }

            return View(carta);
        }

        // GET: Cartas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cartas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Tipo,Descricao,FotoUrl")] Carta carta)
        {
            try
            {


                _context.Add(carta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(carta);
        }

        // GET: Cartas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cartas == null)
            {
                return NotFound();
            }
            var carta = await _context.Cartas
                .Include(c => c.Colecao)
                .Include(c => c.Ilustrador)
                .Include(c => c.Links)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carta == null)
            {
                return NotFound();
            }
            return View(carta);
        }

        // POST: Cartas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Carta carta)
        {
            if (id != carta.Id)
            {
                return NotFound();
            }


            try
            {
                _context.Update(carta);


                await _context.SaveChangesAsync();


            }
            catch (DataException)
            {

            }
            return RedirectToAction(nameof(Index));




        }

        // GET: Cartas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cartas == null)
            {
                return NotFound();
            }

            var carta = await _context.Cartas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carta == null)
            {
                return NotFound();
            }

            return View(carta);
        }

        // POST: Cartas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cartas == null)
            {
                return Problem("Entity set 'OracleDbContext.Cartas'  is null.");
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
            return (_context.Cartas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}