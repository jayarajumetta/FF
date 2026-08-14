using ToscaArtifactAutomation.Core.Canonical;
using ToscaArtifactAutomation.Core.Runtime;
using ToscaArtifactAutomation.CLEQ.CanonicalMaps;

namespace ToscaArtifactAutomation.CLEQ.Pages;

public sealed class EQBOPBasicPolicyFlowPage : IFlowPage
{
    private readonly CanonicalActionExecutor _executor;
    private readonly ScenarioDataContext _data;

    public EQBOPBasicPolicyFlowPage(CanonicalActionExecutor executor, ScenarioDataContext data)
    {
        _executor = executor ?? throw new ArgumentNullException(nameof(executor));
        _data = data ?? throw new ArgumentNullException(nameof(data));
    }

    public Task ClientAndAccountAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(EQBOPBasicPolicyCanonicalMap.ClientAndAccount, _data, cancellationToken);

    public Task ProposalStartAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(EQBOPBasicPolicyCanonicalMap.ProposalStart, _data, cancellationToken);

    public Task IdentityAndPrefillAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(EQBOPBasicPolicyCanonicalMap.IdentityAndPrefill, _data, cancellationToken);

    public Task PolicyDetailsAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(EQBOPBasicPolicyCanonicalMap.PolicyDetails, _data, cancellationToken);

    public Task CoveragesAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(EQBOPBasicPolicyCanonicalMap.Coverages, _data, cancellationToken);

    public Task PricingAndBillingAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(EQBOPBasicPolicyCanonicalMap.PricingAndBilling, _data, cancellationToken);

    public Task SubmissionAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(EQBOPBasicPolicyCanonicalMap.Submission, _data, cancellationToken);

    public Task VerificationAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(EQBOPBasicPolicyCanonicalMap.Verification, _data, cancellationToken);

}
