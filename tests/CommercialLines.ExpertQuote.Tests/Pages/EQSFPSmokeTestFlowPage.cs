using ToscaArtifactAutomation.Core.Canonical;
using ToscaArtifactAutomation.Core.Runtime;
using ToscaArtifactAutomation.CLEQ.CanonicalMaps;

namespace ToscaArtifactAutomation.CLEQ.Pages;

public sealed class EQSFPSmokeTestFlowPage : IFlowPage
{
    private readonly CanonicalActionExecutor _executor;
    private readonly ScenarioDataContext _data;

    public EQSFPSmokeTestFlowPage(CanonicalActionExecutor executor, ScenarioDataContext data)
    {
        _executor = executor ?? throw new ArgumentNullException(nameof(executor));
        _data = data ?? throw new ArgumentNullException(nameof(data));
    }

    public Task ClientAndAccountAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(EQSFPSmokeTestCanonicalMap.ClientAndAccount, _data, cancellationToken);

    public Task ProposalStartAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(EQSFPSmokeTestCanonicalMap.ProposalStart, _data, cancellationToken);

    public Task IdentityAndPrefillAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(EQSFPSmokeTestCanonicalMap.IdentityAndPrefill, _data, cancellationToken);

    public Task PolicyDetailsAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(EQSFPSmokeTestCanonicalMap.PolicyDetails, _data, cancellationToken);

    public Task VerificationAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(EQSFPSmokeTestCanonicalMap.Verification, _data, cancellationToken);

}
