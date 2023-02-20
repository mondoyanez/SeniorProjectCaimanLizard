namespace WatchParty.Models.Concrete
{
	public class TMDBTitle
	{
		public int Id { get; set; }
		public string? Title { get; set; }
		public string? MediaType { get; set; }
		public string? ImagePath { get; set; }
		public double Popularity { get; set; }
		public string? ReleaseDate { get; set; }
		public string? PlotSummary { get; set; }
	}
}
