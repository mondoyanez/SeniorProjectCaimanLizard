using WatchParty.DAL.Abstract;
using WatchParty.DAL.Concrete;
using WatchParty.Models;

namespace WatchPartyTest;
public class FollowingListRepository_Tests
{
    private static readonly string _seedFile = @"..\..\..\Data\followingListRepositorySeed.sql";
    private InMemoryDbHelper<WatchPartyDbContext> _dbHelper = new InMemoryDbHelper<WatchPartyDbContext>(_seedFile, DbPersistence.OneDbPerTest);

    [Test]
    public void GetFollowingList_ForUserWhoIsFollowingNinePeople_ShouldReturnNine()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IFollowingListRepository repo = new FollowingListRepository(context);
        
        // Act
        List<FollowingList> follows = repo.GetFollowingList(1);
        int count = follows.Count;

        // Assert
        Assert.That(count, Is.EqualTo(9));
    }

    [Test]
    public void GetFollowingList_ForUserWhoIsFollowingIsNotFollowingAnybody_ShouldReturnZero()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IFollowingListRepository repo = new FollowingListRepository(context);

        // Act
        List<FollowingList> follows = repo.GetFollowingList(10);
        int count = follows.Count;

        // Assert
        Assert.That(count, Is.EqualTo(0));
    }

    [Test]
    public void GetFollowerList_ForUserWhoHasNoFollowers_ShouldReturnZero()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IFollowingListRepository repo = new FollowingListRepository(context);

        // Act
        List<FollowingList> followers = repo.GetFollowerList(1);
        int count = followers.Count;

        // Assert
        Assert.That(count, Is.EqualTo(2));
    }

    [Test]
    public void GetFollowerList_ForUserWhoHasTwoFollowers_ShouldReturnTwo()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IFollowingListRepository repo = new FollowingListRepository(context);

        // Act
        List<FollowingList> followers = repo.GetFollowerList(11);
        int count = followers.Count;

        // Assert
        Assert.That(count, Is.EqualTo(0));
    }

    [Test]
    public void IsFollowing_ForUserWhoIsFollowingTheOtherUser_ShouldReturnTrue()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IFollowingListRepository repo = new FollowingListRepository(context);

        // Act
        bool isFollowing = repo.IsFollowing(1, 5);

        // Assert
        Assert.That(isFollowing, Is.True);
    }

    [Test]
    public void IsFollowing_ForUserWhoIsNotFollowingTheOtherUser_ShouldReturnFalse()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IFollowingListRepository repo = new FollowingListRepository(context);

        // Act
        bool isFollowing = repo.IsFollowing(10, 5);

        // Assert
        Assert.That(isFollowing, Is.False);
    }

    [Test]
    public void IsFollowing_ForUserWhoIsNotFollowingThemselves_ShouldReturnFalse()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IFollowingListRepository repo = new FollowingListRepository(context);

        // Act
        bool isFollowing = repo.IsFollowing(1, 1);

        // Assert
        Assert.That(isFollowing, Is.False);
    }

    [Test]
    public void AddFollower_ForUserWhoIsNotFollowingTheOtherUser_ShouldSuccessfullyAddTheUserAndUpdateNumberOfFollowingForUserAndNumberOfFollowersForTheUserFollowed()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IFollowingListRepository repo = new FollowingListRepository(context);

        FollowingList newFollow = new FollowingList
        {
            UserId = 10,
            FollowingId = 1,
            Following = context.Watchers.First(w => w.Id == 1),
            User = context.Watchers.First(w => w.Id == 10)
        };

        // Act
        repo.AddFollower(newFollow);

        List<FollowingList> followingList = repo.GetFollowingList(10);
        List<FollowingList> followerList = repo.GetFollowerList(1);

        int numFollowing = followingList.Count;
        int numFollowers = followerList.Count;

        bool isFollowing = repo.IsFollowing(10, 1);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(isFollowing, Is.True);
            Assert.That(numFollowing, Is.EqualTo(1));
            Assert.That(numFollowers, Is.EqualTo(3));
        });
    }

    [Test]
    public void AddFollower_ForUserWhoIsAlreadyFollowingUser_ShouldThrowException()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IFollowingListRepository repo = new FollowingListRepository(context);

        FollowingList newFollow = new FollowingList
        {
            UserId = 1,
            FollowingId = 10,
            Following = context.Watchers.First(w => w.Id == 10),
            User = context.Watchers.First(w => w.Id == 1)
        };

        // Act/Assert
        Assert.Throws<Exception>(() => repo.AddFollower(newFollow));
    }

    [Test]
    public void AddFollower_ForUserWhoIsTryingToFollowThemselves_ShouldThrowException()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IFollowingListRepository repo = new FollowingListRepository(context);

        FollowingList newFollow = new FollowingList
        {
            UserId = 7,
            FollowingId = 7,
            Following = context.Watchers.First(w => w.Id == 7),
            User = context.Watchers.First(w => w.Id == 7)
        };

        // Act/Assert
        Assert.Throws<Exception>(() => repo.AddFollower(newFollow));
    }

    [Test]
    public void AddFollower_ForFollowListThatIsMissingFollowerInfo_ShouldThrowException()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IFollowingListRepository repo = new FollowingListRepository(context);

        FollowingList newFollow = new FollowingList
        {
            UserId = 1,
            User = context.Watchers.First(w => w.Id == 1)
        };

        // Act/Assert
        Assert.Throws<Exception>(() => repo.AddFollower(newFollow));
    }

    [Test]
    public void GetFollowerById_ForUserWhoIsFollowingTheOtherUser_ShouldReturnCorrectFollowingList()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IFollowingListRepository repo = new FollowingListRepository(context);

        // Act
        FollowingList? follow = repo.GetFollowerById(1, 2);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(follow.Id, Is.EqualTo(1));
            Assert.That(follow.UserId, Is.EqualTo(1));
            Assert.That(follow.User.Username, Is.EqualTo("SandraHart"));
            Assert.That(follow.FollowingId, Is.EqualTo(2));
            Assert.That(follow.Following.Username, Is.EqualTo("CarsonDaniel"));
        });
    }

    [Test]
    public void GetFollowerById_ForUserWhoIsNotFollowingTheOtherUser_ShouldReturnNull()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IFollowingListRepository repo = new FollowingListRepository(context);

        // Act
        FollowingList? follow = repo.GetFollowerById(10, 2);

        // Assert
        Assert.That(follow, Is.Null);
    }

    [Test]
    public void GetFollowerById_ForUserWhoIsNotFollowingThemselves_ShouldReturnNull()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IFollowingListRepository repo = new FollowingListRepository(context);

        // Act
        FollowingList? follow = repo.GetFollowerById(1, 1);

        // Assert
        Assert.That(follow, Is.Null);
    }

    [Test]
    public void RemoveFollower_ForUserWhoIsFollowingTheOtherUser_ShouldSuccessfullyUnfollowUser()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IFollowingListRepository repo = new FollowingListRepository(context);

        // Act
        FollowingList? follow = repo.GetFollowerById(1, 2);
        repo.RemoveFollower(follow);
        follow = repo.GetFollowerById(1, 2);

        // Assert
        Assert.That(follow, Is.Null);
    }

    [Test]
    public void RemoveFollower_ForUserWhoIsNotFollowingTheOtherUser_ShouldThrowException()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IFollowingListRepository repo = new FollowingListRepository(context);

        // Act/Assert
        FollowingList? follow = repo.GetFollowerById(1, 2);
        repo.RemoveFollower(follow);
        Assert.Throws<Exception>(() => repo.RemoveFollower(follow));
    }

    [Test]
    public void RemoveFollower_ForMissingDateInFollowingList_ShouldThrowException()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IFollowingListRepository repo = new FollowingListRepository(context);

        FollowingList newFollow = new FollowingList
        {
            UserId = 1,
            User = context.Watchers.First(w => w.Id == 1)
        };

        // Act/Assert
        Assert.Throws<Exception>(() => repo.RemoveFollower(newFollow));
    }
}