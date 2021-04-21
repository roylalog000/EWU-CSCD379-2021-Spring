using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using UserGroup.Api.Controllers;
using System.Collections.Generic;
using UserGroup.Business;
using UserGroup.Data;

namespace UserGroup.Api.Tests.Controllers
{
    [TestClass]
    public class EventsControllerTests
    {
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
    }
}