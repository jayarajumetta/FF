using System.Text.Json;
using NUnit.Framework;
using PnCTestAutomation.Artifacts;
using PnCTestAutomation.BusinessOutcomes;
using PnCTestAutomation.Models;

namespace PnCTestAutomation.UnitTests;

[TestFixture]
public class BusinessOutcomeTests
{
    private string _temporaryRoot = null!;

    [SetUp]
    public void SetUp()
    {
        _temporaryRoot = Path.Combine(
            Path.GetTempPath(),
            "PnCTestAutomation.Tests",
            Guid.NewGuid().ToString("N"));
    }

    [TearDown]
    public void TearDown()
    {
        if (Directory.Exists(_temporaryRoot))
            Directory.Delete(_temporaryRoot, recursive: true);
    }

    [Test]
    public void ApprovedProfileRequiresValidProvenanceAndChecksum()
    {
        var profile = ApprovedProfile();
        profile.Checksum =
            ExpectedOutcomeProfileValidator.ComputeChecksum(profile);
        var catalog = new ExpectedOutcomeCatalog
        {
            SchemaVersion = 1,
            Profiles = [profile]
        };

        Assert.That(
            () => ExpectedOutcomeProfileValidator.ValidateCatalog(
                catalog,
                new DateTimeOffset(2026, 9, 17, 12, 0, 0, TimeSpan.Zero)),
            Throws.Nothing);
    }

    [TestCase("checksum")]
    [TestCase("provenance")]
    [TestCase("stale")]
    [TestCase("synthetic")]
    public void InvalidApprovedProfilesFailConfigurationValidation(string defect)
    {
        var profile = ApprovedProfile();
        switch (defect)
        {
            case "provenance":
                profile.Provenance.ApprovedBy = string.Empty;
                break;
            case "stale":
                profile.Provenance.ValidUntilUtc =
                    new DateTimeOffset(2026, 9, 1, 0, 0, 0, TimeSpan.Zero);
                break;
            case "synthetic":
                profile.Forms!.BaselineVersion = "sample-version";
                break;
        }

        profile.Checksum =
            ExpectedOutcomeProfileValidator.ComputeChecksum(profile);
        if (defect == "checksum")
            profile.Checksum = new string('0', 64);

        Assert.That(
            () => ExpectedOutcomeProfileValidator.ValidateCatalog(
                new ExpectedOutcomeCatalog
                {
                    SchemaVersion = 1,
                    Profiles = [profile]
                },
                new DateTimeOffset(2026, 9, 17, 12, 0, 0, TimeSpan.Zero)),
            Throws.TypeOf<BusinessOutcomeConfigurationException>());
    }

    [Test]
    public void AmbiguousApprovedProfilesFailResolution()
    {
        var first = ApprovedProfile();
        first.Checksum =
            ExpectedOutcomeProfileValidator.ComputeChecksum(first);
        var second = ApprovedProfile();
        second.ProfileId = "sfp-basic-qa-mn-company-two";
        second.Company = "Company Two";
        second.Checksum =
            ExpectedOutcomeProfileValidator.ComputeChecksum(second);
        var provider = new ExpectedOutcomeProfileProvider(
            new ExpectedOutcomeCatalog
            {
                SchemaVersion = 1,
                Profiles = [first, second]
            },
            () => new DateTimeOffset(
                2026,
                9,
                17,
                12,
                0,
                0,
                TimeSpan.Zero));

        Assert.That(
            () => provider.ResolvePreflight("sfp-basic", "qa", "MN"),
            Throws.TypeOf<BusinessOutcomeConfigurationException>()
                .With.Message.Contains("ambiguous"));
    }

