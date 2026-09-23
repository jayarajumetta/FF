using Gherkin;
using Gherkin.Ast;
using NUnit.Framework;
using PnCTestAutomation.Products;
using PnCTestAutomation.TestPlans;
using System.Collections.Specialized;

namespace PnCTestAutomation.UnitTests;

[TestFixture]
public sealed class SgsExecutionCatalogTests
{
    private static string Root => FindRepositoryRoot();
    private static SgsExecutionCatalog Catalog => SgsExecutionCatalog.Load(Path.Combine(Root, "Resources"));

    [Test]
    public void OnlyVerifiedAlabamaIsExecutableAndReadyCasesRequireExplicitLocalSelection()
    {
        var cases = Catalog.Ledger.Workflows.SelectMany(workflow =>
            workflow.Cases.Select(item => new SgsCaseResolution(workflow, item))).ToArray();
        var verified = cases.Single(item => item.IsRunnable);
        var ready = verified with
        {
            Case = verified.Case with
            {
                ExecutionStatus = SgsExecutionStatus.ReadyForLocalVerification,
                ConsecutivePassingRuns = []
            }
        };
        Assert.Multiple(() =>
        {
            Assert.That(verified.Case.AutomationId, Is.EqualTo(ExpertQuoteBopSmokeInputs.AlabamaIdentity));
            Assert.That(verified.Case.ExecutionStatus, Is.EqualTo(SgsExecutionStatus.Verified));
            Assert.That(verified.Case.ConsecutivePassingRuns, Has.Count.EqualTo(2));
            Assert.That(verified.CanExecute(null), Is.True);
            Assert.That(ready.Case.ExecutionStatus, Is.EqualTo(SgsExecutionStatus.ReadyForLocalVerification));
            Assert.That(ready.CanExecute(null), Is.False);
            Assert.That(ready.CanExecute("wrong-case"), Is.False);
            Assert.That(ready.CanExecute(ExpertQuoteBopSmokeInputs.AlabamaIdentity), Is.True);
            Assert.That(cases.Count(item => item.CanExecute(ExpertQuoteBopSmokeInputs.AlabamaIdentity)), Is.EqualTo(1));
            Assert.That(ready.Workflow.Readiness.TransactionExecutionAuthorized, Is.False);
        });
    }

    [Test]
    public void LedgerPreservesEveryActiveAndSourceDisabledCaseWithItsDependencies()
    {
        var ledger = Catalog.Ledger;
        var cases = ledger.Workflows.SelectMany(item => item.Cases).ToArray();
        Assert.Multiple(() =>
        {
            Assert.That(ledger.Workflows, Has.Count.EqualTo(32));
            Assert.That(cases.Count(item => item.SourceStatus == SgsSourceCaseStatus.Active), Is.EqualTo(1115));
            Assert.That(cases.Count(item => item.SourceStatus == SgsSourceCaseStatus.CommentedOut), Is.EqualTo(34));
            Assert.That(cases.Select(item => item.AutomationId), Is.Unique);
            Assert.That(ledger.Workflows.SelectMany(item => item.Dependencies.Bindings).Distinct().Count(), Is.EqualTo(32));
            Assert.That(ledger.Workflows.SelectMany(item => item.Dependencies.SharedBindings).Distinct().Count(), Is.EqualTo(3));
            Assert.That(ledger.Workflows.SelectMany(item => item.Dependencies.Pages).Distinct().Count(), Is.EqualTo(54));
            Assert.That(ledger.Workflows.SelectMany(item => item.Dependencies.Locators).Distinct().Count(), Is.EqualTo(51));
            Assert.That(ledger.DependencyDecisions, Has.Count.EqualTo(191));
            Assert.That(ledger.Workflows.Where(item => item.Product == "CLDC")
                .SelectMany(item => item.Cases).Count(item => item.SourceStatus == SgsSourceCaseStatus.Active), Is.EqualTo(515));
            Assert.That(ledger.Workflows.Where(item => item.Product == "CLEQ")
                .SelectMany(item => item.Cases).Count(item => item.SourceStatus == SgsSourceCaseStatus.Active), Is.EqualTo(161));
            Assert.That(ledger.Workflows.Where(item => item.Product == "PLDC")
                .SelectMany(item => item.Cases).Count(item => item.SourceStatus == SgsSourceCaseStatus.Active), Is.EqualTo(439));
        });
    }

