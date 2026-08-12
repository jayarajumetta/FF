using Microsoft.Playwright;
using InsuranceAutomation.Pages.PageMethods;
using InsuranceAutomation.Utils;
using InsuranceAutomation.Hooks;
using Reqnroll;

namespace InsuranceAutomation.StepDefinitions;

[Binding]
public sealed class SharedBusinessSteps
{
    private readonly BrowserSession _browser;
    private readonly ScenarioData _data;
    public SharedBusinessSteps(BrowserSession browser, ScenarioData data) { _browser = browser; _data = data; }

    [StepDefinition("I apply eligible discounts")]
    public async Task IApplyEligibleDiscountsAsync()
    {
        var eQCommonLoadingIndicatorWait2 = new EQCommonLoadingIndicatorWait2(_browser.Page, _data);
        var eQDiscountRateTierQuestionsNEW = new EQDiscountRateTierQuestionsNEW(_browser.Page, _data);
        var eQDiscountNEW = new EQDiscountNEW(_browser.Page, _data);

        await eQCommonLoadingIndicatorWait2.WaitForLoadingAsync();
        await eQDiscountRateTierQuestionsNEW.SetResidentiaProperty1Async(_data.Get("EQ Discount - Rate Tier Questions(NEW).Residentia_ Property_1", "{end}{scroll[-2]}"));
        await eQCommonLoadingIndicatorWait2.WaitForLoadingAsync();
        await eQDiscountNEW.VerifyMultiCarDiscountAsync(_data.Get("EQ Discount(NEW).Multi-Car Discount", "True"));
        await eQDiscountNEW.ClickRiderGroupDiscountAsync();
        await eQDiscountNEW.VerifyCommercialAutoAsync(_data.Get("EQ Discount(NEW).Commercial Auto", "True"));
        await eQDiscountNEW.VerifySpecialFarmPackageAsync(_data.Get("EQ Discount(NEW).Special Farm Package", "True"));
        await eQDiscountNEW.ClickSafeCycleDiscountAsync();
        await eQDiscountNEW.SetSafeCycleDiscountDateAsync(_data.Get("EQ Discount(NEW).Safe Cycle Discount Date", "{{data:Safe Cycle Discount Date}}"));
        await eQDiscountNEW.ClickNoDefensiveDriverDiscountAsync();
        await eQDiscountNEW.WaitForNextAsync();
        await eQDiscountNEW.ClickNextAsync();
    
    
    }

    [StepDefinition("I assign drivers to vehicles")]
    public async Task IAssignDriversToVehiclesAsync()
    {
        var newEQMultipleDriverAssignment = new NewEQMultipleDriverAssignment(_browser.Page, _data);

        await newEQMultipleDriverAssignment.ClickDriver1VehicleAsync();
        await newEQMultipleDriverAssignment.ClickDriver1PrincipalOccasionalAsync();
        await newEQMultipleDriverAssignment.SetDriver2VehicleAsync(_data.Get("(New) EQ Multiple Driver Assignment.Driver 2 Vehicle", "{Scroll[1]}"));
        await newEQMultipleDriverAssignment.SetDriver2PrincipalOccasionalAsync(_data.Get("(New) EQ Multiple Driver Assignment.Driver 2 Principal Occasional", "{Scroll[1]}"));
        await newEQMultipleDriverAssignment.SetDriver3VehicleAsync(_data.Get("(New) EQ Multiple Driver Assignment.Driver 3 Vehicle", "{Scroll[1]}"));
        await newEQMultipleDriverAssignment.SetDriver3PrincipalOccasionalAsync(_data.Get("(New) EQ Multiple Driver Assignment.Driver 3 Principal Occasional", "{Scroll[1]}"));
        await newEQMultipleDriverAssignment.SetDriver4VehicleAsync(_data.Get("(New) EQ Multiple Driver Assignment.Driver 4 Vehicle", "{Scroll[1]}"));
        await newEQMultipleDriverAssignment.SetDriver4PrincipalOccasionalAsync(_data.Get("(New) EQ Multiple Driver Assignment.Driver 4 Principal Occasional", "{Scroll[1]}"));
        await newEQMultipleDriverAssignment.SetDriver5VehicleAsync(_data.Get("(New) EQ Multiple Driver Assignment.Driver 5 Vehicle", "{Scroll[1]}"));
        await newEQMultipleDriverAssignment.SetDriver5PrincipalOccasionalAsync(_data.Get("(New) EQ Multiple Driver Assignment.Driver 5 Principal Occasional", "{Scroll[1]}"));
        await newEQMultipleDriverAssignment.ClickNextAsync();
    
    
    }

    [StepDefinition("I calculate and review pricing")]
    public async Task ICalculateAndReviewPricingAsync()
    {
        var eQPricingDetailsNew = new EQPricingDetailsNew(_browser.Page, _data);
        var eQCommonLoadingIndicatorWait2 = new EQCommonLoadingIndicatorWait2(_browser.Page, _data);

        await eQPricingDetailsNew.ClickNextAsync();
        await eQCommonLoadingIndicatorWait2.WaitForLoadingAsync();
    
    
    }

    [StepDefinition("I complete the launch checklist")]
    public async Task ICompleteTheLaunchChecklistAsync()
    {
        var eQSubmissionNEW = new EQSubmissionNEW(_browser.Page, _data);
        var eQAgentListCountCapture = new EQAgentListCountCapture(_browser.Page, _data);
        var eQECheckList = new EQECheckList(_browser.Page, _data);
        var eQChecklistClose = new EQChecklistClose(_browser.Page, _data);

        await eQSubmissionNEW.ClickChecklist1Async();
        await eQAgentListCountCapture.StoreDIVAgentDocumentsCountAsync("AgentListcount");
        await eQAgentListCountCapture.VerifyDIVAgentDocumentsCountAsync(_data.Get("EQ Agent List count capture.DIV_Agent Documents Count", "{MATH[{{buffer:AgentList count}}-1]}"));
        await eQECheckList.ClickLnkAutoCycleRVApplicationAsync();
        await eQChecklistClose.ClickBtnOkAsync();
    
    
    }

