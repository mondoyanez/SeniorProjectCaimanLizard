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
using WatchParty.Models.Concrete;
using WatchParty.Services.Abstract;
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
        private readonly ITMDBService _tmdbService;


        public WatchListController(WatchPartyDbContext context, UserManager<IdentityUser> userManager, IWatchListRepository watchListRepository, IShowRepository showRepo, IWatcherRepository watcherRepository, IWatchListItemRepository watchListItemsRepo, IMovieRepository movieRepo, ITMDBService tMDBService)
        {
            _context = context;
            _userManager = userManager;
            _watchListRepo = watchListRepository;
            _showRepo = showRepo;
            _watcherRepository = watcherRepository;
            _watchListItemsRepo = watchListItemsRepo;
            _movieRepo = movieRepo;
            _tmdbService = tMDBService;
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
        public async Task<IActionResult> addShowToWatchList(string showTitle)
        {
            // Get the current user and their watch list
            var currentUser = await _userManager.GetUserAsync(User);
            Watcher watcher = _watcherRepository.FindByAspNetId(currentUser.Id);
            WatchList watchList = _watchListRepo.FindByUserID(watcher.Id);

            // If the watchlist is null, create one for the user
            if (watchList == null)
            {
                watchList = new WatchList()
                {
                    UserId = watcher.Id,
                    ListType = 0
                };
                _watchListRepo.AddOrUpdate(watchList);
            }
            

            // Create a show item if not already existing
            Show show = _showRepo.FindByTitle(showTitle);
            Debug.WriteLine("showTitle: " + showTitle);
            if (show == null)
            {
                //show = _showRepo.CreateShow();
                Debug.WriteLine("Show is null");
                TMDBTitle tmdbTitle = _tmdbService.GetShowDetails(showTitle);

                if (tmdbTitle == null)
                    Debug.WriteLine("tmdbtitle is null");
                show = new Show()
                {
                    Tmdbid = tmdbTitle.Id,
                    Title = tmdbTitle.Title,
                    Overview = tmdbTitle.PlotSummary,
                    FirstAirDate = tmdbTitle.ReleaseDate
                };
                Debug.WriteLine("TMDBTitle: " + tmdbTitle.Title);
            }

            _showRepo.AddOrUpdate(show);

            // Create the watchlistitem and add to db


            Debug.WriteLine("showTitle: " + showTitle);
            
            Debug.WriteLine("watcher: " + watcher.ToString());
            Debug.WriteLine("Watch List: " + watchList.ToString());

            WatchListItem watchListItem = new WatchListItem()
            {
                WatchListId = watchList.Id,
                ShowId = show.Id,
                MovieId = null
            };

            _watchListItemsRepo.AddOrUpdate(watchListItem);
            _context.SaveChanges();

            Debug.WriteLine("inside add to watch list in home controller");
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteWatchListShow(int showId)
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

        [HttpPost]
        public async Task<IActionResult> DeleteWatchListMovie(int movieId)
        {
            // Get all the watch list items that have the given show id, there can be more than one
            IEnumerable<WatchListItem> watchListItems = _watchListItemsRepo.FindAllByMovieId(movieId);

            // Get information about the current user
            var currentUser = await _userManager.GetUserAsync(User);
            Watcher watcher = _watcherRepository.FindByAspNetId(currentUser.Id);


            // Get the users watch list
            WatchList watchList = _watchListRepo.FindByUserID(watcher.Id);


            // Filter out the watch list items to find the one specific to the current user
            WatchListItem watchListItem = watchListItems.Where(wli => wli.WatchListId == watchList.Id).FirstOrDefault();

            Debug.WriteLine("Show id:" + movieId);
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
