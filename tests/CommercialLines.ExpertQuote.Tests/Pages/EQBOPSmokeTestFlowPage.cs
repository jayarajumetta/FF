using ToscaArtifactAutomation.Core.Canonical;
using ToscaArtifactAutomation.Core.Runtime;
using ToscaArtifactAutomation.CLEQ.CanonicalMaps;

namespace ToscaArtifactAutomation.CLEQ.Pages;

public sealed class EQBOPSmokeTestFlowPage : IFlowPage
{
    private readonly CanonicalActionExecutor _executor;
    private readonly ScenarioDataContext _data;

    public EQBOPSmokeTestFlowPage(CanonicalActionExecutor executor, ScenarioDataContext data)
    {
        _executor = executor ?? throw new ArgumentNullException(nameof(executor));
        _data = data ?? throw new ArgumentNullException(nameof(data));
    }

    public Task ClientAndAccountAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(EQBOPSmokeTestCanonicalMap.ClientAndAccount, _data, cancellationToken);

    public Task ProposalStartAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(EQBOPSmokeTestCanonicalMap.ProposalStart, _data, cancellationToken);

    public Task IdentityAndPrefillAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(EQBOPSmokeTestCanonicalMap.IdentityAndPrefill, _data, cancellationToken);

    public Task PreQualificationAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(EQBOPSmokeTestCanonicalMap.PreQualification, _data, cancellationToken);

    public Task VerificationAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(EQBOPSmokeTestCanonicalMap.Verification, _data, cancellationToken);

}
