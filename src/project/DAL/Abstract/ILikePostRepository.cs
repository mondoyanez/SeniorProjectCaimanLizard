using WatchParty.Models;

namespace WatchParty.DAL.Abstract;
public interface ILikePostRepository : IRepository<LikePost>
{
    void AddPostLike(LikePost likePost);
    void RemovePostLike(LikePost likePost);
}