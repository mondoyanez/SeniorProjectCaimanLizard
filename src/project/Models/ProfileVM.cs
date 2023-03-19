namespace WatchParty.Models
{
    public class ProfileVM
    {
        public Watcher Watcher { get; set; }
        public List<FollowingList> Followers { get; set; }
        public List<FollowingList> Following { get; set; }

        public bool isCurrentUser { get; set; }
    }
}
