using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using UserGroup.Api.Controllers;
using System.Collections.Generic;
using UserGroup.Business;
using UserGroup.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using UserGroup.Api.Dto;
using System.Net.Http.Json;
using System.Threading.Tasks;
using UserGroup.Api.Tests.Business;

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

        [TestMethod]
        public async Task Put_WithValidData_UpdatesEvent()
        {
            //Arrange
            WebApplicationFactory factory = new();
            TestableEventManager manager = factory.Manager;
            Event foundEvent = new Event
            {
                Id = 42
            };
            manager.GetItemEvent = foundEvent;

            HttpClient client = factory.CreateClient();
            UpdateEvent updateEvent = new()
            {
                Title = "Casey's Birthday"
            };

            //Act
            HttpResponseMessage response = await client.PutAsJsonAsync("/api/events/42", updateEvent);

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.AreEqual("Casey's Birthday", manager.SavedEvent?.Title);
        }
    }
}