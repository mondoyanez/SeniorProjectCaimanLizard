using WatchParty.DAL.Abstract;
using WatchParty.DAL.Concrete;
using WatchParty.Models;

namespace WatchPartyTest;

/**
 * This is the recommended way to test using the in-memory db.  Seed the db and then write your tests based only on the seed
 * data + anything else you do to it.  No other tests will modify the db for that test.  Every test gets a brand new seeded db.
 * 
 */

public class WatchPartyGroupRepository_Tests
{
    private static readonly string _seedFile = @"..\..\..\Data\WatchPartyGroupSeed.sql"; // relative path of WatchPartyTest from where the executable is: bin/Debug/net7.0
    private static readonly string _seedFilePostEmpty = @"..\..\..\Data\WatchPartyGroupSeedEmpty.sql";

    // Create this helper like this, for whatever context you desire
    private InMemoryDbHelper<WatchPartyDbContext> _dbHelper = new InMemoryDbHelper<WatchPartyDbContext>(_seedFile, DbPersistence.OneDbPerTest);
    private InMemoryDbHelper<WatchPartyDbContext> _dbHelperPostEmpty = new InMemoryDbHelper<WatchPartyDbContext>(_seedFilePostEmpty, DbPersistence.OneDbPerTest);

    [Test]
    public void CreateWatchPartyGroup_WithValidData_ShouldSuccessfullyAddGroup()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IWatchPartyGroupRepository repo = new WatchPartyGroupRepository(context);
        // The db has been seeded

        Watcher? watcher = context.Watchers.FirstOrDefault(w => w.Id == 5);

        WatchPartyGroup group = new WatchPartyGroup
        {
            GroupTitle = "Anime watch party",
            GroupDescription = "Going to be watching random anime together",
            TelePartyUrl = null,
            StartDate = new DateTime(2030, 5, 25, 15, 30, 0),
            HostId = watcher.Id,
            Host = watcher
        };

        // Act
        repo.CreateWatchPartyGroup(group);
        int count = repo.GetAll().Count();

