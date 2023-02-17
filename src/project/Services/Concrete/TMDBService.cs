using System.Diagnostics;
using System.Net;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using WatchParty.Models.Concrete;
using WatchParty.Models.DTO;
using WatchParty.Services.Abstract;

namespace WatchParty.Services.Concrete
{
	public class TMDBService : ITMDBService
	{
		public static readonly HttpClient _httpClient = new HttpClient();
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
			var source = $"{BaseSource}/configuration";
			var jsonResponse = GetJsonStringFromEndpoint(this.Key, source);
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
					PosterSizes = tmdbJsonDTO.images.profile_sizes,
					ProfileSizes = tmdbJsonDTO.images.profile_sizes
				};
			}

			return new TMDBImageConfig();
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
			var source = $"{BaseSource}/search/multi?query={title}";
			var jsonResponse = GetJsonStringFromEndpoint(this.Key, source);
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

		public IEnumerable<TMDBPerson> SearchPerson(string personName)
		{
			throw new NotImplementedException();
		}

		public string GetJsonStringFromEndpoint(string? token, string uri)
		{
			HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri)
			{
				Headers =
				{
					{"Accept", "application/json"},
					{"Authorization", "Bearer " + token},
				}
			};

			HttpResponseMessage response = _httpClient.Send(httpRequestMessage);
			// FIXME: this is only a minimal version; make sure to cover all other bases here
			if (response.IsSuccessStatusCode)
			{
				// Note there is only an async version of this so to avoid forcing us to use async, Scott is waiting for the result manually
				string responseText = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
				return responseText;
			}
			else
			{
				// FIXME: What to do if failure? Should throw and catch specific exceptions that explain what happened
				return null;
			}
		}
	}
}
