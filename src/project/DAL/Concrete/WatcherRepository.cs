using WatchParty.DAL.Abstract;
using WatchParty.Models;

namespace WatchParty.DAL.Concrete;

public class WatcherRepository : Repository<Watcher>, IWatcherRepository
{
    public WatcherRepository(WatchPartyDbContext ctx) : base(ctx) 
    {
    }
}
