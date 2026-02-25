using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using NUnit.Framework;
using Playwright_POC.Configuration;
using Playwright_POC.Context;
using Playwright_POC.Helpers;
using Playwright_POC.Pages;
using Playwright_POC.Pages.ExpertQuotePages;
using Reqnroll;
using System;
using System.Threading.Tasks;
using ReqContext = Playwright_POC.Context.TestContext;

namespace Playwright_POC.StepDefinitions.SFPSteps
{
    /// <summary>
    /// Steps for SFP Primary Insured, UW Questions, Client Details, and Narrative
    /// </summary>
    [Binding]
    public class SFP_InsuredSteps
    {
        private readonly ReqContext _context;
        private readonly ScenarioContextData _contextData;
        private readonly ScenarioContext _scenarioContext;

        public SFP_InsuredSteps(ReqContext context, ScenarioContext scenarioContext)
        {
            _context = context;
            _scenarioContext = scenarioContext;
            _contextData = _scenarioContext["ContextData"] as ScenarioContextData;
        }

        [When("user Validates Primary Insured Information for SFP and continues")]
        public async Task UserValidatesPrimaryInsuredInformationForSFPAndContinues()
        {
            var primaryInsuredPage = new PrimaryInsuredPage(_context.Page);
            await primaryInsuredPage.ValidatePrimaryInsuredDetailsAsync(_contextData);
            await primaryInsuredPage.WaitForSpinnerAsync();
            await primaryInsuredPage.ClickSaveAsync();
        }

        [When("user answers UW Questions and continues")]
        public async Task UserAnswersUWQuestionsAndContinues(Table table)
        {
            var states = TableMappingHelpers.MapYesNoTableToBool(table);
            var primaryInsuredPage = new PrimaryInsuredPage(_context.Page);
            await primaryInsuredPage.AnswerUwQuestionsAsync(states, clickNext: true);
        }

        [When("user enters Claims and Prior Insurance Information and continues")]
        public async Task UserEntersClaimsAndPriorInsuranceInformationAndContinues(Table table)
        {
            var claimsPriorInsurancePage = new ClaimsPriorInsurancePage(_context.Page);
            TableMappingHelpers.ClaimsAndPriorInsuranceFields(table, _contextData);
            await claimsPriorInsurancePage.SetExposuresInsuredAN90DaysAsync(_contextData.PriorFFANPolicy);
            await claimsPriorInsurancePage.EnterYearsInBusinessAsync(_contextData.YearsInBusiness);
            await claimsPriorInsurancePage.ClickNextAsync();
        }

        [When("user validates Client Details and continues")]
        public async Task UserValidatesClientDetailsAndContinues()
        {
            var clientDetailsPage = new SFP_ClientDetailsPage(_context.Page);
            await clientDetailsPage.VerifyClientNameAsync(_contextData.ClientFirstName, _contextData.ClientLastName);
            await clientDetailsPage.VerifyClientStreetAddressAsync(_contextData.StreetAddress);
            await clientDetailsPage.ClickNextAsync();
        }

        [When("user validates Client Details and selects Inspection Contact")]
        public async Task UserValidatesClientDetailsAndSelectsInspectionContact()
        {
            var clientDetailsPage = new SFP_ClientDetailsPage(_context.Page);
            await clientDetailsPage.VerifyClientNameAsync(_contextData.ClientFirstName, _contextData.ClientLastName);
            await clientDetailsPage.CheckInspectionContactAsync();
            await clientDetailsPage.ClickNextAsync();
        }

        [When("user Adds Narrative and continues")]
        public async Task UserAddsNarrativeAndContinues(Table table)
        {
            var narrativePage = new NarrativePage(_context.Page);
            TableMappingHelpers.NarrativeFields(table, _contextData);
            await narrativePage.ClickAddNarrativeButtonAsync();
            await narrativePage.EnterNarrativeAndClickSaveAsync(_contextData.Narrative);
            await narrativePage.ClickNextAsync();
        }
    }
}
