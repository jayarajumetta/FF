using ToscaArtifactAutomation.Core.Canonical;
using ToscaArtifactAutomation.Core.Runtime;
using ToscaArtifactAutomation.CLEQ.CanonicalMaps;

namespace ToscaArtifactAutomation.CLEQ.Pages;

public sealed class EQSFPCountryEstatePolicyFlowPage : IFlowPage
{
    private readonly CanonicalActionExecutor _executor;
    private readonly ScenarioDataContext _data;

    public EQSFPCountryEstatePolicyFlowPage(CanonicalActionExecutor executor, ScenarioDataContext data)
    {
        _executor = executor ?? throw new ArgumentNullException(nameof(executor));
        _data = data ?? throw new ArgumentNullException(nameof(data));
    }

    public Task ClientAndAccountAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(EQSFPCountryEstatePolicyCanonicalMap.ClientAndAccount, _data, cancellationToken);

    public Task ProposalStartAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(EQSFPCountryEstatePolicyCanonicalMap.ProposalStart, _data, cancellationToken);

    public Task IdentityAndPrefillAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(EQSFPCountryEstatePolicyCanonicalMap.IdentityAndPrefill, _data, cancellationToken);

    public Task PolicyDetailsAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(EQSFPCountryEstatePolicyCanonicalMap.PolicyDetails, _data, cancellationToken);

    public Task RiskDetailsAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(EQSFPCountryEstatePolicyCanonicalMap.RiskDetails, _data, cancellationToken);

    public Task CoveragesAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(EQSFPCountryEstatePolicyCanonicalMap.Coverages, _data, cancellationToken);

    public Task PricingAndBillingAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(EQSFPCountryEstatePolicyCanonicalMap.PricingAndBilling, _data, cancellationToken);

    public Task SubmissionAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(EQSFPCountryEstatePolicyCanonicalMap.Submission, _data, cancellationToken);

}
