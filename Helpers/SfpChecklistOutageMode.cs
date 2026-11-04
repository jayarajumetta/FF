using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using PnCTestAutomation.Models;

namespace PnCTestAutomation.Helpers
{
    internal static class SfpChecklistOutageMode
    {
        internal const string Setting = "SfpChecklistOutage:FormsOnly";
        internal const string ResultsFolder = "ChecklistOutageForms";
        internal const string IncompleteReason =
            "Checklist and Transmit were not tested due to the configured checklist outage. " +
            "See the separate Forms-only result; this is not a full workflow pass.";

        internal static bool IsEnabled(string value, string featureTitle)
        {
            if (featureTitle is not ("SFP Basic Policy" or "SFP Country Estate Policy" or "SFP Rate Policy"))
                return false;

            if (string.IsNullOrWhiteSpace(value))
                return false;

            if (!bool.TryParse(value, out var enabled))
                throw new InvalidOperationException($"{Setting} must be true or false.");

            return enabled;
        }

        internal static void RequireComparisonMode(bool recordBaseline)
        {
            if (recordBaseline)
                throw new InvalidOperationException(
                    "Checklist outage Forms-only mode requires comparison against an approved baseline; " +
                    "Debugging:RecordBaseline must be false.");
        }

        internal static void RequireReturnedForms(int count)
        {
            if (count == 0)
                throw new InvalidOperationException(
                    "Forms-only validation cannot pass because Duck Creek returned no forms.");
        }

        internal static void RequireComparableBaseline(IEnumerable<ExpectedFormEntry> expected)
        {
            if (!expected.Any(form => form.ExpectedStatus is "YM" or "YS" or "YU"))
                throw new InvalidOperationException(
                    "Forms-only validation requires at least one applicable expected form in the approved baseline.");
        }

        internal static void MarkWorkflowIncomplete() => Assert.Ignore(IncompleteReason);
    }
}