    [Test]
    public void PendingQaProfileIsExplicitlyNonRunnable()
    {
        var provider = new ExpectedOutcomeProfileProvider(
            new ExpectedOutcomeCatalog
            {
                SchemaVersion = 1,
                Profiles =
                [
                    new ExpectedOutcomeProfile
                    {
                        ProfileId = "sfp-basic-qa-pending",
                        Version = "1.0.0-pending-qa",
                        ScenarioProfile = "sfp-basic",
                        Environment = "qa",
                        State = "*",
                        Company = "*",
                        Mode = BusinessOutcomeProfileMode.NonRunnable,
                        BlockedReason = "QA values have not been approved.",
                        Provenance = new OutcomeProvenance
                        {
                            Source = "Pending QA approval"
                        },
                        Checksum = "PENDING-QA"
                    }
                ]
            });

        var result = provider.ResolvePreflight("sfp-basic", "qa", "MN");

        Assert.Multiple(() =>
        {
            Assert.That(result.IsRunnable, Is.False);
            Assert.That(result.Reason, Does.Contain("not been approved"));
        });
    }

    [Test]
    public void RepositoryProfileCatalogKeepsSfpPilotsNonRunnable()
    {
        var provider = new ExpectedOutcomeProfileProvider(
            new BusinessOutcomeOptions
            {
                ProfilePath = Path.Combine(
                    AppContext.BaseDirectory,
                    "Resources",
                    "ExpectedOutcomes",
                    "sfp-outcomes.json")
            });

        Assert.Multiple(() =>
        {
            Assert.That(
                provider.ResolvePreflight("sfp-basic", "qa", "AL").IsRunnable,
                Is.False);
            Assert.That(
                provider.ResolvePreflight(
                    "sfp-country-estate",
                    "qa",
                    "AL").IsRunnable,
                Is.False);
        });
    }

    [Test]
    public void MissingProfileAndRuntimeApplicabilityMismatchFail()
    {
        var profile = ApprovedProfile();
        profile.Checksum =
            ExpectedOutcomeProfileValidator.ComputeChecksum(profile);
        var provider = new ExpectedOutcomeProfileProvider(
            new ExpectedOutcomeCatalog
            {
                SchemaVersion = 1,
                Profiles = [profile]
            },
            () => new DateTimeOffset(
                2026,
                9,
                17,
                12,
                0,
                0,
                TimeSpan.Zero));
        var context = new BusinessOutcomeContext();
        context.Set(profile);

        Assert.Multiple(() =>
        {
            Assert.That(
                () => provider.ResolvePreflight("sfp-basic", "qa", "AL"),
                Throws.TypeOf<BusinessOutcomeConfigurationException>()
                    .With.Message.Contains("No business outcome profile"));
            Assert.That(
                () => context.ConfirmApplicability(
                    "qa",
                    "MN",
                    "Wrong Company"),
                Throws.TypeOf<BusinessOutcomeConfigurationException>()
                    .With.Message.Contains("not applicable"));
        });
    }

    [Test]
    public async Task QuoteIdentityMatchRecordsOnlyRedactedEvidence()
    {
        var (verifier, artifacts) = CreateVerifier();

        await verifier.VerifyQuoteIdentityAsync(
            "01999999",
            "01999999",
            "reopen");
        var manifest = artifacts.Complete(authoritativeScenarioFailed: false);
        var evidence = manifest.Artifacts.Single(
            item => item.Kind == ArtifactKind.BusinessOutcome);
        var content = File.ReadAllText(
            Path.Combine(artifacts.ScenarioRoot, evidence.RelativePath!));

        Assert.Multiple(() =>
        {
            Assert.That(content, Does.Not.Contain("01999999"));
            Assert.That(content, Does.Contain("expectedIdentityHash"));
            Assert.That(
                manifest.ComponentOutcomes["business-quote-identity"],
                Is.True);
        });
    }

    [Test]
    public void QuoteIdentityMismatchFailsAndMarksAuthoritativeOutcome()
    {
        var (verifier, artifacts) = CreateVerifier();

        Assert.ThrowsAsync<BusinessOutcomeException>(
            async () => await verifier.VerifyQuoteIdentityAsync(
                "01999999",
                "01888888",
                "reopen"));
        var manifest = artifacts.Complete(authoritativeScenarioFailed: true);

        Assert.Multiple(() =>
        {
            Assert.That(manifest.Outcome, Is.EqualTo(ArtifactOutcome.Failed));
            Assert.That(
                manifest.ComponentOutcomes["business-quote-identity"],
                Is.False);
        });
    }

