using Microsoft.AspNetCore.Identity;
using WatchParty.Models;

namespace WatchParty.DAL.Abstract
{
    public interface IWatchListItemRepository : IRepository<WatchListItem>
    {
        IEnumerable<WatchListItem> GetAllWatchListItemsByID(int watchListId);

        IEnumerable<WatchListItem> FindAllByShowId(int showId, int watchListID);
        IEnumerable<WatchListItem> FindAllByMovieId(int movieId, int watchListID);
        bool ExistsWithDifferentId(int WatchListID, int showID);

        WatchListItem FilterForCurrentWatchList(IEnumerable<WatchListItem> watchListItems, int watchListID);
    }
}