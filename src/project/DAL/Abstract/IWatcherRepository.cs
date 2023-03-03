using WatchParty.Models;

namespace WatchParty.DAL.Abstract
{
    public interface IWatcherRepository : IRepository<Watcher>
    {
        Watcher? FindByUsername(string username);
        Watcher? FindByAspNetId(string aspId);
    }
}