    [StepDefinition("I complete the proposal")]
    public async Task ICompleteTheProposalAsync()
    {
        var eQProposalDetailsStart = new EQProposalDetailsStart(_browser.Page, _data);

        await eQProposalDetailsStart.SetEffectiveDateAsync(_data.Get("EQ Proposal Details/Start.EffectiveDate", "{Scroll[-2]}"));
        await eQProposalDetailsStart.ClickPersonalAutoAsync();
        await eQProposalDetailsStart.ClickMotorcycleAsync();
        await eQProposalDetailsStart.ClickRecreationalVehicleAsync();
        await eQProposalDetailsStart.SetEffectiveDateAsync(_data.Get("EQ Proposal Details/Start.EffectiveDate", "{{buffer:EffectiveDate}}"));
        await eQProposalDetailsStart.SetAgentCodeAsync(_data.Get("EQ Proposal Details/Start.AgentCode", "{{data:Agent PC Code}}"));
        await eQProposalDetailsStart.PressAgentCodeAsync("Tab");
        await eQProposalDetailsStart.PressStateAsync("Tab");
        await eQProposalDetailsStart.ClickStateAsync();
        await eQProposalDetailsStart.SetStateNameAsync(_data.Get("EQ Proposal Details/Start.State Name", "X"));
        await eQProposalDetailsStart.PressWritingCompanyAsync("Tab");
        await eQProposalDetailsStart.ClickWritingCompanyAsync();
        await eQProposalDetailsStart.SetWritingCompanyAsync(_data.Get("EQ Proposal Details/Start.WritingCompany", "{{data:WritingCompany}}"));
        await eQProposalDetailsStart.PressWritingCompanyAsync("Tab");
        await eQProposalDetailsStart.PressWritingCompanyAsync("Enter");
        await eQProposalDetailsStart.PressWritingCompanyAsync("Tab");
        await eQProposalDetailsStart.SetCountyComboBoxAsync(_data.Get("EQ Proposal Details/Start.County_ComboBox", "{{data:County Name}}"));
        await eQProposalDetailsStart.PressCountyComboBoxAsync("Tab");
        await eQProposalDetailsStart.WaitForStartQuoteAsync();
        await eQProposalDetailsStart.ClickStartQuoteAsync();
        await eQProposalDetailsStart.WaitForPROCEEDAsync();
        await eQProposalDetailsStart.ClickPROCEEDAsync();
    
    
    }

    [StepDefinition("I complete the submission")]
    public async Task ICompleteTheSubmissionAsync()
    {
        var eUHome = new EUHome(_browser.Page, _data);
        var eUHomeMotorcyclePersonalAuto = new EUHomeMotorcyclePersonalAuto(_browser.Page, _data);
        var eUApplicant = new EUApplicant(_browser.Page, _data);
        var eUPricing = new EUPricing(_browser.Page, _data);
        var eQNewQuote = new EQNewQuote(_browser.Page, _data);
        var eQAutoTabs = new EQAutoTabs(_browser.Page, _data);

        await eUHome.WaitForTxtSearchTypeAsync();
        await eUHome.SetTxtSearchTextAsync(_data.Get("EU Home.Txt_Search Text", "{{buffer:QuoteNumber}}"));
        await eUHome.ClickBtnSearchAsync();
        await eUHomeMotorcyclePersonalAuto.ClickLnkMotorcycleAsync();
        await eUHomeMotorcyclePersonalAuto.ClickLnkPersonalAutoAsync();
        await eUHomeMotorcyclePersonalAuto.ClickLnkRVAsync();
        await eUApplicant.ClickLnkPricingAsync();
        await eUPricing.WaitForTxtUnderwritingNotesAsync();
        await eUPricing.SetTxtUnderwritingNotesAsync(_data.Get("EU Pricing.Txt_Underwriting Notes *", "Approved"));
        await eUPricing.PressTxtUnderwritingNotesAsync("Tab");
        await eUPricing.WaitForBtnApproveAsync();
        await eUPricing.ClickBtnApproveAsync();
        await eUPricing.ClickLnkHomeAsync();
        //await eQNewQuote.SetTxtQuotePolicySearchAsync(_data.Get("EQ New Quote.Txt_Quote\Policy Search", "\"^{a}\""));
        //await eQNewQuote.SetTxtQuotePolicySearchAsync(_data.Get("EQ New Quote.Txt_Quote\Policy Search", "{{buffer:QuoteNumber}}"));
        await eQNewQuote.ClickBtnSearchAsync();
        await eQAutoTabs.ClickDIVSubmissionAsync();
    
    
    }

    [StepDefinition("I enter additional interests")]
    public async Task IEnterAdditionalInterestsAsync()
    {
        var eQAdditionalInterest = new EQAdditionalInterest(_browser.Page, _data);

        await eQAdditionalInterest.WaitForH1AdditionalInterestSummaryAsync();
        await eQAdditionalInterest.ClickNextAsync();
    
    
    }

    [StepDefinition("I enter billing details")]
    public async Task IEnterBillingDetailsAsync()
    {
        var eQBilling = new EQBilling(_browser.Page, _data);

        await eQBilling.WaitForHdrBillingAsync();
        await eQBilling.ClickBtnCreateNewBillingAccountAsync();
        await eQBilling.SetBtnDirectBillAsync(_data.Get("EQ Billing.Btn_Direct Bill", "{scroll[3]}"));
        await eQBilling.SetBtn1PaymentAsync(_data.Get("EQ Billing.Btn_1 Payment", "X"));
        await eQBilling.SetTxtPaymentDueDateAsync(_data.Get("EQ Billing.Txt_PaymentDueDate", "25"));
        await eQBilling.ClickRdBtnFullBalanceAsync();
        await eQBilling.ClickBtnCHECKAsync();
        await eQBilling.SetTxtCheckNumberAsync(_data.Get("EQ Billing.Txt_Check Number", "1234"));
        await eQBilling.ClickBtnBillingNEXTAsync();
    
    
    }

    [StepDefinition("I enter claims and violation history")]
    public async Task IEnterClaimsAndViolationHistoryAsync()
    {
        var eQCommonLoadingIndicatorWait2 = new EQCommonLoadingIndicatorWait2(_browser.Page, _data);
        var eQClaimsViolationNEW = new EQClaimsViolationNEW(_browser.Page, _data);

        await eQCommonLoadingIndicatorWait2.WaitForLoadingAsync();
        await eQClaimsViolationNEW.ClickNextAsync();
    
    
    }

