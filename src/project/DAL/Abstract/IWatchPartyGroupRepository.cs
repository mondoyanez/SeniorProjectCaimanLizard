using WatchParty.Models;

namespace WatchParty.DAL.Abstract;
public interface IWatchPartyGroupRepository : IRepository<WatchPartyGroup>
{
    void CreateWatchPartyGroup(WatchPartyGroup group);
}