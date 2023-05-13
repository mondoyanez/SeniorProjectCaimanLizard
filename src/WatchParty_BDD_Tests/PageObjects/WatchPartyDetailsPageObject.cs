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
    public IWebElement ModalCloseButton => _webDriver.FindElement(By.Id("watch-group-modal-close"));
    public IWebElement CurrentUser;

    public void ExpandGroupGroupOptions()
    {
        GroupOptionsButton.Click();
    }

    public void SelectInviteUsers()
    {
        InviteUserButton.Click();
    }

    public void CloseOpenModal()
    {
        ModalCloseButton.Click();
    }

    public void InviteSelectedUser(string userName)
    {
        _webDriver.FindElement(By.Name(userName)).Click();
    }

    public void RefreshCurrentPage()
    {
        _webDriver.Navigate().Refresh();
    }

    public void UserInTable(string userName)
    {
        CurrentUser = _webDriver.FindElement(By.Id($"remove-user-{userName}"));
    }
}

