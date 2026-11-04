using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Gherkin;
using Gherkin.Ast;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using PnCTestAutomation.Helpers;
using PnCTestAutomation.Models;
using PnCTestAutomation.Services;

namespace PnCTestAutomation.Tests
{
    [TestFixture]
    public class SfpChecklistOutageModeTests
    {
        [TestCase("SFP Basic Policy")]
        [TestCase("SFP Country Estate Policy")]
        [TestCase("SFP Rate Policy")]
        public void OutageMode_IsConfigurableAndRestrictedToAffectedFeatures(string feature)
        {
            Assert.Multiple(() =>
            {
                Assert.That(SfpChecklistOutageMode.IsEnabled(null, feature), Is.False);
                Assert.That(SfpChecklistOutageMode.IsEnabled("false", feature), Is.False);
                Assert.That(SfpChecklistOutageMode.IsEnabled("TRUE", feature), Is.True);
                Assert.Throws<InvalidOperationException>(
                    () => SfpChecklistOutageMode.IsEnabled("yes", feature));
            });
        }

        [Test]
        public void AppSettings_DisablesOutageModeAndAllowsAnExplicitOverride()
        {
            var path = Path.Combine(AppContext.BaseDirectory, "appsettings.json");
            var defaults = new ConfigurationBuilder().AddJsonFile(path).Build();
            var formsOnlyRun = new ConfigurationBuilder().AddJsonFile(path)
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    [SfpChecklistOutageMode.Setting] = "true"
                }).Build();

