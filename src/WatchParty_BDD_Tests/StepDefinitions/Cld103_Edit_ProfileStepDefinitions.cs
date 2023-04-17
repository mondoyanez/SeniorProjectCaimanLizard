using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using WatchParty_BDD_Tests.Drivers;
using WatchParty_BDD_Tests.PageObjects;

namespace WatchParty_BDD_Tests.StepDefinitions
{
    [Binding]
    public class Cld103_Edit_ProfileStepDefinitions
    {
        // Wrapper for the data we get for each user
        public class TestUser
        {
            public string UserName { get; set; }
            public string Email { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Password { get; set; }
        }


        private readonly HomePageObject _homePage;
        private readonly LoginPageObject _loginPage;
        private readonly ScenarioContext _scenarioContext;

        public Cld103_Edit_ProfileStepDefinitions(ScenarioContext context, BrowserDriver browserDriver)
        {
            _homePage = new HomePageObject(browserDriver.Current);
            _loginPage = new LoginPageObject(browserDriver.Current);
            _scenarioContext = context;
        }

        [Given(@"I'm on the ""([^""]*)"" page")]
        public void GivenImOnThePage(string pageName)
        {
            
            _homePage.GoTo(pageName);
        }

        [Then(@"the page title contains ""([^""]*)""")]
        public void ThenThePageTitleContains(string p0)
        {
            _homePage.GetTitle().Should().ContainEquivalentOf(p0, AtLeast.Once());
        }

        [Then(@"I should see a link to the Register page")]
        public void ThenIShouldSeeALinkToTheRegisterPage()
        {
            _homePage.RegisterButton.Should().NotBeNull();
            _homePage.RegisterButton.Displayed.Should().BeTrue();
        }
        
        [Given(@"I login"), When(@"I login")]
        public void WhenILogin()
        {
            // Go to the login page
            _loginPage.GoTo();
            //Thread.Sleep(3000);
            // Now (attempt to) log them in.  Assumes previous steps defined the user
            TestUser u = (TestUser)_scenarioContext["CurrentUser"];
            //_loginPage.EnterUsername(u.UserName);
            _loginPage.EnterPassword(u.Password);
            _loginPage.Login();
        }

        [Then(@"I can see a link to the ""([^""]*)"" page")]
        public void ThenICanSeeALinkToThePage(string profile)
        {
            _homePage.ProfileButton.Should().NotBeNull();
            _homePage.ProfileButton.Displayed.Should().BeTrue();
        }

        [Given(@"the following users exist")]
        public void GivenTheFollowingUsersExist(Table table)
        {
            IEnumerable<TestUser> users = table.CreateSet<TestUser>();
            _scenarioContext["Users"] = users;
        }

        [Given(@"the following users do not exist")]
        public void GivenTheFollowingUsersDoNotExist(Table table)
        {
            IEnumerable<TestUser> nonUsers = table.CreateSet<TestUser>();
            _scenarioContext["NonUsers"] = nonUsers;
        }

        [Given(@"I am a visitor")]
        public void GivenIAmAVisitor()
        {
            // Should already be a visitor
        }

        [Then(@"I should see a login error message")]
        public void ThenIShouldSeeALoginErrorMessage()
        {
            _loginPage.HasLoginErrors().Should().BeTrue();
        }

        //[Given(@"I am a user with first name '([^']*)'"), When(@"I am a user with first name '([^']*)'")]
        //public void GivenIAmAUserWithFirstName(string firstName)
        //{
        //    // Find this user, first look in users, then in non-users
        //    IEnumerable<TestUser> users = (IEnumerable<TestUser>)_scenarioContext["Users"];
        //    TestUser u = users.Where(u => u.FirstName == firstName).FirstOrDefault();
        //    if (u == null)
        //    {
        //        // must have been selecting from non-users
        //        IEnumerable<TestUser> nonUsers = (IEnumerable<TestUser>)_scenarioContext["NonUsers"];
        //        u = nonUsers.Where(u => u.FirstName == firstName).FirstOrDefault();
        //    }
        //    _scenarioContext["CurrentUser"] = u;
        //}

        [Given(@"I am a user with first name ""([^""]*)""")]
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



    }
}
