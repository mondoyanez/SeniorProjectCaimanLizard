using WatchParty.DAL.Abstract;
using WatchParty.Models;

namespace WatchParty.DAL.Concrete;

public class WatcherRepository : Repository<Watcher>, IWatcherRepository
{
    public WatcherRepository(WatchPartyDbContext ctx) : base(ctx) 
    {
    }

    public Watcher? FindByUsername(string username)
    {
        try
        {
            return GetAll().FirstOrDefault(w => w.Username == username);
        }
        catch
        {
            return null;
        }
        
    }

    public Watcher? FindByAspNetId(string aspId)
    {
        try
        {
            return GetAll().FirstOrDefault(w => w.AspNetIdentityId == aspId);
        }
        catch
        {
            return null;
        }
    }
}
