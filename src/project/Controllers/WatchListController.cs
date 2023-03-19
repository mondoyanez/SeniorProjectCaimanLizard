using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private readonly IWatcherRepository _watcherRepository;
        private readonly IWatchListItemRepository _watchListItemsRepo;
        private readonly IMovieRepository _movieRepo;


        public WatchListController(WatchPartyDbContext context, UserManager<IdentityUser> userManager, IWatchListRepository watchListRepository, IShowRepository showRepo, IWatcherRepository watcherRepository, IWatchListItemRepository watchListItemsRepo, IMovieRepository movieRepo)
        {
            _context = context;
            _userManager = userManager;
            _watchListRepo = watchListRepository;
            _showRepo = showRepo;
            _watcherRepository = watcherRepository;
            _watchListItemsRepo = watchListItemsRepo;
            _movieRepo = movieRepo;
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

            //Find the watchlists by userID
            watchListVM.watchList = _watchListRepo.FindByUserID(watcher.Id);

            //Get the items in the watchlistItems
            if (watchListVM.watchList != null)
            {
                watchListVM.watchListItems = _watchListItemsRepo.GetAllWatchListItemsByID(watchListVM.watchList.Id);
            }



            // Get shows/movies by the users watchlistItems
            watchListVM.shows = _showRepo.GetShows(watchListVM.watchListItems);
            watchListVM.movies = _movieRepo.GetMovies(watchListVM.watchListItems);

            return View(watchListVM);
        }

        [HttpPost]
        [Route("/addShowToWatchList")]
        public IActionResult AddShowToWatchList(WatchList watchList, Show show)
        {
            _watchListRepo.AddOrUpdate(watchList);
            _showRepo.AddOrUpdate(show);

            Debug.WriteLine("inside add to watch list in home controller");
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteWatchListItem(int showId)
        {
            // Get all the watch list items that have the given show id, there can be more than one
            IEnumerable<WatchListItem> watchListItems = _watchListItemsRepo.FindAllByShowId(showId);

            // Get information about the current user
            var currentUser = await _userManager.GetUserAsync(User);
            Watcher watcher = _watcherRepository.FindByAspNetId(currentUser.Id);

            Debug.WriteLine("Current user: " + currentUser.ToString());

            // Get the users watch list
            WatchList watchList = _watchListRepo.FindByUserID(watcher.Id);

            Debug.WriteLine("Watch list: " + watchList.ToString());

            // Filter out the watch list items to find the one specific to the current user
            WatchListItem watchListItem = watchListItems.Where(wli => wli.WatchListId == watchList.Id).FirstOrDefault();

            Debug.WriteLine("Show id:" + showId);
            Debug.WriteLine("Watch List Item: " + watchListItem.ToString());

            // Delete the watchListItem from the database
            if (watchListItem == null)
            {
                Debug.WriteLine("Watchlistitem is null");
                return NotFound();
            }

            _watchListItemsRepo.Delete(watchListItem);
            _context.SaveChanges();

            return Ok();
        }

        private bool WatchListExists(int id)
        {
          return (_context.WatchLists?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
