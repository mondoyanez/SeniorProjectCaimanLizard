using WatchParty.Models;

namespace WatchParty.DAL.Abstract;
public interface ICommentRepository: IRepository<Comment>
{
    IEnumerable<Comment> GetVisibleComments();
    void AddComment(Comment comment);
    void HideComment(Comment comment);
}