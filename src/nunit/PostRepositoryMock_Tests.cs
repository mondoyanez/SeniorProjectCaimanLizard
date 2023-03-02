using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using WatchParty.DAL.Abstract;
using WatchParty.DAL.Concrete;
using WatchParty.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WatchPartyTest;
public class PostRepositoryMock_Tests
{
    private Mock<WatchPartyDbContext> _mockContext;
    private Mock<DbSet<Post>> _mockPostDbSet;
    private List<Post> _posts;
    private List<Watcher> _watchers;

    [SetUp]
    public void Setup()
    {
        _watchers = new List<Watcher>
        {
            new Watcher
            {
                Id = 1, AspNetIdentityId = "571e79b0-24be-4f8b-96dd-056b493cd7c5", Username = "SandraHart",
                FirstName = "Sandra", LastName = "Hart",
                Email = "SandraHart@email.com", FollowerCount = 0, FollowingCount = 0,
                Bio = "This is my bio that I filled in but couldn't decided what to make it"
            },
            new Watcher
            {
                Id = 2, AspNetIdentityId = "231e79b0-24be-4f8b-96dd-056b493cd7c5", Username = "CarsonDaniel",
                FirstName = "Carson", LastName = "Daniel",
                Email = "CarsonDaniel@domain.net", FollowerCount = 15, FollowingCount = 45,
                Bio = null
            },
            new Watcher
            {
                Id = 3, AspNetIdentityId = "561e79b0-24bf-4f8b-96dd-056b493cd7c5", Username = "JosefMeyer",
                FirstName = "Josef", LastName = "Meyer",
                Email = "JosefMeyer@mail.edu", FollowerCount = 1000, FollowingCount = 10,
                Bio = null
            }
        };

        _posts = new List<Post>
        {
            new Post
            {
                Id = 1, PostTitle = "That new Ant-man movie was incredible!", PostDescription = null,
                DatePosted = new DateTime(2023, 1, 15, 17, 0, 0), UserId = 2
            },
            new Post
            {
                Id = 2, PostTitle = "Spider-man", PostDescription = "So excited for the new spider man movies!",
                DatePosted = new DateTime(2023, 2, 1, 15, 0, 0), UserId = 1
            },
            new Post
            {
                Id = 3, PostTitle = "Best comedy of 2023?", PostDescription = null,
                DatePosted = new DateTime(2022, 12, 25, 12, 0, 0), UserId = 1
            }
        };

        _posts.ForEach(p =>
        {
            p.User = _watchers.Single(user => user.Id == p.UserId);
        });

        _mockContext = new Mock<WatchPartyDbContext>();
        _mockPostDbSet = MockHelpers.GetMockDbSet(_posts.AsQueryable());
        _mockContext.Setup(ctx => ctx.Posts).Returns(_mockPostDbSet.Object);
        _mockContext.Setup(ctx => ctx.Set<Post>()).Returns(_mockPostDbSet.Object);
    }

    [Test]
    public void NumberOfPosts_WithThreePosts_ReturnsThree()
    {
        // Arrange
        IPostRepository postRepository = new PostRepository(_mockContext.Object);

        // Act
        int actual = postRepository.GetAll().Count();

        // Assert
        Assert.That(actual, Is.EqualTo(3));
    }
}

