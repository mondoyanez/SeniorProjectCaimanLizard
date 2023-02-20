using System.Diagnostics;
using Azure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WatchParty.Areas.Identity.Data;
using WatchParty.DAL.Abstract;
using WatchParty.Models;

namespace WatchParty.Controllers;

public class UserController : Controller
{
    private readonly ILogger<HomeController> _logger;
    //private readonly WatchPartyDbContext _watchPartyDbContext;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IWatcherRepository _watcherRepository;

    public UserController(ILogger<HomeController> logger, IWatcherRepository watcherRepsoitory, UserManager<IdentityUser> userManager)
    {
        _logger = logger;
        //_watchPartyDbContext = watchPartyDbContext;
        _userManager = userManager;
        _watcherRepository = watcherRepsoitory;
    }

    // GET: user/ {username}
    //[Authorize]
    //[HttpGet("{username}")]
    public ActionResult<Watcher> Profile(string username)
    {
        if (_watcherRepository == null)
        {
            return View("Notfound");
        }

        Watcher watcher = _watcherRepository.FindByUsername(username);
        if (watcher == null)
        {
            return View("Notfound");
        }

        return View(watcher);
    }

    public IActionResult Notfound()
    {
        return View();
    }

}
