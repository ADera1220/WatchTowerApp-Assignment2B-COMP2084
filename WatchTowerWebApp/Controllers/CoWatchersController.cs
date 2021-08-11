using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WatchTowerWebApp.Data;
using WatchTowerWebApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace WatchTowerWebApp.Controllers
{
    //This section will be locked behind Authorization, with some noted exceptions
    [Authorize()]
    public class CoWatchersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoWatchersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CoWatchers
        // This section will be authorized for non-authenticated users
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.CoWatchers.ToListAsync());
        }

        // GET: CoWatchers/Details/5
        // This section will be authorized for non-authenticated users
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coWatcher = await _context.CoWatchers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coWatcher == null)
            {
                return NotFound();
            }

            return View(coWatcher);
        }

        // GET: CoWatchers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CoWatchers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,WatchTime")] CoWatcher coWatcher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coWatcher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coWatcher);
        }

        // GET: CoWatchers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coWatcher = await _context.CoWatchers.FindAsync(id);
            if (coWatcher == null)
            {
                return NotFound();
            }
            return View(coWatcher);
        }

        // POST: CoWatchers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,WatchTime")] CoWatcher coWatcher)
        {
            if (id != coWatcher.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coWatcher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoWatcherExists(coWatcher.Id))
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
            return View(coWatcher);
        }

        // GET: CoWatchers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coWatcher = await _context.CoWatchers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coWatcher == null)
            {
                return NotFound();
            }

            return View(coWatcher);
        }

        // POST: CoWatchers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coWatcher = await _context.CoWatchers.FindAsync(id);
            _context.CoWatchers.Remove(coWatcher);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoWatcherExists(int id)
        {
            return _context.CoWatchers.Any(e => e.Id == id);
        }
    }
}
