using WatchParty.Models;

namespace WatchParty.DAL.Abstract;
public interface ICommentRepository: IRepository<Comment>
{
    IEnumerable<Comment> GetComments();
    void AddComment(Comment comment);
}