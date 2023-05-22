using NuGet.Protocol.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
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
    public void GetNotification_WithUserWith2Notification_returnsListOfSize2()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        INotificationRepository repo = new NotificationRepository(context);

        // Act
        IEnumerable<Notification> notifications = repo.FindAllByUserID(1);

        // Assert
        Assert.AreEqual(notifications.Count(), 2);
    }

    [Test]
    public void GetNotification_WithUserWith2Notifications_ReturnsCorrectNotifications()
    {
        // Arrange
        using WatchPartyDbContext context = _dbHelper.GetContext();
        INotificationRepository repo = new NotificationRepository(context);

        // Act
        IEnumerable<Notification> notifications = repo.FindAllByUserID(1);
        Notification notification = notifications.First();

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(notification.Id, Is.EqualTo(1));
            Assert.That(notification.NotifierId, Is.EqualTo(1));
            Assert.That(notification.Content, Is.EqualTo("Your watch party is scheduled for 4/25/13 at 6:00 pm"));
            Assert.That(notification.IsRead, Is.False);
            Assert.That(notification.CreatedAt.ToString("yyyy-MM-dd hh:mm:ss"), Is.EqualTo("2023-04-22 12:00:00"));
        });
    }
}