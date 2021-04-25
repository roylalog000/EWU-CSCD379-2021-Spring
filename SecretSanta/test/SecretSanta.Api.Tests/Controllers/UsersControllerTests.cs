using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using SecretSanta.Api.Controllers;
using SecretSanta.Business;
using SecretSanta.Data;
using Microsoft.AspNetCore.Mvc;
using System;

namespace SecretSanta.Api.Tests.Controllers
{
    [TestClass]
    public class EventsControllerTests
    {
        [TestMethod]
        public void Constructor_WithNullEventManager_ThrowsAppropriateException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new UsersController(null!));
        }

        [TestMethod]
        public void Get_WithData_ReturnsUsers()
        {
            //Arrange
            UsersController controller = new(new UserManager());

            //Act
            IEnumerable<User> users = controller.Get();

            //Assert
            Assert.IsTrue(users.Any());
        }

        [TestMethod]
        [DataRow(42)]
        [DataRow(98)]
        public void Get_WithId_ReturnsUserManagerUser(int id)
        {
            //Arrange
            TestableUserManager manager = new();
            UsersController controller = new(manager);
            User expectedUser = new();
            manager.GetItemUser = expectedUser;

            //Act
            ActionResult<User?> result = controller.Get(id);

            //Assert
            Assert.AreEqual(id, manager.GetItemId);
            Assert.AreEqual(expectedUser, result.Value);
        }

        [TestMethod]
        public void Get_WithNegativeId_ReturnsNotFound()
        {
            //Arrange
            TestableUserManager manager = new();
            UsersController controller = new(manager);
            User expectedUser = new();
            manager.GetItemUser = expectedUser;

            //Act
            ActionResult<User?> result = controller.Get(-1);

            //Assert
            Assert.IsTrue(result.Result is NotFoundResult);
        }

        // ???
        [TestMethod]
        [DataRow(0)]
        public void Delete_WithId_ReturnsOk(int id)
        {
            //Arrange
            TestableUserManager manager = new();
            UsersController controller = new(manager);
            User expectedUser = new();
            manager.GetItemUser = expectedUser;

            //Act
            ActionResult<User?> result = controller.Delete(id);

            //Assert
            Assert.IsTrue(result.Result is OkResult);
        }

        [TestMethod]
        public void Post_WithUser_ReturnsUser()
        {
            TestableUserManager manager = new();
            UsersController controller = new(manager);
            User expectedUser = new();
            manager.GetItemUser = expectedUser;

            ActionResult<User?> result = controller.Post(expectedUser);

            Assert.AreEqual(expectedUser,result.Value);
        }

        [TestMethod]
        public void Put_WithIdAndUser_ReturnOk()
        {
            TestableUserManager manager = new();
            UsersController controller = new(manager);
            User? expectedUser = new User() {Id=1, FirstName="Dallas", LastName="Soup"};
            User? ogUser = new User() {Id=1, FirstName="la", LastName="da"};
            manager.GetItemUser = ogUser;

            ActionResult<User?> result = controller.Put(expectedUser.Id,expectedUser);

            Assert.IsTrue(result.Result is OkResult);
        }

        private class TestableUserManager : IUserRepository
        {
            public User Create(User item)
            {
                return item;
            }

            public User? GetItemUser { get; set; }

            public int GetItemId { get; set; }
            public User? GetItem(int id)
            {
                GetItemId = id;
                return GetItemUser;
            }

            public ICollection<User> List()
            {
                throw new System.NotImplementedException();
            }

            // ???
            public bool Remove(int id)
            {
                UserManager manager = new();
                User? usercheck = manager.GetItem(id);
                usercheck = null;

                if (usercheck == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

            public void Save(User item)
            {
                GetItemUser = item;
            }
        }
    }
}