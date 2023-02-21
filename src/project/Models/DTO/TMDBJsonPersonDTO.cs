namespace WatchParty.Models.DTO
{
    public class TMDBJsonPersonDTO
    {
        public Result[] results { get; set; }

        public class Result
        {
            public int id { get; set; }
            public string name { get; set; }
            public string original_name { get; set; }
            public string profile_path { get; set; }
            public float popularity { get; set; }
            public string known_for_department { get; set; }
            public KnownFor[] known_for { get; set; }

            public class KnownFor
            {
                public int id { get; set; }
                public string title { get; set; }
                public string name { get; set; }
                public string overview { get; set; }
                public string poster_path { get; set; }
                public string media_type { get; set; }
                public float popularity { get; set; }
                public string release_date { get; set; }
                public string first_air_date { get; set; }
            }
        }
    }
}
