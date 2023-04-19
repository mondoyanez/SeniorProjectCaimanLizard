using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchParty_BDD_Tests.PageObjects
{
    public class LoginPageObject : PageObject
    {
        public LoginPageObject(IWebDriver webDriver) : base(webDriver)
        {
            _pageName = "Login";
        }

        public IWebElement UserNameInput => _webDriver.FindElement(By.Id("Input_UserName"));
        public IWebElement PasswordInput => _webDriver.FindElement(By.Id("Input_Password"));
        public IWebElement RememberMeCheck => _webDriver.FindElement(By.Id("Input_RememberMe"));
        public IWebElement SubmitButton => _webDriver.FindElement(By.Id("login-submit"));

        public void EnterUserName(string username)
        {
            UserNameInput.Clear();
            UserNameInput.SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            PasswordInput.Clear();
            PasswordInput.SendKeys(password);
        }

        public void SetRememberMe(bool rememberMe)
        {
            if(rememberMe)
            {
                if(!RememberMeCheck.Selected)
                {
                    RememberMeCheck.Click();
                }
            }
            else
            {
                if(RememberMeCheck.Selected)
                {
                    RememberMeCheck.Click();
                }
            }
        }

        public void Login()
        {
            SubmitButton.Click();
        }

        public bool HasLoginErrors()
        {
           ReadOnlyCollection<IWebElement> elements = _webDriver.FindElements(By.CssSelector(".validation-summary-errors"));
           return elements.Count() > 0;
        }
    }
}
