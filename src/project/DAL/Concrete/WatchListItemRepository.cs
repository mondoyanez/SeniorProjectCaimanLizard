using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.FileSystemGlobbing;
using NuGet.Protocol.Plugins;
using WatchParty.DAL.Abstract;
using WatchParty.Models;

namespace WatchParty.DAL.Concrete;

public class WatchListItemRepository : Repository<WatchListItem>, IWatchListItemRepository
{
    public WatchListItemRepository(WatchPartyDbContext ctx) : base(ctx)
    {
    }

    public IEnumerable<WatchListItem> FindAllByShowId(int showId)
    {
        if (showId == null)
            throw new ArgumentNullException(nameof(showId));

        IEnumerable<WatchListItem> watchListItems = GetAll().Where(wli => wli.ShowId == showId);

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


}