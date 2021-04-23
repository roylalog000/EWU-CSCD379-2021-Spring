using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using UserGroup.Api.Controllers;
using System.Collections.Generic;
using UserGroup.Business;
using UserGroup.Data;
using Microsoft.AspNetCore.Mvc;
using System;

namespace UserGroup.Api.Tests.Controllers
{
    [TestClass]
    public class EventsControllerTests
    {
        [TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_WithNullEventManager_ThrowsAppropriateException()
        {
            //Any of the approachs shown here are fine.
            ArgumentNullException ex = Assert.ThrowsException<ArgumentNullException>(
                () => new EventsController(null!));
            Assert.AreEqual("eventManager", ex.ParamName);

            try
            {
                new EventsController(null!);
            }
            catch(ArgumentNullException e)
            {
                Assert.AreEqual("eventManager", e.ParamName);
                return;
            }
            Assert.Fail("No exception thrown");
        }

        [TestMethod]
        public void Get_WithData_ReturnsEvents()
        {
            //Arrange
            EventsController controller = new(new EventManager());

            //Act
            IEnumerable<Event> events = controller.Get();

            //Assert
            Assert.IsTrue(events.Any());
        }
    
        [TestMethod]
        [DataRow(42)]
        [DataRow(98)]
        public void Get_WithId_ReturnsEventManagerEvent(int id)
        {
            //Arrange
            TestableEventManager manager = new();
            EventsController controller = new(manager);
            Event expectedEvent = new();
            manager.GetItemEvent = expectedEvent;

            //Act
            ActionResult<Event?> result = controller.Get(id);

            //Assert
            Assert.AreEqual(id, manager.GetItemId);
            Assert.AreEqual(expectedEvent, result.Value);
        }

        [TestMethod]
        public void Get_WithNegativeId_ReturnsNotFound()
        {
            //Arrange
            TestableEventManager manager = new();
            EventsController controller = new(manager);
            Event expectedEvent = new();
            manager.GetItemEvent = expectedEvent;

            //Act
            ActionResult<Event?> result = controller.Get(-1);

            //Assert
            Assert.IsTrue(result.Result is NotFoundResult);
        }

        private class TestableEventManager : IEventManager
        {
            public Event Create(Event item)
            {
                throw new System.NotImplementedException();
            }

            public Event? GetItemEvent { get; set; }
            public int GetItemId { get; set; }
            public Event? GetItem(int id)
            {
                GetItemId = id;
                return GetItemEvent;
            }

            public ICollection<Event> List()
            {
                throw new System.NotImplementedException();
            }

            public bool Remove(int id)
            {
                throw new System.NotImplementedException();
            }

            public void Save(Event item)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}