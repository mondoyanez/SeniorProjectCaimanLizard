using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WatchParty.DAL.Abstract;
using WatchParty.Models;

namespace WatchParty.Controllers;

[Route("followingList")]
[ApiController]
public class FollowingListController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IWatcherRepository _watcherRepository;
    private readonly IFollowingListRepository _followingListRepository;
    public FollowingListController(UserManager<IdentityUser> userManager, IWatcherRepository watcherRepository, IFollowingListRepository followingListRepository)
    {
        _userManager = userManager;
        _watcherRepository = watcherRepository;
        _followingListRepository = followingListRepository;
    }

    [HttpPost("addFollower")]
    public IActionResult AddFollower(string followerId)
    {
        Watcher? loggedInWatcher = _watcherRepository.FindByUsername(User.Identity.Name);
        return Ok();
    }

}