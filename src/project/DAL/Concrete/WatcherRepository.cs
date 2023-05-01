using Microsoft.AspNetCore.Identity;
using WatchParty.DAL.Abstract;
using WatchParty.Models;
using WatchParty.Models.DTO;

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

    public List<Watcher> FindAllWatchers()
    {
        return GetAll().ToList();
    }

    public List<WatcherDTO> FindMatchingUsers(string username)
    {
        if (username == null)
            throw new ArgumentNullException(nameof(username));

        List<WatcherDTO> watchers = GetAll().Where(w => w.Username.Contains(username))
            .Select(r => new WatcherDTO()
            {
                Username = r.Username,
                Email = r.Email,
                FirstName = r.FirstName,
                LastName = r.LastName,
            }).ToList();

        return watchers;
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
