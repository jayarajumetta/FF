using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using PnCTestAutomation.Helpers;
using static Microsoft.Playwright.Assertions;

namespace PnCTestAutomation.Pages.ExpertQuotePages.SFP
{
    public class SFP_LiabilityOptionalCoveragePage(IPage page) : BasePage(page)
    {
        private readonly Dictionary<string, IReadOnlyDictionary<string, string>> _retailExpected = new(StringComparer.Ordinal);
        private ILocator Catalog => _page.GetByTestId("coverageTableLiability");

        public async Task EditAsync(IReadOnlyDictionary<string, string> values)
        {
            var name = values["CoverageName"];
            if (name is "Retail Sales On Premises" or "Retail Sales Off Premises")
            {
                await EditRetailAsync(values);
                return;
            }
            var caption = name switch
            {
                "Lessors Risk" => new Regex(@"^\s*Lessor['\u2019]?s\s+Risk\s*$", RegexOptions.IgnoreCase),
                "Special Farm Pollution" or "Chemical Drift and Transportation Increased Limits" =>
                    SFP_NativeFormPage.Caption(name),
                _ => throw new ArgumentException($"Unsupported liability coverage '{name}'.")
            };
            var form = new SFP_NativeFormPage(_page);
            var row = await form.SelectNamedCatalogCoverageAsync(Catalog, caption);
            var firstField = name switch
            {
                "Lessors Risk" => form.CheckboxLabel("CovLessorsRiskInput.Dwelling"),
                _ => form.Field(AcreageCoverageEntity(name) + ".OccurrenceAggregateLimit")
            };
            var edit = row.GetByRole(AriaRole.Button, new()
            {
                NameRegex = new Regex(@"^\s*(?:Edit|Add)(?: Coverage)?\s*$", RegexOptions.IgnoreCase)
            }).And(_page.Locator(":visible"));
            await firstField.Or(edit).First.WaitForAsync(new() { State = WaitForSelectorState.Visible });
            if (await firstField.CountAsync() == 0)
            {
                await Expect(edit).ToHaveCountAsync(1);
                await edit.ClickAsync();
                await WaitForSpinnerAsync();
            }
            switch (name)
            {
                case "Lessors Risk":
                    await FillLessorsAsync(form, values);
                    break;
                case "Special Farm Pollution":
                case "Chemical Drift and Transportation Increased Limits":
                    await ApplyAcreageCoverageAsync(values);
                    break;
            }
            await form.ClickActionAsync("Save");
            await form.RequireReadyAsync(Catalog);
            await Expect(row).Not.ToContainTextAsync(
                new Regex("Required Info Missing|Incomplete", RegexOptions.IgnoreCase));
        }

        private static string AcreageCoverageEntity(string name) => name switch
        {
            "Special Farm Pollution" => "CovLivestockOperationsSpecialFarmPollutionInput",
            "Chemical Drift and Transportation Increased Limits" => "CovFarmChemTransportationDriftInput",
            _ => throw new ArgumentException($"Unsupported computed-acreage coverage '{name}'.")
        };

        internal async Task ApplyAcreageCoverageAsync(IReadOnlyDictionary<string, string> values)
        {
            var form = new SFP_NativeFormPage(_page);
            var entity = AcreageCoverageEntity(values["CoverageName"]);
            await form.SetAsync(entity + ".OccurrenceAggregateLimit", values["OccurrenceAggregate"], moneyOption: true);
            await Expect(form.Field(entity + ".NumberOfAcresUsed")).Not.ToBeEditableAsync();
            try
            {
                await form.VerifyAsync(entity + ".NumberOfAcresUsed", values["Acres"], number: true);
            }
            catch (PlaywrightException error)
            {
                throw new PlaywrightException(
                    $"Cannot verify the supplied {values["CoverageName"]} acreage ({values["Acres"]}). "
                    + "New-quote coverages 145 and 148 both use the read-only line farming-acreage plus unlisted-acreage total. "
                    + error.Message);
            }
            if (values["CoverageName"] == "Special Farm Pollution")
            {
                await form.SetAsync(entity + ".OnSiteManureStorage", values["OnsiteManureStorage"]);
                await form.SetAsync(entity + ".TotalCapacityOfManureStorage", values["TotalOnsiteCapacity"], number: true);
                await form.SetAsync(entity + ".MaximumNumberOfMiles", values["MaximumMiles"], number: true);
                await form.SetAsync(entity + ".NumberOfTrips", values["Trips"], number: true);
            }
        }

