using WatchParty_BDD_Tests.Drivers;
using System;
using NUnit.Framework;
using TechTalk.SpecFlow;
using WatchParty_BDD_Tests.PageObjects;

namespace WatchParty_BDD_Tests.StepDefinitions
{
    [Binding]
    public class HomeStepDefinitions
    {
        private readonly HomePageObject _homePage;

        public HomeStepDefinitions(BrowserDriver browserDriver)
        {
            _homePage = new HomePageObject(browserDriver.Current);
        }

        [Given(@"I am a visitor")]
        public void GivenIAmAVisitor()
        {
            // nothing to do
        }

        [Given(@"I am on the ""([^""]*)"" page"), When(@"I am on the ""([^""]*)"" page")]
        public void WhenIAmOnThePage(string pageName)
        {
            _homePage.GoTo(pageName);
        }

        [Then(@"The page presents a Search bar")]
        public void ThenThePagePresentsASearchBar()
        {
            _homePage.SearchBar.Should().NotBeNull();
            _homePage.SearchBar.Displayed.Should().BeTrue();

            Assert.That(_homePage.SearchBar.GetAttribute("action"), Does.Contain("/Home/Search"));
        }
    }
}
