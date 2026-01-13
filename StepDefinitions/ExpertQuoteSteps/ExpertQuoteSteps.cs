using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using NUnit.Framework;
using Playwright_POC.Configuration;
using Playwright_POC.Context;
using Playwright_POC.Helpers;
using Playwright_POC.Locators;
using Playwright_POC.Pages;
using Playwright_POC.Pages.ExpertQuotePages;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using TestAutomation.Pages.ExpertQuotePages;
using ReqContext = Playwright_POC.Context.TestContext;



[Binding]
public class ExpertQuoteSteps
{
    private readonly ReqContext _context;
    private readonly ScenarioContextData _contextData;
    private readonly CredentialsConfig _credentials;
    private readonly IConfiguration _configuration;
    private Table _table;


    public ExpertQuoteSteps(ReqContext context, ScenarioContextData contextData, CredentialsConfig credentials, IConfiguration configuration)
    {
        _context = context;
        _contextData = contextData;
        _credentials = credentials;
        _configuration = configuration;

    }




[When("I enter valid credentials and Click LogIn")]
public async Task WhenIEnterValidCredentials()
{
    string username = _credentials.Username;
    string password = _credentials.Password;

    var loginPage = new ExpertQuoteLoginPage(_context.Page);
    await loginPage.LoginAsync(username, password);

        // Wait for login to complete and assert dashboard is visible
        Assert.That(await loginPage.IsDashboardVisibleAsync(), Is.True);
}



    [Then("user enters a name in the search field and clicks search")]
    public async Task ThenUserEntersANameInTheSearchField(Table table)
    {
        TableMappingHelpers.ClientSearchFields(table, _contextData);

        string name = $"{_contextData.ClientFirstName} {_contextData.ClientLastName}";
        var clientSearchPage = new ClientSearchPage(_context.Page);

        await clientSearchPage.EnterNameAndSearchAsync(name);

        string clientName = $"{_contextData.ClientLastName}, {_contextData.ClientFirstName}";
        string tableSelector = "table";

        // Uncomment if you want to use the assertion
        // await clientSearchPage.AssertNameNotInTableAsync(tableSelector, clientName);
    }

    [Then("user enters a Random Name in the search field and clicks search")]

    public async Task ThenUserEntersARandomNameInTheSearchField(Table table)
    {
        // Keep current mapping to _contextData
        TableMappingHelpers.ClientSearchFields(table, _contextData);

        // Replace tokens with generated values
        // Supports: {{male}}, {{female}} for first names; {{random}} for last names
        if (string.Equals(_contextData.ClientFirstName, "{{male}}", StringComparison.OrdinalIgnoreCase))
            _contextData.ClientFirstName = RandomGenerators.GenerateRandomFirstName();

        if (string.Equals(_contextData.ClientFirstName, "{{female}}", StringComparison.OrdinalIgnoreCase))
            _contextData.ClientFirstName = RandomGenerators.GenerateRandomFemaleFirstName();

        if (string.Equals(_contextData.ClientLastName, "{{random}}", StringComparison.OrdinalIgnoreCase))
            _contextData.ClientLastName = RandomGenerators.GenerateRandomLastName();

        // Build full name and perform the search
        string name = $"{_contextData.ClientFirstName} {_contextData.ClientLastName}";
        var clientSearchPage = new ClientSearchPage(_context.Page);

        await clientSearchPage.EnterNameAndSearchAsync(name);

        // Keep follow-on format for assertions
        string clientName = $"{_contextData.ClientLastName}, {_contextData.ClientFirstName}";


    }


    [Then("user clicks New Quote button")]
    public async Task ThenUserClicksNewQuoteButton()
    {
        await _context.Page.ClickAsync(ClientSearchLocators.NewQuoteButton);
    }



