using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using UserGroup.Api.Tests.Business;
using UserGroup.Business;

namespace UserGroup.Api.Tests
{
    public class WebApplicationFactory : WebApplicationFactory<Startup>
    {
        public TestableEventManager Manager { get; } = new();
        
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services => {
                services.AddScoped<IEventManager, TestableEventManager>(_ => Manager);
            });
        }
    }
}
