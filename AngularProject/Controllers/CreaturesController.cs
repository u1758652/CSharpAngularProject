using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AngularProject.Data;
using AngularProject.Models;

namespace AngularProject.Controllers
{
    public class CreaturesController : Controller
    {
        private readonly AngularProjectContext _context;

        public CreaturesController(AngularProjectContext context)
        {
            _context = context;
        }

        // GET: Creatures
        public async Task<IActionResult> Index()
        {
            return View(await _context.Creature.ToListAsync());
        }

        // GET: Creatures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creature = await _context.Creature
                .FirstOrDefaultAsync(m => m.Id == id);
            if (creature == null)
            {
                return NotFound();
            }

            return View(creature);
        }

        // GET: Creatures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Creatures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] Creature creature)
        {
            if (ModelState.IsValid)
            {
                _context.Add(creature);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(creature);
        }

        // GET: Creatures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creature = await _context.Creature.FindAsync(id);
            if (creature == null)
            {
                return NotFound();
            }
            return View(creature);
        }

        // POST: Creatures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Creature creature)
        {
            if (id != creature.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(creature);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CreatureExists(creature.Id))
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
            return View(creature);
        }

        // GET: Creatures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creature = await _context.Creature
                .FirstOrDefaultAsync(m => m.Id == id);
            if (creature == null)
            {
                return NotFound();
            }

            return View(creature);
        }

        // POST: Creatures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var creature = await _context.Creature.FindAsync(id);
            _context.Creature.Remove(creature);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CreatureExists(int id)
        {
            return _context.Creature.Any(e => e.Id == id);
        }
    }
}
