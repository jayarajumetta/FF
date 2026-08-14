using ToscaArtifactAutomation.Core.Canonical;
using ToscaArtifactAutomation.Core.Runtime;
using ToscaArtifactAutomation.PLDC.CanonicalMaps;

namespace ToscaArtifactAutomation.PLDC.Pages;

public sealed class AutoRateFilingsCommonPolicyNBFlowPage : IFlowPage
{
    private readonly CanonicalActionExecutor _executor;
    private readonly ScenarioDataContext _data;

    public AutoRateFilingsCommonPolicyNBFlowPage(CanonicalActionExecutor executor, ScenarioDataContext data)
    {
        _executor = executor ?? throw new ArgumentNullException(nameof(executor));
        _data = data ?? throw new ArgumentNullException(nameof(data));
    }

    public Task ClientAndAccountAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(AutoRateFilingsCommonPolicyNBCanonicalMap.ClientAndAccount, _data, cancellationToken);

    public Task ProposalStartAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(AutoRateFilingsCommonPolicyNBCanonicalMap.ProposalStart, _data, cancellationToken);

    public Task PreQualificationAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(AutoRateFilingsCommonPolicyNBCanonicalMap.PreQualification, _data, cancellationToken);

    public Task DriverInformationAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(AutoRateFilingsCommonPolicyNBCanonicalMap.DriverInformation, _data, cancellationToken);

    public Task VehicleInformationAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(AutoRateFilingsCommonPolicyNBCanonicalMap.VehicleInformation, _data, cancellationToken);

    public Task DriverAssignmentAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(AutoRateFilingsCommonPolicyNBCanonicalMap.DriverAssignment, _data, cancellationToken);

    public Task ClaimsAndViolationsAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(AutoRateFilingsCommonPolicyNBCanonicalMap.ClaimsAndViolations, _data, cancellationToken);

    public Task DiscountsAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(AutoRateFilingsCommonPolicyNBCanonicalMap.Discounts, _data, cancellationToken);

    public Task CoveragesAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(AutoRateFilingsCommonPolicyNBCanonicalMap.Coverages, _data, cancellationToken);

    public Task PricingAndBillingAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(AutoRateFilingsCommonPolicyNBCanonicalMap.PricingAndBilling, _data, cancellationToken);

    public Task SubmissionAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(AutoRateFilingsCommonPolicyNBCanonicalMap.Submission, _data, cancellationToken);

    public Task VerificationAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(AutoRateFilingsCommonPolicyNBCanonicalMap.Verification, _data, cancellationToken);

}
