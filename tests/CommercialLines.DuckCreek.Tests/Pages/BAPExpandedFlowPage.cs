using ToscaArtifactAutomation.Core.Canonical;
using ToscaArtifactAutomation.Core.Runtime;
using ToscaArtifactAutomation.CLDC.CanonicalMaps;

namespace ToscaArtifactAutomation.CLDC.Pages;

public sealed class BAPExpandedFlowPage : IFlowPage
{
    private readonly CanonicalActionExecutor _executor;
    private readonly ScenarioDataContext _data;

    public BAPExpandedFlowPage(CanonicalActionExecutor executor, ScenarioDataContext data)
    {
        _executor = executor ?? throw new ArgumentNullException(nameof(executor));
        _data = data ?? throw new ArgumentNullException(nameof(data));
    }

    public Task ClientAndAccountAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(BAPExpandedCanonicalMap.ClientAndAccount, _data, cancellationToken);

    public Task ApplicationSetupAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(BAPExpandedCanonicalMap.ApplicationSetup, _data, cancellationToken);

    public Task CoveragesAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(BAPExpandedCanonicalMap.Coverages, _data, cancellationToken);

    public Task RiskDetailsAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(BAPExpandedCanonicalMap.RiskDetails, _data, cancellationToken);

    public Task InterestsAndEndorsementsAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(BAPExpandedCanonicalMap.InterestsAndEndorsements, _data, cancellationToken);

    public Task UnderwritingAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(BAPExpandedCanonicalMap.Underwriting, _data, cancellationToken);

    public Task PricingAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(BAPExpandedCanonicalMap.Pricing, _data, cancellationToken);

    public Task SubmissionAsync(CancellationToken cancellationToken = default) =>
        _executor.ExecuteAsync(BAPExpandedCanonicalMap.Submission, _data, cancellationToken);

}
