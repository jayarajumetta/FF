using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using NUnit.Framework;
using PnCTestAutomation.Configuration;
using PnCTestAutomation.Context;
using PnCTestAutomation.Helpers;
using PnCTestAutomation.Pages;
using PnCTestAutomation.Pages.ExpertQuotePages;
using PnCTestAutomation.Pages.ExpertQuotePages.SFP;
using Reqnroll;
using System;
using System.Threading.Tasks;

namespace PnCTestAutomation.StepDefinitions.SFPSteps
{
    /// <summary>
    /// Steps for SFP Primary Insured, UW Questions, Client Details, and Narrative
    /// </summary>
    [Binding]
    public class SFP_InsuredSteps
    {
        private readonly PlaywrightContext _context;
        private readonly ScenarioContextData _contextData;
        private readonly ScenarioContext _scenarioContext;

        public SFP_InsuredSteps(PlaywrightContext context, ScenarioContext scenarioContext)
        {
            _context = context;
            _scenarioContext = scenarioContext;
            _contextData = _scenarioContext[ScenarioContextData.ContextKey] as ScenarioContextData
                ?? throw new InvalidOperationException("ScenarioContextData not found. Ensure TestHooks.BeforeTestRun registered it.");
        }

        [When("user Validates Primary Insured Information for SFP and continues")]
        public async Task UserValidatesPrimaryInsuredInformationForSFPAndContinues()
        {
            await ValidatePrimaryInsuredCoreAsync();
        }

        [When("user refills cleared phone and email fields on Primary Insured page")]
        public async Task UserRefillsClearedPhoneAndEmailFields()
        {
            var primaryInsuredPage = new SFP_PrimaryInsuredPage(_context.Page);
            await primaryInsuredPage.RefillClearedPhoneAndEmailAsync(_contextData);
        }

        private async Task ValidatePrimaryInsuredCoreAsync()
        {
            var primaryInsuredPage = new SFP_PrimaryInsuredPage(_context.Page);
            await primaryInsuredPage.ValidatePrimaryInsuredDetailsAsync(_contextData);
            await primaryInsuredPage.WaitForSpinnerAsync();
            await primaryInsuredPage.ClickSaveAsync();
        }

        [When("user answers UW Questions and continues")]
        public async Task UserAnswersUWQuestionsAndContinues(Table table)
        {
            var states = TableMappingHelpers.MapYesNoTableToBool(table);
            var primaryInsuredPage = new SFP_PrimaryInsuredPage(_context.Page);
            await primaryInsuredPage.AnswerUwQuestionsAsync(states, clickNext: true);
        }

        [When("user enters Claims and Prior Insurance Information and continues")]
        public async Task UserEntersClaimsAndPriorInsuranceInformationAndContinues(Table table)
        {
            // CE/re-open flows can land on a different page; force the expected page before interacting.
            var exposuresChip = _context.Page.GetByTestId("fields.data.policy.policyInput$exposuresInsuredAN90Days.value-chip-item-wrapper");
            if (await exposuresChip.CountAsync() == 0)
            {
                var sideMenu = new SideMenuNavigation(_context.Page);
                await sideMenu.GoToByNameAsync("claims and prior insurance");
            }

            var claimsPriorInsurancePage = new ClaimsPriorInsurancePage(_context.Page);
            TableMappingHelpers.ClaimsAndPriorInsuranceFields(table, _contextData);

            // Tosca: Prior FFAN Policy (Exposures Insured AN 90 Days)
            await claimsPriorInsurancePage.SetExposuresInsuredAN90DaysAsync(_contextData.PriorFFANPolicy);

            // Tosca: Years In Business
            await claimsPriorInsurancePage.EnterYearsInBusinessAsync(_contextData.YearsInBusiness);

            // Tosca: Years Continuous Coverage (No Prior, 1 Year, 2 Years, 3+ Years)
            if (!string.IsNullOrEmpty(_contextData.YearsContinuousCoverage))
            {
                await claimsPriorInsurancePage.SelectYearsOfContinuousCoverageAsync(_contextData.YearsContinuousCoverage);
            }

            // Tosca: Prior Insurance Carrier
            if (!string.IsNullOrEmpty(_contextData.PriorInsuranceCarrier))
            {
                await claimsPriorInsurancePage.EnterPriorInsuranceCarrierAsync(_contextData.PriorInsuranceCarrier);
            }

            await claimsPriorInsurancePage.ClickNextAsync();
        }

        [When("user validates Client Details and continues")]
        public async Task UserValidatesClientDetailsAndContinues()
        {
            var clientDetailsPage = new SFP_ClientDetailsPage(_context.Page);
            await clientDetailsPage.WaitForSpinnerAsync();
            await clientDetailsPage.ClickNextAsync();
        }

        [When("user validates Client Details and selects contact role")]
        public async Task UserValidatesClientDetailsAndSelectsContactRole(Table table)
        {
            var clientDetailsPage = new SFP_ClientDetailsPage(_context.Page);
            await clientDetailsPage.WaitForSpinnerAsync();

            foreach (var row in table.Rows)
            {
                var contactRole = row["Answer"];
                await clientDetailsPage.SelectContactRoleAsync(contactRole);
            }

            await clientDetailsPage.ClickNextAsync();
        }

        [When("user validates Client Details and selects Inspection Contact")]
        public async Task UserValidatesClientDetailsAndSelectsInspectionContact()
        {
            var clientDetailsPage = new SFP_ClientDetailsPage(_context.Page);
            await clientDetailsPage.WaitForSpinnerAsync();
            await clientDetailsPage.SelectContactRoleAsync("Inspection Contact");
            await clientDetailsPage.ClickNextAsync();
        }

        [When("user Adds Narrative and continues")]
        public async Task UserAddsNarrativeAndContinues(Table table)
        {
            var narrativePage = new NarrativePage(_context.Page);
            await narrativePage.WaitForSpinnerAsync();
            TableMappingHelpers.NarrativeFields(table, _contextData);

            // Check if we're on the narrative page (button exists)
            if (!await narrativePage.IsOnNarrativePageAsync())
            {
                var sideMenu = new SideMenuNavigation(_context.Page);
                await sideMenu.GoToByNameAsync("narrative");
                await narrativePage.WaitForSpinnerAsync();
            }

            if (await narrativePage.IsOnNarrativePageAsync())
            {
                await narrativePage.ClickAddNarrativeButtonAsync();
                await narrativePage.EnterNarrativeAndClickSaveAsync(_contextData.Narrative);
            }
            else
            {
                throw new InvalidOperationException("Narrative page could not be reached or Add Narrative button is unavailable.");
            }

            await narrativePage.ClickNextAsync();
        }
    }
}
