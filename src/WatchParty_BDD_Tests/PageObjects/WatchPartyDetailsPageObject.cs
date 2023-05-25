﻿using OpenQA.Selenium;

namespace WatchParty_BDD_Tests.PageObjects;
public class WatchPartyDetailsPageObject : PageObject
{
    public WatchPartyDetailsPageObject(IWebDriver webDriver) : base(webDriver)
    {
        _pageName = "ExistingWatchParty";
    }

    public IWebElement DetailsHeaderElement => _webDriver.FindElement(By.Id("watch-group-details-header"));
    public IWebElement GroupTitleElement => _webDriver.FindElement(By.Id("teleparty-title"));
    public IWebElement GroupDescriptionElement => _webDriver.FindElement(By.Id("teleparty-description"));
    public IWebElement GroupDateElement => _webDriver.FindElement(By.Id("teleparty-date"));
    public IWebElement TelePartyUrlElement => _webDriver.FindElement(By.Id("teleparty-url"));
    public IWebElement GroupOptionsButton => _webDriver.FindElement(By.Id("watch-group-options-btn"));
    public IWebElement EditGroupButton => _webDriver.FindElement(By.Id("watch-group-edit"));
    public IWebElement InviteUserButton => _webDriver.FindElement(By.Id("watch-group-invite"));
    public IWebElement RemoveUserButton => _webDriver.FindElement(By.Id("watch-group-remove"));
    public IWebElement ModalCloseButtonInvite => _webDriver.FindElement(By.Id("watch-group-modal-close-add"));
    public IWebElement ModalCloseButtonRemove => _webDriver.FindElement(By.Id("watch-group-modal-close-remove"));
    public IWebElement CurrentUser;

    public string DetailsHeaderElementText()
    {
        return DetailsHeaderElement.Text;
    }

    public string GroupTitleText()
    {
        return GroupTitleElement.Text;
    }

    public string GroupDescriptionText()
    {
        return GroupDescriptionElement.Text;
    }

    public string GroupDateText()
    {
        return GroupDateElement.Text;
    }

    public string TelePartyUrlText()
    {
        return TelePartyUrlElement.Text;
    }

    public void ExpandGroupGroupOptions()
    {
        GroupOptionsButton.Click();
    }

    public void SelectEditGroup()
    {
        EditGroupButton.Click();
    }

    public void SelectInviteUsers()
    {
        InviteUserButton.Click();
    }

    public void SelectRemoveUsers()
    {
        RemoveUserButton.Click();
    }

    public void CloseOpenModalInvite()
    {
        ModalCloseButtonInvite.Click();
    }

    public void CloseCloseModalRemove()
    {
        ModalCloseButtonRemove.Click();
    }

    public void InviteSelectedUser(string userName)
    {
        _webDriver.FindElement(By.Name(userName)).Click();
    }

    public void RemoveSelectedUser(string userName)
    {
        _webDriver.FindElement(By.Name(userName)).Click();
    }

    public void RefreshCurrentPage()
    {
        _webDriver.Navigate().Refresh();
    }

    public void UserInTable(string userName)
    {
        try
        {
            CurrentUser = _webDriver.FindElement(By.Id($"remove-user-{userName}"));
        }
        catch (NoSuchElementException)
        {
            CurrentUser = null;
        }
    }
}

