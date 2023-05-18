using System;
using TechTalk.SpecFlow;
using WatchParty_BDD_Tests.Drivers;
using WatchParty_BDD_Tests.PageObjects;

namespace WatchParty_BDD_Tests.StepDefinitions
{
    [Binding]
    public class CLD200_EditGroupStepDefinitions
    {
        private readonly EditWatchPartyPageObject _editWatchPartyPageObject;
        private readonly ProfilePageObject _profilePage;
        private readonly WatchPartyDetailsPageObject _watchPartyPage;

        public CLD200_EditGroupStepDefinitions(BrowserDriver browserDriver)
        {
            _editWatchPartyPageObject = new EditWatchPartyPageObject(browserDriver.Current);
            _profilePage = new ProfilePageObject(browserDriver.Current);
            _watchPartyPage = new WatchPartyDetailsPageObject(browserDriver.Current);
        }

        [Given(@"I click on the edit group button"), When(@"I click on the edit group button")]
        public void WhenIClickOnTheEditGroupButton()
        {
            _watchPartyPage.SelectEditGroup();
        }

        [Given(@"I update the title to ""([^""]*)"""), When(@"I update the title to ""([^""]*)""")]
        public void WhenIUpdateTheTitleTo(string title)
        {
            _editWatchPartyPageObject.EnterTitle(title);
        }

        [Given(@"I update the description to ""([^""]*)"""), When(@"I update the description to ""([^""]*)""")]
        public void WhenIUpdateTheDescriptionTo(string description)
        {
            _editWatchPartyPageObject.EnterDescription(description);
        }

        [Given(@"I update the start date to ""([^""]*)"" and start time to ""([^""]*)"""), When(@"I update the start date to ""([^""]*)"" and start time to ""([^""]*)""")]
        public void WhenIUpdateTheStartDateToAndStartTimeTo(string date, string time)
        {
            _editWatchPartyPageObject.EnterStartDate(date, time);
        }


        [Given(@"I update the teleparty link to ""([^""]*)"""), When(@"I update the teleparty link to ""([^""]*)""")]
        public void WhenIUpdateTheTelepartyLinkTo(string url)
        {
            _editWatchPartyPageObject.EnterTelePartyUrl(url);
        }


        [Given(@"I click on update"), When(@"I click on update")]
        public void WhenIClickOnUpdate()
        {
            _editWatchPartyPageObject.UpdateGroup();
        }

        [Then(@"I should be redirected to the details page with page title ""([^""]*)""")]
        public void ThenIShouldBeRedirectedToTheDetailsPageWithPageTitle(string p0)
        {
            _watchPartyPage.GetTitle().Should().ContainEquivalentOf(p0, AtLeast.Once());
        }

        [Then(@"I should see header ""([^""]*)"", group title ""([^""]*)"", group description ""([^""]*)"", start date ""([^""]*)"", and TeleParty URL ""([^""]*)"" have all been updated")]
        public void ThenIShouldSeeHeaderGroupTitleGroupDescriptionStartDateAndTelePartyURLHaveAllBeenUpdated(string headerTitle, string groupTitle, string groupDescription, string groupStartDate, string groupTelePartyUrl)
        {
            _watchPartyPage.DetailsHeaderElementText().Should().ContainEquivalentOf(headerTitle, AtLeast.Once());
            _watchPartyPage.GroupTitleText().Should().ContainEquivalentOf(groupTitle, AtLeast.Once());
            _watchPartyPage.GroupDescriptionText().Should().ContainEquivalentOf(groupDescription, AtLeast.Once());
            _watchPartyPage.GroupDateText().Should().ContainEquivalentOf(groupStartDate, AtLeast.Once());
            _watchPartyPage.TelePartyUrlText().Should().ContainEquivalentOf(groupTelePartyUrl, AtLeast.Once());
        }

        [Then(@"I should see a header titled ""([^""]*)""")]
        public void ThenIShouldSeeAHeaderTitled(string p0)
        {
            _editWatchPartyPageObject.UnauthorizedHeaderText().Should().ContainEquivalentOf(p0, AtLeast.Once());
        }

    }
}
