using WatchParty.Models;
using WatchParty.Models.Concrete;

namespace WatchParty.ViewModels
{
    public class WatchListVM
    {
        public bool isCurrentUser;

        public WatchList watchList { get; set; }

        public IEnumerable<WatchList> watchLists { get; set; }

        public IEnumerable<Show> shows { get; set; }

        public IEnumerable<Movie> movies { get; set; }

        public Watcher watcher { get; set; }
    }
}
