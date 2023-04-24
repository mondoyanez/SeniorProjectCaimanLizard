using WatchParty.Models;


namespace WatchParty.ViewModels;

public class NotificationVM
{
    public IEnumerable<Notification> notifications { get; set; }

    public Watcher watcher { get; set; }
}
