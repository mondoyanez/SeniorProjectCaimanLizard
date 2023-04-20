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
    public IActionResult AddFollower(string followerUsername)
    {
        if (User?.Identity?.Name == null)
        {
            throw new ArgumentNullException(nameof(User));
        }

        Watcher? loggedInWatcher = _watcherRepository.FindByUsername(User.Identity.Name);
        Watcher? followerWatcher = _watcherRepository.FindByUsername(followerUsername);

        if (loggedInWatcher == null || followerWatcher == null)
        {
            throw new NullReferenceException("signed in user was not found");
        }

        FollowingList newFollow = new FollowingList()
        {
            UserId = loggedInWatcher.Id,
            FollowingId = followerWatcher.Id,
            Following = followerWatcher,
            User = loggedInWatcher
        };

        _followingListRepository.AddFollower(newFollow);

        return Ok(StatusCodes.Status201Created);
    }

    [HttpPost("removeFollower")]
    public IActionResult RemoveFollower(string followerUsername)
    {
        if (User?.Identity?.Name == null)
        {
            throw new ArgumentNullException(nameof(User));
        }

        Watcher? loggedInWatcher = _watcherRepository.FindByUsername(User.Identity.Name);
        Watcher? followerWatcher = _watcherRepository.FindByUsername(followerUsername);

        if (loggedInWatcher == null || followerWatcher == null)
        {
            throw new NullReferenceException("signed in user was not found");
        }

        FollowingList? follow = _followingListRepository.GetFollowerById(loggedInWatcher.Id, followerWatcher.Id);

        if (follow == null)
        {
            throw new NullReferenceException($"{loggedInWatcher.Username} is not following {followerWatcher.Username}");
        }

        _followingListRepository.RemoveFollower(follow);

        return Ok(StatusCodes.Status201Created);
    }

}