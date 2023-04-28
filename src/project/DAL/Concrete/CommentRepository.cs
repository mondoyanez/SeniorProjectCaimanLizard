using WatchParty.DAL.Abstract;
using WatchParty.Models;
using WatchParty.Utilities;

namespace WatchParty.DAL.Concrete;
public class CommentRepository: Repository<Comment>, ICommentRepository
{
    public CommentRepository(WatchPartyDbContext ctx) : base(ctx)
    {
    }

    public IEnumerable<Comment> GetVisibleComments()
    {
        IEnumerable<Comment> comments = GetAll().Where(c => c.IsVisible).OrderBy(c => c.DatePosted).ToList();

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

    public void HideComment(Comment comment)
    {
        throw new NotImplementedException();
    }
}