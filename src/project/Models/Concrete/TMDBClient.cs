using WatchParty.Models;
using WatchParty.Models.Abstract;

namespace WatchParty.Models.Concrete
{
	public class TMDBClient : HttpClient, IHttpClient
	{
		public string GetJsonStringFromEndpoint(string? token, string relativePath)
		{
			var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, $"{BaseAddress}{relativePath}")
			{
				Headers =
				{
					{"Accept", "application/json"},
					{"Authorization", "Bearer " + token},
				}
			};

			var response = this.Send(httpRequestMessage);
			// FIXME: this is only a minimal version; make sure to cover all other bases here
			if (response.IsSuccessStatusCode)
			{
				// Note there is only an async version of this so to avoid forcing us to use async, Scott is waiting for the result manually
				var responseText = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
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
