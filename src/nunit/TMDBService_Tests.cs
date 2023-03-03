/*
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using WatchParty.Services;
using WatchParty.Models.Concrete;
using WatchParty.Models.DTO;
using WatchParty.Services.Abstract;
using WatchParty.Services.Concrete;
using static WatchParty.Models.DTO.TMDBJsonDTO;

namespace WatchPartyTest;

public class TMDBService_Tests
{
	IConfiguration _configuration;
    ITMDBService _tmdbService;

    [SetUp]
    public void Setup()
    {
	    _configuration = new ConfigurationBuilder().AddUserSecrets<TMDBService_Tests>().Build();
        var key = _configuration["TMDB:APIKey"];
        _tmdbService = new TMDBService(key, new TMDBClient { BaseAddress = new Uri("https://api.themoviedb.org/3") });
    }

    [Test]
    public void SetImageConfig_WithSuccessfulSerialization_ReturnsNoFieldsNull()
    {
		// Arrange

		// Act
		var actualConfig = _tmdbService.SetImageConfig();

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(actualConfig.PosterSizes, Is.Not.Null);
			Assert.That(actualConfig.ProfileSizes, Is.Not.Null);
			Assert.That(actualConfig.BaseUrl, Is.Not.Null);
		});
	}

    [Test]
    public void SearchTitles_WithSuccessfulSerialization_ReturnsNoNullResults()
    {
	    // Arrange

	    // Act
	    var actualTitles = _tmdbService.SearchTitles("bee");

	    // Assert
	    foreach (var titleResult in actualTitles)
	    {
		    Assert.Multiple(() =>
		    {
				Assert.That(titleResult.Id, Is.Not.Zero);
				// image paths are allowed to be empty
				Assert.That(titleResult.MediaType, Is.Not.Empty);
				Assert.That(titleResult.PlotSummary, Is.Not.Empty);
				Assert.That(titleResult.Popularity, Is.Not.Zero);
				// Assert.That(titleResult.ReleaseDate, Is.Not.Empty);
				Assert.That(titleResult.Title, Is.Not.Empty);
		    });
	    }
    }
}*/