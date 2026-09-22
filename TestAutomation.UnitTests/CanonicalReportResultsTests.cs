using System.Globalization;
using System.Xml.Linq;
using NUnit.Framework;
using PnCTestAutomation.TestPlanPublisher;

namespace PnCTestAutomation.UnitTests;

[TestFixture]
public sealed class CanonicalReportResultsTests
{
    private string _root = null!;
    private readonly CanonicalResultLoader _loader = new();

    [SetUp]
    public void SetUp()
    {
        _root = Path.Combine(Path.GetTempPath(), "PnCTestAutomation.Tests", Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(_root);
    }

    [TearDown]
    public void TearDown() => Directory.Delete(_root, true);

    [Test]
    public void TrxReadsOnlyActualResultsWithTruthfulStatusesAndDurations()
    {
        var document = TestCanonicalFiles.Trx(
            ("Passed identity", "Passed"), ("Failed identity", "Failed"), ("Skipped identity", "NotExecuted"));
        var failed = document.Descendants(TestCanonicalFiles.TrxNamespace + "UnitTestResult").ElementAt(1);
        failed.Add(new XElement(TestCanonicalFiles.TrxNamespace + "Output",
            new XElement(TestCanonicalFiles.TrxNamespace + "ErrorInfo",
                new XElement(TestCanonicalFiles.TrxNamespace + "Message", "Teardown assertion"),
                new XElement(TestCanonicalFiles.TrxNamespace + "StackTrace", "Test cleanup"))));
        var results = Load(document);
        Assert.Multiple(() =>
        {
            Assert.That(results.Select(item => item.Outcome),
                Is.EqualTo(new[] { CanonicalReportOutcome.Passed, CanonicalReportOutcome.Failed, CanonicalReportOutcome.Skipped }));
            Assert.That(results[0].TestIdentity, Is.EqualTo("Passed identity"));
            Assert.That(results[0].Duration, Is.EqualTo(TimeSpan.FromMilliseconds(1250)));
            Assert.That(results[1].FailureMessage, Does.Contain("Teardown assertion").And.Contain("Test cleanup"));
        });
    }

    [TestCase("Error")]
    [TestCase("Timeout")]
    [TestCase("Aborted")]
    public void TrxErrorOutcomesAreFailuresNotSkips(string outcome)
    {
        var results = Load(TestCanonicalFiles.Trx(("test", outcome)));
        Assert.That(results.Single().Outcome, Is.EqualTo(CanonicalReportOutcome.Failed));
    }

    [Test]
    public void NUnitReadsFullIdentityAndIgnoredOrInconclusiveAsSkipped()
    {
        var results = Load(TestCanonicalFiles.NUnit(
            ("Fixture.Passed", "Passed"), ("Fixture.Failed", "Failed"),
            ("Fixture.Ignored", "Skipped"), ("Fixture.Inconclusive", "Inconclusive")));
        Assert.That(results.Select(item => (item.TestIdentity, item.Outcome)), Is.EqualTo(new[]
        {
            ("Fixture.Passed", CanonicalReportOutcome.Passed), ("Fixture.Failed", CanonicalReportOutcome.Failed),
            ("Fixture.Ignored", CanonicalReportOutcome.Skipped), ("Fixture.Inconclusive", CanonicalReportOutcome.Skipped)
        }));
    }

    [TestCase("")]
    [TestCase("<TestRun />")]
    [TestCase("<test-run total=\"1\" passed=\"1\" />")]
    [TestCase("<test-suite><test-case name=\"discovered only\" /></test-suite>")]
    [TestCase("<broken")]
    public void EmptyMalformedOrDiscoveryOnlyInputsAreRejected(string contents)
    {
        var path = Path.Combine(_root, "result.xml");
        File.WriteAllText(path, contents);
        Assert.That(() => _loader.LoadReportResults(path), Throws.TypeOf<TestPlanPublicationException>());
    }

    [Test]
    public void MissingCanonicalFileIsRejected() =>
        Assert.That(() => _loader.LoadReportResults(Path.Combine(_root, "missing.trx")),
            Throws.TypeOf<TestPlanPublicationException>());

    [TestCase(true)]
    [TestCase(false)]
    public void ZeroCasesAndDuplicateIdentitiesAreRejected(bool trx)
    {
        Assert.Multiple(() =>
        {
            Assert.That(() => Load(trx ? TestCanonicalFiles.Trx() : TestCanonicalFiles.NUnit()),
                Throws.TypeOf<TestPlanPublicationException>());
            Assert.That(() => Load(trx
                    ? TestCanonicalFiles.Trx(("duplicate", "Passed"), ("duplicate", "Failed"))
                    : TestCanonicalFiles.NUnit(("duplicate", "Passed"), ("duplicate", "Failed"))),
                Throws.TypeOf<TestPlanPublicationException>().With.Message.Contains("duplicate"));
        });
    }

    [TestCase("total")]
    [TestCase("executed")]
    [TestCase("passed")]
    [TestCase("failed")]
    [TestCase("notExecuted")]
    public void TrxCountersAreRequiredAndMustMatchActualCases(string name)
    {
        var document = TestCanonicalFiles.Trx(("test", "Passed"));
        var counters = document.Descendants(TestCanonicalFiles.TrxNamespace + "Counters").Single();
        counters.SetAttributeValue(name, "999");
        Assert.That(() => Load(document), Throws.TypeOf<TestPlanPublicationException>().With.Message.Contains("counter"));
        counters.Attribute(name)!.Remove();
        Assert.That(() => Load(document), Throws.TypeOf<TestPlanPublicationException>().With.Message.Contains("counter"));
    }

    [TestCase("total")]
    [TestCase("passed")]
    [TestCase("failed")]
    [TestCase("skipped")]
    [TestCase("testcasecount")]
    public void NUnitCountersMustMatchActualCases(string name)
    {
        var document = TestCanonicalFiles.NUnit(("test", "Passed"));
        document.Root!.SetAttributeValue(name, "99");
        Assert.That(() => Load(document), Throws.TypeOf<TestPlanPublicationException>().With.Message.Contains("counter"));
    }

    [TestCase("")]
    [TestCase("-00:00:01")]
    [TestCase("tomorrow")]
    public void TrxDurationsCannotBeMissingNegativeOrMalformed(string duration)
    {
        var document = TestCanonicalFiles.Trx(("test", "Passed"));
        document.Descendants(TestCanonicalFiles.TrxNamespace + "UnitTestResult").Single().SetAttributeValue("duration", duration);
        Assert.That(() => Load(document), Throws.TypeOf<TestPlanPublicationException>().With.Message.Contains("duration"));
    }

    [TestCase("-1")]
    [TestCase("NaN")]
    [TestCase("Infinity")]
    [TestCase("1e99")]
    [TestCase("")]
    public void NUnitDurationsMustBeFiniteAndNonnegative(string duration)
    {
        var document = TestCanonicalFiles.NUnit(("test", "Passed"));
        document.Descendants("test-case").Single().SetAttributeValue("duration", duration);
        Assert.That(() => Load(document), Throws.TypeOf<TestPlanPublicationException>().With.Message.Contains("duration"));
    }

    [Test]
    public void DurationsAreParsedIndependentlyOfCurrentCulture()
    {
        var previous = CultureInfo.CurrentCulture;
        try
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("fr-FR");
            Assert.That(Load(TestCanonicalFiles.NUnit(("test", "Passed"))).Single().Duration,
                Is.EqualTo(TimeSpan.FromMilliseconds(1250)));
        }
        finally
        {
            CultureInfo.CurrentCulture = previous;
        }
    }

