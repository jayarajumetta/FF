using InsuranceAutomation.Core;

namespace InsuranceAutomation.NUnit;

/// <summary>
/// One reusable scenario-finalization path for all ReqnRoll/NUnit test projects.
/// It finalizes scenario-owned Playwright evidence before NUnit attachments are registered.
/// </summary>
public static class NUnitScenarioEvidenceFinalizer
{
    public static async Task FinishAsync(
        BrowserSession browser,
        RunLogger logger,
        FrameworkConfig config,
        ScenarioReport report,
        string artifactDirectory,
        string feature,
        string scenario,
        Exception? scenarioError)
    {
        try
        {
            // Capture a final state for every test. Failure-step screenshots remain separate.
            if (browser.IsStarted && config.Browser.ScreenshotAtScenarioEnd)
            {
                try { await browser.CaptureScreenshotAsync("scenario-final.png"); }
                catch (Exception ex) { logger.Warn($"Unable to capture final scenario screenshot: {ex.Message}"); }
            }

            // Closing the context is mandatory before attachment registration because
            // Playwright finalizes trace.zip, HAR and video on context close.
            await browser.CloseAsync(logger);

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
                scenarioError);

            logger.Info($"TEST EVIDENCE ATTACHMENTS: enabled={published.Enabled}; attached={published.AttachedCount}; skipped={published.SkippedCount}; failures={published.Failures.Count}");
            foreach (var failure in published.Failures) logger.Warn($"ATTACHMENT FAILURE: {failure}");
            logger.Flush();
        }
        finally
        {
            logger.Dispose();
        }
    }
}
