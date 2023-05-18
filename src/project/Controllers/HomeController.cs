using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WatchParty.DAL.Abstract;
using WatchParty.Models;

namespace WatchParty.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
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

    //[Route("/SearchDetails/{title}")]
    public IActionResult SearchDetails(string title, DateTime ReleaseDate)
    {
        Debug.WriteLine("Inside controller for search details");
        Debug.WriteLine("Title: " + title);
        Debug.WriteLine("Release Date: " + ReleaseDate);
        //Debug.WriteLine("Media type: " + mediaType);

        Show show = new Show()
        {
            Title = title,
            FirstAirDate = ReleaseDate.ToString()
        };
        return View(show);


        //if (mediaType == "tv")
        //{
        //    //make a call to the api
        //    //for now just using basic data

        //    Show show = new Show()
        //    {
        //        Title = title,
        //        FirstAirDate = ReleaseDate.ToString()
        //    };
        //    return View(show);

        //} else
        //{
        //    Movie movie = new Movie()
        //    {
        //        Title = title,
        //        ReleaseDate = ReleaseDate.ToString()
        //    };
        //    return View(movie);
        //}

    }

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}
