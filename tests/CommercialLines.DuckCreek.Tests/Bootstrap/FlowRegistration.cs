using Microsoft.Extensions.DependencyInjection;
using ToscaArtifactAutomation.Core.Runtime;
using ToscaArtifactAutomation.CLDC.Pages;

namespace ToscaArtifactAutomation.CLDC.Bootstrap;

public sealed class FlowRegistration : IFlowRegistration
{
    public void Register(IServiceCollection services)
    {
        services.AddScoped<BAPBasicPolicyFlowPage>();
        services.AddScoped<BAPExpandedFlowPage>();
        services.AddScoped<CPPBasicPolicyFlowPage>();
        services.AddScoped<CPBasicPolicyFlowPage>();
        services.AddScoped<GLBasicPolicyFlowPage>();
        services.AddScoped<GLOCPPolicyFlowPage>();
        services.AddScoped<IMBasicPolicyFlowPage>();
        services.AddScoped<UMBBasicPolicyFlowPage>();
        services.AddScoped<UMBExpandedFlowPage>();
        services.AddScoped<WCBasicPolicyFlowPage>();
        services.AddScoped<WCExpandedFlowPage>();
        services.AddScoped<BAPSmokeTestFlowPage>();
        services.AddScoped<CPSmokeTestFlowPage>();
        services.AddScoped<GLSmokeTestFlowPage>();
        services.AddScoped<IMSmokeTestFlowPage>();
        services.AddScoped<WCSmokeTestFlowPage>();
        services.AddScoped<CPPSmokeTestFlowPage>();
        services.AddScoped<UMBSmokeTestFlowPage>();
    }
}
