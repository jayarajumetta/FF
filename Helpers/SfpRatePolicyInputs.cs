using System;
using System.Collections.Generic;
using System.Linq;
using Reqnroll;

namespace PnCTestAutomation.Helpers
{
    internal static class SfpRatePolicyInputs
    {
        public static bool IsRatePolicy(IEnumerable<string> tags, string title) =>
            (tags ?? Array.Empty<string>()).Contains("RatePolicy", StringComparer.OrdinalIgnoreCase)
            || (title ?? "").StartsWith("SFP Rate Policy - ", StringComparison.OrdinalIgnoreCase);

        public static readonly string[] BuildingFields =
        {
            "AdditionalDesc", "Construction", "RateType", "YearBuilt", "WiringYear", "HeatingYear",
            "PlumbingYear", "RoofYear", "RoofType", "SolidFuelQuestion", "CoverageType", "InsuranceAmount",
            "Perils", "ReplacementCost", "DescriptionCode", "SquareFeet", "Estimator", "Valuation",
            "Occupancy", "SearchResult", "ThermostatQuestion", "ContentsType", "ContentsAmount",
            "ContentsPerils", "ContentsReplacementCost", "ContentsDescriptionCode"
        };

        public static readonly string[] ResidenceCoverageFields =
        {
            "InsuranceAmount", "SquareFeet", "Perils", "ThermostatQuestion", "ActualCashValue",
            "EstimatorType", "RCTOption", "UseDefaults", "DepreciationPercentage"
        };

        public static readonly string[] ResidenceContentsFields =
        {
            "CoverageType", "InsuranceAmount", "Perils", "ReplacementCost"
        };

        public static readonly string[] MachineryFields =
        {
            "Code", "Limit", "Deductible", "SpecialUse", "CabGlass", "Year", "Make", "Model", "SerialNumber"
        };

        public static IReadOnlyDictionary<string, string> ScheduledProperty(Table table)
        {
            var category = Discriminator(table, "Category");
            var fields = category switch
            {
                "407" => new[]
                {
                    "Category", "ItemType", "Description", "Limit", "AppraisalYear", "TypeOfStone",
                    "Carat", "Cut", "TypeOfJewelry", "KeptInAVault", "GemPrint"
                },
                "409" => new[]
                {
                    "Category", "ItemType", "Amount", "AppraisalYear", "KeptInVault",
                    "UnattendedVehicle", "Description"
                },
                "411" => new[]
                {
                    "Category", "ItemType", "Amount", "LimitPeril", "UnattendedVehicles",
                    "ProfessionalEntertainer", "Name", "Description"
                },
                _ => throw new ArgumentException($"Unsupported Rate Policy scheduled-property category '{category}'.")
            };
            var values = SfpRequiredTable.Read(table, fields);
            SfpRequiredTable.RequireValue("ItemType", values["ItemType"], category switch
            {
                "407" => "Jewelry",
                "409" => "Stamp Collection",
                "411" => "Auto Trailer Home Personal Effects",
                _ => throw new ArgumentException($"Unsupported category '{category}'.")
            });
            return values;
        }

        public static IReadOnlyDictionary<string, string> Liability(Table table)
        {
            var coverage = Discriminator(table, "CoverageName");
            var fields = coverage switch
            {
                "Lessors Risk" => new[]
                {
                    "CoverageName", "DwellingSelected", "DwellingLocation", "Residence", "OnFarm",
                    "BuildingSelected", "BuildingLocation", "Building", "SquareFeet",
                    "LandSelected", "LandLocation", "Acres"
                },
                "Retail Sales On Premises" => new[]
                {
                    "CoverageName", "TotalSales", "Location", "ProducedByOthers", "Description", "Percent"
                },
                "Retail Sales Off Premises" => new[]
                {
                    "CoverageName", "TotalSales", "ProducedByOthers", "Description", "Percent"
                },
                "Special Farm Pollution" => new[]
                {
                    "CoverageName", "OccurrenceAggregate", "Acres", "OnsiteManureStorage",
                    "TotalOnsiteCapacity", "MaximumMiles", "Trips"
                },
                "Chemical Drift and Transportation Increased Limits" => new[]
                {
                    "CoverageName", "OccurrenceAggregate", "Acres"
                },
                _ => throw new ArgumentException($"Unsupported Rate Policy liability coverage '{coverage}'.")
            };
            return SfpRequiredTable.Read(table, fields);
        }

        private static string Discriminator(Table table, string field)
        {
            if (!table.Header.SequenceEqual(new[] { "Question", "Answer" }))
                throw new ArgumentException("Expected exactly the Question and Answer table columns.");
            var rows = table.Rows.Where(row => row["Question"].Trim() == field).ToArray();
            if (rows.Length != 1)
                throw new ArgumentException($"Expected exactly one '{field}' table field.");
            return rows[0]["Answer"].Trim();
        }
    }
}
