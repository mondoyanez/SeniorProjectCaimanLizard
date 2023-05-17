using OpenQA.Selenium;

namespace WatchParty_BDD_Tests.PageObjects;
public class EditWatchPartyPageObject : PageObject
{
    public EditWatchPartyPageObject(IWebDriver webDriver) : base(webDriver)
    {
        _pageName = "EditExistingWatchParty";
    }

    public IWebElement UnauthorizedHeaderElement => _webDriver.FindElement(By.ClassName("watch-party-edit-unauthorized-error"));
    public IWebElement UpdateButton => _webDriver.FindElement(By.Id("watch-party-submit-button"));

    public void UpdateGroup()
    {
        UpdateButton.Click();
    }

    public string UnauthorizedHeaderText()
    {
        return UnauthorizedHeaderElement.Text;
    }
}