    [Then("user enters client information and clicks search")]
    public async Task AndUserEntersClientInformationAndClicksSearch(Table table)
    {
        TableMappingHelpers.NewExistingClientFields(table, _contextData);

        var newClientPage = new NewClientPage(_context.Page);

        await newClientPage.WaitForFirstNameInputAsync();
        await newClientPage.FillFirstNameAsync(_contextData.ClientFirstName);
        await newClientPage.FillLastNameAsync(_contextData.ClientLastName);
        await newClientPage.FillDOBAsync(_contextData.ClientDOB);
        await newClientPage.FillBestPhoneAsync(_contextData.ClientPhoneNumber);
        await newClientPage.FillEmailAsync(_contextData.ClientEmail);
        await newClientPage.ClickSearchAsync();
        await newClientPage.WaitForNextButtonAsync();
    }


    [Then("user selects Create New Client and clicks the Next button")]
    public async Task UserCreatesNewClientAndClicksNext()
    {
        await _context.Page.ClickAsync(NewExistingClientSearchLocators.CreateNewClientButton);
        await _context.Page.ClickAsync(GlobalLocators.NextButton);

        //Wait for the next page to load
        await _context.Page.WaitForLoadStateAsync(LoadState.Load);
        await _context.Page.WaitForSelectorAsync(AccountInformationConstLocators.PageHeader, new() { Timeout = 10000 });
    }


    [Then("user enters account owner information and clicks Next")]
    public async Task EnterAccountOwnerInfo(Table table)
    {
        TableMappingHelpers.AccountOwnerFields(table, _contextData);

        var accountInformationPage = new AccountOwnerInfoPage(_context.Page);

        // Modular, explicit calls for each logical segment:
        await accountInformationPage.WaitForPageReadyAsync();
        await accountInformationPage.ValidateAndFillNameFieldsAsync(_contextData);
        await accountInformationPage.ValidateAndFillContactFieldsAsync(_contextData);
        await accountInformationPage.SelectMaritalStatusAsync(_contextData.MaritalStatus);
        await accountInformationPage.FillAddressFieldsAsync(_contextData);
        await accountInformationPage.WaitForAddressDetailsAsync();
        await accountInformationPage.AnswerMailAndResidenceQuestionsAsync(_contextData);
        await accountInformationPage.ClickNextAsync();
    }



    [Then("user selects Personal Auto and inputs Quote Details")]
    public async Task SelectPersonalAutoAndInputQuoteDetails(Table table)
    {
        TableMappingHelpers.PAQuoteDetailsFields(table, _contextData);

        var proposalDetailsPage = new QuoteDetailsPage(_context.Page);

        await proposalDetailsPage.WaitForProposalPageLoadAsync();
        await proposalDetailsPage.SelectPersonalAutoProductAsync();
        await proposalDetailsPage.EnterQuoteDetailsAsync(_contextData);
        await proposalDetailsPage.SelectRatingStateAndCompanyAsync(_contextData);
        await proposalDetailsPage.SelectRiskAddressAsync(_contextData);
        await proposalDetailsPage.ClickStartQuoteAsync();
        await proposalDetailsPage.HandleSSNPopupsAsync(_contextData);
        await proposalDetailsPage.HandleClientExistsPopupAsync();
    }

    [Then("user selects Business Owners and inputs Quote Details")]
    public async Task SelectBusinessOwnersAndInputQuoteDetails(Table table)
    {
        TableMappingHelpers.BOPQuoteDetailsFields(table, _contextData);

        var proposalDetailsPage = new QuoteDetailsPage(_context.Page);

        await proposalDetailsPage.WaitForProposalPageLoadAsync();
        await proposalDetailsPage.SelectBusinessOwnerProductAsync();
        await proposalDetailsPage.EnterQuoteDetailsAsync(_contextData);
        await proposalDetailsPage.SelectBusinessEntityAsync(_contextData);
        await proposalDetailsPage.SelectLessorsRiskExposureAsync(_contextData);
        await proposalDetailsPage.SelectRatingStateAsync(_contextData);
        await proposalDetailsPage.SelectRiskAddressAsync(_contextData);
        await proposalDetailsPage.ClickStartQuoteAsync();
        await proposalDetailsPage.HandleSSNPopupsAsync(_contextData);
        await proposalDetailsPage.HandleClientExistsPopupAsync();
    }