        // Assert
        Assert.That(count, Is.EqualTo(4));
    }

    [Test]
    public void CreateWatchPartyGroup_WithDataMatchingExistingData_SuccessfullyCreatesGroup()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IWatchPartyGroupRepository repo = new WatchPartyGroupRepository(context);
        // The db has been seeded

        Watcher? watcher = context.Watchers.FirstOrDefault(w => w.Id == 1);

        WatchPartyGroup group = new WatchPartyGroup
        {
            GroupTitle = "Marvel marathon movie night",
            GroupDescription = null,
            TelePartyUrl = null,
            StartDate = new DateTime(2030, 5, 5, 20, 0, 0),
            HostId = watcher.Id,
            Host = watcher
        };

        // Act
        repo.CreateWatchPartyGroup(group);
        int count = repo.GetAll().Count();

        // Assert
        Assert.That(count, Is.EqualTo(4));
    }

    [Test]
    public void CreateWatchPartyGroup_WithDateBeforeTodaysDate_ShouldThrowException()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IWatchPartyGroupRepository repo = new WatchPartyGroupRepository(context);
        // The db has been seeded

        Watcher? watcher = context.Watchers.FirstOrDefault(w => w.Id == 5);

        WatchPartyGroup group = new WatchPartyGroup
        {
            GroupTitle = "Anime watch party",
            GroupDescription = "Going to be watching random anime together",
            StartDate = new DateTime(2000, 5, 25, 15, 30, 0),
            TelePartyUrl = null,
            HostId = watcher.Id,
            Host = watcher
        };

        // Act/Assert
        Assert.Throws<ArgumentException>(() => repo.CreateWatchPartyGroup(group));
    }

    [Test]
    public void CreateWatchPartyGroup_WithInvalidData_ShouldThrowException()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IWatchPartyGroupRepository repo = new WatchPartyGroupRepository(context);
        // The db has been seeded

        WatchPartyGroup group = new WatchPartyGroup
        {
            GroupTitle = "Anime watch party",
            GroupDescription = "Going to be watching random anime together",
            StartDate = new DateTime(2030, 5, 25, 15, 30, 0)
        };

        // Act/Assert
        Assert.Throws<Exception>(() => repo.CreateWatchPartyGroup(group));
    }

    [Test]
    public void CreateWatchPartyGroup_WithDataAsNull_ShouldThrowException()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IWatchPartyGroupRepository repo = new WatchPartyGroupRepository(context);
        // The db has been seeded

        WatchPartyGroup group = null!;

        // Act/Assert
        Assert.Throws<ArgumentNullException>(() => repo.CreateWatchPartyGroup(group));
    }

    [Test]
    public void GetById_ForExistingGroup_ShouldReturnCorrectGroup()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IWatchPartyGroupRepository repo = new WatchPartyGroupRepository(context);

        // Act
        WatchPartyGroup? actual = repo.GetById(2);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(actual?.Id, Is.EqualTo(2));
            Assert.That(actual?.GroupTitle, Is.EqualTo("Harry Potter marathon"));
            Assert.That(actual?.GroupDescription, Is.EqualTo("Going to watch all the Harry Potter movies in order all day"));
            Assert.That(actual?.StartDate, Is.EqualTo(new DateTime(2030, 5, 5, 8, 0, 0)));
            Assert.That(actual?.TelePartyUrl, Is.EqualTo("https://redirect.teleparty.com/join/5ff6a69318b6a145"));
            Assert.That(actual?.Host.AspNetIdentityId, Is.EqualTo("561e79b0-24be-4f8b-96dd-056b493cd7e5"));
            Assert.That(actual?.HostId, Is.EqualTo(5));
        });
    }

    [Test]
    public void GetById_ForNonExistingGroup_ShouldReturnNull()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IWatchPartyGroupRepository repo = new WatchPartyGroupRepository(context);

        // Act
        WatchPartyGroup? actual = repo.GetById(20);

        // Assert
        Assert.That(actual, Is.Null);
    }

    [Test]
    public void UpdateGroup_ForExistingGroupWithNoChanges_ShouldSuccessfullyUpdate()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IWatchPartyGroupRepository repo = new WatchPartyGroupRepository(context);
        WatchPartyGroup? group = repo.GetById(1);

        // Act
        repo.UpdateGroup(group);
        group = repo.GetById(1);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(group, Is.Not.Null);
            Assert.That(group?.Id, Is.EqualTo(1));
            Assert.That(group?.GroupTitle, Is.EqualTo("Marvel marathon movie night"));
            Assert.That(group?.GroupDescription, Is.Null);
            Assert.That(group?.StartDate, Is.EqualTo(new DateTime(2030, 5, 5, 20, 0, 0)));
            Assert.That(group?.TelePartyUrl, Is.Null);
            Assert.That(group?.HostId, Is.EqualTo(1));
        });
    }

    [Test]
    public void UpdateGroup_ForExistingGroupWithTitleChanged_ShouldSuccessfullyUpdate()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IWatchPartyGroupRepository repo = new WatchPartyGroupRepository(context);
        WatchPartyGroup? group = repo.GetById(1);
        group.GroupTitle = "Movie night";

        // Act
        repo.UpdateGroup(group);
        group = repo.GetById(1);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(group, Is.Not.Null);
            Assert.That(group?.Id, Is.EqualTo(1));
            Assert.That(group?.GroupTitle, Is.EqualTo("Movie night"));
            Assert.That(group?.GroupDescription, Is.Null);
            Assert.That(group?.StartDate, Is.EqualTo(new DateTime(2030, 5, 5, 20, 0, 0)));
            Assert.That(group?.TelePartyUrl, Is.Null);
            Assert.That(group?.HostId, Is.EqualTo(1));
        });
    }

    [Test]
    public void UpdateGroup_ForExistingGroupWithDescriptionChanged_ShouldSuccessfullyUpdate()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IWatchPartyGroupRepository repo = new WatchPartyGroupRepository(context);
        WatchPartyGroup? group = repo.GetById(1);
        group.GroupDescription = "Watching them all tonight or die trying!!!";

        // Act
        repo.UpdateGroup(group);
        group = repo.GetById(1);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(group, Is.Not.Null);
            Assert.That(group?.Id, Is.EqualTo(1));
            Assert.That(group?.GroupTitle, Is.EqualTo("Marvel marathon movie night"));
            Assert.That(group?.GroupDescription, Is.EqualTo("Watching them all tonight or die trying!!!"));
            Assert.That(group?.StartDate, Is.EqualTo(new DateTime(2030, 5, 5, 20, 0, 0)));
            Assert.That(group?.TelePartyUrl, Is.Null);
            Assert.That(group?.HostId, Is.EqualTo(1));
        });
    }

    [Test]
    public void UpdateGroup_ForExistingGroupWithDescriptionChangedToNull_ShouldSuccessfullyUpdate()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IWatchPartyGroupRepository repo = new WatchPartyGroupRepository(context);
        WatchPartyGroup? group = repo.GetById(2);
        group.GroupDescription = null;

        // Act
        repo.UpdateGroup(group);
        group = repo.GetById(2);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(group, Is.Not.Null);
            Assert.That(group?.Id, Is.EqualTo(2));
            Assert.That(group?.GroupTitle, Is.EqualTo("Harry Potter marathon"));
            Assert.That(group?.GroupDescription, Is.Null);
            Assert.That(group?.StartDate, Is.EqualTo(new DateTime(2030, 5, 5, 8, 0, 0)));
            Assert.That(group?.TelePartyUrl, Is.EqualTo("https://redirect.teleparty.com/join/5ff6a69318b6a145"));
            Assert.That(group?.HostId, Is.EqualTo(5));
        });
    }

    [Test]
    public void UpdateGroup_ForExistingGroupWithDescriptionChangedToEmptyString_ShouldSuccessfullyUpdate()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IWatchPartyGroupRepository repo = new WatchPartyGroupRepository(context);
        WatchPartyGroup? group = repo.GetById(2);
        group.GroupDescription = "";

        // Act
        repo.UpdateGroup(group);
        group = repo.GetById(2);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(group, Is.Not.Null);
            Assert.That(group?.Id, Is.EqualTo(2));
            Assert.That(group?.GroupTitle, Is.EqualTo("Harry Potter marathon"));
            Assert.That(group?.GroupDescription, Is.EqualTo(String.Empty));
            Assert.That(group?.StartDate, Is.EqualTo(new DateTime(2030, 5, 5, 8, 0, 0)));
            Assert.That(group?.TelePartyUrl, Is.EqualTo("https://redirect.teleparty.com/join/5ff6a69318b6a145"));
            Assert.That(group?.HostId, Is.EqualTo(5));
        });
    }

    [Test]
    public void UpdateGroup_ForExistingGroupWithTelePartyUrlChanged_ShouldSuccessfullyUpdate()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IWatchPartyGroupRepository repo = new WatchPartyGroupRepository(context);
        WatchPartyGroup? group = repo.GetById(1);
        group.TelePartyUrl = "https://redirect.teleparty.com/join/1cd99f76df1ab78e";

        // Act
        repo.UpdateGroup(group);
        group = repo.GetById(1);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(group, Is.Not.Null);
            Assert.That(group?.Id, Is.EqualTo(1));
            Assert.That(group?.GroupTitle, Is.EqualTo("Marvel marathon movie night"));
            Assert.That(group?.GroupDescription, Is.Null);
            Assert.That(group?.StartDate, Is.EqualTo(new DateTime(2030, 5, 5, 20, 0, 0)));
            Assert.That(group?.TelePartyUrl, Is.EqualTo("https://redirect.teleparty.com/join/1cd99f76df1ab78e"));
            Assert.That(group?.HostId, Is.EqualTo(1));
        });
    }

    [Test]
    public void UpdateGroup_ForExistingGroupWithTelePartyUrlChangedToNull_ShouldSuccessfullyUpdate()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IWatchPartyGroupRepository repo = new WatchPartyGroupRepository(context);
        WatchPartyGroup? group = repo.GetById(2);
        group.TelePartyUrl = null;

        // Act
        repo.UpdateGroup(group);
        group = repo.GetById(2);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(group, Is.Not.Null);
            Assert.That(group?.Id, Is.EqualTo(2));
            Assert.That(group?.GroupTitle, Is.EqualTo("Harry Potter marathon"));
            Assert.That(group?.GroupDescription, Is.EqualTo("Going to watch all the Harry Potter movies in order all day"));
            Assert.That(group?.StartDate, Is.EqualTo(new DateTime(2030, 5, 5, 8, 0, 0)));
            Assert.That(group?.TelePartyUrl, Is.Null);
            Assert.That(group?.HostId, Is.EqualTo(5));
        });
    }

    [Test]
    public void UpdateGroup_ForExistingGroupWithTelePartyUrlChangedToEmptyString_ShouldSuccessfullyUpdate()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IWatchPartyGroupRepository repo = new WatchPartyGroupRepository(context);
        WatchPartyGroup? group = repo.GetById(2);
        group.TelePartyUrl = "";

        // Act
        repo.UpdateGroup(group);
        group = repo.GetById(2);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(group, Is.Not.Null);
            Assert.That(group?.Id, Is.EqualTo(2));
            Assert.That(group?.GroupTitle, Is.EqualTo("Harry Potter marathon"));
            Assert.That(group?.GroupDescription, Is.EqualTo("Going to watch all the Harry Potter movies in order all day"));
            Assert.That(group?.StartDate, Is.EqualTo(new DateTime(2030, 5, 5, 8, 0, 0)));
            Assert.That(group?.TelePartyUrl, Is.EqualTo(String.Empty));
            Assert.That(group?.HostId, Is.EqualTo(5));
        });
    }

    [Test]
    public void UpdateGroup_ForExistingGroupWithTitleMissing_ShouldThrowException()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IWatchPartyGroupRepository repo = new WatchPartyGroupRepository(context);
        WatchPartyGroup? group = repo.GetById(2);
        group.GroupTitle = null!;

        // Act/Assert
        Assert.Throws<Exception>(() => repo.UpdateGroup(group));
    }

    [Test]
    public void UpdateGroup_ForNullGroup_ShouldThrowException()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IWatchPartyGroupRepository repo = new WatchPartyGroupRepository(context);

        // Act/Assert
        Assert.Throws<ArgumentNullException>(() => repo.UpdateGroup(null!));
    }

    [Test]
    public void UpdateGroup_ForInvalidDate_ShouldThrowException()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IWatchPartyGroupRepository repo = new WatchPartyGroupRepository(context);
        WatchPartyGroup? group = repo.GetById(2);
        group.StartDate = new DateTime(2000, 5, 5, 10, 0, 0);

        // Act/Assert
        Assert.Throws<ArgumentException>(() => repo.UpdateGroup(group));
    }
}
