using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Gherkin;
using Gherkin.Ast;
using NUnit.Framework;
using PnCTestAutomation.Models;
using PnCTestAutomation.Services;

namespace PnCTestAutomation.Tests
{
    [TestFixture]
    public class SfpFormsBaselineTests
    {
        private static readonly FormsValidationService Validator = new(new DuckCreekFormsConfig());
        private static readonly string[] UnqualifiedStates = { "MD", "PA", "VT" };

        private static string ProjectRoot()
        {
            var directory = new DirectoryInfo(TestContext.CurrentContext.TestDirectory);
            while (directory != null && !File.Exists(Path.Combine(directory.FullName, "TestAutomation.csproj")))
                directory = directory.Parent;
            return directory?.FullName
                ?? throw new InvalidOperationException("Cannot locate the canonical SFP features.");
        }

        private static string[] ExampleStates(string variant)
        {
            var file = variant == "BASIC" ? "SFP_BasicPolicy.feature" : "SFP_CE.feature";
            var scenario = new Parser().Parse(Path.Combine(ProjectRoot(), "Features", "SFP", file))
                .Feature.Children.OfType<Scenario>().Single();
            return scenario.Examples.SelectMany(example =>
            {
                var headers = example.TableHeader.Cells.Select(cell => cell.Value).ToArray();
                var stateColumn = Array.IndexOf(headers, "StateAbbv");
                if (stateColumn < 0)
                    throw new InvalidOperationException($"Missing StateAbbv in {file}.");
                return example.TableBody.Select(row => row.Cells.ElementAt(stateColumn).Value);
            }).ToArray();
        }

        public static IEnumerable<TestCaseData> BaselineStates()
        {
            foreach (var variant in new[] { "BASIC", "CE" })
                foreach (var state in ReadCsv(variant)[0].Skip(2))
                    yield return new TestCaseData(variant, state);
        }

        private static string[][] ReadCsv(string variant) =>
            File.ReadAllLines(Path.Combine(TestContext.CurrentContext.TestDirectory,
                "Resources", "ExpectedForms", "SFP", $"SFP_{variant}.csv"))
                .Select(line => line.Split(',')).ToArray();

        [TestCase("BASIC", 182, "B")]
        [TestCase("CE", 169, "C")]
        public void DeployedBaseline_CoversQualifiedStatesWithoutInventingNewStateExpectations(
            string variant, int count, string type)
        {
            var csv = ReadCsv(variant);
            var scenarioStates = ExampleStates(variant);
            var baselineStates = csv[0].Skip(2).ToArray();
            Assert.Multiple(() =>
            {
                Assert.That(scenarioStates, Has.Length.EqualTo(41));
                Assert.That(scenarioStates, Is.Unique);
                Assert.That(csv[0].Take(2), Is.EqualTo(new[] { "Type", "Form" }));
                Assert.That(baselineStates, Has.Length.EqualTo(38));
                Assert.That(baselineStates, Is.Unique);
                Assert.That(baselineStates, Is.EquivalentTo(scenarioStates.Except(UnqualifiedStates)));
                Assert.That(baselineStates.Intersect(UnqualifiedStates), Is.Empty);
                Assert.That(csv[0], Is.Unique);
                Assert.That(csv.Skip(1), Has.Count.EqualTo(count));
                Assert.That(csv.All(row => row.Length == csv[0].Length), Is.True, "Missing or shifted state cells");
                Assert.That(csv.Skip(1).Select(row => row[1]), Is.Unique);
                Assert.That(csv.Skip(1).All(row => !string.IsNullOrWhiteSpace(row[1])), Is.True);
                Assert.That(csv.Skip(1).All(row => row[0] == "BASE" || row[0] == type), Is.True);
                Assert.That(csv.Skip(1).SelectMany(row => row.Skip(2)).All(value => value is "YM" or "N"),
                    Is.True, "The approved matrices must not contain blank or implicit expectations");
                Assert.That(csv.Skip(1).Count(row => row[0] == "BASE"), Is.EqualTo(147));
            });
        }

