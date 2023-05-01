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
    public void FindGroup_ForExistingGroupWithAllValidData_ShouldReturnCorrectGroup()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IWatchPartyGroupRepository repo = new WatchPartyGroupRepository(context);
        Watcher host = context.Watchers.First(w => w.Id == 5);

        // Act
        WatchPartyGroup? actual = repo.FindGroup("Harry Potter marathon",
            "Going to watch all the Harry Potter movies in order all day", new DateTime(2023, 5, 5, 8, 0, 0), host,
            host.Id);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(actual?.Id, Is.EqualTo(2));
            Assert.That(actual?.GroupTitle, Is.EqualTo("Harry Potter marathon"));
            Assert.That(actual?.GroupDescription, Is.EqualTo("Going to watch all the Harry Potter movies in order all day"));
            Assert.That(actual?.StartDate, Is.EqualTo(new DateTime(2023, 5, 5, 8, 0, 0)));
            Assert.That(actual?.Host.AspNetIdentityId, Is.EqualTo("561e79b0-24be-4f8b-96dd-056b493cd7e5"));
            Assert.That(actual?.HostId, Is.EqualTo(5));
        });
    }

    [Test]
    public void FindGroup_ForExistingGroupWithDescriptionAsNull_ShouldReturnCorrectGroup()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IWatchPartyGroupRepository repo = new WatchPartyGroupRepository(context);
        Watcher host = context.Watchers.First(w => w.Id == 1);

        // Act
        WatchPartyGroup? actual = repo.FindGroup("Marvel marathon movie night",
            null, new DateTime(2023, 5, 5, 20, 0, 0), host,
            host.Id);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(actual?.Id, Is.EqualTo(1));
            Assert.That(actual?.GroupTitle, Is.EqualTo("Marvel marathon movie night"));
            Assert.That(actual?.GroupDescription, Is.Null);
            Assert.That(actual?.StartDate, Is.EqualTo(new DateTime(2023, 5, 5, 20, 0, 0)));
            Assert.That(actual?.Host.AspNetIdentityId, Is.EqualTo("571e79b0-24be-4f8b-96dd-056b493cd7c5"));
            Assert.That(actual?.HostId, Is.EqualTo(1));
        });
    }

    [Test]
    public void FindGroup_ForNonExistingGroup_ShouldReturnNull()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IWatchPartyGroupRepository repo = new WatchPartyGroupRepository(context);
        Watcher host = context.Watchers.First(w => w.Id == 1);

        // Act
        WatchPartyGroup? actual = repo.FindGroup("Movie night",
            null, new DateTime(2023, 5, 2, 3, 0, 0), host,
            host.Id);

        // Assert
        Assert.That(actual, Is.Null);
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
            Assert.That(actual?.StartDate, Is.EqualTo(new DateTime(2023, 5, 5, 8, 0, 0)));
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
}
