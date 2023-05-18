using System;
using TechTalk.SpecFlow;
using WatchParty_BDD_Tests.Drivers;
using WatchParty_BDD_Tests.PageObjects;

namespace WatchParty_BDD_Tests.StepDefinitions
{
    [Binding]
    public class CLD200_EditGroupStepDefinitions
    {
        private readonly EditWatchPartyPageObject _editWatchPartyPage;
        private readonly ProfilePageObject _profilePage;
        private readonly WatchPartyDetailsPageObject _watchPartyPage;

        public CLD200_EditGroupStepDefinitions(BrowserDriver browserDriver)
        {
            _editWatchPartyPage = new EditWatchPartyPageObject(browserDriver.Current);
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
            _editWatchPartyPage.EnterTitle(title);
        }

        [Given(@"I update the description to ""([^""]*)"""), When(@"I update the description to ""([^""]*)""")]
        public void WhenIUpdateTheDescriptionTo(string description)
        {
            _editWatchPartyPage.EnterDescription(description);
        }

        [Given(@"I update the start date to ""([^""]*)"" and start time to ""([^""]*)"""), When(@"I update the start date to ""([^""]*)"" and start time to ""([^""]*)""")]
        public void WhenIUpdateTheStartDateToAndStartTimeTo(string date, string time)
        {
            _editWatchPartyPage.EnterStartDate(date, time);
        }


        [Given(@"I update the teleparty link to ""([^""]*)"""), When(@"I update the teleparty link to ""([^""]*)""")]
        public void WhenIUpdateTheTelepartyLinkTo(string url)
        {
            _editWatchPartyPage.EnterTelePartyUrl(url);
        }

        [Given(@"I click on update"), When(@"I click on update")]
        public void WhenIClickOnUpdate()
        {
            _editWatchPartyPage.UpdateGroup();
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

        [Then(@"I should see header ""([^""]*)"", group title ""([^""]*)"", group description empty, start date ""([^""]*)"", and TeleParty URL ""([^""]*)"" have all been updated")]
        public void ThenIShouldSeeHeaderGroupTitleGroupDescriptionEmptyStartDateAndTelePartyURLHaveAllBeenUpdated(string headerTitle, string groupTitle, string groupStartDate, string groupTelePartyUrl)
        {
            _watchPartyPage.DetailsHeaderElementText().Should().ContainEquivalentOf(headerTitle, AtLeast.Once());
            _watchPartyPage.GroupTitleText().Should().ContainEquivalentOf(groupTitle, AtLeast.Once());
            _watchPartyPage.GroupDescriptionText().Should().BeNullOrWhiteSpace();
            _watchPartyPage.GroupDateText().Should().ContainEquivalentOf(groupStartDate, AtLeast.Once());
            _watchPartyPage.TelePartyUrlText().Should().ContainEquivalentOf(groupTelePartyUrl, AtLeast.Once());
        }

        [Then(@"I should see a header titled ""([^""]*)""")]
        public void ThenIShouldSeeAHeaderTitled(string p0)
        {
            _editWatchPartyPage.UnauthorizedHeaderText().Should().ContainEquivalentOf(p0, AtLeast.Once());
        }

        [Then(@"I should receive an error message stating Title is a required field on the edit page")]
        public void ThenIShouldReceiveAnErrorMessageStatingTitleIsARequiredFieldOnTheEditPage()
        {
            _editWatchPartyPage.GetTitle().Should().ContainEquivalentOf("Edit Group", AtLeast.Once());
            _editWatchPartyPage.TitleErrorValidationText().Should().ContainEquivalentOf("Title is a required field", AtLeast.Once());
        }

        [Then(@"I should receive an error message telling me to enter the url in the correct format on the edit page")]
        public void ThenIShouldReceiveAnErrorMessageTellingMeToEnterTheUrlInTheCorrectFormatOnTheEditPage()
        {
            _editWatchPartyPage.GetTitle().Should().ContainEquivalentOf("Edit Group", AtLeast.Once());
            _editWatchPartyPage.TelePartyUrlValidationText().Should().ContainEquivalentOf("Must be in format of: https://redirect.teleparty.com/join/44c95d8fcf1fdbe1 with a length of 49 characters", AtLeast.Once());
        }
    }
}
