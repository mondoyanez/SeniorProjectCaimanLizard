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
}