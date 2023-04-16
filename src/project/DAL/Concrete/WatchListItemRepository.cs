using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.FileSystemGlobbing;
using NuGet.Protocol.Plugins;
using System.Text.RegularExpressions;
using WatchParty.DAL.Abstract;
using WatchParty.Models;

namespace WatchParty.DAL.Concrete;

public class WatchListItemRepository : Repository<WatchListItem>, IWatchListItemRepository
{
    public WatchListItemRepository(WatchPartyDbContext ctx) : base(ctx)
    {
    }

    public bool ExistsWithDifferentId(int watchListId, int ShowId)
    {
        WatchListItem item = GetAll().Where(wli => wli.WatchListId == watchListId).Where(wli => wli.ShowId == ShowId).FirstOrDefault();

        if (item == null)
            return false;
        else return true;
    }

    public IEnumerable<WatchListItem> FindAllByMovieId(int movieId, int watchListID)
    {
        if (movieId == null || watchListID == null)
            throw new ArgumentNullException(nameof(movieId));

        IEnumerable<WatchListItem> watchListItems = GetAll().Where(wli => wli.MovieId == movieId).Where(wli => wli.WatchListId == watchListID);

        return watchListItems;
    }

    public IEnumerable<WatchListItem> FindAllByShowId(int showId, int watchListID)
    {
        if (showId == null || watchListID == null)
            throw new ArgumentNullException(nameof(showId));

        IEnumerable<WatchListItem> watchListItems = GetAll().Where(wli => wli.ShowId == showId);
        //watchListItems.Where(wli => wli.WatchListId == watchListID);

        return watchListItems;
    }

    public IEnumerable<WatchListItem> GetAllWatchListItemsByID(int watchListId)
    {
        if (watchListId == null)
            return Enumerable.Empty<WatchListItem>();

        IEnumerable<WatchListItem> watchListItems = GetAll().Where(i => i.WatchListId == watchListId);

        if (watchListItems == null)
            return Enumerable.Empty<WatchListItem>();

        return watchListItems;
    }

    public WatchListItem FilterForCurrentWatchList(IEnumerable<WatchListItem> watchListItems, int watchListID)
    {
        //.Where(wli => wli.WatchListId == watchList.Id).First();
        WatchListItem item = watchListItems.Where(wli => wli.WatchListId == watchListID).First();

        //if (item == null)
        //    return Empty<WatchListItem>();

        return item;
    }
}