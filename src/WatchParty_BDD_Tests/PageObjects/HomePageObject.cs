using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WatchParty_BDD_Tests.Shared;
using System.Collections.ObjectModel;

namespace WatchParty_BDD_Tests.PageObjects
{
    public class HomePageObject : PageObject
    {
        public HomePageObject(IWebDriver webDriver) : base(webDriver)
        {
            // using a named page (in Common.cs)
            _pageName = "Home";
        }

        public IWebElement ProfileButton => _webDriver.FindElement(By.Id("profile-link"));
        public IWebElement SearchBar => _webDriver.FindElement(By.Id("search-form"));
        public IWebElement RegisterButton => _webDriver.FindElement(By.CssSelector("a[href=\"/Identity/Account/Register\"]"));
        public IWebElement LoginButton => _webDriver.FindElement(By.CssSelector("a[href=\"/Identity/Account/Login\"]"));
        public IWebElement NavBarHelloLink => _webDriver.FindElement(By.CssSelector("a[href=\"/Identity/Account/Manage\"]"));
        public IWebElement NotificationButton => _webDriver.FindElement(By.Id("notification-bell"));


        public string NavbarWelcomeText()
        {
            return NavBarHelloLink.Text;
        }

        public void Logout()
        {
            IWebElement profileDropdown = _webDriver.FindElement(By.Id("profileDropdown"));
            profileDropdown.Click();

            IWebElement navbarLogoutButton = _webDriver.FindElement(By.Id("logout-button"));
            navbarLogoutButton.Click();
        }
    }
}
