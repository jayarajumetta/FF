using Microsoft.Extensions.DependencyInjection;
using Reqnroll.Microsoft.Extensions.DependencyInjection;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Hooks;

public static class DependencyInjection
{
    [ScenarioDependencies]
    public static IServiceCollection CreateServices()
    {
        var services = new ServiceCollection();
        services.AddScoped<BrowserSession>();
        services.AddScoped<ScenarioData>();
        services.AddScoped<RecoveryManager>();
        return services;
    }
}
