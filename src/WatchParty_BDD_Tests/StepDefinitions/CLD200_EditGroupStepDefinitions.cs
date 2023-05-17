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

        [Then(@"I should see a header titled ""([^""]*)""")]
        public void ThenIShouldSeeAHeaderTitled(string p0)
        {
            _editWatchPartyPageObject.UnauthorizedHeaderText().Should().ContainEquivalentOf(p0, AtLeast.Once());
        }

    }
}
