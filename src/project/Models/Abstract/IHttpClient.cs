namespace WatchParty.Models.Abstract
{
	public interface IHttpClient
	{
		public string GetJsonStringFromEndpoint(string? token, string uri);
	}
}
