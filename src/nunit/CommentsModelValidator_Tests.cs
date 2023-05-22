using WatchParty.Models;

namespace WatchPartyTest;
public class CommentsModelValidator_Tests
{
    private Comment MakeValidComment()
    {
        Watcher poster = new Watcher
        {
            Id = 1,
            AspNetIdentityId = "b2f96999-701e-4ad6-8ab7-e0825b49387c",
            Username = "Ja",
            FirstName = "Ja",
            LastName = "Morrant",
            Email = "MorrantJa@gmail.com",
            Bio = "This is my bio"
        };

        Watcher commenter = new Watcher
        {
            Id = 2,
            AspNetIdentityId = "d5f96973-601e-4ac6-8cb7-k0825b49387r",
            Username = "ShannenBrion",
            FirstName = "Brion",
            LastName = "Shannen",
            Email = "ShannenBrion@gmail.com",
            Bio = "Comedy's are my favorite genre"
        };

        Post post = new Post
        {
            Id = 1,
            PostTitle = "My very first post!",
            PostDescription = "Enter a description",
            DatePosted = new DateTime(2023, 2, 28, 15, 0, 0),
            IsVisible = true,
            UserId = 1,
            User = poster
        };

        Comment comment = new Comment
        {
            Id = 1,
            CommentTitle = "This text contains a comment",
            DatePosted = new DateTime(2023, 2, 28, 15, 10, 20),
            IsVisible = true,
            UserId = 2,
            PostId = 1,
            Post = post,
            User = commenter
        };

        return comment;
    }

    [Test]
    public void ValidComment_IsValid()
    {
        // Arrange
        Comment comment = MakeValidComment();

        //Act
        ModelValidator mv = new ModelValidator(comment);

        // Assert
        Assert.That(mv.Valid, Is.True);
    }

