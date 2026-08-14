using Microsoft.Extensions.DependencyInjection;

namespace ToscaArtifactAutomation.Core.Runtime;

public interface IFlowPage { }

public interface IFlowRegistration
{
    void Register(IServiceCollection services);
}
