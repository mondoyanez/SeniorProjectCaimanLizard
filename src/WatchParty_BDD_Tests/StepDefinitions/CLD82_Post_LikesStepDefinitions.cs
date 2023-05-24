using System;
using NUnit.Framework;
using TechTalk.SpecFlow;
using WatchParty_BDD_Tests.Drivers;
using WatchParty_BDD_Tests.PageObjects;

namespace WatchParty_BDD_Tests.StepDefinitions
{
    [Binding]
    public class CLD82_Post_LikesStepDefinitions
    {
        private readonly PostIndexPageObject _postIndexPageObject;
        private readonly ScenarioContext _scenarioContext;

        public CLD82_Post_LikesStepDefinitions(BrowserDriver browserDriver, ScenarioContext context)
        {
            _postIndexPageObject = new PostIndexPageObject(browserDriver.Current);
            _scenarioContext = context;
        }

        [Given(@"I like a post"), When(@"I like a post")]
        public void GivenILikeAPost()
        {
            _scenarioContext["FirstNotLikedPostID"] = _postIndexPageObject.FirstNotLikePostID;
            _scenarioContext["PostLikesBefore"] = _postIndexPageObject.GetPostLikes(_scenarioContext["FirstNotLikedPostID"].ToString());
            _postIndexPageObject.LikeAPost();
            _scenarioContext["PostLikesAfter"] = _postIndexPageObject.GetPostLikes(_scenarioContext["FirstNotLikedPostID"].ToString());
        }

        [When(@"I try to like the same post again")]
        public void WhenITryToLikeTheSamePostAgain()
        {
            _postIndexPageObject.LikeSpecificPost(_scenarioContext["FirstNotLikedPostID"].ToString());
        }

        [Then(@"the post is unliked")]
        public void ThenThePostIsUnliked()
        {
            Assert.False(_postIndexPageObject.IsPostLiked(_scenarioContext["FirstNotLikedPostID"].ToString()));
        }

        [Then(@"I can see its post likes increase by one")]
        public void ThenICanSeeItsPostLikesIncreaseByOne()
        {
            int postLikesBefore = Convert.ToInt32(_scenarioContext["PostLikesBefore"]);
            int postLikesAfter = Convert.ToInt32(_scenarioContext["PostLikesAfter"]);
            Assert.That(postLikesBefore + 1 == postLikesAfter);
        }

        [Then(@"I can see the post is liked")]
        public void ThenICanSeeThePostIsLiked()
        {
            Assert.That(_postIndexPageObject.IsPostLiked(_scenarioContext["FirstNotLikedPostID"].ToString()));
        }
    }
}
