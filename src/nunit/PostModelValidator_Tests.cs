using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchParty.Models;

namespace WatchPartyTest;
public class PostModelValidator_Tests
{
    private Post MakeValidPost()
    {
        Watcher watcher = new Watcher
        {
            Id = 1,
            AspNetIdentityId = "b2f96999-701e-4ad6-8ab7-e0825b49387c",
            Username = "Ja",
            FirstName = "Ja",
            LastName = "Morrant",
            Email = "MorrantJa@gmail.com",
            FollowingCount = 1000000,
            FollowerCount = 50,
            Bio = "This is my bio"
        };

        Post post = new Post
        {
            Id = 1,
            PostTitle = "My very first post!",
            PostDescription = "Enter a description",
            DatePosted = new DateTime(2023, 2, 28, 15, 0, 0),
            UserId = 1,
            User = watcher
        };
        return post;
    }

    [Test]
    public void ValidPost_IsValid()
    {
        // Arrange
        Post post = MakeValidPost();

        // Act
        ModelValidator mv = new ModelValidator(post);

        // Assert
        Assert.That(mv.Valid, Is.True);
    }

    [Test]
    public void Post_WithValidId_IsIncorrect()
    {
        // Arrange
        Post post = MakeValidPost();
        
        // Act
        ModelValidator mv = new ModelValidator(post);
        int actual = post.Id;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("Id"), Is.False);
            Assert.That(actual, Is.Not.EqualTo(5));
        });
    }

    [Test]
    public void Post_WithValidId_IsCorrect()
    {
        // Arrange
        Post post = MakeValidPost();

        // Act
        ModelValidator mv = new ModelValidator(post);
        int actual = post.Id;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("Id"), Is.False);
            Assert.That(actual, Is.EqualTo(1));
        });
    }

    [Test]
    public void Post_WithMissingTitleAsNull_IsNotValid()
    {
        // Arrange
        Post post = MakeValidPost();
        post.PostTitle = null!;

        // Act
        ModelValidator mv = new ModelValidator(post);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.False);
            Assert.That(mv.ContainsFailureFor("PostTitle"), Is.True);
        });
    }

    [Test]
    public void Post_WithTitleAsEmptyString_IsNotValid()
    {
        // Arrange
        Post post = MakeValidPost();
        post.PostTitle = String.Empty;

        // Act
        ModelValidator mv = new ModelValidator(post);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.False);
            Assert.That(mv.ContainsFailureFor("PostTitle"), Is.True);
        });
    }

    [Test]
    public void Post_WithTitleExceedingLength_IsNotValid()
    {
        // Arrange
        Post post = MakeValidPost();
        post.PostTitle =
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
        ModelValidator mv = new ModelValidator(post);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.False);
            Assert.That(mv.ContainsFailureFor("PostTitle"), Is.True);
        });
    }

    [Test]
    public void Post_WithValidTitle_IsCorrect()
    {
        // Arrange
        Post post = MakeValidPost();

        // Act
        ModelValidator mv = new ModelValidator(post);
        string actual = post.PostTitle;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("PostTitle"), Is.False);
            Assert.That(actual, Is.EqualTo("My very first post!"));
        });
    }

    [Test]
    public void Post_WithDescriptionExceedingLength_IsNotValid()
    {
        // Arrange
        Post post = MakeValidPost();
        post.PostDescription =
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
        ModelValidator mv = new ModelValidator(post);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.False);
            Assert.That(mv.ContainsFailureFor("PostDescription"), Is.True);
        });
    }

    [Test]
    public void Post_WithValidDescription_IsCorrect()
    {
        // Arrange
        Post post = MakeValidPost();

        // Act
        ModelValidator mv = new ModelValidator(post);
        string? actual = post.PostDescription;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("PostDescription"), Is.False);
            Assert.That(actual, Is.EqualTo("Enter a description"));
        });
    }

    [Test]
    public void Post_WithValidDescriptionAsNull_IsNull()
    {
        // Arrange
        Post post = MakeValidPost();
        post.PostDescription = null;

        // Act
        ModelValidator mv = new ModelValidator(post);
        string? actual = post.PostDescription;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("PostDescription"), Is.False);
            Assert.That(actual, Is.Null);
        });
    }

    [Test]
    public void Post_WithValidDescriptionAsEmptyString_IsValid()
    {
        // Arrrange
        Post post = MakeValidPost();
        post.PostDescription = String.Empty;

        // Act
        ModelValidator mv = new ModelValidator(post);
        string? actual = post.PostDescription;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("PostDescription"), Is.False);
            Assert.That(actual, Is.EqualTo(String.Empty));
        });
    }

    [Test]
    public void Post_WithValidDescription_IsIncorrect()
    {
        // Arrange
        Post post = MakeValidPost();

        // Act
        ModelValidator mv = new ModelValidator(post);
        string? actual = post.PostDescription;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("PostDescription"), Is.False);
            Assert.That(actual, Is.Not.EqualTo("wrong text"));
        });
    }

    [Test]
    public void Post_WithValidDatePosted_IsCorrect()
    {
        // Arrange
        Post post = MakeValidPost();

        // Act
        ModelValidator mv = new ModelValidator(post);
        DateTime actual = post.DatePosted;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("DatePosted"), Is.False);
            Assert.That(actual, Is.EqualTo(new DateTime(2023, 2, 28, 15, 0, 0)));
        });
    }

    [Test]
    public void Post_WithValidDatePosted_IsIncorrect()
    {
        // Arrange
        Post post = MakeValidPost();

        // Act
        ModelValidator mv = new ModelValidator(post);
        DateTime actual = post.DatePosted;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("DatePosted"), Is.False);
            Assert.That(actual, Is.Not.EqualTo(new DateTime(2022, 5, 25, 8, 25, 45)));
        });
    }

    [Test]
    public void Post_WithValidUserId_IsIncorrect()
    {
        // Arrange
        Post post = MakeValidPost();

        // Act
        ModelValidator mv = new ModelValidator(post);
        int actual = post.UserId;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("UserId"), Is.False);
            Assert.That(actual, Is.Not.EqualTo(10));
        });
    }

    [Test]
    public void Post_WithValidUserId_IsCorrect()
    {
        // Arrange
        Post post = MakeValidPost();

        // Act
        ModelValidator mv = new ModelValidator(post);
        int actual = post.UserId;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("UserId"), Is.False);
            Assert.That(actual, Is.EqualTo(1));
        });
    }
}