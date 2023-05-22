using WatchParty.Models;

namespace WatchParty.DAL.Abstract;
public interface IFollowingListRepository: IRepository<FollowingList>
{
    List<FollowingList> GetFollowingList(int id);
    List<FollowingList> GetFollowerList(int id);
    bool IsFollowing(int userId, int followerId);
    void AddFollower(FollowingList newFollow);
    void RemoveFollower(FollowingList follower);
    FollowingList? GetFollowerById(int userId, int followerId);
}