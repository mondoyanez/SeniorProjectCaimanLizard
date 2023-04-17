using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V109.Profiler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchParty_BDD_Tests.PageObjects
{
    public class ProfilePageObject : PageObject
    {
        public ProfilePageObject(IWebDriver webDriver) : base(webDriver)
        {
            _pageName = "Profile";
        }

        
    }
}