using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcTiggy.Models;

namespace MvcTiggy.Controllers
{
    public class AdventuresController : Controller
    {
        private readonly MvcAdventureContext _context;

        public AdventuresController(MvcAdventureContext context)
        {
            _context = context;
        }

        // GET: Adventures
        public async Task<IActionResult> Index(decimal adventureMaxCost, string searchString)
        {
            var adventures = from a in _context.Adventure select a;

            if(!string.IsNullOrEmpty(searchString))
            {
                adventures = adventures.Where(a => a.Name.Contains(searchString));
            }

            if(adventureMaxCost > 0)
            {
                var matches = new List<Adventure>();
                foreach (var item in adventures)
                {
                    if (item.EstimatedCost <= adventureMaxCost)
                    {
                        matches.Add(item);
                    }
                }
                adventures = adventures.Where(a => a.EstimatedCost == adventureMaxCost);

               
                var x = adventures.Count();
                var y = matches.Count();
            }

            var adventureCostViewModel = new AdventureCostViewModel();
            adventureCostViewModel.CostRanges = new SelectList(
                                                    new List<decimal> {300, 1000, 2500, 2000, 5000});
            adventureCostViewModel.Adventures = await adventures.ToListAsync();

            return View(adventureCostViewModel);
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }



        // GET: Adventures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adventure = await _context.Adventure
                .FirstOrDefaultAsync(m => m.ID == id);
            if (adventure == null)
            {
                return NotFound();
            }

            return View(adventure);
        }

        // GET: Adventures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Adventures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Description,PlannedDate,EstimatedCost")] Adventure adventure)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adventure);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adventure);
        }

        // GET: Adventures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adventure = await _context.Adventure.FindAsync(id);
            if (adventure == null)
            {
                return NotFound();
            }
            return View(adventure);
        }

        // POST: Adventures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Description,PlannedDate,EstimatedCost")] Adventure adventure)
        {
            if (id != adventure.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adventure);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdventureExists(adventure.ID))
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
            return View(adventure);
        }

        // GET: Adventures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adventure = await _context.Adventure
                .FirstOrDefaultAsync(m => m.ID == id);
            if (adventure == null)
            {
                return NotFound();
            }

            return View(adventure);
        }

        // POST: Adventures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adventure = await _context.Adventure.FindAsync(id);
            _context.Adventure.Remove(adventure);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdventureExists(int id)
        {
            return _context.Adventure.Any(e => e.ID == id);
        }
    }
}
