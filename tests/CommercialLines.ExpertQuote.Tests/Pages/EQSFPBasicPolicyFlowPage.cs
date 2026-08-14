using ToscaArtifactAutomation.Core.Canonical;
using ToscaArtifactAutomation.Core.Runtime;
using ToscaArtifactAutomation.CLEQ.CanonicalMaps;

namespace ToscaArtifactAutomation.CLEQ.Pages;

public sealed class EQSFPBasicPolicyFlowPage : IFlowPage
{
    private readonly CanonicalActionExecutor _executor;
    private readonly ScenarioDataContext _data;

    public EQSFPBasicPolicyFlowPage(CanonicalActionExecutor executor, ScenarioDataContext data)
    {
        _executor = executor ?? throw new ArgumentNullException(nameof(executor));
        _data = data ?? throw new ArgumentNullException(nameof(data));
    }

    public Task ClientAndAccountAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(EQSFPBasicPolicyCanonicalMap.ClientAndAccount, _data, cancellationToken);

    public Task ProposalStartAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(EQSFPBasicPolicyCanonicalMap.ProposalStart, _data, cancellationToken);

    public Task IdentityAndPrefillAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(EQSFPBasicPolicyCanonicalMap.IdentityAndPrefill, _data, cancellationToken);

    public Task PolicyDetailsAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(EQSFPBasicPolicyCanonicalMap.PolicyDetails, _data, cancellationToken);

    public Task RiskDetailsAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(EQSFPBasicPolicyCanonicalMap.RiskDetails, _data, cancellationToken);

    public Task CoveragesAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(EQSFPBasicPolicyCanonicalMap.Coverages, _data, cancellationToken);

    public Task PricingAndBillingAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(EQSFPBasicPolicyCanonicalMap.PricingAndBilling, _data, cancellationToken);

    public Task SubmissionAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(EQSFPBasicPolicyCanonicalMap.Submission, _data, cancellationToken);

}
