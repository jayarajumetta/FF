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
        private ILocator OccupancyTable => _page.GetByTestId("classCodeTable");
        private ILocator OccupancyFilter => _page.GetByTestId("temp.filter");

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
                await form.SetAsync("BuildingInput." + field, values[question]);

            await form.CheckAsync("RiskInput.EQBuildingCoverage");
            await form.SetAsync("CovBuildingInput.CoverageType", values["CoverageType"]);
            await form.SetAsync("CovBuildingInput.Limit", values["InsuranceAmount"], number: true);
            await form.SetAsync("CovBuildingInput.PerilGroup", values["Perils"]);
            await form.SetByLabelAsync("Replacement Cost", values["ReplacementCost"]);
            await form.SetAsync("CovBuildingInput.DescriptionCodeEQ", values["DescriptionCode"]);
            await form.SetAsync("BuildingInput.SquareFt", values["SquareFeet"], number: true);
            await form.SetAsync("BuildingValuatioinInput.EstimatorType", values["Estimator"]);
            await form.SetAsync("BuildingValuatioinInput.ValuationType", values["Valuation"]);
            await form.SetByLabelAsync("Occupancy", values["Occupancy"]);
            await SelectOccupancyAsync(values["SearchResult"]);
            await form.SetAsync("BuildingInput.BuildingThermostatQuestion", values["ThermostatQuestion"]);
            await form.ClickActionAsync("CompleteBVSProcess1");
            await RequireCalculatedValueAsync(form);

            await form.CheckAsync("RiskInput.EQBuildingContentsCoverage");
            await SelectContentsTypeAsync(values["ContentsType"]);
            await form.SetAsync("CovBuildingContentsInput.Limit", values["ContentsAmount"], number: true);
            await form.SetAsync("CovBuildingContentsInput.PerilGroup", values["ContentsPerils"]);
            var contentsSection = await form.SectionAsync("CovBuildingContentsInput.Limit");
            await form.SetSectionAsync(contentsSection, "CovBuildingContentsInput.ReplacementCost",
                values["ContentsReplacementCost"]);
            await form.SetAsync("CovBuildingContentsInput.DescriptionCodeEQ", values["ContentsDescriptionCode"]);
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
            await _page.GetByTestId(added[0]).ClickAsync();
            await WaitForSpinnerAsync();
            await form.VerifyAsync("BuildingInput.AdditionalDescription", values["AdditionalDesc"]);
            await form.VerifyAsync("CovBuildingInput.CoverageType", values["CoverageType"]);
            await form.VerifyAsync("CovBuildingInput.Limit", values["InsuranceAmount"], number: true);
            await form.VerifyAsync("CovBuildingInput.PerilGroup", values["Perils"]);
            await VerifyContentsTypeAsync(values["ContentsType"]);
            await form.VerifyAsync("CovBuildingContentsInput.Limit", values["ContentsAmount"], number: true);
            await form.VerifyAsync("CovBuildingContentsInput.PerilGroup", values["ContentsPerils"]);
            await form.VerifyAsync("CovBuildingContentsInput.DescriptionCodeEQ", values["ContentsDescriptionCode"]);
            await form.VerifyControlAsync(
                form.SectionField(await form.SectionAsync("CovBuildingContentsInput.Limit"),
                    "CovBuildingContentsInput.ReplacementCost"),
                values["ContentsReplacementCost"]);
            await RequireCalculatedValueAsync(form);
            await locations.LocationsNavigation.ClickAsync();
            await WaitForSpinnerAsync();
            await locations.WaitUntilReadyAsync();
        }

        internal Task SelectContentsTypeAsync(string type) =>
            new SFP_NativeFormPage(_page).SetAsync("CovBuildingContentsInput.CoverageType", type);

        internal Task VerifyContentsTypeAsync(string expectedType) =>
            new SFP_NativeFormPage(_page).VerifyAsync("CovBuildingContentsInput.CoverageType", expectedType);

        private async Task SelectOccupancyAsync(string searchResult)
        {
            var form = new SFP_NativeFormPage(_page);
            if (!await OccupancyTable.IsVisibleAsync())
            {
                var search = _page.GetByRole(AriaRole.Button, new() { Name = "Search", Exact = true })
                    .And(_page.Locator(":visible"));
                await Expect(search).ToHaveCountAsync(1);
                await search.ClickAsync();
                await WaitForSpinnerAsync();
            }
            await Expect(OccupancyTable).ToBeVisibleAsync();
            await OccupancyFilter.FillAsync(searchResult);
            var parts = searchResult.Split(" - ", 2, StringSplitOptions.None);
            if (parts.Length != 2)
                throw new ArgumentException($"Expected 'code - description' for SearchResult, received '{searchResult}'.");
            var row = OccupancyTable.Locator("tr, mat-row")
                .Filter(new() { Has = _page.GetByText(parts[0], new() { Exact = true }) })
                .Filter(new() { HasText = parts[1] });
            await Expect(row).ToHaveCountAsync(1);
            var checkbox = row.Locator("input[type='checkbox'][data-testid$='occupancyClassCodeInput$addToPolicy.value' i]");
            await Expect(checkbox).ToHaveCountAsync(1);
            await checkbox.CheckAsync();
            await Expect(checkbox).ToBeCheckedAsync();
            await form.ClickActionAsync("AddClass");
            await Expect(_page.GetByText(searchResult, new() { Exact = true }).And(_page.Locator(":visible"))).ToHaveCountAsync(1);
        }

        private static async Task RequireCalculatedValueAsync(SFP_NativeFormPage form)
        {
            var amount = form.Field("BuildingValuationOutput.CalculatedValue");
            await SfpFieldAssertions.PositiveAmountAsync(amount, "BVS calculated value");
        }
    }
}
