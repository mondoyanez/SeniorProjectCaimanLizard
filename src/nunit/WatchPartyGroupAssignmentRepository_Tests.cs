using WatchParty.DAL.Abstract;
using WatchParty.DAL.Concrete;
using WatchParty.Models;

namespace WatchPartyTest;

/**
 * This is the recommended way to test using the in-memory db.  Seed the db and then write your tests based only on the seed
 * data + anything else you do to it.  No other tests will modify the db for that test.  Every test gets a brand new seeded db.
 * 
 */

public class WatchPartyGroupAssignmentRepository_Tests
{
    private static readonly string
        _seedFile =
            @"..\..\..\Data\WatchPartyGroupAssignmentSeed.sql"; // relative path of WatchPartyTest from where the executable is: bin/Debug/net7.0

    private static readonly string _seedFilePostEmpty = @"..\..\..\Data\WatchPartyGroupAssignmentSeedEmpty.sql";

    // Create this helper like this, for whatever context you desire
    private InMemoryDbHelper<WatchPartyDbContext> _dbHelper =
        new InMemoryDbHelper<WatchPartyDbContext>(_seedFile, DbPersistence.OneDbPerTest);

    private InMemoryDbHelper<WatchPartyDbContext> _dbHelperPostEmpty =
        new InMemoryDbHelper<WatchPartyDbContext>(_seedFilePostEmpty, DbPersistence.OneDbPerTest);

    [Test]
    public void AddToGroup_WithValidData_ShouldSuccessfullyAddObject()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IWatchPartyGroupAssignmentRepository repo = new WatchPartyGroupAssignmentRepository(context);
        // The db has been seeded

        WatchPartyGroup? group = context.WatchPartyGroups.FirstOrDefault(g => g.Id == 1);
        Watcher? watcher = context.Watchers.FirstOrDefault(w => w.Id == 4);

        WatchPartyGroupAssignment assignment = new WatchPartyGroupAssignment
        {
            GroupId = group.Id,
            Group = group,
            WatcherId = watcher.Id,
            Watcher = watcher
        };

        // Act
        repo.AddToGroup(assignment);
        int count = repo.GetAll().Count();

        // Assert
        Assert.That(count, Is.EqualTo(13));
    }

    [Test]
    public void AddToGroup_WithValidDataButUserIsAlreadyInGroup_ShouldThrowAnException()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IWatchPartyGroupAssignmentRepository repo = new WatchPartyGroupAssignmentRepository(context);
        // The db has been seeded

        WatchPartyGroup? group = context.WatchPartyGroups.FirstOrDefault(g => g.Id == 1);
        Watcher? watcher = context.Watchers.FirstOrDefault(w => w.Id == 2);

        WatchPartyGroupAssignment assignment = new WatchPartyGroupAssignment
        {
            GroupId = group.Id,
            Group = group,
            WatcherId = watcher.Id,
            Watcher = watcher
        };

        // Act/Assert
        Assert.Throws<Exception>(() => repo.AddToGroup(assignment));
    }

    [Test]
    public void AddToGroup_WithInValidData_ShouldThrowAnException()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IWatchPartyGroupAssignmentRepository repo = new WatchPartyGroupAssignmentRepository(context);
        // The db has been seeded

        WatchPartyGroup? group = context.WatchPartyGroups.FirstOrDefault(g => g.Id == 1);

        WatchPartyGroupAssignment assignment = new WatchPartyGroupAssignment
        {
            GroupId = group.Id,
            Group = group
        };

        // Act/Assert
        Assert.Throws<Exception>(() => repo.AddToGroup(assignment));
    }

    [Test]
    public void AddToGroup_AssignmentIsNull_ShouldThrowAnException()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IWatchPartyGroupAssignmentRepository repo = new WatchPartyGroupAssignmentRepository(context);
        // The db has been seeded
        WatchPartyGroupAssignment assignment = null!;

        // Act/Assert
        Assert.Throws<ArgumentNullException>(() => repo.AddToGroup(assignment));
    }

    [Test]
    public void GetGroupIds_UserInThreeGroups_ShouldReturnThreeGroupIds()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IWatchPartyGroupAssignmentRepository repo = new WatchPartyGroupAssignmentRepository(context);

        // Act
        List<int> actual = repo.GetGroupIds(1);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(actual.Count, Is.EqualTo(3));
            Assert.That(actual.First(), Is.EqualTo(1));
            Assert.That(actual.Last(), Is.EqualTo(3));
        });
    }

    [Test]
    public void GetGroupIds_UserInOneGroup_ShouldReturnOneGroupId()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IWatchPartyGroupAssignmentRepository repo = new WatchPartyGroupAssignmentRepository(context);

        // Act
        List<int> actual = repo.GetGroupIds(10);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(actual.Count, Is.EqualTo(1));
            Assert.That(actual.First(), Is.EqualTo(3));
            Assert.That(actual.Last(), Is.EqualTo(3));
        });
    }

    [Test]
    public void GetGroupIds_UserIsNotInAnyGroup_ShouldReturnEmptyList()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IWatchPartyGroupAssignmentRepository repo = new WatchPartyGroupAssignmentRepository(context);

        // Act
        List<int> actual = repo.GetGroupIds(11);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(actual, Is.Empty);
        });
    }

    [Test]
    public void GetGroupIds_UserIdDoesNotExist_ShouldReturnEmptyList()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IWatchPartyGroupAssignmentRepository repo = new WatchPartyGroupAssignmentRepository(context);

        // Act
        List<int> actual = repo.GetGroupIds(110);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(actual, Is.Empty);
        });
    }
}
