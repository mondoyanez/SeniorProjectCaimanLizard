using WatchParty.Models;
using WatchParty.Models.Concrete;
using WatchParty.Utilities;

namespace WatchParty.ViewModels
{
	public class FeedVM
	{
		public IEnumerable<Post> Posts { get; set; }
		public IEnumerable<Comment> Comments { get; set; }
        public DateFromConversion Convert { get; set; } = new();
		public IEnumerable<TMDBTitle> PopularMovies { get; set; }
		public IEnumerable<TMDBTitle> PopularShows { get; set; }
		public TMDBImageConfig ImageConfig { get; set; }
    }
}
