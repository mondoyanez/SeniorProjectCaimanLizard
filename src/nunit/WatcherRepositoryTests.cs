using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchParty.Models;
using Microsoft.EntityFrameworkCore;
using WatchParty.DAL.Abstract;
using WatchParty.DAL.Concrete;
using Moq;

namespace WatchPartyTest
{
    public class WatcherRepositoryTests
    {
        private List<Watcher> _watchers;
        private Watcher _watcher;
        private Mock<WatchPartyDbContext> _mockContext;
        private Mock<DbSet<Watcher>> _dbSet;

        [SetUp]
        public void Setup()
        {
            _watchers = new List<Watcher>()
            {
                new Watcher { Id=1, AspNetIdentityId="one", Username="SandraHart", FirstName="Sandra", LastName="Hart" },
                new Watcher { Id=2, AspNetIdentityId="two", Username="CarsonDaniel", FirstName="Carson"},
                new Watcher { Id=3, AspNetIdentityId="three", Username=null}
            };

            _watcher = new Watcher { Id = 1, AspNetIdentityId = "one", Username = "SandraHart", FirstName = "Sandra", LastName = "Hart" };

            _mockContext = new Mock<WatchPartyDbContext>();
            _dbSet = MockHelpers.GetMockDbSet(_watchers.AsQueryable());
            _mockContext.Setup(ctx => ctx.Watchers).Returns(_dbSet.Object);
            _mockContext.Setup(ctx => ctx.Set<Watcher>()).Returns(_dbSet.Object);
        }