    [StepDefinition("I enter driver information")]
    public async Task IEnterDriverInformationAsync()
    {
        var eQDriverInformation = new EQDriverInformation(_browser.Page, _data);
        var eQNamedInsOperatorStatus = new EQNamedInsOperatorStatus(_browser.Page, _data);
        var eQDriverLicenseTime = new EQDriverLicenseTime(_browser.Page, _data);
        var eQSideMenu = new EQSideMenu(_browser.Page, _data);
        var eQAddAdditionalDriver1 = new EQAddAdditionalDriver1(_browser.Page, _data);

        await eQDriverInformation.ClickExistingClient1Async();
        await eQDriverInformation.ClickBtnNextAsync();
        await eQDriverInformation.PressBtnNextAsync("Tab");
        await eQNamedInsOperatorStatus.SetFirstNameDriver1Async(_data.Get("EQ NamedIns_Operator Status.First Name_Driver1", "{{data:First Name}}"));
        await eQNamedInsOperatorStatus.SetLastNameDriver1Async(_data.Get("EQ NamedIns_Operator Status.Last Name_Driver1", "{{data:Last Name}}"));
        await eQNamedInsOperatorStatus.SetDOBDriver1Async(_data.Get("EQ NamedIns_Operator Status.DOB_Driver1", "{{data:DOB}}"));
        await eQNamedInsOperatorStatus.ClickMoreOptionsRelationToAccountOwnerAsync();
        await eQNamedInsOperatorStatus.PressMoreOptionsRelationToAccountOwnerAsync("Tab");
        await eQNamedInsOperatorStatus.WaitForMoreOptionsRelationToAccountOwnerAsync();
        await eQNamedInsOperatorStatus.ClickMoreOptionsRelationToAccountOwnerAsync();
        await eQNamedInsOperatorStatus.WaitForAccountOwnerAsync();
        await eQNamedInsOperatorStatus.ClickAccountOwnerAsync();
        await eQNamedInsOperatorStatus.SetSSNAsync(_data.Get("EQ NamedIns_Operator Status.SSN", "{{data:SSN}}"));
        await eQNamedInsOperatorStatus.ClickMTNationalGuardAsync();
        await eQNamedInsOperatorStatus.WaitForIsThisDriverANamedInsuredAsync();
        await eQNamedInsOperatorStatus.SetPrimaryNamedInsuredAsync(_data.Get("EQ NamedIns_Operator Status.Primary Named Insured", "X{scroll[2]}"));
        await eQNamedInsOperatorStatus.SetNamedInsuredAsync(_data.Get("EQ NamedIns_Operator Status.Named Insured", "X{scroll[2]}"));
        await eQNamedInsOperatorStatus.SetNotANamedInsuredAsync(_data.Get("EQ NamedIns_Operator Status.Not a Named Insured", "X{scroll[2]}"));
        await eQNamedInsOperatorStatus.SetRelatedAsync(_data.Get("EQ NamedIns_Operator Status.Related", "X{scroll[2]}"));
        await eQNamedInsOperatorStatus.SetAssignedAsync(_data.Get("EQ NamedIns_Operator Status.Assigned", "X{scroll[2]}"));
        await eQNamedInsOperatorStatus.SetAssignedAsync(_data.Get("EQ NamedIns_Operator Status.Assigned", "X{scroll[2]}"));
        await eQNamedInsOperatorStatus.SetRelatedAsync(_data.Get("EQ NamedIns_Operator Status.Related", "X{scroll[2]}"));
        await eQNamedInsOperatorStatus.SetAssignedAsync(_data.Get("EQ NamedIns_Operator Status.Assigned", "X{scroll[2]}"));
        await eQNamedInsOperatorStatus.ClickNoCycleLicenseAsync();
        await eQNamedInsOperatorStatus.SetAssignedAsync(_data.Get("EQ NamedIns_Operator Status.Assigned", "X{scroll[2]}"));
        await eQNamedInsOperatorStatus.ClickMoreOptionsOperatorStatusAsync();
        await eQNamedInsOperatorStatus.SetMilitaryAsync(_data.Get("EQ NamedIns_Operator Status.Military", "X"));
        await eQNamedInsOperatorStatus.SetMissionaryAsync(_data.Get("EQ NamedIns_Operator Status.Missionary", "X"));
        await eQNamedInsOperatorStatus.SetNonDriverAsync(_data.Get("EQ NamedIns_Operator Status.Non Driver", "X"));
        await eQNamedInsOperatorStatus.SetOtherInsuranceAsync(_data.Get("EQ NamedIns_Operator Status.Other Insurance", "X"));
        await eQNamedInsOperatorStatus.WaitForNonDriverReasonAsync();
        await eQNamedInsOperatorStatus.SetCycleNonDriverComboBoxAsync(_data.Get("EQ NamedIns_Operator Status.CycleNonDriver_ComboBox", "Never Licensed"));
        await eQNamedInsOperatorStatus.SetCycleNonDriverComboBoxAsync(_data.Get("EQ NamedIns_Operator Status.CycleNonDriver_ComboBox", "Underage"));
        await eQNamedInsOperatorStatus.SetCycleNonDriverComboBoxAsync(_data.Get("EQ NamedIns_Operator Status.CycleNonDriver_ComboBox", "Medical Condition"));
        await eQNamedInsOperatorStatus.SetCycleNonDriverComboBoxAsync(_data.Get("EQ NamedIns_Operator Status.CycleNonDriver_ComboBox", "Surrendered"));
        await eQNamedInsOperatorStatus.SetCycleNonDriverComboBoxAsync(_data.Get("EQ NamedIns_Operator Status.CycleNonDriver_ComboBox", "Permit Driver"));
        await eQNamedInsOperatorStatus.WaitForIsThisDriverANamedInsuredAsync();
        await eQNamedInsOperatorStatus.SetPrimaryNamedInsuredAsync(_data.Get("EQ NamedIns_Operator Status.Primary Named Insured", "X{scroll[2]}"));
        await eQNamedInsOperatorStatus.SetNamedInsuredAsync(_data.Get("EQ NamedIns_Operator Status.Named Insured", "X{scroll[2]}"));
        await eQNamedInsOperatorStatus.SetNotANamedInsuredAsync(_data.Get("EQ NamedIns_Operator Status.Not a Named Insured", "X{scroll[2]}"));
        await eQNamedInsOperatorStatus.SetAssignedAsync(_data.Get("EQ NamedIns_Operator Status.Assigned", "X{scroll[2]}"));
        await eQNamedInsOperatorStatus.SetNonDriverAsync(_data.Get("EQ NamedIns_Operator Status.Non Driver", "X{scroll[2]}"));
        await eQNamedInsOperatorStatus.SetRelatedAsync(_data.Get("EQ NamedIns_Operator Status.Related", "X"));
        await eQNamedInsOperatorStatus.SetAssignedAsync(_data.Get("EQ NamedIns_Operator Status.Assigned", "X"));
        await eQNamedInsOperatorStatus.SetRelatedAsync(_data.Get("EQ NamedIns_Operator Status.Related", "X"));
        await eQNamedInsOperatorStatus.ClickMoreOptionsOperatorStatusAsync();
        await eQNamedInsOperatorStatus.SetMilitaryAsync(_data.Get("EQ NamedIns_Operator Status.Military", "X"));
        await eQNamedInsOperatorStatus.SetMissionaryAsync(_data.Get("EQ NamedIns_Operator Status.Missionary", "X"));
        await eQNamedInsOperatorStatus.SetOtherInsuranceAsync(_data.Get("EQ NamedIns_Operator Status.Other Insurance", "X"));
        await eQNamedInsOperatorStatus.SetRoommateAsync(_data.Get("EQ NamedIns_Operator Status.Roommate", "X"));
        await eQNamedInsOperatorStatus.WaitForNonDriverReasonAsync();
        await eQNamedInsOperatorStatus.ClickNeverLicensedAsync();
        await eQNamedInsOperatorStatus.ClickUnderageAsync();
        await eQNamedInsOperatorStatus.ClickMedicalConditionAsync();
        await eQNamedInsOperatorStatus.ClickMoreOptionsNonDriverAsync();
        await eQNamedInsOperatorStatus.ClickSurrenderedAsync();
        await eQNamedInsOperatorStatus.ClickPermitDriverAsync();
        await eQDriverLicenseTime.SetYrsLicensedCurrentStateAsync(_data.Get("EQ DriverLicense_Time.Yrs Licensed Current State", "\"^{a}\""));
        await eQDriverLicenseTime.SetYrsLicensedCurrentStateAsync(_data.Get("EQ DriverLicense_Time.Yrs Licensed Current State", "9"));
        await eQDriverLicenseTime.SetMonthsLicensedCurrentStateAsync(_data.Get("EQ DriverLicense_Time.Months Licensed Current State", "\"^{a}\""));
        await eQDriverLicenseTime.SetMonthsLicensedCurrentStateAsync(_data.Get("EQ DriverLicense_Time.Months Licensed Current State", "9"));
        await eQDriverLicenseTime.SetNoAsync(_data.Get("EQ DriverLicense_Time.No", "{Scroll[2]}"));
        await eQSideMenu.SetDriverInformationAsync(_data.Get("EQ Side Menu.Driver Information", "X"));
        await eQSideMenu.SetDriverInformationAsync(_data.Get("EQ Side Menu.Driver Information", "X"));
        await eQSideMenu.SelectVehicleSummaryAsync(_data.Get("EQ Side Menu.Vehicle Summary", "{XL[Vehicle Summary]}"));
        await eQSideMenu.SelectCoveragesAsync(_data.Get("EQ Side Menu.Coverages", "{XL[Coverages]}"));
        await eQAddAdditionalDriver1.StoreDriver1Async("Driver_1");
        await eQSideMenu.SetVehicleSummaryAsync(_data.Get("EQ Side Menu.Vehicle Summary", "X"));
        await eQSideMenu.SelectCoveragesAsync(_data.Get("EQ Side Menu.Coverages", "{XL[Coverages]}"));
    
    
    }

