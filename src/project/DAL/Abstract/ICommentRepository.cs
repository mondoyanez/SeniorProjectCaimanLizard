using WatchParty.Models;

namespace WatchParty.DAL.Abstract;
public interface ICommentRepository: IRepository<Comment>
{
    IEnumerable<Comment> GetComments(int number);
    void AddComment(Comment comment);
}