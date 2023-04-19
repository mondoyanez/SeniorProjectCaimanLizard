using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing;
using NuGet.Protocol.Plugins;
using System.Linq;
using WatchParty.DAL.Abstract;
using WatchParty.Models;
using WatchParty.Models.Concrete;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WatchParty.DAL.Concrete;

public class ShowRepository : Repository<Show>, IShowRepository
{
    public ShowRepository(WatchPartyDbContext ctx) : base(ctx)
    {
    }

    public Show? CreateShow()
    {
        Show show = new Show();
        TMDBClient client = new TMDBClient();




        return show;
    }

    public Show? FindByTitle(string title)
    {
        if (title == null)
            throw new ArgumentNullException(nameof(title));

        Show show = GetAll().Where(s => s.Title == title).FirstOrDefault();

        return show;

    }

    public IEnumerable<Show> GetShows(IEnumerable<WatchListItem> watchListItems)
    {
        if (watchListItems == null)
            return Enumerable.Empty<Show>();

        var showIds = watchListItems.Where(wli => wli.ShowId != null).Select(wli => wli.ShowId.Value);
        return GetAll().Where(s => showIds.Contains(s.Id));
    }

}