        [Test]
        public void GetCorrectUsername_ReturnsSandraHart()
        {
            _mockContext.Setup(ctx => ctx.Watchers).Returns(_dbSet.Object);
            _mockContext.Setup(ctx => ctx.Set<Watcher>()).Returns(_dbSet.Object);
            IWatcherRepository watcherRepository = new WatcherRepository(_mockContext.Object);

            string expected = "SandraHart";
            string actual = watcherRepository.FindByUsername(expected).Username;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void wrongUsername_ReturnsNull()
        {
            _mockContext.Setup(ctx => ctx.Watchers).Returns(_dbSet.Object);
            _mockContext.Setup(ctx => ctx.Set<Watcher>()).Returns(_dbSet.Object);
            IWatcherRepository watcherRepository = new WatcherRepository(_mockContext.Object);
            Watcher expected = null;
            Watcher actual = watcherRepository.FindByUsername("wrong");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetAspNetId_ProperIdProvided_ReturnsCorrectId()
        {
            // Arrange
            _mockContext.Setup(ctx => ctx.Watchers).Returns(_dbSet.Object);
            _mockContext.Setup(ctx => ctx.Set<Watcher>()).Returns(_dbSet.Object);
            IWatcherRepository watcherRepository = new WatcherRepository(_mockContext.Object);

            // Act
            Watcher? actual = watcherRepository.FindByAspNetId("one");


            // Assert
            Assert.That(actual.AspNetIdentityId, Is.EqualTo("one"));
        }

        [Test]
        public void GetAspNetId_ProvidesProperId_ChecksIfGivenWrongIdReturnsNotEqualToId()
        {
            // Arrange
            _mockContext.Setup(ctx => ctx.Watchers).Returns(_dbSet.Object);
            _mockContext.Setup(ctx => ctx.Set<Watcher>()).Returns(_dbSet.Object);
            IWatcherRepository watcherRepository = new WatcherRepository(_mockContext.Object);

            // Act
            Watcher? actual = watcherRepository.FindByAspNetId("two");


            // Assert
            Assert.That(actual?.AspNetIdentityId, Is.Not.EqualTo("one"));
        }

        [Test]
        public void GetAspNetId_GibberishPassedInForId_ReturnsNull()
        {
            // Arrange
            _mockContext.Setup(ctx => ctx.Watchers).Returns(_dbSet.Object);
            _mockContext.Setup(ctx => ctx.Set<Watcher>()).Returns(_dbSet.Object);
            IWatcherRepository watcherRepository = new WatcherRepository(_mockContext.Object);

            // Assert
            Assert.Throws<ArgumentNullException>(() => watcherRepository.FindByAspNetId("fhjdsahifueoinvoi"));
        }

        [Test]
        public void GetAspNetId_NullIsPassedForId_ReturnsNull()
        {
            // Arrange
            _mockContext.Setup(ctx => ctx.Watchers).Returns(_dbSet.Object);
            _mockContext.Setup(ctx => ctx.Set<Watcher>()).Returns(_dbSet.Object);
            IWatcherRepository watcherRepository = new WatcherRepository(_mockContext.Object);

            // Assert
            Assert.Throws<ArgumentNullException>(() => watcherRepository.FindByAspNetId(null!));
        }

        [Test]
        public void GetAspNetId_ProperIdPassedButIdIsNull_ReturnsNull()
        {
            // Arrange
            _mockContext.Setup(ctx => ctx.Watchers).Returns(_dbSet.Object);
            _mockContext.Setup(ctx => ctx.Set<Watcher>()).Returns(_dbSet.Object);
            IWatcherRepository watcherRepository = new WatcherRepository(_mockContext.Object);

            // Act
            Watcher? actual = watcherRepository.FindByAspNetId("three");
            actual.AspNetIdentityId = null!;

            // Assert
            Assert.That(actual?.AspNetIdentityId, Is.Null);
        }

        [Test]
        public void FindAllWatchers_WithThreeExistingUsers_ShouldReturnThreeUsers()
        {
            // Arrange
            _mockContext.Setup(ctx => ctx.Watchers).Returns(_dbSet.Object);
            _mockContext.Setup(ctx => ctx.Set<Watcher>()).Returns(_dbSet.Object);
            IWatcherRepository watcherRepository = new WatcherRepository(_mockContext.Object);

            // Act
            List<Watcher>? actual = watcherRepository.FindAllWatchers();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(actual.Count, Is.EqualTo(3));

                Assert.That(actual.First().Id, Is.EqualTo(1));
                Assert.That(actual.First().AspNetIdentityId, Is.EqualTo("one"));
                Assert.That(actual.First().Username, Is.EqualTo("SandraHart"));
                Assert.That(actual.First().FirstName, Is.EqualTo("Sandra"));
                Assert.That(actual.First().LastName, Is.EqualTo("Hart"));
                Assert.That(actual.First().Email, Is.Null);
                Assert.That(actual.First().Bio, Is.Null);
                Assert.That(actual.First().WatchListPrivacy, Is.False);

                Assert.That(actual.Last().Id, Is.EqualTo(3));
                Assert.That(actual.Last().AspNetIdentityId, Is.EqualTo("three"));
                Assert.That(actual.Last().Username, Is.Null);
                Assert.That(actual.Last().FirstName, Is.Null);
                Assert.That(actual.Last().LastName, Is.Null);
                Assert.That(actual.Last().Email, Is.Null);
                Assert.That(actual.Last().Bio, Is.Null);
                Assert.That(actual.Last().WatchListPrivacy, Is.False);
            });
        }

        [Test]
        public void FindAllWatchers_WithNoUsers_ReturnsZero()
        {
            // Arrange
            _watchers.Clear();
            _mockContext = new Mock<WatchPartyDbContext>();
            _dbSet = MockHelpers.GetMockDbSet(_watchers.AsQueryable());
            _mockContext.Setup(ctx => ctx.Watchers).Returns(_dbSet.Object);
            _mockContext.Setup(ctx => ctx.Set<Watcher>()).Returns(_dbSet.Object);
            IWatcherRepository watcherRepository = new WatcherRepository(_mockContext.Object);

            // Act
            List<Watcher>? actual = watcherRepository.FindAllWatchers();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.Empty);
                Assert.That(actual.Count, Is.EqualTo(0));
            });

        }
    }
}
