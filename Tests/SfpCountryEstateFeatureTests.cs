using System;
using System.IO;
using System.Linq;
using Gherkin;
using Gherkin.Ast;
using NUnit.Framework;
using PnCTestAutomation.Helpers;
using PnCTestAutomation.Hooks;

namespace PnCTestAutomation.Tests
{
    [TestFixture]
    public class SfpCountryEstateFeatureTests
    {
        private static readonly string[] NewStateAbbreviations = { "MD", "PA", "VT" };

        private static Scenario ReadScenario(string featureFile = "SFP_CE.feature")
        {
            var directory = new DirectoryInfo(TestContext.CurrentContext.TestDirectory);
            while (directory != null && !File.Exists(Path.Combine(directory.FullName, "TestAutomation.csproj")))
                directory = directory.Parent;
            if (directory == null)
                throw new InvalidOperationException("Cannot locate TestAutomation.csproj for the canonical SFP feature.");
            var path = Path.Combine(directory.FullName, "Features", "SFP", featureFile);
            return new Parser().Parse(path).Feature.Children.OfType<Scenario>().Single();
        }

        [Test]
        public void CanonicalCeFinalization_MatchesBasicStepOrderAndAllTableValues()
        {
            var basicSteps = ReadScenario("SFP_BasicPolicy.feature").Steps.ToArray();
            var ceSteps = ReadScenario().Steps.ToArray();
            const string pricingStep = "user verifies Premium on Pricing screen";
            var basicStart = Array.FindIndex(basicSteps, step => step.Text == pricingStep);
            var ceStart = Array.FindIndex(ceSteps, step => step.Text == pricingStep);
            Assert.That(basicStart, Is.GreaterThanOrEqualTo(0));
            Assert.That(ceStart, Is.GreaterThanOrEqualTo(0));

            var expected = basicSteps.Skip(basicStart).ToArray();
            var actual = ceSteps.Skip(ceStart).ToArray();
            Assert.That(actual, Has.Length.EqualTo(expected.Length));
            for (var i = 0; i < expected.Length; i++)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(actual[i].Keyword, Is.EqualTo(expected[i].Keyword), $"Step {i} keyword");
                    Assert.That(actual[i].Text, Is.EqualTo(expected[i].Text), $"Step {i} binding");
                    Assert.That(actual[i].Argument?.GetType(), Is.EqualTo(expected[i].Argument?.GetType()),
                        $"Step {i} argument type");
                    if (expected[i].Argument is DataTable expectedTable && actual[i].Argument is DataTable actualTable)
                        Assert.That(actualTable.Rows.Select(row => row.Cells.Select(cell => cell.Value).ToArray()).ToArray(),
                            Is.EqualTo(expectedTable.Rows.Select(row => row.Cells.Select(cell => cell.Value).ToArray()).ToArray()),
                            $"Step {i} table");
                });
            }
        }

        [Test]
        public void CanonicalCeExamples_PreserveAllStatesLeadingZeroZipsAndShardAssignments()
        {
            var examples = ReadScenario().Examples.ToArray();
            var rows = examples.SelectMany(example => example.TableBody)
                .Select(row => row.Cells.Select(cell => cell.Value).ToArray()).ToArray();
            Assert.Multiple(() =>
            {
                Assert.That(rows, Has.Length.EqualTo(41));
                Assert.That(rows.All(row => row.Length == 12), Is.True);
                Assert.That(rows.Select(row => row[1]), Is.Unique);
                Assert.That(rows.Select(row => row[5]), Is.Unique);
                Assert.That(rows.All(row => System.Text.RegularExpressions.Regex.IsMatch(row[5], @"^\d{5}$")), Is.True);
                Assert.That(rows.All(row => NewStateAbbreviations.Contains(row[1])
                    ? row[3] == ""
                    : row[3] == "111"), Is.True);
                Assert.That(rows.Single(row => row[1] == "AL"),
                    Is.EqualTo(new[]
                    {
                        "Alabama", "AL", "2210 Wood Ave", "111", "Florence", "35630", "Lauderdale",
                        "", "", "1%", "", ""
                    }));
                AssertApprovedDevStateRows(rows);
                Assert.That(rows.Single(row => row[1] == "MA")[5], Is.EqualTo("01202"));
                Assert.That(rows.Single(row => row[1] == "CT")[5], Is.EqualTo("06106"));
                Assert.That(rows.Single(row => row[1] == "ME")[5], Is.EqualTo("04736"));
                Assert.That(rows.Single(row => row[1] == "NH")[5], Is.EqualTo("03431"));
                Assert.That(rows.Single(row => row[1] == "NJ")[5], Is.EqualTo("08901"));
                Assert.That(rows.Single(row => row[1] == "RI")[5], Is.EqualTo("02904"));
                Assert.That(examples.Select(example => string.Join(" ", example.Tags.Select(tag => tag.Name))),
                    Is.EqualTo(new[]
                    {
                        "@Shard4 @Debug", "@Shard4", "@Shard5 @Debug", "@Shard5", "@Shard5 @DevOnly",
                        "@Shard6 @Debug", "@Shard6", "@Shard6 @DevOnly"
                    }));
                Assert.That(examples.Select(example => example.TableBody.Count()),
                    Is.EqualTo(new[] { 1, 13, 1, 12, 1, 1, 10, 2 }));
                AssertNewStatesAreDevOnly(examples);
            });
        }

        [Test]
        public void CanonicalBasicExamples_AddOfficialStatesWithEmptyAddressLine2AndBalancedShards()
        {
            var examples = ReadScenario("SFP_BasicPolicy.feature").Examples.ToArray();
            var rows = examples.SelectMany(example => example.TableBody)
                .Select(row => row.Cells.Select(cell => cell.Value).ToArray()).ToArray();

            Assert.Multiple(() =>
            {
                Assert.That(rows, Has.Length.EqualTo(41));
                Assert.That(rows.All(row => row.Length == 12), Is.True);
                Assert.That(rows.Select(row => row[1]), Is.Unique);
                Assert.That(rows.Select(row => row[5]), Is.Unique);
                Assert.That(rows.All(row => System.Text.RegularExpressions.Regex.IsMatch(row[5], @"^\d{5}$")), Is.True);
                Assert.That(rows.All(row => NewStateAbbreviations.Contains(row[1])
                    ? row[3] == ""
                    : !string.IsNullOrEmpty(row[3])), Is.True);
                AssertApprovedDevStateRows(rows);
                Assert.That(examples.Select(example => string.Join(" ", example.Tags.Select(tag => tag.Name))),
                    Is.EqualTo(new[]
                    {
                        "@Shard1 @Debug", "@Shard1", "@Shard1 @Pollution146",
                        "@Shard1 @Connecticut @Pollution146", "@Shard2 @Debug", "@Shard2",
                        "@Shard2 @Pollution146", "@Shard2 @DevOnly", "@Shard2 @NewJersey",
                        "@Shard3 @Debug", "@Shard3", "@Shard3 @DevOnly",
                        "@Shard3 @RhodeIsland @Pollution146"
                    }));
                Assert.That(examples.Select(example => example.TableBody.Count()),
                    Is.EqualTo(new[] { 1, 10, 2, 1, 1, 8, 3, 1, 1, 1, 9, 2, 1 }));
                Assert.That(
                    examples.Where(example => example.Tags.Any(tag => tag.Name == "@Pollution146"))
                        .SelectMany(example => example.TableBody)
                        .Select(row => row.Cells.ElementAt(1).Value),
                    Is.EquivalentTo(new[] { "CT", "DE", "GA", "MA", "ME", "NH", "RI" }));
                AssertNewStatesAreDevOnly(examples);
            });
        }

        [TestCase("DevOnly", "QA", true)]
        [TestCase("DevOnly", "Dev", false)]
        [TestCase("QAOnly", "Dev", true)]
        [TestCase("QAOnly", "QA", false)]
        [TestCase("Regression", "QA", false)]
        [TestCase("Regression", "Dev", false)]
        public void EnvironmentRestriction_EnforcesEnvironmentTags(
            string tag, string environment, bool shouldSkip)
        {
            Assert.That(TestHooks.IsEnvironmentRestricted(new[] { tag }, environment, out _),
                Is.EqualTo(shouldSkip));
        }

        [Test]
        public void QaSfpPipelines_ExcludeDevOnlyExamplesFromEveryShardFilter()
        {
            foreach (var file in new[] { "sfp-smoke-adhoc.yml", "sfp-smoke-vm.yml" })
            {
                var path = Path.Combine(ProjectRoot(), "Pipelines", file);
                var filters = File.ReadLines(path)
                    .Where(line => System.Text.RegularExpressions.Regex.IsMatch(
                        line, @"SHARD_FILTER_(FULL|DEBUG|SMOKE):\s*"""))
                    .ToArray();

                Assert.That(filters, Is.Not.Empty, file);
                Assert.That(filters.All(line => line.Contains("TestCategory!=DevOnly")), Is.True, file);
            }
        }

        [Test]
        public void DevCaptureConfiguration_AllowsEveryDevOnlyState()
        {
            var json = File.ReadAllText(Path.Combine(ProjectRoot(), "appsettings.Dev.json"));
            using var document = System.Text.Json.JsonDocument.Parse(json);
            var allowed = document.RootElement.GetProperty("StateFilters")
                .GetProperty("DevAllowedStates").EnumerateArray()
                .Select(value => value.GetString()).ToArray();

            Assert.That(allowed, Does.Contain("MD").And.Contain("PA").And.Contain("VT"));

            var recordJson = File.ReadAllText(
                Path.Combine(ProjectRoot(), "appsettings.RecordBaseline.json"));
            using var recordDocument = System.Text.Json.JsonDocument.Parse(recordJson);
            Assert.Multiple(() =>
            {
                Assert.That(recordDocument.RootElement.GetProperty("Environment").GetString(),
                    Is.EqualTo("Dev"));
                Assert.That(recordDocument.RootElement.GetProperty("Debugging")
                    .GetProperty("RecordBaseline").GetBoolean(), Is.True);
            });

            var script = File.ReadAllText(
                Path.Combine(ProjectRoot(), "Scripts", "record-new-states.ps1"));
            Assert.Multiple(() =>
            {
                Assert.That(script, Does.Contain("\"TestCategory=DevOnly\""));
                Assert.That(script, Does.Contain("RecordBaseline profile must target Dev"));
                Assert.That(script, Does.Contain("must allow exactly MD, PA, and VT"));
                Assert.That(script, Does.Contain("bin\\Debug\\net8.0"));
                Assert.That(script, Does.Contain("Expected one raw Forms XML file for each"));
                Assert.That(script, Does.Contain("$case.Variant"));
                Assert.That(script, Does.Contain("$case.State"));
                Assert.That(script, Does.Contain("$case.Quote"));
            });
        }

        private static string ProjectRoot()
        {
            var directory = new DirectoryInfo(TestContext.CurrentContext.TestDirectory);
            while (directory != null && !File.Exists(Path.Combine(directory.FullName, "TestAutomation.csproj")))
                directory = directory.Parent;
            return directory?.FullName
                ?? throw new InvalidOperationException("Cannot locate TestAutomation.csproj.");
        }

        private static void AssertNewStatesAreDevOnly(Examples[] examples)
        {
            foreach (var example in examples)
            {
                var states = example.TableBody.Select(row => row.Cells.ElementAt(1).Value).ToArray();
                var isDevOnly = example.Tags.Any(tag => tag.Name == "@DevOnly");
                Assert.That(states.Intersect(NewStateAbbreviations).Any(), Is.EqualTo(isDevOnly),
                    $"Examples block [{string.Join(", ", states)}]");
            }
        }

        private static void AssertApprovedDevStateRows(string[][] rows)
        {
            Assert.That(rows.Single(row => row[1] == "VT"),
                Is.EqualTo(new[]
                {
                    "Vermont", "VT", "69 Old River Road", "", "Woodstock", "05091", "Windsor",
                    "031", "$2,500", "1%", "None", "No"
                }));
            Assert.That(rows.Single(row => row[1] == "MD"),
                Is.EqualTo(new[]
                {
                    "Maryland", "MD", "18400 Muncaster Road", "", "Derwood", "20855", "Montgomery",
                    "007", "$1,000", "2%", "2%", "Yes"
                }));
            Assert.That(rows.Single(row => row[1] == "PA"),
                Is.EqualTo(new[]
                {
                    "Pennsylvania", "PA", "2451 Kissel Hill Road", "", "Lancaster", "17601", "Lancaster",
                    "001", "$2,000", "None", "None", "No"
                }));
        }

        [Test]
        public void CanonicalCeScheduledItems_UseApprovedValuesBeforeInsuranceScoreAndPricing()
        {
            var steps = ReadScenario().Steps.ToArray();
            var index = Array.FindIndex(steps, step => step.Text == "user adds and verifies Country Estate Scheduled Personal Property");
            Assert.That(index, Is.GreaterThanOrEqualTo(0));
            var data = (DataTable)steps[index].Argument;
            var rows = data.Rows.ToArray();
            var table = new Reqnroll.Table(rows[0].Cells.Select(cell => cell.Value).ToArray());
            foreach (var row in rows.Skip(1))
                table.AddRow(row.Cells.Select(cell => cell.Value).ToArray());
            var items = TableMappingHelpers.CountryEstateScheduledPropertyFields(table,
                new ScenarioContextData { ClientFirstName = "Jamie", ClientLastName = "Example" });
            Assert.Multiple(() =>
            {
                Assert.That(items.Select(item => item.Code), Is.EqualTo(new[] { "409", "411" }));
                Assert.That(items.Select(item => item.Amount), Is.EqualTo(new[] { 5000, 10000 }));
                Assert.That(items.Select(item => item.Description),
                    Is.EqualTo(new[] { "Stamp Collections", "Auto Trailer Home Personal Effects" }));
                Assert.That(items.All(item => item.UnattendedVehicle && item.YearOfAppraisal == null), Is.True);
                Assert.That(table.Rows[1]["NamedPersonNames"], Is.EqualTo("{{fullName}}"));
                Assert.That(items[1].NamedPersonCount, Is.EqualTo(0));
                Assert.That(items[1].NamedPersonNames, Is.EqualTo("Jamie Example"));
                Assert.That(index, Is.LessThan(Array.FindIndex(steps, step => step.Text == "user runs Insurance Score")));
                Assert.That(index, Is.LessThan(Array.FindIndex(steps, step => step.Text == "user verifies Premium on Pricing screen")));
            });
        }
    }
}
