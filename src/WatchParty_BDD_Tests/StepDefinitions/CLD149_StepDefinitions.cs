using System;
using TechTalk.SpecFlow;
using WatchParty_BDD_Tests.Drivers;
using WatchParty_BDD_Tests.PageObjects;

namespace WatchParty_BDD_Tests.StepDefinitions
{
    [Binding]
    public class CLD149_StepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly PostIndexPageObject _postIndexPage;
        public CLD149_StepDefinitions(BrowserDriver browserDriver, ScenarioContext context)
        {
            _postIndexPage = new PostIndexPageObject(browserDriver.Current);
            _scenarioContext = context;
        }


        [Then(@"I can see the PopularShowsCarousel element")]
        public void ThenICanSeeThePopularShowsCarouselElement()
        {
            _postIndexPage.PopularShowsCarousel.Displayed.Should().BeTrue();
            //_postIndexPage.PopularShowsCarousel.Should().NotBeNull();
        }

        [Then(@"I can see the PopularMoviesCarousel element")]
        public void ThenICanSeeThePopularMoviesCarouselElement()
        {
            _postIndexPage.PopularMoviesCarousel.Displayed.Should().BeTrue();
            //_postIndexPage.PopularMoviesCarousel.Should().NotBeNull();
        }


        [When(@"I hover over the PopularShowsCarousel element")]
        public void WhenIHoverOverThePopularShowsCarouselElement()
        {
            _postIndexPage.HoverPopularShows();
        }

        [When(@"I hover over the PopularMoviesCarousel element")]
        public void WhenIHoverOverThePopularMoviesCarouselElement()
        {
            _postIndexPage.HoverPopularMovies();
        }


        [Then(@"I can see the show description")]
        public void ThenICanSeeTheShowDescription()
        {
            //_postIndexPage.PopularShowsCarouselHoverText.Should().NotBeNullOrEmpty();
        }

        [Then(@"I can see the movie description")]
        public void ThenICanSeeTheMovieDescription()
        {
           // _postIndexPage.PopularMoviesCarouselHoverText.Should().NotBeNullOrEmpty();
        }
    }
}
