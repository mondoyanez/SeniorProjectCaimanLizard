using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WatchParty_BDD_Tests.PageObjects;
public class SearchPageObject: PageObject
{
    public SearchPageObject(IWebDriver webDriver) : base(webDriver)
    {
        _pageName = "Search";
    }

    public IWebElement watchListDropdown => _webDriver.FindElement(By.Id("watchlist-dropdown"));
    public IWebElement addtoCurrentlyWatchingButton => _webDriver.FindElement(By.Id("addToCurrent"));
    public IWebElement addtoHaveWatchedButton => _webDriver.FindElement(By.Id("addToHave"));



}