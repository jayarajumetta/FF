using ToscaArtifactAutomation.Core.Canonical;
using ToscaArtifactAutomation.Core.Runtime;
using ToscaArtifactAutomation.PLDC.CanonicalMaps;

namespace ToscaArtifactAutomation.PLDC.Pages;

public sealed class AutoRateFilingsCommonPolicyNBPriorEffDateFlowPage : IFlowPage
{
    private readonly CanonicalActionExecutor _executor;
    private readonly ScenarioDataContext _data;

    public AutoRateFilingsCommonPolicyNBPriorEffDateFlowPage(CanonicalActionExecutor executor, ScenarioDataContext data)
    {
        _executor = executor ?? throw new ArgumentNullException(nameof(executor));
        _data = data ?? throw new ArgumentNullException(nameof(data));
    }

    public Task ClientAndAccountAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(AutoRateFilingsCommonPolicyNBPriorEffDateCanonicalMap.ClientAndAccount, _data, cancellationToken);

    public Task ProposalStartAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(AutoRateFilingsCommonPolicyNBPriorEffDateCanonicalMap.ProposalStart, _data, cancellationToken);

    public Task PreQualificationAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(AutoRateFilingsCommonPolicyNBPriorEffDateCanonicalMap.PreQualification, _data, cancellationToken);

    public Task DriverInformationAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(AutoRateFilingsCommonPolicyNBPriorEffDateCanonicalMap.DriverInformation, _data, cancellationToken);

    public Task VehicleInformationAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(AutoRateFilingsCommonPolicyNBPriorEffDateCanonicalMap.VehicleInformation, _data, cancellationToken);

    public Task DriverAssignmentAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(AutoRateFilingsCommonPolicyNBPriorEffDateCanonicalMap.DriverAssignment, _data, cancellationToken);

    public Task ClaimsAndViolationsAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(AutoRateFilingsCommonPolicyNBPriorEffDateCanonicalMap.ClaimsAndViolations, _data, cancellationToken);

    public Task DiscountsAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(AutoRateFilingsCommonPolicyNBPriorEffDateCanonicalMap.Discounts, _data, cancellationToken);

    public Task CoveragesAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(AutoRateFilingsCommonPolicyNBPriorEffDateCanonicalMap.Coverages, _data, cancellationToken);

    public Task PricingAndBillingAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(AutoRateFilingsCommonPolicyNBPriorEffDateCanonicalMap.PricingAndBilling, _data, cancellationToken);

    public Task SubmissionAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(AutoRateFilingsCommonPolicyNBPriorEffDateCanonicalMap.Submission, _data, cancellationToken);

    public Task VerificationAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(AutoRateFilingsCommonPolicyNBPriorEffDateCanonicalMap.Verification, _data, cancellationToken);

}
