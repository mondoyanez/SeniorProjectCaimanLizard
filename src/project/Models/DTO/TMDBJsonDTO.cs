namespace WatchParty.Models.DTO
{
	public class TMDBJsonDTO
	{
		public Images images { get; set; }
		public string[] change_keys { get; set; }
		public int page { get; set; }
		public Result[] results { get; set; }
		public int total_pages { get; set; }
		public int total_results { get; set; }

		public class Images
		{
			public string base_url { get; set; }
			public string secure_base_url { get; set; }
			public string[] backdrop_sizes { get; set; }
			public string[] logo_sizes { get; set; }
			public string[] poster_sizes { get; set; }
			public string[] profile_sizes { get; set; }
			public string[] still_sizes { get; set; }
		}

		public class Result
		{
			public bool adult { get; set; }
			public string backdrop_path { get; set; }
			public int id { get; set; }
			public string title { get; set; }
			public string original_language { get; set; }
			public string original_title { get; set; }
			public string overview { get; set; }
			public string poster_path { get; set; }
			public string media_type { get; set; }
			public int?[] genre_ids { get; set; }
			public float popularity { get; set; }
			public string release_date { get; set; }
			public bool video { get; set; }
			public float vote_average { get; set; }
			public int vote_count { get; set; }
			public string name { get; set; }
			public string original_name { get; set; }
			public string first_air_date { get; set; }
			public string[] origin_country { get; set; }
		}
	}
}
