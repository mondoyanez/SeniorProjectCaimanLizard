using WatchParty.Models;

namespace WatchPartyTest;
public class WatchPartyGroupAssignmentModelValidator_Tests
{
    public WatchPartyGroupAssignment MakeValidGroupAssignment()
    {
        Watcher host = new Watcher
        {
            Id = 1,
            AspNetIdentityId = "b2f96999-701e-4ad6-8ab7-e0825b49387c",
            Username = "Ja",
            FirstName = "Ja",
            LastName = "Morrant",
            Email = "MorrantJa@gmail.com",
            Bio = "This is my bio"
        };

        Watcher invitee = new Watcher
        {
            Id = 2,
            AspNetIdentityId = "d5f96973-601e-4ac6-8cb7-k0825b49387r",
            Username = "ShannenBrion",
            FirstName = "Brion",
            LastName = "Shannen",
            Email = "ShannenBrion@gmail.com",
            Bio = "Comedy's are my favorite genre"
        };

        WatchPartyGroup group = new WatchPartyGroup
        {
            Id = 1,
            GroupTitle = "Marvel marathon movie night",
            GroupDescription = "Watching every movie in the MCU with friends",
            StartDate = new DateTime(2023, 5, 5, 8, 0, 0),
            HostId = host.Id,
            Host = host
        };

        WatchPartyGroupAssignment assignment = new WatchPartyGroupAssignment
        {
            Id = 1,
            GroupId = group.Id,
            Group = group,
            WatcherId = invitee.Id,
            Watcher = invitee
        };

        return assignment;
    }

    [Test]
    public void MakeValidGroupAssignment_IsValid()
    {
        // Arrange
        WatchPartyGroupAssignment assignment = MakeValidGroupAssignment();

        // Act
        ModelValidator mv = new ModelValidator(assignment);

        // Assert
        Assert.That(mv.Valid, Is.True);
    }

    [Test]
    public void MakeValidGroupAssignment_WithValidId_IsCorrect()
    {
        // Arrange
        WatchPartyGroupAssignment assignment = MakeValidGroupAssignment();

        // Act
        ModelValidator mv = new ModelValidator(assignment);
        int actual = assignment.Id;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("Id"), Is.False);
            Assert.That(actual, Is.EqualTo(1));
        });
    }

    [Test]
    public void MakeValidGroupAssignment_WithValidId_IsIncorrect()
    {
        // Arrange
        WatchPartyGroupAssignment assignment = MakeValidGroupAssignment();

        // Act
        ModelValidator mv = new ModelValidator(assignment);
        int actual = assignment.Id;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("Id"), Is.False);
            Assert.That(actual, Is.Not.EqualTo(5));
        });
    }

    [Test]
    public void MakeValidGroupAssignment_WithValidGroupId_IsCorrect()
    {
        // Arrange
        WatchPartyGroupAssignment assignment = MakeValidGroupAssignment();

        // Act
        ModelValidator mv = new ModelValidator(assignment);
        int actual = assignment.GroupId;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("GroupId"), Is.False);
            Assert.That(actual, Is.EqualTo(1));
        });
    }

    [Test]
    public void MakeValidGroupAssignment_WithValidGroupId_IsIncorrect()
    {
        // Arrange
        WatchPartyGroupAssignment assignment = MakeValidGroupAssignment();

        // Act
        ModelValidator mv = new ModelValidator(assignment);
        int actual = assignment.GroupId;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("GroupId"), Is.False);
            Assert.That(actual, Is.Not.EqualTo(7));
        });
    }

    [Test]
    public void MakeValidGroupAssignment_WithValidWatcherId_IsCorrect()
    {
        // Arrange
        WatchPartyGroupAssignment assignment = MakeValidGroupAssignment();

        // Act
        ModelValidator mv = new ModelValidator(assignment);
        int actual = assignment.WatcherId;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("WatcherId"), Is.False);
            Assert.That(actual, Is.EqualTo(2));
        });
    }

    [Test]
    public void MakeValidGroupAssignment_WithValidWatcherId_IsIncorrect()
    {
        // Arrange
        WatchPartyGroupAssignment assignment = MakeValidGroupAssignment();

        // Act
        ModelValidator mv = new ModelValidator(assignment);
        int actual = assignment.WatcherId;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("WatcherId"), Is.False);
            Assert.That(actual, Is.Not.EqualTo(10));
        });
    }

    [Test]
    public void MakeValidGroupAssignment_WithValidGroupObject_IsCorrect()
    {
        // Arrange
        WatchPartyGroupAssignment assignment = MakeValidGroupAssignment();

        // Act
        ModelValidator mv = new ModelValidator(assignment);
        WatchPartyGroup actual = assignment.Group;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("Group"), Is.False);
            Assert.That(actual.Id, Is.EqualTo(1));
        });
    }

    [Test]
    public void MakeValidGroupAssignment_WithValidGroupObject_IsIncorrect()
    {
        // Arrange
        WatchPartyGroupAssignment assignment = MakeValidGroupAssignment();

        // Act
        ModelValidator mv = new ModelValidator(assignment);
        WatchPartyGroup actual = assignment.Group;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("Group"), Is.False);
            Assert.That(actual.Id, Is.Not.EqualTo(7));
        });
    }

    [Test]
    public void MakeValidGroupAssignment_WithValidWatcherObject_IsCorrect()
    {
        // Arrange
        WatchPartyGroupAssignment assignment = MakeValidGroupAssignment();

        // Act
        ModelValidator mv = new ModelValidator(assignment);
        Watcher actual = assignment.Watcher;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("Group"), Is.False);
            Assert.That(actual.Id, Is.EqualTo(2));
        });
    }

    [Test]
    public void MakeValidGroupAssignment_WithValidWatcherObject_IsIncorrect()
    {
        // Arrange
        WatchPartyGroupAssignment assignment = MakeValidGroupAssignment();

        // Act
        ModelValidator mv = new ModelValidator(assignment);
        Watcher actual = assignment.Watcher;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("Group"), Is.False);
            Assert.That(actual.Id, Is.Not.EqualTo(1));
        });
    }
}