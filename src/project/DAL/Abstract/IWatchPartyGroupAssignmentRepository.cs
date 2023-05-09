using WatchParty.Models;

namespace WatchParty.DAL.Abstract;
public interface IWatchPartyGroupAssignmentRepository : IRepository<WatchPartyGroupAssignment>
{
    WatchPartyGroupAssignment? FindGroupAssignment(int groupId, int userId);
    void AddToGroup(WatchPartyGroupAssignment assignment);
    void RemoveFromGroup(WatchPartyGroupAssignment assignment);
    List<int> GetGroupIds(int userId);
}