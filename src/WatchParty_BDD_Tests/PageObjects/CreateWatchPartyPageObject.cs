using OpenQA.Selenium;

namespace WatchParty_BDD_Tests.PageObjects;
public class CreateWatchPartyPageObject : PageObject
{
    public CreateWatchPartyPageObject(IWebDriver webDriver) : base(webDriver)
    {
        _pageName = "CreateWatchParty";
    }

    public IWebElement TitleInput => _webDriver.FindElement(By.ClassName("watch-party-title-input"));
    public IWebElement DescriptionInput => _webDriver.FindElement(By.ClassName("watch-party-description-input"));
    public IWebElement StartDateInput => _webDriver.FindElement(By.ClassName("watch-party-date-input"));
    public IWebElement SubmitButton => _webDriver.FindElement(By.Id("watch-party-submit-button"));

    public void EnterTitle(string title)
    {
        TitleInput.SendKeys(title);
    }

    public void EnterDescription(string description)
    {
        DescriptionInput.SendKeys(description);
    }

    public void EnterStartDate(string startDate)
    {
        StartDateInput.SendKeys(startDate);
    }

    public void CreateWatchParty()
    {
        SubmitButton.Click();
    }
}