    [Test]
    public void Comment_WithValidId_IsCorrect()
    {
        // Arrange
        Comment comment = MakeValidComment();

        // Act
        ModelValidator mv = new ModelValidator(comment);
        int actual = comment.Id;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("Id"), Is.False);
            Assert.That(actual, Is.EqualTo(1));
        });
    }

    [Test]
    public void Comment_WithValidTitle_IsCorrect()
    {
        // Arrange
        Comment comment = MakeValidComment();

        // Act
        ModelValidator mv = new ModelValidator(comment);
        string actual = comment.CommentTitle;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("CommentTitle"), Is.False);
            Assert.That(actual, Is.EqualTo("This text contains a comment"));
        });
    }

    [Test]
    public void Comment_WithTitleExceedingLength_IsNotValid()
    {
        // Arrange
        Comment comment = MakeValidComment();
        comment.CommentTitle =
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla facilisi. Fusce blandit ligula ut neque ultricies convallis. " +
            "Pellentesque in ipsum eget metus venenatis vestibulum. Morbi ut velit sed nibh pharetra bibendum eget ac augue. Praesent suscipit " +
            "elit eu arcu consectetur rhoncus. Curabitur feugiat dolor eu tellus euismod, eget lobortis leo bibendum. Suspendisse euismod neque eget " +
            "metus dapibus, eget bibendum libero elementum. Donec pulvinar velit eget mi lobortis, a luctus turpis sollicitudin. Vivamus mollis felis " +
            "id est congue faucibus. Sed sit amet blandit ipsum. Etiam sagittis, turpis at fringilla consectetur, ipsum augue auctor tellus, non " +
            "imperdiet sapien magna in mauris. Aenean euismod ante enim, at volutpat libero dictum ac. Vestibulum bibendum eros ac tristique finibus. " +
            "Proin auctor feugiat metus, eu aliquam felis. Integer ac turpis vel elit pellentesque rhoncus. Vestibulum vel accumsan ex. Vestibulum " +
            "ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis laoreet odio eget dui malesuada, auctor bibendum nisl " +
            "maximus. Sed hendrerit odio non massa sagittis, euismod suscipit augue ullamcorper. Vestibulum lacinia nulla nulla, ut euismod velit " +
            "viverra non. Donec bibendum quam at ligula gravida, ut scelerisque mi posuere. Fusce luctus posuere felis, nec volutpat quam interdum at. " +
            "Maecenas faucibus ex quis arcu commodo, eget aliquet sapien mollis. Sed eu nibh convallis, vehicula arcu eu, suscipit ex. Suspendisse " +
            "potenti. Ut sed eros vel nisl venenatis tincidunt nec eget orci. Nullam scelerisque, tortor in consectetur bibendum, ante mauris rutrum " +
            "metus, sit amet interdum mauris tellus vitae ex. Nulla pretium odio quam, vitae venenatis nisl luctus eget. Sed id leo quis libero " +
            "congue pretium. Nullam quis imperdiet magna. Etiam dignissim congue faucibus. Nam vitae euismod libero, ut dignissim velit. Aliquam sit " +
            "amet nunc eu felis ullamcorper facilisis in vitae lectus. Sed faucibus mi ac ligula fermentum, non dignissim elit tincidunt. Pellentesque " +
            "sit amet justo auctor, tristique ante quis, imperdiet magna. Aliquam non fringilla orci. Suspendisse non augue euismod, vestibulum ex in, " +
            "tristique magna. Maecenas vel orci ac libero blandit cursus. Aliquam tincidunt turpis mauris, ac pulvinar orci dictum a. Nam sed erat " +
            "sapien. Nunc euismod venenatis vestibulum. Nulla facilisi. Vivamus a nunc et felis rhoncus consequat. Sed a bibendum dolor, nec " +
            "consectetur dolor. Nulla aliquam sapien vel mi eleifend, sit amet efficitur lectus commodo. Pellentesque ultrices ex ac nulla dictum, " +
            "eu aliquet velit euismod. In nec";

        // Act
        ModelValidator mv = new ModelValidator(comment);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.False);
            Assert.That(mv.ContainsFailureFor("CommentTitle"), Is.True);
        });
    }

    [Test]
    public void Comment_WithMissingTitleAsNull_IsNotValid()
    {
        // Arrange
        Comment comment = MakeValidComment();
        comment.CommentTitle = null!;

        // Act
        ModelValidator mv = new ModelValidator(comment);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.False);
            Assert.That(mv.ContainsFailureFor("CommentTitle"), Is.True);
        });
    }

    [Test]
    public void Comment_WithMissingTitleAsEmptyString_IsNotValid()
    {
        // Arrange
        Comment comment = MakeValidComment();
        comment.CommentTitle = String.Empty;

        //Act
        ModelValidator mv = new ModelValidator(comment);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.False);
            Assert.That(mv.ContainsFailureFor("CommentTitle"), Is.True);
        });
    }

    [Test]
    public void Comment_WithValidDatePosted_IsCorrect()
    {
        // Arrange
        Comment comment = MakeValidComment();

        // Act
        ModelValidator mv = new ModelValidator(comment);
        DateTime actual = comment.DatePosted;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("DatePosted"), Is.False);
            Assert.That(actual, Is.EqualTo(new DateTime(2023, 2, 28, 15, 10, 20)));
        });
    }

    [Test]
    public void Comment_WithValidUserId_IsCorrect()
    {
        // Arrange
        Comment comment = MakeValidComment();

        // Act
        ModelValidator mv = new ModelValidator(comment);
        int actual = comment.UserId;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("UserId"), Is.False);
            Assert.That(actual, Is.EqualTo(2));
        });
    }

    [Test]
    public void Comment_WithValidIsVisible_IsCorrect()
    {
        // Arrange
        Comment comment = MakeValidComment();

        // Act
        ModelValidator mv = new ModelValidator(comment);
        bool actual = comment.IsVisible;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("IsVisible"), Is.False);
            Assert.That(actual, Is.True);
        });
    }

    [Test]
    public void Comment_WithValidPostId_IsCorrect()
    {
        // Arrange
        Comment comment = MakeValidComment();

        // Act
        ModelValidator mv = new ModelValidator(comment);
        int actual = comment.PostId;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("PostId"), Is.False);
            Assert.That(actual, Is.EqualTo(1));
        });
    }

    [Test]
    public void Comment_WithValidPost_IsCorrect()
    {
        // Arrange
        Comment comment = MakeValidComment();

        // Act
        ModelValidator mv = new ModelValidator(comment);
        Post actual = comment.Post;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("Post"), Is.False);
            Assert.That(actual.Id, Is.EqualTo(1));
            Assert.That(actual.PostTitle, Is.EqualTo("My very first post!"));
            Assert.That(actual.PostDescription, Is.EqualTo("Enter a description"));
            Assert.That(actual.DatePosted, Is.EqualTo(new DateTime(2023, 2, 28, 15, 0, 0)));
            Assert.That(actual.UserId, Is.EqualTo(1));
            Assert.That(actual.User.Id, Is.EqualTo(1));
            Assert.That(actual.User.Username, Is.EqualTo("Ja"));
            Assert.That(actual.User.AspNetIdentityId, Is.EqualTo("b2f96999-701e-4ad6-8ab7-e0825b49387c"));
        });
    }

    [Test]
    public void Comment_WithValidUser_IsCorrect()
    {
        // Arrange
        Comment comment = MakeValidComment();

        // Act
        ModelValidator mv = new ModelValidator(comment);
        Watcher actual = comment.User;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("User"), Is.False);
            Assert.That(actual.Id, Is.EqualTo(2));
            Assert.That(actual.AspNetIdentityId, Is.EqualTo("d5f96973-601e-4ac6-8cb7-k0825b49387r"));
            Assert.That(actual.Username, Is.EqualTo("ShannenBrion"));
            Assert.That(actual.FirstName, Is.EqualTo("Brion"));
            Assert.That(actual.LastName, Is.EqualTo("Shannen"));
            Assert.That(actual.Email, Is.EqualTo("ShannenBrion@gmail.com"));
            Assert.That(actual.Bio, Is.EqualTo("Comedy's are my favorite genre"));
        });
    }
}