using WatchParty.Models.Concrete;
using WatchParty.Services.Abstract;

namespace WatchParty.Services.Concrete
{
	public class TMDBService : ITMDBService
	{
		public string BaseSource { get; set; }
		public string? Key { get; set; }

		public TMDBService(string? key)
		{
			BaseSource = "https://api.themoviedb.org/3";
			SetCredentials(key ?? "");
		}

		public void SetCredentials(string apiKey)
		{
			this.Key = apiKey;
		}
		public TMDBImageConfig SetImageConfig()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<TMDBGenre> GetMovieGenres()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<TMDBGenre> GetShowGenres()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<TMDBTitle> SearchMovies(string movieTitle)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<TMDBTitle> SearchShows(string showTitle)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<TMDBTitle> SearchTitles(string title)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<TMDBPerson> SearchPerson(string personName)
		{
			throw new NotImplementedException();
		}
	}
}
