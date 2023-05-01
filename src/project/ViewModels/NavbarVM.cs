using WatchParty.Models;


namespace WatchParty.ViewModels;

public class NavbarVM
{
    //public IEnumerable<Notification> notifications { get; set; }

    public IEnumerable<Notification> recentNotifications { get; set; }

    public int newNotificationCount { get; set; }
}
