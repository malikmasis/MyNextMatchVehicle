using EntityFrameworkCoreMock;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MNMVehicleMVC.Data;
using MNMVehicleMVC.Data.Models;
using MNMVehicleMVC.Model;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MNMVehicleMVC.Tests.UnitTest
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void Login()
        {
            var mock = new Mock<User>();
        }

        [TestMethod]
        public void Contact()
        {
            var user = new User();

            var mock = new Mock<postgresContext>();
            mock.Setup(p => p.SaveChanges()).Returns(1);

            using (var db = new postgresContext())
            {
                user.Name = "Malik";
                user.SurName = "Chanbaz";
                db.User.Add(user);
                var count = db.SaveChanges();
                Assert.AreEqual(count, 1);
            }
        }

        [TestMethod]
        public void About()
        {
        }

        //[TestMethod]
        //public void Add_writes_to_database()
        //{
        //    var options = new DbContextOptionsBuilder<postgresContext>()
        //        .UseInMemoryDatabase(databaseName: "postgres")
        //        .Options;

        //    // Run the test against one instance of the context
        //    using (var context = new postgresContext(options))
        //    {
        //        var service = new BlogService(context);
        //        service.Add("http://sample.com");
        //    }

        //    // Use a separate instance of the context to verify correct data was saved to database
        //    using (var context = new postgresContext(options))
        //    {
        //        Assert.AreEqual(1, context.User.CountAsync());
        //        Assert.AreEqual("http://sample.com", context.User.SingleAsync());
        //    }
        //}

        //[TestMethod]
        //public void Find_searches_url()
        //{
        //    var options = new DbContextOptionsBuilder<BloggingContext>()
        //        .UseInMemoryDatabase(databaseName: "Find_searches_url")
        //        .Options;

        //    // Insert seed data into the database using one instance of the context
        //    using (var context = new BloggingContext(options))
        //    {
        //        context.Blogs.Add(new Blog { Url = "http://sample.com/cats" });
        //        context.Blogs.Add(new Blog { Url = "http://sample.com/catfish" });
        //        context.Blogs.Add(new Blog { Url = "http://sample.com/dogs" });
        //        context.SaveChanges();
        //    }

        //    // Use a clean instance of the context to run the test
        //    using (var context = new BloggingContext(options))
        //    {
        //        var service = new BlogService(context);
        //        var result = service.Find("cat");
        //        Assert.AreEqual(2, result.Count());
        //    }
        //}



        [TestMethod]
        public void TestGetAllUsers()
        {
            //Arrange
            var mock = new Mock<IStoreAppContext>();
            mock.Setup(x => x.Set<User>())
                .Returns(new TestDbSet<User>
                {
            new User { Name = "he" }
                });

            //using (var db = new postgresContext())
            //{
            //    var VehicleList = db.User.ToList();
            //}

            //UserService userService = new UserService(mock.Object);

            // Act
            //var allUsers = userService.GetAllUsers();

            // Assert
            //Assert.AreEqual(1, allUsers.Count());
        }


        [TestMethod]
        public void CreateBlog_saves_a_blog_via_context()
        {
            var mockSet = new Mock<DbSet<User>>();

            var mockContext = new Mock<IStoreAppContext>();
            mockContext.Setup(m => m.User).Returns(mockSet.Object);

            var service = new UserService(mockContext.Object);
            service.AddBlog("malik", "masis");

            mockSet.Verify(m => m.Add(It.IsAny<User>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void GetAllBlogs_orders_by_name()
        {
            var data = new List<User>
            {
                new User { Name = "BBB" },
                new User { Name = "ZZZ" },
                new User { Name = "AAA" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<User>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<IStoreAppContext>();
            mockContext.Setup(c => c.User).Returns(mockSet.Object);

            var service = new UserService(mockContext.Object);
            var blogs = service.GetAllBlogs();

            Assert.AreEqual(3, blogs.Count);
            Assert.AreEqual("AAA", blogs[0].Name);
            Assert.AreEqual("BBB", blogs[1].Name);
            Assert.AreEqual("ZZZ", blogs[2].Name);
        }


        //[TestMethod]
        //public async Task GetAllBlogsAsync_orders_by_name()
        //{

        //    var data = new List<User>
        //    {
        //        new User { Name = "BBB" },
        //        new User { Name = "ZZZ" },
        //        new User { Name = "AAA" },
        //    }.AsQueryable();

        //    var mockSet = new Mock<DbSet<User>>();
        //    mockSet.As<DbAsyncEnumerable<User>>()
        //        .Setup(m => m.GetAsyncEnumerator())
        //        .Returns(new TestDbAsyncEnumerator<Blog>(data.GetEnumerator()));

        //    mockSet.As<IQueryable<Blog>>()
        //        .Setup(m => m.Provider)
        //        .Returns(new TestDbAsyncQueryProvider<Blog>(data.Provider));

        //    mockSet.As<IQueryable<Blog>>().Setup(m => m.Expression).Returns(data.Expression);
        //    mockSet.As<IQueryable<Blog>>().Setup(m => m.ElementType).Returns(data.ElementType);
        //    mockSet.As<IQueryable<Blog>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        //    var mockContext = new Mock<BloggingContext>();
        //    mockContext.Setup(c => c.Blogs).Returns(mockSet.Object);

        //    var service = new BlogService(mockContext.Object);
        //    var blogs = await service.GetAllBlogsAsync();

        //    Assert.AreEqual(3, blogs.Count);
        //    Assert.AreEqual("AAA", blogs[0].Name);
        //    Assert.AreEqual("BBB", blogs[1].Name);
        //    Assert.AreEqual("ZZZ", blogs[2].Name);
        //}
    }
}
