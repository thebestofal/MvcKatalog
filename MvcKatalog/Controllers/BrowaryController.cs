using System;
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
    public class BrowaryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BrowaryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Browary
        public async Task<IActionResult> Index()
        {
            return View(await _context.Browary.ToListAsync());
        }

        // GET: Browary/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var browar = await _context.Browary
                .FirstOrDefaultAsync(m => m.Id == id);
            if (browar == null)
            {
                return NotFound();
            }

            return View(browar);
        }

        [Authorize(Roles = "Admin")]
        // GET: Browary/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Browary/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nazwa,KrajPochodzenia")] Browar browar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(browar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(browar);
        }

        [Authorize(Roles = "Admin")]
        // GET: Browary/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var browar = await _context.Browary.FindAsync(id);
            if (browar == null)
            {
                return NotFound();
            }
            return View(browar);
        }

        // POST: Browary/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nazwa,KrajPochodzenia")] Browar browar)
        {
            if (id != browar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(browar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrowarExists(browar.Id))
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
            return View(browar);
        }

        [Authorize(Roles = "Admin")]
        // GET: Browary/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var browar = await _context.Browary
                .FirstOrDefaultAsync(m => m.Id == id);
            if (browar == null)
            {
                return NotFound();
            }

            return View(browar);
        }

        // POST: Browary/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var browar = await _context.Browary.FindAsync(id);
            _context.Browary.Remove(browar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BrowarExists(int id)
        {
            return _context.Browary.Any(e => e.Id == id);
        }
    }
}