    [Then("user selects Special Farm Package and inputs Quote Details")]
    public async Task SelectSpecialFarmPackageAndInputQuoteDetails(Table table)
    {
        TableMappingHelpers.BOPQuoteDetailsFields(table, _contextData);
        var proposalDetailsPage = new QuoteDetailsPage(_context.Page);
        await proposalDetailsPage.WaitForProposalPageLoadAsync();
        await proposalDetailsPage.SelectSpecialFarmPackageProductAsync();
        await proposalDetailsPage.CheckSpecialFarmPackageSelected();
        await proposalDetailsPage.EnterSFPQuoteDetailsAsync(_contextData);
        await proposalDetailsPage.SelectRatingStateAsync(_contextData);
        await proposalDetailsPage.SelectRiskAddressAsync(_contextData);
        await proposalDetailsPage.ClickStartQuoteAsync();
        await proposalDetailsPage.HandleSSNPopupsAsync(_contextData);
        await proposalDetailsPage.HandleClientExistsPopupAsync();
    }

    [Then("user enters SFP policy details and clicks Next button")]
    public async Task UserEntersSFPPolicyDetailsAndClicksNext(Table table)
    {
        TableMappingHelpers.SFPPolicyDataFields(table, _contextData);
        var sfpPolicyDetailsPage = new PolicyDetailsPage(_context.Page);
        await sfpPolicyDetailsPage.SelectPrimaryFarmType(_contextData.PrimaryFarmType);
        await sfpPolicyDetailsPage.SelectLivestockType(_contextData.LivestockType);
        await sfpPolicyDetailsPage.EnterGrossFarmIncome(_contextData.GrossFarmIncome);
        await sfpPolicyDetailsPage.SelectGrowIndustrialHemp(_contextData.GrowIndustrialHemp);
        await _context.Page.ClickAsync(GlobalLocators.NextButton);


    }

    [Then("user selects class codes and continues")]
    public async Task UserSelectesClassCodesAndContinues(Table table)
    {
        TableMappingHelpers.BOPPreQualificationFields(table, _contextData);

        var preQualificationPage = new PreQualificationPage(_context.Page);

        await preQualificationPage.SearchAddClassCodeAsync(_contextData);
        await preQualificationPage.TogglePrimaryOccupancySliderAsync();
        await preQualificationPage.SelectIndustryClassCodeRestrictionsAsync(_contextData);
        await _context.Page.ClickAsync(GlobalLocators.NextButton);
    }


    [Then("user enters Pre-Qualification information and continues")]
    public async Task WhenUserEntersPreQualificationInfoAndContinuesAsync(Table table)
    {
        TableMappingHelpers.PreQualificationFields(table, _contextData);

        var preQualificationPage = new PreQualificationPage(_context.Page);
        await preQualificationPage.EnterPreQualificationInfoAndContinueAsync(_contextData.EligibilityRestrictions);
    }


    [Then("user selects existing Driver")]
    public async Task UserSelectsExistingDriverAsync()
    {
        await _context.Page.ClickAsync(DriverSelectionPageLocators.ExistingClientButton);

        // Click Next to Proceed
        await _context.Page.ClickAsync(GlobalLocators.NextButton);
    }



    [Then("user enters Driver information and continues")]
    public async Task WhenUserEntersDriverInfoAndContinuesAsync(Table table)
    {
        TableMappingHelpers.DriverInfoFields(table, _contextData);

        var addDriverInfoPage = new AddDriverInfoPage(_context.Page);

        await addDriverInfoPage.PreparePriorInsuranceReasonAsync(_contextData);
        await addDriverInfoPage.CollectAndStoreQuoteNumberAsync(_contextData);
        await addDriverInfoPage.WaitForPageLoadAsync();
        await addDriverInfoPage.ValidateDriverFieldsAsync(_contextData);
        await addDriverInfoPage.SelectDriverOptionsAsync(_contextData);
        await addDriverInfoPage.FillDriverLicenseFieldsAsync(_contextData);
        await addDriverInfoPage.SelectInsuranceOptionsAsync(_contextData);
        await addDriverInfoPage.HandlePriorInsuranceAsync(_contextData);
        await addDriverInfoPage.SaveAndContinueAsync();
        await addDriverInfoPage.HandleMVRPopUpAsync();
    }



