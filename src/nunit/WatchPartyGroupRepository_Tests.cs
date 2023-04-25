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
}
