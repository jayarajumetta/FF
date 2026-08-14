using ToscaArtifactAutomation.Core.Canonical;
using ToscaArtifactAutomation.Core.Runtime;
using ToscaArtifactAutomation.PLDC.CanonicalMaps;

namespace ToscaArtifactAutomation.PLDC.Pages;

public sealed class CycleRateFilingsPolicy3NBPriorEffDateFlowPage : IFlowPage
{
    private readonly CanonicalActionExecutor _executor;
    private readonly ScenarioDataContext _data;

    public CycleRateFilingsPolicy3NBPriorEffDateFlowPage(CanonicalActionExecutor executor, ScenarioDataContext data)
    {
        _executor = executor ?? throw new ArgumentNullException(nameof(executor));
        _data = data ?? throw new ArgumentNullException(nameof(data));
    }

    public Task ClientAndAccountAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(CycleRateFilingsPolicy3NBPriorEffDateCanonicalMap.ClientAndAccount, _data, cancellationToken);

    public Task ProposalStartAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(CycleRateFilingsPolicy3NBPriorEffDateCanonicalMap.ProposalStart, _data, cancellationToken);

    public Task PreQualificationAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(CycleRateFilingsPolicy3NBPriorEffDateCanonicalMap.PreQualification, _data, cancellationToken);

    public Task DriverInformationAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(CycleRateFilingsPolicy3NBPriorEffDateCanonicalMap.DriverInformation, _data, cancellationToken);

    public Task VehicleInformationAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(CycleRateFilingsPolicy3NBPriorEffDateCanonicalMap.VehicleInformation, _data, cancellationToken);

    public Task DriverAssignmentAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(CycleRateFilingsPolicy3NBPriorEffDateCanonicalMap.DriverAssignment, _data, cancellationToken);

    public Task ClaimsAndViolationsAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(CycleRateFilingsPolicy3NBPriorEffDateCanonicalMap.ClaimsAndViolations, _data, cancellationToken);

    public Task DiscountsAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(CycleRateFilingsPolicy3NBPriorEffDateCanonicalMap.Discounts, _data, cancellationToken);

    public Task CoveragesAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(CycleRateFilingsPolicy3NBPriorEffDateCanonicalMap.Coverages, _data, cancellationToken);

    public Task PricingAndBillingAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(CycleRateFilingsPolicy3NBPriorEffDateCanonicalMap.PricingAndBilling, _data, cancellationToken);

    public Task SubmissionAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(CycleRateFilingsPolicy3NBPriorEffDateCanonicalMap.Submission, _data, cancellationToken);

    public Task VerificationAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(CycleRateFilingsPolicy3NBPriorEffDateCanonicalMap.Verification, _data, cancellationToken);

}