    [StepDefinition("I enter vehicle information")]
    public async Task IEnterVehicleInformationAsync()
    {
        var eQVehicleAutoVin1 = new EQVehicleAutoVin1(_browser.Page, _data);
        var eQVehicleSummaryAutoMotorHomeUse = new EQVehicleSummaryAutoMotorHomeUse(_browser.Page, _data);
        var eQVehicleSummaryAutoAdditional = new EQVehicleSummaryAutoAdditional(_browser.Page, _data);
        var eQCAVerifiedMileage = new EQCAVerifiedMileage(_browser.Page, _data);
        var eQVehicleSummaryNextAdd = new EQVehicleSummaryNextAdd(_browser.Page, _data);

        await eQVehicleAutoVin1.WaitForTxtVINAsync();
        await eQVehicleAutoVin1.ClickTxtVINAsync();
        await eQVehicleAutoVin1.SetTxtVINAsync(_data.Get("EQ Vehicle Auto Vin_1.txt_VIN", "{{data:VIN 1}}"));
        await eQVehicleAutoVin1.PressTxtVINAsync("Tab");
        await eQVehicleSummaryAutoMotorHomeUse.SetBtnLoanAsync(_data.Get("EQ Vehicle Summary Auto/Motor Home Use.btn_Loan", "X"));
        await eQVehicleSummaryAutoMotorHomeUse.SetBtnLeasedAsync(_data.Get("EQ Vehicle Summary Auto/Motor Home Use.btn_Leased", "X"));
        await eQVehicleSummaryAutoMotorHomeUse.SetBtnOwnAsync(_data.Get("EQ Vehicle Summary Auto/Motor Home Use.btn_Own", "X"));
        await eQVehicleSummaryAutoMotorHomeUse.ClickNativeAmericanRegisterNOAsync();
        await eQVehicleSummaryAutoMotorHomeUse.ClickILCategory1Async();
        await eQVehicleSummaryAutoMotorHomeUse.ClickCategoryIAsync();
        await eQVehicleSummaryAutoMotorHomeUse.ClickActiveDisablingDeviceAsync();
        await eQVehicleSummaryAutoMotorHomeUse.SetPleasureCANYFFCICAsync(_data.Get("EQ Vehicle Summary Auto/Motor Home Use.Pleasure_CA_NY_FFCIC", "X"));
        await eQVehicleSummaryAutoMotorHomeUse.ClickItem1DayAsync();
        await eQVehicleSummaryAutoMotorHomeUse.SetNYFFCICTotalAnnualMilesAsync(_data.Get("EQ Vehicle Summary Auto/Motor Home Use.NY_FFCIC_total_annual_miles", "\"^{a}\""));
        await eQVehicleSummaryAutoMotorHomeUse.SetNYFFCICTotalAnnualMilesAsync(_data.Get("EQ Vehicle Summary Auto/Motor Home Use.NY_FFCIC_total_annual_miles", "8500"));
        await eQVehicleSummaryAutoMotorHomeUse.SetWorkMilesDayAsync(_data.Get("EQ Vehicle Summary Auto/Motor Home Use.Work_miles_day", "\"^{a}\""));
        await eQVehicleSummaryAutoMotorHomeUse.SetWorkMilesDayAsync(_data.Get("EQ Vehicle Summary Auto/Motor Home Use.Work_miles_day", "10"));
        await eQVehicleSummaryAutoMotorHomeUse.SetNonWorkAnnualMilesAsync(_data.Get("EQ Vehicle Summary Auto/Motor Home Use.Non_work_annual_miles", "\"^{a}\""));
        await eQVehicleSummaryAutoMotorHomeUse.SetNonWorkAnnualMilesAsync(_data.Get("EQ Vehicle Summary Auto/Motor Home Use.Non_work_annual_miles", "3500"));
        await eQVehicleSummaryAutoMotorHomeUse.ClickMoreOptionsFarmUseAsync();
        await eQVehicleSummaryAutoMotorHomeUse.SetTxtPurchaseDateAsync(_data.Get("EQ Vehicle Summary Auto/Motor Home Use.txt_purchase_date", "\"^{a}\""));
        await eQVehicleSummaryAutoMotorHomeUse.SetTxtPurchaseDateAsync(_data.Get("EQ Vehicle Summary Auto/Motor Home Use.txt_purchase_date", "10/10/2000"));
        await eQVehicleSummaryAutoMotorHomeUse.SetTxtOdometerAsync(_data.Get("EQ Vehicle Summary Auto/Motor Home Use.txt_odometer", "\"^{a}\""));
        await eQVehicleSummaryAutoMotorHomeUse.SetTxtOdometerAsync(_data.Get("EQ Vehicle Summary Auto/Motor Home Use.txt_odometer", "60000"));
        await eQVehicleSummaryAutoMotorHomeUse.SetTxtAnnualMileageAsync(_data.Get("EQ Vehicle Summary Auto/Motor Home Use.txt_annual_mileage", "\"^{a}\""));
        await eQVehicleSummaryAutoMotorHomeUse.SetTxtAnnualMileageAsync(_data.Get("EQ Vehicle Summary Auto/Motor Home Use.txt_annual_mileage", "{{data:Annual Mileage Veh 1}}"));
        await eQVehicleSummaryAutoMotorHomeUse.ClickBtnSaveContinueAsync();
        await eQVehicleSummaryAutoAdditional.WaitForVINAsync();
        await eQVehicleSummaryAutoAdditional.SetVINAsync(_data.Get("EQ Vehicle Summary Auto Additional.VIN", "{{data:VIN 2}}"));
        await eQVehicleSummaryAutoAdditional.PressVINAsync("Tab");
        await eQVehicleSummaryAutoAdditional.ClickVehicleMoreOptionsAsync();
        await eQVehicleSummaryAutoAdditional.SetCollectorCarAsync(_data.Get("EQ Vehicle Summary Auto Additional.CollectorCar", "X"));
        await eQVehicleSummaryAutoAdditional.ClickCollectorCarTypeMoreOptionsAsync();
        await eQVehicleSummaryAutoAdditional.SetClassicAsync(_data.Get("EQ Vehicle Summary Auto Additional.Classic", "X"));
        await eQVehicleSummaryAutoAdditional.SetAgreedValueAsync(_data.Get("EQ Vehicle Summary Auto Additional.Agreed Value", "{{data:Agreed Value Veh 2}}"));
        await eQVehicleSummaryAutoAdditional.SetOwnAsync(_data.Get("EQ Vehicle Summary Auto Additional.Own", "X"));
        await eQVehicleSummaryAutoAdditional.ClickCONTINUEAsync();
        await eQVehicleSummaryAutoAdditional.SetRestrictedUseAsync(_data.Get("EQ Vehicle Summary Auto Additional.Restricted Use", "X"));
        await eQVehicleSummaryAutoAdditional.SetAppraisalDateAsync(_data.Get("EQ Vehicle Summary Auto Additional.Appraisal Date", "06/06/2025"));
        await eQVehicleSummaryAutoAdditional.SetTotalAnnualMileageAsync(_data.Get("EQ Vehicle Summary Auto Additional.Total_annual_mileage", "\"^{a}\""));
        await eQVehicleSummaryAutoAdditional.SetTotalAnnualMileageAsync(_data.Get("EQ Vehicle Summary Auto Additional.Total_annual_mileage", "{{data:Annual Mileage Veh 2}}"));
        await eQVehicleSummaryAutoAdditional.PressTotalAnnualMileageAsync("Tab");
        await eQVehicleSummaryAutoAdditional.ClickSaveContinueAsync();
        await eQVehicleSummaryAutoAdditional.WaitForVINAsync();
        await eQVehicleSummaryAutoAdditional.SetVINAsync(_data.Get("EQ Vehicle Summary Auto Additional.VIN", "{{data:VIN 3}}"));
        await eQVehicleSummaryAutoAdditional.PressVINAsync("Tab");
        await eQVehicleSummaryAutoAdditional.ClickVehicleMoreOptionsAsync();
        await eQVehicleSummaryAutoAdditional.SetCollectorCarAsync(_data.Get("EQ Vehicle Summary Auto Additional.CollectorCar", "X"));
        await eQVehicleSummaryAutoAdditional.SetModernClassicAsync(_data.Get("EQ Vehicle Summary Auto Additional.Modern Classic", "X"));
        await eQVehicleSummaryAutoAdditional.SetAgreedValueAsync(_data.Get("EQ Vehicle Summary Auto Additional.Agreed Value", "{{data:Agreed Value Veh 3}}"));
        await eQVehicleSummaryAutoAdditional.SetOwnAsync(_data.Get("EQ Vehicle Summary Auto Additional.Own", "X"));
        await eQVehicleSummaryAutoAdditional.ClickCONTINUEAsync();
        await eQVehicleSummaryAutoAdditional.SetRestrictedUseAsync(_data.Get("EQ Vehicle Summary Auto Additional.Restricted Use", "X"));
        await eQVehicleSummaryAutoAdditional.SetAppraisalDateAsync(_data.Get("EQ Vehicle Summary Auto Additional.Appraisal Date", "06/06/2025"));
        await eQVehicleSummaryAutoAdditional.SetOdometerAsync(_data.Get("EQ Vehicle Summary Auto Additional.Odometer", "\"^{a}\""));
        await eQVehicleSummaryAutoAdditional.SetOdometerAsync(_data.Get("EQ Vehicle Summary Auto Additional.Odometer", "60000"));
        await eQVehicleSummaryAutoAdditional.SetTotalAnnualMileageAsync(_data.Get("EQ Vehicle Summary Auto Additional.Total_annual_mileage", "\"^{a}\""));
        await eQVehicleSummaryAutoAdditional.SetTotalAnnualMileageAsync(_data.Get("EQ Vehicle Summary Auto Additional.Total_annual_mileage", "{{data:Annual Mileage Veh 3}}"));
        await eQVehicleSummaryAutoAdditional.PressTotalAnnualMileageAsync("Tab");
        await eQVehicleSummaryAutoAdditional.ClickSaveContinueAsync();
        await eQCAVerifiedMileage.ClickOptOutAsync();
        await eQVehicleSummaryNextAdd.ClickBtnNextAsync();
    
    
    }

