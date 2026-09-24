using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using Gherkin;
using Gherkin.Ast;
using NUnit.Framework;
using PnCTestAutomation.BusinessOutcomes;
using PnCTestAutomation.Models;
using PnCTestAutomation.Services;

namespace PnCTestAutomation.UnitTests;

[TestFixture]
public class SfpDevelopmentBaselineTests
{
    private static readonly DateTimeOffset ApprovalWindow =
        new(2026, 9, 25, 0, 0, 0, TimeSpan.Zero);

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        Converters = { new JsonStringEnumConverter() }
    };

    private static readonly Dictionary<string, string> DevelopmentPremiums = new()
    {
        ["BASIC"] =
            "AL=6489 AR=7103 AZ=7390 CO=5289 CT=6539 DE=5752 GA=6091 ID=4465 IL=3677 " +
            "IN=3757 IA=5014 KS=6968 KY=6117.78 LA=7336 MA=5836 ME=7010 MN=4500.96 " +
            "MS=10206 MO=5281 MT=4063 NE=4873 NH=5540 NJ=4860 NM=5848 NV=7012 ND=4198 " +
            "OH=3796 OK=8454 OR=3308 RI=6394 SC=8600 SD=5641 TN=6594 TX=11214 UT=4834 " +
            "WA=9926 WI=4758 WY=5789",
        ["CE"] =
            "AL=3089 AZ=3940 CT=3564 DE=2283 GA=3843 IA=2839 KS=5110 LA=5095 " +
            "MA=2599 ME=674 NM=6037 NV=3110 SC=3547 TN=3626 WI=2164 WY=4623"
    };

    private static string ScenarioProfile(string variant) =>
        variant == "BASIC" ? "sfp-basic" : "sfp-country-estate";

    private static ExpectedOutcomeCatalog ReadCatalog(string file = "sfp-outcomes.json") =>
        JsonSerializer.Deserialize<ExpectedOutcomeCatalog>(
            File.ReadAllText(Path.Combine(AppContext.BaseDirectory,
                "Resources", "ExpectedOutcomes", file)), JsonOptions)!;

    private static Dictionary<string, decimal> Premiums(string variant) =>
        DevelopmentPremiums[variant].Split(' ')
            .Select(pair => pair.Split('='))
            .ToDictionary(pair => pair[0],
                pair => decimal.Parse(pair[1], CultureInfo.InvariantCulture));

    public static IEnumerable<TestCaseData> ApprovedStates()
    {
        foreach (var variant in DevelopmentPremiums.Keys)
            foreach (var (state, amount) in Premiums(variant))
                yield return new TestCaseData(variant, state, amount);
    }

    [TestCaseSource(nameof(ApprovedStates))]
    public void ApprovedProfileUsesExactDevelopmentPremiumAndDeployedForms(
        string variant, string state, decimal expectedAmount)
    {
        var provider = new ExpectedOutcomeProfileProvider(ReadCatalog(), () => ApprovalWindow);
        var resolution = provider.ResolvePreflight(ScenarioProfile(variant), "qa", state);
        var profile = resolution.Profile;
        using var settings = JsonDocument.Parse(
            File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "appsettings.json")));
        var config = JsonSerializer.Deserialize<DuckCreekFormsConfig>(
            settings.RootElement.GetProperty("DuckCreekForms").GetRawText(), JsonOptions)!;
        var baseline = new FormsValidationService(config).LoadExpectedBaseline("SFP", state, variant);

        Assert.Multiple(() =>
        {
            Assert.That(resolution.IsRunnable, Is.True);
            Assert.That(profile.Premium!.ExpectedAmount, Is.EqualTo(expectedAmount));
            Assert.That(profile.Premium.Tolerance, Is.EqualTo(0.01m));
            Assert.That(profile.Premium.Currency, Is.EqualTo("USD"));
            Assert.That(profile.Premium.ToleranceRule, Is.EqualTo(PremiumToleranceRule.Absolute));
            Assert.That(profile.Forms!.BaselineId, Is.EqualTo(baseline.BaselineId));
            Assert.That(profile.Forms.BaselineVersion, Is.EqualTo(baseline.Version));
            Assert.That(baseline.Version, Is.EqualTo("development-d91ced6"));
            Assert.That(profile.Forms.BaselineChecksum, Is.EqualTo(baseline.Checksum));
            Assert.That(baseline.Entries, Has.Count.EqualTo(variant == "BASIC" ? 182 : 169));
            Assert.That(profile.Transmission!.Mode, Is.EqualTo(TransmissionExpectationMode.AvailabilityOnly));
            Assert.That(profile.Provenance.Source,
                Does.Contain("d91ced656df2652d65aa9b2de3d0f188d0233845"));
            Assert.That(profile.Provenance.ValidUntilUtc,
                Is.EqualTo(DateTimeOffset.Parse("2026-10-18T12:44:42.1790000Z", CultureInfo.InvariantCulture)));
            Assert.That(profile.Checksum, Is.EqualTo(ExpectedOutcomeProfileValidator.ComputeChecksum(profile)));
        });
    }

    [TestCase("BASIC", "SFP_BasicPolicy.feature", 38)]
    [TestCase("CE", "SFP_CE.feature", 16)]
    public void OnlyStatesWithDevelopmentPremiumsAreRunnable(
        string variant, string featureFile, int approvedCount)
    {
        var root = new DirectoryInfo(TestContext.CurrentContext.TestDirectory);
        while (root != null && !File.Exists(Path.Combine(root.FullName, "TestAutomation.csproj")))
            root = root.Parent;
        Assert.That(root, Is.Not.Null, "Cannot locate the canonical SFP features.");
        var feature = new Parser().Parse(Path.Combine(root!.FullName, "Features", "SFP", featureFile)).Feature;
        var scenario = feature.Children.OfType<Scenario>().Single();
        var states = scenario.Examples.SelectMany(example =>
        {
            var headers = example.TableHeader.Cells.Select(cell => cell.Value).ToArray();
            var column = Array.IndexOf(headers, "StateAbbv");
            Assert.That(column, Is.GreaterThanOrEqualTo(0));
            return example.TableBody.Select(row => row.Cells.ElementAt(column).Value);
        }).ToArray();
        var companyTable = (DataTable)scenario.Steps.Single(step =>
            step.Text == "user selects Special Farm Package and inputs Quote Details").Argument;
        var company = companyTable.Rows.Single(row => row.Cells.First().Value == "WritingCompany")
            .Cells.Last().Value;
        var premiums = Premiums(variant);
        var catalog = ReadCatalog();
        var provider = new ExpectedOutcomeProfileProvider(catalog, () => ApprovalWindow);

        Assert.Multiple(() =>
        {
            Assert.That(states, Has.Length.EqualTo(38));
            Assert.That(premiums.Keys.Except(states), Is.Empty);
            Assert.That(catalog.Profiles.Count(profile =>
                profile.ScenarioProfile == ScenarioProfile(variant) &&
                profile.Mode == BusinessOutcomeProfileMode.Approved), Is.EqualTo(approvedCount));
            foreach (var state in states)
            {
                var qa = provider.ResolvePreflight(ScenarioProfile(variant), "qa", state);
                Assert.That(qa.IsRunnable, Is.EqualTo(premiums.ContainsKey(state)), $"{variant}/{state}");
                if (qa.IsRunnable)
                    Assert.That(qa.Profile.Company, Is.EqualTo(company));
                else
                    Assert.That(qa.Reason, Is.Not.Empty);
                Assert.That(provider.ResolvePreflight(ScenarioProfile(variant), "dev", state).IsRunnable,
                    Is.False, $"QA approval must not enable Dev for {variant}/{state}");
            }
        });
    }

    [Test]
    public void LocalAlabamaRunnerUsesTheSameUpdatedProfileAsTheDefaultCatalog()
    {
        var local = ReadCatalog("sfp-basic-al-local.json").Profiles.Single();
        var standard = ReadCatalog().Profiles.Single(profile => profile.ProfileId == local.ProfileId);
        Assert.That(local.Checksum, Is.EqualTo(standard.Checksum));
        Assert.That(ExpectedOutcomeProfileValidator.ComputeChecksum(local),
            Is.EqualTo(ExpectedOutcomeProfileValidator.ComputeChecksum(standard)));
    }

    [TestCase("DE")]
    [TestCase("ME")]
    public void RetainedCePremiumsKeepTheirLegacyQualificationProvenance(string state)
    {
        var profile = new ExpectedOutcomeProfileProvider(ReadCatalog(), () => ApprovalWindow)
            .ResolvePreflight("sfp-country-estate", "qa", state).Profile;
        Assert.That(profile.Provenance.Source, Does.Contain("retained legacy data"));
    }

    [Test]
    public void ImportedProfilesFailClosedAfterTheExistingApprovalHorizon()
    {
        Assert.That(() => new ExpectedOutcomeProfileProvider(ReadCatalog(),
                () => new DateTimeOffset(2026, 10, 19, 0, 0, 0, TimeSpan.Zero)),
            Throws.TypeOf<BusinessOutcomeConfigurationException>());
    }
}
