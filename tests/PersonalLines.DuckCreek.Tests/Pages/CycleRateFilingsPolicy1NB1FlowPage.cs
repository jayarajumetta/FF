using ToscaArtifactAutomation.Core.Canonical;
using ToscaArtifactAutomation.Core.Runtime;
using ToscaArtifactAutomation.PLDC.CanonicalMaps;

namespace ToscaArtifactAutomation.PLDC.Pages;

public sealed class CycleRateFilingsPolicy1NB1FlowPage : IFlowPage
{
    private readonly CanonicalActionExecutor _executor;
    private readonly ScenarioDataContext _data;

    public CycleRateFilingsPolicy1NB1FlowPage(CanonicalActionExecutor executor, ScenarioDataContext data)
    {
        _executor = executor ?? throw new ArgumentNullException(nameof(executor));
        _data = data ?? throw new ArgumentNullException(nameof(data));
    }

    public Task ClientAndAccountAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(CycleRateFilingsPolicy1NB1CanonicalMap.ClientAndAccount, _data, cancellationToken);

    public Task ProposalStartAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(CycleRateFilingsPolicy1NB1CanonicalMap.ProposalStart, _data, cancellationToken);

    public Task PreQualificationAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(CycleRateFilingsPolicy1NB1CanonicalMap.PreQualification, _data, cancellationToken);

    public Task DriverInformationAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(CycleRateFilingsPolicy1NB1CanonicalMap.DriverInformation, _data, cancellationToken);

    public Task VehicleInformationAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(CycleRateFilingsPolicy1NB1CanonicalMap.VehicleInformation, _data, cancellationToken);

    public Task DriverAssignmentAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(CycleRateFilingsPolicy1NB1CanonicalMap.DriverAssignment, _data, cancellationToken);

    public Task ClaimsAndViolationsAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(CycleRateFilingsPolicy1NB1CanonicalMap.ClaimsAndViolations, _data, cancellationToken);

    public Task DiscountsAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(CycleRateFilingsPolicy1NB1CanonicalMap.Discounts, _data, cancellationToken);

    public Task CoveragesAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(CycleRateFilingsPolicy1NB1CanonicalMap.Coverages, _data, cancellationToken);

    public Task PricingAndBillingAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(CycleRateFilingsPolicy1NB1CanonicalMap.PricingAndBilling, _data, cancellationToken);

    public Task SubmissionAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(CycleRateFilingsPolicy1NB1CanonicalMap.Submission, _data, cancellationToken);

    public Task VerificationAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(CycleRateFilingsPolicy1NB1CanonicalMap.Verification, _data, cancellationToken);

}
