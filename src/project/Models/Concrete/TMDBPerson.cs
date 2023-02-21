namespace WatchParty.Models.Concrete
{
	public class TMDBPerson
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? ImagePath { get; set; }
		public double Popularity { get; set; }
		public IEnumerable<TMDBTitle>? KnownFor { get; set; }
	}
}
