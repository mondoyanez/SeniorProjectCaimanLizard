using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WatchParty_BDD_Tests.PageObjects;
public class CreatePostPageObject: PageObject
{
    public CreatePostPageObject(IWebDriver webDriver) : base(webDriver)
    {
        _pageName = "CreatePost";
    }

    public IWebElement PostTitleInput => _webDriver.FindElement(By.Id("post-title"));
    public IWebElement PostDescriptionInput => _webDriver.FindElement(By.Id("post-description"));
    public IWebElement SubmitButton => _webDriver.FindElement(By.Id("post-submit"));

    public void EnterTitle(string title)
    {
        PostTitleInput.Clear();
        PostTitleInput.SendKeys(title);
    }

    public void EnterBlankTitle()
    {
        PostTitleInput.Clear();
    }

    public void EnterDescription(string description)
    {
        PostDescriptionInput.Clear();
        PostDescriptionInput.SendKeys(description);
    }

    public void EnterBlankDescription()
    {
        PostDescriptionInput.Clear();
    }

    public void CreatePost()
    {
        SubmitButton.Click();
    }
}