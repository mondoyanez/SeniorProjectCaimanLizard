using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using WatchParty.DAL.Abstract;
using WatchParty.Models;
using WatchParty.Services.Abstract;
using WatchParty.Services.Concrete;
using WatchParty.ViewModels;

namespace WatchParty.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly ITMDBService _tmdbService;

    public HomeController(ILogger<HomeController> logger, ITMDBService tMDBService)
    {
        _logger = logger;
        _tmdbService = tMDBService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Search()
    {
	    return View();
    }

    public IActionResult Actors()
    {
        return View();
    }

    [Authorize]
    public IActionResult FindUsers()
    {
        return View();
    }

    

    public IActionResult SearchDetails(string title, DateOnly ReleaseDate)
    {
        Debug.WriteLine("Inside controller for search details");
        Debug.WriteLine("Title: " + title);
        Debug.WriteLine("Release Date: " + ReleaseDate);
        //Debug.WriteLine("Media type: " + mediaType);


        ShowDetailsVM vm = new ShowDetailsVM();

        int showId = _tmdbService.GetShowId(title, ReleaseDate);

        if (showId == 0)
        {
            return View();
        }

        vm = _tmdbService.GetShowDetails(showId);

        return View(vm);

    }

    public IActionResult MovieDetails(string title, DateOnly ReleaseDate)
    {
        Debug.WriteLine("Inside controller for search details");
        Debug.WriteLine("Title: " + title);
        Debug.WriteLine("Release Date: " + ReleaseDate);
        //Debug.WriteLine("Media type: " + mediaType);


        MovieDetailsVM vm = new MovieDetailsVM();

        int Id = _tmdbService.GetMovieId(title, ReleaseDate);
        Debug.WriteLine("Id: " + Id);
        if (Id == 0)
        {
            return View();
        }

        vm = _tmdbService.GetMovieDetails(Id);

        return View(vm);

    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}
