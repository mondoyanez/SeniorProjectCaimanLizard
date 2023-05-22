using WatchParty.Models;

namespace WatchParty.ViewModels;
public class ProfileVM
{
    public Watcher? Watcher { get; set; }
    public List<FollowingList>? Followers { get; set; }
    public List<FollowingList>? Following { get; set; }
    public List<WatchPartyGroup>? Groups { get; set; }

    public bool isCurrentUser { get; set; }
    public bool? isFollowing { get; set; }
}