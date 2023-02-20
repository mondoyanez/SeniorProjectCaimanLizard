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
            //_watchers = new List<Watcher>
            //{
            //    new Watcher {1, "one", "SandraHart", "Sandra", "Hart", "sandra@mail.com", 0, 0, null}
            //};

            _watcher = new Watcher();
            _watcher.Id = 1;
            _watcher.Username = "SandraHart";
            _watcher.FirstName = "Sandra";
            _watcher.LastName = "Hart";

            
        }

        //[Test]
        //public void GetCorrectUsername_ReturnsSandraHart()
        //{
        //    IWatcherRepository watcherRepository = new WatcherRepository(_mockContext.Object);
        //}
    }
}
