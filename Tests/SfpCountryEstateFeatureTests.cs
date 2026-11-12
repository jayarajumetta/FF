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
        private static readonly string[] EmptyAddressLine2States = { "MD", "PA", "VT", "WV" };
        private static readonly string[] DevOnlyStateAbbreviations = { "CA", "VA", "WV" };

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
        public void CanonicalCeResidence_UsesRequestedConstructionAndRenovationYears()
        {
            var step = ReadScenario().Steps.Single(
                item => item.Text == "user adds a Country Estate Residence to the Location");
            var rows = ((DataTable)step.Argument).Rows.ToArray();
            var table = new Reqnroll.Table(rows[0].Cells.Select(cell => cell.Value).ToArray());
            foreach (var row in rows.Skip(1))
                table.AddRow(row.Cells.Select(cell => cell.Value).ToArray());

            var data = new ScenarioContextData();
            TableMappingHelpers.ResidenceFields(table, data);
            Assert.Multiple(() =>
            {
                Assert.That(data.ResidenceYearBuilt, Is.EqualTo("1995"));
                Assert.That(data.ResidenceRoofYear, Is.EqualTo("2016"));
                Assert.That(data.Farm.ResidenceHeatingYear, Is.EqualTo("2022"));
                Assert.That(data.Farm.ResidencePlumbingYear, Is.EqualTo("2020"));
                Assert.That(data.Farm.ResidenceElectricalYear, Is.EqualTo("2017"));
            });
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
                Assert.That(rows, Has.Length.EqualTo(44));
                Assert.That(rows.All(row => row.Length == 12), Is.True);
                Assert.That(rows.Select(row => row[1]), Is.Unique);
                Assert.That(rows.Select(row => row[5]), Is.Unique);
                Assert.That(rows.All(row => System.Text.RegularExpressions.Regex.IsMatch(row[5], @"^\d{5}$")), Is.True);
                Assert.That(rows.All(row => EmptyAddressLine2States.Contains(row[1])
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
                        "@Shard4 @Debug", "@Shard4", "@Shard4 @DevOnly", "@Shard5 @Debug",
                        "@Shard5", "@Shard5", "@Shard5 @DevOnly", "@Shard6 @Debug",
                        "@Shard6", "@Shard6", "@Shard6 @DevOnly"
                    }));
                Assert.That(examples.Select(example => example.TableBody.Count()),
                    Is.EqualTo(new[] { 1, 13, 1, 1, 12, 1, 1, 1, 10, 2, 1 }));
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
                Assert.That(rows, Has.Length.EqualTo(44));
                Assert.That(rows.All(row => row.Length == 12), Is.True);
                Assert.That(rows.Select(row => row[1]), Is.Unique);
                Assert.That(rows.Select(row => row[5]), Is.Unique);
                Assert.That(rows.All(row => System.Text.RegularExpressions.Regex.IsMatch(row[5], @"^\d{5}$")), Is.True);
                Assert.That(rows.All(row => EmptyAddressLine2States.Contains(row[1])
                    ? row[3] == ""
                    : !string.IsNullOrEmpty(row[3])), Is.True);
                AssertApprovedDevStateRows(rows);
                Assert.That(examples.Select(example => string.Join(" ", example.Tags.Select(tag => tag.Name))),
                    Is.EqualTo(new[]
                    {
                        "@Shard1 @Debug @PipelineSmoke", "@Shard1", "@Shard1 @Pollution146",
                        "@Shard1 @Connecticut @Pollution146", "@Shard1 @DevOnly",
                        "@Shard2 @Debug", "@Shard2", "@Shard2 @Pollution146", "@Shard2",
                        "@Shard2 @NewJersey", "@Shard2 @DevOnly", "@Shard3 @Debug",
                        "@Shard3", "@Shard3", "@Shard3 @RhodeIsland @Pollution146",
                        "@Shard3 @DevOnly"
                    }));
                Assert.That(examples.Select(example => example.TableBody.Count()),
                    Is.EqualTo(new[] { 1, 10, 2, 1, 1, 1, 8, 3, 1, 1, 1, 1, 9, 2, 1, 1 }));
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
        public void PnCRegressionPipeline_UsesSafeDynamicDistributionFilters()
        {
            var path = Path.Combine(
                ProjectRoot(),
                "Pipelines",
                "pnc-automated-regression.yml");
            var pipeline = File.ReadAllText(path);
            var filterDefinitions = System.Text.RegularExpressions.Regex.Matches(
                pipeline,
                @"name:\s*TEST_FILTER\s*\r?\n\s*value:\s*""([^""]+)""");

            Assert.Multiple(() =>
            {
                Assert.That(filterDefinitions, Has.Count.EqualTo(6));
                Assert.That(
                    filterDefinitions
                        .Cast<System.Text.RegularExpressions.Match>()
                        .All(match => match.Groups[1].Value.Contains("TestCategory!=DevOnly")),
                    Is.True);
                Assert.That(
                    pipeline,
                    Does.Contain("TestCategory=PipelineSmoke&TestCategory!=DevOnly"));
                Assert.That(
                    pipeline,
                    Does.Contain("TestCategory=RatePolicy&TestCategory!=DevOnly"));
                Assert.That(
                    pipeline,
                    Does.Contain("parallel: ${{ parameters.agentCount }}"));
                Assert.That(pipeline, Does.Contain("distributionBatchType: basedOnExecutionTime"));
                Assert.That(pipeline, Does.Contain("rerunFailedTests: false"));
                Assert.That(pipeline, Does.Not.Contain("SHARD_FILTER_"));
            });

            var basicPolicyFeature = File.ReadAllText(
                Path.Combine(ProjectRoot(), "Features", "SFP", "SFP_BasicPolicy.feature"));
            Assert.That(
                System.Text.RegularExpressions.Regex.Matches(
                    basicPolicyFeature,
                    @"@PipelineSmoke\b"),
                Has.Count.EqualTo(1));
        }

        [Test]
        public void DevConfiguration_AllowsCurrentSevenStateRollout()
        {
            var json = File.ReadAllText(Path.Combine(ProjectRoot(), "appsettings.Dev.json"));
            using var document = System.Text.Json.JsonDocument.Parse(json);
            var allowed = document.RootElement.GetProperty("StateFilters")
                .GetProperty("DevAllowedStates").EnumerateArray()
                .Select(value => value.GetString()).ToArray();

            Assert.That(allowed, Is.EqualTo(new[] { "WY", "IL", "MT", "IN", "ND", "TN", "KY" }));
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
                Assert.That(states.Intersect(DevOnlyStateAbbreviations).Any(), Is.EqualTo(isDevOnly),
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
            Assert.That(rows.Single(row => row[1] == "CA"),
                Is.EqualTo(new[]
                {
                    "California", "CA", "3300 Glenwood St", "111", "Eureka", "95501", "Humboldt",
                    "", "", "None", "", ""
                }));
            Assert.That(rows.Single(row => row[1] == "VA"),
                Is.EqualTo(new[]
                {
                    "Virginia", "VA", "15235 Whitehead Rd", "111", "Branchville", "23828", "Southampton",
                    "", "", "1%", "", ""
                }));
            Assert.That(rows.Single(row => row[1] == "WV"),
                Is.EqualTo(new[]
                {
                    "West Virginia", "WV", "108 Victorian Commons Rd", "", "Winfield", "25213", "Putnam",
                    "", "", "1%", "", ""
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
