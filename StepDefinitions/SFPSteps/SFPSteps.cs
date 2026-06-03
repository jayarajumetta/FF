using Microsoft.Playwright;
using NUnit.Framework;
using PnCTestAutomation.Context;
using PnCTestAutomation.Helpers;
using PnCTestAutomation.Pages;
using PnCTestAutomation.Pages.ExpertQuotePages;
using PnCTestAutomation.Pages.ExpertQuotePages.SFP;
using Reqnroll;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PnCTestAutomation.StepDefinitions.SFPSteps
{
    /// <summary>
    /// Core SFP Steps - Quote Details, Policy Details, SSN Handling
    /// </summary>
    [Binding]
    public class SFPSteps
    {
        private readonly PlaywrightContext _context;
        private readonly ScenarioContextData _contextData;
        private readonly ScenarioContext _scenarioContext;

        public SFPSteps(PlaywrightContext context, ScenarioContext scenarioContext)
        {
            _context = context;
            _scenarioContext = scenarioContext;
            _contextData = _scenarioContext["ContextData"] as ScenarioContextData
                ?? throw new InvalidOperationException("ScenarioContextData not found. Ensure TestHooks.BeforeTestRun registered it.");
        }

        [When("user selects Special Farm Package and inputs Quote Details")]
        public async Task SelectSpecialFarmPackageAndInputQuoteDetails(Table table)
        {
            var productSelection = GetProductSelection(table) ?? "SFP";
            _contextData.ProductSelection = productSelection;
            TableMappingHelpers.SFPQuoteDetailsFields(table, _contextData);
            var proposalDetailsPage = new QuoteDetailsPage(_context.Page);
            await proposalDetailsPage.WaitForProposalPageLoadAsync();
            await SelectInsuranceProductAsync(proposalDetailsPage, productSelection);
            await proposalDetailsPage.EnterSFPQuoteDetailsAsync(_contextData);
            await proposalDetailsPage.SelectRatingStateAsync(_contextData);
            await proposalDetailsPage.SelectRiskAddressAsync(_contextData);
            await proposalDetailsPage.ClickStartQuoteAsync();
            await proposalDetailsPage.HandleClientExistsPopupAsync();
            Console.WriteLine($"Client {_contextData.ClientFirstName}");
        }

        [When("user selects Country Estate and inputs Quote Details")]
        public async Task SelectCountryEstateAndInputQuoteDetails(Table table)
        {
            // Backward-compatible wrapper; CE can now also be selected via ProductSelection in the shared step table.
            await SelectSpecialFarmPackageAndInputQuoteDetails(table);
        }

        private static string GetProductSelection(Table table)
        {
            var row = table.Rows.FirstOrDefault(r =>
                string.Equals(r["Question"], "ProductSelection", StringComparison.OrdinalIgnoreCase));
            return row?["Answer"]?.Trim();
        }

        private static async Task SelectInsuranceProductAsync(QuoteDetailsPage proposalDetailsPage, string productSelection)
        {
            var normalized = (productSelection ?? string.Empty).Trim();

            if (normalized.Equals("CE", StringComparison.OrdinalIgnoreCase)
                || normalized.Equals("Country Estate", StringComparison.OrdinalIgnoreCase))
            {
                await proposalDetailsPage.SelectCountryEstateProductAsync();
                return;
            }

            if (normalized.Equals("SFP", StringComparison.OrdinalIgnoreCase)
                || normalized.Equals("Special Farm Package", StringComparison.OrdinalIgnoreCase)
                || string.IsNullOrEmpty(normalized))
            {
                await proposalDetailsPage.SelectSpecialFarmPackageProductAsync();
                return;
            }

            throw new ArgumentException($"Unsupported ProductSelection '{productSelection}'. Use SFP or CE.");
        }

        [When("user handles SSN popup and enters SSN")]
        public async Task UserHandlesSSNPopupAndEntersSSN(Table table)
        {
            TableMappingHelpers.SSNFields(table, _contextData);

            if (string.Equals(_contextData.SSN, "{{randomSSN}}", StringComparison.OrdinalIgnoreCase))
                _contextData.SSN = RandomGenerators.GenerateRandomSSN();

            var quoteDetailsPage = new QuoteDetailsPage(_context.Page);
            await quoteDetailsPage.HandleSSNPopupsAsync(_contextData);

            // Capture quote number from URL or tab
            await CaptureQuoteNumberAsync();
        }

        private async Task CaptureQuoteNumberAsync()
        {
            _contextData.QuoteNumber = await ExtractQuoteNumberFromPageAsync(_context.Page);
            if (!string.IsNullOrEmpty(_contextData.QuoteNumber))
                Console.WriteLine($"*** QUOTE NUMBER: {_contextData.QuoteNumber} ***");
            else
                Console.WriteLine("[CaptureQuoteNumber] Not found yet — will retry at Pricing.");
        }

        internal static async Task<string> ExtractQuoteNumberFromPageAsync(IPage page)
        {
            try
            {
                // Try the Angular Material tab header component (works regardless of MDC/legacy class names)
                foreach (var selector in new[] { "mat-tab-header", "[class*='tab-header']", "[class*='tab-label']" })
                {
                    var el = page.Locator(selector).First;
                    if (await el.CountAsync() > 0)
                    {
                        var text = await el.InnerTextAsync(new() { Timeout = 3000 });
                        var m = System.Text.RegularExpressions.Regex.Match(text, @"\b(\d{7,9})\b");
                        if (m.Success) return m.Groups[1].Value;
                    }
                }
                // Final fallback: scan body text
                var body = await page.Locator("body").InnerTextAsync(new() { Timeout = 3000 });
                var match = System.Text.RegularExpressions.Regex.Match(body, @"\b(0\d{7})\b");
                if (match.Success) return match.Groups[1].Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ExtractQuoteNumber] Error: {ex.Message}");
            }
            return null;
        }

        [When("user enters SFP policy details and clicks Next button")]
        public async Task UserEntersSFPPolicyDetailsAndClicksNext(Table table)
        {
            TableMappingHelpers.SFPPolicyDataFields(table, _contextData);
            var sfpPolicyDetailsPage = new SFP_PolicyDetailsPage(_context.Page);
            await sfpPolicyDetailsPage.EnsureOnPolicyDetailsPageAsync();
            await sfpPolicyDetailsPage.SelectPrimaryFarmCategoryAsync(_contextData.PrimaryFarmType);
            await sfpPolicyDetailsPage.SelectPrimaryFarmSubTypeAsync(_contextData.LivestockType);

            if (!string.IsNullOrEmpty(_contextData.SecondaryFarmType))
            {
                var toggled = await sfpPolicyDetailsPage.SetSecondaryFarmTypeAsync(true);
                if (toggled)
                {
                    var categorySelected = await sfpPolicyDetailsPage.SelectSecondaryFarmCategoryAsync(_contextData.SecondaryFarmType);
                    if (categorySelected && !string.IsNullOrEmpty(_contextData.SecondaryFarmSubType))
                        await sfpPolicyDetailsPage.SelectSecondaryFarmSubTypeAsync(_contextData.SecondaryFarmSubType);
                }
            }

            await sfpPolicyDetailsPage.EnterGrossFarmIncomeAsync(_contextData.GrossFarmIncome);
            await sfpPolicyDetailsPage.SelectGrowIndustrialHempAsync(_contextData.GrowIndustrialHemp);
            await sfpPolicyDetailsPage.ClickNextAsync();
            Console.WriteLine($"Client {_contextData.ClientFirstName}");
        }
    }
}
