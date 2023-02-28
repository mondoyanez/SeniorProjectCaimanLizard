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
		public TMDBImageConfig SetImageConfig(string relativePath="/configuration")
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

		public IEnumerable<TMDBTitle> SearchMovies(string movieTitle, string relativePath = "/search/movie?query=")
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

            return tmdbJsonDTO.results.Where(results => results.media_type != "person").OrderByDescending(results => results.popularity).Select(r => new TMDBTitle()
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

		public IEnumerable<TMDBTitle> SearchShows(string showTitle, string relativePath = "/search/tv?query=")
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

            return tmdbJsonDTO.results.Where(results => results.media_type != "person").OrderByDescending(results => results.popularity).Select(r => new TMDBTitle()
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

			if (tmdbJsonDTO.results == null) return new List<TMDBTitle>();

			return tmdbJsonDTO.results.Where(results => results.media_type != "person").OrderByDescending(results => results.popularity).Select(r => new TMDBTitle()
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

		public IEnumerable<TMDBPerson> SearchPerson(string personName, string relativePath)
		{
			throw new NotImplementedException();
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

            return tmdbJsonDTO.results.Where(results => results.release_date.Contains(year)).OrderByDescending(results => results.popularity).Select(r => new TMDBTitle()
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
	}
}
