using WatchParty.Models.Concrete;

namespace WatchParty.Services.Abstract
{
	public interface ITMDBService
	{
		void SetCredentials(string apiKey);
		TMDBImageConfig SetImageConfig();
		IEnumerable<TMDBGenre> GetMovieGenres();
		IEnumerable<TMDBGenre> GetShowGenres();
		IEnumerable<TMDBTitle> SearchMovies(string movieTitle);
		IEnumerable<TMDBTitle> SearchShows(string showTitle);
		IEnumerable<TMDBTitle> SearchTitles(string title);
		IEnumerable<TMDBPerson> SearchPerson(string personName);
	}
}
