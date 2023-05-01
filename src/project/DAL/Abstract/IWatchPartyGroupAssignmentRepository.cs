using WatchParty.Models;

namespace WatchParty.DAL.Abstract;
public interface IWatchPartyGroupAssignmentRepository : IRepository<WatchPartyGroupAssignment>
{
    void AddToGroup(WatchPartyGroupAssignment assignment);
    List<int> GetGroupIds(int userId);
}