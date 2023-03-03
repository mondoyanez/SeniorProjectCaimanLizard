
using Microsoft.EntityFrameworkCore.Internal;
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
    private static readonly string _seedFilePostEmpty = @"..\..\..\Data\postRepositorySeedPostsEmpty.sql";

    // Create this helper like this, for whatever context you desire
    private InMemoryDbHelper<WatchPartyDbContext> _dbHelper = new InMemoryDbHelper<WatchPartyDbContext>(_seedFile, DbPersistence.OneDbPerTest);
    private InMemoryDbHelper<WatchPartyDbContext> _dbHelperPostEmpty = new InMemoryDbHelper<WatchPartyDbContext>(_seedFilePostEmpty, DbPersistence.OneDbPerTest);

    [Test]
    public void OrderedByDescending_ForPostsWithTenPosts_ReturnsListInDescendingOrder()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IPostRepository repo = new PostRepository(context);
        // The db has been seeded

        // Act
        IEnumerable<Post> posts = repo.GetAllPostsDescending();

        int count = posts.Count();

        string? title = posts.FirstOrDefault().PostTitle;
        string? description = posts.FirstOrDefault()?.PostDescription;
        string? date = posts.FirstOrDefault().DatePosted.ToString("yyyy-MM-dd hh:mm:ss");
        int? id = posts.FirstOrDefault().UserId;
        string? username = posts.FirstOrDefault().User.Username;
        

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(count, Is.EqualTo(10));
            Assert.That(title, Is.EqualTo("Friends"));
            Assert.That(description, Is.EqualTo("By far one of my favorite shows"));
            Assert.That(date, Is.EqualTo("2023-02-08 08:00:00"));
            Assert.That(id, Is.EqualTo(5));
            Assert.That(username, Is.EqualTo("GabrielGrant"));
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
        IEnumerable<Post> posts = repo.GetAll();

        int count = posts.Count();

        string? title = posts.FirstOrDefault().PostTitle;
        string? description = posts.FirstOrDefault()?.PostDescription;
        string? date = posts.FirstOrDefault().DatePosted.ToString("yyyy-MM-dd hh:mm:ss");
        int? id = posts.FirstOrDefault().UserId;
        string? username = posts.FirstOrDefault().User.Username;


        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(count, Is.EqualTo(10));
            Assert.That(title, Is.Not.EqualTo("Friends"));
            Assert.That(description, Is.Not.EqualTo("By far one of my favorite shows"));
            Assert.That(date, Is.Not.EqualTo("2023-02-08 08:00:00"));
            Assert.That(id, Is.Not.EqualTo(5));
            Assert.That(username, Is.Not.EqualTo("GabrielGrant"));
        });
    }

    [Test]
    public void OrderedByDescending_NoPostsInDatabase_ThrowsException()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelperPostEmpty.GetContext();
        IPostRepository repo = new PostRepository(context);
        // The db has been seeded

        // Act
        Assert.Throws<Exception>(() => repo.GetAllPostsDescending());
    }


    [Test]
    public void AddNewPostWithAllInformationEntered_ForPostsWithTenPosts_SuccessfullyCreatesPostsUpdatesDatabaseAndDatePostedIsString()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IPostRepository repo = new PostRepository(context);
        // The db has been seeded

        Post post = new Post
        {
            PostTitle = "My very first post!",
            PostDescription = "Enter a description",
            DatePosted = new DateTime(2023, 3, 1, 17, 25, 45),
            UserId = 10,
            User = context.Watchers.First(w => w.Id == 10)
        };

        // Act
        repo.AddPost(post);
        IEnumerable<Post> posts = repo.GetAllPostsDescending();

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(posts.Count(), Is.EqualTo(11));

            Assert.That(posts?.FirstOrDefault()?.PostTitle, Is.EqualTo(post.PostTitle));
            Assert.That(posts?.FirstOrDefault()?.PostDescription, Is.EqualTo(post.PostDescription));
            Assert.That(posts?.FirstOrDefault()?.DatePosted.ToString("yyyy-MM-dd hh:mm:ss"), Is.EqualTo("2023-03-01 05:25:45"));
            Assert.That(posts?.FirstOrDefault()?.UserId, Is.EqualTo(post.UserId));
            Assert.That(posts?.FirstOrDefault()?.User.Username, Is.EqualTo(post.User.Username));

            Assert.That(posts?.LastOrDefault()?.PostTitle, Is.EqualTo("Best comedy of 2023?"));
            Assert.That(posts?.LastOrDefault()?.PostDescription, Is.Null);
            Assert.That(posts?.LastOrDefault()?.DatePosted.ToString("yyyy-MM-dd hh:mm:ss"), Is.EqualTo("2022-12-25 12:00:00"));
            Assert.That(posts?.LastOrDefault()?.UserId, Is.EqualTo(7));
            Assert.That(posts?.LastOrDefault()?.User.Username, Is.EqualTo("JudsonCooke"));
        });
    }

    [Test]
    public void AddNewPostWithMissingDescription_ForPostsWithTenPosts_SuccessfullyCreatesPostsUpdatesDatabaseAndDatePostedIsDateTime()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IPostRepository repo = new PostRepository(context);
        // The db has been seeded

        Post post = new Post
        {
            PostTitle = "My very first post!",
            PostDescription = null!,
            DatePosted = new DateTime(2023, 3, 1, 17, 25, 45),
            UserId = 10,
            User = context.Watchers.First(w => w.Id == 10)
        };

        // Act
        repo.AddPost(post);
        IEnumerable<Post> posts = repo.GetAllPostsDescending();

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(posts.Count(), Is.EqualTo(11));

            Assert.That(posts?.FirstOrDefault()?.PostTitle, Is.EqualTo(post.PostTitle));
            Assert.That(posts?.FirstOrDefault()?.PostDescription, Is.Null);
            Assert.That(posts?.FirstOrDefault()?.DatePosted, Is.EqualTo(post.DatePosted));
            Assert.That(posts?.FirstOrDefault()?.UserId, Is.EqualTo(post.UserId));
            Assert.That(posts?.FirstOrDefault()?.User.Username, Is.EqualTo(post.User.Username));

            Assert.That(posts?.LastOrDefault()?.PostTitle, Is.EqualTo("Best comedy of 2023?"));
            Assert.That(posts?.LastOrDefault()?.PostDescription, Is.Null);
            Assert.That(posts?.LastOrDefault()?.DatePosted, Is.EqualTo(new DateTime(2022, 12, 25, 12, 0, 0)));
            Assert.That(posts?.LastOrDefault()?.UserId, Is.EqualTo(7));
            Assert.That(posts?.LastOrDefault()?.User.Username, Is.EqualTo("JudsonCooke"));
        });
    }

    [Test]
    public void AddNewPostWithMissingTitleAndUserExists_ForPostsWithTenPosts_ThrowsException()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IPostRepository repo = new PostRepository(context);
        // The db has been seeded

        Post post = new Post
        {
            PostTitle = null!,
            PostDescription = "Oops forgot to include title should get an exception though",
            DatePosted = new DateTime(2023, 3, 1, 17, 25, 45),
            UserId = 7,
            User = context.Watchers.First(w => w.Id == 7)
        };

        // Act/Assert
        Assert.Throws<Exception>(() => repo.AddPost(post));
    }

    [Test]
    public void AddNewPostWithValidInformationButUserDoesNotExist_ForPostsWithTenPosts_ThrowsException()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IPostRepository repo = new PostRepository(context);
        // The db has been seeded

        Watcher watcher = new Watcher
        {
            Id = 11,
            AspNetIdentityId = "b2f96999-701e-4ad6-8ab7-e0825b49387c",
            Username = "OthoT",
            FirstName = "Tisha",
            LastName = "Otho",
            Email = "TishaOtho@gmail.com",
            FollowingCount = 500,
            FollowerCount = 10,
            Bio = "This bio contains information about myself"
        };

        Post post = new Post
        {
            PostTitle = "That was an amazing movie",
            PostDescription = "So that new movie was amazing so lets talk about it",
            DatePosted = new DateTime(2023, 3, 1, 17, 25, 45),
            UserId = 11,
            User = watcher
        };

        // Act/Assert
        Assert.Throws<Exception>(() => repo.AddPost(post));
    }

    [Test]
    public void AddNewPostIsNull_ForPostsWithTenPosts_ThrowsNullReferenceException()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IPostRepository repo = new PostRepository(context);
        // The db has been seeded

        // Act/Assert
        Assert.Throws<ArgumentNullException>(() => repo.AddPost(null!));
    }
}