using System.Diagnostics;
using Azure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WatchParty.Areas.Identity.Data;
using WatchParty.Models;

namespace WatchParty.Controllers;

public class UserController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly WatchPartyDbContext _watchPartyDbContext;
    private readonly UserManager<IdentityUser> _userManager;

    public UserController(ILogger<HomeController> logger, WatchPartyDbContext watchPartyDbContext, UserManager<IdentityUser> userManager)
    {
        _logger = logger;
        _watchPartyDbContext = watchPartyDbContext;
        _userManager = userManager;
    }

    // GET: user/profile
    //[Authorize]
    public async Task<IActionResult> Profile()
    {
        ProfileVM vm = new ProfileVM();
        WatchPartyUser user = (WatchPartyUser)await _userManager.GetUserAsync(HttpContext.User);

        if (user != null)
        {
            vm.Watcher.Username = user.Username;
        }

        return View(vm);
    }

    public IActionResult NotFound()
    {
        return View();
    }

}
