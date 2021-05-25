using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using UserGroup.Web.Api;
using Microsoft.Extensions.DependencyInjection;
using UserGroup.Web.Tests.Api;

namespace UserGroup.Web.Tests
{
    public class WebApplicationFactory : WebApplicationFactory<Startup>
    {
        public TestableEventsClient Client { get; } = new();

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services => {
                services.AddScoped<IEventsClient, TestableEventsClient>(_ => Client);
            });
        }
    }
}
