using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
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
            return scenario.Examples
                .Where(example => example.Tags.All(tag => tag.Name != "@DevOnly"))
                .SelectMany(example =>
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
                foreach (var state in ApprovedStates(variant))
                    yield return new TestCaseData(variant, state);
        }

        private static string[] ApprovedStates(string variant)
        {
            using var document = JsonDocument.Parse(File.ReadAllText(Path.Combine(
                TestContext.CurrentContext.TestDirectory, "Resources", "ExpectedForms", "SFP", "SFP.json")),
                new JsonDocumentOptions { CommentHandling = JsonCommentHandling.Skip });
            return document.RootElement.GetProperty("STATES").GetProperty(variant)
                .EnumerateArray().Select(state => state.GetString()!).ToArray();
        }

        private static string[][] ReadMatrix(string variant)
        {
            var states = ApprovedStates(variant);
            var expected = states.Select(state => Validator.LoadExpectedFormsForLob("SFP", state, variant))
                .ToArray();
            return new[] { new[] { "Type", "Form" }.Concat(states).ToArray() }
                .Concat(expected[0].Select((form, index) =>
                    new[] { form.Type, form.FormName }
                        .Concat(expected.Select(forms => forms[index].ExpectedStatus)).ToArray()))
                .ToArray();
        }

        [TestCase("BASIC", 201, "B", 41, 164)]
        [TestCase("CE", 189, "C", 41, 164)]
        public void DeployedBaseline_CoversApprovedStatesWithExplicitExpectations(
            string variant, int count, string type, int stateCount, int commonCount)
        {
            var matrix = ReadMatrix(variant);
            var scenarioStates = ExampleStates(variant);
            var baselineStates = matrix[0].Skip(2).ToArray();
            Assert.Multiple(() =>
            {
                Assert.That(scenarioStates, Has.Length.EqualTo(41));
                Assert.That(scenarioStates, Is.Unique);
                Assert.That(baselineStates, Has.Length.EqualTo(stateCount));
                Assert.That(baselineStates, Is.Unique);
                Assert.That(baselineStates, Is.Ordered.Using<string>(StringComparer.Ordinal));
                Assert.That(baselineStates, Is.EquivalentTo(scenarioStates));
                Assert.That(matrix.Skip(1), Has.Count.EqualTo(count));
                Assert.That(matrix.Skip(1).Select(row => row[1]), Is.Unique);
                Assert.That(matrix.Skip(1).All(row => !string.IsNullOrWhiteSpace(row[1])), Is.True);
                Assert.That(matrix.Skip(1).All(row => row[0] == "BASE" || row[0] == type), Is.True);
                Assert.That(matrix.Skip(1).SelectMany(row => row.Skip(2)).All(value => value is "YM" or "N"),
                    Is.True, "JSON must resolve every declared form to an explicit expectation");
                Assert.That(matrix.Skip(1).Count(row => row[0] == "BASE"), Is.EqualTo(commonCount));
            });
        }

        [TestCase("BASIC", "MN", "SF00030120", "N")]
        [TestCase("CE", "MN", "SF00030426", "YM")]
        [TestCase("BASIC", "NH", "SF07050826", "YM")]
        [TestCase("BASIC", "CT", "X31610525", "YM")]
        [TestCase("BASIC", "MD", "SF01570726", "YM")]
        [TestCase("CE", "MD", "SF01850726", "YM")]
        [TestCase("CE", "MD", "SF07120826", "YM")]
        [TestCase("CE", "PA", "SF06770120", "YM")]
        [TestCase("CE", "VT", "SF06770120", "N")]
        [TestCase("BASIC", "MD", "X32940120", "N")]
        [TestCase("BASIC", "MT", "SF06200510", "N")]
        [TestCase("BASIC", "ND", "SF06200510", "N")]
        [TestCase("BASIC", "ND", "X35690422", "N")]
        [TestCase("BASIC", "TN", "SF06200510", "YM")]
        [TestCase("BASIC", "TN", "X35690422", "YM")]
        [TestCase("CE", "MT", "SF06200510", "N")]
        [TestCase("CE", "TN", "SF06200510", "YM")]
        [TestCase("CE", "TN", "X35690422", "YM")]
        public void ApprovedMasterUpdates_ResolveExpectedStatus(
            string variant, string state, string formName, string status)
        {
            var expected = Validator.LoadExpectedFormsForLob("SFP", state, variant);
            Assert.That(expected.Single(form => form.FormName == formName).ExpectedStatus, Is.EqualTo(status));
        }

        [TestCase("BASIC", "NH", "SF07050326")]
        [TestCase("CE", "MD", "SF07120726")]
        [TestCase("BASIC", "MD", "SF01570714")]
        [TestCase("CE", "MD", "SF01850714")]
        public void RetiredMasterEditions_AreInformationalIfReturned(string variant, string state, string formName)
        {
            var expected = Validator.LoadExpectedFormsForLob("SFP", state, variant);
            Assert.That(expected.Select(form => form.FormName), Does.Not.Contain(formName));
            var summary = Validator.Validate(expected,
                new List<ActualFormEntry> { new() { Name = formName, Selected = 2 } }, "SFP", state, "offline");
            Assert.That(summary.Results.Single(result => result.FormName == formName).Result, Is.EqualTo("INFO"));
        }

        [TestCaseSource(nameof(BaselineStates))]
        public void RuntimeLoader_EnforcesJsonMandatoryAndExcludedForms(string variant, string state)
        {
            var expected = Validator.LoadExpectedFormsForLob("SFP", state, variant);
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

        [TestCase("BASIC", "DC")]
        [TestCase("CE", "DC")]
        public void RuntimeLoader_RejectsStatesOutsideTheMasterInventory(string variant, string state)
        {
            var error = Assert.Throws<InvalidOperationException>(
                () => Validator.LoadExpectedFormsForLob("SFP", state, variant));
            Assert.That(error!.Message, Does.Contain($"State '{state}' is not approved in SFP.json for {variant}"));
        }

        [TestCase("BASIC", 201)]
        [TestCase("CE", 189)]
        public void RecordMode_CanSeedProposalFromScenarioBaseline(string variant, int count)
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
        public void CommonForms_PreserveTheSameStateMatrixInBothVariants()
        {
            var basic = ReadMatrix("BASIC");
            var ce = ReadMatrix("CE");
            var sharedColumns = ce[0].Select(column => Array.IndexOf(basic[0], column)).ToArray();
            Assert.That(sharedColumns.All(column => column >= 0), Is.True);
            var ceCommonRows = ce.Skip(1).Where(row => row[0] == "BASE").ToArray();
            var sharedForms = ceCommonRows.Select(row => row[1]).ToHashSet(StringComparer.Ordinal);
            Assert.That(basic.Skip(1).Where(row => row[0] == "BASE" && sharedForms.Contains(row[1]))
                .Select(row => sharedColumns.Select(column => row[column]).ToArray()),
                Is.EqualTo(ceCommonRows));
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

        [TestCase("BASIC", "DB9A0B12E055CBCE3C496E1FFD55C04D5BCEBCDA52788B2209F7388DA201CABD")]
        [TestCase("CE", "FDEC8DA2F28759757ECC5EC9630258BE13F832AEA09681680BCB83A393232197")]
        public void JsonBaseline_MatchesCurrentMasterSnapshot(string variant, string expectedHash)
        {
            var lines = ApprovedStates(variant).OrderBy(state => state, StringComparer.Ordinal)
                .SelectMany(state => Validator.LoadExpectedFormsForLob("SFP", state, variant)
                    .OrderBy(form => form.FormName, StringComparer.Ordinal)
                    .Select(form => $"{state}|{form.FormName}|{form.ExpectedStatus}"));
            var hash = Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(string.Join("\n", lines) + "\n")));
            Assert.That(hash, Is.EqualTo(expectedHash), "Preserve the current masters and documented coverage/exclusion adjustments");
        }

        [Test]
        public void SourceAndDeployedSfpBaselines_AreJsonOnly()
        {
            foreach (var root in new[] { ProjectRoot(), TestContext.CurrentContext.TestDirectory })
            {
                var directory = Path.Combine(root, "Resources", "ExpectedForms", "SFP");
                Assert.That(File.Exists(Path.Combine(directory, "SFP.json")), Is.True);
                foreach (var obsolete in new[] { "SFP.csv", "SFP_BASIC.csv", "SFP_CE.csv" })
                    Assert.That(File.Exists(Path.Combine(directory, obsolete)), Is.False, obsolete);
            }
        }

        [Test]
        public void JsonLoader_PreservesAllSelectionStatusesAndExcludedForms()
        {
            var expected = LoadJsonFixture("""
                {
                  "STATES": { "BASIC": ["MD", "PA"] },
                  "BASE": { "MANDATORY": "all", "EXCLUDED": ["PA"] },
                  "BASIC": { "SELECTED": { "MD": "YS" }, "UNCHECKED": { "MD": "YU" }, "PROHIBITED": { "MD": "N" } }
                }
                """);
            Assert.That(expected.Select(form => form.ExpectedStatus), Is.EqualTo(new[] { "YM", "N", "YS", "YU", "N" }));
        }

        [TestCase("""{"BASE": {}, "BASIC": { "F1": "all" }}""")]
        [TestCase("""{"STATES": {"BASIC": []}, "BASE": {}, "BASIC": {"F1": "all"}}""")]
        [TestCase("""{"STATES": {"BASIC": ["MD", "MD"]}, "BASE": {}, "BASIC": {"F1": "all"}}""")]
        [TestCase("""{"STATES": {"BASIC": ["MD"]}, "BASE": {"F1": "all"}, "BASIC": {"F1": "all"}}""")]
        [TestCase("""{"STATES": {"BASIC": ["MD"]}, "BASE": {}, "BASIC": {"F1": "all", "F1": []}}""")]
        [TestCase("""{"STATES": {"BASIC": ["MD"]}, "BASE": {}, "BASIC": {"F1": {"MD": "YO"}}}""")]
        [TestCase("""{"STATES": {"BASIC": ["MD"]}, "BASE": {}, "BASIC": {"F1": ["XX"]}}""")]
        [TestCase("""{"STATES": {"BASIC": ["MD"]}, "BASE": {}, "BASIC": {"F1": ["MD", "MD"]}}""")]
        [TestCase("""{"STATES": {"BASIC": ["MD"]}, "BASE": {}, "BASIC": {"F1": null}}""")]
        [TestCase("""{"STATES": {"BASIC": ["MD"]}, "BASE": {}, "BASIC": {}}""")]
        public void JsonLoader_RejectsAmbiguousOrInvalidExpectations(string json)
        {
            Assert.Throws<InvalidOperationException>(() => LoadJsonFixture(json));
        }

        [Test]
        [NonParallelizable]
        public void JsonRecording_AccumulatesStatesWithoutChangingTheApprovedBaseline()
        {
            JsonSerializer.Serialize(new Dictionary<string, string>());
            var originalBase = AppContext.GetData("APP_CONTEXT_BASE_DIRECTORY");
            var temporaryBase = Path.Combine(TestContext.CurrentContext.WorkDirectory,
                $"sfp-recording-test-{Guid.NewGuid():N}");
            var directory = Path.Combine(temporaryBase, "Resources", "ExpectedForms", "SFP");
            var proposalPath = Path.Combine(directory, "SFP_BASIC_PROPOSED.json");
            Directory.CreateDirectory(directory);
            try
            {
                AppDomain.CurrentDomain.SetData("APP_CONTEXT_BASE_DIRECTORY", temporaryBase + Path.DirectorySeparatorChar);
                var template = new List<ExpectedFormEntry>
                {
                    new() { FormName = "FORMONE", Type = "BASE", ExpectedStatus = "N" },
                    new() { FormName = "FORMTWO", Type = "B", ExpectedStatus = "N" }
                };
                Validator.SaveProposedBaseline(
                    new List<ActualFormEntry> { new() { Name = "FORMONE", Selected = 2 } },
                    template, "SFP", "MD", "BASIC");
                Validator.SaveProposedBaseline(
                    new List<ActualFormEntry>
                    {
                        new() { Name = "FORMONE", Selected = 1 },
                        new() { Name = "NEWFORM", Selected = 0 }
                    },
                    template, "SFP", "PA", "BASIC");
                var md = Validator.LoadFromSfpJson(proposalPath, "MD");
                var pa = Validator.LoadFromSfpJson(proposalPath, "PA");
                Assert.Multiple(() =>
                {
                    Assert.That(md.Select(form => form.ExpectedStatus), Is.EqualTo(new[] { "YM", "N", "N" }));
                    Assert.That(pa.Select(form => form.ExpectedStatus), Is.EqualTo(new[] { "YS", "N", "YU" }));
                    Assert.That(Directory.GetFiles(directory).Select(Path.GetFileName),
                        Is.EqualTo(new[] { "SFP_BASIC_PROPOSED.json" }));
                });
            }
            finally
            {
                AppDomain.CurrentDomain.SetData("APP_CONTEXT_BASE_DIRECTORY", originalBase);
                if (File.Exists(proposalPath)) File.Delete(proposalPath);
                Directory.Delete(directory);
                Directory.Delete(Path.GetDirectoryName(directory)!);
                Directory.Delete(Path.Combine(temporaryBase, "Resources"));
                Directory.Delete(temporaryBase);
            }
        }

        private static List<ExpectedFormEntry> LoadJsonFixture(string json)
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources",
                $"sfp-json-test-{Guid.NewGuid():N}.json");
            File.WriteAllText(path, json);
            try { return Validator.LoadFromSfpJson(path, "MD"); }
            finally { File.Delete(path); }
        }
    }
}
