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

    public Comment? FindCommentById(int id)
    {
        return GetAll().FirstOrDefault(c => c.Id == id);
    }

    public void HideComment(Comment comment)
    {
        if (FindCommentById(comment.Id) == null)
            throw new Exception("Comment does not exist");

        if (!comment.IsVisible)
            throw new Exception("Comment is already hidden");

        try
        {
            comment.IsVisible = false;
            AddOrUpdate(comment);
        }
        catch
        {
            throw new Exception("Invalid information was given while trying to update database");
        }
    }
}