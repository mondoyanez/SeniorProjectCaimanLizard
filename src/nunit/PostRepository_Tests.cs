using WatchParty.DAL.Abstract;
using WatchParty.DAL.Concrete;
using WatchParty.Models;

namespace WatchPartyTest;

/**
 * This is the recommended way to test using the in-memory db.  Seed the db and then write your tests based only on the seed
 * data + anything else you do to it.  No other tests will modify the db for that test.  Every test gets a brand new seeded db.
 * 
 */

public class PostRepository_Tests
{
    private static readonly string _seedFile = @"..\..\..\Data\postRepositorySeed.sql";  // relative path of WatchPartyTest from where the executable is: bin/Debug/net7.0

    // Create this helper like this, for whatever context you desire
    private InMemoryDbHelper<WatchPartyDbContext> _dbHelper = new InMemoryDbHelper<WatchPartyDbContext>(_seedFile, DbPersistence.OneDbPerTest);

    [Test]
    public void OrderedByDescending_ForPostsWithTenPosts_ReturnsListInDescendingOrder()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IPostRepository repo = new PostRepository(context);
        // The db has been seeded

        // Act
        var posts = repo.GetAllPostsDescending();

        int count = posts.Count();

        var title = posts.FirstOrDefault().PostTitle;
        string? description = posts.FirstOrDefault()?.PostDescription;
        var date = posts.FirstOrDefault().DatePosted.ToString("yyyy-MM-dd hh:mm:ss");
        var id = posts.FirstOrDefault().UserId;
        //var username = posts.FirstOrDefault().User.Username;
        

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(count, Is.EqualTo(10));
            Assert.That(title, Is.EqualTo("Friends"));
            Assert.That(description, Is.EqualTo("By far one of my favorite shows"));
            Assert.That(date, Is.EqualTo("2023-02-08 08:00:00"));
            Assert.That(id, Is.EqualTo(5));
            //Assert.That(username, Is.EqualTo("GabrielGrant"));
        });
    }

    [Test]
    public void OrderedByDescending_ForPostsWithTenPosts_DoesNotReturnListInDescendingOrder()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IPostRepository repo = new PostRepository(context);
        // The db has been seeded

        // Act
        var posts = repo.GetAll();

        int count = posts.Count();

        var title = posts.FirstOrDefault().PostTitle;
        string? description = posts.FirstOrDefault()?.PostDescription;
        var date = posts.FirstOrDefault().DatePosted.ToString("yyyy-MM-dd hh:mm:ss");
        var id = posts.FirstOrDefault().UserId;
        //var username = posts.FirstOrDefault().User.Username;


        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(count, Is.EqualTo(10));
            Assert.That(title, Is.Not.EqualTo("Friends"));
            Assert.That(description, Is.Not.EqualTo("By far one of my favorite shows"));
            Assert.That(date, Is.Not.EqualTo("2023-02-08 08:00:00"));
            Assert.That(id, Is.Not.EqualTo(5));
            //Assert.That(username, Is.EqualTo("GabrielGrant"));
        });
    }
}

