using Microsoft.AspNetCore.Identity;
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

        List<Show> result = new();
        IEnumerable<Show> shows = GetAll();

        foreach (WatchListItem watchListItem in watchListItems)
        {
            if (watchListItem.ShowId != null)
            {
                result.Append(shows.Where(s => s.Id == watchListItem.ShowId).First());
            }
        }
  
        return result;
    }






    //public IEnumerable<Show> GetShows(WatchList watchList)
    //{
    //    if (watchList == null)
    //        return Enumerable.Empty<Show>();

    //    IEnumerable<Show> shows = GetAll().Where(s => s.Id == watchList.ShowId);

    //    return shows;

    //}

    //public IEnumerable<Show> GetShows(IEnumerable<WatchList> watchLists)
    //{
    //    if (watchLists == null)
    //        return Enumerable.Empty<Show>();

    //    IEnumerable<Show> shows = GetAll();
    //    List<Show> result = new();

    //    result = shows.Where(s => s.Tmdbid == watchList.ShowId);

    //    return result;

    //foreach (WatchList watchList in watchLists)
    //{
    //    if (watchList.ShowId != null)
    //    {
    //        //result.Add(shows.First(s => s.Tmdbid == watchList.ShowId));
    //        Show show = shows.First(s => s.Tmdbid == watchList.ShowId);
    //        result.Append(show);
    //    }
    //}

    //return result;
    //}
}