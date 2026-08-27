using InsuranceAutomation.Core;
using NUnit.Framework;

namespace InsuranceAutomation.NUnit;

/// <summary>
/// One reusable scenario-finalization path for all ReqnRoll/NUnit test projects.
/// Playwright trace/video are finalized before attachments are registered; HAR collection is intentionally disabled in v57. Deferred Tosca
/// verification failures are converted to the final NUnit assertion only after evidence publication.
/// </summary>
public static class NUnitScenarioEvidenceFinalizer
{
    public static async Task FinishAsync(
        BrowserSession browser,
        RunLogger logger,
        FrameworkConfig config,
        ScenarioReport report,
        DeferredVerificationCollector verificationFailures,
        string artifactDirectory,
        string feature,
        string scenario,
        Exception? scenarioError)
    {
        string? deferredSummary = null;
        try
        {
            if (browser.IsStarted && config.Browser.ScreenshotAtScenarioEnd)
            {
                try { await browser.CaptureScreenshotAsync("scenario-final.png"); }
                catch (Exception ex) { logger.Warn($"Unable to capture final scenario screenshot: {ex.Message}"); }
            }

            // Closing the context finalizes video; trace is stopped inside CloseAsync. HAR collection is disabled in v57.
            await browser.CloseAsync(logger);

            if (verificationFailures.HasFailures)
            {
                deferredSummary = verificationFailures.BuildSummary();
                logger.Error($"DEFERRED VERIFICATION SUMMARY ({verificationFailures.Failures.Count}):{Environment.NewLine}{deferredSummary}");
            }

            var effectiveError = scenarioError;
            if (effectiveError is null && verificationFailures.HasFailures)
                effectiveError = new AssertionException($"{verificationFailures.Failures.Count} deferred verification failure(s). {deferredSummary}");

            if (config.Reporting.HtmlReport)
                report.Write(feature, scenario, logger.LogPath, browser.TracePath, browser.VideoPath, browser.HarPath, null);

            var bundle = browser.CreateEvidenceBundle(logger);
            if (config.Reporting.HtmlReport)
                report.Write(feature, scenario, logger.LogPath, browser.TracePath, browser.VideoPath, browser.HarPath, bundle);

            logger.Flush();

            var published = NUnitEvidencePublisher.Publish(
                artifactDirectory,
                config,
                feature,
                scenario,
                effectiveError);

            logger.Info($"TEST EVIDENCE ATTACHMENTS: enabled={published.Enabled}; attached={published.AttachedCount}; skipped={published.SkippedCount}; failures={published.Failures.Count}");
            foreach (var failure in published.Failures) logger.Warn($"ATTACHMENT FAILURE: {failure}");
            logger.Flush();
        }
        finally
        {
            logger.Dispose();
        }

        // Do not replace an existing business/action exception. ReqnRoll/NUnit already owns it.
        // Only convert collected soft verification failures when there was no earlier fatal test error.
        if (scenarioError is null && !string.IsNullOrWhiteSpace(deferredSummary))
            Assert.Fail($"Deferred verification failures:{Environment.NewLine}{deferredSummary}");
    }
}