    [StepDefinition("I load the required business test data")]
    public async Task ILoadTheRequiredBusinessTestDataAsync()
    {
        await Task.CompletedTask;
    
    
    }

    [StepDefinition("I prepare the Home and Auto application")]
    public async Task IPrepareTheHomeAndAutoApplicationAsync()
    {
        await _browser.NavigateAsync(_data.Get("BaseUrl", "{{env:BASE_URL}}"));
        var edgePreferencesFile = new EdgePreferencesFile(_browser.Page, _data);
        var eQSignOn = new EQSignOn(_browser.Page, _data);

        await eQSignOn.SetTxtUsernameAsync(_data.Get("EQ Sign On.Txt_Username", "\"^{a}\""));
        await eQSignOn.SetTxtUsernameAsync(_data.Get("EQ Sign On.Txt_Username", "{{env:APP_USERNAME}}"));
        await eQSignOn.SetTxtPassword1Async(_data.Get("EQ Sign On.Txt_Password_1", "\"^{a}\""));
        await eQSignOn.SetTxtPasswordAsync(_data.Get("EQ Sign On.Txt_Password", "{{env:APP_PASSWORD}}"));
    
    
    }

    [StepDefinition("I return to the submission")]
    public async Task IReturnToTheSubmissionAsync()
    {
        var eQSubmission = new EQSubmission(_browser.Page, _data);

        await eQSubmission.StoreLblValueTotalPolicyPremiumAsync("Premium");
        await eQSubmission.StoreLblValueEffectiveDateAsync("EffectiveDate");
        await eQSubmission.StoreLblValuePolicyNumberAsync("PolicyNumber");
        await eQSubmission.StoreLblValueChecklistIdAsync("CheckListID");
    
    
    }

