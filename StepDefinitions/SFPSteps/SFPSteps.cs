using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using NUnit.Framework;
using Playwright_POC.Configuration;
using Playwright_POC.Context;
using Playwright_POC.Helpers;
using Playwright_POC.Pages;
using Playwright_POC.Pages.ExpertQuotePages;
using Playwright_POC.Pages.ExpertQuotePages.SFP;
using Reqnroll;
using System;
using System.Threading.Tasks;
using ReqContext = Playwright_POC.Context.TestContext;

namespace Playwright_POC.StepDefinitions.SFPSteps
{
    /// <summary>
    /// Core SFP Steps - Quote Details, Policy Details, SSN Handling
    /// </summary>
    [Binding]
    public class SFPSteps
    {
        private readonly ReqContext _context;
        private readonly ScenarioContextData _contextData;
        private readonly CredentialsConfig _credentials;
        private readonly IConfiguration _configuration;
        private readonly ScenarioContext _scenarioContext;

        public SFPSteps(ReqContext context, ScenarioContext scenarioContext, CredentialsConfig credentials, IConfiguration configuration)
        {
            _context = context;
            _scenarioContext = scenarioContext;
            _contextData = _scenarioContext["ContextData"] as ScenarioContextData;
            _credentials = credentials;
            _configuration = configuration;
        }

        [When("user selects Special Farm Package and inputs Quote Details")]
        public async Task SelectSpecialFarmPackageAndInputQuoteDetails(Table table)
        {
            TableMappingHelpers.SFPQuoteDetailsFields(table, _contextData);
            var proposalDetailsPage = new QuoteDetailsPage(_context.Page);
            await proposalDetailsPage.WaitForProposalPageLoadAsync();
            await proposalDetailsPage.SelectSpecialFarmPackageProductAsync();
            await proposalDetailsPage.EnterSFPQuoteDetailsAsync(_contextData);
            await proposalDetailsPage.SelectRatingStateAsync(_contextData);
            await proposalDetailsPage.SelectRiskAddressAsync(_contextData);
            await proposalDetailsPage.ClickStartQuoteAsync();
            await proposalDetailsPage.HandleClientExistsPopupAsync();
            Console.WriteLine($"Client {_contextData.ClientFirstName}");
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
            try
            {
                // Try to get quote number from URL (e.g., /quote/123456)
                var url = _context.Page.Url;
                var match = System.Text.RegularExpressions.Regex.Match(url, @"/quote/(\d+)");
                if (match.Success)
                {
                    _contextData.QuoteNumber = match.Groups[1].Value;
                }
                else
                {
                    // Try tab label
                    var tabLabel = _context.Page.Locator("div[class*='mat-tab-label-container'] span");
                    if (await tabLabel.CountAsync() > 0)
                    {
                        var text = await tabLabel.First.InnerTextAsync();
                        var lines = text.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                        _contextData.QuoteNumber = lines.Length > 1 ? lines[1].Trim() : text.Trim();
                    }
                }
                
                if (!string.IsNullOrEmpty(_contextData.QuoteNumber))
                {
                    Console.WriteLine($"*** QUOTE NUMBER: {_contextData.QuoteNumber} ***");
                    System.IO.File.WriteAllText("QuoteNumber.txt", _contextData.QuoteNumber);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not capture quote number: {ex.Message}");
            }
        }

        [When("user enters SFP policy details and clicks Next button")]
        public async Task UserEntersSFPPolicyDetailsAndClicksNext(Table table)
        {
            TableMappingHelpers.SFPPolicyDataFields(table, _contextData);
            var sfpPolicyDetailsPage = new SFP_PolicyDetailsPage(_context.Page);
            await sfpPolicyDetailsPage.SelectPrimaryFarmCategoryAsync(_contextData.PrimaryFarmType);
            await sfpPolicyDetailsPage.SelectPrimaryFarmSubTypeAsync(_contextData.LivestockType);

            if (!string.IsNullOrEmpty(_contextData.SecondaryFarmType))
            {
                await sfpPolicyDetailsPage.SetSecondaryFarmTypeAsync(true);
                await sfpPolicyDetailsPage.SelectSecondaryFarmCategoryAsync(_contextData.SecondaryFarmType);
                if (!string.IsNullOrEmpty(_contextData.SecondaryFarmSubType))
                    await sfpPolicyDetailsPage.SelectSecondaryFarmSubTypeAsync(_contextData.SecondaryFarmSubType);
            }

            await sfpPolicyDetailsPage.EnterGrossFarmIncomeAsync(_contextData.GrossFarmIncome);
            await sfpPolicyDetailsPage.SelectGrowIndustrialHempAsync(_contextData.GrowIndustrialHemp);
            await sfpPolicyDetailsPage.ClickNextAsync();
            Console.WriteLine($"Client {_contextData.ClientFirstName}");
        }
    }
}
