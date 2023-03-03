using WatchParty.DAL.Abstract;
using WatchParty.Models;

namespace WatchParty.DAL.Concrete;
public class PostRepository: Repository<Post>, IPostRepository
{
    public PostRepository(WatchPartyDbContext ctx) : base(ctx)
    {
    }

    public IEnumerable<Post> GetAllPostsDescending()
    {
        IEnumerable<Post> posts = GetAll().OrderByDescending(p => p.DatePosted).ToList();

        if (!posts.Any())
            throw new Exception("No posts were found");

        return posts;
    }

    public void AddPost(Post? post)
    {
        if (post == null)
        {
            throw new ArgumentNullException(nameof(post));
        }

        try
        {
            AddOrUpdate(post);
        }
        catch
        {
            throw new Exception("Invalid information was given while trying to update database");
        }
    }
}