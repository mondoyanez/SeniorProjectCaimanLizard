using OpenQA.Selenium;

namespace WatchParty_BDD_Tests.PageObjects;
public class WatchPartyDetailsPageObject : PageObject
{
    public WatchPartyDetailsPageObject(IWebDriver webDriver) : base(webDriver)
    {
        _pageName = "ExistingWatchParty";
    }

    public IWebElement GroupOptionsButton => _webDriver.FindElement(By.Id("watch-group-options-btn"));
    public IWebElement InviteUserButton => _webDriver.FindElement(By.Id("watch-group-invite"));
    public IWebElement RemoveUserButton => _webDriver.FindElement(By.Id("watch-group-remove"));
}

