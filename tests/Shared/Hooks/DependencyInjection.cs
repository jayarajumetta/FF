using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Reqnroll.Microsoft.Extensions.DependencyInjection;
using ToscaArtifactAutomation.Core.Actions;
using ToscaArtifactAutomation.Core.Application;
using ToscaArtifactAutomation.Core.Browser;
using ToscaArtifactAutomation.Core.Canonical;
using ToscaArtifactAutomation.Core.Configuration;
using ToscaArtifactAutomation.Core.Locators;
using ToscaArtifactAutomation.Core.Reporting;
using ToscaArtifactAutomation.Core.Runtime;
using ToscaArtifactAutomation.Core.Utils;

namespace ToscaArtifactAutomation.Tests.Shared.Hooks;

public static class DependencyInjection
{
    [ScenarioDependencies]
    public static IServiceCollection CreateServices()
    {
        var services = new ServiceCollection();
        var settings = FrameworkSettingsLoader.Load();
        services.AddSingleton(settings);
        services.AddSingleton(settings.Framework);
        services.AddSingleton(settings.Application);
        services.AddSingleton<RunDataStore>();
        services.AddSingleton<LocatorCatalogProvider>();
        services.AddSingleton<RandomDataService>();
        services.AddSingleton<ToscaExpressionResolver>();
        services.AddScoped<ScenarioDataContext>();
        services.AddScoped<BrowserSession>();
        services.AddScoped<LocatorResolver>();
        services.AddScoped<UiActions>();
        services.AddScoped<UiAssertions>();
        services.AddScoped<ConditionEvaluator>();
        services.AddScoped<SystemActionService>();
        services.AddScoped<SourceInstructionExecutor>();
        services.AddScoped<CanonicalActionExecutor>();
        services.AddScoped<ApplicationSessionService>();
        services.AddScoped<StepExecutionTracker>();
        foreach (var registrationType in Assembly.GetExecutingAssembly().GetTypes().Where(t => typeof(IFlowRegistration).IsAssignableFrom(t) && t is { IsClass: true, IsAbstract: false }))
        {
            var registration = (IFlowRegistration)(Activator.CreateInstance(registrationType)
                ?? throw new InvalidOperationException($"Could not instantiate flow registration '{registrationType.FullName}'."));
            registration.Register(services);
        }
        return services;
    }
}
