using Microsoft.Extensions.DependencyInjection;
using ToscaArtifactAutomation.Core.Runtime;
using ToscaArtifactAutomation.PLDC.Pages;

namespace ToscaArtifactAutomation.PLDC.Bootstrap;

public sealed class FlowRegistration : IFlowRegistration
{
    public void Register(IServiceCollection services)
    {
        services.AddScoped<AutoRateFilingsPolicy1NBFlowPage>();
        services.AddScoped<AutoRateFilingsPolicy3NBPriorEffDateFlowPage>();
        services.AddScoped<AutoRateFilingsCommonPolicyNBFlowPage>();
        services.AddScoped<AutoRateFilingsCommonPolicyNBPriorEffDateFlowPage>();
        services.AddScoped<CycleRateFilingsPolicy1NB1FlowPage>();
        services.AddScoped<CycleRateFilingsPolicy3NBPriorEffDateFlowPage>();
        services.AddScoped<SmokeTestAutoFlowPage>();
        services.AddScoped<SmokeTestCycleFlowPage>();
        services.AddScoped<SmokeTestRVFlowPage>();
    }
}
