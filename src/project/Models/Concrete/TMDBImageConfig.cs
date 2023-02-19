namespace WatchParty.Models.Concrete
{
	public class TMDBImageConfig
	{
		public string? BaseUrl { get; set; }
		public IEnumerable<string>? PosterSizes { get; set; }
		public IEnumerable<string>? ProfileSizes { get; set; }

	}
}
