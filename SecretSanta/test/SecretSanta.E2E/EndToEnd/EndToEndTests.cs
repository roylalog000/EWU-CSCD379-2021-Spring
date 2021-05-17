using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlaywrightSharp;
using System.Linq;

namespace SecretSanta.Web.Tests
{
    [TestClass]
    public class EndToEndTests
    {
        private static WebHostServerFixture<Web.Startup, SecretSanta.Api.Startup> Server;

        [ClassInitialize]
        public static void InitializeClass(TestContext testContext)
        {
            Server = new();
        }

        [TestMethod]
        public async Task LaunchHomepage()
        {
            var localhost = Server.WebRootUri.AbsoluteUri.Replace("127.0.0.1", "localhost");
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new LaunchOptions
            {
                Headless = true,
            });

            var page = await browser.NewPageAsync();
            var response = await page.GoToAsync(localhost);

            Assert.IsTrue(response.Ok);

            var headerContent = await page.GetTextContentAsync("body > header > div > a");
            Assert.AreEqual("Secret Santa", headerContent);
        }

        [TestMethod]
        public async Task CreateUser()
        {
            var localhost = Server.WebRootUri.AbsoluteUri.Replace("127.0.0.1", "localhost");
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new LaunchOptions
            {
                Headless = true,
            });

            var page = await browser.NewPageAsync();
            var response = await page.GoToAsync(localhost);

            Assert.IsTrue(response.Ok);

            await page.ClickAsync("text=Users");

            await page.ScreenshotAsync("create.png");

            // make sure we have 5 speakers here
            var users = await page.QuerySelectorAllAsync("body > section > section > section");
            Assert.AreEqual(5,users.Count());

            await page.ClickAsync("text=Create");

            await page.TypeAsync("input#FirstName", "Sausage");
            await page.TypeAsync("input#LastName", "Casing");

            await page.ClickAsync("text=Create");

            // make sure we have 5+1 speakers here
            users = await page.QuerySelectorAllAsync("body > section > section > section");
            Assert.AreEqual(6,users.Count());
        }

        [TestMethod]
        public async Task DeleteUser()
        {
            var localhost = Server.WebRootUri.AbsoluteUri.Replace("127.0.0.1", "localhost");
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new LaunchOptions
            {
                Headless = true,
            });

            var page = await browser.NewPageAsync();
            var response = await page.GoToAsync(localhost);

            Assert.IsTrue(response.Ok);

            await page.ClickAsync("text=Users");

            page.Dialog += (_, args) => args.Dialog.AcceptAsync();

            await page.ClickAsync("body > section > section > section:last-child > a > section > button");

            var users = await page.QuerySelectorAllAsync("body > section > section > section");
            Assert.AreEqual(5, users.Count());
        }

        [TestMethod]
        public async Task EditUser()
        {
            var localhost = Server.WebRootUri.AbsoluteUri.Replace("127.0.0.1", "localhost");
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new LaunchOptions
            {
                Headless = true,
            });

            var page = await browser.NewPageAsync();
            var response = await page.GoToAsync(localhost);

            Assert.IsTrue(response.Ok);

            await page.ClickAsync("text=Users");

            var sectionText = await page.GetTextContentAsync("body > section > section > section:last-child");

            Assert.IsTrue(sectionText.Contains("Miracle Max"));
        }
    }
}