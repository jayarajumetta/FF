using ToscaArtifactAutomation.Core.Canonical;
using ToscaArtifactAutomation.Core.Runtime;
using ToscaArtifactAutomation.CLDC.CanonicalMaps;

namespace ToscaArtifactAutomation.CLDC.Pages;

public sealed class GLBasicPolicyFlowPage : IFlowPage
{
    private readonly CanonicalActionExecutor _executor;
    private readonly ScenarioDataContext _data;

    public GLBasicPolicyFlowPage(CanonicalActionExecutor executor, ScenarioDataContext data)
    {
        _executor = executor ?? throw new ArgumentNullException(nameof(executor));
        _data = data ?? throw new ArgumentNullException(nameof(data));
    }

    public Task ClientAndAccountAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(GLBasicPolicyCanonicalMap.ClientAndAccount, _data, cancellationToken);

    public Task ApplicationSetupAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(GLBasicPolicyCanonicalMap.ApplicationSetup, _data, cancellationToken);

}
