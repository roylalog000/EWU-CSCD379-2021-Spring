using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using SecretSanta.Business;
using System;
using SecretSanta.Data;
using System.Collections.Generic;

namespace SecretSanta.Business.Tests
{
    [TestClass]
    public class UserManagerTests
    {
        [TestMethod]
        public void Create_WithUser_ReturnUser()
        {
            UserManager manager = new();
            User? newUser = new User() {Id=4, FirstName="Dallas", LastName="Soup"};
            User? createdUser = manager.Create(newUser);
            Assert.AreSame(newUser, createdUser);
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(2)]
        public void GetItem_WithId_ReturnsUserManagerUser(int id)
        {
            UserManager manager = new();
            User? foundUser = manager.GetItem(id);
            Assert.IsNotNull(foundUser);
        }

        [TestMethod]
        public void List_WithData_ReturnsUsers()
        {
            UserManager manager = new();
            IEnumerable<User> users = manager.List();
            Assert.IsTrue(users.Any());
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(2)]
        public void Remove_WithValidId_ReturnsTrue(int id)
        {
            UserManager manager = new();
            Assert.IsTrue(manager.Remove(id));
        }

        [TestMethod]
        [DataRow(42)]
        public void Remove_WithInvalidId_ReturnsFalse(int id)
        {
            UserManager manager = new();
            Assert.IsFalse(manager.Remove(id));
        }

        [TestMethod]
        public void Save_WithUser()
        {
            UserManager manager = new();
            User? newUser = new User() {Id=2, FirstName="Dallas", LastName="Soup"};
            manager.Save(newUser);
            User? updatedUser = manager.GetItem(newUser.Id);
            Assert.AreSame(newUser, updatedUser);
        }
    }
}