using Microsoft.EntityFrameworkCore;
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
        return GetAll().OrderByDescending(p => p.DatePosted).ToList();
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
            throw new Exception("Something went wrong with submitting post");
        }
    }
}