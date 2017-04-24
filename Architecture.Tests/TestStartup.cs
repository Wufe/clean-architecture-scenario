using Architecture;
using Architecture.Database;
using Architecture.Tests.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MyTested.AspNetCore.Mvc;

namespace Architecture.Tests
{
    public class TestStartup : Startup
    {
        public TestStartup(IHostingEnvironment env) : base(env)
        {
        }

        public void ConfigureTestServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
            //services.Replace<DataContext, DataContextTest>(ServiceLifetime.Scoped);
        }
    }
}
