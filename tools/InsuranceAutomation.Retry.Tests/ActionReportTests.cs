using System.Text.Json;
using InsuranceAutomation.Core;
using NUnit.Framework;

namespace InsuranceAutomation.Reporting.Tests;

public sealed class ActionReportTests
{
    [Test]
    public async Task ActionsPreserveOrderFailuresNestingAndStepIsolation()
    {
        var directory = Path.Combine(Path.GetTempPath(), "actions-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(directory);
        try
        {
            var report = new ScenarioReport(directory);
            report.StartStep("Create client");
            var config = new FrameworkConfig();
            using var logger = new RunLogger(directory);
            var ui = new UiActions(new BrowserSession(config), config, logger, report, "Test");
            await PageActionAsync(ui);
            var found = await report.TraceActionAsync("ClientPage.ExistsAsync", "exists", "Client", new Dictionary<string, string>(), () => Task.FromResult(false));
            Assert.That(found, Is.False);
            await report.TraceActionAsync("ClientPage.ParentAsync", "parent", "Client", new Dictionary<string, string>(), async () =>
                await report.TraceActionAsync("ClientPage.ChildAsync", "child", "Client", new Dictionary<string, string>(), () => Task.FromResult(true)));
            var failure = new InvalidOperationException("broken <control>");
            Func<Task> failedAction = async () => { await report.TraceActionAsync<bool>(
                "ClientPage.VerifyAsync", "verify", "Client", new Dictionary<string, string>(), () => Task.FromException<bool>(failure)); };
            var caught = Assert.ThrowsAsync<InvalidOperationException>(failedAction);
            Assert.That(caught, Is.SameAs(failure));
            await report.TraceActionAsync("LoginPage.EnterPasswordAsync", "fill", "Password", new Dictionary<string, string> { ["value"] = "secret-value" }, () => Task.FromResult(true));
            await report.TraceActionAsync("ClientPage.DeferredAsync", "verify", "Client", new Dictionary<string, string>(), () =>
            {
                report.RecordDeferredVerification(new DeferredVerificationFailure(DateTimeOffset.Now, "Create client", "Client", "Name", "Value", "expected", "mismatch", null));
                return Task.FromResult(true);
            });
            report.EndStep(false, "failure", new Dictionary<string, string>(), null, new StepEvidence([], []), "Steps.CreateAsync", true);
            report.StartStep("Next step");
            report.EndStep(true, null, new Dictionary<string, string>(), null, new StepEvidence([], []), "Steps.NextAsync", true);
            var logPath = Path.Combine(directory, "execution.log");
            report.Write("Feature", "Case", logPath, null, null, null, null);
            using var document = JsonDocument.Parse(File.ReadAllText(Path.Combine(directory, "scenario-result.json")));
            var steps = document.RootElement.GetProperty("steps");
            var actions = steps[0].GetProperty("actions");
            Assert.That(actions.GetArrayLength(), Is.EqualTo(6));
            Assert.That(actions[0].GetProperty("method").GetString(), Is.EqualTo("ActionReportTests.PageActionAsync"));
            Assert.That(actions[1].GetProperty("status").GetString(), Is.EqualTo("PASS"));
            Assert.That(actions[1].GetProperty("result").GetString(), Is.EqualTo("False"));
            Assert.That(actions[2].GetProperty("children").GetArrayLength(), Is.EqualTo(1));
            Assert.That(actions[3].GetProperty("status").GetString(), Is.EqualTo("FAIL"));
            Assert.That(actions[4].GetProperty("data").GetProperty("value").GetString(), Is.EqualTo("***"));
            Assert.That(actions[5].GetProperty("status").GetString(), Is.EqualTo("FAIL"));
            Assert.That(steps[1].GetProperty("actions").GetArrayLength(), Is.Zero);
            var html = File.ReadAllText(report.ReportPath);
            Assert.That(html, Does.Contain("binding-node"));
            Assert.That(html, Does.Contain("action-node FAIL"));
            Assert.That(html, Does.Contain("broken &lt;control&gt;"));
            Assert.That(html, Does.Not.Contain("secret-value"));
            Assert.That(html, Does.Not.Contain("MoveNext"));
        }
        finally { Directory.Delete(directory, true); }
    }

    private static Task PageActionAsync(UiActions ui) => ui.ReviewRequiredAsync("offline action");
}
