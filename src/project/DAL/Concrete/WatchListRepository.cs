using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.FileSystemGlobbing;
using NuGet.Protocol.Plugins;
using WatchParty.DAL.Abstract;
using WatchParty.Models;

namespace WatchParty.DAL.Concrete;

public class WatchListRepository : Repository<WatchList>, IWatchListRepository
{
    public WatchListRepository(WatchPartyDbContext ctx) : base(ctx)
    {
    }

    public WatchList? FindByUserID(int userID)
    {
        if (userID == null)
            throw new ArgumentNullException(nameof(userID));

        WatchList? watchList = GetAll().FirstOrDefault(w => w.UserId == userID);

        return watchList;
    }

    public IEnumerable<WatchList> FindAllByUserID(int userID)
    {
        if (userID == null)
            throw new ArgumentNullException(nameof(userID));

        IEnumerable<WatchList>? watchLists = GetAll().Where(w => w.UserId == userID);

        if (watchLists == null)
            return Enumerable.Empty<WatchList>();

        return watchLists;
    }

}