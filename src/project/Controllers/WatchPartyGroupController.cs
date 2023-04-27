using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WatchParty.DAL.Abstract;

namespace WatchParty.Controllers;

[Authorize]
public class WatchPartyGroupController : Controller
{
    private readonly IWatchPartyGroupRepository _groupRepository;
    private readonly IWatchPartyGroupAssignmentRepository _assignmentRepository;
    private readonly IWatcherRepository _watcherRepository;
    private readonly UserManager<IdentityUser> _userManager;

    public WatchPartyGroupController(IWatchPartyGroupRepository groupRepository, IWatchPartyGroupAssignmentRepository assignmentRepository, IWatcherRepository watcherRepository, UserManager<IdentityUser> userManager)
    {
        _groupRepository = groupRepository;
        _assignmentRepository = assignmentRepository;
        _watcherRepository = watcherRepository;
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        return View();
    }
}