    [TestCase(true)]
    [TestCase(false)]
    public void RunSetupOrTeardownFailureCannotBeReinterpretedAsPassingCases(bool trx)
    {
        var document = trx ? TestCanonicalFiles.Trx(("test", "Passed")) : TestCanonicalFiles.NUnit(("test", "Passed"));
        if (trx)
            document.Descendants(TestCanonicalFiles.TrxNamespace + "ResultSummary").Single().SetAttributeValue("outcome", "Failed");
        else
            document.Root!.SetAttributeValue("result", "Failed");
        Assert.That(() => Load(document), Throws.TypeOf<TestPlanPublicationException>().With.Message.Contains("teardown"));
    }

    [Test]
    public void NUnitSuiteFailureIsCheckedEvenWhenTheRunCountsLookSuccessful()
    {
        var document = TestCanonicalFiles.NUnit(("test", "Passed"));
        var test = document.Root!.Element("test-case")!;
        test.Remove();
        document.Root.Add(new XElement("test-suite", new XAttribute("result", "Failed"),
            new XAttribute("site", "TearDown"), test));
        Assert.That(() => Load(document), Throws.TypeOf<TestPlanPublicationException>());
    }

    [Test]
    public void FailedEmptyNUnitSuiteCannotBeHiddenBehindAnotherFailedTest()
    {
        var document = TestCanonicalFiles.NUnit(("test", "Failed"));
        document.Root!.Add(new XElement("test-suite", new XAttribute("result", "Failed"),
            new XElement("failure", new XElement("message", "OneTimeSetUp failed before discovery"))));
        Assert.That(() => Load(document), Throws.TypeOf<TestPlanPublicationException>().With.Message.Contains("setup/teardown"));
    }

