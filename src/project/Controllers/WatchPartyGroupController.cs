using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WatchParty.DAL.Abstract;
using WatchParty.Models;

namespace WatchParty.Controllers;

[Authorize]
public class WatchPartyGroupController : Controller
{
    private readonly IWatchPartyGroupRepository _groupRepository;
    private readonly IWatcherRepository _watcherRepository;

    public WatchPartyGroupController(IWatchPartyGroupRepository groupRepository, IWatcherRepository watcherRepository)
    {
        _groupRepository = groupRepository;
        _watcherRepository = watcherRepository;
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("GroupTitle, GroupDescription, StartDate")] WatchPartyGroup newGroup)
    {
        if (newGroup.StartDate.Equals(new DateTime(1, 1, 1, 0, 0, 0)))
            newGroup.StartDate = new DateTime(DateTime.Now.AddDays(7).Year, DateTime.Now.AddDays(7).Month, DateTime.Now.AddDays(7).Day, 20, 0, 0);

        ModelState.Clear();

        Watcher? watcher = _watcherRepository.FindByUsername(User?.Identity?.Name);

        if (watcher == null)
            throw new ArgumentException(nameof(watcher));

        newGroup.HostId = watcher.Id;
        newGroup.Host = watcher;

        TryValidateModel(newGroup);

        if (ModelState.IsValid)
        {
            _groupRepository.CreateWatchPartyGroup(newGroup);
            return RedirectToAction("Profile", "User", new { username = User.Identity.Name });
        }

        return View();
    }
}

