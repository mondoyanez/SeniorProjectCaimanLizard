using WatchParty_BDD_Tests.Drivers;
using WatchParty_BDD_Tests.PageObjects;
using WatchParty_BDD_Tests.Shared;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace WatchParty_BDD_Tests.StepDefinitions;

// Wrapper for the data we get for each user
public class TestUser
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
}

[Binding]
public class CreatePostsStepDefinitions
{

    // The context is shared between all step definition files.
    // This is where we put data that is shared between steps in different files.
    private readonly ScenarioContext _scenarioContext;
    private readonly LoginPageObject _loginPage;
    private readonly HomePageObject _homePage;
    private readonly CreatePostPageObject _createPostPage;
    private readonly NotificationPageObject _notificationPage;

    // So we can get user-secrets
    private IConfigurationRoot Configuration { get; }

    public CreatePostsStepDefinitions(ScenarioContext context, BrowserDriver browserDriver)
    {
        _loginPage = new LoginPageObject(browserDriver.Current);
        _homePage = new HomePageObject(browserDriver.Current);
        _createPostPage = new CreatePostPageObject(browserDriver.Current);
        _scenarioContext = context;
        _notificationPage = new NotificationPageObject(browserDriver.Current);

        // we need to keep the admin password secret
        IConfigurationBuilder builder = new ConfigurationBuilder().AddUserSecrets<CreatePostsStepDefinitions>();
        Configuration = builder.Build();
    }

    [Given(@"the following users exist")]
    public void GivenTheFollowingUsersExist(Table table)
    {
        // Nothing to do for this step other than to save the background data
        // that defines the users
        IEnumerable<TestUser> users = table.CreateSet<TestUser>();
        _scenarioContext["Users"] = users;
    }

    [Given(@"the following users do not exist")]
    public void GivenTheFollowingUsersDoNotExist(Table table)
    {
        // Same with this one, just setting up the background data
        IEnumerable<TestUser> nonUsers = table.CreateSet<TestUser>();
        _scenarioContext["NonUsers"] = nonUsers;
    }

    [Given(@"the users have a group set")]
    public void GivenTheUsersHaveAGroupSet()
    {
        // Go through each user and set a group for them
        IEnumerable<TestUser> users = (IEnumerable<TestUser>)_scenarioContext["Users"];
        foreach (TestUser user in users)
        {
            GivenIAmAUserWithFirstName(user.FirstName);
        }
    }

    [Given(@"I am a user with first name '([^']*)'")]
    public void GivenIAmAUserWithFirstName(string firstName)
    {
        // Find this user, first look in users, then in non-users
        IEnumerable<TestUser> users = (IEnumerable<TestUser>)_scenarioContext["Users"];
        TestUser u = users.Where(u => u.FirstName == firstName).FirstOrDefault();
        if (u == null)
        {
            // must have been selecting from non-users
            IEnumerable<TestUser> nonUsers = (IEnumerable<TestUser>)_scenarioContext["NonUsers"];
            u = nonUsers.Where(u => u.FirstName == firstName).FirstOrDefault();
        }
        _scenarioContext["CurrentUser"] = u;
    }

    [Given(@"I login"), When(@"I login")]
    public void WhenILogin()
    {
        // Go to the login page
        _loginPage.GoTo();
        //Thread.Sleep(3000);
        // Now (attempt to) log them in.  Assumes previous steps defined the user
        TestUser u = (TestUser)_scenarioContext["CurrentUser"];
        _loginPage.EnterUserName(u.UserName);
        _loginPage.EnterPassword(u.Password);
        _loginPage.Login();
    }

    [Given(@"I navigate to the ""([^""]*)"" page"), When(@"I navigate to the ""([^""]*)"" page")]
    public void WhenINavigateToThePage(string pageName)
    {
        _loginPage.GoTo(pageName);
    }

    [Given(@"I enter ""([^""]*)"" in the title input"), When(@"I enter ""([^""]*)"" in the title input")]
    public void WhenIEnterInTheTitleInput(string title)
    {
        _createPostPage.EnterTitle(title);
    }

    [Given(@"I leave the title input blank"), When(@"I leave the title input blank")]
    public void WhenILeaveTheTitleInputBlank()
    {
        _createPostPage.EnterBlankTitle();
    }


    [Given(@"I enter ""([^""]*)"" in the description input"), When(@"I enter ""([^""]*)"" in the description input")]
    public void WhenIEnterInTheDescriptionInput(string description)
    {
        _createPostPage.EnterDescription(description);
    }

    [Given(@"I leave the desciption input blank"), When(@"I leave the desciption input blank")]
    public void WhenILeaveTheDesciptionInputBlank()
    {
        _createPostPage.EnterBlankDescription();
    }


    [Given(@"I click the submit button"), When(@"I click the submit button")]
    public void WhenIClickTheSubmitButton()
    {
        _createPostPage.CreatePost();
    }


    [Then(@"The page title contains ""([^""]*)""")]
    public void ThenThePageTitleContains(string p0)
    {
        _createPostPage.GetTitle().Should().ContainEquivalentOf(p0, AtLeast.Once());
    }
}