    [TestCase("$1,234.56", 1234.56)]
    [TestCase("USD 1,234.56", 1234.56)]
    [TestCase("1,234.56 USD", 1234.56)]
    [TestCase("($1,234.56)", -1234.56)]
    public void CurrencyParserNormalizesUsdFormats(
        string raw,
        decimal expected)
    {
        var parsed = CurrencyAmountParser.TryParse(raw, "USD", out var actual);

        Assert.Multiple(() =>
        {
            Assert.That(parsed, Is.True);
            Assert.That(actual, Is.EqualTo(expected));
        });
    }

    [TestCase("")]
    [TestCase("1,234.56")]
    [TestCase("$not-a-number")]
    [TestCase("(USD 1.00")]
    public void CurrencyParserRejectsMissingOrInvalidValues(string raw)
    {
        Assert.That(
            CurrencyAmountParser.TryParse(raw, "USD", out _),
            Is.False);
    }

    [Test]
    public async Task PremiumToleranceBoundaryPassesAndOutsideFails()
    {
        var (passingVerifier, _) = CreateVerifier();
        var boundary =
            await passingVerifier.VerifyPremiumAsync("$1,000.50");
        var (failingVerifier, _) = CreateVerifier("premium-fail");

        Assert.Multiple(() =>
        {
            Assert.That(boundary, Is.EqualTo(1000.50m));
            Assert.That(
                async () =>
                    await failingVerifier.VerifyPremiumAsync("$1,000.51"),
                Throws.TypeOf<BusinessOutcomeException>());
        });
    }

    [Test]
    public void MissingPremiumExpectationAndNonNumericPremiumFail()
    {
        var missingProfile = ApprovedProfile();
        missingProfile.Premium = null;
        var (missingVerifier, _) = CreateVerifier(
            "missing-premium",
            missingProfile);
        var (invalidVerifier, _) = CreateVerifier("invalid-premium");

        Assert.Multiple(() =>
        {
            Assert.That(
                async () => await missingVerifier.VerifyPremiumAsync("$1.00"),
                Throws.TypeOf<BusinessOutcomeConfigurationException>());
            Assert.That(
                async () => await invalidVerifier.VerifyPremiumAsync("not available"),
                Throws.TypeOf<BusinessOutcomeException>());
        });
    }

    [Test]
    public void FormsVersionOrMetadataMismatchFails()
    {
        var (verifier, _) = CreateVerifier();
        var metadata = new FormsResponseMetadata
        {
            Manuscript = "Wrong",
            PrintJobName = "PrintJob",
            ReturnSuccessStatus = "1"
        };

        Assert.That(
            async () => await verifier.VerifyFormsContractAsync(
                new FormsBaselineSnapshot(
                    [],
                    "SFP:BASIC",
                    "v1",
                    new string('A', 64)),
                metadata,
                "Manuscript",
                "PrintJob"),
            Throws.TypeOf<BusinessOutcomeException>());
    }

    [Test]
    public void FormsBaselineVersionMismatchFails()
    {
        var (verifier, _) = CreateVerifier("forms-version");
        var metadata = new FormsResponseMetadata
        {
            Manuscript = "Manuscript",
            PrintJobName = "PrintJob",
            ReturnSuccessStatus = "1",
            HasRoleBasedSecurity = true
        };

        Assert.That(
            async () => await verifier.VerifyFormsContractAsync(
                new FormsBaselineSnapshot(
                    [],
                    "SFP:BASIC",
                    "v2",
                    new string('A', 64)),
                metadata,
                "Manuscript",
                "PrintJob"),
            Throws.TypeOf<BusinessOutcomeException>());
    }

    [Test]
    public void TransmitUnavailableFailsAvailabilityContract()
    {
        var (verifier, _) = CreateVerifier();

        Assert.That(
            async () => await verifier.VerifyTransmissionAvailabilityAsync(
                new TransmissionAvailability(true, false)),
            Throws.TypeOf<BusinessOutcomeException>());
    }

