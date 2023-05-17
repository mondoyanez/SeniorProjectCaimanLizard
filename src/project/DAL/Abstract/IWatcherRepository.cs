using Microsoft.AspNetCore.Identity;
using WatchParty.Models;
using WatchParty.Models.DTO;

namespace WatchParty.DAL.Abstract
{
    public interface IWatcherRepository : IRepository<Watcher>
    {
        Watcher? FindByUsername(string username);
        Watcher? FindByAspNetId(string aspId);
        List<Watcher> FindAllWatchers();
        List<WatcherDTO> FindMatchingUsers(string username);
        bool IsCurrentUser(string username, IdentityUser watcher);
    }
}
