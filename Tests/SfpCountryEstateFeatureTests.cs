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
        private static Scenario ReadScenario()
        {
            var directory = new DirectoryInfo(TestContext.CurrentContext.TestDirectory);
            while (directory != null && !File.Exists(Path.Combine(directory.FullName, "TestAutomation.csproj")))
                directory = directory.Parent;
            if (directory == null)
                throw new InvalidOperationException("Cannot locate TestAutomation.csproj for the canonical CE feature.");
            var path = Path.Combine(directory.FullName, "Features", "SFP", "SFP_CE.feature");
            return new Parser().Parse(path).Feature.Children.OfType<Scenario>().Single();
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
            var items = TableMappingHelpers.CountryEstateScheduledPropertyFields(table);
            Assert.Multiple(() =>
            {
                Assert.That(items.Select(item => item.Code), Is.EqualTo(new[] { "409", "411" }));
                Assert.That(items.Select(item => item.Amount), Is.EqualTo(new[] { 5000, 10000 }));
                Assert.That(items.Select(item => item.Description),
                    Is.EqualTo(new[] { "Stamp Collections", "Auto Trailer Home Personal Effects" }));
                Assert.That(items.All(item => item.UnattendedVehicle && item.YearOfAppraisal == null), Is.True);
                Assert.That(index, Is.LessThan(Array.FindIndex(steps, step => step.Text == "user runs Insurance Score")));
                Assert.That(index, Is.LessThan(Array.FindIndex(steps, step => step.Text == "user verifies Premium on Pricing screen")));
            });
        }
    }
}