            Assert.That(SfpChecklistOutageMode.IsEnabled(
                defaults[SfpChecklistOutageMode.Setting], "SFP Basic Policy"), Is.False);
            Assert.That(SfpChecklistOutageMode.IsEnabled(
                formsOnlyRun[SfpChecklistOutageMode.Setting], "SFP Basic Policy"), Is.True);
        }

        [TestCase("SFP Smoke Test")]
        [TestCase("Forms Validation Smoke Test")]
        [TestCase("BOP Basic Policy")]
        public void OutageMode_DoesNotAffectOtherFeatures(string feature)
        {
            Assert.That(SfpChecklistOutageMode.IsEnabled("true", feature), Is.False);
        }

        [Test]
        public void OutageMode_RequiresComparisonRatherThanBaselineRecording()
        {
            Assert.DoesNotThrow(() => SfpChecklistOutageMode.RequireComparisonMode(false));
            Assert.That(
                Assert.Throws<InvalidOperationException>(
                    () => SfpChecklistOutageMode.RequireComparisonMode(true))!.Message,
                Does.Contain("approved baseline"));
        }

        [Test]
        public void OutageMode_RejectsEmptyFormsResponses()
        {
            Assert.DoesNotThrow(() => SfpChecklistOutageMode.RequireReturnedForms(1));
            Assert.That(
                Assert.Throws<InvalidOperationException>(
                    () => SfpChecklistOutageMode.RequireReturnedForms(0))!.Message,
                Does.Contain("no forms"));
        }

        [Test]
        public void OutageMode_RequiresAnApplicableBaselineForm()
        {
            Assert.Throws<InvalidOperationException>(
                () => SfpChecklistOutageMode.RequireComparableBaseline(Array.Empty<ExpectedFormEntry>()));
            Assert.Throws<InvalidOperationException>(
                () => SfpChecklistOutageMode.RequireComparableBaseline(
                    new[] { new ExpectedFormEntry { ExpectedStatus = "N" } }));
            Assert.DoesNotThrow(
                () => SfpChecklistOutageMode.RequireComparableBaseline(
                    new[] { new ExpectedFormEntry { ExpectedStatus = "YM" } }));
        }

        [Test]
        public void OutageMode_DoesNotMarkTheFullWorkflowAsPassed()
        {
            var error = Assert.Throws<IgnoreException>(
                SfpChecklistOutageMode.MarkWorkflowIncomplete);
            Assert.That(error!.Message, Does.Contain("Checklist and Transmit were not tested")
                .And.Contain("not a full workflow pass"));
        }

        [TestCase("SFP_BasicPolicy.feature", "SFP Basic Policy", "user verifies no referrals are needed")]
        [TestCase("SFP_CE.feature", "SFP Country Estate Policy", "user verifies no referrals are needed")]
        [TestCase("SFP_RatePolicy.feature", "SFP Rate Policy", "user verifies referral is required")]
        public void CanonicalFlow_RetainsPricingReferralAndForms(string feature, string featureTitle, string referral)
        {
            var root = new DirectoryInfo(TestContext.CurrentContext.TestDirectory);
            while (root != null && !File.Exists(Path.Combine(root.FullName, "TestAutomation.csproj")))
                root = root.Parent;
            Assert.That(root, Is.Not.Null);
            var parsedFeature = new Parser()
                .Parse(Path.Combine(root!.FullName, "Features", "SFP", feature)).Feature;
            Assert.That(parsedFeature.Name, Is.EqualTo(featureTitle));
            Assert.That(SfpChecklistOutageMode.IsEnabled("true", parsedFeature.Name), Is.True);
            var scenario = parsedFeature.Children.OfType<Scenario>().Single();
            var steps = scenario.Steps.Select(step => step.Text).ToArray();
            var pricing = Array.IndexOf(steps, "user verifies Premium on Pricing screen");
            var submission = Array.IndexOf(steps, "user navigates to Submission and opens Checklist");
            var referralIndex = Array.IndexOf(steps, referral);
            var forms = Array.IndexOf(steps, "user validates Forms via Duckcreek for state \"<StateAbbv>\"");
            Assert.That(pricing, Is.GreaterThanOrEqualTo(0));
            Assert.That(submission, Is.GreaterThan(pricing));
            Assert.That(referralIndex, Is.GreaterThan(submission));
            Assert.That(forms, Is.GreaterThan(referralIndex));
        }

        [TestCase(0, 0, "Passed")]
        [TestCase(1, 0, "Failed")]
        [TestCase(0, 1, "Failed")]
        public void SeparateFormsResult_ReportsTheActualComparison(int failed, int issues, string outcome)
        {
            var outputDirectory = Path.Combine(Path.GetTempPath(), $"SfpChecklistOutage_{Guid.NewGuid():N}");
            var summary = new FormsValidationSummary
            {
                LOB = "SFP",
                State = "AL",
                QuoteId = "quote&1",
                TestCaseName = "SFP_BASIC",
                Failed = failed,
                Issues = issues
            };
            try
            {
                FormsReportGenerator.WriteTrxResults(summary, outputDirectory, checklistOutageFormsOnly: true);
                var trx = XDocument.Load(Directory.GetFiles(outputDirectory, "*.trx").Single());
                XNamespace ns = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010";
                var result = trx.Descendants(ns + "UnitTestResult").Single();
                Assert.Multiple(() =>
                {
                    Assert.That((string)result.Attribute("outcome"), Is.EqualTo(outcome));
                    Assert.That((string)result.Attribute("testName"),
                        Does.Contain("Forms Only (Checklist outage)").And.Contain("Quote quote&1"));
                });
            }
            finally
            {
                if (Directory.Exists(outputDirectory))
                    Directory.Delete(outputDirectory, recursive: true);
            }
        }

        [TestCase(2, true)]
        [TestCase(0, false)]
        public void FormsOnly_UsesTheRealFormsComparison(int selected, bool expectedPass)
        {
            var expected = new System.Collections.Generic.List<ExpectedFormEntry>
            {
                new() { FormName = "TESTFORM", ExpectedStatus = "YM" }
            };
            var actual = new System.Collections.Generic.List<ActualFormEntry>
            {
                new() { Name = "TESTFORM", Selected = selected }
            };
            SfpChecklistOutageMode.RequireComparableBaseline(expected);
            SfpChecklistOutageMode.RequireReturnedForms(actual.Count);
            var summary = new FormsValidationService(new DuckCreekFormsConfig())
                .Validate(expected, actual, "SFP", "AL", "quote");
            Assert.That(summary.AllPassed, Is.EqualTo(expectedPass));
        }
    }
}
