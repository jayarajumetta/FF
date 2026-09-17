#nullable enable
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PnCTestAutomation.Artifacts;
using PnCTestAutomation.Models;

namespace PnCTestAutomation.BusinessOutcomes
{
    public sealed class BusinessOutcomeException : Exception
    {
        public BusinessOutcomeException(string outcome, string message)
            : base($"{outcome}: {message}")
        {
            Outcome = outcome;
        }

        public string Outcome { get; }
    }

    public sealed record FormsBaselineSnapshot(
        IReadOnlyList<ExpectedFormEntry> Entries,
        string BaselineId,
        string Version,
        string Checksum);

    public sealed record TransmissionAvailability(
        bool IsAvailable,
        bool IsEnabled);

    public sealed record TransmissionResult(
        string Status,
        string IdentityKind,
        string Identity);

    public interface IBusinessOutcomeVerifier
    {
        Task VerifyQuoteIdentityAsync(
            string authoritativeIdentity,
            string actualIdentity,
            string checkpoint);

        Task<decimal> VerifyPremiumAsync(string rawPremium);

        Task VerifyFormsContractAsync(
            FormsBaselineSnapshot baseline,
            FormsResponseMetadata metadata,
            string requestedManuscript,
            string requestedPrintJob);

        Task VerifyTransmissionAvailabilityAsync(
            TransmissionAvailability availability);

        Task VerifyTransmissionResultAsync(
            TransmissionResult result,
            string authoritativeIdentity);
    }

