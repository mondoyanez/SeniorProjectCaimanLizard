using WatchParty.Models;

namespace WatchParty.DAL.Abstract;
public interface IPostRepository: IRepository<Post>
{
    IEnumerable<Post> GetAllPostsDescending();
    void AddPost(Post post);
}