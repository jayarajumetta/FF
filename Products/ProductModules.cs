#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using PnCTestAutomation.Artifacts;

namespace PnCTestAutomation.Products
{
    public enum ProductCapability
    {
        SemanticControls,
        FrameScope,
        DataProfile,
        ArtifactEvidence,
        QuoteHandoff,
        BusinessOutcomes,
        TestPlans
    }

    public sealed record ProductEvidenceContract(
        IReadOnlyList<ArtifactKind> RequiredArtifacts,
        bool RequiresCanonicalResult,
        bool RequiresFailureTrace,
        bool RequiresFailureVideo)
    {
        public IReadOnlyList<ArtifactKind> RequiredFailureArtifacts
        {
            get
            {
                var required = new List<ArtifactKind>();
                if (RequiresFailureTrace)
                    required.Add(ArtifactKind.Trace);
                if (RequiresFailureVideo)
                    required.Add(ArtifactKind.Video);
                return required;
            }
        }
    }

    public sealed record ProductModuleDescriptor(
        string ModuleId,
        string Product,
        string Workflow,
        IReadOnlyList<string> AutomationIdFamilies,
        IReadOnlyList<ProductCapability> RequiredCapabilities,
        string DataProfileId,
        bool UsesPilotDataProfile,
        ProductEvidenceContract Evidence,
        IReadOnlyList<string> SelectorExceptionReferences,
        IReadOnlyList<string> BlockedSelectors,
        bool RetrySafe);

    public interface IProductModule
    {
        ProductModuleDescriptor Descriptor { get; }
    }

    public interface IProductModuleRegistry
    {
        IReadOnlyList<ProductModuleDescriptor> Modules { get; }

        ProductModuleDescriptor Resolve(string automationId);
        ProductModuleDescriptor? TryResolve(string automationId);
    }

    public sealed class ProductModuleRegistry : IProductModuleRegistry
    {
        private readonly IReadOnlyList<ProductModuleDescriptor> _modules;

        public ProductModuleRegistry(IEnumerable<IProductModule> modules)
        {
            ArgumentNullException.ThrowIfNull(modules);
            _modules = modules.Select(module => module.Descriptor).ToArray();
            Validate(_modules);
        }

        public IReadOnlyList<ProductModuleDescriptor> Modules => _modules;

        public ProductModuleDescriptor Resolve(string automationId) =>
            TryResolve(automationId)
            ?? throw new ProductModuleConfigurationException(
                $"No product module owns automation ID '{automationId}'.");

        public ProductModuleDescriptor? TryResolve(string automationId)
        {
            if (string.IsNullOrWhiteSpace(automationId))
                return null;

            var matches = _modules
                .Where(module => module.AutomationIdFamilies.Any(family =>
                    automationId.Equals(family, StringComparison.Ordinal) ||
                    automationId.StartsWith(
                        family + ":",
                        StringComparison.Ordinal)))
                .ToArray();
            return matches.Length switch
            {
                0 => null,
                1 => matches[0],
                _ => throw new ProductModuleConfigurationException(
                    $"Automation ID '{automationId}' has ambiguous product ownership.")
            };
        }

        private static void Validate(
            IReadOnlyCollection<ProductModuleDescriptor> modules)
        {
            if (modules.Count == 0)
            {
                throw new ProductModuleConfigurationException(
                    "At least one product module is required.");
            }

            RequireUnique(
                modules.Select(module => module.ModuleId),
                "module ID");
            RequireUnique(
                modules.SelectMany(module => module.AutomationIdFamilies),
                "automation ID family");

            foreach (var module in modules)
            {
                Require(module.ModuleId, "module ID");
                Require(module.Product, "product");
                Require(module.Workflow, "workflow");
                Require(module.DataProfileId, "data profile ID");
                if (module.AutomationIdFamilies.Count == 0 ||
                    module.RequiredCapabilities.Count == 0 ||
                    module.Evidence.RequiredArtifacts.Count == 0)
                {
                    throw new ProductModuleConfigurationException(
                        $"Product module '{module.ModuleId}' has an incomplete contract.");
                }
                if (module.SelectorExceptionReferences.Any(reference =>
                        !reference.StartsWith(
                            "ANI-ID-",
                            StringComparison.Ordinal)))
                {
                    throw new ProductModuleConfigurationException(
                        $"Product module '{module.ModuleId}' has an undocumented selector exception.");
                }
            }
        }

