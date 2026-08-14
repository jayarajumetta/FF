using ToscaArtifactAutomation.Core.Canonical;
using ToscaArtifactAutomation.Core.Runtime;
using ToscaArtifactAutomation.PLDC.CanonicalMaps;

namespace ToscaArtifactAutomation.PLDC.Pages;

public sealed class AutoRateFilingsPolicy1NBFlowPage : IFlowPage
{
    private readonly CanonicalActionExecutor _executor;
    private readonly ScenarioDataContext _data;

    public AutoRateFilingsPolicy1NBFlowPage(CanonicalActionExecutor executor, ScenarioDataContext data)
    {
        _executor = executor ?? throw new ArgumentNullException(nameof(executor));
        _data = data ?? throw new ArgumentNullException(nameof(data));
    }

    public Task ClientAndAccountAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(AutoRateFilingsPolicy1NBCanonicalMap.ClientAndAccount, _data, cancellationToken);

    public Task ProposalStartAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(AutoRateFilingsPolicy1NBCanonicalMap.ProposalStart, _data, cancellationToken);

    public Task PreQualificationAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(AutoRateFilingsPolicy1NBCanonicalMap.PreQualification, _data, cancellationToken);

    public Task DriverInformationAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(AutoRateFilingsPolicy1NBCanonicalMap.DriverInformation, _data, cancellationToken);

    public Task VehicleInformationAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(AutoRateFilingsPolicy1NBCanonicalMap.VehicleInformation, _data, cancellationToken);

    public Task DriverAssignmentAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(AutoRateFilingsPolicy1NBCanonicalMap.DriverAssignment, _data, cancellationToken);

    public Task ClaimsAndViolationsAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(AutoRateFilingsPolicy1NBCanonicalMap.ClaimsAndViolations, _data, cancellationToken);

    public Task DiscountsAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(AutoRateFilingsPolicy1NBCanonicalMap.Discounts, _data, cancellationToken);

    public Task CoveragesAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(AutoRateFilingsPolicy1NBCanonicalMap.Coverages, _data, cancellationToken);

    public Task PricingAndBillingAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(AutoRateFilingsPolicy1NBCanonicalMap.PricingAndBilling, _data, cancellationToken);

    public Task SubmissionAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(AutoRateFilingsPolicy1NBCanonicalMap.Submission, _data, cancellationToken);

    public Task VerificationAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(AutoRateFilingsPolicy1NBCanonicalMap.Verification, _data, cancellationToken);

}
