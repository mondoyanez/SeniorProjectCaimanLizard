using WatchParty.DAL.Abstract;
using WatchParty.DAL.Concrete;
using WatchParty.Models;

namespace WatchPartyTest;

/**
 * This is the recommended way to test using the in-memory db.  Seed the db and then write your tests based only on the seed
 * data + anything else you do to it.  No other tests will modify the db for that test.  Every test gets a brand new seeded db.
 * 
 */

public class CommentsRepository_Tests
{
    private static readonly string _seedFile = @"..\..\..\Data\commentRepositorySeed.sql";  // relative path of WatchPartyTest from where the executable is: bin/Debug/net7.0
    private static readonly string _seedFilePostEmpty = @"..\..\..\Data\commentRepositorySeedCommentsEmpty.sql";

    // Create this helper like this, for whatever context you desire
    private InMemoryDbHelper<WatchPartyDbContext> _dbHelper = new InMemoryDbHelper<WatchPartyDbContext>(_seedFile, DbPersistence.OneDbPerTest);
    private InMemoryDbHelper<WatchPartyDbContext> _dbHelperPostEmpty = new InMemoryDbHelper<WatchPartyDbContext>(_seedFilePostEmpty, DbPersistence.OneDbPerTest);

    [Test]
    public void GetAllComments_GetAllCommentsWithinEveryPost_ReturnsCommentsAscendingOrder()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        ICommentRepository repo = new CommentRepository(context);
        // The db has been seeded

        // Act
        IEnumerable<Comment> comments = repo.GetVisibleComments();

        int count = comments.Count();

        // Assert

        Assert.Multiple(() =>
        {
            Assert.That(count, Is.EqualTo(3));
            Assert.That(comments.First().Id, Is.EqualTo(1));
            Assert.That(comments.First().CommentTitle, Is.EqualTo("I also thought that Friends was a great show"));
            Assert.That(comments.First().DatePosted.ToString("yyyy-MM-dd hh:mm:ss"), Is.EqualTo("2023-04-02 01:25:00"));
            Assert.That(comments.First().UserId, Is.EqualTo(2));
            Assert.That(comments.First().User.Username, Is.EqualTo("CarsonDaniel"));
            Assert.That(comments.First().PostId, Is.EqualTo(3));
            Assert.That(comments.First().Post.PostTitle, Is.EqualTo("Friends"));
        });
    }

    [Test]
    public void GetComments_ForThirdPostWithThreeComments_ReturnsCommentsAscendingOrder()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        ICommentRepository repo = new CommentRepository(context);
        // The db has been seeded

        // Act
        IEnumerable<Comment> comments = repo.GetVisibleComments().Where(c => c.PostId == 3).ToList();

        int count = comments.Count();

        // Assert

        Assert.Multiple(() =>
        {
            Assert.That(count, Is.EqualTo(2));
            Assert.That(comments.First().Id, Is.EqualTo(1));
            Assert.That(comments.First().CommentTitle, Is.EqualTo("I also thought that Friends was a great show"));
            Assert.That(comments.First().DatePosted.ToString("yyyy-MM-dd hh:mm:ss"), Is.EqualTo("2023-04-02 01:25:00"));
            Assert.That(comments.First().UserId, Is.EqualTo(2));
            Assert.That(comments.First().User.Username, Is.EqualTo("CarsonDaniel"));
            Assert.That(comments.First().PostId, Is.EqualTo(3));
            Assert.That(comments.First().Post.PostTitle, Is.EqualTo("Friends"));
        });
    }

    [Test]
    public void GetComments_ForNotCommentsExisting_ShouldThrowException()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelperPostEmpty.GetContext();
        ICommentRepository repo = new CommentRepository(context);
        // The db has been seeded

        // Act/Assert
        Assert.Throws<Exception>(() => repo.GetVisibleComments());
    }

    [Test]
    public void AddComment_ForFourExistingComments_ShouldSuccessfullyAddComment()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        ICommentRepository repo = new CommentRepository(context);
        // The db has been seeded

        Comment comment = new Comment
        {
            CommentTitle = "The new spider-man movie was cool but I still preferred the original trilogy",
            DatePosted = new DateTime(2023, 4, 13, 18, 0, 0),
            IsVisible = true,
            UserId = 8,
            User = context.Watchers.FirstOrDefault(u => u.Id == 8),
            PostId = 2,
            Post = context.Posts.FirstOrDefault(p => p.Id == 2)
        };

        // Act
        repo.AddComment(comment);
        IEnumerable<Comment> comments = repo.GetVisibleComments();

        int totalCommentsCount = comments.Count();
        int secondPostCommentsCount = comments.Count(c => c.PostId == 2);
        int thirdPostCommentsCount = comments.Count(c => c.PostId == 3);

        // Assert
        Assert.That(totalCommentsCount, Is.EqualTo(4));
        Assert.That(thirdPostCommentsCount, Is.EqualTo(2));
        Assert.That(secondPostCommentsCount, Is.EqualTo(2));

        Assert.That(comments.First().Id, Is.EqualTo(1));
        Assert.That(comments.First().CommentTitle, Is.EqualTo("I also thought that Friends was a great show"));
        Assert.That(comments.First().DatePosted.ToString("yyyy-MM-dd hh:mm:ss"), Is.EqualTo("2023-04-02 01:25:00"));
        Assert.That(comments.First().UserId, Is.EqualTo(2));
        Assert.That(comments.First().User.Username, Is.EqualTo("CarsonDaniel"));
        Assert.That(comments.First().PostId, Is.EqualTo(3));
        Assert.That(comments.First().Post.PostTitle, Is.EqualTo("Friends"));

        Assert.That(comments.Last().Id, Is.EqualTo(5));
        Assert.That(comments.Last().CommentTitle, Is.EqualTo("The new spider-man movie was cool but I still preferred the original trilogy"));
        Assert.That(comments.Last().DatePosted.ToString("yyyy-MM-dd hh:mm:ss"), Is.EqualTo("2023-04-13 06:00:00"));
        Assert.That(comments.Last().UserId, Is.EqualTo(8));
        Assert.That(comments.Last().User.Username, Is.EqualTo("SofiaCarpenter"));
        Assert.That(comments.Last().PostId, Is.EqualTo(2));
        Assert.That(comments.Last().Post.PostTitle, Is.EqualTo("Spider-man"));
    }

    [Test]
    public void AddCommentMissingCommentTitleAsNull_ForFourExistingComments_ShouldThrowException()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        ICommentRepository repo = new CommentRepository(context);
        // The db has been seeded

        Comment comment = new Comment
        {
            CommentTitle = null!,
            DatePosted = new DateTime(2023, 4, 13, 18, 0, 0),
            UserId = 8,
            User = context.Watchers.FirstOrDefault(u => u.Id == 8),
            PostId = 2,
            Post = context.Posts.FirstOrDefault(p => p.Id == 2)
        };

        // Act/Assert
        Assert.Throws<Exception>(() => repo.AddComment(comment));
    }

    [Test]
    public void AddCommentThatIsNull_ForFourExistingComments_ShouldThrowException()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        ICommentRepository repo = new CommentRepository(context);
        // The db has been seeded

        Comment comment = null!;

        // Act/Assert
        Assert.Throws<ArgumentNullException>(() => repo.AddComment(comment));
    }
}