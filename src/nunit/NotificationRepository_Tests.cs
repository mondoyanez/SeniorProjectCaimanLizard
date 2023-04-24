using NuGet.Protocol.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchParty.DAL.Abstract;
using WatchParty.DAL.Concrete;
using WatchParty.Models;
using WatchParty.ViewModels;

namespace WatchPartyTest;

public class NotificationRepository_Tests
{
    private static readonly string _seedFile = @"..\..\..\Data\notificationRepositorySeed.sql";
    private InMemoryDbHelper<WatchPartyDbContext> _dbHelper = new InMemoryDbHelper<WatchPartyDbContext>(_seedFile, DbPersistence.OneDbPerTest);

    [Test]
    public void GetNotifications_ForEmptyUserList_ShouldBeEmpty()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        INotificationRepository repo = new NotificationRepository(context);

        // Act
        IEnumerable<Notification> notifications = repo.FindAllByUserID(6);

        // Assert
        Assert.That(notifications, Is.Empty);
    }

    [Test]
    public void GetNotifications_WithWrongUserID_RetrunsException()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        INotificationRepository repo = new NotificationRepository(context);

        // Act


        // Assert
        Assert.Throws<ArgumentNullException>(() => repo.FindAllByUserID(1002));
    }

    //[Test]
    //public void GetUsersWatchList_ForUserWithWatchList_WatchListShouldNotBeNull()
    //{
    //    // Arrange
    //    using WatchPartyDbContext context = _dbHelper.GetContext();
    //    IWatchListRepository repo = new WatchListRepository(context);

    //    // Act
    //    WatchList watchList = repo.FindByUserID(1, 0);

    //    // Assert
    //    Assert.That(watchList, Is.Not.Null);
    //}
}