using WatchParty.Models;
using WatchParty.Models.Concrete;

namespace WatchParty.ViewModels
{
	public class FeedVM
	{
		public IEnumerable<Post> Posts { get; set; }	
		public IEnumerable<TMDBTitle> PopularMovies { get; set; }
		public IEnumerable<TMDBTitle> PopularShows { get; set; }
		public TMDBImageConfig ImageConfig { get; set; }
	}
}