    [StepDefinition("I save and exit the submission")]
    public async Task ISaveAndExitTheSubmissionAsync()
    {
        var eQSubmission = new EQSubmission(_browser.Page, _data);

        await eQSubmission.ClickBtnSaveAndExitAsync();
    
    
    }

    [StepDefinition("I save the generated business test results")]
    public async Task ISaveTheGeneratedBusinessTestResultsAsync()
    {
        await Task.CompletedTask;
    
    
    }

    [StepDefinition("I select additional coverages")]
    public async Task ISelectAdditionalCoveragesAsync()
    {
        var eQOtherPolicyCoveragesSectionNew = new EQOtherPolicyCoveragesSectionNew(_browser.Page, _data);
        var eQPersonalInjuryProtectionSectionNew = new EQPersonalInjuryProtectionSectionNew(_browser.Page, _data);
        var eQVehicleCoveragesSection = new EQVehicleCoveragesSection(_browser.Page, _data);
        var eQAdditionalCoveragesNextNew = new EQAdditionalCoveragesNextNew(_browser.Page, _data);

        await eQOtherPolicyCoveragesSectionNew.WaitForH1AdditionalCoveragesAsync();
        await eQOtherPolicyCoveragesSectionNew.SetTortOptionAsync(_data.Get("EQ Other Policy Coverages Section (New).Tort Option", "{home}x"));
        await eQOtherPolicyCoveragesSectionNew.SetIncomeLossCoverageAsync(_data.Get("EQ Other Policy Coverages Section (New).Income Loss Coverage", "{Home}x"));
        await eQOtherPolicyCoveragesSectionNew.SetUMPDAsync(_data.Get("EQ Other Policy Coverages Section (New).UMPD", "X"));
        await eQOtherPolicyCoveragesSectionNew.ClickUIMPDAsync();
        await eQOtherPolicyCoveragesSectionNew.WaitForADDCoverageAsync();
        await eQOtherPolicyCoveragesSectionNew.SetADDCoverageAsync(_data.Get("EQ Other Policy Coverages Section (New).AD&D Coverage", "{scroll[3]}"));
        await eQOtherPolicyCoveragesSectionNew.ClickADDDriver1Async();
        await eQOtherPolicyCoveragesSectionNew.ClickADDDriver2Async();
        await eQOtherPolicyCoveragesSectionNew.ClickADDDriver3Async();
        await eQOtherPolicyCoveragesSectionNew.ClickADDDriver4Async();
        await eQOtherPolicyCoveragesSectionNew.ClickADDDriver5Async();
        await eQOtherPolicyCoveragesSectionNew.ClickTotalDisabilityCoverageDriver1Async();
        await eQOtherPolicyCoveragesSectionNew.ClickIncLiabilityClaimsOfFamilyMembersAsync();
        await eQOtherPolicyCoveragesSectionNew.ClickExtraordinaryMedicalBenefitAsync();
        await eQOtherPolicyCoveragesSectionNew.ClickWorkLossNoAsync();
        await eQPersonalInjuryProtectionSectionNew.ClickHouseholdMembersAge65OrReceivingPensionAsync();
        await eQPersonalInjuryProtectionSectionNew.SetPIPLimitAsync(_data.Get("EQ Personal Injury Protection Section (New).PIP Limit", "X"));
        await eQPersonalInjuryProtectionSectionNew.SetPIPDeductibleAsync(_data.Get("EQ Personal Injury Protection Section (New).PIP Deductible", "X"));
        await eQPersonalInjuryProtectionSectionNew.ClickAdditionalPIPAsync();
        await eQPersonalInjuryProtectionSectionNew.ClickPIPStackingAsync();
        await eQPersonalInjuryProtectionSectionNew.SetExtraPIPOptionAsync(_data.Get("EQ Personal Injury Protection Section (New).Extra PIP Option", "X"));
        await eQPersonalInjuryProtectionSectionNew.SetAutoHealthInsurerAsync(_data.Get("EQ Personal Injury Protection Section (New).Auto Health Insurer", "X"));
        await eQPersonalInjuryProtectionSectionNew.ClickMedicalExpenseEliminationAsync();
        await eQPersonalInjuryProtectionSectionNew.ClickWorkLossNoAsync();
        await eQPersonalInjuryProtectionSectionNew.ClickBroadenedPIPAsync();
        await eQPersonalInjuryProtectionSectionNew.ClickAdditionalDeathBenefitAsync();
        await eQPersonalInjuryProtectionSectionNew.ClickWaiverOfIncomeLossAsync();
        await eQVehicleCoveragesSection.ClickUMPDUIMPDV1Async();
        await eQVehicleCoveragesSection.ClickUIMPDCoverageV1Async();
        await eQVehicleCoveragesSection.SetRentalReimbursementCoverageV1Async(_data.Get("EQ Vehicle Coverages Section.Rental Reimbursement Coverage_V1", "{scroll[4]}"));
        await eQVehicleCoveragesSection.ClickTheftDeductibleV1Async();
        await eQVehicleCoveragesSection.SetRoadsideAssistanceCoverageV1Async(_data.Get("EQ Vehicle Coverages Section.Roadside Assistance Coverage_V1", "{Scroll[2]}"));
        await eQVehicleCoveragesSection.ClickCycleAccessoriesV1Async();
        await eQVehicleCoveragesSection.ClickOriginalPartsV1Async();
        await eQVehicleCoveragesSection.SetEndorsementLimitV1Async(_data.Get("EQ Vehicle Coverages Section.Endorsement Limit V1", "SA-1398 $5,000"));
        await eQVehicleCoveragesSection.ClickUMPDUIMPDV2Async();
        await eQVehicleCoveragesSection.ClickUIMPDCoverageV2Async();
        await eQVehicleCoveragesSection.SetRentalReimbursementCoverageV2Async(_data.Get("EQ Vehicle Coverages Section.Rental Reimbursement Coverage_V2", "{scroll[4]}"));
        await eQVehicleCoveragesSection.ClickTheftDeductibleV2Async();
        await eQVehicleCoveragesSection.SetRoadsideAssistanceCoverageV2Async(_data.Get("EQ Vehicle Coverages Section.Roadside Assistance Coverage_V2", "{scroll[2]}"));
        await eQVehicleCoveragesSection.ClickCycleAccessoriesV2Async();
        await eQVehicleCoveragesSection.ClickOriginalPartsV2Async();
        await eQVehicleCoveragesSection.SetEndorsementLimitV2Async(_data.Get("EQ Vehicle Coverages Section.Endorsement Limit V2", "SA-1399 $7,000"));
        await eQVehicleCoveragesSection.ClickNoCoverageV1TowingAsync();
        await eQVehicleCoveragesSection.ClickUMPDUIMPDV3Async();
        await eQVehicleCoveragesSection.ClickUIMPDCoverageV3Async();
        await eQVehicleCoveragesSection.SetRentalReimbursementCoverageV3Async(_data.Get("EQ Vehicle Coverages Section.Rental Reimbursement Coverage_V3", "{scroll[4]}"));
        await eQVehicleCoveragesSection.ClickTheftDeductibleV3Async();
        await eQVehicleCoveragesSection.SetRoadsideAssistanceCoverageV3Async(_data.Get("EQ Vehicle Coverages Section.Roadside Assistance Coverage_V3", "{scroll[2]}"));
        await eQVehicleCoveragesSection.ClickCycleAccessoriesV3Async();
        await eQVehicleCoveragesSection.ClickOriginalPartsV3Async();
        await eQVehicleCoveragesSection.ClickUMPDUIMPDV4Async();
        await eQVehicleCoveragesSection.ClickUIMPDCoverageV4Async();
        await eQVehicleCoveragesSection.SetRentalReimbursementCoverageV4Async(_data.Get("EQ Vehicle Coverages Section.Rental Reimbursement Coverage_V4", "{end}"));
        await eQVehicleCoveragesSection.ClickTheftDeductibleV4Async();
        await eQVehicleCoveragesSection.ClickRoadsideAssistanceCoverageV4Async();
        await eQVehicleCoveragesSection.ClickCycleAccessoriesV4Async();
        await eQVehicleCoveragesSection.ClickOriginalPartsV4Async();
        await eQAdditionalCoveragesNextNew.ClickNextAsync();
    
    
    }

