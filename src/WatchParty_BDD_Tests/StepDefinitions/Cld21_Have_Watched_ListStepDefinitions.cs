using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using WatchParty_BDD_Tests.Drivers;
using WatchParty_BDD_Tests.PageObjects;
using SeleniumExtras.WaitHelpers;


namespace WatchParty_BDD_Tests.StepDefinitions
{
    [Binding]
    public class Cld21_Have_Watched_ListStepDefinitions
    {
        private readonly HomePageObject _homePage;
        private readonly WatchListPageObject _watchlistPage;
        private readonly SearchPageObject _searchPage;
        private readonly ScenarioContext _scenarioContext;
        private readonly WebDriverWait wait;


        public Cld21_Have_Watched_ListStepDefinitions(ScenarioContext context, BrowserDriver browserDriver)
        {
            _homePage = new HomePageObject(browserDriver.Current);
            _scenarioContext = context;
            _watchlistPage = new WatchListPageObject(browserDriver.Current);
            _searchPage = new SearchPageObject(browserDriver.Current);
            wait = new WebDriverWait(browserDriver.Current, TimeSpan.FromSeconds(10));
        }

        [When(@"I click on the watchlist button")]
        public void WhenIClickOnTheWatchlistButton()
        {
            _watchlistPage.navWatchListButton.Click();
        }

        [Then(@"I should be on my watchlist page")]
        public void ThenIShouldBeOnMyWatchlistPage()
        {
            _homePage.GetTitle().Should().ContainEquivalentOf("Watch List", AtLeast.Once());
        }

        [When(@"I search for ""([^""]*)""")]
        public void WhenISearchFor(string search)
        {
            _homePage.SearchInput.Clear();
            _homePage.SearchInput.SendKeys(search);
            _homePage.SearchInput.Submit();
        }

        [When(@"I add it to my watchlist")]
        public void WhenIAddItToMyWatchlist()
        {
            wait.Until(ExpectedConditions.ElementExists(By.Id("watchlist-dropdown")));
            _searchPage.watchListDropdown.Click();
            _searchPage.addtoCurrentlyWatchingButton.Click();

        }

        [Then(@"I should see the show in my watchlist")]
        public void ThenIShouldSeeTheShowInMyWatchlist()
        {
            _watchlistPage.navWatchListButton.Click();

            _watchlistPage.showTitle.Displayed.Should().BeTrue();
        }



        [When(@"I click on the have watched list button")]
        public void WhenIClickOnTheHaveWatchedListButton()
        {
            _watchlistPage.changeWatchList.Click();
            _watchlistPage.haveListDropdownButton.Click();
        }

        [Then(@"I should see my have watched list")]
        public void ThenIShouldSeeMyHaveWatchedList()
        {
            _watchlistPage.haveWatchedList.Displayed.Should().BeTrue();
        }

        [When(@"I add it to my have watched list")]
        public void WhenIAddItToMyHaveWatchedList()
        {
            wait.Until(ExpectedConditions.ElementExists(By.Id("watchlist-dropdown")));
            _searchPage.watchListDropdown.Click();
            _searchPage.addtoHaveWatchedButton.Click();
        }




    }
}
