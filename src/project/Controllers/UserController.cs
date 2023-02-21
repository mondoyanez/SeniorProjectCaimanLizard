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
    public ActionResult<Watcher> Profile(string username)
    {
        if (_watcherRepository == null)
        {
            return View("Notfound");
        }
        ProfileVM vm = new ProfileVM();
        Watcher watcher = _watcherRepository.FindByUsername(username);
        vm.Watcher = watcher;

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

    private bool WatcherExists(int id)
    {
        return (_context.Watchers?.Any(e => e.Id == id)).GetValueOrDefault();
    }

}