    [TestCase(true)]
    [TestCase(false)]
    public void FailureDiagnosticsCannotAppearInANonFailedTest(bool trx)
    {
        var document = trx ? TestCanonicalFiles.Trx(("test", "Passed")) : TestCanonicalFiles.NUnit(("test", "Passed"));
        if (trx)
            document.Descendants(TestCanonicalFiles.TrxNamespace + "UnitTestResult").Single().Add(
                new XElement(TestCanonicalFiles.TrxNamespace + "Output",
                    new XElement(TestCanonicalFiles.TrxNamespace + "ErrorInfo", "failure")));
        else
            document.Descendants("test-case").Single().Add(new XElement("failure", new XElement("message", "failure")));
        Assert.That(() => Load(document), Throws.TypeOf<TestPlanPublicationException>());
    }

    [TestCase(true)]
    [TestCase(false)]
    public void NonFinalOutcomesCannotLookExecuted(bool trx)
    {
        var document = trx ? TestCanonicalFiles.Trx(("test", "Passed")) : TestCanonicalFiles.NUnit(("test", "Passed"));
        var test = document.Descendants(trx ? TestCanonicalFiles.TrxNamespace + "UnitTestResult" : "test-case").Single();
        test.SetAttributeValue(trx ? "outcome" : "result", "Running");
        Assert.That(() => Load(document), Throws.TypeOf<TestPlanPublicationException>());
    }

    [Test]
    public void XmlExternalEntitiesAreRejectedWithoutReadingTheirTargets()
    {
        var path = Path.Combine(_root, "result.xml");
        File.WriteAllText(path, "<!DOCTYPE test-run [<!ENTITY data SYSTEM 'file:///never-read'>]><test-run>&data;</test-run>");
        Assert.That(() => _loader.LoadReportResults(path), Throws.TypeOf<TestPlanPublicationException>());
    }

    private IReadOnlyList<CanonicalReportResult> Load(XDocument document)
    {
        var path = Path.Combine(_root, "result.xml");
        document.Save(path);
        return _loader.LoadReportResults(path);
    }
}

internal static class TestCanonicalFiles
{
    internal static readonly XNamespace TrxNamespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010";

    internal static XDocument Trx(params (string Identity, string Outcome)[] tests)
    {
        var failed = tests.Count(item => item.Outcome is "Failed" or "Error" or "Timeout" or "Aborted");
        var ns = TrxNamespace;
        return new XDocument(new XElement(ns + "TestRun",
            new XElement(ns + "Results", tests.Select((test, index) =>
                new XElement(ns + "UnitTestResult", new XAttribute("testId", index + 1),
                    new XAttribute("testName", test.Identity), new XAttribute("outcome", test.Outcome),
                    new XAttribute("duration", "00:00:01.2500000")))),
            new XElement(ns + "ResultSummary", new XAttribute("outcome", failed > 0 ? "Failed" : "Completed"),
                new XElement(ns + "Counters", new XAttribute("total", tests.Length),
                    new XAttribute("executed", tests.Count(item => item.Outcome != "NotExecuted")),
                    new XAttribute("passed", tests.Count(item => item.Outcome == "Passed")),
                    new XAttribute("failed", tests.Count(item => item.Outcome == "Failed")),
                    new XAttribute("error", tests.Count(item => item.Outcome == "Error")),
                    new XAttribute("timeout", tests.Count(item => item.Outcome == "Timeout")),
                    new XAttribute("aborted", tests.Count(item => item.Outcome == "Aborted")),
                    new XAttribute("notExecuted", tests.Count(item => item.Outcome == "NotExecuted"))))));
    }

    internal static XDocument NUnit(params (string Identity, string Outcome)[] tests) =>
        new(new XElement("test-run",
            new XAttribute("result", tests.Any(item => item.Outcome == "Failed") ? "Failed" :
                tests.All(item => item.Outcome is "Skipped" or "Inconclusive") ? "Skipped" : "Passed"),
            new XAttribute("duration", "1.25"), new XAttribute("total", tests.Length),
            new XAttribute("testcasecount", tests.Length),
            new XAttribute("passed", tests.Count(item => item.Outcome == "Passed")),
            new XAttribute("failed", tests.Count(item => item.Outcome == "Failed")),
            new XAttribute("skipped", tests.Count(item => item.Outcome == "Skipped")),
            new XAttribute("inconclusive", tests.Count(item => item.Outcome == "Inconclusive")),
            tests.Select(item => new XElement("test-case", new XAttribute("fullname", item.Identity),
                new XAttribute("result", item.Outcome), new XAttribute("duration", "1.25")))));
}