    [Then("user enters vehicle information and continues")]
    public async Task WhenUserEntersVehicleInfoAndContinuesAsync(Table table)
    {
        TableMappingHelpers.MapVehicleFields(table, _contextData);

        var addVehicleInfoPage = new AddVehicleInfoPage(_context.Page);

        await addVehicleInfoPage.WaitForVehiclePageReadyAsync();
        await addVehicleInfoPage.SelectUnlistedVehicleIfVisibleAsync();
        await addVehicleInfoPage.EnterVINAndSelectVehicleAsync(_contextData);
        await addVehicleInfoPage.SelectVehicleTypeAsync(_contextData.VehicleType);
        await addVehicleInfoPage.ValidateVehicleDetailsAsync(_contextData);
        await addVehicleInfoPage.SelectVehicleOptionsAsync(_contextData);
        await addVehicleInfoPage.FillPurchaseAndMileageFieldsAsync(_contextData);
        await addVehicleInfoPage.SaveAndContinueVehicleAsync();
    }


    [Then("user assigns a vehicle to the driver")]
    public async Task WhenUserAssignsDriverAndVehicleAsync(Table table)
    {
        TableMappingHelpers.VehicleAssignmentFields(table, _contextData);

        var addVehicleInfoPage = new AddVehicleInfoPage(_context.Page);
        await addVehicleInfoPage.AssignVehicleToDriverAsync(_contextData.Vehicle, _contextData.DriverStatus);
    }



    [Then("user verifies there are no claims or violations")]
    public async Task UserVerifiesNoClaimsOrViolationsAsync()
    {
        var claimsAndViolationsPage = new ClaimsViolationsPage(_context.Page);
        await claimsAndViolationsPage.VerifyNoClaimsOrViolationsAndContinueAsync();
    }



    [Then("user selects discounts and clicks Next")]
    public async Task UserSelectsDiscountsAsync()
    {
        var discountsPage = new DiscountsPage(_context.Page);
        await discountsPage.ClickNextAsync();
    }



    [Then("user selects Policy Coverages")]
    public async Task UserSelectsCoveragesAsync(Table table)
    {
        TableMappingHelpers.PolicyCoverageFields(table, _contextData);

        var policyCoveragesPage = new PolicyCoveragesPage(_context.Page);

        await policyCoveragesPage.SelectPolicyCoverageAsync(_contextData.PolicyCoverage);
        await policyCoveragesPage.SelectCompCollOnlyAsync(_contextData.CompCollOnly);
        await policyCoveragesPage.SelectCompDeductibleAsync(_contextData.CompDeductible);
        await policyCoveragesPage.SelectCollDeductibleAsync(_contextData.CollDeductible);
        await policyCoveragesPage.ClickNextAsync();
    }





    [Then("user selects Additional Coverages")]
    public async Task UserSelectsAdditionalCoveragesAsync(Table table)
    {
        TableMappingHelpers.AdditionalCoverageFields(table, _contextData);

        var additionalCoveragesPage = new AdditionalCoveragesPage(_context.Page);
        string name = $"{_contextData.ClientFirstName} {_contextData.ClientLastName}";

        await additionalCoveragesPage.SelectAccidentalDeathAndDismembermentAsync(_contextData.AccidentalDeathAndDismemberment);
        await additionalCoveragesPage.WaitForCoverageOptionsLoadAsync();
        await additionalCoveragesPage.SelectADDDriverAsync(name);
        await additionalCoveragesPage.SelectLossOfIncomeAsync(name);
        await additionalCoveragesPage.SelectRentalReimbursementAsync(_contextData.RentalReimbursement);
        await additionalCoveragesPage.SelectRoadsideAssistanceAsync(_contextData.RoadsideAssistance);
        await additionalCoveragesPage.ClickNextAsync();
    }



