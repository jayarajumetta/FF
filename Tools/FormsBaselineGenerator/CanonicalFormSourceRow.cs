using System;
using System.Collections.Generic;

namespace PnCTestAutomation.Tools.FormsBaselineGenerator
{
    public enum FormSourceFamily
    {
        Sfp,
        Common
    }

    public sealed record WorkbookSourceInfo(
        string Identity,
        string Path,
        string Sha256);

    public sealed record SourceCellFact(
        string Header,
        string Address,
        string RawValue);

    public sealed record CanonicalStateMarker(
        string RawHeader,
        string NormalizedState,
        string Address,
        string RawValue,
        bool IsConfiguredState,
        bool IsCompanySpecific,
        bool IsLegacyEligible);

    public sealed record CanonicalSourceFinding(
        string Code,
        string Message,
        string CellAddress,
        bool ManualReviewRequired);

    public sealed class CanonicalFormSourceRow
    {
        public string RawFormIdentifier { get; init; } = "";
        public string NormalizedFormIdentifier { get; init; } = "";
        public string ParsedFormNumber { get; init; }
        public string ParsedEdition { get; init; }
        public string TitleDescription { get; init; } = "";
        public FormSourceFamily SourceFamily { get; init; }
        public WorkbookSourceInfo Workbook { get; init; } = new("", "", "");
        public string Worksheet { get; init; } = "";
        public int SourceRowNumber { get; init; }
        public string LegacySection { get; init; } = "BASE";
        public IReadOnlyList<string> SourceDivisionProductHints { get; init; } = Array.Empty<string>();
        public IReadOnlyList<SourceCellFact> RelevantCells { get; init; } = Array.Empty<SourceCellFact>();
        public IReadOnlyList<CanonicalStateMarker> StateMarkers { get; init; } = Array.Empty<CanonicalStateMarker>();
        public string RawSelection { get; init; } = "";
        public string RawRules { get; init; } = "";
        public string RawPrintRules { get; init; } = "";
        public string RawMultipleSelectionCriteria { get; init; } = "";
        public string RawAdditionalSelectionCriteria { get; init; } = "";
        public string RawAdditionalRequirements { get; init; } = "";
        public string RawNotes { get; init; } = "";
        public string RawStartDate { get; init; } = "";
        public DateOnly? ParsedStartDate { get; init; }
        public string RawStopDate { get; init; } = "";
        public DateOnly? ParsedStopDate { get; init; }
        public string RawEffectiveDate { get; init; } = "";
        public DateOnly? ParsedEffectiveDate { get; init; }
        public string RawTransactionRules { get; init; } = "";
        public IReadOnlyList<string> TransactionTokens { get; init; } = Array.Empty<string>();
        public string RawLifecycle { get; init; } = "";
        public string RawWithdrawn { get; init; } = "";
        public string RawReplacement { get; init; } = "";
        public IReadOnlyList<CanonicalSourceFinding> Findings { get; init; } =
            Array.Empty<CanonicalSourceFinding>();
    }
}
