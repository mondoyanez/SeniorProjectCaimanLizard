using WatchParty.Models;

namespace WatchParty.DAL.Abstract;
public interface IWatchPartyGroupAssignmentRepository : IRepository<WatchPartyGroupAssignment>
{
    void AddToGroup(WatchPartyGroupAssignment assignment);
}