using OpenQA.Selenium;

namespace WatchParty_BDD_Tests.PageObjects;
public class EditWatchPartyPageObject : PageObject
{
    public EditWatchPartyPageObject(IWebDriver webDriver) : base(webDriver)
    {
        _pageName = "EditExistingWatchParty";
    }

    public IWebElement UnauthorizedHeaderElement => _webDriver.FindElement(By.ClassName("watch-party-edit-unauthorized-error"));

    public string UnauthorizedHeaderText()
    {
        return UnauthorizedHeaderElement.Text;
    }
}
