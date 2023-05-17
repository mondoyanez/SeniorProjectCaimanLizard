using OpenQA.Selenium;

namespace WatchParty_BDD_Tests.PageObjects;
public class ProfilePageObject: PageObject
{
    public ProfilePageObject(IWebDriver webDriver) : base(webDriver)
    {
        _pageName = "Profile";
    }

    public IWebElement CreateWatchPartyButton => _webDriver.FindElement(By.Id("user-create-watch-party"));
    public IWebElement EditProfileButton => _webDriver.FindElement(By.Id("user-profile-edit"));
    public IWebElement FollowUserButton => _webDriver.FindElement(By.Id("user-profile-btn-follow"));
    public IWebElement UnfollowUserButton => _webDriver.FindElement(By.Id("user-profile-following-icon"));
    public IWebElement WatchListButton => _webDriver.FindElement(By.Id("user-profile-watch-list"));
    public IWebElement WatchPartyDetailsLink => _webDriver.FindElement(By.Id("user-watch-party-details-link"));

    public void CreateWatchParty()
    {
        CreateWatchPartyButton.Click();
    }

    public void GoToWatchPartyDetails()
    {
        WatchPartyDetailsLink.Click();
    }
}