using Microsoft.AspNetCore.Identity;
using WatchParty.Models;

namespace WatchParty.DAL.Abstract
{
    public interface IWatchListItemRepository : IRepository<WatchListItem>
    {
        IEnumerable<WatchListItem> GetAllWatchListItemsByID(int watchListId);

        IEnumerable<WatchListItem> FindAllByShowId(int showId);
        IEnumerable<WatchListItem> FindAllByMovieId(int movieId);
        bool ExistsWithDifferentId(int id1, int id2);
    }
}