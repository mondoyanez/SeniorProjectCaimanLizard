using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WatchParty.DAL.Abstract;
using WatchParty.Models;
using WatchParty.ViewModels;

namespace WatchParty.Controllers;

[Authorize]
public class WatchPartyGroupController : Controller
{
    private readonly IWatchPartyGroupRepository _groupRepository;
    private readonly IWatchPartyGroupAssignmentRepository _assignmentRepository;
    private readonly IWatcherRepository _watcherRepository;

    public WatchPartyGroupController(IWatchPartyGroupRepository groupRepository, IWatchPartyGroupAssignmentRepository assignmentRepository, IWatcherRepository watcherRepository)
    {
        _groupRepository = groupRepository;
        _assignmentRepository = assignmentRepository;
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
            WatchPartyGroup? group = _groupRepository.FindGroup(newGroup.GroupTitle, newGroup.GroupDescription,
                newGroup.StartDate, newGroup.Host, newGroup.HostId);

            if (group == null)
                throw new NullReferenceException(nameof(group));

            _assignmentRepository.AddToGroup(new WatchPartyGroupAssignment{ Group = group, GroupId = group.Id, Watcher = group.Host, WatcherId = group.HostId });
            return RedirectToAction("Profile", "User", new { username = User.Identity.Name });
        }

        return View();
    }

    [HttpGet]
    public IActionResult Details(int groupId)
    {
        WatchPartyGroup group = _groupRepository.FindById(groupId);
        List<Watcher>? watchers = _watcherRepository.FindAllWatchers();

        PartyGroupVM vm = new()
        {
            Group = group,
            Watchers = watchers
        };

        return View(vm);
    }
}

