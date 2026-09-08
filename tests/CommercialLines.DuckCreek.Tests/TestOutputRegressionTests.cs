using System.Reflection;
using InsuranceAutomation.Core;
using Microsoft.Playwright;
using NUnit.Framework;

namespace InsuranceAutomation.CLDC;

[TestFixture]
[Category("FrameworkRegression")]
public sealed class TestOutputRegressionTests
{
    [Test]
    public void ArtifactRootRemainsInsideResults()
    {
        var root = Path.Combine(Path.GetTempPath(), "output-path-check");
        Assert.That(TestOutputPaths.ResolveArtifactRoot(root, "Artifacts"), Is.EqualTo(Path.Combine(root, "Artifacts")));
        Assert.Throws<InvalidOperationException>((Action)(() => TestOutputPaths.ResolveArtifactRoot(root, "..")));
        Assert.Throws<InvalidOperationException>((Action)(() => TestOutputPaths.ResolveArtifactRoot(root, Path.GetTempPath())));
    }

    [Test]
    public async Task FailureAndFinalScreenshotRequestsReuseOneCapture()
    {
        var root = Path.Combine(Path.GetTempPath(), "screenshot-check-" + Guid.NewGuid().ToString("N"));
        try
        {
            var browser = new BrowserSession(new FrameworkConfig());
            browser.SetArtifactDirectory(root);
            var page = DispatchProxy.Create<IPage, ScreenshotPageProxy>();
            typeof(BrowserSession).GetField("_page", BindingFlags.Instance | BindingFlags.NonPublic)!.SetValue(browser, page);
            var paths = await Task.WhenAll(browser.CaptureScreenshotAsync("failure.png"), browser.CaptureScreenshotAsync("final.png"));
            var bytes = await browser.CaptureScreenshotBytesAsync();
            Assert.Multiple((Action)(() =>
            {
                Assert.That(paths[0], Is.EqualTo(paths[1]));
                Assert.That(((ScreenshotPageProxy)(object)page).Calls, Is.EqualTo(1));
                Assert.That(Directory.GetFiles(root, "*.png", SearchOption.AllDirectories), Has.Length.EqualTo(1));
                Assert.That(bytes, Is.EqualTo(new byte[] { 1, 2, 3 }));
            }));
            var report = new ScenarioReport(root) { ScreenshotPath = paths[0] };
            report.Write("feature", "scenario", Path.Combine(root, "execution.log"), null, null, null, null);
            Assert.That(File.ReadAllText(Path.Combine(root, "report.html")), Does.Contain("screenshots/scenario.png"));
        }
        finally { if (Directory.Exists(root)) Directory.Delete(root, true); }
    }

    [Test]
    public async Task UnavailableBrowserDoesNotCreateScreenshot()
    {
        var browser = new BrowserSession(new FrameworkConfig());
        Assert.That(await browser.CaptureScreenshotAsync("final.png"), Is.Null);
        Assert.That(browser.ScreenshotPath, Is.Null);
    }

    public class ScreenshotPageProxy : DispatchProxy
    {
        public int Calls { get; private set; }
        protected override object? Invoke(MethodInfo? targetMethod, object?[]? args)
        {
            if (targetMethod?.Name != nameof(IPage.ScreenshotAsync)) throw new NotSupportedException(targetMethod?.Name);
            Calls++;
            var options = (PageScreenshotOptions)args![0]!;
            byte[] bytes = [1, 2, 3];
            File.WriteAllBytes(options.Path!, bytes);
            return Task.FromResult(bytes);
        }
    }
}
