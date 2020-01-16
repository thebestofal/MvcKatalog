﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcKatalog.Data;
using MvcProj.Models;

namespace MvcKatalog.Controllers
{
    public class PiwaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PiwaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Piwa
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Piwa.Include(p => p.Browar);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Piwa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var piwo = await _context.Piwa
                .Include(p => p.Browar)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (piwo == null)
            {
                return NotFound();
            }

            return View(piwo);
        }

        [Authorize(Roles = "Admin")]
        // GET: Piwa/Create
        public IActionResult Create()
        {
            ViewData["BrowarId"] = new SelectList(_context.Browary, "Id", "Nazwa");
            return View();
        }

        // POST: Piwa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nazwa,Typ,ZawartoscAlk,Ibu,Ekstrakt,BrowarId")] Piwo piwo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(piwo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrowarId"] = new SelectList(_context.Browary, "Id", "Nazwa", piwo.BrowarId);
            return View(piwo);
        }

        [Authorize(Roles = "Admin")]
        // GET: Piwa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var piwo = await _context.Piwa.FindAsync(id);
            if (piwo == null)
            {
                return NotFound();
            }
            ViewData["BrowarId"] = new SelectList(_context.Browary, "Id", "Nazwa", piwo.BrowarId);
            return View(piwo);
        }

        // POST: Piwa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nazwa,Typ,ZawartoscAlk,Ibu,Ekstrakt,BrowarId")] Piwo piwo)
        {
            if (id != piwo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(piwo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PiwoExists(piwo.Id))
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
            ViewData["BrowarId"] = new SelectList(_context.Browary, "Id", "Nazwa", piwo.BrowarId);
            return View(piwo);
        }

        [Authorize(Roles = "Admin")]
        // GET: Piwa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var piwo = await _context.Piwa
                .Include(p => p.Browar)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (piwo == null)
            {
                return NotFound();
            }

            return View(piwo);
        }

        // POST: Piwa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var piwo = await _context.Piwa.FindAsync(id);
            _context.Piwa.Remove(piwo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PiwoExists(int id)
        {
            return _context.Piwa.Any(e => e.Id == id);
        }
    }
}
