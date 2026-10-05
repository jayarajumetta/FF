using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;
using Gherkin;
using Gherkin.Ast;
using NUnit.Framework;
using PnCTestAutomation.Models;
using PnCTestAutomation.Parsers;
using PnCTestAutomation.Services;

namespace PnCTestAutomation.Tests
{
    [TestFixture]
    public class SfpFormsBaselineTests
    {
        private static readonly FormsValidationService Validator = new(new DuckCreekFormsConfig());
        private static readonly string[] ObservedBasicStates = { "MD", "PA", "VT" };
        private static readonly Dictionary<string, (string[] Missing, string[] Unexpected)> ObservedDifferences = new()
        {
            ["VT"] = (new[] { "SF05400917", "SF05500726", "SF06110413", "SF07410726", "SF26600726" },
                new[] { "SF05500203", "SF06210704", "SF26620221" }),
            ["MD"] = (new[] { "SF07120726", "SF01570714", "X44440225" },
                new[] { "X35690422", "SF01570726", "SF07120826", "SF26620221" }),
            ["PA"] = (new[] { "SF06080498", "SF07110726", "SF06200510", "X35690422" },
                Array.Empty<string>())
        };

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
                foreach (var state in ApprovedStates(variant))
                    yield return new TestCaseData(variant, state);
        }

        public static IEnumerable<TestCaseData> ObservedBasicRuns()
        {
            yield return new TestCaseData("VT", 25, new[]
            {
                "FI99020121", "NM3421025", "SF00010120", "SF00020120", "SF00030426",
                "SF01010120", "SF01020125", "SF01251225", "SF03010120", "SF03051225",
                "SF04010120", "SF05010426", "SF05500203", "SF06171112", "SF06210704",
                "SF15020626", "SF26370322", "SF26620221", "SF36161024", "X32940120",
                "X51360120", "X51370120", "X51820618", "X52090726", "X52780125"
            });
            yield return new TestCaseData("MD", 34, new[]
            {
                "FI99020121", "NM3421025", "SF00010120", "SF00020120", "SF00030426",
                "SF01010120", "SF01251225", "SF01570726", "SF03010120", "SF03050195",
                "SF04010120", "SF05010426", "SF05280709", "SF05500203", "SF06090998",
                "SF06101098", "SF06190714", "SF06200510", "SF06210704", "SF07120826",
                "SF15020810", "SF26590320", "SF26620221", "SF26680522", "SF36161024",
                "X28000726", "X32940120", "X35690422", "X37601013", "X45900120",
                "X51360120", "X51370120", "X51820618", "X52780125"
            });
            yield return new TestCaseData("PA", 26, new[]
            {
                "FI99020121", "NM3421025", "SF00010120", "SF00020120", "SF00030426",
                "SF01010120", "SF01021112", "SF01251225", "SF03010120", "SF03050195",
                "SF04010120", "SF05010426", "SF05280709", "SF05490120", "SF06101098",
                "SF06171112", "SF15020810", "SF26370322", "SF26590320", "SF36161024",
                "X32940120", "X45900120", "X51360120", "X51370120", "X51820618", "X52780125"
            });
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

        [TestCase("BASIC", 201, "B", 41, 162)]
        [TestCase("CE", 187, "C", 41, 162)]
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

        [TestCaseSource(nameof(ObservedBasicRuns))]
        public void SavedBasicObservations_ReportDifferencesFromCurrentMasters(
            string state, int count, string[] formIds)
        {
            var expected = Validator.LoadExpectedFormsForLob("SFP", state, "BASIC");
            var included = expected.Where(form => form.ExpectedStatus != "N").ToArray();
            var differences = ObservedDifferences[state];
            Assert.Multiple(() =>
            {
                Assert.That(formIds, Has.Length.EqualTo(count));
                Assert.That(formIds, Is.Unique);
                Assert.That(included, Has.Length.EqualTo(count + differences.Missing.Length - differences.Unexpected.Length));
                Assert.That(included.Select(form => form.ExpectedStatus), Is.All.EqualTo("YM"));
            });

            var xml = new XElement("server", new XElement("responses",
                new XElement("FormsEngine.initPrintJobRs", new XElement("printJob",
                    new XAttribute("name", "_TransactionPrint"),
                    formIds.Select(id => new XElement("printDoc",
                        new XAttribute("name", id),
                        new XAttribute("selected", "2"),
                        new XAttribute("printDefault", "Mandatory")))))));
            var actual = FormsXmlParser.Parse(xml.ToString(SaveOptions.DisableFormatting));
            var summary = Validator.Validate(expected, actual, "SFP", state, "offline");
            Assert.Multiple(() =>
            {
                Assert.That(actual, Has.Count.EqualTo(count));
                Assert.That(summary.Passed, Is.EqualTo(count - differences.Unexpected.Length));
                Assert.That(summary.Failed, Is.EqualTo(differences.Missing.Length + differences.Unexpected.Length));
                Assert.That(summary.Issues + summary.Info, Is.Zero);
                Assert.That(summary.Results.Where(result => result.ResultCode == "C11").Select(result => result.FormName),
                    Is.EquivalentTo(differences.Missing));
                Assert.That(summary.Results.Where(result => result.ResultCode == "C5").Select(result => result.FormName),
                    Is.EquivalentTo(differences.Unexpected));
            });
        }

        [TestCase("BASIC", "ADC3CB9B1F9254204E60D169D3EC081989C5C1B4BCA22F0247440DB98802AE90")]
        [TestCase("CE", "FF2B4B2DA980A2485C761DE3061DDA80B847A19900565E2EA61F84EDE8A77E05")]
        public void LegacyStates_PreserveApprovedMandatoryForms(string variant, string expectedHash)
        {
            var states = ApprovedStates(variant).Except(ObservedBasicStates).OrderBy(state => state, StringComparer.Ordinal).ToArray();
            var lines = states.SelectMany(state => Validator.LoadExpectedFormsForLob("SFP", state, variant)
                .Where(form => form.ExpectedStatus == "YM").OrderBy(form => form.FormName, StringComparer.Ordinal)
                .Select(form => $"{state}|{form.FormName}"));
            var hash = Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(string.Join("\n", lines) + "\n")));
            Assert.That(states, Has.Length.EqualTo(38));
            Assert.That(hash, Is.EqualTo(expectedHash), "The refresh must preserve required forms in the 38 legacy states");
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
        [TestCase("CE", 187)]
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

        [TestCase("BASIC", "61E6F3418DF06278B221F5C34C9231BE3AADFC9325B133FA1EF402502C26AA86")]
        [TestCase("CE", "820F8B4C83C9AD6FEB2E7F09906DAF0DB2FCF9BD4325E0F326B7AF1913165068")]
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
