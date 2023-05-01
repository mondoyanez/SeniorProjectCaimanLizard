using Microsoft.AspNetCore.Identity;
using WatchParty.Models;

namespace WatchParty.DAL.Abstract
{
    public interface INotificationRepository : IRepository<Notification>
    {
        IEnumerable<Notification> FindAllByUserID(int userID);
    }
}