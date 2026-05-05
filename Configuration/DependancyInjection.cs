using Microsoft.Extensions.DependencyInjection;
using Playwright_POC;
using Reqnroll;
using Reqnroll.Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    [ScenarioDependencies]
    public static IServiceCollection CreateServices()
    {
        var services = new ServiceCollection();

        // Call your Startup.cs configuration
        var startup = new Startup();
        startup.ConfigureServices(services);

        return services;
    }
}