    public sealed partial class BusinessOutcomeVerifier :
        IBusinessOutcomeVerifier
    {
        private readonly IBusinessOutcomeContext _context;
        private readonly IArtifactCaptureService _capture;
        private readonly IArtifactContext _artifacts;

        public BusinessOutcomeVerifier(
            IBusinessOutcomeContext context,
            IArtifactCaptureService capture,
            IArtifactContext artifacts)
        {
            _context = context;
            _capture = capture;
            _artifacts = artifacts;
        }

        public async Task VerifyQuoteIdentityAsync(
            string authoritativeIdentity,
            string actualIdentity,
            string checkpoint)
        {
            var profile = _context.Require();
            var passed =
                !string.IsNullOrWhiteSpace(authoritativeIdentity) &&
                !string.IsNullOrWhiteSpace(actualIdentity) &&
                authoritativeIdentity.Equals(
                    actualIdentity,
                    StringComparison.Ordinal);
            await RecordAsync(
                "quote-identity",
                checkpoint,
                passed,
                new Dictionary<string, object?>
                {
                    ["expectedIdentityHash"] = HashIdentity(authoritativeIdentity),
                    ["actualIdentityHash"] = HashIdentity(actualIdentity)
                },
                profile);
            if (!passed)
            {
                throw new BusinessOutcomeException(
                    "quote identity",
                    "The displayed quote identity was missing or did not match the scenario-owned identity.");
            }
        }

        public async Task<decimal> VerifyPremiumAsync(string rawPremium)
        {
            var profile = _context.Require();
            var expectation = profile.Premium
                              ?? throw new BusinessOutcomeConfigurationException(
                                  "The active profile has no premium expectation.");
            if (!CurrencyAmountParser.TryParse(
                    rawPremium,
                    expectation.Currency,
                    out var actual))
            {
                await RecordAsync(
                    "premium",
                    "premium-invalid",
                    false,
                    new Dictionary<string, object?>
                    {
                        ["currency"] = expectation.Currency,
                        ["parseSucceeded"] = false
                    },
                    profile);
                throw new BusinessOutcomeException(
                    "premium",
                    "The displayed premium was missing or non-numeric.");
            }

            var difference = Math.Abs(actual - expectation.ExpectedAmount);
            var passed = expectation.ToleranceRule switch
            {
                PremiumToleranceRule.Absolute =>
                    difference <= expectation.Tolerance,
                _ => false
            };
            await RecordAsync(
                "premium",
                "premium-comparison",
                passed,
                new Dictionary<string, object?>
                {
                    ["currency"] = expectation.Currency,
                    ["expectedAmount"] = expectation.ExpectedAmount,
                    ["actualAmount"] = actual,
                    ["toleranceRule"] = expectation.ToleranceRule.ToString(),
                    ["tolerance"] = expectation.Tolerance,
                    ["difference"] = difference
                },
                profile);
            if (!passed)
            {
                throw new BusinessOutcomeException(
                    "premium",
                    "The displayed premium is outside the approved tolerance.");
            }

            return actual;
        }

        public async Task VerifyFormsContractAsync(
            FormsBaselineSnapshot baseline,
            FormsResponseMetadata metadata,
            string requestedManuscript,
            string requestedPrintJob)
        {
            var profile = _context.Require();
            var expectation = profile.Forms
                              ?? throw new BusinessOutcomeConfigurationException(
                                  "The active profile has no forms expectation.");
            var passed =
                expectation.BaselineId.Equals(
                    baseline.BaselineId,
                    StringComparison.Ordinal) &&
                expectation.BaselineVersion.Equals(
                    baseline.Version,
                    StringComparison.Ordinal) &&
                expectation.BaselineChecksum.Equals(
                    baseline.Checksum,
                    StringComparison.OrdinalIgnoreCase) &&
                expectation.Manuscript.Equals(
                    requestedManuscript,
                    StringComparison.Ordinal) &&
                expectation.PrintJob.Equals(
                    requestedPrintJob,
                    StringComparison.Ordinal) &&
                expectation.Manuscript.Equals(
                    metadata.Manuscript,
                    StringComparison.Ordinal) &&
                expectation.PrintJob.Equals(
                    metadata.PrintJobName,
                    StringComparison.Ordinal) &&
                expectation.ExpectedReturnSuccessStatuses.Any(status =>
                    status.Equals(
                        metadata.ReturnSuccessStatus,
                        StringComparison.OrdinalIgnoreCase)) &&
                (!expectation.RequireRoleBasedSecurity ||
                 metadata.HasRoleBasedSecurity);
            await RecordAsync(
                "forms-contract",
                "forms-profile",
                passed,
                new Dictionary<string, object?>
                {
                    ["baselineId"] = baseline.BaselineId,
                    ["baselineVersion"] = baseline.Version,
                    ["baselineChecksum"] = baseline.Checksum,
                    ["manuscriptMatched"] =
                        expectation.Manuscript.Equals(
                            metadata.Manuscript,
                            StringComparison.Ordinal),
                    ["printJobMatched"] =
                        expectation.PrintJob.Equals(
                            metadata.PrintJobName,
                            StringComparison.Ordinal),
                    ["returnStatusMatched"] =
                        expectation.ExpectedReturnSuccessStatuses.Any(status =>
                            status.Equals(
                                metadata.ReturnSuccessStatus,
                                StringComparison.OrdinalIgnoreCase)),
                    ["roleBasedSecurityMatched"] =
                        !expectation.RequireRoleBasedSecurity ||
                        metadata.HasRoleBasedSecurity
                },
                profile);
            if (!passed)
            {
                throw new BusinessOutcomeException(
                    "forms contract",
                    "Forms baseline version, checksum, or response metadata did not match the approved profile.");
            }
        }

        public async Task VerifyTransmissionAvailabilityAsync(
            TransmissionAvailability availability)
        {
            var profile = _context.Require();
            var expectation = profile.Transmission
                              ?? throw new BusinessOutcomeConfigurationException(
                                  "The active profile has no transmission expectation.");
            if (expectation.Mode != TransmissionExpectationMode.AvailabilityOnly)
            {
                await RecordAsync(
                    "transmission",
                    "transmit-availability-contract",
                    false,
                    new Dictionary<string, object?>
                    {
                        ["mode"] = expectation.Mode.ToString(),
                        ["available"] = availability.IsAvailable,
                        ["enabled"] = availability.IsEnabled
                    },
                    profile);
                throw new BusinessOutcomeException(
                    "transmission",
                    "An availability check cannot satisfy a transmit-and-verify profile.");
            }

            var passed = availability.IsAvailable && availability.IsEnabled;
            await RecordAsync(
                "transmission",
                "transmit-available",
                passed,
                new Dictionary<string, object?>
                {
                    ["mode"] = expectation.Mode.ToString(),
                    ["available"] = availability.IsAvailable,
                    ["enabled"] = availability.IsEnabled
                },
                profile);
            if (!passed)
            {
                throw new BusinessOutcomeException(
                    "transmission",
                    "The transmit action is unavailable or disabled.");
            }
        }

        public async Task VerifyTransmissionResultAsync(
            TransmissionResult result,
            string authoritativeIdentity)
        {
            var profile = _context.Require();
            var expectation = profile.Transmission
                              ?? throw new BusinessOutcomeConfigurationException(
                                  "The active profile has no transmission expectation.");
            if (expectation.Mode != TransmissionExpectationMode.TransmitAndVerify)
            {
                await RecordAsync(
                    "transmission",
                    "transmit-result-contract",
                    false,
                    new Dictionary<string, object?>
                    {
                        ["mode"] = expectation.Mode.ToString()
                    },
                    profile);
                throw new BusinessOutcomeException(
                    "transmission",
                    "The active profile does not authorize transmission.");
            }

            var statusMatched = expectation.ExpectedStatuses.Any(status =>
                status.Equals(result.Status, StringComparison.OrdinalIgnoreCase));
            var identityMatched =
                !string.IsNullOrWhiteSpace(result.Identity) &&
                expectation.IdentityKind.Equals(
                    result.IdentityKind,
                    StringComparison.OrdinalIgnoreCase) &&
                result.Identity.Equals(
                    authoritativeIdentity,
                    StringComparison.Ordinal);
            var passed = statusMatched && identityMatched;
            await RecordAsync(
                "transmission",
                "transmit-result",
                passed,
                new Dictionary<string, object?>
                {
                    ["statusMatched"] = statusMatched,
                    ["identityKind"] = result.IdentityKind,
                    ["identityHash"] = HashIdentity(authoritativeIdentity)
                },
                profile);
            if (!passed)
            {
                throw new BusinessOutcomeException(
                    "transmission",
                    "The transmission status or returned identity did not match the approved profile.");
            }
        }

        private async Task RecordAsync(
            string component,
            string checkpoint,
            bool passed,
            IReadOnlyDictionary<string, object?> details,
            ExpectedOutcomeProfile profile)
        {
            _artifacts.RecordComponentOutcome(
                $"business-{component}",
                passed);
            await _capture.CaptureAsync(
                ArtifactKind.BusinessOutcome,
                checkpoint,
                ".json",
                path => File.WriteAllTextAsync(
                    path,
                    JsonSerializer.Serialize(
                        new
                        {
                            version = 1,
                            profileId = profile.ProfileId,
                            profileVersion = profile.Version,
                            outcome = component,
                            passed,
                            details
                        },
                        new JsonSerializerOptions
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                            WriteIndented = true
                        })));
        }

