using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WatchParty.Models.Concrete;
using WatchParty.Services.Abstract;

namespace WatchParty.Controllers
{
	[Route("api")]
	[ApiController]
	public class TMDBController : ControllerBase
	{
		private readonly ITMDBService _tmdbService;

		public TMDBController(ITMDBService tmdbService)
		{
			_tmdbService = tmdbService;
		}

		[HttpGet("imageConfig")]
		public IActionResult ImageConfig()
		{
			return Ok(_tmdbService.SetImageConfig());
		}

		[HttpGet("movieGenres")]
		public IActionResult MovieGenres()
		{
			return Ok(_tmdbService.GetMovieGenres());
		}

		[HttpGet("showGenres")]
		public IActionResult ShowGenres()
		{
			return Ok(_tmdbService.GetShowGenres());
		}

		[HttpGet("searchMovie")]
		public IActionResult SearchMovie(string movieTitle)
		{
			return Ok(_tmdbService.SearchMovies(movieTitle));
		}

		[HttpGet("searchShow")]
		public IActionResult SearchShow(string showTitle)
		{
			return Ok(_tmdbService.SearchShows(showTitle));
		}

		[HttpGet("searchTitle")]
		public IActionResult SearchTitle(string title)
		{
			return Ok(_tmdbService.SearchTitles(title));
		}

		[HttpGet("searchPerson")]
		public IActionResult SearchPerson(string personName)
		{
			return Ok(_tmdbService.SearchPerson(personName));
		}

        [HttpGet("searchYear")]
        public IActionResult SearchYear(string year)
        {
            return Ok(_tmdbService.SearchYear(year));
        }
	}
}
