using Microsoft.AspNetCore.Identity;
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
        if (aspId == null)
            throw new ArgumentNullException(nameof(aspId));

        Watcher? watcher = GetAll().FirstOrDefault(w => w.AspNetIdentityId == aspId);

        if (watcher?.AspNetIdentityId == null)
            throw new ArgumentNullException(nameof(watcher));

        return watcher;
    }

    public bool IsCurrentUser(string username, IdentityUser currentUser)
    {
        if (currentUser.UserName == username)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
