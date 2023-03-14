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
    public class WatchListController : Controller
    {
        private readonly WatchPartyDbContext _context;

        public WatchListController(WatchPartyDbContext context)
        {
            _context = context;
        }

        // GET: WatchList
        public async Task<IActionResult> Index()
        {
            var watchPartyDbContext = _context.WatchLists.Include(w => w.Movie).Include(w => w.Show).Include(w => w.User);
            return View(await watchPartyDbContext.ToListAsync());
        }

        // GET: WatchList/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.WatchLists == null)
            {
                return NotFound();
            }

            var watchList = await _context.WatchLists
                .Include(w => w.Movie)
                .Include(w => w.Show)
                .Include(w => w.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (watchList == null)
            {
                return NotFound();
            }

            return View(watchList);
        }

        // GET: WatchList/Create
        public IActionResult Create()
        {
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id");
            ViewData["ShowId"] = new SelectList(_context.Shows, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Watchers, "Id", "Id");
            return View();
        }

        // POST: WatchList/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,ShowId,MovieId")] WatchList watchList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(watchList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id", watchList.MovieId);
            ViewData["ShowId"] = new SelectList(_context.Shows, "Id", "Id", watchList.ShowId);
            ViewData["UserId"] = new SelectList(_context.Watchers, "Id", "Id", watchList.UserId);
            return View(watchList);
        }

        // GET: WatchList/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.WatchLists == null)
            {
                return NotFound();
            }

            var watchList = await _context.WatchLists.FindAsync(id);
            if (watchList == null)
            {
                return NotFound();
            }
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id", watchList.MovieId);
            ViewData["ShowId"] = new SelectList(_context.Shows, "Id", "Id", watchList.ShowId);
            ViewData["UserId"] = new SelectList(_context.Watchers, "Id", "Id", watchList.UserId);
            return View(watchList);
        }

        // POST: WatchList/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,ShowId,MovieId")] WatchList watchList)
        {
            if (id != watchList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(watchList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WatchListExists(watchList.Id))
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
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id", watchList.MovieId);
            ViewData["ShowId"] = new SelectList(_context.Shows, "Id", "Id", watchList.ShowId);
            ViewData["UserId"] = new SelectList(_context.Watchers, "Id", "Id", watchList.UserId);
            return View(watchList);
        }

        // GET: WatchList/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.WatchLists == null)
            {
                return NotFound();
            }

            var watchList = await _context.WatchLists
                .Include(w => w.Movie)
                .Include(w => w.Show)
                .Include(w => w.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (watchList == null)
            {
                return NotFound();
            }

            return View(watchList);
        }

        // POST: WatchList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.WatchLists == null)
            {
                return Problem("Entity set 'WatchPartyDbContext.WatchLists'  is null.");
            }
            var watchList = await _context.WatchLists.FindAsync(id);
            if (watchList != null)
            {
                _context.WatchLists.Remove(watchList);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WatchListExists(int id)
        {
          return (_context.WatchLists?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
