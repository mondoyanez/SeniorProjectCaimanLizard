using WatchParty.DAL.Abstract;
using WatchParty.Models;

namespace WatchParty.DAL.Concrete;
public class WatchPartyGroupAssignmentRepository : Repository<WatchPartyGroupAssignment>, IWatchPartyGroupAssignmentRepository
{
    public WatchPartyGroupAssignmentRepository(WatchPartyDbContext ctx) : base(ctx)
    {
    }

    public WatchPartyGroupAssignment? FindGroupAssignment(int groupId, int userId)
    {
        return GetAll().FirstOrDefault(g => g.GroupId == groupId && g.WatcherId == userId);
    }

    public void AddToGroup(WatchPartyGroupAssignment assignment)
    {
        if (assignment == null)
            throw new ArgumentNullException(nameof(assignment));

        WatchPartyGroupAssignment? alreadyExists = GetAll().FirstOrDefault(a => a.WatcherId == assignment.WatcherId && a.GroupId == assignment.GroupId);

        if (alreadyExists != null)
            throw new Exception("User is already in group");

        try
        {
            AddOrUpdate(assignment);
        }
        catch
        {
            throw new Exception("Invalid information was given while trying to update database");
        }
    }

    public void RemoveFromGroup(WatchPartyGroupAssignment? assignment)
    {
        if (assignment == null)
            throw new ArgumentNullException(nameof(assignment));

        if (assignment?.Group?.HostId == assignment?.WatcherId)
            throw new Exception("Host cannot be removed from group!");

        try
        {
            Delete(assignment);
        }
        catch
        {
            throw new Exception("Invalid information was given while trying to update database");
        }
    }

    public List<int> GetGroupIds(int userId)
    {
        return GetAll().Where(w => w.WatcherId == userId)
            .Select(w => w.GroupId)
            .ToList();
    }

    public bool UserInGroup(int groupId, string username)
    {
        return GetAll().FirstOrDefault(u => u.Watcher.Username == username && u.GroupId == groupId) != null;
    }
}