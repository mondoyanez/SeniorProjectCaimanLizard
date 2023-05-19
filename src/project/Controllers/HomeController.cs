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

    //public IActionResult SearchDetails(string title, DateOnly ReleaseDate)
    //{
    //    Debug.WriteLine("Inside controller for search details");
    //    Debug.WriteLine("Title: " + title);
    //    Debug.WriteLine("Release Date: " + ReleaseDate);
    //    //Debug.WriteLine("Media type: " + mediaType);

    //    Show show = new Show()
    //    {
    //        Title = title,
    //        FirstAirDate = ReleaseDate.ToString()
    //    };
    //    return View(show);


    //    //if (mediaType == "tv")
    //    //{
    //    //    //make a call to the api
    //    //    //for now just using basic data

    //    //    Show show = new Show()
    //    //    {
    //    //        Title = title,
    //    //        FirstAirDate = ReleaseDate.ToString()
    //    //    };
    //    //    return View(show);

    //    //} else
    //    //{
    //    //    Movie movie = new Movie()
    //    //    {
    //    //        Title = title,
    //    //        ReleaseDate = ReleaseDate.ToString()
    //    //    };
    //    //    return View(movie);
    //    //}

    //}

    public IActionResult SearchDetails(string title, DateOnly ReleaseDate)
    {
        Debug.WriteLine("Inside controller for search details");
        Debug.WriteLine("Title: " + title);
        Debug.WriteLine("Release Date: " + ReleaseDate);
        //Debug.WriteLine("Media type: " + mediaType);

        int id = 100088;

        ShowDetailsVM vm = new ShowDetailsVM();
        //vm = _tmdbService.GetShowDetails(id);

        int showId = _tmdbService.GetShowId(title, ReleaseDate);

        if (showId == 0)
        {
            return View();
        }

        vm = _tmdbService.GetShowDetails(showId);

        return View(vm);

        // Should be getting an id and a mediaType
        // hit different services for the different media types, and pass in the correct id
        // This is all manually entered right now, need to change it once the id is figured out

    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}
