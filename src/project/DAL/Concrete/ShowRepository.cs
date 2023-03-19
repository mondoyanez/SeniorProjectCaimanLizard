using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing;
using NuGet.Protocol.Plugins;
using System.Linq;
using WatchParty.DAL.Abstract;
using WatchParty.Models;

namespace WatchParty.DAL.Concrete;

public class ShowRepository : Repository<Show>, IShowRepository
{
    public ShowRepository(WatchPartyDbContext ctx) : base(ctx)
    {
    }

    public IEnumerable<Show> GetShows(IEnumerable<WatchListItem> watchListItems)
    {
        if (watchListItems == null)
            return Enumerable.Empty<Show>();

        var showIds = watchListItems.Where(wli => wli.ShowId != null).Select(wli => wli.ShowId.Value);
        return GetAll().Where(s => showIds.Contains(s.Id));
    }

}