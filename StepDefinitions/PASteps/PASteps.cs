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
        [StepDefinition("user selects Personal Auto and inputs Quote Details")]
    public async Task SelectPersonalAutoAndInputQuoteDetails(Table table)
    {
        TableMappingHelpers.PAQuoteDetailsFields(table, _contextData);

        var proposalDetailsPage = new QuoteDetailsPage(_context.Page);

        await proposalDetailsPage.WaitForProposalPageLoadAsync();
        await proposalDetailsPage.SelectPersonalAutoProductAsync();
        
        // Get actual values and assert in step (PO returns values, step asserts)
        var actualPolicyTerm = await proposalDetailsPage.EnterQuoteDetailsAsync(_contextData);
        Assert.That(actualPolicyTerm, Is.EqualTo(_contextData.PolicyTerm), "Policy Term does not match expected value.");
        
        var actualWritingCompany = await proposalDetailsPage.SelectRatingStateAndCompanyAsync(_contextData);
        Assert.That(actualWritingCompany, Is.EqualTo(_contextData.WritingCompany), "Writing Company does not match expected value.");
        
        await proposalDetailsPage.SelectRiskAddressAsync(_contextData);
        await proposalDetailsPage.ClickStartQuoteAsync();
        await proposalDetailsPage.HandleSSNPopupsAsync(_contextData);
        await proposalDetailsPage.HandleClientExistsPopupAsync();
    }

    [StepDefinition("user enters Pre-Qualification information and continues")]
    public async Task UserEntersPreQualificationInfoAndContinues(Table table)
    {
        TableMappingHelpers.PreQualificationFields(table, _contextData);

        var preQualificationPage = new PreQualificationPage(_context.Page);
        await preQualificationPage.EnterPreQualificationInfoAndContinueAsync(_contextData.EligibilityRestrictions);
    }

    [StepDefinition("user selects existing Driver")]
    public async Task UserSelectsExistingDriver()
    {
        await DriverSelectionPageLocators.ExistingClientButton(_context.Page).ClickAsync();

        // Click Next to Proceed
        await GlobalLocators.NextButton(_context.Page).ClickAsync();
    }



    [StepDefinition("user enters Driver information and continues")]
    public async Task UserEntersDriverInfoAndContinues(Table table)
    {
        TableMappingHelpers.DriverInfoFields(table, _contextData);

        var addDriverInfoPage = new AddDriverInfoPage(_context.Page);

        await addDriverInfoPage.PreparePriorInsuranceReasonAsync(_contextData);
        await addDriverInfoPage.CollectAndStoreQuoteNumberAsync(_contextData);
        await addDriverInfoPage.WaitForPageLoadAsync();
        
        // Get driver field values and validate in step (PO returns, Step asserts)
        var driverFields = await addDriverInfoPage.GetDriverFieldValuesAsync();
        var expectedDOB = DateTime.Parse(_contextData.ClientDOB, System.Globalization.CultureInfo.InvariantCulture);
        
        Assert.That(driverFields.FirstName, Is.EqualTo(_contextData.ClientFirstName).IgnoreCase, 
            $"First Name mismatch. Expected: '{_contextData.ClientFirstName}', Actual: '{driverFields.FirstName}'");
        Assert.That(driverFields.LastName, Is.EqualTo(_contextData.ClientLastName).IgnoreCase, 
            $"Last Name mismatch. Expected: '{_contextData.ClientLastName}', Actual: '{driverFields.LastName}'");
        Assert.That(driverFields.DateOfBirth, Is.EqualTo(expectedDOB), "DOB does not match expected value.");
        Assert.That(driverFields.PhoneNumber, Is.EqualTo(_contextData.ClientPhoneNumber), "Phone Number does not match.");
        Assert.That(driverFields.Email, Is.EqualTo(_contextData.ClientEmail), "Email does not match.");
        Assert.That(driverFields.DLState, Is.EqualTo(_contextData.DLState), "DL State does not match.");
        
        await addDriverInfoPage.SelectDriverOptionsAsync(_contextData);
        await addDriverInfoPage.FillDriverLicenseFieldsAsync(_contextData);
        await addDriverInfoPage.SelectInsuranceOptionsAsync(_contextData);
        await addDriverInfoPage.HandlePriorInsuranceAsync(_contextData);
        await addDriverInfoPage.SaveAndContinueAsync();
        await addDriverInfoPage.HandleMVRPopUpAsync();
    }


    [StepDefinition("user enters vehicle information and continues")]
    public async Task UserEntersVehicleInfoAndContinues(Table table)
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


    [StepDefinition("user assigns a vehicle to the driver")]
    public async Task UserAssignsVehicleToDriver(Table table)
    {
        TableMappingHelpers.VehicleAssignmentFields(table, _contextData);

        var addVehicleInfoPage = new AddVehicleInfoPage(_context.Page);
        await addVehicleInfoPage.AssignVehicleToDriverAsync(_contextData.Vehicle, _contextData.DriverStatus);
    }



    [StepDefinition("user verifies there are no claims or violations")]
    public async Task UserVerifiesNoClaimsOrViolationsAsync()
    {
        var claimsAndViolationsPage = new ClaimsViolationsPage(_context.Page);
        await claimsAndViolationsPage.VerifyNoClaimsOrViolationsAndContinueAsync();
    }

    [StepDefinition("user selects discounts and clicks Next")]
    public async Task UserSelectsDiscountsAsync()
    {
        var discountsPage = new DiscountsPage(_context.Page);
        await discountsPage.ClickNextAsync();
    }



    [StepDefinition("user selects Policy Coverages")]
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





    [StepDefinition("user selects Additional Coverages")]
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

    [StepDefinition("user verifies Pricing Details")]
    public async Task UserVerifiesPricingDetailsAsync()
    {
        var pricingDetailsPage = new PricingDetailsPage(_context.Page);
        string name = $"{_contextData.ClientFirstName} {_contextData.ClientLastName}";

        await pricingDetailsPage.AssertAccountOwnerAsync(name);
        await pricingDetailsPage.AssertAccountAddressAsync(_contextData.RiskAddress);

        // More verifications can be added here

        await pricingDetailsPage.ClickNextAsync();
    }



    [StepDefinition("user verifies eligibility and clicks Next")]
    public async Task UserVerifiesEligibilityAsync()
    {
        // Add any questions that may populate

        await GlobalLocators.NextButton(_context.Page).ClickAsync();
    }


    [StepDefinition("user adds an Additional Interest")]
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
}