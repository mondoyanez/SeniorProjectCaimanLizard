using WatchParty.Models;
using WatchParty.Models.Concrete;

namespace WatchParty.ViewModels
{
    public class WatchListVM
    {
        public bool isCurrentUser;

        public WatchList? currentlyWatchList { get; set; }

        public IEnumerable<WatchListItem>? watchListItems { get; set; }

        public IEnumerable<Show>? shows { get; set; }

        public IEnumerable<Movie>? movies { get; set; }

        public Watcher watcher { get; set; }

        // Want to watch list items
        public IEnumerable<WatchListItem> wantToWatchListItems { get; set; }

        public WatchList? wantToWatchList { get; set; }

        public IEnumerable<Show>? shows1 { get; set; }

        public IEnumerable<Movie>? movies1 { get; set; }


    }
}