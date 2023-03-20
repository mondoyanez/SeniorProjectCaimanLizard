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
    private readonly IWatcherRepository _watcherRepository;
    private readonly IFollowingListRepository _followingListRepository;
    public FollowingListController(IWatcherRepository watcherRepository, IFollowingListRepository followingListRepository)
    {
        _watcherRepository = watcherRepository;
        _followingListRepository = followingListRepository;
    }

    [HttpPost("addFollower")]
    public IActionResult AddFollower(int followerId)
    {
        Watcher? loggedInWatcher = _watcherRepository.FindByUsername(User.Identity.Name);

        return Ok(StatusCodes.Status201Created);
    }

}