using WatchParty.Models;

namespace WatchParty.DAL.Abstract;
public interface IFollowingListRepository: IRepository<FollowingList>
{
    List<FollowingList> GetFollowingList(int id);
    List<FollowingList> GetFollowerList(int id);
}