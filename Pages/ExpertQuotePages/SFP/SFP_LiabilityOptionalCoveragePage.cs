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
            var form = new SFP_NativeFormPage(_page);
            await form.SelectNamedCatalogCoverageAsync(Catalog, CatalogCaption(name));
            var actionName = CoverageActionName(name);
            var firstField = name switch
            {
                "Lessors Risk" => form.CheckboxLabel("CovLessorsRiskInput.Dwelling"),
                _ => form.Field(AcreageCoverageEntity(name) + ".OccurrenceAggregateLimit")
            };
            var edit = form.Action(actionName);
            await form.ClickActionAndRequireReadyAsync(
                actionName, firstField.Or(form.Action("Save")));
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
            await form.ContinueReviewAndRequireReadyAsync(Catalog);
            var summaryRow = edit.Locator("xpath=ancestor::*[self::tr or self::mat-row][1]");
            await Expect(summaryRow).ToHaveCountAsync(1);
            await Expect(summaryRow).Not.ToContainTextAsync(
                new Regex("Required Info Missing|Incomplete", RegexOptions.IgnoreCase));
        }

        private static string CoverageActionName(string name) => name switch
        {
            "Lessors Risk" => "AddEditLessorsRisk",
            "Special Farm Pollution" => "AddEditSpecialFarmPollution",
            "Chemical Drift and Transportation Increased Limits" => "AddEditFarmChemTransportationDrift",
            _ => throw new ArgumentException($"Unsupported liability coverage '{name}'.")
        };

        internal static Regex CatalogCaption(string name) => name switch
        {
            "Lessors Risk" =>
                new Regex(@"^\s*Lessor['\u2019]?s\s+Risk\s*$", RegexOptions.IgnoreCase),
            "Special Farm Pollution" =>
                SFP_NativeFormPage.Caption(
                    "Livestock Operations Special Farm Pollution Liability"),
            "Chemical Drift and Transportation Increased Limits" =>
                SFP_NativeFormPage.Caption(
                    "Farm Chemical Transportation/Farm Chemical Drift"),
            _ => throw new ArgumentException($"Unsupported liability coverage '{name}'.")
        };

        internal async Task ExpectCatalogCoverageUnavailableAsync(string name)
        {
            await Expect(Catalog).ToBeVisibleAsync();
            var cell = _page.Locator("td, mat-cell").Filter(new()
            {
                HasTextRegex = CatalogCaption(name)
            });
            var row = Catalog.Locator("tr, mat-row").Filter(new() { Has = cell });
            await Expect(row).ToHaveCountAsync(0);
        }

        internal static bool IsCoverageExpectedUnavailable(string ratingState, string coverageName) =>
            string.Equals(ratingState?.Trim(), "Wyoming", StringComparison.OrdinalIgnoreCase)
            && (string.Equals(
                    coverageName?.Trim(),
                    "Special Farm Pollution",
                    StringComparison.OrdinalIgnoreCase)
                || string.Equals(
                    coverageName?.Trim(),
                    "Chemical Drift and Transportation Increased Limits",
                    StringComparison.OrdinalIgnoreCase));

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
            var acreage = form.ReadOnlyValue(entity + ".NumberOfAcresUsed");
            await Expect(acreage).ToHaveCountAsync(1);
            try
            {
                await SfpFieldAssertions.NumberTextAsync(acreage, values["Acres"]);
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
                await form.SetAsync(
                    "SpecialFarmPollutionQuestionsInput.PriorIncidencesOfPollutionClaims",
                    values["PriorPollutionClaims"]);
                await form.SetAsync(
                    "SpecialFarmPollutionQuestionsInput.ClientAppliesHumanWaste",
                    values["ClientAppliesHumanWaste"]);
                await form.SetAsync(
                    "SpecialFarmPollutionQuestionsInput.RiskWithin1_2Mile",
                    values["RiskWithinHalfMile"]);
                await form.SetAsync(
                    "SpecialFarmPollutionQuestionsInput.RiskWithin1_4Mile",
                    values["RiskWithinQuarterMile"]);
            }
            else
            {
                SfpRequiredTable.RequireValue(
                    "Eligibility", values["Eligibility"], "None of the Above");
                await form.CheckAsync("FarmChemTransportationDriftQuestionsInput.EqNoneAbove");
            }
        }

        private static async Task FillLessorsAsync(SFP_NativeFormPage form, IReadOnlyDictionary<string, string> values)
        {
            foreach (var field in new[] { "DwellingSelected", "BuildingSelected", "LandSelected" })
                SfpRequiredTable.RequireValue(field, values[field], "Select");
            await form.CheckAsync("CovLessorsRiskInput.Dwelling");
            await SelectListedLocationAsync(
                form, "CovLessorsRiskInput.LessorsDwellingLocation", values["DwellingLocation"]);
            await form.ClickActionAsync("AddListedLocationDwelling");
            await VerifyListedItemAsync(form, "LessorsDwellingInput.Location", values["DwellingLocation"]);
            await SelectListedItemAsync(form, "LessorsDwellingInput.ResidenceID", values["Residence"]);
            await form.SetAsync("LessorsDwellingInput.OnFarmPremises", values["OnFarm"]);
            await form.CheckAsync("CovLessorsRiskInput.Building");
            await SelectListedLocationAsync(
                form, "CovLessorsRiskInput.LessorsBuildingLocation", values["BuildingLocation"]);
            await form.ClickActionAsync("AddListedLocationBuilding");
            await VerifyListedItemAsync(form, "LessorsBuildingInput.Location", values["BuildingLocation"]);
            await SelectListedItemAsync(form, "LessorsBuildingInput.Building", values["Building"]);
            await form.SetAsync("LessorsBuildingInput.SquareFeet", values["SquareFeet"], number: true);
            await form.CheckAsync("CovLessorsRiskInput.Land");
            await SelectListedLocationAsync(
                form, "CovLessorsRiskInput.LessorsLandLocation", values["LandLocation"]);
            await form.ClickActionAsync("AddListedLand");
            await VerifyListedItemAsync(form, "LessorsLandInput.Location", values["LandLocation"]);
            await form.SetAsync("LessorsLandInput.Acres", values["Acres"], number: true);
        }

        private static Task SelectListedLocationAsync(
            SFP_NativeFormPage form, string logicalName, string location) =>
            SelectListedItemAsync(form, logicalName, location);

        private static Task SelectListedItemAsync(
            SFP_NativeFormPage form, string logicalName, string value) =>
            form.SelectAsync(form.Field(logicalName), ListedItemCaption(value));

        private static async Task VerifyListedItemAsync(
            SFP_NativeFormPage form, string logicalName, string value)
        {
            var control = form.Field(logicalName);
            await Expect(control).ToHaveCountAsync(1);
            await Expect(control).ToBeVisibleAsync();
            var displayed = control.Locator(".mat-select-value-text, .mat-mdc-select-value-text");
            await Expect(await displayed.CountAsync() == 0 ? control : displayed)
                .ToHaveTextAsync(ListedItemCaption(value));
        }

        private static Regex ListedItemCaption(string value) =>
            new(@"^\s*" + Regex.Escape(value.Trim()).Replace(@"\ ", @"\s+")
                + @"(?:\s+-\s+.*)?\s*$", RegexOptions.IgnoreCase);

        private async Task EditRetailAsync(IReadOnlyDictionary<string, string> values)
        {
            var form = new SFP_NativeFormPage(_page);
            await form.SelectNamedCatalogCoverageAsync(
                Catalog,
                new Regex(
                    @"^\s*Retail Sales and Farm Stands,\s*Product Sales\s*$",
                    RegexOptions.IgnoreCase));
            await form.ClickActionAsync("AddEditRetailSales");
            var onPremises = values["CoverageName"] == "Retail Sales On Premises";
            var entity = onPremises ? "CovRetailSalesOnPremises" : "CovRetailSalesOffPremises";
            var selector = onPremises ? "RetailSalesOnPremise" : "RetailSalesOffPremise";
            var total = onPremises ? "TotalSalesOnPremise" : "TotalSalesOffPremise";
            await VerifyRetailSelectorAsync(form, onPremises);
            await form.CheckAsync("RetailSaleOfGoodsInput." + selector);
            await form.SetAsync(entity + "Input." + total, values["TotalSales"], number: true);
            if (onPremises)
            {
                var section = await form.SectionAsync(entity + "Input." + total);
                await form.SelectAsync(
                    form.SectionField(section, "SalesLocationInput.Location"),
                    ListedItemCaption(values["Location"]));
            }
            await form.SetAsync(entity + "Input.OthersGoods", values["ProducedByOthers"]);
            await form.SetAsync(entity + "Input.Description", values["Description"]);
            await form.SetAsync(entity + "Input.PercentOfTotalSalesOthersGoods", values["Percent"], number: true);
            await form.ClickActionAsync("Save");
            await form.ContinueReviewAndRequireReadyAsync(Catalog);

            _retailExpected[values["CoverageName"]] = values;
            await form.ClickActionAsync("AddEditRetailSales");
            foreach (var expected in _retailExpected.Values)
                await VerifyRetailAsync(form, expected);
            await form.ClickActionAsync("Save");
            await form.ContinueReviewAndRequireReadyAsync(Catalog);
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
            var section = await form.SectionAsync(entity + "Input." + totalField);
            if (onPremises)
            {
                var location = form.SectionField(section, "SalesLocationInput.Location");
                await Expect(location).ToHaveCountAsync(1);
                await Expect(location).ToBeVisibleAsync();
                var displayed = location.Locator(".mat-select-value-text, .mat-mdc-select-value-text");
                await Expect(await displayed.CountAsync() == 0 ? location : displayed)
                    .ToHaveTextAsync(ListedItemCaption(values["Location"]));
            }
            var total = decimal.Parse(values["TotalSales"], CultureInfo.InvariantCulture);
            var others = SfpRequiredTable.YesNo(values["ProducedByOthers"])
                ? total * decimal.Parse(values["Percent"], CultureInfo.InvariantCulture) / 100
                : 0;
            await form.VerifySectionAsync(
                section,
                entity + "Output.TotalSalesOthersGoods",
                others.ToString(CultureInfo.InvariantCulture),
                number: true,
                readOnlyCaption: "Revenue Generated from Goods produced by Others");
        }

        private static Task VerifyRetailSelectorAsync(SFP_NativeFormPage form, bool onPremises) =>
            Expect(form.CheckboxLabel("RetailSaleOfGoodsInput." +
                (onPremises ? "RetailSalesOnPremise" : "RetailSalesOffPremise")))
                .ToHaveTextAsync(new Regex(onPremises
                    ? @"^\s*On-Premises\s*\(171-10020\)\s*$"
                    : @"^\s*Off-Premises\s*\(171-10030\)\s*$"));
    }
}
