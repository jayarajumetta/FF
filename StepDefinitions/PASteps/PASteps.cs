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
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using ReqContext = Playwright_POC.Context.TestContext;


[Binding]

public class PASteps
{

    private readonly ReqContext _context;
    private readonly ScenarioContextData _contextData;
    private readonly CredentialsConfig _credentials;
    private readonly IConfiguration _configuration;


    public PASteps(ReqContext context, ScenarioContextData contextData, CredentialsConfig credentials, IConfiguration configuration)
    {
        _context = context;
        _contextData = contextData;
        _credentials = credentials;
        _configuration = configuration;

    }
    [When("user selects Personal Auto and inputs Quote Details")]
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



    [When("user selects existing Driver")]
    public async Task UserSelectsExistingDriverAsync()
    {
        await _context.Page.GetByRole(AriaRole.Button, new() { Name = "Existing Client" }).ClickAsync();

        // Click Next to Proceed
        var addDriverInfoPage = new PA_AddDriverInfoPage(_context.Page);
        await addDriverInfoPage.ClickNextAsync();
    }



    [When("user enters Driver information and continues")]
    public async Task WhenUserEntersDriverInfoAndContinuesAsync(Table table)
    {
        TableMappingHelpers.DriverInfoFields(table, _contextData);

        var addDriverInfoPage = new PA_AddDriverInfoPage(_context.Page);

        await addDriverInfoPage.PreparePriorInsuranceReasonAsync(_contextData);
        await addDriverInfoPage.CollectAndStoreQuoteNumberAsync(_contextData);
        await addDriverInfoPage.WaitForPageLoadAsync();
        await addDriverInfoPage.SelectDriverOptionsAsync(_contextData);
        await addDriverInfoPage.FillDriverLicenseFieldsAsync(_contextData);
        await addDriverInfoPage.SelectInsuranceOptionsAsync(_contextData);
        await addDriverInfoPage.HandlePriorInsuranceAsync(_contextData);
        await addDriverInfoPage.SaveAndContinueAsync();
        await addDriverInfoPage.HandleMVRPopUpAsync();

        // Validate Driver fields - Uncomment and modify the following lines if validation is needed
        /*
        var driverFieldValues = await addDriverInfoPage.GetDriverFieldValuesAsync();
        Assert.AreEqual(_contextData.DriverFirstName, driverFieldValues.FirstName, "Driver first name does not match.");
        Assert.AreEqual(_contextData.DriverLastName, driverFieldValues.LastName, "Driver last name does not match.");
        */
    }


    [When("user enters vehicle information and continues")]
    public async Task WhenUserEntersVehicleInfoAndContinuesAsync(Table table)
    {
        TableMappingHelpers.MapVehicleFields(table, _contextData);

        var addVehicleInfoPage = new PA_AddVehicleInfoPage(_context.Page);

        await addVehicleInfoPage.WaitForVehiclePageReadyAsync();
        await addVehicleInfoPage.SelectUnlistedVehicleIfVisibleAsync();
        await addVehicleInfoPage.EnterVINAndSelectVehicleAsync(_contextData);
        await addVehicleInfoPage.SelectVehicleTypeAsync(_contextData.VehicleType);
        await addVehicleInfoPage.ValidateVehicleDetailsAsync(_contextData);
        await addVehicleInfoPage.SelectVehicleOptionsAsync(_contextData);
        await addVehicleInfoPage.FillPurchaseAndMileageFieldsAsync(_contextData);
        await addVehicleInfoPage.SaveAndContinueVehicleAsync();
    }


    [When("user assigns a vehicle to the driver")]
    public async Task WhenUserAssignsDriverAndVehicleAsync(Table table)
    {
        TableMappingHelpers.VehicleAssignmentFields(table, _contextData);

        var addVehicleInfoPage = new PA_AddVehicleInfoPage(_context.Page);
        await addVehicleInfoPage.AssignVehicleToDriverAsync(_contextData.Vehicle, _contextData.DriverStatus);
    }



    [When("user verifies there are no claims or violations")]
    public async Task UserVerifiesNoClaimsOrViolationsAsync()
    {
        var claimsPriorInsurancePage = new ClaimsPriorInsurancePage(_context.Page);
        await claimsPriorInsurancePage.VerifyNoClaimsOrViolationsAndContinueAsync();
    }

