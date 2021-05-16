using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserGroup.Web.Api;
using UserGroup.Web.Tests.Api;
using UserGroup.Web.ViewModels;

namespace UserGroup.Web.Tests
{
    [TestClass]
    public class EventsControllerTests
    {
        private WebApplicationFactory Factory { get; } = new();

        [TestMethod]
        [Ignore("Ignoring these now since we changed up the UI to use the API diectly instead of through the Contoller.")]
        public async Task Index_WithEvents_InvokesGetAllAsync()
        {
            //Arrange
            Event event1 = new() { Id = 1, Title = "Event 1" };
            Event event2 = new() { Id = 2, Title = "Event 2" };
            TestableEventsClient eventsClient = Factory.Client;
            eventsClient.GetAllEventsReturnValue = new List<Event>()
            {
                event1,
                event2
            };

            HttpClient client = Factory.CreateClient();

            //Act
            HttpResponseMessage response = await client.GetAsync("/Events/");

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.AreEqual(1, eventsClient.GetAllAsyncInvocationCount);
        }
    
        [TestMethod]
        [Ignore("Ignoring these now since we changed up the UI to use the API diectly instead of through the Contoller.")]
        public async Task Create_WithValidModel_InvokesPostAsync()
        {
            //Arrange
            HttpClient client = Factory.CreateClient();
            TestableEventsClient eventsClient = Factory.Client;

            Dictionary<string, string?> values = new()
            {
                { nameof(EventViewModel.Title), "Birthday" }
            };
            FormUrlEncodedContent content = new(values!);

            //Act
            HttpResponseMessage response = await client.PostAsync("/Events/Create", content);

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.AreEqual(1, eventsClient.PostAsyncInvocationCount);
            Assert.AreEqual(1, eventsClient.PostAsyncInvokedParameters.Count);
            Assert.AreEqual("Birthday", eventsClient.PostAsyncInvokedParameters[0].Title);
        }
    }
}
