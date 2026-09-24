using System;
using System.IO;
using System.Linq;
using Gherkin;
using Gherkin.Ast;
using NUnit.Framework;
using PnCTestAutomation.Helpers;

namespace PnCTestAutomation.Tests
{
    [TestFixture]
    public class SfpCountryEstateFeatureTests
    {
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
                Assert.That(rows, Has.Length.EqualTo(38));
                Assert.That(rows.All(row => row.Length == 7), Is.True);
                Assert.That(rows.Select(row => row[1]), Is.Unique);
                Assert.That(rows.Select(row => row[5]), Is.Unique);
                Assert.That(rows.All(row => System.Text.RegularExpressions.Regex.IsMatch(row[5], @"^\d{5}$")), Is.True);
                Assert.That(rows.All(row => row[3] == "111"), Is.True);
                Assert.That(rows.Single(row => row[1] == "AL"),
                    Is.EqualTo(new[] { "Alabama", "AL", "2210 Wood Ave", "111", "Florence", "35630", "Lauderdale" }));
                Assert.That(rows.Single(row => row[1] == "MA")[5], Is.EqualTo("01202"));
                Assert.That(rows.Single(row => row[1] == "CT")[5], Is.EqualTo("06106"));
                Assert.That(rows.Single(row => row[1] == "ME")[5], Is.EqualTo("04736"));
                Assert.That(rows.Single(row => row[1] == "NH")[5], Is.EqualTo("03431"));
                Assert.That(rows.Single(row => row[1] == "NJ")[5], Is.EqualTo("08901"));
                Assert.That(rows.Single(row => row[1] == "RI")[5], Is.EqualTo("02904"));
                Assert.That(examples.Select(example => string.Join(" ", example.Tags.Select(tag => tag.Name))),
                    Is.EqualTo(new[] { "@Shard4 @Debug", "@Shard4", "@Shard5 @Debug", "@Shard5", "@Shard6 @Debug", "@Shard6" }));
                Assert.That(examples.Select(example => example.TableBody.Count()), Is.EqualTo(new[] { 1, 13, 1, 12, 1, 10 }));
            });
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
