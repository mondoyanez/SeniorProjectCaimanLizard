using OpenQA.Selenium;

namespace WatchParty_BDD_Tests.PageObjects;
public class EditWatchPartyPageObject : PageObject
{
    public EditWatchPartyPageObject(IWebDriver webDriver) : base(webDriver)
    {
        _pageName = "EditExistingWatchParty";
    }
}
