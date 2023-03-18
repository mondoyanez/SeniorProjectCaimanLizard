using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WatchParty.DAL.Abstract;
using WatchParty.Models;
using WatchParty.ViewModels;

namespace WatchParty.Controllers
{
    public class WatchListController : Controller
    {
        private readonly WatchPartyDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IWatchListRepository _watchListRepo;
        private readonly IShowRepository _showRepo;
        private readonly IRepository<Movie> _movieRepo;
        private readonly IWatcherRepository _watcherRepository;


        public WatchListController(WatchPartyDbContext context, UserManager<IdentityUser> userManager, IWatchListRepository watchListRepository, IShowRepository showRepo, IRepository<Movie> movieRepo, IWatcherRepository watcherRepository)
        {
            _context = context;
            _userManager = userManager;
            _watchListRepo = watchListRepository;
            _showRepo = showRepo;
            _movieRepo = movieRepo;
            _watcherRepository = watcherRepository;
        }

        // GET: WatchList/username
        [Authorize]
        public async Task<IActionResult> Index(string username)
        {
            // Find the user and add their information to the view model
            if (_watcherRepository == null)
            {
                return View("user/Notfound");
            }
            WatchListVM watchListVM = new WatchListVM();
            Watcher watcher = _watcherRepository.FindByUsername(username);
            watchListVM.watcher = watcher;
            var currentUser = await _userManager.GetUserAsync(User);
            watchListVM.isCurrentUser = _watcherRepository.IsCurrentUser(username, currentUser);
            if (watcher == null)
            {
                return View("user/Notfound");
            }

            //Find the watchlist by userID
            watchListVM.watchList = _watchListRepo.FindByUserID(watcher.Id);

            // Get shows/movies by the ShowId/MovieId
            watchListVM.shows = _showRepo.GetShows(watchListVM.watchList);

            return View(watchListVM);
        }

        [HttpPost]
        [Route("/addShowToWatchList")]
        public IActionResult AddShowToWatchList(WatchList watchList, Show show)
        {
            _watchListRepo.AddOrUpdate(watchList);
            _showRepo.AddOrUpdate(show);

            Console.WriteLine("inside add to watch list in home controller");
            return Ok();
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
        //public IActionResult Create()
        //{
        //    ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id");
        //    ViewData["ShowId"] = new SelectList(_context.Shows, "Id", "Id");
        //    ViewData["UserId"] = new SelectList(_context.Watchers, "Id", "Id");
        //    return View();
        //}

        //// POST: WatchList/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,UserId,ShowId,MovieId")] WatchList watchList)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(watchList);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id", watchList.MovieId);
        //    ViewData["ShowId"] = new SelectList(_context.Shows, "Id", "Id", watchList.ShowId);
        //    ViewData["UserId"] = new SelectList(_context.Watchers, "Id", "Id", watchList.UserId);
        //    return View(watchList);
        //}

        // GET: WatchList/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.WatchLists == null)
        //    {
        //        return NotFound();
        //    }

        //    var watchList = await _context.WatchLists.FindAsync(id);
        //    if (watchList == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id", watchList.MovieId);
        //    ViewData["ShowId"] = new SelectList(_context.Shows, "Id", "Id", watchList.ShowId);
        //    ViewData["UserId"] = new SelectList(_context.Watchers, "Id", "Id", watchList.UserId);
        //    return View(watchList);
        //}

        // POST: WatchList/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,ShowId,MovieId")] WatchList watchList)
        //{
        //    if (id != watchList.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(watchList);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!WatchListExists(watchList.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id", watchList.MovieId);
        //    ViewData["ShowId"] = new SelectList(_context.Shows, "Id", "Id", watchList.ShowId);
        //    ViewData["UserId"] = new SelectList(_context.Watchers, "Id", "Id", watchList.UserId);
        //    return View(watchList);
        //}

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