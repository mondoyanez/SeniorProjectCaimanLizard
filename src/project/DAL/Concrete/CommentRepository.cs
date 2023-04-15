using WatchParty.DAL.Abstract;
using WatchParty.Models;
using WatchParty.Utilities;

namespace WatchParty.DAL.Concrete;
public class CommentRepository: Repository<Comment>, ICommentRepository
{
    public CommentRepository(WatchPartyDbContext ctx) : base(ctx)
    {
    }

    public IEnumerable<Comment> GetComments(int number = 0)
    {
        IEnumerable<Comment> comments = GetAll().OrderBy(c => c.DatePosted).ToList();

        if (number != 0)
        {
            comments = comments.Take(number);
        }

        if (!comments.Any())
            throw new Exception("No comments were found");

        return comments;
    }

    public void AddComment(Comment? comment)
    {
        if (comment == null)
        {
            throw new ArgumentNullException(nameof(comment));
        }

        try
        {
            AddOrUpdate(comment);
        }
        catch
        {
            throw new Exception("Invalid information was given while trying to update database");
        }
    }
}