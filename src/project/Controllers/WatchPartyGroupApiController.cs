using Microsoft.AspNetCore.Mvc;
using WatchParty.DAL.Abstract;
using WatchParty.Models;

namespace WatchParty.Controllers;

[Route("partyGroup")]
[ApiController]
public class WatchPartyGroupApiController : ControllerBase
{
    private readonly IWatcherRepository _watcherRepository;
    private readonly IWatchPartyGroupRepository _watchPartyGroupRepository;
    private readonly IWatchPartyGroupAssignmentRepository _assignmentRepository;

    public WatchPartyGroupApiController(IWatchPartyGroupAssignmentRepository assignmentRepository, IWatcherRepository watcherRepository, IWatchPartyGroupRepository watchPartyGroupRepository)
    {
        _assignmentRepository = assignmentRepository;
        _watcherRepository = watcherRepository;
        _watchPartyGroupRepository = watchPartyGroupRepository;
    }

    [HttpPost("AddUser")]
    public IActionResult AddUser(int groupId, int userId)
    {
        Watcher watcher = _watcherRepository.FindById(userId);
        WatchPartyGroup? group = _watchPartyGroupRepository.GetById(groupId);

        if (watcher == null)
            throw new ArgumentNullException(nameof(watcher));

        if (group == null)
            throw new ArgumentNullException(nameof(group));

        WatchPartyGroupAssignment assignment = new()
        {
            Group = group,
            GroupId = group.Id,
            Watcher = watcher,
            WatcherId = watcher.Id
        };

        _assignmentRepository.AddToGroup(assignment);

        return Ok(StatusCodes.Status201Created);
    }
}