        private static void RequireUnique(
            IEnumerable<string> values,
            string description)
        {
            var duplicate = values
                .GroupBy(value => value, StringComparer.OrdinalIgnoreCase)
                .FirstOrDefault(group => group.Count() > 1);
            if (duplicate != null)
            {
                throw new ProductModuleConfigurationException(
                    $"Duplicate product {description} '{duplicate.Key}'.");
            }
        }

        private static void Require(string value, string description)
        {
            if (string.IsNullOrWhiteSpace(value) ||
                value.Any(char.IsControl))
            {
                throw new ProductModuleConfigurationException(
                    $"Product {description} is missing or invalid.");
            }
        }
    }

    public sealed class SfpProductModule : IProductModule
    {
        public ProductModuleDescriptor Descriptor { get; } = new(
            "sfp-reference",
            "Special Farm Package",
            "Current SFP reference workflows",
            [
                "SFP-BASIC-POLICY",
                "SFP-COUNTRY-ESTATE",
                "SFP-FORMS-VALIDATION"
            ],
            [
                ProductCapability.SemanticControls,
                ProductCapability.FrameScope,
                ProductCapability.ArtifactEvidence,
                ProductCapability.QuoteHandoff,
                ProductCapability.BusinessOutcomes,
                ProductCapability.TestPlans
            ],
            "sfp-outcomes",
            false,
            new ProductEvidenceContract(
                [
                    ArtifactKind.Screenshot,
                    ArtifactKind.BusinessOutcome,
                    ArtifactKind.QuoteHandoff,
                    ArtifactKind.TrxMetadata,
                    ArtifactKind.TimingSummary
                ],
                true,
                true,
                true),
            ["ANI-ID-001", "ANI-ID-002", "ANI-ID-003", "ANI-ID-004"],
            [],
            false);
    }

    public sealed class ExpertQuoteBopPilotModule : IProductModule
    {
        public const string DataProfileId = "eq-bop-al-smoke";
        public const string AutomationIdFamily = "EQ-BOP-SMOKE";

        public ProductModuleDescriptor Descriptor { get; } = new(
            "expertquote-bop-al-pilot",
            "Commercial Lines ExpertQuote BOP",
            "SGS 03 EQ BOP smoke",
            [AutomationIdFamily],
            [
                ProductCapability.SemanticControls,
                ProductCapability.FrameScope,
                ProductCapability.DataProfile,
                ProductCapability.ArtifactEvidence,
                ProductCapability.QuoteHandoff,
                ProductCapability.BusinessOutcomes,
                ProductCapability.TestPlans
            ],
            DataProfileId,
            true,
            new ProductEvidenceContract(
                [
                    ArtifactKind.Screenshot,
                    ArtifactKind.BusinessOutcome,
                    ArtifactKind.QuoteHandoff,
                    ArtifactKind.TrxMetadata,
                    ArtifactKind.TimingSummary
                ],
                true,
                true,
                true),
            [
                "ANI-ID-001",
                "ANI-ID-002",
                "ANI-ID-005",
                "ANI-ID-006",
                "ANI-ID-007",
                "ANI-ID-008",
                "ANI-ID-009",
                "ANI-ID-010",
                "ANI-ID-011",
                "ANI-ID-012",
                "ANI-ID-013",
                "ANI-ID-014",
                "ANI-ID-015",
                "ANI-ID-016",
                "ANI-ID-017",
                "ANI-ID-018",
                "ANI-ID-019",
                "ANI-ID-020",
                "ANI-ID-021",
                "ANI-ID-022",
                "ANI-ID-023"
            ],
            [
                "client-info-search",
                "prefill-result",
                "active-quote-identity",
                "close-quote",
                "retrieved-quote-result"
            ],
            false);
    }

    public sealed class CommercialDuckCreekBapPilotModule : IProductModule
    {
        public const string DataProfileId = "cldc-bap-al-smoke";
        public const string AutomationIdFamily = "CLDC-BAP-SMOKE";

