using System.Diagnostics;
using System.Net;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using WatchParty.Models.Abstract;
using WatchParty.Models.Concrete;
using WatchParty.Models.DTO;
using WatchParty.Services.Abstract;

namespace WatchParty.Services.Concrete
{
    public class TMDBService : ITMDBService
    {
        private readonly TMDBClient _httpClient;
        public string BaseSource { get; set; }
        public string? Key { get; set; }

        public TMDBService(string? key, TMDBClient client)
        {
            _httpClient = client;
            BaseSource = "https://api.themoviedb.org/3";
            SetCredentials(key ?? "");
        }

        public void SetCredentials(string apiKey)
        {
            this.Key = apiKey;
        }

        public TMDBImageConfig SetImageConfig(string relativePath = "/configuration")
        {
            var jsonResponse = _httpClient.GetJsonStringFromEndpoint(this.Key, relativePath);
            Debug.WriteLine(jsonResponse);

            TMDBJsonDTO? tmdbJsonDTO = new();
            try
            {
                tmdbJsonDTO = System.Text.Json.JsonSerializer.Deserialize<TMDBJsonDTO>(jsonResponse);
            }
            catch (System.Text.Json.JsonException e)
            {
                tmdbJsonDTO = null;
                Debug.WriteLine(e);
            }

            if (tmdbJsonDTO != null)
            {
                return new TMDBImageConfig()
                {
                    BaseUrl = tmdbJsonDTO.images.secure_base_url,
                    PosterSizes = tmdbJsonDTO.images.poster_sizes,
                    ProfileSizes = tmdbJsonDTO.images.profile_sizes
                };
            }

            return new TMDBImageConfig();
        }

        public IEnumerable<TMDBGenre> GetMovieGenres(string relativePath)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TMDBGenre> GetShowGenres(string relativePath)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TMDBTitle> SearchMovies(string movieTitle, string relativePath = "/search/multi?query=")
        {
            var jsonResponse = _httpClient.GetJsonStringFromEndpoint(this.Key, $"{relativePath}{movieTitle}");
            Debug.WriteLine(jsonResponse);

            TMDBJsonDTO? tmdbJsonDTO = new();
            try
            {
                tmdbJsonDTO = System.Text.Json.JsonSerializer.Deserialize<TMDBJsonDTO>(jsonResponse);
            }
            catch (System.Text.Json.JsonException e)
            {
                tmdbJsonDTO = null;
                Debug.WriteLine(e);
            }

            if (tmdbJsonDTO.results == null) return new List<TMDBTitle>();

            return tmdbJsonDTO.results.Where(results => results.media_type == "movie")
                .OrderByDescending(results => results.popularity).Select(r => new TMDBTitle()
                {
                    Id = r.id,
                    Title = r.title,
                    MediaType = r.media_type,
                    ImagePath = r.poster_path ?? "",
                    Popularity = r.popularity,
                    ReleaseDate = r.release_date,
                    PlotSummary = r.overview
                })
                .ToList();
        }

        public IEnumerable<TMDBTitle> SearchShows(string showTitle, string relativePath = "/search/multi?query=")
        {
            var jsonResponse = _httpClient.GetJsonStringFromEndpoint(this.Key, $"{relativePath}{showTitle}");
            Debug.WriteLine(jsonResponse);

            TMDBJsonDTO? tmdbJsonDTO = new();
            try
            {
                tmdbJsonDTO = System.Text.Json.JsonSerializer.Deserialize<TMDBJsonDTO>(jsonResponse);
            }
            catch (System.Text.Json.JsonException e)
            {
                tmdbJsonDTO = null;
                Debug.WriteLine(e);
            }

            if (tmdbJsonDTO.results == null) return new List<TMDBTitle>();

            return tmdbJsonDTO.results.Where(results => results.media_type == "tv")
                .OrderByDescending(results => results.popularity).Select(r => new TMDBTitle()
                {
                    Id = r.id,
                    Title = r.name,
                    MediaType = r.media_type,
                    ImagePath = r.poster_path ?? "",
                    Popularity = r.popularity,
                    ReleaseDate = r.first_air_date,
                    PlotSummary = r.overview
                })
                .ToList();
        }

        public IEnumerable<TMDBTitle> SearchTitles(string title, string relativePath = "/search/multi?query=")
        {
            var jsonResponse = _httpClient.GetJsonStringFromEndpoint(this.Key, $"{relativePath}{title}");
            Debug.WriteLine(jsonResponse);

            TMDBJsonDTO? tmdbJsonDTO = new();
            try
            {
                tmdbJsonDTO = System.Text.Json.JsonSerializer.Deserialize<TMDBJsonDTO>(jsonResponse);
            }
            catch (System.Text.Json.JsonException e)
            {
                tmdbJsonDTO = null;
                Debug.WriteLine(e);
            }

            if (tmdbJsonDTO?.results == null) return new List<TMDBTitle>();

            return tmdbJsonDTO.results.Where(results => results.media_type != "person")
                .OrderByDescending(results => results.popularity).Select(r => new TMDBTitle()
                {
                    Id = r.id,
                    Title = r.title ?? r.name,
                    MediaType = r.media_type,
                    ImagePath = r.poster_path ?? "",
                    Popularity = r.popularity,
                    ReleaseDate = r.release_date ?? r.first_air_date,
                    PlotSummary = r.overview
                })
                .ToList();
        }

