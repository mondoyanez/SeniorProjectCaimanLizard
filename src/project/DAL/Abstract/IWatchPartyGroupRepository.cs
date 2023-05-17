using WatchParty.Models;

namespace WatchParty.DAL.Abstract;
public interface IWatchPartyGroupRepository : IRepository<WatchPartyGroup>
{
    void CreateWatchPartyGroup(WatchPartyGroup group);
    WatchPartyGroup? FindGroup(string groupTitle, string? groupDescription, DateTime startDate, Watcher host, int hostId);
    WatchPartyGroup? GetById(int id);
}