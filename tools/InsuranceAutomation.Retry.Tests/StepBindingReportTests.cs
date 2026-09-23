using System.Text.Json;
using InsuranceAutomation.Core;
using NUnit.Framework;

namespace InsuranceAutomation.Reporting.Tests;

[TestFixture]
public sealed class StepBindingReportTests
{
    [TestCase(true)]
    [TestCase(false)]
    public void IndividualReportPreservesSelectedBinding(bool passed)
    {
        var directory = Path.Combine(Path.GetTempPath(), "binding-report-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(directory);
        try
        {
            var report = new ScenarioReport(directory);
            report.SetScenarioData(new Dictionary<string, string> { ["CaseOnly"] = "case-value", ["Policy"] = "one; two=three" });
            report.StartStep("Verify <policy>");
            report.EndStep(passed, passed ? null : "Expected policy failed", new Dictionary<string, string> { ["Policy"] = "one; two=three" }, null,
                new StepEvidence([], []), "Example.PolicySteps.VerifyPolicyAsync", bindingCaptured: true);
            report.StartStep("Undefined step");
            report.EndStep(false, "No match", new Dictionary<string, string>(), null,
                new StepEvidence([], []), bindingCaptured: true);
            report.Write("Policy", "Example", Path.Combine(directory, "execution.log"), null, null, null, null);

            using var json = JsonDocument.Parse(File.ReadAllText(Path.Combine(directory, "scenario-result.json")));
            var steps = json.RootElement.GetProperty("steps");
            Assert.That(json.RootElement.GetProperty("data").GetProperty("CaseOnly").GetString(), Is.EqualTo("case-value"));
            Assert.That(steps[0].GetProperty("data").TryGetProperty("CaseOnly", out _), Is.False);
            Assert.That(steps[0].GetProperty("data").GetProperty("Policy").GetString(), Is.EqualTo("one; two=three"));
            Assert.That(steps[1].GetProperty("data").EnumerateObject().Count(), Is.Zero);
            Assert.That(steps[0].GetProperty("binding").GetString(), Is.EqualTo("Example.PolicySteps.VerifyPolicyAsync"));
            Assert.That(steps[0].GetProperty("bindingCaptured").GetBoolean(), Is.True);
            Assert.That(steps[0].GetProperty("status").GetString(), Is.EqualTo(passed ? "PASS" : "FAIL"));
            Assert.That(steps[1].GetProperty("binding").GetString(), Is.Empty);
            var html = File.ReadAllText(report.ReportPath);
            Assert.That(html, Does.Contain("C# step definition"));
            Assert.That(html, Does.Contain("Example.PolicySteps.VerifyPolicyAsync"));
            Assert.That(html, Does.Contain("Verify &lt;policy&gt;"));
            Assert.That(html, Does.Contain(passed ? "<details><summary>Verify" : "<details open><summary>Verify"));
            Assert.That(html, Does.Contain("No step-definition method was captured"));
            Assert.That(html.Split("CaseOnly").Length - 1, Is.EqualTo(1));
            Assert.That(html.IndexOf("Test-case data", StringComparison.Ordinal), Is.LessThan(html.IndexOf("Execution steps", StringComparison.Ordinal)));
        }
        finally
        {
            Directory.Delete(directory, recursive: true);
        }
    }

    [Test]
    public void StepDataTracksReadsWritesAndFallbacksWithoutSnapshotPollution()
    {
        var data = new ScenarioData(new FrameworkConfig());
        data.SetRuntime("CaseOnly", "case");
        data.SetRuntime("Policy", "old");
        data.BeginStep();
        Assert.That(data.Get("Policy"), Is.EqualTo("old"));
        data.SetRuntime("QuoteId", "123");
        data.SetRuntime("apiKey", "sensitive");
        Assert.That(data.Get("Missing", "fallback"), Is.EqualTo("fallback"));
        Assert.That(data.GetCanonicalField("Address", "default address"), Is.EqualTo("default address"));
        var first = data.StepSnapshot();
        Assert.That(first.ContainsKey("CaseOnly"), Is.False);
        Assert.That(first["apiKey"], Is.EqualTo("***"));
        Assert.That(first["Address"], Is.EqualTo("default address"));
        Assert.That(data.Snapshot()["CaseOnly"], Is.EqualTo("case"));
        Assert.That(data.StepSnapshot().Count, Is.EqualTo(first.Count));
        data.BeginStep();
        Assert.That(data.StepSnapshot(), Is.Empty);
        data.SetRuntime("Policy", "new");
        Assert.That(first["Policy"], Is.EqualTo("old"));
        Assert.That(data.StepSnapshot().Keys, Is.EquivalentTo(new[] { "Policy" }));
        Assert.That(data.Snapshot()["Policy"], Is.EqualTo("new"));
    }
}
