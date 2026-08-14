using ToscaArtifactAutomation.Core.Canonical;
using ToscaArtifactAutomation.Core.Runtime;
using ToscaArtifactAutomation.PLDC.CanonicalMaps;

namespace ToscaArtifactAutomation.PLDC.Pages;

public sealed class SmokeTestAutoFlowPage : IFlowPage
{
    private readonly CanonicalActionExecutor _executor;
    private readonly ScenarioDataContext _data;

    public SmokeTestAutoFlowPage(CanonicalActionExecutor executor, ScenarioDataContext data)
    {
        _executor = executor ?? throw new ArgumentNullException(nameof(executor));
        _data = data ?? throw new ArgumentNullException(nameof(data));
    }

    public Task ClientAndAccountAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(SmokeTestAutoCanonicalMap.ClientAndAccount, _data, cancellationToken);

    public Task ProposalStartAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(SmokeTestAutoCanonicalMap.ProposalStart, _data, cancellationToken);

    public Task VerificationAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(SmokeTestAutoCanonicalMap.Verification, _data, cancellationToken);

}
