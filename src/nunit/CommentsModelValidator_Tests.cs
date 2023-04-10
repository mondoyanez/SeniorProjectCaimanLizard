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
            UserId = 1,
            User = poster
        };

        Comment comment = new Comment
        {
            Id = 1,
            CommentTitle = "This text contains a comment",
            DatePosted = new DateTime(2023, 2, 28, 15, 10, 20),
            UserId = 2,
            PostId = 1,
            Post = post,
            User = poster
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
}