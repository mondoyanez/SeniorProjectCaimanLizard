using WatchParty.DAL.Abstract;
using WatchParty.Models;

namespace WatchParty.DAL.Concrete;
public class WatchPartyGroupRepository : Repository<WatchPartyGroup>, IWatchPartyGroupRepository
{
    public WatchPartyGroupRepository(WatchPartyDbContext ctx) : base(ctx)
    {
    }

    public void CreateWatchPartyGroup(WatchPartyGroup @group)
    {
        throw new NotImplementedException();
    }
}