    [Test]
    public void EveryActiveGherkinRowResolvesToExactlyOneLedgerEntry()
    {
        var catalog = Catalog;
        foreach (var workflow in catalog.Ledger.Workflows)
        {
            var path = Path.Combine(Root, workflow.DestinationPath.Replace('/', Path.DirectorySeparatorChar));
            using var reader = File.OpenText(path);
            var document = new Parser().Parse(reader);
            var resolvedIds = new List<string>();
            foreach (var scenario in document.Feature.Children.OfType<Scenario>())
            {
                foreach (var example in scenario.Examples)
                {
                    foreach (var row in example.TableBody)
                    {
                        var arguments = example.TableHeader.Cells.Select(cell => cell.Value)
                            .Zip(row.Cells.Select(cell => cell.Value))
                            .ToDictionary(pair => pair.First, pair => pair.Second);
                        var tags = document.Feature.Tags.Concat(scenario.Tags).Concat(example.Tags)
                            .Select(tag => tag.Name.TrimStart('@'));
                        var resolution = catalog.Resolve(document.Feature.Name, tags, arguments);
                        Assert.That(resolution.Case.SourceStatus, Is.EqualTo(SgsSourceCaseStatus.Active));
                        resolvedIds.Add(resolution.Case.AutomationId);
                    }
                }
            }
            Assert.That(resolvedIds, Is.EquivalentTo(
                workflow.Cases.Where(item => item.SourceStatus == SgsSourceCaseStatus.Active)
                    .Select(item => item.AutomationId)), workflow.DestinationPath);
        }
    }

    [Test]
    public void EveryLedgerProfileMatchesItsReviewedProductPayload()
    {
        var catalog = Catalog;
        foreach (var workflow in catalog.Ledger.Workflows)
            foreach (var item in workflow.Cases)
            {
                Assert.That(
                    () => catalog.ValidateResourcePayloads(
                        Path.Combine(Root, "Resources"), new SgsCaseResolution(workflow, item)),
                    Throws.Nothing, item.AutomationId);
            }
    }

    [Test]
    public void StableIdentityIgnoresRowOrderAndDisplayNamesButSeparatesCompanyAndProfile()
    {
        var workflow = Catalog.Ledger.Workflows.First(item => item.Product == "PLDC");
        var first = workflow.Cases.First(item => item.Arguments["stateVariant"] == "AZ ANG");
        var second = workflow.Cases.First(item => item.Arguments["stateVariant"] == "AZ ANP");
        var reordered = first.Arguments.Reverse().ToDictionary(pair => pair.Key, pair => pair.Value);
        reordered["stateName"] = "Display-only state spelling";
        var differentProfile = new Dictionary<string, string>(first.Arguments)
        {
            ["dataFile"] = "TestData/Scenarios/different_az_ang.json"
        };

        Assert.Multiple(() =>
        {
            Assert.That(SgsCaseIdentity.Resolve(workflow.AutomationFamily, reordered), Is.EqualTo(first.AutomationId));
            Assert.That(first.AutomationId, Is.Not.EqualTo(second.AutomationId));
            Assert.That(SgsCaseIdentity.Resolve(workflow.AutomationFamily, differentProfile), Is.Not.EqualTo(first.AutomationId));
        });
    }

    [Test]
    public void RuntimeQualifierPreservesSfpIdentityAndUsesAllSgsCaseDimensions()
    {
        var workflow = Catalog.Ledger.Workflows[0];
        var item = workflow.Cases[0];
        var sgsArguments = new OrderedDictionary();
        foreach (var argument in item.Arguments)
            sgsArguments.Add(argument.Key, argument.Value);
        var sfpArguments = new OrderedDictionary { ["StateAbbv"] = "AL", ["State"] = "Alabama" };
        Assert.Multiple(() =>
        {
            Assert.That(ScenarioAutomationIdentity.ResolveQualifier(["SFP"], sfpArguments), Is.EqualTo("AL"));
            Assert.That(ScenarioAutomationIdentity.Resolve(
                ["SgsImported", "AutomationId-" + workflow.AutomationFamily], [],
                ScenarioAutomationIdentity.ResolveQualifier(["SgsImported"], sgsArguments)), Is.EqualTo(item.AutomationId));
        });
    }

