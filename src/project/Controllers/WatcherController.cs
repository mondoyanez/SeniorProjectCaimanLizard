using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WatchParty.Models;

namespace WatchParty.Controllers
{
    public class WatcherController : Controller
    {
        private readonly WatchPartyDbContext _context;

        public WatcherController(WatchPartyDbContext context)
        {
            _context = context;
        }

        // GET: Watcher
        public async Task<IActionResult> Index()
        {
              return _context.Watchers != null ? 
                          View(await _context.Watchers.ToListAsync()) :
                          Problem("Entity set 'WatchPartyDbContext.Watchers'  is null.");
        }

        // GET: Watcher/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Watchers == null)
            {
                return NotFound();
            }

            var watcher = await _context.Watchers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (watcher == null)
            {
                return NotFound();
            }

            return View(watcher);
        }

        // GET: Watcher/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Watcher/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AspNetIdentityId,Username,FirstName,LastName,Email,FollowingCount,FollowerCount,Bio")] Watcher watcher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(watcher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(watcher);
        }

        // GET: Watcher/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Watchers == null)
            {
                return NotFound();
            }

            var watcher = await _context.Watchers.FindAsync(id);
            if (watcher == null)
            {
                return NotFound();
            }
            return View(watcher);
        }

        // POST: Watcher/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AspNetIdentityId,Username,FirstName,LastName,Email,FollowingCount,FollowerCount,Bio")] Watcher watcher)
        {
            if (id != watcher.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(watcher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WatcherExists(watcher.Id))
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
            return View(watcher);
        }

        // GET: Watcher/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Watchers == null)
            {
                return NotFound();
            }

            var watcher = await _context.Watchers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (watcher == null)
            {
                return NotFound();
            }

            return View(watcher);
        }

        // POST: Watcher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Watchers == null)
            {
                return Problem("Entity set 'WatchPartyDbContext.Watchers'  is null.");
            }
            var watcher = await _context.Watchers.FindAsync(id);
            if (watcher != null)
            {
                _context.Watchers.Remove(watcher);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WatcherExists(int id)
        {
          return (_context.Watchers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
