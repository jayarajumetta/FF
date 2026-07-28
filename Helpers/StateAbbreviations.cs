using System;
using System.Collections.Generic;

namespace PnCTestAutomation.Helpers
{
    /// <summary>
    /// Single source of truth for converting a state name to its two-letter postal code.
    ///
    /// This previously existed as two private copies (SharedEQSteps and SFP_FinalizationSteps)
    /// that drifted apart — one was missing eight states, so scenarios in those states silently
    /// produced the wrong value instead of failing. Add new states here and both callers get them.
    /// </summary>
    public static class StateAbbreviations
    {
        private static readonly Dictionary<string, string> ByName = new(StringComparer.OrdinalIgnoreCase)
        {
            ["ALABAMA"] = "AL",
            ["ALASKA"] = "AK",
            ["ARIZONA"] = "AZ",
            ["ARKANSAS"] = "AR",
            ["CALIFORNIA"] = "CA",
            ["COLORADO"] = "CO",
            ["CONNECTICUT"] = "CT",
            ["DELAWARE"] = "DE",
            ["DISTRICT OF COLUMBIA"] = "DC",
            ["FLORIDA"] = "FL",
            ["GEORGIA"] = "GA",
            ["HAWAII"] = "HI",
            ["IDAHO"] = "ID",
            ["ILLINOIS"] = "IL",
            ["INDIANA"] = "IN",
            ["IOWA"] = "IA",
            ["KANSAS"] = "KS",
            ["KENTUCKY"] = "KY",
            ["LOUISIANA"] = "LA",
            ["MAINE"] = "ME",
            ["MARYLAND"] = "MD",
            ["MASSACHUSETTS"] = "MA",
            ["MICHIGAN"] = "MI",
            ["MINNESOTA"] = "MN",
            ["MISSISSIPPI"] = "MS",
            ["MISSOURI"] = "MO",
            ["MONTANA"] = "MT",
            ["NEBRASKA"] = "NE",
            ["NEVADA"] = "NV",
            ["NEW HAMPSHIRE"] = "NH",
            ["NEW JERSEY"] = "NJ",
            ["NEW MEXICO"] = "NM",
            ["NEW YORK"] = "NY",
            ["NORTH CAROLINA"] = "NC",
            ["NORTH DAKOTA"] = "ND",
            ["OHIO"] = "OH",
            ["OKLAHOMA"] = "OK",
            ["OREGON"] = "OR",
            ["PENNSYLVANIA"] = "PA",
            ["RHODE ISLAND"] = "RI",
            ["SOUTH CAROLINA"] = "SC",
            ["SOUTH DAKOTA"] = "SD",
            ["TENNESSEE"] = "TN",
            ["TEXAS"] = "TX",
            ["UTAH"] = "UT",
            ["VERMONT"] = "VT",
            ["VIRGINIA"] = "VA",
            ["WASHINGTON"] = "WA",
            ["WEST VIRGINIA"] = "WV",
            ["WISCONSIN"] = "WI",
            ["WYOMING"] = "WY"
        };

        /// <summary>
        /// Converts a full state name to its postal code. Input that is already a two-letter
        /// code is passed through uppercased.
        /// </summary>
        /// <remarks>
        /// An unrecognized name is returned uppercased and unchanged rather than guessed at.
        /// The old implementations truncated to the first two characters, which turned
        /// GEORGIA into "GE" and MAINE into "MA" — wrong, but plausible enough to pass
        /// unnoticed. Returning the full name makes a downstream config lookup miss loudly.
        /// </remarks>
        public static string ToAbbreviation(string state)
        {
            var value = (state ?? string.Empty).Trim();

            if (value.Length == 0)
                return string.Empty;

            if (value.Length == 2)
                return value.ToUpperInvariant();

            return ByName.TryGetValue(value, out var abbreviation)
                ? abbreviation
                : value.ToUpperInvariant();
        }
    }
}
