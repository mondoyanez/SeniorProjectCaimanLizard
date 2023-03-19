using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing;
using NuGet.Protocol.Plugins;
using System.Linq;
using WatchParty.DAL.Abstract;
using WatchParty.Models;

namespace WatchParty.DAL.Concrete;

public class MovieRepository : Repository<Movie>, IMovieRepository
{
    public MovieRepository(WatchPartyDbContext ctx) : base(ctx)
    {
    }

    public IEnumerable<Movie> GetMovies(IEnumerable<WatchListItem> watchListItems)
    {
        if (watchListItems == null)
            return Enumerable.Empty<Movie>();

        var movieIds = watchListItems.Where(wli => wli.MovieId != null).Select(wli => wli.MovieId.Value);
        return GetAll().Where(m => movieIds.Contains(m.Id));
    }

}