    [Then("user verifies Pricing Details")]
    public async Task UserVerifiesPricingDetailsAsync()
    {
        var pricingDetailsPage = new PricingDetailsPage(_context.Page);
        string name = $"{_contextData.ClientFirstName} {_contextData.ClientLastName}";

        var accountOwner = await pricingDetailsPage.GetAccountOwnerAsync();
        pricingDetailsPage.AssertAccountOwner(accountOwner, name);

        var accountAddress = await pricingDetailsPage.GetAccountAddressAsync();
        pricingDetailsPage.AssertAccountAddress(accountAddress, _contextData.RiskAddress);

        // More verifications can be added here

        await pricingDetailsPage.ClickNextAsync();
    }



    [Then("user verifies eligibility and clicks Next")]
    public async Task UserVerifiesEligibilityAsync()
    {
        // Add any questions that may populate

        await _context.Page.ClickAsync(GlobalLocators.NextButton);
    }


    [Then("user adds an Additional Interest")]
    public async Task UserAddsAdditionalInterestAsync(Table table)
    {
        TableMappingHelpers.AdditionalInterestFields(table, _contextData);

        var addAdditionalInterestPage = new AddAdditionalInterestPage(_context.Page);

        await addAdditionalInterestPage.ClickAddAdditionalInterestAsync();
        await addAdditionalInterestPage.SelectAdditionalInterestTypeAsync(_contextData.AdditionalInterestType);

        if (_contextData.AdditionalInterestType == "Joint Owner")
            await addAdditionalInterestPage.HandleJointOwnerFieldsAsync(_contextData);

        await addAdditionalInterestPage.FillAdditionalInterestFieldsAsync(_contextData);
        await addAdditionalInterestPage.SaveAndContinueAsync();
        await addAdditionalInterestPage.HandleUWDialogIfPresentAsync();
        await addAdditionalInterestPage.ClickNextAsync();
    }



    [Then("user creates a new Billing Account and Submits payment")]
    public async Task UserCreatesBillingAccountAndSubmitsPaymentAsync(Table table)
    {
        TableMappingHelpers.BillingAccountFields(table, _contextData);

        var billingPage = new BillingPage(_context.Page);
        string name = $"{_contextData.ClientFirstName} {_contextData.ClientLastName}";

        await billingPage.ClickCreateNewBillingAccountAsync();
        await billingPage.SelectPrimaryPayerAsync(name);
        await billingPage.SelectPaymentTypeAsync(_contextData.PaymentType);
        await billingPage.WaitForPaymentPlanAsync(_contextData.PaymentPlan);
        await billingPage.SelectPaymentPlanAsync(_contextData.PaymentPlan);
        await billingPage.WaitForPaymentDueDateInputAsync();
        await billingPage.EnterPaymentDueDateAsync(_contextData.PaymentDueDate);
        await billingPage.SelectPaymentAmountAsync(_contextData.PaymentAmount);
        await billingPage.SelectPaymentMethodAsync(_contextData.PaymentMethod);
        await billingPage.EnterCheckNumberAsync(_contextData.CheckNumber);
        await billingPage.SelectPaperlessCommunicationAsync(_contextData.Paperless);
        await billingPage.ClickNextAsync();
        billingPage.DisplayQuoteNumber(_contextData.QuoteNumber);
        System.IO.File.WriteAllText("QuoteNumber.txt", _contextData.QuoteNumber ?? "");
    }

    [Then("user selects Primary Insured and continues")]
    public async Task UserSelectsPrimaryInsuredAsync()
    {
        var primaryInsuredPage = new PrimaryInsuredPage(_context.Page);
        await primaryInsuredPage.SelectExistingClientAsPrimaryInsuredAsync(_contextData);
    }
}
