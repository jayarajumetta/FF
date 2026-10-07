using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Playwright;
using PnCTestAutomation.Helpers;
using static Microsoft.Playwright.Assertions;

namespace PnCTestAutomation.Pages.ExpertQuotePages.SFP
{
    public class SFP_BuildingPage(IPage page) : BasePage(page)
    {
        public async Task AddWithCoverageAndContentsAsync(IReadOnlyDictionary<string, string> values)
        {
            SfpRequiredTable.RequireValue("CoverageType", values["CoverageType"], "Farm Building", "Private Structure");
            SfpRequiredTable.RequireValue("ContentsType", values["ContentsType"],
                values["CoverageType"] == "Farm Building" ? "Farm Contents" : "Private Contents");
            SfpRequiredTable.RequireValue("Estimator", values["Estimator"], "BVS");
            var locations = new SFP_LocationsResidencesBuildingsPage(_page);
            await locations.WaitUntilReadyAsync();
            var previousBuildings = await locations.EditBuildingButtons.EvaluateAllAsync<string[]>(
                "elements => elements.map(element => element.getAttribute('data-testid'))");
            await locations.AddBuildingButton().ClickAsync();
            await WaitForSpinnerAsync();
            var form = new SFP_NativeFormPage(_page);
            foreach (var (question, field) in new[]
            {
                ("AdditionalDesc", "AdditionalDescription"), ("Construction", "ConstructionCode"),
                ("RateType", "RateType"), ("YearBuilt", "YearBuilt"), ("WiringYear", "WiringYear"),
                ("HeatingYear", "HeatingYear"), ("PlumbingYear", "PlumbingYear"),
                ("RoofYear", "RoofYear"), ("RoofType", "RoofType"), ("SolidFuelQuestion", "SolidFuelHeatingDevices")
            })
            {
                var value = question switch
                {
                    "Construction" => NativeConstructionCaption(values[question]),
                    "RoofType" => NativeRoofCaption(values[question]),
                    _ => values[question]
                };
                await form.SetAsync("BuildingInput." + field, value);
            }

            await form.CheckAsync("RiskInput.EQBuildingCoverage");
            await form.SetAsync("CovBuildingInput.CoverageType", values["CoverageType"]);
            await form.SetAsync("CovBuildingInput.Limit", values["InsuranceAmount"], number: true);
            await form.SetAsync("CovBuildingInput.PerilGroup", values["Perils"]);
            await form.SetAsync("CovBuildingInput.ReplacementCost", values["ReplacementCost"]);
            await form.SetAsync(
                "CovBuildingInput.DescriptionCodeEQ", NativeDescriptionCodeCaption(values["DescriptionCode"]));
            await form.SetAsync("BuildingInput.SquareFt", values["SquareFeet"], number: true);
            await form.SetAsync("BuildingInput.BuildingThermostatQuestion", values["ThermostatQuestion"]);
            await form.SetAsync("BuildingValuatioinInput.EstimatorType", values["Estimator"]);
            await form.SetAsync("BuildingValuatioinInput.ValuationType", values["Valuation"]);
            await form.SetRefreshingTypeaheadAsync(
                "BuildingValuatioinInput.BVSOccupancyGroup", values["Occupancy"]);
            await SelectBvsSearchResultAsync(values["SearchResult"]);
            await GetValuationAsync();
            await RequireCalculatedValuesAsync(form);

            await form.CheckAsync("RiskInput.EQBuildingContentsCoverage");
            // The section is visible before Angular Material finishes wiring its controls.
            await Expect(form.Field("CovBuildingContentsInput.DescriptionCodeEQ").Locator(
                    "xpath=ancestor::mat-form-field[contains(@class, 'mat-form-field-animations-enabled')][1]"))
                .ToHaveCountAsync(1, new() { Timeout = 30000 });
            await SelectContentsTypeAsync(values["ContentsType"]);
            await form.SetAsync("CovBuildingContentsInput.Limit", values["ContentsAmount"], number: true);
            await form.SetAsync("CovBuildingContentsInput.PerilGroup", values["ContentsPerils"]);
            var contentsSection = await form.SectionAsync("CovBuildingContentsInput.Limit");
            await form.SetSectionAsync(contentsSection, "CovBuildingContentsInput.ReplacementCost",
                values["ContentsReplacementCost"]);
            await form.SetAsync("CovBuildingContentsInput.DescriptionCodeEQ",
                NativeDescriptionCodeCaption(values["ContentsDescriptionCode"]));
            await form.VerifyAsync("BuildingInput.AdditionalDescription", values["AdditionalDesc"]);
            await form.VerifyAsync("CovBuildingInput.Limit", values["InsuranceAmount"], number: true);
            await form.VerifyAsync("CovBuildingContentsInput.Limit", values["ContentsAmount"], number: true);
            await form.ClickActionAsync("Save");
            await locations.WaitUntilReadyAsync();
            await Expect(locations.EditBuildingButtons).ToHaveCountAsync(previousBuildings.Length + 1);
            var currentBuildings = await locations.EditBuildingButtons.EvaluateAllAsync<string[]>(
                "elements => elements.map(element => element.getAttribute('data-testid'))");
            var added = currentBuildings.Except(previousBuildings, StringComparer.Ordinal).ToArray();
            if (added.Length != 1)
                throw new PlaywrightException("The newly saved building could not be identified uniquely.");
            await locations.OpenBuildingAsync(added[0]);
            await form.VerifyAsync("BuildingInput.AdditionalDescription", values["AdditionalDesc"]);
            await form.VerifyAsync("CovBuildingInput.CoverageType", values["CoverageType"]);
            await form.VerifyAsync("CovBuildingInput.Limit", values["InsuranceAmount"], number: true);
            await form.VerifyAsync("CovBuildingInput.PerilGroup", values["Perils"]);
            await VerifyContentsTypeAsync(values["ContentsType"]);
            await form.VerifyAsync("CovBuildingContentsInput.Limit", values["ContentsAmount"], number: true);
            await form.VerifyAsync("CovBuildingContentsInput.PerilGroup", values["ContentsPerils"]);
            await form.VerifyAsync("CovBuildingContentsInput.DescriptionCodeEQ",
                NativeDescriptionCodeCaption(values["ContentsDescriptionCode"]));
            await form.VerifySectionAsync(
                await form.SectionAsync("CovBuildingContentsInput.Limit"),
                "CovBuildingContentsInput.ReplacementCost", values["ContentsReplacementCost"]);
            await RequireCalculatedValuesAsync(form);
            await locations.LocationsNavigation.ClickAsync();
            await WaitForSpinnerAsync();
            await locations.WaitUntilReadyAsync();
        }

