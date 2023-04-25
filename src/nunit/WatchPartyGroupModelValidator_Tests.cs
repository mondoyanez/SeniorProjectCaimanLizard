using WatchParty.Models;

namespace WatchPartyTest;
public class WatchPartyGroupModelValidator_Tests
{
    public WatchPartyGroup MakeValidGroup()
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

        WatchPartyGroup group = new WatchPartyGroup
        {
            Id = 1,
            GroupTitle = "Marvel marathon movie night",
            GroupDescription = "Watching every movie in the MCU with friends",
            StartDate = new DateTime(2023, 5, 5, 8, 0, 0),
            HostId = host.Id,
            Host = host
        };

        return group;
    }

    [Test]
    public void MakeValidGroup_IsValid()
    {
        // Arrange
        WatchPartyGroup group = MakeValidGroup();

        // Act
        ModelValidator mv = new ModelValidator(group);

        // Assert
        Assert.That(mv.Valid, Is.True);
    }

    [Test]
    public void MakeValidGroup_WithValidId_IsCorrect()
    {
        // Arrange
        WatchPartyGroup group = MakeValidGroup();

        // Act
        ModelValidator mv = new ModelValidator(group);
        int actual = group.Id;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("Id"), Is.False);
            Assert.That(actual, Is.EqualTo(1));
        });
    }

    [Test]
    public void MakeValidGroup_WithValidId_IsIncorrect()
    {
        // Arrange
        WatchPartyGroup group = MakeValidGroup();

        // Act
        ModelValidator mv = new ModelValidator(group);
        int actual = group.Id;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("Id"), Is.False);
            Assert.That(actual, Is.Not.EqualTo(6));
        });
    }

    [Test]
    public void MakeValidGroup_WithValidGroupTitle_IsCorrect()
    {
        // Arrange
        WatchPartyGroup group = MakeValidGroup();

        // Act
        ModelValidator mv = new ModelValidator(group);
        string actual = group.GroupTitle;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("GroupTitle"), Is.False);
            Assert.That(actual, Is.EqualTo("Marvel marathon movie night"));
        });
    }

    [Test]
    public void MakeGroup_WithInvalidGroupTitleAsEmptyString_FailsModelValidation()
    {
        // Arrange
        WatchPartyGroup group = MakeValidGroup();
        group.GroupTitle = string.Empty;

        // Act
        ModelValidator mv = new ModelValidator(group);
        string? actual = group.GroupTitle;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.False);
            Assert.That(mv.ContainsFailureFor("GroupTitle"), Is.True);
            Assert.That(actual, Is.Empty);
        });
    }

    [Test]
    public void MakeGroup_WithInvalidGroupTitleAsNull_FailsModelValidation()
    {
        // Arrange
        WatchPartyGroup group = MakeValidGroup();
        group.GroupTitle = null!;

        // Act
        ModelValidator mv = new ModelValidator(group);
        string? actual = group.GroupTitle;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.False);
            Assert.That(mv.ContainsFailureFor("GroupTitle"), Is.True);
            Assert.That(actual, Is.Null);
        });
    }

    [Test]
    public void MakeValidGroup_WithValidGroupTitle_IsIncorrect()
    {
        // Arrange
        WatchPartyGroup group = MakeValidGroup();

        // Act
        ModelValidator mv = new ModelValidator(group);
        string actual = group.GroupTitle;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("GroupTitle"), Is.False);
            Assert.That(actual, Is.Not.EqualTo("Incorrect Title"));
        });
    }

    [Test]
    public void MakeValidGroup_WithValidGroupDescription_IsCorrect()
    {
        // Arrange
        WatchPartyGroup group = MakeValidGroup();

        // Act
        ModelValidator mv = new ModelValidator(group);
        string? actual = group.GroupDescription;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("GroupDescription"), Is.False);
            Assert.That(actual, Is.EqualTo("Watching every movie in the MCU with friends"));
        });
    }

    [Test]
    public void MakeValidGroup_WithValidGroupDescriptionAsEmptyString_IsCorrect()
    {
        // Arrange
        WatchPartyGroup group = MakeValidGroup();
        group.GroupDescription = string.Empty;

        // Act
        ModelValidator mv = new ModelValidator(group);
        string? actual = group.GroupDescription;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("GroupDescription"), Is.False);
            Assert.That(actual, Is.Empty);
        });
    }

    [Test]
    public void MakeValidGroup_WithValidGroupDescriptionAsNull_IsCorrect()
    {
        // Arrange
        WatchPartyGroup group = MakeValidGroup();
        group.GroupDescription = null!;

        // Act
        ModelValidator mv = new ModelValidator(group);
        string? actual = group.GroupDescription;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("GroupDescription"), Is.False);
            Assert.That(actual, Is.Null);
        });
    }

    [Test]
    public void MakeValidGroup_WithValidGroupDescription_IsIncorrect()
    {
        // Arrange
        WatchPartyGroup group = MakeValidGroup();

        // Act
        ModelValidator mv = new ModelValidator(group);
        string? actual = group.GroupDescription;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("GroupDescription"), Is.False);
            Assert.That(actual, Is.Not.EqualTo("Incorrect description"));
        });
    }

    [Test]
    public void MakeValidGroup_WithValidStartDate_IsCorrect()
    {
        // Arrange
        WatchPartyGroup group = MakeValidGroup();

        // Act
        ModelValidator mv = new ModelValidator(group);
        DateTime actual = group.StartDate;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("StartDate"), Is.False);
            Assert.That(actual, Is.EqualTo(new DateTime(2023, 5, 5, 8, 0, 0)));
        });
    }

    [Test]
    public void MakeValidGroup_WithValidStartDate_IsIncorrect()
    {
        // Arrange
        WatchPartyGroup group = MakeValidGroup();

        // Act
        ModelValidator mv = new ModelValidator(group);
        DateTime actual = group.StartDate;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("StartDate"), Is.False);
            Assert.That(actual, Is.Not.EqualTo(new DateTime(2020, 7, 2, 4, 15, 18)));
        });
    }

    [Test]
    public void MakeValidGroup_WithValidHostId_IsCorrect()
    {
        // Arrange
        WatchPartyGroup group = MakeValidGroup();

        // Act
        ModelValidator mv = new ModelValidator(group);
        int actual = group.HostId;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("HostId"), Is.False);
            Assert.That(actual, Is.EqualTo(1));
        });
    }

    [Test]
    public void MakeValidGroup_WithValidHostId_IsIncorrect()
    {
        // Arrange
        WatchPartyGroup group = MakeValidGroup();

        // Act
        ModelValidator mv = new ModelValidator(group);
        int actual = group.HostId;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("HostId"), Is.False);
            Assert.That(actual, Is.Not.EqualTo(3));
        });
    }

    [Test]
    public void MakeValidGroup_WithValidHost_IsCorrect()
    {
        // Arrange
        WatchPartyGroup group = MakeValidGroup();

        // Act
        ModelValidator mv = new ModelValidator(group);
        Watcher actual = group.Host;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("Host"), Is.False);
            Assert.That(actual.AspNetIdentityId, Is.EqualTo("b2f96999-701e-4ad6-8ab7-e0825b49387c"));
        });
    }

    [Test]
    public void MakeValidGroup_WithValidHost_IsIncorrect()
    {
        // Arrange
        WatchPartyGroup group = MakeValidGroup();

        // Act
        ModelValidator mv = new ModelValidator(group);
        Watcher actual = group.Host;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("Host"), Is.False);
            Assert.That(actual.AspNetIdentityId, Is.Not.EqualTo("c2f96996-701e-4ad6-8ab7-f0825b49387t"));
        });
    }
}