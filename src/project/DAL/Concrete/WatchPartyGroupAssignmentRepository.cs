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
        throw new NotImplementedException();
    }
}