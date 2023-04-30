using WatchParty.DAL.Abstract;
using WatchParty.Models;

namespace WatchParty.DAL.Concrete;
public class WatchPartyGroupAssignmentRepository : Repository<WatchPartyGroupAssignment>, IWatchPartyGroupAssignmentRepository
{
    public WatchPartyGroupAssignmentRepository(WatchPartyDbContext ctx) : base(ctx)
    {
    }

    public void AddToGroup(WatchPartyGroupAssignment assignment)
    {
        if (assignment == null)
            throw new ArgumentNullException(nameof(assignment));

        WatchPartyGroupAssignment? alreadyExists = GetAll().FirstOrDefault(a => a.WatcherId == assignment.WatcherId && a.GroupId == assignment.GroupId);
        WatchPartyGroupAssignment? host = GetAll().FirstOrDefault(a => a.Group.HostId == assignment.WatcherId);

        if (alreadyExists != null)
            throw new Exception("User is already in group");

        if (host != null)
            throw new Exception("Host cannot be added to group");

        try
        {
            AddOrUpdate(assignment);
        }
        catch
        {
            throw new Exception("Invalid information was given while trying to update database");
        }
    }

    public List<int> GetGroupIds(int userId)
    {
        throw new NotImplementedException();
    }
}