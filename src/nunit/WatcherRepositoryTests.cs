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
    }
}