    [StepDefinition("I select or create the client and enter account details")]
    public async Task ISelectOrCreateTheClientAndEnterAccountDetailsAsync()
    {
        var eQNewQuote = new EQNewQuote(_browser.Page, _data);
        var eQClientSelection = new EQClientSelection(_browser.Page, _data);
        var eQAccountDetails = new EQAccountDetails(_browser.Page, _data);

        await eQNewQuote.WaitForBtnNewQuoteAsync();
        await eQNewQuote.VerifyBtnNewQuoteAsync(_data.Get("EQ New Quote.Btn_New Quote", "New Quote"));
        await eQNewQuote.ClickBtnNewQuoteAsync();
        await eQClientSelection.SetTxtFirstAsync(_data.Get("EQ Client Selection.Txt_First", "{{data:First Name}}"));
        await eQClientSelection.SetTxtLastAsync(_data.Get("EQ Client Selection.Txt_Last", "{{data:Last Name}}"));
        await eQClientSelection.WaitForBtnSearchAsync();
        await eQClientSelection.ClickBtnSearchAsync();
        await eQClientSelection.WaitForBtnCreateNewClientAsync();
        await eQClientSelection.ClickBtnCreateNewClientAsync();
        await eQClientSelection.ClickBtnNextAsync();
        await eQAccountDetails.VerifyTxtFirstNameAccountOwnerAsync(_data.Get("EQ Account Details.Txt_First Name_Account Owner", "True"));
        await eQAccountDetails.SetTxtBestPhoneAccountOwnerAsync(_data.Get("EQ Account Details.Txt_Best phone_Account Owner", "{{data:Phone Number}}"));
        await eQAccountDetails.SetTxtEmailAccountOwnerAsync(_data.Get("EQ Account Details.Txt_Email_Account Owner", "{{data:Email}}"));
        await eQAccountDetails.WaitForLblMaritalStatusAsync();
        await eQAccountDetails.ClickBtnSingleAsync();
        await eQAccountDetails.ClickBtnMarriedAsync();
        await eQAccountDetails.ClickBtnDivorcedAsync();
        await eQAccountDetails.SetTxtOwnerAddressLine2Async(_data.Get("EQ Account Details.Txt_owner.address.line2", "{{data:Apartment}}"));
        await eQAccountDetails.SetTxtOwnerAddressCityNewAsync(_data.Get("EQ Account Details.Txt_owner.address.city_New", "{{data:City}}"));
        await eQAccountDetails.PressDrpdwnStateAsync("Tab");
        await eQAccountDetails.ClickDrpdwnStateAsync();
        await eQAccountDetails.SetStateNameAsync(_data.Get("EQ Account Details.State Name", "X"));
        await eQAccountDetails.SetTxtOwnerAddressZipAsync(_data.Get("EQ Account Details.Txt_owner.address.zip", "{{data:ZIP}}"));
        await eQAccountDetails.WaitForSatelliteAsync();
        await eQAccountDetails.ClickBtnNextAsync();
        await eQAccountDetails.PressBtnNextAsync("Shift+Tab");
        await eQAccountDetails.ClickBtnYesAtLeast90DaysAsync();
        await eQAccountDetails.WaitForLblIsTheAccountAddressAlsoWhereTheClientResidesAsync();
        await eQAccountDetails.ClickBtnYesClientResidesAsync();
        await eQAccountDetails.ClickBtnNextAsync();
    
    
    }

