using System.Diagnostics;
using Azure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WatchParty.Areas.Identity.Data;
using WatchParty.DAL.Abstract;
using WatchParty.Models;

namespace WatchParty.Controllers;

public class UserController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IWatcherRepository _watcherRepository;
    private readonly WatchPartyDbContext _context;

    public UserController(ILogger<HomeController> logger, IWatcherRepository watcherRepsoitory, UserManager<IdentityUser> userManager, WatchPartyDbContext context)
    {
        _logger = logger;
        _userManager = userManager;
        _watcherRepository = watcherRepsoitory;
        _context = context;
    }

    // GET: user/ {username}
    [Authorize]
    public async Task<ActionResult<Watcher>> Profile(string username)
    {
        if (_watcherRepository == null)
        {
            return View("Notfound");
        }
        ProfileVM vm = new ProfileVM();
        Watcher watcher = _watcherRepository.FindByUsername(username);
        vm.Watcher = watcher;

        var currentUser = await _userManager.GetUserAsync(User);
        vm.isCurrentUser = _watcherRepository.IsCurrentUser(username, currentUser);


        if (watcher == null)
        {
            return View("Notfound");
        }

        return View(vm);
    }

    public IActionResult Notfound()
    {
        return View();
    }

    public async Task<IActionResult> Edit(string? username)
    {
        if (username == null || _context.Watchers == null)
        {
            return NotFound();
        }

        ProfileVM vm = new ProfileVM();

        Watcher watcher = _watcherRepository.FindByUsername(username);
        vm.Watcher = watcher;

        var currentUser = await _userManager.GetUserAsync(User);
        vm.isCurrentUser = _watcherRepository.IsCurrentUser(username, currentUser);


        if (watcher == null)
        {
            return NotFound();
        }

        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ProfileAsync([Bind("Id,AspNetIdentityId,Username,FirstName,LastName,Email,FollowingCount,FollowerCount,Bio")] Watcher watcher)
    {
        ModelState.ClearValidationState("watcher.AspNetIdentityId");
        ModelState.ClearValidationState("watcher.Id");
        //if (ModelState.IsValid)
        //{
        //}
        _watcherRepository.AddOrUpdate(watcher);

        ProfileVM vm = new ProfileVM();
        vm.Watcher = watcher;

        var currentUser = await _userManager.GetUserAsync(User);
        vm.isCurrentUser = _watcherRepository.IsCurrentUser(watcher.Username, currentUser);


        return View(vm);
    }


    private bool WatcherExists(int id)
    {
        return (_context.Watchers?.Any(e => e.Id == id)).GetValueOrDefault();
    }

}
