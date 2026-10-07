using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using Gherkin;
using Gherkin.Ast;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using PnCTestAutomation.Context;
using PnCTestAutomation.Helpers;
using PnCTestAutomation.Models;
using PnCTestAutomation.Services;
using PnCTestAutomation.StepDefinitions.SFPSteps;
using Reqnroll;
using Scenario = Gherkin.Ast.Scenario;
using DataTable = Gherkin.Ast.DataTable;

namespace PnCTestAutomation.Tests
{
    [TestFixture]
    public class SfpRatePolicyFeatureTests
    {
        internal static string FeaturePath()
        {
            var directory = new DirectoryInfo(TestContext.CurrentContext.TestDirectory);
            while (directory != null && !File.Exists(Path.Combine(directory.FullName, "TestAutomation.csproj")))
                directory = directory.Parent;
            return Path.Combine(directory?.FullName
                ?? throw new InvalidOperationException("Cannot locate the active automation checkout."),
                "Features", "SFP", "SFP_RatePolicy.feature");
        }

        private static Scenario ReadScenario() =>
            new Parser().Parse(FeaturePath()).Feature.Children.OfType<Scenario>().Single();

        [Test]
        public void CanonicalFeature_PreservesInputsExceptApprovedRatePolicyUpdates()
        {
            var lines = File.ReadAllLines(FeaturePath());
            var tables = ReadScenario().Steps.Select(step => step.Argument).OfType<DataTable>().ToArray();
            var effectiveDate = tables
                .SelectMany(table => table.Rows)
                .Single(row => row.Cells.First().Value == "EffectiveDate");
            Assert.That(
                effectiveDate.Cells.ElementAt(1).Value,
                Is.EqualTo("{{laterOfTomorrow:03/21/2027}}"));
            lines[effectiveDate.Location.Line - 1] = "| EffectiveDate | {{tomorrow}} |";
            foreach (var (coverage, originalAcres) in new[]
            {
                ("Special Farm Pollution", "100"),
                ("Chemical Drift and Transportation Increased Limits", "75")
            })
            {
                var table = tables.Single(candidate => candidate.Rows.Any(row =>
                    row.Cells.First().Value == "CoverageName" && row.Cells.ElementAt(1).Value == coverage));
                var acreage = table.Rows.Single(row => row.Cells.First().Value == "Acres");
                Assert.That(acreage.Cells.ElementAt(1).Value, Is.EqualTo("200"), coverage);
                lines[acreage.Location.Line - 1] = $"| Acres | {originalAcres} |";
            }
            var semanticLines = lines.Select(line => line.Trim())
                .Where(line => line.Length != 0)
                .Select(line => line.StartsWith('|')
                    ? string.Join("|", line.Split('|').Select(cell => cell.Trim()))
                    : line);
            var hash = Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(
                string.Join("\n", semanticLines) + "\n")));
            Assert.That(hash, Is.EqualTo("253579EA9C1B718218307385F989A8FB40F9924649DED39BA4D46807A2A4DE38"),
                "Only table alignment, the Rate Policy effective-date token, and the two user-approved 200-acre expectations may differ from the supplied scenario.");
        }

        [Test]
        public void RateEffectiveDate_UsesMarch2027OrTomorrowWhicheverIsLater()
        {
            var releaseDate = new DateTime(2027, 3, 21);
            var tomorrow = DateTime.Today.AddDays(1);
            var expected = (releaseDate > tomorrow ? releaseDate : tomorrow)
                .ToString("M/d/yyyy", System.Globalization.CultureInfo.InvariantCulture);

            Assert.Multiple(() =>
            {
                Assert.That(
                    DateHelpers.ResolveDateToken("{{laterOfTomorrow:03/21/2027}}"),
                    Is.EqualTo(expected));
                Assert.That(
                    DateHelpers.ResolveDateToken("{{laterOfTomorrow:01/01/2000}}"),
                    Is.EqualTo(DateHelpers.GetTomorrowDate()));
                Assert.Throws<ArgumentException>(() =>
                    DateHelpers.ResolveDateToken("{{laterOfTomorrow:03/21/27}}"));
            });
        }

        [Test]
        public void GeneratedFeature_HasExactlyFourStateAndShardCases()
        {
            var feature = new Parser().Parse(FeaturePath()).Feature;
            var scenario = feature.Children.OfType<Scenario>().Single();
            var generated = typeof(Features.SFP.SFPRatePolicyFeature)
                .GetMethod("SFPRatePolicy_State")!.GetCustomAttributes<TestCaseAttribute>().ToArray();
            var expected = new[]
            {
                new[] { "Minnesota", "MN", "401 S 4th St", "111", "Minneapolis", "55415", "Hennepin", "Shard1" },
                new[] { "Nebraska", "NE", "555 S 10th St", "111", "Lincoln", "68508", "Lancaster", "Shard1" },
                new[] { "South Dakota", "SD", "300 6th St", "111", "Rapid City", "57701", "Pennington", "Shard2" },
                new[] { "Wisconsin", "WI", "100 N Jefferson St", "111", "Green Bay", "54301", "Brown", "Shard3" }
            };
            Assert.Multiple(() =>
            {
                Assert.That(feature.Tags.Select(tag => tag.Name),
                    Is.EquivalentTo(new[] { "@SFP", "@RatePolicy", "@ExpertQuote", "@Regression" }));
                Assert.That(scenario.Name, Is.EqualTo("SFP Rate Policy - <State>"));
                Assert.That(scenario.Examples.Select(example => example.TableBody.Count()), Is.EqualTo(new[] { 2, 1, 1 }));
                Assert.That(generated, Has.Length.EqualTo(4));
                foreach (var row in expected)
                {
                    var test = generated.Single(candidate => Equals(candidate.Arguments[1], row[1]));
                    Assert.That(test.Arguments.Take(7), Is.EqualTo(row.Take(7)), row[1]);
                    Assert.That(test.Arguments[8], Is.EqualTo(new[] { row[7] }), row[1]);
                }
            });
        }

        [Test]
        public void EveryScenarioStep_HasExactlyOneBindingWithTheCorrectTableArgument()
        {
            var bindings = typeof(SFP_RatePolicySteps).Assembly.GetTypes()
                .Where(type => type.IsDefined(typeof(BindingAttribute)))
                .SelectMany(type => type.GetMethods())
                .SelectMany(method => method.GetCustomAttributesData()
                    .Where(attribute => attribute.AttributeType.Namespace == "Reqnroll"
                        && attribute.AttributeType.Name is "GivenAttribute" or "WhenAttribute" or "ThenAttribute" or "StepDefinitionAttribute")
                    .Select(attribute => (Method: method, Kind: attribute.AttributeType.Name,
                        Expression: (string)attribute.ConstructorArguments[0].Value!)))
                .ToArray();
            var kind = "GivenAttribute";
            foreach (var step in ReadScenario().Steps)
            {
                kind = step.Keyword.Trim() switch
                {
                    "Given" => "GivenAttribute",
                    "When" => "WhenAttribute",
                    "Then" => "ThenAttribute",
                    _ => kind
                };
                var matches = bindings.Where(binding =>
                    (binding.Kind == kind || binding.Kind == "StepDefinitionAttribute")
                    && BindingPattern(binding.Expression).IsMatch(step.Text)).ToArray();
                Assert.That(matches, Has.Length.EqualTo(1),
                    $"{step.Keyword}{step.Text}: {string.Join(", ", matches.Select(match => match.Method.DeclaringType!.Name + "." + match.Method.Name))}");
                Assert.That(matches[0].Method.GetParameters().Count(parameter => parameter.ParameterType == typeof(Table)),
                    Is.EqualTo(step.Argument is DataTable ? 1 : 0), step.Text);
            }
            TestContext.WriteLine($"Resolved all {ReadScenario().Steps.Count()} step occurrences without missing or duplicate bindings.");
        }

        private static Regex BindingPattern(string expression)
        {
            var pattern = expression.Contains("(.*)", StringComparison.Ordinal) || expression.StartsWith('^')
                ? expression
                : Regex.Escape(expression).Replace(Regex.Escape("{string}"), "\"[^\"]*\"");
            return new Regex("^(?:" + pattern + ")$");
        }

        [Test]
        public void NewTables_RejectEveryUnknownDuplicateMissingOrEmptyField()
        {
            foreach (var step in ReadScenario().Steps.Where(step => step.Argument is DataTable))
            {
                var reader = Reader(step.Text);
                if (reader == null)
                    continue;
                var original = ToTable((DataTable)step.Argument);
                var values = reader(original);
                Assert.That(values, Has.Count.EqualTo(original.RowCount), step.Text);
                var unknown = ToTable((DataTable)step.Argument);
                unknown.AddRow("TypoThatMustNotBeIgnored", "Yes");
                Assert.Throws<ArgumentException>(() => reader(unknown), step.Text);
                var duplicate = ToTable((DataTable)step.Argument);
                duplicate.AddRow(original.Rows[0]["Question"], original.Rows[0]["Answer"]);
                Assert.Throws<ArgumentException>(() => reader(duplicate), step.Text);
                var missing = new Table("Question", "Answer");
                foreach (var row in original.Rows.Skip(1))
                    missing.AddRow(row["Question"], row["Answer"]);
                Assert.Throws<ArgumentException>(() => reader(missing), step.Text);
                var empty = ToTable((DataTable)step.Argument);
                empty.Rows[0]["Answer"] = "";
                Assert.Throws<ArgumentException>(() => reader(empty), step.Text);
            }
        }

        private static Func<Table, IReadOnlyDictionary<string, string>> Reader(string step) => step switch
        {
            "user adds Residence Coverage and stays on the property" =>
                table => SfpRequiredTable.Read(table, SfpRatePolicyInputs.ResidenceCoverageFields),
            "user adds Residence Contents and saves the property" =>
                table => SfpRequiredTable.Read(table, SfpRatePolicyInputs.ResidenceContentsFields),
            "user adds a building with coverage and contents" =>
                table => SfpRequiredTable.Read(table, SfpRatePolicyInputs.BuildingFields),
            "user adds detailed Farm Personal Property and continues" =>
                table => SfpRequiredTable.Read(table, SfpRatePolicyInputs.MachineryFields),
            "user adds Scheduled Personal Property item and stays" or "user adds Scheduled Personal Property item and continues" =>
                SfpRatePolicyInputs.ScheduledProperty,
            "user edits liability optional coverage and stays" or "user edits liability optional coverage and continues" =>
                SfpRatePolicyInputs.Liability,
            _ => null
        };

        internal static Table ToTable(DataTable table)
        {
            var rows = table.Rows.ToArray();
            var result = new Table(rows[0].Cells.Select(cell => cell.Value).ToArray());
            foreach (var row in rows.Skip(1))
                result.AddRow(row.Cells.Select(cell => cell.Value).ToArray());
            return result;
        }

        [TestCase("Unknown coverage")]
        [TestCase("Limited Farm Pollution")]
        public void RateLiability_RejectsUnknownOrBasicOnlyCoverage(string coverage) =>
            Assert.Throws<ArgumentException>(() => SfpRatePolicyInputs.Liability(
                SfpBasicInputTests.TableOf(("CoverageName", coverage))));

        [TestCase("999", "Jewelry")]
        [TestCase("407", "Stamp Collection")]
        public void RateScheduledProperty_RejectsUnknownOrMismatchedCategory(string category, string itemType) =>
            Assert.Throws<ArgumentException>(() => SfpRatePolicyInputs.ScheduledProperty(
                SfpBasicInputTests.TableOf(("Category", category), ("ItemType", itemType))));

        [TestCase("0")]
        [TestCase("-1")]
        [TestCase("")]
        [TestCase("NaN")]
        public void Valuation_RejectsZeroNegativeOrMissingAmounts(string value) =>
            Assert.Throws<Microsoft.Playwright.PlaywrightException>(
                () => SfpFieldAssertions.ParsePositiveAmount(value, "ACV"));

        [TestCase("$0.01", 0.01)]
        [TestCase("$225,000.00", 225000)]
        public void Valuation_RequiresAnActuallyPositiveNumericAmount(string value, decimal expected) =>
            Assert.That(SfpFieldAssertions.ParsePositiveAmount(value, "ACV"), Is.EqualTo(expected));

        [TestCase("No", false)]
        [TestCase("Yes", true)]
        public void ExplicitBoolean_IsPreserved(string value, bool expected) =>
            Assert.That(SfpRequiredTable.YesNo(value), Is.EqualTo(expected));

        [TestCase("")]
        [TestCase("maybe")]
        public void InvalidBoolean_IsNotSilentlyMappedToNo(string value) =>
            Assert.Throws<ArgumentException>(() => SfpRequiredTable.YesNo(value));

        [TestCase("Dev", "https://expertquote-dev.example", true)]
        [TestCase("QA", "https://expertquote-qa.example", true)]
        [TestCase("Production", "https://expertquote.example", false)]
        [TestCase("Dev", "https://expertquote.example", false)]
        public void QuoteCreation_RequiresAnExplicitNonProductionTarget(string environment, string endpoint, bool allowed)
        {
            var config = new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string, string>
            {
                ["Environment"] = environment,
                ["Playwright:ExpertQuoteDev"] = endpoint,
                ["Playwright:ExpertQuote"] = endpoint
            }).Build();
            var steps = new SFP_RatePolicySteps(new PlaywrightContext(), new ScenarioContextData(), config);
            if (allowed)
                Assert.DoesNotThrow(steps.RequireNonProductionEnvironment);
            else
                Assert.Throws<InvalidOperationException>(steps.RequireNonProductionEnvironment);
        }

        [TestCase("MN")]
        [TestCase("NE")]
        [TestCase("SD")]
        [TestCase("WI")]
        public void MissingApprovedRateBaseline_CannotFallBackToBasicOrCe(string state)
        {
            const string json = """
                {"STATES":{"BASIC":["MN","NE","SD","WI"],"CE":["MN","NE","SD","WI"]},
                 "BASE":{"COMMON":"all"},"BASIC":{"BASICONLY":"all"},"CE":{"CEONLY":"all"}}
                """;
            var validator = new FormsValidationService(new DuckCreekFormsConfig());
            var error = Assert.Throws<InvalidOperationException>(() =>
                validator.ParseSfpJson(json, state, "RATEPOLICY"));
            Assert.That(error!.Message, Does.Contain("RATEPOLICY").And.Contain("no approved JSON baseline"));
        }

        [TestCase("MN")]
        [TestCase("NE")]
        [TestCase("SD")]
        [TestCase("WI")]
        public void NamedRatePolicyBaseline_UsesItsOwnJsonAndRejectsAnUnpopulatedDraft(string state)
        {
            var file = Path.Combine(TestContext.CurrentContext.TestDirectory,
                "Resources", "ExpectedForms", "SFP", "SFP_RATEPOLICY.json");
            var json = File.ReadAllText(file);
            using var document = JsonDocument.Parse(json,
                new JsonDocumentOptions { CommentHandling = JsonCommentHandling.Skip });
            Assert.Multiple(() =>
            {
                Assert.That(json, Does.Contain("Rate Policy Baseline"));
                Assert.That(document.RootElement.GetProperty("STATES").GetProperty("RATEPOLICY")
                    .EnumerateArray().Select(value => value.GetString()),
                    Is.EquivalentTo(new[] { "MN", "NE", "SD", "WI" }));
                Assert.That(document.RootElement.GetProperty("STATES").EnumerateObject().Select(value => value.Name),
                    Is.EqualTo(new[] { "RATEPOLICY" }));
            });
            var validator = new FormsValidationService(new DuckCreekFormsConfig());
            if (!document.RootElement.GetProperty("BASE").EnumerateObject().Any()
                && !document.RootElement.GetProperty("RATEPOLICY").EnumerateObject().Any())
            {
                var error = Assert.Throws<InvalidOperationException>(() =>
                    validator.LoadExpectedFormsForLob("SFP", state, "RATEPOLICY"));
                Assert.That(error!.Message, Does.Contain("Rate Policy Baseline is unpopulated")
                    .And.Contain("SFP_RATEPOLICY.json").And.Contain(state));
                Assert.Throws<InvalidOperationException>(() =>
                    validator.LoadExpectedFormsTemplateForRecording("SFP", "RATEPOLICY"));
            }
            else
            {
                var expected = validator.ParseSfpJson(json, state, "RATEPOLICY");
                Assert.That(validator.LoadExpectedFormsForLob("SFP", state, "RATEPOLICY")
                    .Select(form => (form.FormName, form.ExpectedStatus, form.Type)),
                    Is.EqualTo(expected.Select(form => (form.FormName, form.ExpectedStatus, form.Type))));
            }
        }

        [TestCase("{}")]
        [TestCase("{\"EXCLUDED\":[]}")]
        [TestCase("{\"MNONLY\":[\"MN\"]}")]
        public void UnpopulatedState_CannotPassWithEmptyOrExclusionOnlyExpectations(string forms)
        {
            var json = "{\"STATES\":{\"RATEPOLICY\":[\"MN\",\"NE\",\"SD\",\"WI\"]},\"BASE\":{},\"RATEPOLICY\":"
                + forms + "}";
            var error = Assert.Throws<InvalidOperationException>(() =>
                new FormsValidationService(new DuckCreekFormsConfig()).ParseSfpJson(json, "WI", "RATEPOLICY"));
            Assert.That(error!.Message, Does.Contain("unpopulated").And.Contain("WI"));
        }

        [Test]
        public void FormsRouting_KeepsRateIndependentAndPreservesBasicCe()
        {
            var data = new ScenarioContextData { ProductSelection = "SFP" };
            Assert.That(SFP_FinalizationSteps.DeriveFormsTestCase(data, new[] { "RatePolicy" }, "SFP Rate Policy - <State>"),
                Is.EqualTo("RATEPOLICY"));
            data.FormsTestCase = "BASIC";
            Assert.That(SFP_FinalizationSteps.DeriveFormsTestCase(data, new[] { "RatePolicy" }, "SFP Rate Policy - <State>"),
                Is.EqualTo("RATEPOLICY"));
            data.FormsTestCase = null;
            Assert.That(SFP_FinalizationSteps.DeriveFormsTestCase(data, Array.Empty<string>(), "SFP Basic Policy - <State>"),
                Is.EqualTo("BASIC"));
            data.ProductSelection = "CE";
            Assert.That(SFP_FinalizationSteps.DeriveFormsTestCase(data, new[] { "CE" }, "SFP Country Estate Policy - <State>"),
                Is.EqualTo("CE"));
        }

        [Test]
        public void ApprovedRateJson_UsesOnlySharedAndRateExpectations()
        {
            const string json = """
                {"STATES":{"BASIC":["MN"],"RATEPOLICY":["MN","NE","SD","WI"]},
                 "BASE":{"COMMON":"all"},"BASIC":{"BASICONLY":"all"},
                 "RATEPOLICY":{"RATEONLY":"all","EXCLUDED":[]}}
                """;
            var validator = new FormsValidationService(new DuckCreekFormsConfig());
            var expected = validator.ParseSfpJson(json, "MN", "RATEPOLICY");
            Assert.That(expected.Select(form => form.FormName), Is.EquivalentTo(new[] { "COMMON", "RATEONLY", "EXCLUDED" }));
            var result = validator.Validate(expected, new List<ActualFormEntry>
            {
                new() { Name = "COMMON", Selected = 2 }, new() { Name = "EXCLUDED", Selected = 2 }
            }, "SFP", "MN", "offline");
            Assert.That(result.Failed, Is.EqualTo(2), "Missing RATEONLY and forbidden EXCLUDED must both fail.");
        }
    }
}
