using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WatchParty_BDD_Tests.PageObjects;
public class WatchListPageObject: PageObject
{
    public WatchListPageObject(IWebDriver webDriver) : base(webDriver)
    {
        _pageName = "WatchList";
    }

    public IWebElement navWatchListButton => _webDriver.FindElement(By.Id("nav-watchlist"));
    public IWebElement haveListDropdownButton => _webDriver.FindElement(By.Id("dropdown-have"));
    public IWebElement changeWatchList => _webDriver.FindElement(By.Id("dropdown-change-list"));

    public IWebElement haveWatchedList => _webDriver.FindElement(By.Id("haveWatchedList"));
    public IWebElement showTitle => _webDriver.FindElement(By.Id("show-title"));



}