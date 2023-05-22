using System;
using TechTalk.SpecFlow;
using WatchParty_BDD_Tests.Drivers;
using WatchParty_BDD_Tests.PageObjects;

namespace WatchParty_BDD_Tests.StepDefinitions
{
    [Binding]
    public class Cld103_Edit_ProfileStepDefinitions
    {
        private readonly HomePageObject _homePage;
        private readonly LoginPageObject _loginPage;
        private readonly ScenarioContext _scenarioContext;

        public Cld103_Edit_ProfileStepDefinitions(ScenarioContext context, BrowserDriver browserDriver)
        {
            _homePage = new HomePageObject(browserDriver.Current);
            _loginPage = new LoginPageObject(browserDriver.Current);
            _scenarioContext = context;
        }

        [Given(@"I'm on the ""([^""]*)"" page")]
        public void GivenImOnThePage(string pageName)
        {
            _homePage.GoTo(pageName);
        }

        [Then(@"the page title contains ""([^""]*)""")]
        public void ThenThePageTitleContains(string p0)
        {
            _homePage.GetTitle().Should().ContainEquivalentOf(p0, AtLeast.Once());
        }

        [Then(@"I should see a link to the Register page")]
        public void ThenIShouldSeeALinkToTheRegisterPage()
        {
            _homePage.RegisterButton.Should().NotBeNull();
            _homePage.RegisterButton.Displayed.Should().BeTrue();
        }
    }
}
