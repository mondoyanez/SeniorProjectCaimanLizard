using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.FileSystemGlobbing;
using NuGet.Protocol.Plugins;
using WatchParty.DAL.Abstract;
using WatchParty.Models;

namespace WatchParty.DAL.Concrete;

public class ShowRepository : Repository<Show>, IShowRepository
{
    public ShowRepository(WatchPartyDbContext ctx) : base(ctx)
    {
    }
    public IEnumerable<Show> GetShows(WatchList watchList)
    {
        if (watchList == null)
            return Enumerable.Empty<Show>();

        IEnumerable<Show> shows = GetAll().Where(s => s.Tmdbid == watchList.ShowId);

        return shows;

    }
}