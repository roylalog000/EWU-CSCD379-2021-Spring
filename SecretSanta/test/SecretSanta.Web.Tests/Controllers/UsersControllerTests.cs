using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SecretSanta.Web.Tests
{
    [TestClass]
    public class UsersControllerTests
    {
        private WebApplicationFactory Factory { get; } = new();

        [TestMethod]
        public async Task Index_WithUsers_InvokesGetAllAsync()
        {
            //Arrange
            HttpClient client = Factory.CreateClient();

            //Act
            HttpResponseMessage response = await client.GetAsync("/Users");

            //Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
