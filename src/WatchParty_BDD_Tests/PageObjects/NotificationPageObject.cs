using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WatchParty_BDD_Tests.PageObjects;
public class NotificationPageObject: PageObject
{
    public NotificationPageObject(IWebDriver webDriver) : base(webDriver)
    {
        _pageName = "Notification";
    }

    public IWebElement DeleteButton => _webDriver.FindElement(By.Id("delete-notification"));
    public IWebElement NoNotifications => _webDriver.FindElement(By.Id("no-notifications"));
    
}