        private static string HashIdentity(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;
            return Convert.ToHexString(
                SHA256.HashData(Encoding.UTF8.GetBytes(value)));
        }
    }

    public static class CurrencyAmountParser
    {
        public static bool TryParse(
            string value,
            string expectedCurrency,
            out decimal amount)
        {
            amount = default;
            if (string.IsNullOrWhiteSpace(value) ||
                !expectedCurrency.Equals("USD", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            var normalized = value.Trim();
            var hasCurrency =
                normalized.Contains('$') ||
                normalized.StartsWith("USD", StringComparison.OrdinalIgnoreCase) ||
                normalized.EndsWith("USD", StringComparison.OrdinalIgnoreCase);
            if (!hasCurrency)
                return false;

            normalized = normalized
                .Replace("USD", string.Empty, StringComparison.OrdinalIgnoreCase)
                .Replace("$", string.Empty, StringComparison.Ordinal)
                .Trim();
            var negative =
                normalized.StartsWith('(') &&
                normalized.EndsWith(')');
            if (negative)
                normalized = normalized[1..^1].Trim();
            else if (normalized.Contains('(') || normalized.Contains(')'))
                return false;

            normalized = normalized.Replace(",", string.Empty);
            if (!Regex.IsMatch(
                    normalized,
                    @"^\d+(?:\.\d{1,2})?$",
                    RegexOptions.CultureInvariant))
            {
                return false;
            }

            if (!decimal.TryParse(
                    normalized,
                    NumberStyles.AllowDecimalPoint,
                    CultureInfo.InvariantCulture,
                    out amount))
            {
                return false;
            }

            if (negative)
                amount = -amount;
            return true;
        }
    }
}