        internal Task SelectContentsTypeAsync(string type) =>
            new SFP_NativeFormPage(_page).SetAsync("CovBuildingContentsInput.CoverageType", type);

        internal Task VerifyContentsTypeAsync(string expectedType) =>
            new SFP_NativeFormPage(_page).VerifyAsync("CovBuildingContentsInput.CoverageType", expectedType);

        internal static string NativeConstructionCaption(string value) => value switch
        {
            "Brick" => "Brick/Stone/Masonry",
            "Metal" => "Aluminum/Steel/Engineered Steel/All Metal",
            _ => value
        };

        internal static string NativeRoofCaption(string value) => value switch
        {
            "Concrete" => "Concrete, Composition Wood Fiber/Cement",
            _ => value
        };

        internal static string NativeDescriptionCodeCaption(string value) => value switch
        {
            "Storage Building" => "712 - Storage Building",
            "Equipment Shed" => "160 - Equipment Shed",
            _ => value
        };

        internal Task SelectBvsSearchResultAsync(string searchResult) =>
            new SFP_NativeFormPage(_page).SetAsync(
                "BuildingValuatioinInput.BVSSearchResult", searchResult);

        internal Task GetValuationAsync() =>
            new SFP_NativeFormPage(_page).ClickActionAsync("CompleteBVSProcess3");

        internal static async Task RequireCalculatedValuesAsync(SFP_NativeFormPage form)
        {
            await SfpFieldAssertions.PositiveAmountAsync(
                form.Field("BuildingValuationOutput.ACVValue"), "BVS ACV calculated value");
            await SfpFieldAssertions.PositiveAmountAsync(
                form.Field("BuildingValuationOutput.RCValue"), "BVS RC calculated value");
        }
    }
}