    [TestCase("Rejected", "Quote", "Q-200")]
    [TestCase("Completed", "Policy", "Q-200")]
    [TestCase("Completed", "Quote", "Q-201")]
    public void TransmissionStatusOrIdentityMismatchFails(
        string status,
        string identityKind,
        string identity)
    {
        var profile = ApprovedProfile();
        profile.Transmission = new TransmissionOutcomeExpectation
        {
            Mode = TransmissionExpectationMode.TransmitAndVerify,
            ExpectedStatuses = ["Completed"],
            IdentityKind = "Quote"
        };
        var (verifier, _) = CreateVerifier(
            $"transmit-{status}-{identityKind}-{identity}",
            profile);

        Assert.That(
            async () => await verifier.VerifyTransmissionResultAsync(
                new TransmissionResult(status, identityKind, identity),
                "Q-200"),
            Throws.TypeOf<BusinessOutcomeException>());
    }

    [Test]
    public async Task TransmissionResultPassesOnlyWithApprovedStatusAndIdentity()
    {
        var profile = ApprovedProfile();
        profile.Transmission = new TransmissionOutcomeExpectation
        {
            Mode = TransmissionExpectationMode.TransmitAndVerify,
            ExpectedStatuses = ["Completed"],
            IdentityKind = "Quote"
        };
        var (verifier, artifacts) = CreateVerifier(
            "transmit-pass",
            profile);

        await verifier.VerifyTransmissionResultAsync(
            new TransmissionResult("Completed", "Quote", "Q-200"),
            "Q-200");
        var manifest = artifacts.Complete(authoritativeScenarioFailed: false);

        Assert.That(
            manifest.ComponentOutcomes["business-transmission"],
            Is.True);
    }

    private (BusinessOutcomeVerifier Verifier, ArtifactContext Artifacts)
        CreateVerifier(
            string scenarioId = "business-outcome",
            ExpectedOutcomeProfile? profile = null)
    {
        profile ??= ApprovedProfile();
        var context = new BusinessOutcomeContext();
        context.Set(profile);
        context.ConfirmApplicability(
            profile.Environment,
            profile.State,
            profile.Company);
        var artifacts = new ArtifactContext(
            new ArtifactOptions
            {
                RootPath = _temporaryRoot,
                ProfileName = "unit",
                RequiredOnFailure = []
            },
            "run-1",
            scenarioId);
        return (
            new BusinessOutcomeVerifier(
                context,
                new ArtifactCaptureService(artifacts),
                artifacts),
            artifacts);
    }

    private static ExpectedOutcomeProfile ApprovedProfile() =>
        new()
        {
            ProfileId = "sfp-basic-qa-mn-company-one",
            Version = "1.0.0",
            ScenarioProfile = "sfp-basic",
            Environment = "qa",
            State = "MN",
            Company = "Company One",
            Mode = BusinessOutcomeProfileMode.Approved,
            Provenance = new OutcomeProvenance
            {
                Source = "QA approval record 42",
                ApprovedBy = "qa-owner",
                ApprovedAtUtc = new DateTimeOffset(
                    2026,
                    9,
                    1,
                    0,
                    0,
                    0,
                    TimeSpan.Zero),
                ValidUntilUtc = new DateTimeOffset(
                    2027,
                    9,
                    1,
                    0,
                    0,
                    0,
                    TimeSpan.Zero)
            },
            Premium = new PremiumOutcomeExpectation
            {
                ExpectedAmount = 1000.00m,
                Currency = "USD",
                ToleranceRule = PremiumToleranceRule.Absolute,
                Tolerance = 0.50m
            },
            Forms = new FormsOutcomeExpectation
            {
                BaselineId = "SFP:BASIC",
                BaselineVersion = "v1",
                BaselineChecksum = new string('A', 64),
                Manuscript = "Manuscript",
                PrintJob = "PrintJob",
                ExpectedReturnSuccessStatuses = ["1"],
                RequireRoleBasedSecurity = true
            },
            Transmission = new TransmissionOutcomeExpectation
            {
                Mode = TransmissionExpectationMode.AvailabilityOnly
            }
        };
}
