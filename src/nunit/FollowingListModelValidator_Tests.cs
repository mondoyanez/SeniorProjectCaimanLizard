using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchParty.Models;

namespace WatchPartyTest;
public class FollowingListModelValidator_Tests
{
    private FollowingList MakeValidFollow()
    {
        Watcher watcher = new Watcher
        {
            Id = 1,
            AspNetIdentityId = "b2f96999-701e-4ad6-8ab7-e0825b49387c",
            Username = "Ja",
            FirstName = "Ja",
            LastName = "Morrant",
            Email = "MorrantJa@gmail.com",
            Bio = "This is my bio"
        };

        Watcher follower = new Watcher
        {
            Id = 2,
            AspNetIdentityId = "b2f96998-701e-4ad6-8ab7-e0825b49388d",
            Username = "SandraHart",
            FirstName = "Sandra",
            LastName = "Hart",
            Email = "SandraHart@gmail.com",
            Bio = null
        };

        FollowingList follow = new FollowingList
        {
            Id = 1,
            UserId = 2,
            FollowingId = 1,
            Following = watcher,
            User = follower
        };

        return follow;
    }

    [Test]
    public void ValidFollowList_IsValid()
    {
        // Arrange
        FollowingList follow = MakeValidFollow();

        // Act
        ModelValidator mv = new ModelValidator(follow);

        // Assert
        Assert.That(mv.Valid, Is.True);
    }

    [Test]
    public void ValidFollowList_WithValidId_ReturnsProperValue()
    {
        // Arrange
        FollowingList follow = MakeValidFollow();

        // Act
        ModelValidator mv = new ModelValidator(follow);
        int actual = follow.Id;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("Id"), Is.False);
            Assert.That(actual, Is.EqualTo(1));
        });
    }

    [Test]
    public void ValidFollowList_WithValidUserId_ReturnsProperValue()
    {
        // Arrange
        FollowingList follow = MakeValidFollow();

        // Act
        ModelValidator mv = new ModelValidator(follow);
        int actual = follow.UserId;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("UserId"), Is.False);
            Assert.That(actual, Is.EqualTo(2));
        });
    }

    [Test]
    public void ValidFollowList_WithValidFollowingId_ReturnsProperValue()
    {
        // Arrange
        FollowingList follow = MakeValidFollow();

        // Act
        ModelValidator mv = new ModelValidator(follow);
        int actual = follow.FollowingId;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("FollowingId"), Is.False);
            Assert.That(actual, Is.EqualTo(1));
        });
    }

    [Test]
    public void ValidFollowList_WithValidUser_ReturnsProperValue()
    {
        // Arrange
        FollowingList follow = MakeValidFollow();

        // Act
        ModelValidator mv = new ModelValidator(follow);

        Watcher follower = follow.User;

        int actualId = follower.Id;
        string actualAspId = follower.AspNetIdentityId;
        string actualUsername = follower.Username;
        string? actualFirstName = follower.FirstName;
        string? actualLastName = follower.LastName;
        string? actualEmail = follower.Email;
        string? actualBio = follower.Bio;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("User"), Is.False);
            Assert.That(actualId, Is.EqualTo(2));
            Assert.That(actualAspId, Is.EqualTo("b2f96998-701e-4ad6-8ab7-e0825b49388d"));
            Assert.That(actualUsername, Is.EqualTo("SandraHart"));
            Assert.That(actualFirstName, Is.EqualTo("Sandra"));
            Assert.That(actualLastName, Is.EqualTo("Hart"));
            Assert.That(actualEmail, Is.EqualTo("SandraHart@gmail.com"));
            Assert.That(actualBio, Is.Null);
        });
    }

    [Test]
    public void ValidFollowList_WithValidFollowing_ReturnsProperValue()
    {
        // Arrange
        FollowingList follow = MakeValidFollow();

        // Act
        ModelValidator mv = new ModelValidator(follow);

        Watcher follower = follow.Following;

        int actualId = follower.Id;
        string actualAspId = follower.AspNetIdentityId;
        string actualUsername = follower.Username;
        string? actualFirstName = follower.FirstName;
        string? actualLastName = follower.LastName;
        string? actualEmail = follower.Email;
        string? actualBio = follower.Bio;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("Following"), Is.False);
            Assert.That(actualId, Is.EqualTo(1));
            Assert.That(actualAspId, Is.EqualTo("b2f96999-701e-4ad6-8ab7-e0825b49387c"));
            Assert.That(actualUsername, Is.EqualTo("Ja"));
            Assert.That(actualFirstName, Is.EqualTo("Ja"));
            Assert.That(actualLastName, Is.EqualTo("Morrant"));
            Assert.That(actualEmail, Is.EqualTo("MorrantJa@gmail.com"));
            Assert.That(actualBio, Is.EqualTo("This is my bio"));
        });
    }
}