        public IEnumerable<TMDBPerson> SearchPerson(string personName, string relativePath = "/search/person?query=")
        {

            var jsonResponse = _httpClient.GetJsonStringFromEndpoint(this.Key, $"{relativePath}{personName}");
            Debug.WriteLine(jsonResponse);

            TMDBJsonPersonDTO? tmdbJsonDTO = new();
            try
            {
                tmdbJsonDTO = System.Text.Json.JsonSerializer.Deserialize<TMDBJsonPersonDTO>(jsonResponse);
            }
            catch (System.Text.Json.JsonException e)
            {
                tmdbJsonDTO = null;
                Debug.WriteLine(e);
            }

            if (tmdbJsonDTO?.results == null) return new List<TMDBPerson>();

            return tmdbJsonDTO.results.Where(results => results.known_for_department.Equals("Acting"))
                .OrderByDescending(results => results.popularity).Select(r => new TMDBPerson()
                {
                    Id = r.id,
                    Name = r.name ?? r.original_name,
                    ImagePath = r.profile_path ?? string.Empty,
                    Popularity = r.popularity,
                    KnownFor = r.known_for.Select(t => new TMDBTitle()
                    {
                        Id = t.id,
                        Title = t.title ?? t.name,
                        MediaType = t.media_type,
                        ImagePath = t.poster_path ?? String.Empty,
                        Popularity = t.popularity,
                        ReleaseDate = t.release_date ?? t.first_air_date,
                        PlotSummary = t.overview
                    })
                }).ToList();
        }

        public IEnumerable<TMDBTitle> SearchYear(string year, string relativePath = "/search/multi?query=")
        {
            var jsonResponse = _httpClient.GetJsonStringFromEndpoint(this.Key, $"{relativePath}{year}");
            Debug.WriteLine(jsonResponse);

            TMDBJsonDTO? tmdbJsonDTO = new();
            try
            {
                tmdbJsonDTO = System.Text.Json.JsonSerializer.Deserialize<TMDBJsonDTO>(jsonResponse);
            }
            catch (System.Text.Json.JsonException e)
            {
                tmdbJsonDTO = null;
                Debug.WriteLine(e);
            }



            if (tmdbJsonDTO.results == null) return new List<TMDBTitle>();

            return tmdbJsonDTO.results.Where(results => results.release_date.Contains(year))
                .OrderByDescending(results => results.popularity).Select(r => new TMDBTitle()
                {
                    Id = r.id,
                    Title = r.title ?? r.name,
                    MediaType = r.media_type,
                    ImagePath = r.poster_path ?? "",
                    Popularity = r.popularity,
                    ReleaseDate = r.release_date ?? r.first_air_date,
                    PlotSummary = r.overview
                })
                .ToList();
        }

        public IEnumerable<TMDBTitle> GetPopularMovies(string relativePath = "/movie/popular")
        {
			var jsonResponse = _httpClient.GetJsonStringFromEndpoint(this.Key, $"{relativePath}");
			Debug.WriteLine(jsonResponse);

			TMDBJsonDTO? tmdbJsonDTO = new();
			try
			{
				tmdbJsonDTO = System.Text.Json.JsonSerializer.Deserialize<TMDBJsonDTO>(jsonResponse);
			}
			catch (System.Text.Json.JsonException e)
			{
				tmdbJsonDTO = null;
				Debug.WriteLine(e);
			}



			if (tmdbJsonDTO.results == null) return new List<TMDBTitle>();

			return tmdbJsonDTO.results.Select(r => new TMDBTitle()
				{
					Id = r.id,
					Title = r.title ?? r.name,
					MediaType = "movie",
					ImagePath = r.poster_path ?? "",
					Popularity = r.popularity,
					ReleaseDate = r.release_date ?? "",
					PlotSummary = r.overview
				})
				.ToList();
		}

        public IEnumerable<TMDBTitle> GetPopularShows(string relativePath = "/tv/popular")
        {
            var jsonResponse = _httpClient.GetJsonStringFromEndpoint(this.Key, $"{relativePath}");
            Debug.WriteLine(jsonResponse);

            TMDBJsonDTO? tmdbJsonDTO = new();
            try
            {
                tmdbJsonDTO = System.Text.Json.JsonSerializer.Deserialize<TMDBJsonDTO>(jsonResponse);
            }
            catch (System.Text.Json.JsonException e)
            {
                tmdbJsonDTO = null;
                Debug.WriteLine(e);
            }



            if (tmdbJsonDTO.results == null) return new List<TMDBTitle>();

            return tmdbJsonDTO.results.Select(r => new TMDBTitle()
                {
                    Id = r.id,
                    Title = r.name,
                    MediaType = "tv",
                    ImagePath = r.poster_path ?? "",
                    Popularity = r.popularity,
                    ReleaseDate = r.first_air_date ?? "",
                    PlotSummary = r.overview
                })
                .ToList();
        }
    }
}
