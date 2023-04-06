using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchParty.DAL.Abstract;
using WatchParty.DAL.Concrete;
using WatchParty.Models;

namespace WatchPartyTest;

public class WatchListRepository_Tests
{
    private static readonly string _seedFile = @"..\..\..\Data\watchListRepositorySeed.sql";
    private InMemoryDbHelper<WatchPartyDbContext> _dbHelper = new InMemoryDbHelper<WatchPartyDbContext>(_seedFile, DbPersistence.OneDbPerTest);

    [Test]
    public void GetUsersWatchList_ForUserWithWatchList_WatchListShouldNotBeNull()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IWatchListRepository repo = new WatchListRepository(context);

        // Act
        WatchList watchList = repo.FindByUserID(1);

        // Assert
        Assert.That(watchList, Is.Not.Null);
    }

    [Test]
    public void GetUsersWatchList_ForUserWithoutWatchList_WatchListShouldBeNull()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IWatchListRepository repo = new WatchListRepository(context);

        // Act
        WatchList watchList = repo.FindByUserID(7);

        // Assert
        Assert.That(watchList, Is.Null);
    }

    [Test]
    public void GetWatchListItems_ForUserWithItems_ShouldReturnNotNull()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IWatchListItemRepository repo = new WatchListItemRepository(context);

        // Act
        IEnumerable<WatchListItem> watchListitems = repo.GetAllWatchListItemsByID(1);

        // Assert
        Assert.That(watchListitems, Is.Not.Null);
    }

    [Test]
    public void GetWatchListItems_ForUserWithItems_ShouldReturnCountOf4()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IWatchListItemRepository repo = new WatchListItemRepository(context);

        // Act
        IEnumerable<WatchListItem> watchListitems = repo.GetAllWatchListItemsByID(1);
        int count = watchListitems.Count();

        // Assert
        Assert.AreEqual(4, count);
    }

    [Test]
    public void GetWatchListItems_ForUserWithoutItems_ShouldReturnCountOf0()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IWatchListItemRepository repo = new WatchListItemRepository(context);

        // Act
        IEnumerable<WatchListItem> watchListitems = repo.GetAllWatchListItemsByID(7);
        int count = watchListitems.Count();

        // Assert
        Assert.AreEqual(0, count);
    }

    [Test]
    public void GetWatchListItems_ForUserWithNoItems_ShouldReturnNull()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IWatchListItemRepository repo = new WatchListItemRepository(context);

        // Act
        IEnumerable<WatchListItem> watchListitems = repo.GetAllWatchListItemsByID(7);

        // Assert
        Assert.That(watchListitems, Is.Empty);
    }

    [Test]
    public void ExistsWithDifferentId_ForUserWithoutShow_ShouldReturnFalse()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IWatchListItemRepository repo = new WatchListItemRepository(context);

        // Act
        bool exists = repo.ExistsWithDifferentId(2, 1);

        //Assert
        Assert.That(exists, Is.False);
    }

    [Test]
    public void ExistsWithDifferentId_ForUserWithShow_ShouldReturnTrue()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IWatchListItemRepository repo = new WatchListItemRepository(context);

        // Act
        bool exists = repo.ExistsWithDifferentId(1, 1);

        //Assert
        Assert.That(exists, Is.True);
    }
}

