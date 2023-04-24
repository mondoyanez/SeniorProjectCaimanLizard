using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.FileSystemGlobbing;
using NuGet.Protocol.Plugins;
using WatchParty.DAL.Abstract;
using WatchParty.Models;

namespace WatchParty.DAL.Concrete;

public class NotificationRepository : Repository<Notification>, INotificationRepository
{
    public NotificationRepository(WatchPartyDbContext ctx) : base(ctx)
    {
    }

    public IEnumerable<Notification> FindAllByUserID(int userID)
    {
        throw new NotImplementedException();
    }
}