    [TestCase("../outside.json")]
    [TestCase("C:\\outside.json")]
    [TestCase("\\\\server\\outside.json")]
    [TestCase("TestData//profile.json")]
    public void IdentityRejectsUnownedPaths(string path)
    {
        var item = Catalog.Ledger.Workflows[0].Cases[0];
        var arguments = new Dictionary<string, string>(item.Arguments) { ["dataFile"] = path };
        Assert.That(() => SgsCaseIdentity.GetQualifier(arguments),
            Throws.TypeOf<SgsExecutionConfigurationException>());
    }

    [Test]
    public void SourceDisabledCasesCannotBeMarkedRunnable()
    {
        var ledger = Catalog.Ledger;
        var workflow = ledger.Workflows.First(item =>
            item.Cases.Any(test => test.SourceStatus == SgsSourceCaseStatus.CommentedOut));
        var disabled = workflow.Cases.First(item => item.SourceStatus == SgsSourceCaseStatus.CommentedOut);
        var changed = workflow with { Cases = [disabled with { ExecutionStatus = SgsExecutionStatus.ReadyForLocalVerification }] };
        Assert.That(() => new SgsExecutionCatalog(ledger with { Workflows = [changed] }),
            Throws.TypeOf<SgsExecutionConfigurationException>().With.Message.Contains("Source-commented"));
    }

    [Test]
    public void CaseStatusCannotBypassUnfinishedRuntimeContracts()
    {
        var ledger = Catalog.Ledger;
        var workflow = ledger.Workflows[0];
        var item = workflow.Cases[0] with
        {
            ExecutionStatus = SgsExecutionStatus.ReadyForLocalVerification,
            BlockedReason = ""
        };
        Assert.That(() => new SgsExecutionCatalog(ledger with { Workflows = [workflow with { Cases = [item] }] }),
            Throws.TypeOf<SgsExecutionConfigurationException>().With.Message.Contains("readiness"));
    }

    [Test]
    public void VerifiedStatusRequiresTwoDistinctEvidencedPasses()
    {
        var ledger = Catalog.Ledger;
        var workflow = ledger.Workflows[0] with
        {
            Readiness = new SgsWorkflowReadiness(true, true, true, true, true, true, true, true),
            Cases = [ledger.Workflows[0].Cases[0] with
            {
                ExecutionStatus = SgsExecutionStatus.Verified,
                BlockedReason = "",
                ConsecutivePassingRuns = []
            }]
        };
        Assert.That(() => new SgsExecutionCatalog(ledger with { Workflows = [workflow] }),
            Throws.TypeOf<SgsExecutionConfigurationException>().With.Message.Contains("two distinct"));
    }

    [Test]
    public void MissingCoverageAndScenarioRetriesFailInsteadOfSelectingAnotherCase()
    {
        var catalog = Catalog;
        var workflow = catalog.Ledger.Workflows[0];
        var tags = new[] { "SgsImported", "NoRetry", workflow.ApplicationTag,
            workflow.RunTypeTag, "AutomationId-" + workflow.AutomationFamily };
        var changedArguments = new Dictionary<string, string>(workflow.Cases[0].Arguments)
        {
            ["dataFile"] = "TestData/Scenarios/unknown.json"
        };
        Assert.Multiple(() =>
        {
            Assert.That(() => catalog.Resolve(workflow.Feature, tags, changedArguments),
                Throws.TypeOf<SgsExecutionConfigurationException>().With.Message.Contains("ledger entry"));
            Assert.That(() => catalog.Resolve(workflow.Feature, tags.Append("RetrySafe"), workflow.Cases[0].Arguments),
                Throws.TypeOf<SgsExecutionConfigurationException>().With.Message.Contains("retries"));
        });
    }

    private static string FindRepositoryRoot()
    {
        var directory = new DirectoryInfo(TestContext.CurrentContext.TestDirectory);
        while (directory != null)
        {
            if (File.Exists(Path.Combine(directory.FullName, "TestAutomation.csproj")))
                return directory.FullName;
            directory = directory.Parent;
        }
        throw new DirectoryNotFoundException("Could not locate the repository root.");
    }
}
