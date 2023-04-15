using Microsoft.AspNetCore.Identity;
using WatchParty.Models;

namespace WatchParty.DAL.Abstract
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Movie? FindByTitle(string movieTitle);
        IEnumerable<Movie> GetMovies(IEnumerable<WatchListItem> watchListItems);
    }
}