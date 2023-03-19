using Microsoft.AspNetCore.Mvc;
using WatchParty.DAL.Abstract;

namespace WatchParty.Controllers;

[Route("watcher")]
[ApiController]
public class WatcherController : ControllerBase
{
    private readonly IWatcherRepository _watcherRepository;

    public WatcherController(IWatcherRepository watcherRepository)
    {
        _watcherRepository = watcherRepository;
    }

    [HttpGet("findByUsername")]
    public IActionResult FindByUsername(string username)
    {
        return Ok(_watcherRepository.FindMatchingUsers(username));
    }
}