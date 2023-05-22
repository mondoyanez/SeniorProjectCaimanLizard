using WatchParty.Models;

namespace WatchParty.DAL.Abstract;
public interface ICommentRepository: IRepository<Comment>
{
    IEnumerable<Comment> GetVisibleComments();
    void AddComment(Comment comment);
    Comment? FindCommentById(int id);
    void HideComment(Comment comment);
}