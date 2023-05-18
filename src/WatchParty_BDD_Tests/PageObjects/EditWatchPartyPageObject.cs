using OpenQA.Selenium;

namespace WatchParty_BDD_Tests.PageObjects;
public class EditWatchPartyPageObject : PageObject
{
    public EditWatchPartyPageObject(IWebDriver webDriver) : base(webDriver)
    {
        _pageName = "EditExistingWatchParty";
    }

    public IWebElement UnauthorizedHeaderElement => _webDriver.FindElement(By.ClassName("watch-party-edit-unauthorized-error"));
    public IWebElement TitleInput => _webDriver.FindElement(By.ClassName("watch-party-title-input"));
    public IWebElement DescriptionInput => _webDriver.FindElement(By.ClassName("watch-party-description-input"));
    public IWebElement StartDateInput => _webDriver.FindElement(By.ClassName("watch-party-date-input"));
    public IWebElement TelePartyUrlInput => _webDriver.FindElement(By.ClassName("watch-party-url-input"));
    public IWebElement UpdateButton => _webDriver.FindElement(By.Id("watch-party-submit-button"));

    public void EnterTitle(string title)
    {
        TitleInput.Clear();
        TitleInput.SendKeys(title);
    }

    public void EnterDescription(string description)
    {
        DescriptionInput.Clear();
        DescriptionInput.SendKeys(description);
    }

    public void EnterStartDate(string date, string time)
    {
        StartDateInput.Clear();
        StartDateInput.SendKeys(date);
        StartDateInput.SendKeys(Keys.Tab);
        StartDateInput.SendKeys(time);
    }

    public void EnterTelePartyUrl(string url)
    {
        TelePartyUrlInput.Clear();
        TelePartyUrlInput.SendKeys(url);
    }

    public void UpdateGroup()
    {
        UpdateButton.Click();
    }

    public string UnauthorizedHeaderText()
    {
        return UnauthorizedHeaderElement.Text;
    }
}
