using NUnit.Framework;
using OpenQA.Selenium;
using WatchParty_BDD_Tests.Drivers;
using WatchParty_BDD_Tests.PageObjects;

namespace WatchParty_BDD_Tests.StepDefinitions
{
    [Binding]
    public class CLD199_RemoveUserWatchPartyStepDefinitions
    {
        private readonly CreateWatchPartyPageObject _createWatchPartyPageObject;
        private readonly ProfilePageObject _profilePage;
        private readonly WatchPartyDetailsPageObject _watchPartyPage;

        public CLD199_RemoveUserWatchPartyStepDefinitions(BrowserDriver browserDriver)
        {
            _createWatchPartyPageObject = new CreateWatchPartyPageObject(browserDriver.Current);
            _profilePage = new ProfilePageObject(browserDriver.Current);
            _watchPartyPage = new WatchPartyDetailsPageObject(browserDriver.Current);
        }

        [Given(@"I go to click on the create new watch party button"), When(@"I go to click on the create new watch party button")]
        public void WhenIGoToClickOnTheCreateNewWatchPartyButton()
        {
            _profilePage.CreateWatchParty();
        }

        [Given(@"I click on the add users button"), When(@"I click on the add users button")]
        public void WhenIClickOnTheAddUsersButton()
        {
            _watchPartyPage.SelectInviteUsers();
        }

        [Given(@"I click on the remove users button"), When(@"I click on the remove users button")]
        public void WhenIClickOnTheRemoveUsersButton()
        {
            _watchPartyPage.SelectRemoveUsers();
        }

        [Given(@"I click on the group options button"), When(@"I click on the group options button")]
        public void WhenIClickOnTheGroupOptionsButton()
        {
            _watchPartyPage.ExpandGroupGroupOptions();
        }

        [Given(@"I add ""([^""]*)"" to the group"), When(@"I add ""([^""]*)"" to the group")]
        public void WhenIAddToTheGroup(string username)
        {
            _watchPartyPage.InviteSelectedUser(username);
        }

        [Given(@"I remove ""([^""]*)"" from the group"), When(@"I remove ""([^""]*)"" from the group")]
        public void WhenIRemoveFromTheGroup(string username)
        {
            _watchPartyPage.RemoveSelectedUser(username);
        }

        [Given(@"I close the open invite modal"), When(@"I close the open invite modal")]
        public void WhenICloseTheOpenInviteModal()
        {
            _watchPartyPage.CloseOpenModalInvite();
        }

        [Given(@"I close the open remove modal"), When(@"I close the open remove modal")]
        public void WhenICloseTheOpenRemoveModal()
        {
            _watchPartyPage.CloseCloseModalRemove();
        }

        [Given(@"I enter ""([^""]*)"" for the watch party title"), When(@"I enter ""([^""]*)"" for the watch party title")]
        public void WhenIEnterForTheWatchPartyTitle(string title)
        {
            _createWatchPartyPageObject.EnterTitle(title);
        }

        [Given(@"I enter ""([^""]*)"" for the watch party description"), When(@"I enter ""([^""]*)"" for the watch party description")]
        public void WhenIEnterForTheWatchPartyDescription(string description)
        {
            _createWatchPartyPageObject.EnterDescription(description);
        }

        [Given(@"I enter the watch party start date"), When(@"I enter the watch party start date")]
        public void WhenIEnterTheWatchPartyStartDate()
        {
            _createWatchPartyPageObject.EnterStartDate("10-15-2024");
            _createWatchPartyPageObject.EnterStartDate(Keys.Tab);
            _createWatchPartyPageObject.EnterStartDate("20:00");
        }

        [Given(@"I create the watch party"), When(@"I create the watch party")]
        public void WhenICreateTheWatchParty()
        {
            _createWatchPartyPageObject.CreateWatchParty();
        }

        [Given(@"I go to the details page of the newly created watch party"), When(@"I go to the details page of the newly created watch party")]
        public void WhenIGoToTheDetailsPageOfTheNewlyCreatedWatchParty()
        {
            _profilePage.GoToWatchPartyDetails();
        }

        [Then(@"I should not see the group options button")]
        public void ThenIShouldNotSeeTheGroupOptionsButton()
        {
            Assert.Throws<NoSuchElementException>(() => _watchPartyPage.GroupOptionsButton.Click());
        }

        [Then(@"I should see the group options button")]
        public void ThenIShouldSeeTheGroupOptionsButton()
        {
            _watchPartyPage.GroupOptionsButton.Should().NotBeNull();
            _watchPartyPage.GroupOptionsButton.Displayed.Should().BeTrue();
        }

        [Then(@"I should see that ""([^""]*)"" was added to the group")]
        public void ThenIShouldSeeThatWasAddedToTheGroup(string username)
        {
            _watchPartyPage.RefreshCurrentPage();
            _watchPartyPage.UserInTable(username);

            _watchPartyPage.CurrentUser.Should().NotBeNull();
            _watchPartyPage.CurrentUser.Displayed.Should().BeTrue();
        }

        [Then(@"I should not see that ""([^""]*)"" is in the group")]
        public void ThenIShouldNotSeeThatIsInTheGroup(string username)
        {
            _watchPartyPage.UserInTable(username);
            _watchPartyPage.CurrentUser.Should().BeNull();
            _watchPartyPage.RefreshCurrentPage();
        }

    }
}
