using WatchParty.DAL.Abstract;
using WatchParty.Models;
using WatchParty.Utilities;

namespace WatchParty.DAL.Concrete;
public class PostRepository: Repository<Post>, IPostRepository
{
    public PostRepository(WatchPartyDbContext ctx) : base(ctx)
    {
    }

    public IEnumerable<Post> GetAllPostsDescending()
    {
        IEnumerable<Post> posts = GetAll()
            .Where(p => p.IsVisible)
            .OrderByDescending(p => p.DatePosted)
            .ToList();

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

    public Post? FindPostById(int id)
    {
        return GetAll().FirstOrDefault(p => p.Id == id);
    }

    public void HidePost(Post post)
    {
        if (FindPostById(post.Id) == null)
            throw new Exception("Post does not exist");
        
        if (!post.IsVisible)
            throw new Exception("Post is already hidden");

        try
        {
            post.IsVisible = false;
            AddOrUpdate(post);
        }
        catch
        {
            throw new Exception("Invalid information was given while trying to update database");
        }
    }
}