        [TestCaseSource(nameof(BaselineStates))]
        public void RuntimeLoader_PreservesEveryCsvExpectationAndEnforcesIt(string variant, string state)
        {
            var csv = ReadCsv(variant);
            var column = Array.IndexOf(csv[0], state);
            Assert.That(column, Is.GreaterThanOrEqualTo(2));
            var expected = Validator.LoadExpectedFormsForLob("SFP", state, variant);
            Assert.That(expected.Select(form => (form.Type, form.FormName, form.ExpectedStatus)),
                Is.EqualTo(csv.Skip(1).Select(row => (row[0], row[1], row[column]))),
                "The runtime must select the scenario CSV, not the legacy JSON fallback");

            var actual = expected.Where(form => form.ExpectedStatus == "YM")
                .Select(form => new ActualFormEntry { Name = form.FormName, Selected = 2 }).ToList();
            var summary = Validator.Validate(expected, actual, "SFP", state, "offline");
            Assert.Multiple(() =>
            {
                Assert.That(summary.Passed, Is.EqualTo(actual.Count));
                Assert.That(summary.TotalForms, Is.EqualTo(actual.Count), "Correctly absent N rows are suppressed");
                Assert.That(summary.Failed + summary.Issues + summary.Info, Is.Zero);
                Assert.That(expected.Single(form => form.FormName == "SF04010120").ExpectedStatus, Is.EqualTo("YM"));
                Assert.That(expected.Select(form => form.FormName),
                    Does.Not.Contain("X42960309").And.Not.Contain("X43061125").And.Not.Contain("SM1703E"),
                    "Administration forms are not part of the policy-output baseline");
            });

            actual.RemoveAll(form => form.Name == "SF04010120");
            summary = Validator.Validate(expected, actual, "SFP", state, "offline");
            Assert.That(summary.Failed, Is.EqualTo(1));
            Assert.That(summary.Results.Single(form => form.FormName == "SF04010120").ResultCode, Is.EqualTo("C11"));
            actual.Add(new ActualFormEntry { Name = "SF04010120", Selected = 2 });

            var prohibited = expected.First(form => form.ExpectedStatus == "N").FormName;
            foreach (var selected in new[] { 0, 1, 2 })
            {
                actual.Add(new ActualFormEntry { Name = prohibited, Selected = selected });
                summary = Validator.Validate(expected, actual, "SFP", state, "offline");
                Assert.That(summary.Failed, Is.EqualTo(1), $"Explicit N must reject selected={selected}");
                Assert.That(summary.Results.Single(form => form.FormName == prohibited).ResultCode,
                    Is.EqualTo(selected == 0 ? "C7" : selected == 1 ? "C9" : "C5"));
                actual.RemoveAt(actual.Count - 1);
            }
        }

        [TestCase("BASIC", "MD")]
        [TestCase("BASIC", "PA")]
        [TestCase("BASIC", "VT")]
        [TestCase("CE", "MD")]
        [TestCase("CE", "PA")]
        [TestCase("CE", "VT")]
        public void RuntimeLoader_RejectsNewStatesUntilFormsBaselinesAreQualified(string variant, string state)
        {
            var error = Assert.Throws<InvalidOperationException>(
                () => Validator.LoadExpectedFormsForLob("SFP", state, variant));
            Assert.That(error!.Message, Does.Contain($"State column '{state}' not found"));
        }

        [TestCase("BASIC", 182)]
        [TestCase("CE", 169)]
        public void RecordMode_CanSeedProposalBeforeNewStateColumnsExist(string variant, int count)
        {
            var template = Validator.LoadExpectedFormsTemplateForRecording("SFP", variant);
            Assert.Multiple(() =>
            {
                Assert.That(template, Has.Count.EqualTo(count));
                Assert.That(template.Select(form => form.FormName), Is.Unique);
                Assert.That(template.All(form => form.Type is "BASE" or "B" or "C"), Is.True);
            });
        }

        [Test]
        public void CommonForms_PreserveTheSameFullStateMatrixInBothVariants()
        {
            var basic = ReadCsv("BASIC");
            var ce = ReadCsv("CE");
            Assert.That(basic[0], Is.EqualTo(ce[0]));
            Assert.That(basic.Skip(1).Where(row => row[0] == "BASE"),
                Is.EqualTo(ce.Skip(1).Where(row => row[0] == "BASE")));
        }

        [TestCase("BASIC")]
        [TestCase("CE")]
        public void AlabamaBaseline_RequiresSharedWindMitigationAndBasicEquipmentBreakdown(string variant)
        {
            var expected = Validator.LoadExpectedFormsForLob("SFP", "AL", variant);
            Assert.That(expected.Single(form => form.FormName == "X51181225").ExpectedStatus, Is.EqualTo("YM"));
            if (variant == "BASIC")
                Assert.That(expected.Single(form => form.FormName == "SF26891023").ExpectedStatus, Is.EqualTo("YM"));
        }
    }
}
