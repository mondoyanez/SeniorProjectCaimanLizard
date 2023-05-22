using NuGet.Protocol.Plugins;
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
        WatchList watchList = repo.FindByUserID(1, 0);

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
        WatchList watchList = repo.FindByUserID(7, 0);

        // Assert
        Assert.That(watchList, Is.Null);
    }

    [Test]
    public void GetUsersWatchList_ForUserWitMultiplehWatchList_WatchListShouldBeCorrect()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IWatchListRepository repo = new WatchListRepository(context);

        // Act
        WatchList watchList = repo.FindByUserID(1, 1);

        // Assert
        Assert.IsTrue(watchList.Id == 7);
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
        IEnumerable<WatchListItem> watchListitems = repo.GetAllWatchListItemsByID(100);
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
        IEnumerable<WatchListItem> watchListitems = repo.GetAllWatchListItemsByID(100);

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
        bool exists = repo.ExistsWithDifferentId(3, 1);

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

    [Test]
    public void FindWatchListByUserID_ForUserWithOneList_IsNotNull()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IWatchListRepository repo = new WatchListRepository(context);

        // Act
        WatchList actual = repo.FindByUserID(1, 0);

        // Assert
        Assert.IsNotNull(actual);
    }

    [Test]
    public void FindWatchListByUserID_ForUserWithNoList_IsNull()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IWatchListRepository repo = new WatchListRepository(context);

        // Act
        WatchList actual = repo.FindByUserID(100, 0);

        // Assert
        Assert.IsNull(actual);
    }

    [Test]
    public void FindWatchListByUserID_ForUsersWithTwoLists_IsNotNull()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IWatchListRepository repo = new WatchListRepository(context);

        // Act
        WatchList actual = repo.FindByUserID(5, 1);

        // Assert
        Assert.IsNotNull(actual);
    }

    [Test]
    public void FindWatchListByUserID_UserWithTwoLists_FindsCorrectList()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IWatchListRepository repo = new WatchListRepository(context);

        // Act
        WatchList actual = repo.FindByUserID(5, 1);

        // Assert
        Assert.AreEqual(1, actual.ListType);
    }

    [Test]
    public void FindWatchListItem_UserWithNoItems_IsNull()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IWatchListItemRepository repo = new WatchListItemRepository(context);

        // Act
        IEnumerable<WatchListItem> items = repo.FindAllByShowId(5, 1);

        // Assert
        Assert.IsEmpty(items);
    }

    [Test]
    public void FindWatchListItem_UserWithOneItems_IsNotNull()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IWatchListItemRepository repo = new WatchListItemRepository(context);

        // Act
        IEnumerable<WatchListItem> items = repo.FindAllByShowId(1, 2);

        // Assert
        Assert.IsNotEmpty(items);
    }

    [Test]
    public void FindWatchListItem_UserWithMultipleItems_IsNotNull()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IWatchListItemRepository repo = new WatchListItemRepository(context);

        // Act
        IEnumerable<WatchListItem> items = repo.FindAllByShowId(1, 1);

        // Assert
        Assert.IsNotEmpty(items);
    }

    [Test]
    public void FindWatchListItem_UserWithMultipleItems_HasCorrectAmoun()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IWatchListItemRepository repo = new WatchListItemRepository(context);

        // Act
        IEnumerable<WatchListItem> items = repo.FindAllByShowId(1, 1);

        // Assert
        Assert.IsTrue(items.Count() == 3);
    }

    [Test]
    public void FilterResults_UserWithTwoLists_ReturnsNotNull_FirstList()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IWatchListItemRepository repo = new WatchListItemRepository(context);

        IEnumerable<WatchListItem> items = repo.FindAllByShowId(1, 1);

        // Act
        WatchListItem item = repo.FilterForCurrentWatchList(items, 1);

        // Assert
        Assert.IsNotNull(item);
    }

    [Test]
    public void FilterResults_UserWithTwoLists_ReturnsCorrectList_FirstList()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IWatchListItemRepository repo = new WatchListItemRepository(context);

        IEnumerable<WatchListItem> items = repo.FindAllByShowId(1, 1);

        // Act
        WatchListItem item = repo.FilterForCurrentWatchList(items, 1);

        // Assert
        Assert.IsTrue(item.Id == 1);
    }

    [Test]
    public void FilterResults_UserWithTwoLists_ReturnsNotNull_SecondList()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IWatchListItemRepository repo = new WatchListItemRepository(context);

        IEnumerable<WatchListItem> items = repo.FindAllByShowId(1, 1);

        // Act
        WatchListItem item = repo.FilterForCurrentWatchList(items, 7);

        // Assert
        Assert.IsNotNull(item);
    }

    [Test]
    public void FilterResults_UserWithTwoLists_ReturnsCorrectList_SecondList()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        IWatchListItemRepository repo = new WatchListItemRepository(context);

        IEnumerable<WatchListItem> items = repo.FindAllByShowId(1, 1);

        // Act
        WatchListItem item = repo.FilterForCurrentWatchList(items, 7);

        // Assert
        Assert.IsTrue(item.Id == 7);
    }

}

