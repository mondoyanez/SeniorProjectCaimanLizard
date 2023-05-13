using NUnit.Framework;
using OpenQA.Selenium;
using WatchParty_BDD_Tests.Drivers;
using WatchParty_BDD_Tests.PageObjects;

namespace WatchParty_BDD_Tests.StepDefinitions
{
    [Binding]
    public class CLD199_RemoveUserWatchPartyStepDefinitions
    {
        private readonly WatchPartyDetailsPageObject _watchPartyPage;

        public CLD199_RemoveUserWatchPartyStepDefinitions(BrowserDriver browserDriver)
        {
            _watchPartyPage = new WatchPartyDetailsPageObject(browserDriver.Current);
        }

        [Then(@"I should not see the group options button")]
        public void ThenIShouldNotSeeTheGroupOptionsButton()
        {
            Assert.Throws<NoSuchElementException>(() => _watchPartyPage.GroupOptionsButton.Click());
        }
    }
}
