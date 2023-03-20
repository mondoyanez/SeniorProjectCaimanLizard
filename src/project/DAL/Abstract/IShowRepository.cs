using Microsoft.AspNetCore.Identity;
using WatchParty.Models;

namespace WatchParty.DAL.Abstract
{
    public interface IShowRepository : IRepository<Show>
    {
        IEnumerable<Show> GetShows(IEnumerable<WatchListItem> watchListItems);

        Show? FindByTitle(string title);
        Show? CreateShow();
    }
}