        public ProductModuleDescriptor Descriptor { get; } = new(
            "commercial-duckcreek-bap-al-pilot",
            "Commercial Lines DuckCreek BAP",
            "SGS 012 BAP Alabama smoke",
            [AutomationIdFamily],
            [
                ProductCapability.SemanticControls,
                ProductCapability.FrameScope,
                ProductCapability.DataProfile,
                ProductCapability.ArtifactEvidence,
                ProductCapability.QuoteHandoff,
                ProductCapability.BusinessOutcomes,
                ProductCapability.TestPlans
            ],
            DataProfileId,
            true,
            new ProductEvidenceContract(
                [
                    ArtifactKind.Screenshot,
                    ArtifactKind.BusinessOutcome,
                    ArtifactKind.QuoteHandoff,
                    ArtifactKind.TrxMetadata,
                    ArtifactKind.TimingSummary,
                    ArtifactKind.RuntimeLocator
                ],
                true,
                true,
                true),
            [],
            [
                "login",
                "new-quote",
                "effective-date",
                "product",
                "start",
                "client-profile",
                "masked-identity",
                "policy-info",
                "insurance-score",
                "bap-fields",
                "stable-frame-paths",
                "pii-safe-evidence-policy",
                "quote-save",
                "quote-search",
                "quote-reopen"
            ],
            false);
    }

    public sealed class PersonalDuckCreekAutoSmokePilotModule :
        IProductModule
    {
        public const string DataProfileId = "pldc-auto-az-ang-smoke";
        public const string AutomationIdFamily = "PLDC-AUTO-SMOKE";

        public ProductModuleDescriptor Descriptor { get; } = Create(
            "personal-duckcreek-auto-az-ang-pilot",
            "SGS 211 Personal Auto AZ ANG smoke",
            AutomationIdFamily,
            DataProfileId,
            [
                "login",
                "new-quote",
                "policy-state",
                "writing-company",
                "conditional-proposal",
                "stable-frame-paths",
                "pii-safe-evidence-policy",
                "quote-capture",
                "quote-search",
                "quote-reopen"
            ]);

        internal static ProductModuleDescriptor Create(
            string moduleId,
            string workflow,
            string automationIdFamily,
            string dataProfileId,
            IReadOnlyList<string> blockers,
            bool requiresQuoteHandoff = true)
        {
            var requiredArtifacts = new List<ArtifactKind>
            {
                ArtifactKind.Screenshot,
                ArtifactKind.BusinessOutcome
            };
            if (requiresQuoteHandoff)
                requiredArtifacts.Add(ArtifactKind.QuoteHandoff);
            requiredArtifacts.AddRange(
            [
                ArtifactKind.TrxMetadata,
                ArtifactKind.TimingSummary,
                ArtifactKind.RuntimeLocator
            ]);
            var requiredCapabilities = new List<ProductCapability>
            {
                ProductCapability.SemanticControls,
                ProductCapability.FrameScope,
                ProductCapability.DataProfile,
                ProductCapability.ArtifactEvidence,
                ProductCapability.BusinessOutcomes,
                ProductCapability.TestPlans
            };
            if (requiresQuoteHandoff)
                requiredCapabilities.Add(ProductCapability.QuoteHandoff);

            return new(
                moduleId,
                "Personal Lines DuckCreek Auto",
                workflow,
                [automationIdFamily],
                requiredCapabilities,
                dataProfileId,
                true,
                new ProductEvidenceContract(
                    requiredArtifacts,
                    true,
                    true,
                    true),
                [],
                blockers,
                false);
        }
    }

    public sealed class PersonalDuckCreekStateMaritalPilotModule :
        IProductModule
    {
        public const string DataProfileId =
            "pldc-auto-state-marital-microcase";
        public const string AutomationIdFamily =
            "PLDC-AUTO-STATE-MARITAL";

        public ProductModuleDescriptor Descriptor { get; } =
            PersonalDuckCreekAutoSmokePilotModule.Create(
                "personal-duckcreek-auto-state-marital-pilot",
                "Personal Auto state and marital rate-filing microcase",
                AutomationIdFamily,
                DataProfileId,
                [
                    "account-state",
                    "marital-status",
                    "account-readiness",
                    "stable-frame-paths",
                    "pii-safe-evidence-policy"
                ],
                requiresQuoteHandoff: false);
    }

    public sealed class ProductModuleConfigurationException : Exception
    {
        public ProductModuleConfigurationException(string message)
            : base(message)
        {
        }
    }
}