        private static async Task FillLessorsAsync(SFP_NativeFormPage form, IReadOnlyDictionary<string, string> values)
        {
            foreach (var field in new[] { "DwellingSelected", "BuildingSelected", "LandSelected" })
                SfpRequiredTable.RequireValue(field, values[field], "Select");
            await form.CheckAsync("CovLessorsRiskInput.Dwelling");
            await form.ClickActionAsync("AddListedLocationDwelling");
            await form.SetAsync("LessorsDwellingInput.Location", values["DwellingLocation"]);
            await form.SetAsync("LessorsDwellingInput.ResidenceID", values["Residence"]);
            await form.SetAsync("LessorsDwellingInput.OnFarmPremises", values["OnFarm"]);
            await form.CheckAsync("CovLessorsRiskInput.Building");
            await form.ClickActionAsync("AddListedLocationBuilding");
            await form.SetAsync("LessorsBuildingInput.Location", values["BuildingLocation"]);
            await form.SetAsync("LessorsBuildingInput.Building", values["Building"]);
            await form.SetAsync("LessorsBuildingInput.SquareFeet", values["SquareFeet"], number: true);
            await form.CheckAsync("CovLessorsRiskInput.Land");
            await form.ClickActionAsync("AddListedLand");
            await form.SetAsync("LessorsLandInput.Location", values["LandLocation"]);
            await form.SetAsync("LessorsLandInput.Acres", values["Acres"], number: true);
        }

        private async Task EditRetailAsync(IReadOnlyDictionary<string, string> values)
        {
            var form = new SFP_NativeFormPage(_page);
            await form.ClickActionAsync("AddEditRetailSales");
            var onPremises = values["CoverageName"] == "Retail Sales On Premises";
            var entity = onPremises ? "CovRetailSalesOnPremises" : "CovRetailSalesOffPremises";
            var selector = onPremises ? "RetailSalesOnPremise" : "RetailSalesOffPremise";
            var total = onPremises ? "TotalSalesOnPremise" : "TotalSalesOffPremise";
            await VerifyRetailSelectorAsync(form, onPremises);
            await form.CheckAsync("RetailSaleOfGoodsInput." + selector);
            await form.SetAsync(entity + "Input." + total, values["TotalSales"], number: true);
            if (onPremises)
                await form.SetSectionAsync(await form.SectionAsync(entity + "Input." + total),
                    "SalesLocationInput.Location", values["Location"]);
            await form.SetAsync(entity + "Input.OthersGoods", values["ProducedByOthers"]);
            await form.SetAsync(entity + "Input.Description", values["Description"]);
            await form.SetAsync(entity + "Input.PercentOfTotalSalesOthersGoods", values["Percent"], number: true);
            await form.ClickActionAsync("Save");
            await form.RequireReadyAsync(Catalog);

            _retailExpected[values["CoverageName"]] = values;
            await form.ClickActionAsync("AddEditRetailSales");
            foreach (var expected in _retailExpected.Values)
                await VerifyRetailAsync(form, expected);
            await form.ClickActionAsync("Save");
            await form.RequireReadyAsync(Catalog);
        }

        private static async Task VerifyRetailAsync(SFP_NativeFormPage form, IReadOnlyDictionary<string, string> values)
        {
            var onPremises = values["CoverageName"] == "Retail Sales On Premises";
            var entity = onPremises ? "CovRetailSalesOnPremises" : "CovRetailSalesOffPremises";
            var totalField = onPremises ? "TotalSalesOnPremise" : "TotalSalesOffPremise";
            await VerifyRetailSelectorAsync(form, onPremises);
            await form.VerifyAsync("RetailSaleOfGoodsInput." +
                (onPremises ? "RetailSalesOnPremise" : "RetailSalesOffPremise"), "Yes");
            await form.VerifyAsync(entity + "Input." + totalField, values["TotalSales"], number: true);
            await form.VerifyAsync(entity + "Input.OthersGoods", values["ProducedByOthers"]);
            await form.VerifyAsync(entity + "Input.Description", values["Description"]);
            await form.VerifyAsync(entity + "Input.PercentOfTotalSalesOthersGoods", values["Percent"], number: true);
            if (onPremises)
                await form.VerifyControlAsync(
                    form.SectionField(await form.SectionAsync(entity + "Input." + totalField), "SalesLocationInput.Location"),
                    values["Location"]);
            await form.VerifyAsync(entity + "Output.Coverage", "171");
            await form.VerifyAsync(entity + "Output.ClassCode", onPremises ? "10020" : "10030");
            var total = decimal.Parse(values["TotalSales"], CultureInfo.InvariantCulture);
            var others = SfpRequiredTable.YesNo(values["ProducedByOthers"])
                ? total * decimal.Parse(values["Percent"], CultureInfo.InvariantCulture) / 100
                : 0;
            await form.VerifyAsync(entity + "Output.TotalSalesOthersGoods", others.ToString(CultureInfo.InvariantCulture), number: true);
            await form.VerifyAsync(entity + "Output.TotalSalesOwnGoods", (total - others).ToString(CultureInfo.InvariantCulture), number: true);
        }

        private static Task VerifyRetailSelectorAsync(SFP_NativeFormPage form, bool onPremises) =>
            Expect(form.CheckboxLabel("RetailSaleOfGoodsInput." +
                (onPremises ? "RetailSalesOnPremise" : "RetailSalesOffPremise")))
                .ToHaveTextAsync(new Regex(onPremises
                    ? @"^\s*On-Premises\s*\(171-10020\)\s*$"
                    : @"^\s*Off-Premises\s*\(171-10030\)\s*$"));
    }
}
