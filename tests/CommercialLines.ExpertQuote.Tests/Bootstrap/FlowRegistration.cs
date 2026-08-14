using Microsoft.Extensions.DependencyInjection;
using ToscaArtifactAutomation.Core.Runtime;
using ToscaArtifactAutomation.CLEQ.Pages;

namespace ToscaArtifactAutomation.CLEQ.Bootstrap;

public sealed class FlowRegistration : IFlowRegistration
{
    public void Register(IServiceCollection services)
    {
        services.AddScoped<EQBOPBasicPolicyFlowPage>();
        services.AddScoped<EQBOPSmokeTestFlowPage>();
        services.AddScoped<EQSFPSmokeTestFlowPage>();
        services.AddScoped<EQSFPBasicPolicyFlowPage>();
        services.AddScoped<EQSFPCountryEstatePolicyFlowPage>();
    }
}
