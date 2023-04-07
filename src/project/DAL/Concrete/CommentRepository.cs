using Microsoft.EntityFrameworkCore;
using WatchParty.DAL.Abstract;
using WatchParty.Models;

namespace WatchParty.DAL.Concrete;
public class CommentRepository: Repository<Comment>, ICommentRepository
{
    public CommentRepository(WatchPartyDbContext ctx) : base(ctx)
    {
    }

    public IEnumerable<Comment> GetComments()
    {
        IEnumerable<Comment> comments = GetAll().OrderBy(c => c.DatePosted).ToList();

        if (!comments.Any())
            throw new Exception("No comments were found");

        return comments;
    }

    public void AddComment(Comment comment)
    {
        throw new NotImplementedException();
    }
}