    [StepDefinition("I select policy coverages")]
    public async Task ISelectPolicyCoveragesAsync()
    {
        var editCoverageOptionNew = new EditCoverageOptionNew(_browser.Page, _data);
        var eQCommonLoadingIndicatorWait2 = new EQCommonLoadingIndicatorWait2(_browser.Page, _data);
        var coveragesNew = new CoveragesNew(_browser.Page, _data);

        await editCoverageOptionNew.WaitForSupplementalUMUIMOptInAsync();
        await editCoverageOptionNew.ClickSupplementalUMUIMOptInAsync();
        await editCoverageOptionNew.ClickSupplementalUMUIMCovAsync();
        await editCoverageOptionNew.WaitForUMCoverageAsync();
        await editCoverageOptionNew.ClickUMCoverageAsync();
        await editCoverageOptionNew.ClickSaveAndContinueAsync();
        await eQCommonLoadingIndicatorWait2.WaitForLoadingAsync();
        await coveragesNew.ClickV1CompCollOnlyYESAsync();
        await coveragesNew.ClickV1ComprehensiveAndCollisionOnlyAsync();
        await coveragesNew.ClickV1CompDedAsync();
        await coveragesNew.ClickV1CompDedMoreOptAsync();
        await coveragesNew.ClickV1CollDedAsync();
        await coveragesNew.ClickV1CollDedMoreOptAsync();
        await coveragesNew.SetV2CompCollOnlyYESAsync(_data.Get("Coverages (New).V2_Comp/Coll Only - YES", "X"));
        await coveragesNew.ClickV2ComprehensiveAndCollisionOnlyAsync();
        await coveragesNew.VerifyV2ComprehensiveDeductibleAsync(_data.Get("Coverages (New).V2_Comprehensive Deductible", "True"));
        await coveragesNew.SetV2CompDedAsync(_data.Get("Coverages (New).V2_CompDed", "X"));
        await coveragesNew.ClickV2CompDedMoreOptAsync();
        await coveragesNew.SetV2CollDedAsync(_data.Get("Coverages (New).V2_CollDed", "X"));
        await coveragesNew.ClickV2CollDedMoreOptAsync();
        await coveragesNew.ClickNextAsync();
        await coveragesNew.SetV3CompCollOnlyYESAsync(_data.Get("Coverages (New).V3_Comp/Coll Only - YES", "X"));
        await coveragesNew.ClickV3ComprehensiveAndCollisionOnlyAsync();
        await coveragesNew.VerifyV3ComprehensiveDeductibleAsync(_data.Get("Coverages (New).V3_Comprehensive Deductible", "True"));
        await coveragesNew.ClickV3CompDedAsync();
        await coveragesNew.ClickV3CompDedMoreOptAsync();
        await coveragesNew.ClickV3CollDedAsync();
        await coveragesNew.ClickV3CollDedMoreOptAsync();
        await coveragesNew.ClickNextAsync();
        await coveragesNew.SetV4CompCollOnlyYESAsync(_data.Get("Coverages (New).V4_Comp/Coll Only - YES", "X"));
        await coveragesNew.ClickV4ComprehensiveAndCollisionOnlyAsync();
        await coveragesNew.VerifyV4ComprehensiveDeductibleAsync(_data.Get("Coverages (New).V4_Comprehensive Deductible", "True"));
        await coveragesNew.ClickV4CompDedAsync();
        await coveragesNew.ClickV4CompDedMoreOptAsync();
        await coveragesNew.ClickV4CollDedAsync();
        await coveragesNew.ClickV4CollDedMoreOptAsync();
        await coveragesNew.ClickNextAsync();
        await coveragesNew.SetV1CompCollOnlyYESAsync(_data.Get("Coverages (New).V1_Comp/Coll Only - YES", "X"));
        await coveragesNew.ClickV1ComprehensiveAndCollisionOnlyAsync();
        await coveragesNew.SetV1CompDedAsync(_data.Get("Coverages (New).V1_CompDed", "X"));
        await coveragesNew.ClickV1CompDedMoreOptAsync();
        await coveragesNew.SetV1CollDedAsync(_data.Get("Coverages (New).V1_CollDed", "X"));
        await coveragesNew.ClickV1CollDedMoreOptAsync();
        await coveragesNew.SetV2CompCollOnlyYESAsync(_data.Get("Coverages (New).V2_Comp/Coll Only - YES", "X"));
        await coveragesNew.ClickV2ComprehensiveAndCollisionOnlyAsync();
        await coveragesNew.VerifyV2ComprehensiveDeductibleAsync(_data.Get("Coverages (New).V2_Comprehensive Deductible", "True"));
        await coveragesNew.SetV2CompDedAsync(_data.Get("Coverages (New).V2_CompDed", "X"));
        await coveragesNew.ClickV2CompDedMoreOptAsync();
        await coveragesNew.VerifyV3ComprehensiveDeductibleAsync(_data.Get("Coverages (New).V3_Comprehensive Deductible", "True"));
        await coveragesNew.SetV3CompDedAsync(_data.Get("Coverages (New).V3_CompDed", "X"));
        await coveragesNew.ClickV3CompDedMoreOptAsync();
        await coveragesNew.SetV2CollDedAsync(_data.Get("Coverages (New).V2_CollDed", "X"));
        await coveragesNew.ClickV2CollDedMoreOptAsync();
        await coveragesNew.ClickV4CompDedMoreOptAsync();
        await coveragesNew.SetV2CompDedAsync(_data.Get("Coverages (New).V2_CompDed", "X"));
        await coveragesNew.SetV3CompCollOnlyYESAsync(_data.Get("Coverages (New).V3_Comp/Coll Only - YES", "X"));
        await coveragesNew.ClickV3ComprehensiveAndCollisionOnlyAsync();
        await coveragesNew.VerifyV3ComprehensiveDeductibleAsync(_data.Get("Coverages (New).V3_Comprehensive Deductible", "True"));
        await coveragesNew.SetV3CompDedAsync(_data.Get("Coverages (New).V3_CompDed", "X"));
        await coveragesNew.ClickV3CompDedMoreOptAsync();
        await coveragesNew.SetV3CollDedAsync(_data.Get("Coverages (New).V3_CollDed", "X"));
        await coveragesNew.ClickV3CollDedMoreOptAsync();
        await coveragesNew.ClickV2CompDedMoreOptAsync();
        await coveragesNew.SetV4CompCollOnlyYESAsync(_data.Get("Coverages (New).V4_Comp/Coll Only - YES", "X"));
        await coveragesNew.ClickV4ComprehensiveAndCollisionOnlyAsync();
        await coveragesNew.VerifyV4ComprehensiveDeductibleAsync(_data.Get("Coverages (New).V4_Comprehensive Deductible", "True"));
        await coveragesNew.SetV4CompDedAsync(_data.Get("Coverages (New).V4_CompDed", "X"));
        await coveragesNew.ClickV4CompDedMoreOptAsync();
        await coveragesNew.SetV4CollDedAsync(_data.Get("Coverages (New).V4_CollDed", "X"));
        await coveragesNew.ClickV4CollDedMoreOptAsync();
        await coveragesNew.ClickNextAsync();
    
    
    }

    [StepDefinition("I set TCName")]
    public async Task ISetTcnameAsync()
    {
        await Task.CompletedTask;
    
    
    }

    [StepDefinition("I validate downstream policy data")]
    public async Task IValidateDownstreamPolicyDataAsync()
    {
        var eQSubmissionNEW = new EQSubmissionNEW(_browser.Page, _data);

        await eQSubmissionNEW.WaitForTransmitAsync();
        await eQSubmissionNEW.ClickTransmitAsync();
    
    
    }

    [StepDefinition("I verify the policy transmission confirmation")]
    public async Task IVerifyThePolicyTransmissionConfirmationAsync()
    {
        var eQTransmitConfirmation = new EQTransmitConfirmation(_browser.Page, _data);

        await eQTransmitConfirmation.WaitForPolicyNumberAsync();
        await eQTransmitConfirmation.StorePolicyNumberAsync("PolicyNumber");
        await eQTransmitConfirmation.SelectEffectiveDateAsync(_data.Get("EQ Transmit Confirmation.Effective Date", "{XL[Effective Date]}"));
    
    
    }
}