    [When("user selects discounts and clicks Next")]
    public async Task UserSelectsDiscountsAsync()
    {
        var discountsPage = new PA_DiscountsPage(_context.Page);
        await discountsPage.ClickNextAsync();
    }



    [When("user selects Policy Coverages")]
    public async Task UserSelectsCoveragesAsync(Table table)
    {
        TableMappingHelpers.PolicyCoverageFields(table, _contextData);

        var policyCoveragesPage = new PA_PolicyCoveragesPage(_context.Page);

        await policyCoveragesPage.SelectPolicyCoverageAsync(_contextData.PolicyCoverage);
        await policyCoveragesPage.SelectCompCollOnlyAsync(_contextData.CompCollOnly);
        await policyCoveragesPage.SelectCompDeductibleAsync(_contextData.CompDeductible);
        await policyCoveragesPage.SelectCollDeductibleAsync(_contextData.CollDeductible);
        await policyCoveragesPage.ClickNextAsync();
    }





    [When("user selects Additional Coverages")]
    public async Task UserSelectsAdditionalCoveragesAsync(Table table)
    {
        TableMappingHelpers.AdditionalCoverageFields(table, _contextData);

        var additionalCoveragesPage = new PA_AdditionalCoveragesPage(_context.Page);
        string name = $"{_contextData.ClientFirstName} {_contextData.ClientLastName}";

        await additionalCoveragesPage.SelectAccidentalDeathAndDismembermentAsync(_contextData.AccidentalDeathAndDismemberment);
        await additionalCoveragesPage.WaitForCoverageOptionsLoadAsync();
        await additionalCoveragesPage.SelectADDDriverAsync(name);
        await additionalCoveragesPage.SelectLossOfIncomeAsync(name);
        await additionalCoveragesPage.SelectRentalReimbursementAsync(_contextData.RentalReimbursement);
        await additionalCoveragesPage.SelectRoadsideAssistanceAsync(_contextData.RoadsideAssistance);
        await additionalCoveragesPage.ClickNextAsync();
    }

    [When("user verifies Pricing Details")]
    public async Task UserVerifiesPricingDetailsAsync()
    {
        var pricingDetailsPage = new PA_PricingDetailsPage(_context.Page);
        string name = $"{_contextData.ClientFirstName} {_contextData.ClientLastName}";

        var accountOwner = await pricingDetailsPage.GetAccountOwnerAsync();
        await pricingDetailsPage.AssertAccountOwnerAsync(name);

        var accountAddress = await pricingDetailsPage.GetAccountAddressAsync();
        await pricingDetailsPage.AssertAccountAddressAsync(_contextData.RiskAddress);

        // More verifications can be added here

        await pricingDetailsPage.ClickNextAsync();
    }



    [When("user verifies eligibility and clicks Next")]
    public async Task UserVerifiesEligibilityAsync()
    {
        // Add any questions that may populate
        var basePage = new PA_PricingDetailsPage(_context.Page); // Any BasePage-derived page works
        await basePage.ClickNextAsync();
    }


    [When("user adds an Additional Interest")]
    public async Task UserAddsAdditionalInterestAsync(Table table)
    {
        TableMappingHelpers.AdditionalInterestFields(table, _contextData);

        var addAdditionalInterestPage = new PA_AddAdditionalInterestPage(_context.Page);

        await addAdditionalInterestPage.ClickAddAdditionalInterestAsync();
        await addAdditionalInterestPage.SelectAdditionalInterestTypeAsync(_contextData.AdditionalInterestType);

        if (_contextData.AdditionalInterestType == "Joint Owner")
            await addAdditionalInterestPage.HandleJointOwnerFieldsAsync(_contextData);

        await addAdditionalInterestPage.FillAdditionalInterestFieldsAsync(_contextData);
        await addAdditionalInterestPage.SaveAndContinueAsync();
        await addAdditionalInterestPage.HandleUWDialogIfPresentAsync();
        await addAdditionalInterestPage.ClickNextAsync();
    }
}
