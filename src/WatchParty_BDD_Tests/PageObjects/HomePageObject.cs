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

        public IWebElement RegisterButton => _webDriver.FindElement(By.Id("register-link"));
        public IWebElement NavBarHelloLink => _webDriver.FindElement(By.CssSelector("a[href=\"/Identity/Account/Manage\"]"));
        private ReadOnlyCollection<IWebElement> Questions => _webDriver.FindElements(By.CssSelector("li.question a"));

        public string NavbarWelcomeText()
        {
            return NavBarHelloLink.Text;
        }

        public void Logout()
        {
            IWebElement navbarLogoutButton = _webDriver.FindElement(By.Id("logout-button"));
            navbarLogoutButton.Click();
        }

        public bool HasQuestionText(string text)
        {
            // Look through all the questions and see if text is present
            return Questions.Any(q => q.Text.Contains(text));
        }
    }
}