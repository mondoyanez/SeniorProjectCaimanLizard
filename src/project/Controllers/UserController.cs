using System.Diagnostics;
using Azure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WatchParty.Areas.Identity.Data;
using WatchParty.DAL.Abstract;
using WatchParty.Models;
using WatchParty.ViewModels;

namespace WatchParty.Controllers;

public class UserController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IWatcherRepository _watcherRepository;
    private readonly IFollowingListRepository _followingListRepository;
    private readonly IWatchPartyGroupAssignmentRepository _assignmentRepository;
    private readonly IWatchPartyGroupRepository _groupRepository;
    private readonly WatchPartyDbContext _context;

    public UserController(ILogger<HomeController> logger, IWatcherRepository watcherRepsoitory, UserManager<IdentityUser> userManager, IFollowingListRepository followingListRepository, IWatchPartyGroupAssignmentRepository assignmentRepository, IWatchPartyGroupRepository groupRepository, WatchPartyDbContext context)
    {
        _logger = logger;
        _userManager = userManager;
        _watcherRepository = watcherRepsoitory;
        _followingListRepository = followingListRepository;
        _assignmentRepository = assignmentRepository;
        _groupRepository = groupRepository;
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

        Watcher? loggedInUser = _watcherRepository.FindByUsername(User.Identity.Name);
        Watcher? watcher = _watcherRepository.FindByUsername(username);

        if (loggedInUser == null)
            throw new ArgumentNullException(nameof(loggedInUser));

        if (watcher == null)
            throw new ArgumentNullException(nameof(watcher));

        List<FollowingList> followingList = _followingListRepository.GetFollowingList(watcher.Id);
        List<FollowingList> followerList = _followingListRepository.GetFollowerList(watcher.Id);
        List<WatchPartyGroup> watchPartyGroups = new List<WatchPartyGroup>();

        List<int> groupIds = _assignmentRepository.GetGroupIds(watcher.Id);

        if (groupIds.Any())
        {
            foreach (var group in groupIds)
                watchPartyGroups.Add(_groupRepository.GetById(group));
        }
        

        vm.Watcher = watcher;
        vm.Following = followingList;
        vm.Followers = followerList;

        vm.isFollowing = watcher.Id != loggedInUser?.Id ? _followingListRepository.IsFollowing(loggedInUser.Id, watcher.Id) : null;

        var currentUser = await _userManager.GetUserAsync(User);
        vm.isCurrentUser = _watcherRepository.IsCurrentUser(username, currentUser);

        vm.Groups = watchPartyGroups;

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
    public async Task<IActionResult> ProfileAsync([Bind("Id,AspNetIdentityId,Username,FirstName,LastName,Email,FollowingCount,FollowerCount,Bio,WatchListPrivacy")] Watcher watcher)
    {
        ModelState.ClearValidationState("watcher.AspNetIdentityId");
        ModelState.ClearValidationState("watcher.Id");
        //if (ModelState.IsValid)
        //{
        //}
        _watcherRepository.AddOrUpdate(watcher);

        Watcher? loggedInUser = _watcherRepository.FindByUsername(User.Identity.Name);

        ProfileVM vm = new ProfileVM();
        vm.Watcher = watcher;

        var currentUser = await _userManager.GetUserAsync(User);
        vm.isCurrentUser = _watcherRepository.IsCurrentUser(watcher.Username, currentUser);
        vm.Followers = _followingListRepository.GetFollowerList(watcher.Id);
        vm.Following = _followingListRepository.GetFollowingList(watcher.Id);
        vm.isFollowing = watcher.Id != loggedInUser?.Id ? _followingListRepository.IsFollowing(loggedInUser.Id, watcher.Id) : null;

        return View(vm);
    }

    private bool WatcherExists(int id)
    {
        return (_context.Watchers?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
