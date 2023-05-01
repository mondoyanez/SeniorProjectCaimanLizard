using System;
using TechTalk.SpecFlow;
using WatchParty_BDD_Tests.Drivers;
using WatchParty_BDD_Tests.PageObjects;

namespace WatchParty_BDD_Tests.StepDefinitions
{
    [Binding]
    public class Cld181_NotificationsStepDefinitions
    {
        private readonly HomePageObject _homePage;
        private readonly NotificationPageObject _notificationPage;
        private readonly ScenarioContext _scenarioContext;

        public Cld181_NotificationsStepDefinitions(ScenarioContext context, BrowserDriver browserDriver)
        {
            _homePage = new HomePageObject(browserDriver.Current);
            _scenarioContext = context;
            _notificationPage = new NotificationPageObject(browserDriver.Current);
        }

        [Then(@"I should see a link to the Notification page")]
        public void ThenIShouldSeeALinkToTheNotificationPage()
        {
            _homePage.NotificationButton.Should().NotBeNull();
            _homePage.NotificationButton.Displayed.Should().BeTrue();
        }


        [When(@"I click on the notification bell")]
        public void WhenIClickOnTheNotificationBell()
        {
            _homePage.NotificationButton.Click();
        }

        [When(@"I click delete for the first notification")]
        public void WhenIClickDeleteForTheFirstNotification()
        {
            _notificationPage.DeleteButton.Click();
        }

        [Then(@"the notification is deleted")]
        public void ThenTheNotificationIsDeleted()
        {
            _notificationPage.NoNotifications.Displayed.Should().BeTrue();
        }



    }


}
