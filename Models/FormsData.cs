using System;
using System.Collections.Generic;

namespace Playwright_POC.Models
{
    /// <summary>
    /// A single form returned from the DuckCreek FormsEngine response.
    /// Maps to: server > responses > FormsEngine.initPrintJobRs > printJob > printDoc
    /// </summary>
    public class ActualFormEntry
    {
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// DuckCreek selected attribute: 0 = unchecked, 1 = selected, 2 = mandatory.
        /// </summary>
        public int Selected { get; set; }

        public string DocType { get; set; }
        public string Caption { get; set; }
    }

    /// <summary>
    /// A single expected form from the master list (JSON/CSV).
    /// The ExpectedStatus uses codes: YM (mandatory), YS (selected), YU (unselected), N (not expected).
    /// </summary>
    public class ExpectedFormEntry
    {
        public string FormName { get; set; } = string.Empty;

        /// <summary>
        /// Expected status code: YM, YS, YU, or N.
        /// </summary>
        public string ExpectedStatus { get; set; } = string.Empty;

        /// <summary>
        /// Row type from CSV (e.g., BASE, B, C). BASE = shared across all test cases.
        /// Single-letter codes (B, C) are test-case-specific rows.
        /// </summary>
        public string Type { get; set; } = string.Empty;
    }

    /// <summary>
    /// Result of comparing a single expected form against the actual DuckCreek response.
    /// Mirrors the C1–C15 codes from the legacy PowerShell script.
    /// </summary>
    public class FormValidationResult
    {
        public string FormName { get; set; } = string.Empty;
        public string ExpectedStatus { get; set; } = string.Empty;
        public int ActualSelected { get; set; } = -1;
        public string Result { get; set; } = string.Empty;      // PASS, FAIL, INFO, ISSUE
        public string ResultCode { get; set; } = string.Empty;   // C1–C15 (legacy reference)
        public string Details { get; set; } = string.Empty;

        /// <summary>
        /// Human-readable explanation. Primary output shown in reports and console.
        /// </summary>
        public string Message { get; set; } = string.Empty;
    }

    /// <summary>
    /// Aggregate summary of a forms validation run.
    /// </summary>
    public class FormsValidationSummary
    {
        public string LOB { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string QuoteId { get; set; } = string.Empty;
        public int TotalForms { get; set; }
        public int Passed { get; set; }
        public int Failed { get; set; }
        public int Info { get; set; }
        public int Issues { get; set; }
        public List<FormValidationResult> Results { get; set; } = new();
        public FormsResponseMetadata ResponseMetadata { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public string TestCaseName { get; set; } = string.Empty;
        public bool AllPassed => Failed == 0 && Issues == 0;
    }

    /// <summary>
    /// Metadata extracted from the FormsEngine XML response envelope.
    /// Validates printJob name, manuscript, roleBasedSecurity, returnSuccessStatus.
    /// </summary>
    public class FormsResponseMetadata
    {
        public string PrintJobName { get; set; } = string.Empty;
        public string Manuscript { get; set; } = string.Empty;
        public string ReturnSuccessStatus { get; set; } = string.Empty;
        public bool HasRoleBasedSecurity { get; set; }
        public List<string> Warnings { get; set; } = new();
    }

    /// <summary>
    /// Rules for filtering forms by writing company.
    /// E.g., Texas new business = Lloyd's only, ANPAC is conversion-only.
    /// </summary>
    public class CompanyFilterRule
    {
        public string State { get; set; } = string.Empty;
        public List<string> ExcludePrefixes { get; set; } = new();
        public string Reason { get; set; } = string.Empty;
    }

    /// <summary>
    /// Configuration for the DuckCreek Forms API connection.
    /// Bound from appsettings.json section "DuckCreekForms".
    /// </summary>
    public class DuckCreekFormsConfig
    {
        public string ServerBaseUrl { get; set; } = string.Empty;
        public string Endpoint { get; set; } = "/duckcreek/dctserver.aspx";
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Credentials for logging into DuckCreek CLAS browser app.
        /// These are different from the Forms API credentials above.
        /// </summary>
        public string CLASUsername { get; set; } = string.Empty;
        public string CLASPassword { get; set; } = string.Empty;

        /// <summary>
        /// URL for the DuckCreek CLAS Express application (browser login).
        /// </summary>
        public string CLASBaseUrl { get; set; } = string.Empty;
        public string PrintJob { get; set; } = "TransactionPrint";
        public string ResultsBasePath { get; set; } = string.Empty;

        /// <summary>
        /// Default manuscript (fallback when LOB not found in Manuscripts dictionary).
        /// </summary>
        public string Manuscript { get; set; } = "Carrier_CommercialLines_Forms_US_4_0_0_0";

        /// <summary>
        /// Per-LOB manuscript overrides. Key = LOB code (SFP, BAP, BOP, PA, etc.).
        /// If a LOB is not listed here, the default Manuscript is used.
        /// </summary>
        public Dictionary<string, string> Manuscripts { get; set; } = new();

        /// <summary>
        /// Per-LOB print job overrides. Key = LOB code. Falls back to PrintJob if not found.
        /// </summary>
        public Dictionary<string, string> PrintJobs { get; set; } = new();

        /// <summary>
        /// Company filter rules by state. E.g., TX → exclude ANPAC prefixes for new business.
        /// </summary>
        public List<CompanyFilterRule> CompanyFilters { get; set; } = new();

        /// <summary>
        /// Resolves the correct manuscript for a given LOB.
        /// </summary>
        public string GetManuscriptForLob(string lob)
        {
            if (Manuscripts != null && Manuscripts.TryGetValue(lob.ToUpperInvariant(), out var m))
                return m;
            return Manuscript;
        }

        /// <summary>
        /// Resolves the correct print job for a given LOB.
        /// </summary>
        public string GetPrintJobForLob(string lob)
        {
            if (PrintJobs != null && PrintJobs.TryGetValue(lob.ToUpperInvariant(), out var pj))
                return pj;
            return PrintJob;
        }
    }
}
