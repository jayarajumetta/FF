using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.CLDC.Pages.Locators;

namespace InsuranceAutomation.CLDC.Pages;

public sealed class NavigationPage
{
    private readonly BrowserSession _browser;
    private readonly NavigationLocators _locators;
    private readonly UiActions _ui;

    public NavigationPage(BrowserSession browser, UiActions ui)
    {
        _browser = browser;
        _locators = new NavigationLocators(browser.Page);
        _ui = ui;
    }

    public Task EnterAVCostNewAsync(string value) =>
        _ui.FillAsync(_locators.AVCostNew, value, new ControlIntent("Navigation", "AVCostNew"));

    public Task PressAVCostNewAsync(string key) =>
        _ui.PressAsync(_locators.AVCostNew, key, new ControlIntent("Navigation", "AVCostNew"));

    public Task EnterAWhatIsThePublicProtectionClassRatingAsync(string value) =>
        _ui.FillAsync(_locators.AWhatIsThePublicProtectionClassRating, value, new ControlIntent("Navigation", "AWhatIsThePublicProtectionClassRating"));

    public Task PressAWhatIsThePublicProtectionClassRatingAsync(string key) =>
        _ui.PressAsync(_locators.AWhatIsThePublicProtectionClassRating, key, new ControlIntent("Navigation", "AWhatIsThePublicProtectionClassRating"));

    public Task VerifyAcceptUMAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.AcceptUM, expected, property, new ControlIntent("Navigation", "AcceptUM"));

    public Task WaitForAccountsReceivableHeadingAsync(string expected) =>
        _ui.WaitAsync(_locators.PageTitle, expected, new ControlIntent("Navigation", "AccountsReceivableHeading"));

    public Task ClickAccountsReceivableUWQuestionsAsync() =>
        _ui.ClickAsync(_locators.AccountsReceivableUWQuestions, new ControlIntent("Navigation", "AccountsReceivableUWQuestions"));

    public Task ClickAddAsync() =>
        _ui.ClickAsync(_locators.Add, new ControlIntent("Navigation", "Add"));

    public Task ClickAddAddlInterestAsync() =>
        _ui.ClickAsync(_locators.AddAddlInterest, new ControlIntent("Navigation", "AddAddlInterest"));

    public Task ClickAddBuildingAsync() =>
        _ui.ClickAsync(_locators.AddBuilding, new ControlIntent("Navigation", "AddBuilding"));

    public Task ClickAddClassAsync() =>
        _ui.ClickAsync(_locators.AddClass, new ControlIntent("Navigation", "AddClass"));

    public Task WaitForAddClassCodeAsync(string expected) =>
        _ui.WaitAsync(_locators.AddClassCode, expected, new ControlIntent("Navigation", "AddClassCode"));

    public Task ClickAddClassCodeAsync() =>
        _ui.ClickAsync(_locators.AddClassCode, new ControlIntent("Navigation", "AddClassCode"));

    public Task ClickOKAsync() =>
        _ui.ClickAsync(_locators.OK, new ControlIntent("Navigation", "OK"));

    public Task ClickAddCoverageFormAsync() =>
        _ui.ClickAsync(_locators.AddCoverageForm, new ControlIntent("Navigation", "AddCoverageForm"));

    public Task ClickAddDriverAsync() =>
        _ui.ClickAsync(_locators.AddDriver, new ControlIntent("Navigation", "AddDriver"));

    public Task EnterAddDriverNameAsync(string value) =>
        _ui.FillAsync(_locators.AddDriverName, value, new ControlIntent("Navigation", "AddDriverName"));

    public Task PressAddDriverNameAsync(string key) =>
        _ui.PressAsync(_locators.AddDriverName, key, new ControlIntent("Navigation", "AddDriverName"));

    public Task ClickEndorsementMainAddEndorsementAsync() =>
        _ui.ClickAsync(_locators.AddEndorsement, new ControlIntent("Navigation", "EndorsementMainAddEndorsement"));

    public Task WaitForEndorsementMainAddEndorsementAsync(string expected) =>
        _ui.WaitAsync(_locators.AddEndorsement, expected, new ControlIntent("Navigation", "EndorsementMainAddEndorsement"));

    public Task ClickEndorsementsAddEndorsementAsync() =>
        _ui.ClickAsync(_locators.AddEndorsement, new ControlIntent("Navigation", "EndorsementsAddEndorsement"));

    public Task ClickAddExcludedOfficerInformationAsync() =>
        _ui.ClickAsync(_locators.AddExcludedOfficerInformation, new ControlIntent("Navigation", "AddExcludedOfficerInformation"));

    public Task ClickAddExcludedOthersInformationAsync() =>
        _ui.ClickAsync(_locators.AddExcludedOthersInformation, new ControlIntent("Navigation", "AddExcludedOthersInformation"));

    public Task ClickAddGroupAsync() =>
        _ui.ClickAsync(_locators.AddGroup, new ControlIntent("Navigation", "AddGroup"));

    public Task ClickAddNotesRemarksAsync() =>
        _ui.ClickAsync(_locators.AddNotesRemarks, new ControlIntent("Navigation", "AddNotesRemarks"));

    public Task ClickAddOptionAAsync() =>
        _ui.ClickAsync(_locators.AddOptionA, new ControlIntent("Navigation", "AddOptionA"));

    public Task ClickAddOtherInterestAsync() =>
        _ui.ClickAsync(_locators.AddOtherInterest, new ControlIntent("Navigation", "AddOtherInterest"));

    public Task ClickAddOthersInformationAsync() =>
        _ui.ClickAsync(_locators.AddOthersInformation, new ControlIntent("Navigation", "AddOthersInformation"));

    public Task ClickAddPartnerInformationAsync() =>
        _ui.ClickAsync(_locators.AddPartnerInformation, new ControlIntent("Navigation", "AddPartnerInformation"));

    public Task ClickAddPremisesAsync() =>
        _ui.ClickAsync(_locators.AddPremises, new ControlIntent("Navigation", "AddPremises"));

    public Task ClickAddPriorCarrierAsync() =>
        _ui.ClickAsync(_locators.AddPriorCarrier, new ControlIntent("Navigation", "AddPriorCarrier"));

    public Task ClickAddRiskAtThisLocationAsync() =>
        _ui.ClickAsync(_locators.AddRiskAtThisLocation, new ControlIntent("Navigation", "AddRiskAtThisLocation"));

    public Task ClickAddSoleProprietorInformationAsync() =>
        _ui.ClickAsync(_locators.AddSoleProprietorInformation, new ControlIntent("Navigation", "AddSoleProprietorInformation"));

    public Task ClickAddThirdPartyAsync() =>
        _ui.ClickAsync(_locators.AddThirdParty, new ControlIntent("Navigation", "AddThirdParty"));

    public Task ClickAdditionalInterestsAsync() =>
        _ui.ClickAsync(_locators.PageTitle, new ControlIntent("Navigation", "AdditionalInterests"));

    public Task EnterAdditionalOtherInterestAddressAsync(string value) =>
        _ui.FillAsync(_locators.AdditionalOtherInterestAddress, value, new ControlIntent("Navigation", "AdditionalOtherInterestAddress"));

    public Task PressAdditionalOtherInterestAddressAsync(string key) =>
        _ui.PressAsync(_locators.AdditionalOtherInterestAddress, key, new ControlIntent("Navigation", "AdditionalOtherInterestAddress"));

    public Task WaitForAdditionalOtherInterestInputFirstNameAsync(string expected) =>
        _ui.WaitAsync(_locators.AdditionalOtherInterestInputFirstName, expected, new ControlIntent("Navigation", "AdditionalOtherInterestInputFirstName"));

    public Task EnterAdditionalOtherInterestInputFirstNameAsync(string value) =>
        _ui.FillAsync(_locators.AdditionalOtherInterestInputFirstName, value, new ControlIntent("Navigation", "AdditionalOtherInterestInputFirstName"));

    public Task PressAdditionalOtherInterestInputFirstNameAsync(string key) =>
        _ui.PressAsync(_locators.AdditionalOtherInterestInputFirstName, key, new ControlIntent("Navigation", "AdditionalOtherInterestInputFirstName"));

    public Task WaitForAdditionalOtherInterestInputLastNameAsync(string expected) =>
        _ui.WaitAsync(_locators.AdditionalOtherInterestInputLastName, expected, new ControlIntent("Navigation", "AdditionalOtherInterestInputLastName"));

    public Task WaitForAdditionalInterestsScheduleAddlInterestsAsync(string expected) =>
        _ui.WaitAsync(_locators.PageTop, expected, new ControlIntent("Navigation", "AdditionalInterestsScheduleAddlInterests"));

    public Task VerifyAdditionalInterestsScheduleAddlInterestsAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.PageTop, expected, property, new ControlIntent("Navigation", "AdditionalInterestsScheduleAddlInterests"));

    public Task WaitForSignsHeadingAsync(string expected) =>
        _ui.WaitAsync(_locators.PageTitle, expected, new ControlIntent("Navigation", "SignsHeading"));

    public Task ClickGLNavigationLinksAddlInterestsAsync() =>
        _ui.ClickAsync(_locators.PageTitle, new ControlIntent("Navigation", "GLNavigationLinksAddlInterests"));

    public Task EnterAddressAsync(string value) =>
        _ui.FillAsync(_locators.Address, value, new ControlIntent("Navigation", "Address"));

    public Task PressAddressAsync(string key) =>
        _ui.PressAsync(_locators.Address, key, new ControlIntent("Navigation", "Address"));

    public Task EnterCG2935AddLInsuredStateOrPoliticalPermitsAddressAsync(string value) =>
        _ui.FillAsync(_locators.CG2935AddLInsuredStateOrPoliticalPermitsAddress, value, new ControlIntent("Navigation", "CG2935AddLInsuredStateOrPoliticalPermitsAddress"));

    public Task PressCG2935AddLInsuredStateOrPoliticalPermitsAddressAsync(string key) =>
        _ui.PressAsync(_locators.CG2935AddLInsuredStateOrPoliticalPermitsAddress, key, new ControlIntent("Navigation", "CG2935AddLInsuredStateOrPoliticalPermitsAddress"));

    public Task EnterGLOCPRiskAddressAsync(string value) =>
        _ui.FillAsync(_locators.GLOCPRiskAddress, value, new ControlIntent("Navigation", "GLOCPRiskAddress"));

    public Task PressGLOCPRiskAddressAsync(string key) =>
        _ui.PressAsync(_locators.GLOCPRiskAddress, key, new ControlIntent("Navigation", "GLOCPRiskAddress"));

    public Task WaitForLocationAddressAsync(string expected) =>
        _ui.WaitAsync(_locators.LocationAddress, expected, new ControlIntent("Navigation", "LocationAddress"));

    public Task EnterAddressStreetCityStateZipAsync(string value) =>
        _ui.FillAsync(_locators.AddressStreetCityStateZip, value, new ControlIntent("Navigation", "AddressStreetCityStateZip"));

    public Task PressAddressStreetCityStateZipAsync(string key) =>
        _ui.PressAsync(_locators.AddressStreetCityStateZip, key, new ControlIntent("Navigation", "AddressStreetCityStateZip"));

    public Task EnterAggregateLimitAsync(string value) =>
        _ui.FillAsync(_locators.AggregateLimit, value, new ControlIntent("Navigation", "AggregateLimit"));

    public Task PressAggregateLimitAsync(string key) =>
        _ui.PressAsync(_locators.AggregateLimit, key, new ControlIntent("Navigation", "AggregateLimit"));

    public Task EnterAnnualGrossReceiptsAsync(string value) =>
        _ui.FillAsync(_locators.AnnualGrossReceipts, value, new ControlIntent("Navigation", "AnnualGrossReceipts"));

    public Task PressAnnualGrossReceiptsAsync(string key) =>
        _ui.PressAsync(_locators.AnnualGrossReceipts, key, new ControlIntent("Navigation", "AnnualGrossReceipts"));

    public Task EnterAnyPersonalAutoPolicyListingNameInsuredAsync(string value) =>
        _ui.FillAsync(_locators.AnyPersonalAutoPolicyListingNameInsured, value, new ControlIntent("Navigation", "AnyPersonalAutoPolicyListingNameInsured"));

    public Task PressAnyPersonalAutoPolicyListingNameInsuredAsync(string key) =>
        _ui.PressAsync(_locators.AnyPersonalAutoPolicyListingNameInsured, key, new ControlIntent("Navigation", "AnyPersonalAutoPolicyListingNameInsured"));

    public Task WaitForAnyVehicleCoveredRegisteredInNotPrimaryStateAsync(string expected) =>
        _ui.WaitAsync(_locators.AnyVehicleCoveredRegisteredInNotPrimaryState, expected, new ControlIntent("Navigation", "AnyVehicleCoveredRegisteredInNotPrimaryState"));

    public Task EnterAnyVehicleCoveredRegisteredInNotPrimaryStateAsync(string value) =>
        _ui.FillAsync(_locators.AnyVehicleCoveredRegisteredInNotPrimaryState, value, new ControlIntent("Navigation", "AnyVehicleCoveredRegisteredInNotPrimaryState"));

    public Task PressAnyVehicleCoveredRegisteredInNotPrimaryStateAsync(string key) =>
        _ui.PressAsync(_locators.AnyVehicleCoveredRegisteredInNotPrimaryState, key, new ControlIntent("Navigation", "AnyVehicleCoveredRegisteredInNotPrimaryState"));

    public Task EnterAreAnySignsOffPremisesOrNotAttachedToBuildingAsync(string value) =>
        _ui.FillAsync(_locators.AreAnySignsOffPremisesOrNotAttachedToBuilding, value, new ControlIntent("Navigation", "AreAnySignsOffPremisesOrNotAttachedToBuilding"));

    public Task PressAreAnySignsOffPremisesOrNotAttachedToBuildingAsync(string key) =>
        _ui.PressAsync(_locators.AreAnySignsOffPremisesOrNotAttachedToBuilding, key, new ControlIntent("Navigation", "AreAnySignsOffPremisesOrNotAttachedToBuilding"));

    public Task WaitForArePhysicalsRequiredAfterOffersOfEmploymentAreMadeAsync(string expected) =>
        _ui.WaitAsync(_locators.ArePhysicalsRequiredAfterOffersOfEmploymentAreMade, expected, new ControlIntent("Navigation", "ArePhysicalsRequiredAfterOffersOfEmploymentAreMade"));

    public Task WaitForAreThereAnyCommercialVehiclesOwnedByTheApplicantNotInsuredOnThePolicyAsync(string expected) =>
        _ui.WaitAsync(_locators.AreThereAnyCommercialVehiclesOwnedByTheApplicantNotInsuredOnThePolicy, expected, new ControlIntent("Navigation", "AreThereAnyCommercialVehiclesOwnedByTheApplicantNotInsuredOnThePolicy"));

    public Task EnterAreThereAnyCommercialVehiclesOwnedByTheApplicantNotInsuredOnThePolicyAsync(string value) =>
        _ui.FillAsync(_locators.AreThereAnyCommercialVehiclesOwnedByTheApplicantNotInsuredOnThePolicy, value, new ControlIntent("Navigation", "AreThereAnyCommercialVehiclesOwnedByTheApplicantNotInsuredOnThePolicy"));

    public Task PressAreThereAnyCommercialVehiclesOwnedByTheApplicantNotInsuredOnThePolicyAsync(string key) =>
        _ui.PressAsync(_locators.AreThereAnyCommercialVehiclesOwnedByTheApplicantNotInsuredOnThePolicy, key, new ControlIntent("Navigation", "AreThereAnyCommercialVehiclesOwnedByTheApplicantNotInsuredOnThePolicy"));

    public Task EnterAreThereAnyOfficersThatShouldBeExcludedAsync(string value) =>
        _ui.FillAsync(_locators.AreThereAnyOfficersThatShouldBeExcluded, value, new ControlIntent("Navigation", "AreThereAnyOfficersThatShouldBeExcluded"));

    public Task PressAreThereAnyOfficersThatShouldBeExcludedAsync(string key) =>
        _ui.PressAsync(_locators.AreThereAnyOfficersThatShouldBeExcluded, key, new ControlIntent("Navigation", "AreThereAnyOfficersThatShouldBeExcluded"));

    public Task WaitForAssignLocationAsync(string expected) =>
        _ui.WaitAsync(_locators.AssignLocation, expected, new ControlIntent("Navigation", "AssignLocation"));

    public Task ClickAssignLocationAsync() =>
        _ui.ClickAsync(_locators.AssignLocation, new ControlIntent("Navigation", "AssignLocation"));

    public Task WaitForAssignLocationsAsync(string expected) =>
        _ui.WaitAsync(_locators.AssignLocations, expected, new ControlIntent("Navigation", "AssignLocations"));

    public Task ClickAssignLocationsAsync() =>
        _ui.ClickAsync(_locators.AssignLocations, new ControlIntent("Navigation", "AssignLocations"));

    public Task EnterAudioVisualAsync(string value) =>
        _ui.FillAsync(_locators.AudioVisual, value, new ControlIntent("Navigation", "AudioVisual"));

    public Task PressAudioVisualAsync(string key) =>
        _ui.PressAsync(_locators.AudioVisual, key, new ControlIntent("Navigation", "AudioVisual"));

    public Task EnterAvailableClassificationsAsync(string value) =>
        _ui.FillAsync(_locators.AvailableClassifications, value, new ControlIntent("Navigation", "AvailableClassifications"));

    public Task PressAvailableClassificationsAsync(string key) =>
        _ui.PressAsync(_locators.AvailableClassifications, key, new ControlIntent("Navigation", "AvailableClassifications"));

    public Task EnterAverageNumberOfDaysServiceAsync(string value) =>
        _ui.FillAsync(_locators.AverageNumberOfDaysService, value, new ControlIntent("Navigation", "AverageNumberOfDaysService"));

    public Task PressAverageNumberOfDaysServiceAsync(string key) =>
        _ui.PressAsync(_locators.AverageNumberOfDaysService, key, new ControlIntent("Navigation", "AverageNumberOfDaysService"));

    public Task EnterAverageNumberOfWorkingDaysAsync(string value) =>
        _ui.FillAsync(_locators.AverageNumberOfWorkingDays, value, new ControlIntent("Navigation", "AverageNumberOfWorkingDays"));

    public Task PressAverageNumberOfWorkingDaysAsync(string key) =>
        _ui.PressAsync(_locators.AverageNumberOfWorkingDays, key, new ControlIntent("Navigation", "AverageNumberOfWorkingDays"));

    public Task EnterAverageServiceChargeAsync(string value) =>
        _ui.FillAsync(_locators.AverageServiceCharge, value, new ControlIntent("Navigation", "AverageServiceCharge"));

    public Task PressAverageServiceChargeAsync(string key) =>
        _ui.PressAsync(_locators.AverageServiceCharge, key, new ControlIntent("Navigation", "AverageServiceCharge"));

    public Task EnterAverageValuePerOrderAsync(string value) =>
        _ui.FillAsync(_locators.AverageValuePerOrder, value, new ControlIntent("Navigation", "AverageValuePerOrder"));

    public Task PressAverageValuePerOrderAsync(string key) =>
        _ui.PressAsync(_locators.AverageValuePerOrder, key, new ControlIntent("Navigation", "AverageValuePerOrder"));

    public Task EnterBAreThereAnyPrivateProtectionImprovementsAsync(string value) =>
        _ui.FillAsync(_locators.BAreThereAnyPrivateProtectionImprovements, value, new ControlIntent("Navigation", "BAreThereAnyPrivateProtectionImprovements"));

    public Task PressBAreThereAnyPrivateProtectionImprovementsAsync(string key) =>
        _ui.PressAsync(_locators.BAreThereAnyPrivateProtectionImprovements, key, new ControlIntent("Navigation", "BAreThereAnyPrivateProtectionImprovements"));

    public Task EnterBG2SymbolAsync(string value) =>
        _ui.FillAsync(_locators.BG2Symbol, value, new ControlIntent("Navigation", "BG2Symbol"));

    public Task PressBG2SymbolAsync(string key) =>
        _ui.PressAsync(_locators.BG2Symbol, key, new ControlIntent("Navigation", "BG2Symbol"));

    public Task EnterBG2SymbolPrefixAsync(string value) =>
        _ui.FillAsync(_locators.BG2SymbolPrefix, value, new ControlIntent("Navigation", "BG2SymbolPrefix"));

    public Task PressBG2SymbolPrefixAsync(string key) =>
        _ui.PressAsync(_locators.BG2SymbolPrefix, key, new ControlIntent("Navigation", "BG2SymbolPrefix"));

    public Task ClickBaileesCustomerUWQuestionsAsync() =>
        _ui.ClickAsync(_locators.BaileesCustomerUWQuestions, new ControlIntent("Navigation", "BaileesCustomerUWQuestions"));

    public Task WaitForBaileesCustomersHeadingAsync(string expected) =>
        _ui.WaitAsync(_locators.BaileesCustomersHeading, expected, new ControlIntent("Navigation", "BaileesCustomersHeading"));

    public Task WaitForBillTypeAsync(string expected) =>
        _ui.WaitAsync(_locators.BillType, expected, new ControlIntent("Navigation", "BillType"));

    public Task EnterBillTypeAsync(string value) =>
        _ui.FillAsync(_locators.BillType, value, new ControlIntent("Navigation", "BillType"));

    public Task PressBillTypeAsync(string key) =>
        _ui.PressAsync(_locators.BillType, key, new ControlIntent("Navigation", "BillType"));

    public Task ClickNavigationBillingAsync() =>
        _ui.ClickAsync(_locators.PageTitle, new ControlIntent("Navigation", "NavigationBilling"));

    public Task WaitForBillingAsync(string expected) =>
        _ui.WaitAsync(_locators.PageTitle, expected, new ControlIntent("Navigation", "Billing"));

    public Task EnterBodyStyleAsync(string value) =>
        _ui.FillAsync(_locators.BodyStyle, value, new ControlIntent("Navigation", "BodyStyle"));

    public Task PressBodyStyleAsync(string key) =>
        _ui.PressAsync(_locators.BodyStyle, key, new ControlIntent("Navigation", "BodyStyle"));

    public Task EnterBoomDeductibleAsync(string value) =>
        _ui.FillAsync(_locators.BoomDeductible, value, new ControlIntent("Navigation", "BoomDeductible"));

    public Task PressBoomDeductibleAsync(string key) =>
        _ui.PressAsync(_locators.BoomDeductible, key, new ControlIntent("Navigation", "BoomDeductible"));

    public Task WaitForBorrowingHiringOrLeasingWithinYearAsync(string expected) =>
        _ui.WaitAsync(_locators.BorrowingHiringOrLeasingWithinYear, expected, new ControlIntent("Navigation", "BorrowingHiringOrLeasingWithinYear"));

    public Task EnterBorrowingHiringOrLeasingWithinYearAsync(string value) =>
        _ui.FillAsync(_locators.BorrowingHiringOrLeasingWithinYear, value, new ControlIntent("Navigation", "BorrowingHiringOrLeasingWithinYear"));

    public Task PressBorrowingHiringOrLeasingWithinYearAsync(string key) =>
        _ui.PressAsync(_locators.BorrowingHiringOrLeasingWithinYear, key, new ControlIntent("Navigation", "BorrowingHiringOrLeasingWithinYear"));

    public Task ClickBuildingAsync() =>
        _ui.ClickAsync(_locators.PageTitle, new ControlIntent("Navigation", "Building"));

    public Task EnterBuildingLimitAsync(string value) =>
        _ui.FillAsync(_locators.BuildingLimit, value, new ControlIntent("Navigation", "BuildingLimit"));

    public Task PressBuildingLimitAsync(string key) =>
        _ui.PressAsync(_locators.BuildingLimit, key, new ControlIntent("Navigation", "BuildingLimit"));

    public Task EnterBuildingRatingGroupAsync(string value) =>
        _ui.FillAsync(_locators.RiskInputRatingGroupID, value, new ControlIntent("Navigation", "BuildingRatingGroup"));

    public Task PressBuildingRatingGroupAsync(string key) =>
        _ui.PressAsync(_locators.RiskInputRatingGroupID, key, new ControlIntent("Navigation", "BuildingRatingGroup"));

    public Task EnterBusinessInterruptionDescriptionOfScheduledPropertyAsync(string value) =>
        _ui.FillAsync(_locators.BusinessInterruptionDescriptionOfScheduledProperty, value, new ControlIntent("Navigation", "BusinessInterruptionDescriptionOfScheduledProperty"));

    public Task PressBusinessInterruptionDescriptionOfScheduledPropertyAsync(string key) =>
        _ui.PressAsync(_locators.BusinessInterruptionDescriptionOfScheduledProperty, key, new ControlIntent("Navigation", "BusinessInterruptionDescriptionOfScheduledProperty"));

    public Task WaitForOptionAAsync(string expected) =>
        _ui.WaitAsync(_locators.PageTop, expected, new ControlIntent("Navigation", "OptionA"));

    public Task EnterBusinessInterruptionEndorsementAsync(string value) =>
        _ui.FillAsync(_locators.BusinessInterruptionEndorsement, value, new ControlIntent("Navigation", "BusinessInterruptionEndorsement"));

    public Task PressBusinessInterruptionEndorsementAsync(string key) =>
        _ui.PressAsync(_locators.BusinessInterruptionEndorsement, key, new ControlIntent("Navigation", "BusinessInterruptionEndorsement"));

    public Task WaitForBusinessInterruptionLimitOfInsuranceAsync(string expected) =>
        _ui.WaitAsync(_locators.BusinessInterruptionLimitOfInsurance, expected, new ControlIntent("Navigation", "BusinessInterruptionLimitOfInsurance"));

    public Task EnterBusinessInterruptionLimitOfInsuranceAsync(string value) =>
        _ui.FillAsync(_locators.BusinessInterruptionLimitOfInsurance, value, new ControlIntent("Navigation", "BusinessInterruptionLimitOfInsurance"));

    public Task PressBusinessInterruptionLimitOfInsuranceAsync(string key) =>
        _ui.PressAsync(_locators.BusinessInterruptionLimitOfInsurance, key, new ControlIntent("Navigation", "BusinessInterruptionLimitOfInsurance"));

    public Task WaitForCA2325LeasedWorkersCoverageAsync(string expected) =>
        _ui.WaitAsync(_locators.CA2325LeasedWorkersCoverage, expected, new ControlIntent("Navigation", "CA2325LeasedWorkersCoverage"));

    public Task EnterCA9940ContractProvisionsAsync(string value) =>
        _ui.FillAsync(_locators.CA9940ContractProvisions, value, new ControlIntent("Navigation", "CA9940ContractProvisions"));

    public Task PressCA9940ContractProvisionsAsync(string key) =>
        _ui.PressAsync(_locators.CA9940ContractProvisions, key, new ControlIntent("Navigation", "CA9940ContractProvisions"));

    public Task EnterCA9940MakeAsync(string value) =>
        _ui.FillAsync(_locators.CA9940Make, value, new ControlIntent("Navigation", "CA9940Make"));

    public Task PressCA9940MakeAsync(string key) =>
        _ui.PressAsync(_locators.CA9940Make, key, new ControlIntent("Navigation", "CA9940Make"));

    public Task EnterCA9940ModelAsync(string value) =>
        _ui.FillAsync(_locators.CA9940Model, value, new ControlIntent("Navigation", "CA9940Model"));

    public Task PressCA9940ModelAsync(string key) =>
        _ui.PressAsync(_locators.CA9940Model, key, new ControlIntent("Navigation", "CA9940Model"));

    public Task EnterCA9940VINAsync(string value) =>
        _ui.FillAsync(_locators.CA9940VIN, value, new ControlIntent("Navigation", "CA9940VIN"));

    public Task PressCA9940VINAsync(string key) =>
        _ui.PressAsync(_locators.CA9940VIN, key, new ControlIntent("Navigation", "CA9940VIN"));

    public Task EnterCA9940YearAsync(string value) =>
        _ui.FillAsync(_locators.CA9940Year, value, new ControlIntent("Navigation", "CA9940Year"));

    public Task PressCA9940YearAsync(string key) =>
        _ui.PressAsync(_locators.CA9940Year, key, new ControlIntent("Navigation", "CA9940Year"));

    public Task EnterCA9948ClassesOfCommoditiesTransportedAsync(string value) =>
        _ui.FillAsync(_locators.CA9948ClassesOfCommoditiesTransported, value, new ControlIntent("Navigation", "CA9948ClassesOfCommoditiesTransported"));

    public Task PressCA9948ClassesOfCommoditiesTransportedAsync(string key) =>
        _ui.PressAsync(_locators.CA9948ClassesOfCommoditiesTransported, key, new ControlIntent("Navigation", "CA9948ClassesOfCommoditiesTransported"));

    public Task ClickExcludeUndergroundPropertyDamageHazardAsync() =>
        _ui.ClickAsync(_locators.ExcludeUndergroundPropertyDamageHazard, new ControlIntent("Navigation", "ExcludeUndergroundPropertyDamageHazard"));

    public Task ClickCGLAsync() =>
        _ui.ClickAsync(_locators.PageTitle, new ControlIntent("Navigation", "CGL"));

    public Task EnterCGLLimitsAsync(string value) =>
        _ui.FillAsync(_locators.CGLLimits, value, new ControlIntent("Navigation", "CGLLimits"));

    public Task PressCGLLimitsAsync(string key) =>
        _ui.PressAsync(_locators.CGLLimits, key, new ControlIntent("Navigation", "CGLLimits"));

    public Task WaitForCPPLiabilityAsync(string expected) =>
        _ui.WaitAsync(_locators.PageTitle, expected, new ControlIntent("Navigation", "CPPLiability"));

    public Task PressCPPLiabilityAsync(string key) =>
        _ui.PressAsync(_locators.PageTitle, key, new ControlIntent("Navigation", "CPPLiability"));

    public Task ClickCPPLiabilityAsync() =>
        _ui.ClickAsync(_locators.PageTitle, new ControlIntent("Navigation", "CPPLiability"));

    public Task EnterCWhatIsTheDistanceInFeetToTheNearestHydrantAsync(string value) =>
        _ui.FillAsync(_locators.CWhatIsTheDistanceInFeetToTheNearestHydrant, value, new ControlIntent("Navigation", "CWhatIsTheDistanceInFeetToTheNearestHydrant"));

    public Task PressCWhatIsTheDistanceInFeetToTheNearestHydrantAsync(string key) =>
        _ui.PressAsync(_locators.CWhatIsTheDistanceInFeetToTheNearestHydrant, key, new ControlIntent("Navigation", "CWhatIsTheDistanceInFeetToTheNearestHydrant"));

    public Task ClickCallISOAsync() =>
        _ui.ClickAsync(_locators.CallISO, new ControlIntent("Navigation", "CallISO"));

    public Task WaitForCarrierAsync(string expected) =>
        _ui.WaitAsync(_locators.Carrier, expected, new ControlIntent("Navigation", "Carrier"));

    public Task EnterCarrierAsync(string value) =>
        _ui.FillAsync(_locators.Carrier, value, new ControlIntent("Navigation", "Carrier"));

    public Task PressCarrierAsync(string key) =>
        _ui.PressAsync(_locators.Carrier, key, new ControlIntent("Navigation", "Carrier"));

    public Task EnterCauseOfLossAsync(string value) =>
        _ui.FillAsync(_locators.CauseOfLoss, value, new ControlIntent("Navigation", "CauseOfLoss"));

    public Task PressCauseOfLossAsync(string key) =>
        _ui.PressAsync(_locators.CauseOfLoss, key, new ControlIntent("Navigation", "CauseOfLoss"));

    public Task EnterCityAsync(string value) =>
        _ui.FillAsync(_locators.City, value, new ControlIntent("Navigation", "City"));

    public Task PressCityAsync(string key) =>
        _ui.PressAsync(_locators.City, key, new ControlIntent("Navigation", "City"));

    public Task EnterClassCodeAsync(string value) =>
        _ui.FillAsync(_locators.ClassCode, value, new ControlIntent("Navigation", "ClassCode"));

    public Task PressClassCodeAsync(string key) =>
        _ui.PressAsync(_locators.ClassCode, key, new ControlIntent("Navigation", "ClassCode"));

    public Task WaitForClassCodeFrameAsync(string expected) =>
        _ui.WaitAsync(_locators.ClassCodeFrame, expected, new ControlIntent("Navigation", "ClassCodeFrame"));

    public Task EnterClassCodeFrameClassCodeWindowAsync(string value) =>
        _ui.FillAsync(_locators.ClassCodeFrameClassCodeWindow, value, new ControlIntent("Navigation", "ClassCodeFrameClassCodeWindow"));

    public Task EnterClassificationOfRiskAsync(string value) =>
        _ui.FillAsync(_locators.ClassificationOfRisk, value, new ControlIntent("Navigation", "ClassificationOfRisk"));

    public Task PressClassificationOfRiskAsync(string key) =>
        _ui.PressAsync(_locators.ClassificationOfRisk, key, new ControlIntent("Navigation", "ClassificationOfRisk"));

    public Task WaitForClickAddEndorsementAsync(string expected) =>
        _ui.WaitAsync(_locators.AddEndorsement, expected, new ControlIntent("Navigation", "ClickAddEndorsement"));

    public Task ClickClickAddEndorsementAsync() =>
        _ui.ClickAsync(_locators.AddEndorsement, new ControlIntent("Navigation", "ClickAddEndorsement"));

    public Task WaitForClickAddExcludedDriverAsync(string expected) =>
        _ui.WaitAsync(_locators.ClickAddExcludedDriver, expected, new ControlIntent("Navigation", "ClickAddExcludedDriver"));

    public Task ClickClickAddExcludedDriverAsync() =>
        _ui.ClickAsync(_locators.ClickAddExcludedDriver, new ControlIntent("Navigation", "ClickAddExcludedDriver"));

    public Task WaitForAddClientAsync(string expected) =>
        _ui.WaitAsync(_locators.AddClient, expected, new ControlIntent("Navigation", "AddClient"));

    public Task VerifyAddClientAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.AddClient, expected, property, new ControlIntent("Navigation", "AddClient"));

    public Task EnterAddClientAsync(string value) =>
        _ui.FillAsync(_locators.AddClient, value, new ControlIntent("Navigation", "AddClient"));

    public Task ClickAddClientAsync() =>
        _ui.ClickAsync(_locators.AddClient, new ControlIntent("Navigation", "AddClient"));

    public Task EnterPolicyCovgComputerSystemsCoinsuranceAsync(string value) =>
        _ui.FillAsync(_locators.PolicyCovgComputerSystemsCoinsurance, value, new ControlIntent("Navigation", "PolicyCovgComputerSystemsCoinsurance"));

    public Task PressPolicyCovgComputerSystemsCoinsuranceAsync(string key) =>
        _ui.PressAsync(_locators.PolicyCovgComputerSystemsCoinsurance, key, new ControlIntent("Navigation", "PolicyCovgComputerSystemsCoinsurance"));

    public Task EnterRatingGroupsCoinsuranceAsync(string value) =>
        _ui.FillAsync(_locators.RatingGroupsCoinsurance, value, new ControlIntent("Navigation", "RatingGroupsCoinsurance"));

    public Task PressRatingGroupsCoinsuranceAsync(string key) =>
        _ui.PressAsync(_locators.RatingGroupsCoinsurance, key, new ControlIntent("Navigation", "RatingGroupsCoinsurance"));

    public Task EnterPolicyCovgContractorsEquipmentCoinsuranceAsync(string value) =>
        _ui.FillAsync(_locators.PolicyCovgContractorsEquipmentCoinsurance, value, new ControlIntent("Navigation", "PolicyCovgContractorsEquipmentCoinsurance"));

    public Task PressPolicyCovgContractorsEquipmentCoinsuranceAsync(string key) =>
        _ui.PressAsync(_locators.PolicyCovgContractorsEquipmentCoinsurance, key, new ControlIntent("Navigation", "PolicyCovgContractorsEquipmentCoinsurance"));

    public Task ClickCollisionAsync() =>
        _ui.ClickAsync(_locators.Collision, new ControlIntent("Navigation", "Collision"));

    public Task VerifyCollisionCoverageAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.CollisionCoverage, expected, property, new ControlIntent("Navigation", "CollisionCoverage"));

    public Task EnterCollisionCoverageAsync(string value) =>
        _ui.FillAsync(_locators.CollisionCoverage, value, new ControlIntent("Navigation", "CollisionCoverage"));

    public Task PressCollisionCoverageAsync(string key) =>
        _ui.PressAsync(_locators.CollisionCoverage, key, new ControlIntent("Navigation", "CollisionCoverage"));

    public Task WaitForCollisionDeductibleAsync(string expected) =>
        _ui.WaitAsync(_locators.CollisionDeductible, expected, new ControlIntent("Navigation", "CollisionDeductible"));

    public Task EnterHiredAutoCollisionDeductibleAsync(string value) =>
        _ui.FillAsync(_locators.HiredAutoCollisionDeductible, value, new ControlIntent("Navigation", "HiredAutoCollisionDeductible"));

    public Task PressHiredAutoCollisionDeductibleAsync(string key) =>
        _ui.PressAsync(_locators.HiredAutoCollisionDeductible, key, new ControlIntent("Navigation", "HiredAutoCollisionDeductible"));

    public Task ClickStateDetailsHiredAutoPDWithoutDriverIfAnyAsync() =>
        _ui.ClickAsync(_locators.StateDetailsHiredAutoPDWithoutDriverIfAny, new ControlIntent("Navigation", "StateDetailsHiredAutoPDWithoutDriverIfAny"));

    public Task ClickStateDetailsHiredAutoPhysicalDamageWithDriverIfAnyAsync() =>
        _ui.ClickAsync(_locators.StateDetailsHiredAutoPhysicalDamageWithDriverIfAny, new ControlIntent("Navigation", "StateDetailsHiredAutoPhysicalDamageWithDriverIfAny"));

    public Task ClickCommercialAutoAsync() =>
        _ui.ClickAsync(_locators.CommercialAuto, new ControlIntent("Navigation", "CommercialAuto"));

    public Task ClickCommonNavigationLinksNextAsync() =>
        _ui.ClickAsync(_locators.CommonNavigationLinksNext, new ControlIntent("Navigation", "CommonNavigationLinksNext"));

    public Task EnterCompanyNameAsync(string value) =>
        _ui.FillAsync(_locators.CompanyName, value, new ControlIntent("Navigation", "CompanyName"));

    public Task PressCompanyNameAsync(string key) =>
        _ui.PressAsync(_locators.CompanyName, key, new ControlIntent("Navigation", "CompanyName"));

    public Task ClickComprehensiveAsync() =>
        _ui.ClickAsync(_locators.Comprehensive, new ControlIntent("Navigation", "Comprehensive"));

    public Task EnterComputerEquipmentAsync(string value) =>
        _ui.FillAsync(_locators.ComputerEquipment, value, new ControlIntent("Navigation", "ComputerEquipment"));

    public Task PressComputerEquipmentAsync(string key) =>
        _ui.PressAsync(_locators.ComputerEquipment, key, new ControlIntent("Navigation", "ComputerEquipment"));

    public Task ClickComputerSystemsUWQuestionsAsync() =>
        _ui.ClickAsync(_locators.ComputerSystemsUWQuestions, new ControlIntent("Navigation", "ComputerSystemsUWQuestions"));

    public Task EnterBuildingDetailConstructionAsync(string value) =>
        _ui.FillAsync(_locators.BuildingDetailConstruction, value, new ControlIntent("Navigation", "BuildingDetailConstruction"));

    public Task PressBuildingDetailConstructionAsync(string key) =>
        _ui.PressAsync(_locators.BuildingDetailConstruction, key, new ControlIntent("Navigation", "BuildingDetailConstruction"));

    public Task EnterRiskBaileesCustomersConstructionAsync(string value) =>
        _ui.FillAsync(_locators.RiskBaileesCustomersConstruction, value, new ControlIntent("Navigation", "RiskBaileesCustomersConstruction"));

    public Task PressRiskBaileesCustomersConstructionAsync(string key) =>
        _ui.PressAsync(_locators.RiskBaileesCustomersConstruction, key, new ControlIntent("Navigation", "RiskBaileesCustomersConstruction"));

    public Task EnterConstructionCodeAsync(string value) =>
        _ui.FillAsync(_locators.ConstructionCode, value, new ControlIntent("Navigation", "ConstructionCode"));

    public Task PressConstructionCodeAsync(string key) =>
        _ui.PressAsync(_locators.ConstructionCode, key, new ControlIntent("Navigation", "ConstructionCode"));

    public Task EnterRiskAccountsReceivableConstructionAsync(string value) =>
        _ui.FillAsync(_locators.RiskAccountsReceivableConstruction, value, new ControlIntent("Navigation", "RiskAccountsReceivableConstruction"));

    public Task PressRiskAccountsReceivableConstructionAsync(string key) =>
        _ui.PressAsync(_locators.RiskAccountsReceivableConstruction, key, new ControlIntent("Navigation", "RiskAccountsReceivableConstruction"));

    public Task ClickContractorsEquipmentUWQuestionsAsync() =>
        _ui.ClickAsync(_locators.ContractorsEquipmentUWQuestions, new ControlIntent("Navigation", "ContractorsEquipmentUWQuestions"));

    public Task WaitForCoverageBeginDateAsync(string expected) =>
        _ui.WaitAsync(_locators.CoverageBeginDate, expected, new ControlIntent("Navigation", "CoverageBeginDate"));

    public Task EnterCoverageEndDateAsync(string value) =>
        _ui.FillAsync(_locators.CoverageEndDate, value, new ControlIntent("Navigation", "CoverageEndDate"));

    public Task PressCoverageEndDateAsync(string key) =>
        _ui.PressAsync(_locators.CoverageEndDate, key, new ControlIntent("Navigation", "CoverageEndDate"));

    public Task WaitForPolicyCovgGLCoverageFormAsync(string expected) =>
        _ui.WaitAsync(_locators.PolicyCovgGLCoverageForm, expected, new ControlIntent("Navigation", "PolicyCovgGLCoverageForm"));

    public Task EnterPolicyCovgGLCoverageFormAsync(string value) =>
        _ui.FillAsync(_locators.PolicyCovgGLCoverageForm, value, new ControlIntent("Navigation", "PolicyCovgGLCoverageForm"));

    public Task PressPolicyCovgGLCoverageFormAsync(string key) =>
        _ui.PressAsync(_locators.PolicyCovgGLCoverageForm, key, new ControlIntent("Navigation", "PolicyCovgGLCoverageForm"));

    public Task VerifyPolicyCovgSignsCoverageFormAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.PolicyCovgSignsCoverageForm, expected, property, new ControlIntent("Navigation", "PolicyCovgSignsCoverageForm"));

    public Task EnterRiskMainCoverageFormAsync(string value) =>
        _ui.FillAsync(_locators.RiskMainCoverageForm, value, new ControlIntent("Navigation", "RiskMainCoverageForm"));

    public Task PressRiskMainCoverageFormAsync(string key) =>
        _ui.PressAsync(_locators.RiskMainCoverageForm, key, new ControlIntent("Navigation", "RiskMainCoverageForm"));

    public Task WaitForPolicyCovgComputerSystemsCoverageFormDisplayAsync(string expected) =>
        _ui.WaitAsync(_locators.PolicyCovgComputerSystemsCoverageFormDisplay, expected, new ControlIntent("Navigation", "PolicyCovgComputerSystemsCoverageFormDisplay"));

    public Task WaitForPolicyCovgBaileesCutomersCoverageFormDisplayAsync(string expected) =>
        _ui.WaitAsync(_locators.PolicyCovgBaileesCutomersCoverageFormDisplay, expected, new ControlIntent("Navigation", "PolicyCovgBaileesCutomersCoverageFormDisplay"));

    public Task WaitForPolicyCovgMotorTruckCargoCoverageFormDisplayAsync(string expected) =>
        _ui.WaitAsync(_locators.PolicyCovgMotorTruckCargoCoverageFormDisplay, expected, new ControlIntent("Navigation", "PolicyCovgMotorTruckCargoCoverageFormDisplay"));

    public Task WaitForPolicyCovgSignsCoverageFormDisplayAsync(string expected) =>
        _ui.WaitAsync(_locators.PolicyCovgSignsCoverageFormDisplay, expected, new ControlIntent("Navigation", "PolicyCovgSignsCoverageFormDisplay"));

    public Task WaitForPolicyCovgContractorsEquipmentCoverageFormDisplayAsync(string expected) =>
        _ui.WaitAsync(_locators.PolicyCovgContractorsEquipmentCoverageFormDisplay, expected, new ControlIntent("Navigation", "PolicyCovgContractorsEquipmentCoverageFormDisplay"));

    public Task EnterCoverageFormToBeAddedAsync(string value) =>
        _ui.FillAsync(_locators.CoverageFormToBeAdded, value, new ControlIntent("Navigation", "CoverageFormToBeAdded"));

    public Task PressCoverageFormToBeAddedAsync(string key) =>
        _ui.PressAsync(_locators.CoverageFormToBeAdded, key, new ControlIntent("Navigation", "CoverageFormToBeAdded"));

    public Task EnterCoverageTypeAsync(string value) =>
        _ui.FillAsync(_locators.CoverageType, value, new ControlIntent("Navigation", "CoverageType"));

    public Task PressCoverageTypeAsync(string key) =>
        _ui.PressAsync(_locators.CoverageType, key, new ControlIntent("Navigation", "CoverageType"));

    public Task EnterCoveredPropertyConsistingPrincipallyOfAsync(string value) =>
        _ui.FillAsync(_locators.CoveredPropertyConsistingPrincipallyOf, value, new ControlIntent("Navigation", "CoveredPropertyConsistingPrincipallyOf"));

    public Task PressCoveredPropertyConsistingPrincipallyOfAsync(string key) =>
        _ui.PressAsync(_locators.CoveredPropertyConsistingPrincipallyOf, key, new ControlIntent("Navigation", "CoveredPropertyConsistingPrincipallyOf"));

    public Task ClickCreateValuationAsync() =>
        _ui.ClickAsync(_locators.CreateValuation, new ControlIntent("Navigation", "CreateValuation"));

    public Task EnterDWhatIsTheDistanceInMilesToTheNearestRespondingFireDepartmentAsync(string value) =>
        _ui.FillAsync(_locators.DWhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment, value, new ControlIntent("Navigation", "DWhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment"));

    public Task PressDWhatIsTheDistanceInMilesToTheNearestRespondingFireDepartmentAsync(string key) =>
        _ui.PressAsync(_locators.DWhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment, key, new ControlIntent("Navigation", "DWhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment"));

    public Task EnterDataAndMediaAsync(string value) =>
        _ui.FillAsync(_locators.DataAndMedia, value, new ControlIntent("Navigation", "DataAndMedia"));

    public Task PressDataAndMediaAsync(string key) =>
        _ui.PressAsync(_locators.DataAndMedia, key, new ControlIntent("Navigation", "DataAndMedia"));

    public Task EnterDateOfBirthAsync(string value) =>
        _ui.FillAsync(_locators.DateOfBirth, value, new ControlIntent("Navigation", "DateOfBirth"));

    public Task PressDateOfBirthAsync(string key) =>
        _ui.PressAsync(_locators.DateOfBirth, key, new ControlIntent("Navigation", "DateOfBirth"));

    public Task EnterDateOfHireAsync(string value) =>
        _ui.FillAsync(_locators.DateOfHire, value, new ControlIntent("Navigation", "DateOfHire"));

    public Task PressDateOfHireAsync(string key) =>
        _ui.PressAsync(_locators.DateOfHire, key, new ControlIntent("Navigation", "DateOfHire"));

    public Task EnterDebrisRemovalAdditionalAsync(string value) =>
        _ui.FillAsync(_locators.DebrisRemovalAdditional, value, new ControlIntent("Navigation", "DebrisRemovalAdditional"));

    public Task PressDebrisRemovalAdditionalAsync(string key) =>
        _ui.PressAsync(_locators.DebrisRemovalAdditional, key, new ControlIntent("Navigation", "DebrisRemovalAdditional"));

    public Task EnterDebrisRemovalAdditionalLimitAsync(string value) =>
        _ui.FillAsync(_locators.DebrisRemovalAdditionalLimit, value, new ControlIntent("Navigation", "DebrisRemovalAdditionalLimit"));

    public Task PressDebrisRemovalAdditionalLimitAsync(string key) =>
        _ui.PressAsync(_locators.DebrisRemovalAdditionalLimit, key, new ControlIntent("Navigation", "DebrisRemovalAdditionalLimit"));

    public Task EnterDedTypeAsync(string value) =>
        _ui.FillAsync(_locators.DedType, value, new ControlIntent("Navigation", "DedType"));

    public Task PressDedTypeAsync(string key) =>
        _ui.PressAsync(_locators.DedType, key, new ControlIntent("Navigation", "DedType"));

    public Task EnterDedicatedLineAsync(string value) =>
        _ui.FillAsync(_locators.DedicatedLine, value, new ControlIntent("Navigation", "DedicatedLine"));

    public Task PressDedicatedLineAsync(string key) =>
        _ui.PressAsync(_locators.DedicatedLine, key, new ControlIntent("Navigation", "DedicatedLine"));

    public Task EnterRatingGroupsDeductibleAsync(string value) =>
        _ui.FillAsync(_locators.RatingGroupsDeductible, value, new ControlIntent("Navigation", "RatingGroupsDeductible"));

    public Task PressRatingGroupsDeductibleAsync(string key) =>
        _ui.PressAsync(_locators.RatingGroupsDeductible, key, new ControlIntent("Navigation", "RatingGroupsDeductible"));

    public Task EnterEndorsementIF0002WaterborneEquipmentDeductibleAsync(string value) =>
        _ui.FillAsync(_locators.EndorsementIF0002WaterborneEquipmentDeductible, value, new ControlIntent("Navigation", "EndorsementIF0002WaterborneEquipmentDeductible"));

    public Task PressEndorsementIF0002WaterborneEquipmentDeductibleAsync(string key) =>
        _ui.PressAsync(_locators.EndorsementIF0002WaterborneEquipmentDeductible, key, new ControlIntent("Navigation", "EndorsementIF0002WaterborneEquipmentDeductible"));

    public Task EnterPolicyCovgMotorTruckCargoDeductibleAsync(string value) =>
        _ui.FillAsync(_locators.PolicyCovgMotorTruckCargoDeductible, value, new ControlIntent("Navigation", "PolicyCovgMotorTruckCargoDeductible"));

    public Task PressPolicyCovgMotorTruckCargoDeductibleAsync(string key) =>
        _ui.PressAsync(_locators.PolicyCovgMotorTruckCargoDeductible, key, new ControlIntent("Navigation", "PolicyCovgMotorTruckCargoDeductible"));

    public Task EnterRiskBaileesCustomersDeductibleAsync(string value) =>
        _ui.FillAsync(_locators.RiskBaileesCustomersDeductible, value, new ControlIntent("Navigation", "RiskBaileesCustomersDeductible"));

    public Task PressRiskBaileesCustomersDeductibleAsync(string key) =>
        _ui.PressAsync(_locators.RiskBaileesCustomersDeductible, key, new ControlIntent("Navigation", "RiskBaileesCustomersDeductible"));

    public Task EnterBuildingDetailDeductibleAsync(string value) =>
        _ui.FillAsync(_locators.BuildingDetailDeductible, value, new ControlIntent("Navigation", "BuildingDetailDeductible"));

    public Task PressBuildingDetailDeductibleAsync(string key) =>
        _ui.PressAsync(_locators.BuildingDetailDeductible, key, new ControlIntent("Navigation", "BuildingDetailDeductible"));

    public Task EnterDeductibleBasisAsync(string value) =>
        _ui.FillAsync(_locators.DeductibleBasis, value, new ControlIntent("Navigation", "DeductibleBasis"));

    public Task PressDeductibleBasisAsync(string key) =>
        _ui.PressAsync(_locators.DeductibleBasis, key, new ControlIntent("Navigation", "DeductibleBasis"));

    public Task EnterPolicyCovgContractorsEquipmentDeductibleAsync(string value) =>
        _ui.FillAsync(_locators.PolicyCovgContractorsEquipmentDeductible, value, new ControlIntent("Navigation", "PolicyCovgContractorsEquipmentDeductible"));

    public Task PressPolicyCovgContractorsEquipmentDeductibleAsync(string key) =>
        _ui.PressAsync(_locators.PolicyCovgContractorsEquipmentDeductible, key, new ControlIntent("Navigation", "PolicyCovgContractorsEquipmentDeductible"));

    public Task EnterPolicyCovgComputerSystemsDeductibleAsync(string value) =>
        _ui.FillAsync(_locators.PolicyCovgComputerSystemsDeductible, value, new ControlIntent("Navigation", "PolicyCovgComputerSystemsDeductible"));

    public Task PressPolicyCovgComputerSystemsDeductibleAsync(string key) =>
        _ui.PressAsync(_locators.PolicyCovgComputerSystemsDeductible, key, new ControlIntent("Navigation", "PolicyCovgComputerSystemsDeductible"));

    public Task EnterBuildingDetailDeductibleIncreasedTheftAsync(string value) =>
        _ui.FillAsync(_locators.BuildingDetailDeductibleIncreasedTheft, value, new ControlIntent("Navigation", "BuildingDetailDeductibleIncreasedTheft"));

    public Task PressBuildingDetailDeductibleIncreasedTheftAsync(string key) =>
        _ui.PressAsync(_locators.BuildingDetailDeductibleIncreasedTheft, key, new ControlIntent("Navigation", "BuildingDetailDeductibleIncreasedTheft"));

    public Task EnterRatingGroupsDeductibleIncreasedTheftAsync(string value) =>
        _ui.FillAsync(_locators.RatingGroupsDeductibleIncreasedTheft, value, new ControlIntent("Navigation", "RatingGroupsDeductibleIncreasedTheft"));

    public Task PressRatingGroupsDeductibleIncreasedTheftAsync(string key) =>
        _ui.PressAsync(_locators.RatingGroupsDeductibleIncreasedTheft, key, new ControlIntent("Navigation", "RatingGroupsDeductibleIncreasedTheft"));

    public Task EnterBuildingDetailDeductibleWindHailAsync(string value) =>
        _ui.FillAsync(_locators.BuildingDetailDeductibleWindHail, value, new ControlIntent("Navigation", "BuildingDetailDeductibleWindHail"));

    public Task PressBuildingDetailDeductibleWindHailAsync(string key) =>
        _ui.PressAsync(_locators.BuildingDetailDeductibleWindHail, key, new ControlIntent("Navigation", "BuildingDetailDeductibleWindHail"));

    public Task EnterRatingGroupsDeductibleWindHailAsync(string value) =>
        _ui.FillAsync(_locators.RatingGroupsDeductibleWindHail, value, new ControlIntent("Navigation", "RatingGroupsDeductibleWindHail"));

    public Task PressRatingGroupsDeductibleWindHailAsync(string key) =>
        _ui.PressAsync(_locators.RatingGroupsDeductibleWindHail, key, new ControlIntent("Navigation", "RatingGroupsDeductibleWindHail"));

    public Task EnterDefaultExpModTypeAsync(string value) =>
        _ui.FillAsync(_locators.DefaultExpModType, value, new ControlIntent("Navigation", "DefaultExpModType"));

    public Task PressDefaultExpModTypeAsync(string key) =>
        _ui.PressAsync(_locators.DefaultExpModType, key, new ControlIntent("Navigation", "DefaultExpModType"));

    public Task<string> CaptureDefaultExperienceModAsync(string property = "") =>
        _ui.CaptureAsync(_locators.DefaultExperienceMod, property, new ControlIntent("Navigation", "DefaultExperienceMod"));

    public Task EnterDescribeAllHoldHarmlessAgreementsAndPleaseProvideACopyAsync(string value) =>
        _ui.FillAsync(_locators.DescribeAllHoldHarmlessAgreementsAndPleaseProvideACopy, value, new ControlIntent("Navigation", "DescribeAllHoldHarmlessAgreementsAndPleaseProvideACopy"));

    public Task PressDescribeAllHoldHarmlessAgreementsAndPleaseProvideACopyAsync(string key) =>
        _ui.PressAsync(_locators.DescribeAllHoldHarmlessAgreementsAndPleaseProvideACopy, key, new ControlIntent("Navigation", "DescribeAllHoldHarmlessAgreementsAndPleaseProvideACopy"));

    public Task EnterPolicyCovgContractorsEquipmentDescriptionAsync(string value) =>
        _ui.FillAsync(_locators.PolicyCovgContractorsEquipmentDescription, value, new ControlIntent("Navigation", "PolicyCovgContractorsEquipmentDescription"));

    public Task PressPolicyCovgContractorsEquipmentDescriptionAsync(string key) =>
        _ui.PressAsync(_locators.PolicyCovgContractorsEquipmentDescription, key, new ControlIntent("Navigation", "PolicyCovgContractorsEquipmentDescription"));

    public Task EnterPolicyCovgBaileesCutomersDescriptionAsync(string value) =>
        _ui.FillAsync(_locators.PolicyCovgBaileesCutomersDescription, value, new ControlIntent("Navigation", "PolicyCovgBaileesCutomersDescription"));

    public Task PressPolicyCovgBaileesCutomersDescriptionAsync(string key) =>
        _ui.PressAsync(_locators.PolicyCovgBaileesCutomersDescription, key, new ControlIntent("Navigation", "PolicyCovgBaileesCutomersDescription"));

    public Task EnterPolicyCovgComputerSystemsDescriptionAsync(string value) =>
        _ui.FillAsync(_locators.PolicyCovgComputerSystemsDescription, value, new ControlIntent("Navigation", "PolicyCovgComputerSystemsDescription"));

    public Task PressPolicyCovgComputerSystemsDescriptionAsync(string key) =>
        _ui.PressAsync(_locators.PolicyCovgComputerSystemsDescription, key, new ControlIntent("Navigation", "PolicyCovgComputerSystemsDescription"));

    public Task EnterRatingGroupsDescriptionAsync(string value) =>
        _ui.FillAsync(_locators.RatingGroupsDescription, value, new ControlIntent("Navigation", "RatingGroupsDescription"));

    public Task PressRatingGroupsDescriptionAsync(string key) =>
        _ui.PressAsync(_locators.RatingGroupsDescription, key, new ControlIntent("Navigation", "RatingGroupsDescription"));

    public Task EnterPolicyCovgSignsDescriptionAsync(string value) =>
        _ui.FillAsync(_locators.PolicyCovgSignsDescription, value, new ControlIntent("Navigation", "PolicyCovgSignsDescription"));

    public Task PressPolicyCovgSignsDescriptionAsync(string key) =>
        _ui.PressAsync(_locators.PolicyCovgSignsDescription, key, new ControlIntent("Navigation", "PolicyCovgSignsDescription"));

    public Task EnterPolicyCovgMotorTruckCargoDescriptionAsync(string value) =>
        _ui.FillAsync(_locators.PolicyCovgMotorTruckCargoDescription, value, new ControlIntent("Navigation", "PolicyCovgMotorTruckCargoDescription"));

    public Task PressPolicyCovgMotorTruckCargoDescriptionAsync(string key) =>
        _ui.PressAsync(_locators.PolicyCovgMotorTruckCargoDescription, key, new ControlIntent("Navigation", "PolicyCovgMotorTruckCargoDescription"));

    public Task EnterDescriptionOfBusinessActivitesAsync(string value) =>
        _ui.FillAsync(_locators.DescriptionOfBusinessActivites, value, new ControlIntent("Navigation", "DescriptionOfBusinessActivites"));

    public Task PressDescriptionOfBusinessActivitesAsync(string key) =>
        _ui.PressAsync(_locators.DescriptionOfBusinessActivites, key, new ControlIntent("Navigation", "DescriptionOfBusinessActivites"));

    public Task EnterDescriptionOfOperationSAsync(string value) =>
        _ui.FillAsync(_locators.DescriptionOfOperationS, value, new ControlIntent("Navigation", "DescriptionOfOperationS"));

    public Task PressDescriptionOfOperationSAsync(string key) =>
        _ui.PressAsync(_locators.DescriptionOfOperationS, key, new ControlIntent("Navigation", "DescriptionOfOperationS"));

    public Task EnterDescriptionOfOperationsAsync(string value) =>
        _ui.FillAsync(_locators.DescriptionOfOperations, value, new ControlIntent("Navigation", "DescriptionOfOperations"));

    public Task PressDescriptionOfOperationsAsync(string key) =>
        _ui.PressAsync(_locators.DescriptionOfOperations, key, new ControlIntent("Navigation", "DescriptionOfOperations"));

    public Task WaitForDescriptionOfSpecifiedOperationAsync(string expected) =>
        _ui.WaitAsync(_locators.DescriptionOfSpecifiedOperation, expected, new ControlIntent("Navigation", "DescriptionOfSpecifiedOperation"));

    public Task VerifyDescriptionOfSpecifiedOperationAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.DescriptionOfSpecifiedOperation, expected, property, new ControlIntent("Navigation", "DescriptionOfSpecifiedOperation"));

    public Task EnterDescriptionOfSpecifiedOperationAsync(string value) =>
        _ui.FillAsync(_locators.DescriptionOfSpecifiedOperation, value, new ControlIntent("Navigation", "DescriptionOfSpecifiedOperation"));

    public Task PressDescriptionOfSpecifiedOperationAsync(string key) =>
        _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, key, new ControlIntent("Navigation", "DescriptionOfSpecifiedOperation"));

    public Task ClickDesignatedWorkplacesExclusionOKAsync() =>
        _ui.ClickAsync(_locators.DesignatedWorkplacesExclusionOK, new ControlIntent("Navigation", "DesignatedWorkplacesExclusionOK"));

    public Task WaitForUnderwritingInfoOtherInsuranceHistoryDetailAsync(string expected) =>
        _ui.WaitAsync(_locators.Select, expected, new ControlIntent("Navigation", "UnderwritingInfoOtherInsuranceHistoryDetail"));

    public Task ClickLocationDetailAsync() =>
        _ui.ClickAsync(_locators.PageTitle, new ControlIntent("Navigation", "LocationDetail"));

    public Task WaitForLocationDetailAsync(string expected) =>
        _ui.WaitAsync(_locators.PageTitle, expected, new ControlIntent("Navigation", "LocationDetail"));

    public Task EnterDoYouHaveACDLLicenseAsync(string value) =>
        _ui.FillAsync(_locators.DoYouHaveACDLLicense, value, new ControlIntent("Navigation", "DoYouHaveACDLLicense"));

    public Task PressDoYouHaveACDLLicenseAsync(string key) =>
        _ui.PressAsync(_locators.DoYouHaveACDLLicense, key, new ControlIntent("Navigation", "DoYouHaveACDLLicense"));

    public Task EnterDoesAnyRiskGeneratePowerOtherThanPrivateWindmillsOrEmergencyBackupAsync(string value) =>
        _ui.FillAsync(_locators.DoesAnyRiskGeneratePowerOtherThanPrivateWindmillsOrEmergencyBackup, value, new ControlIntent("Navigation", "DoesAnyRiskGeneratePowerOtherThanPrivateWindmillsOrEmergencyBackup"));

    public Task PressDoesAnyRiskGeneratePowerOtherThanPrivateWindmillsOrEmergencyBackupAsync(string key) =>
        _ui.PressAsync(_locators.DoesAnyRiskGeneratePowerOtherThanPrivateWindmillsOrEmergencyBackup, key, new ControlIntent("Navigation", "DoesAnyRiskGeneratePowerOtherThanPrivateWindmillsOrEmergencyBackup"));

    public Task EnterDoesTheApplicantWishToCoverAnySignsInsideTheirPremisesAsync(string value) =>
        _ui.FillAsync(_locators.DoesTheApplicantWishToCoverAnySignsInsideTheirPremises, value, new ControlIntent("Navigation", "DoesTheApplicantWishToCoverAnySignsInsideTheirPremises"));

    public Task PressDoesTheApplicantWishToCoverAnySignsInsideTheirPremisesAsync(string key) =>
        _ui.PressAsync(_locators.DoesTheApplicantWishToCoverAnySignsInsideTheirPremises, key, new ControlIntent("Navigation", "DoesTheApplicantWishToCoverAnySignsInsideTheirPremises"));

    public Task EnterDoesTheInsuredApplicantRequestAdditionalInsuredStatusWithoutAWrittenContractRequirementAsync(string value) =>
        _ui.FillAsync(_locators.DoesTheInsuredApplicantRequestAdditionalInsuredStatusWithoutAWrittenContractRequirement, value, new ControlIntent("Navigation", "DoesTheInsuredApplicantRequestAdditionalInsuredStatusWithoutAWrittenContractRequirement"));

    public Task PressDoesTheInsuredApplicantRequestAdditionalInsuredStatusWithoutAWrittenContractRequirementAsync(string key) =>
        _ui.PressAsync(_locators.DoesTheInsuredApplicantRequestAdditionalInsuredStatusWithoutAWrittenContractRequirement, key, new ControlIntent("Navigation", "DoesTheInsuredApplicantRequestAdditionalInsuredStatusWithoutAWrittenContractRequirement"));

    public Task EnterDoesTheInsuredEnterIntoContractsInvolvingCommercialSnowRemovalIncludingSnowRemovalFromResidentialRoofsAsync(string value) =>
        _ui.FillAsync(_locators.DoesTheInsuredEnterIntoContractsInvolvingCommercialSnowRemovalIncludingSnowRemovalFromResidentialRoofs, value, new ControlIntent("Navigation", "DoesTheInsuredEnterIntoContractsInvolvingCommercialSnowRemovalIncludingSnowRemovalFromResidentialRoofs"));

    public Task PressDoesTheInsuredEnterIntoContractsInvolvingCommercialSnowRemovalIncludingSnowRemovalFromResidentialRoofsAsync(string key) =>
        _ui.PressAsync(_locators.DoesTheInsuredEnterIntoContractsInvolvingCommercialSnowRemovalIncludingSnowRemovalFromResidentialRoofs, key, new ControlIntent("Navigation", "DoesTheInsuredEnterIntoContractsInvolvingCommercialSnowRemovalIncludingSnowRemovalFromResidentialRoofs"));

    public Task EnterDoesTheInsuredEverEnterIntoContractsForTasksNotContemplatedInTheCurrentLiabilityClassificationsOnThePolicyAsync(string value) =>
        _ui.FillAsync(_locators.DoesTheInsuredEverEnterIntoContractsForTasksNotContemplatedInTheCurrentLiabilityClassificationsOnThePolicy, value, new ControlIntent("Navigation", "DoesTheInsuredEverEnterIntoContractsForTasksNotContemplatedInTheCurrentLiabilityClassificationsOnThePolicy"));

    public Task PressDoesTheInsuredEverEnterIntoContractsForTasksNotContemplatedInTheCurrentLiabilityClassificationsOnThePolicyAsync(string key) =>
        _ui.PressAsync(_locators.DoesTheInsuredEverEnterIntoContractsForTasksNotContemplatedInTheCurrentLiabilityClassificationsOnThePolicy, key, new ControlIntent("Navigation", "DoesTheInsuredEverEnterIntoContractsForTasksNotContemplatedInTheCurrentLiabilityClassificationsOnThePolicy"));

    public Task ClickDriveOtherCarAsync() =>
        _ui.ClickAsync(_locators.DriveOtherCar, new ControlIntent("Navigation", "DriveOtherCar"));

    public Task ClickDriverScheduleAsync() =>
        _ui.ClickAsync(_locators.PageTitle, new ControlIntent("Navigation", "DriverSchedule"));

    public Task VerifyDriversLicenseNumberAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.DriversLicenseNumber, expected, property, new ControlIntent("Navigation", "DriversLicenseNumber"));

    public Task EnterDryCleaningAsync(string value) =>
        _ui.FillAsync(_locators.DryCleaning, value, new ControlIntent("Navigation", "DryCleaning"));

    public Task PressDryCleaningAsync(string key) =>
        _ui.PressAsync(_locators.DryCleaning, key, new ControlIntent("Navigation", "DryCleaning"));

    public Task EnterDuplicatedRecordsAsync(string value) =>
        _ui.FillAsync(_locators.DuplicatedRecords, value, new ControlIntent("Navigation", "DuplicatedRecords"));

    public Task PressDuplicatedRecordsAsync(string key) =>
        _ui.PressAsync(_locators.DuplicatedRecords, key, new ControlIntent("Navigation", "DuplicatedRecords"));

    public Task EnterEAreNoSmokingRulesPostedAndEnforcedAsync(string value) =>
        _ui.FillAsync(_locators.EAreNoSmokingRulesPostedAndEnforced, value, new ControlIntent("Navigation", "EAreNoSmokingRulesPostedAndEnforced"));

    public Task PressEAreNoSmokingRulesPostedAndEnforcedAsync(string key) =>
        _ui.PressAsync(_locators.EAreNoSmokingRulesPostedAndEnforced, key, new ControlIntent("Navigation", "EAreNoSmokingRulesPostedAndEnforced"));

    public Task EnterEMailAsync(string value) =>
        _ui.FillAsync(_locators.EMail, value, new ControlIntent("Navigation", "EMail"));

    public Task EnterEarthquakeAsync(string value) =>
        _ui.FillAsync(_locators.Earthquake, value, new ControlIntent("Navigation", "Earthquake"));

    public Task PressEarthquakeAsync(string key) =>
        _ui.PressAsync(_locators.Earthquake, key, new ControlIntent("Navigation", "Earthquake"));

    public Task WaitForEasyPayAsync(string expected) =>
        _ui.WaitAsync(_locators.EasyPay, expected, new ControlIntent("Navigation", "EasyPay"));

    public Task EnterEasyPayAsync(string value) =>
        _ui.FillAsync(_locators.EasyPay, value, new ControlIntent("Navigation", "EasyPay"));

    public Task PressEasyPayAsync(string key) =>
        _ui.PressAsync(_locators.EasyPay, key, new ControlIntent("Navigation", "EasyPay"));

    public Task WaitForCommercialAutoEffectiveDateAsync(string expected) =>
        _ui.WaitAsync(_locators.BusinessownersEffectiveDate, expected, new ControlIntent("Navigation", "CommercialAutoEffectiveDate"));

    public Task EnterCommercialAutoEffectiveDateAsync(string value) =>
        _ui.FillAsync(_locators.BusinessownersEffectiveDate, value, new ControlIntent("Navigation", "CommercialAutoEffectiveDate"));

    public Task PressCommercialAutoEffectiveDateAsync(string key) =>
        _ui.PressAsync(_locators.BusinessownersEffectiveDate, key, new ControlIntent("Navigation", "CommercialAutoEffectiveDate"));

    public Task WaitForBusinessownersEffectiveDateAsync(string expected) =>
        _ui.WaitAsync(_locators.BusinessownersEffectiveDate, expected, new ControlIntent("Navigation", "BusinessownersEffectiveDate"));

    public Task EnterBusinessownersEffectiveDateAsync(string value) =>
        _ui.FillAsync(_locators.BusinessownersEffectiveDate, value, new ControlIntent("Navigation", "BusinessownersEffectiveDate"));

    public Task PressBusinessownersEffectiveDateAsync(string key) =>
        _ui.PressAsync(_locators.BusinessownersEffectiveDate, key, new ControlIntent("Navigation", "BusinessownersEffectiveDate"));

    public Task EnterPolicyInfoRequiredAndOptionalFieldsEffectiveDateAsync(string value) =>
        _ui.FillAsync(_locators.PolicyInfoRequiredAndOptionalFieldsEffectiveDate, value, new ControlIntent("Navigation", "PolicyInfoRequiredAndOptionalFieldsEffectiveDate"));

    public Task PressPolicyInfoRequiredAndOptionalFieldsEffectiveDateAsync(string key) =>
        _ui.PressAsync(_locators.PolicyInfoRequiredAndOptionalFieldsEffectiveDate, key, new ControlIntent("Navigation", "PolicyInfoRequiredAndOptionalFieldsEffectiveDate"));

    public Task EnterEligibleForEnhancedWindRatingProgramAsync(string value) =>
        _ui.FillAsync(_locators.EligibleForEnhancedWindRatingProgram, value, new ControlIntent("Navigation", "EligibleForEnhancedWindRatingProgram"));

    public Task PressEligibleForEnhancedWindRatingProgramAsync(string key) =>
        _ui.PressAsync(_locators.EligibleForEnhancedWindRatingProgram, key, new ControlIntent("Navigation", "EligibleForEnhancedWindRatingProgram"));

    public Task ClickEmployeeHiredAutosCheckBoxAsync() =>
        _ui.ClickAsync(_locators.EmployeeHiredAutosCheckBox, new ControlIntent("Navigation", "EmployeeHiredAutosCheckBox"));

    public Task WaitForEmployersLiabAsync(string expected) =>
        _ui.WaitAsync(_locators.EmployersLiab, expected, new ControlIntent("Navigation", "EmployersLiab"));

    public Task PressEmployersLiabAsync(string key) =>
        _ui.PressAsync(_locators.EmployersLiab, key, new ControlIntent("Navigation", "EmployersLiab"));

    public Task ClickEmployersLiabAsync() =>
        _ui.ClickAsync(_locators.EmployersLiab, new ControlIntent("Navigation", "EmployersLiab"));

    public Task ClickEndorsementAsync() =>
        _ui.ClickAsync(_locators.PageTitle, new ControlIntent("Navigation", "Endorsement"));

    public Task WaitForEndorsementHeadingAsync(string expected) =>
        _ui.WaitAsync(_locators.PageTitle, expected, new ControlIntent("Navigation", "EndorsementHeading"));

    public Task VerifyFirstEndorsementScheduleRowAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.FirstEndorsementScheduleRow, expected, property, new ControlIntent("Navigation", "FirstEndorsementScheduleRow"));

    public Task VerifyFirstEndorsementTableRowAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.FirstEndorsementTableRow, expected, property, new ControlIntent("Navigation", "FirstEndorsementTableRow"));

    public Task VerifySecondEndorsementTableRowAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.SecondEndorsementTableRow, expected, property, new ControlIntent("Navigation", "SecondEndorsementTableRow"));

    public Task EnterCG2401NonBindingArbitrationEndorsementTypeAsync(string value) =>
        _ui.FillAsync(_locators.CG2401NonBindingArbitrationEndorsementType, value, new ControlIntent("Navigation", "CG2401NonBindingArbitrationEndorsementType"));

    public Task PressCG2401NonBindingArbitrationEndorsementTypeAsync(string key) =>
        _ui.PressAsync(_locators.CG2401NonBindingArbitrationEndorsementType, key, new ControlIntent("Navigation", "CG2401NonBindingArbitrationEndorsementType"));

    public Task WaitForBAPEndorsementsEndorsementTypeAsync(string expected) =>
        _ui.WaitAsync(_locators.BAPEndorsementsEndorsementType, expected, new ControlIntent("Navigation", "BAPEndorsementsEndorsementType"));

    public Task EnterBAPEndorsementsEndorsementTypeAsync(string value) =>
        _ui.FillAsync(_locators.BAPEndorsementsEndorsementType, value, new ControlIntent("Navigation", "BAPEndorsementsEndorsementType"));

    public Task PressBAPEndorsementsEndorsementTypeAsync(string key) =>
        _ui.PressAsync(_locators.BAPEndorsementsEndorsementType, key, new ControlIntent("Navigation", "BAPEndorsementsEndorsementType"));

    public Task ClickBAPEndorsementsEndorsementTypeAsync() =>
        _ui.ClickAsync(_locators.BAPEndorsementsEndorsementType, new ControlIntent("Navigation", "BAPEndorsementsEndorsementType"));

    public Task EnterEndorsementsPartnersOfficersAndOthersExclusionEndorsementTypeAsync(string value) =>
        _ui.FillAsync(_locators.EndorsementsPartnersOfficersAndOthersExclusionEndorsementType, value, new ControlIntent("Navigation", "EndorsementsPartnersOfficersAndOthersExclusionEndorsementType"));

    public Task PressEndorsementsPartnersOfficersAndOthersExclusionEndorsementTypeAsync(string key) =>
        _ui.PressAsync(_locators.EndorsementsPartnersOfficersAndOthersExclusionEndorsementType, key, new ControlIntent("Navigation", "EndorsementsPartnersOfficersAndOthersExclusionEndorsementType"));

    public Task ClickGLNavigationLinksEndorsementsAsync() =>
        _ui.ClickAsync(_locators.PageTitle, new ControlIntent("Navigation", "GLNavigationLinksEndorsements"));

    public Task WaitForEndorsementsAsync(string expected) =>
        _ui.WaitAsync(_locators.PageTitle, expected, new ControlIntent("Navigation", "Endorsements"));

    public Task WaitForWCNavigationLinksEndorsementsAsync(string expected) =>
        _ui.WaitAsync(_locators.PageTitle, expected, new ControlIntent("Navigation", "WCNavigationLinksEndorsements"));

    public Task PressWCNavigationLinksEndorsementsAsync(string key) =>
        _ui.PressAsync(_locators.PageTitle, key, new ControlIntent("Navigation", "WCNavigationLinksEndorsements"));

    public Task ClickWCNavigationLinksEndorsementsAsync() =>
        _ui.ClickAsync(_locators.PageTitle, new ControlIntent("Navigation", "WCNavigationLinksEndorsements"));

    public Task VerifySignsHeadingAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.PageTitle, expected, property, new ControlIntent("Navigation", "SignsHeading"));

    public Task EnterEngineSizeCcAsync(string value) =>
        _ui.FillAsync(_locators.EngineSizeCc, value, new ControlIntent("Navigation", "EngineSizeCc"));

    public Task PressEngineSizeCcAsync(string key) =>
        _ui.PressAsync(_locators.EngineSizeCc, key, new ControlIntent("Navigation", "EngineSizeCc"));

    public Task WaitForEntityInfoFrameAsync(string expected) =>
        _ui.WaitAsync(_locators.EntityInfoFrame, expected, new ControlIntent("Navigation", "EntityInfoFrame"));

    public Task ClickEntityScheduleAsync() =>
        _ui.ClickAsync(_locators.PageTitle, new ControlIntent("Navigation", "EntitySchedule"));

    public Task EnterEstimatedHighestValueAsync(string value) =>
        _ui.FillAsync(_locators.EstimatedHighestValue, value, new ControlIntent("Navigation", "EstimatedHighestValue"));

    public Task PressEstimatedHighestValueAsync(string key) =>
        _ui.PressAsync(_locators.EstimatedHighestValue, key, new ControlIntent("Navigation", "EstimatedHighestValue"));

    public Task EnterEstimatorTypeAsync(string value) =>
        _ui.FillAsync(_locators.EstimatorType, value, new ControlIntent("Navigation", "EstimatorType"));

    public Task PressEstimatorTypeAsync(string key) =>
        _ui.PressAsync(_locators.EstimatorType, key, new ControlIntent("Navigation", "EstimatorType"));

    public Task ClickExcessLiabilityIfAnyAsync() =>
        _ui.ClickAsync(_locators.ExcessLiabilityIfAny, new ControlIntent("Navigation", "ExcessLiabilityIfAny"));

    public Task SetExcludeCollapseHazardAsync(string value) =>
        _ui.SmartSetAsync(_locators.ExcludeCollapseHazard, value, new ControlIntent("Navigation", "ExcludeCollapseHazard"));

    public Task PressExcludeCollapseHazardAsync(string key) =>
        _ui.PressAsync(_locators.ExcludeCollapseHazard, key, new ControlIntent("Navigation", "ExcludeCollapseHazard"));

    public Task SetExcludeExplosionHazardAsync(string value) =>
        _ui.SmartSetAsync(_locators.ExcludeExplosionHazard, value, new ControlIntent("Navigation", "ExcludeExplosionHazard"));

    public Task PressExcludeExplosionHazardAsync(string key) =>
        _ui.PressAsync(_locators.ExcludeExplosionHazard, key, new ControlIntent("Navigation", "ExcludeExplosionHazard"));

    public Task SetExcludeUndergroundPropertyDamageHazardAsync(string value) =>
        _ui.SmartSetAsync(_locators.ExcludeUndergroundPropertyDamageHazard, value, new ControlIntent("Navigation", "ExcludeUndergroundPropertyDamageHazard"));

    public Task PressExcludeUndergroundPropertyDamageHazardAsync(string key) =>
        _ui.PressAsync(_locators.ExcludeUndergroundPropertyDamageHazard, key, new ControlIntent("Navigation", "ExcludeUndergroundPropertyDamageHazard"));

    public Task WaitForExcludedLiabilityConfidentialInformationAsync(string expected) =>
        _ui.WaitAsync(_locators.ExcludedLiabilityConfidentialInformation, expected, new ControlIntent("Navigation", "ExcludedLiabilityConfidentialInformation"));

    public Task VerifyExcludedLiabilityConfidentialInformationAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.ExcludedLiabilityConfidentialInformation, expected, property, new ControlIntent("Navigation", "ExcludedLiabilityConfidentialInformation"));

    public Task EnterExcludedLiabilityConfidentialInformationAsync(string value) =>
        _ui.FillAsync(_locators.ExcludedLiabilityConfidentialInformation, value, new ControlIntent("Navigation", "ExcludedLiabilityConfidentialInformation"));

    public Task PressExcludedLiabilityConfidentialInformationAsync(string key) =>
        _ui.PressAsync(_locators.ExcludedLiabilityConfidentialInformation, key, new ControlIntent("Navigation", "ExcludedLiabilityConfidentialInformation"));

    public Task EnterExperienceModTypeAsync(string value) =>
        _ui.FillAsync(_locators.ExperienceModType, value, new ControlIntent("Navigation", "ExperienceModType"));

    public Task PressExperienceModTypeAsync(string key) =>
        _ui.PressAsync(_locators.ExperienceModType, key, new ControlIntent("Navigation", "ExperienceModType"));

    public Task EnterExperienceRatedAsync(string value) =>
        _ui.FillAsync(_locators.ExperienceRated, value, new ControlIntent("Navigation", "ExperienceRated"));

    public Task PressExperienceRatedAsync(string key) =>
        _ui.PressAsync(_locators.ExperienceRated, key, new ControlIntent("Navigation", "ExperienceRated"));

    public Task EnterExperienceRatingOptionsAsync(string value) =>
        _ui.FillAsync(_locators.ExperienceRatingOptions, value, new ControlIntent("Navigation", "ExperienceRatingOptions"));

    public Task PressExperienceRatingOptionsAsync(string key) =>
        _ui.PressAsync(_locators.ExperienceRatingOptions, key, new ControlIntent("Navigation", "ExperienceRatingOptions"));

    public Task EnterGeneralLiabilityExpirationDateAsync(string value) =>
        _ui.FillAsync(_locators.BusinessownersExpirationDate, value, new ControlIntent("Navigation", "GeneralLiabilityExpirationDate"));

    public Task PressGeneralLiabilityExpirationDateAsync(string key) =>
        _ui.PressAsync(_locators.BusinessownersExpirationDate, key, new ControlIntent("Navigation", "GeneralLiabilityExpirationDate"));

    public Task EnterBusinessownersExpirationDateAsync(string value) =>
        _ui.FillAsync(_locators.BusinessownersExpirationDate, value, new ControlIntent("Navigation", "BusinessownersExpirationDate"));

    public Task PressBusinessownersExpirationDateAsync(string key) =>
        _ui.PressAsync(_locators.BusinessownersExpirationDate, key, new ControlIntent("Navigation", "BusinessownersExpirationDate"));

    public Task EnterExposureAsync(string value) =>
        _ui.FillAsync(_locators.Exposure, value, new ControlIntent("Navigation", "Exposure"));

    public Task PressExposureAsync(string key) =>
        _ui.PressAsync(_locators.Exposure, key, new ControlIntent("Navigation", "Exposure"));

    public Task EnterExtendedEmployeeCoverageAsync(string value) =>
        _ui.FillAsync(_locators.ExtendedEmployeeCoverage, value, new ControlIntent("Navigation", "ExtendedEmployeeCoverage"));

    public Task PressExtendedEmployeeCoverageAsync(string key) =>
        _ui.PressAsync(_locators.ExtendedEmployeeCoverage, key, new ControlIntent("Navigation", "ExtendedEmployeeCoverage"));

    public Task EnterExtraExpenseAsync(string value) =>
        _ui.FillAsync(_locators.ExtraExpense, value, new ControlIntent("Navigation", "ExtraExpense"));

    public Task PressExtraExpenseAsync(string key) =>
        _ui.PressAsync(_locators.ExtraExpense, key, new ControlIntent("Navigation", "ExtraExpense"));

    public Task VerifyFeetFromHydrantAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.FeetFromHydrant, expected, property, new ControlIntent("Navigation", "FeetFromHydrant"));

    public Task EnterFeetFromHydrantAsync(string value) =>
        _ui.FillAsync(_locators.FeetFromHydrant, value, new ControlIntent("Navigation", "FeetFromHydrant"));

    public Task PressFeetFromHydrantAsync(string key) =>
        _ui.PressAsync(_locators.FeetFromHydrant, key, new ControlIntent("Navigation", "FeetFromHydrant"));

    public Task EnterFireDamageAsync(string value) =>
        _ui.FillAsync(_locators.FireDamage, value, new ControlIntent("Navigation", "FireDamage"));

    public Task PressFireDamageAsync(string key) =>
        _ui.PressAsync(_locators.FireDamage, key, new ControlIntent("Navigation", "FireDamage"));

    public Task EnterStateDetailsDriveOtherCarFirstNameAsync(string value) =>
        _ui.FillAsync(_locators.StateDetailsDriveOtherCarFirstName, value, new ControlIntent("Navigation", "StateDetailsDriveOtherCarFirstName"));

    public Task PressStateDetailsDriveOtherCarFirstNameAsync(string key) =>
        _ui.PressAsync(_locators.StateDetailsDriveOtherCarFirstName, key, new ControlIntent("Navigation", "StateDetailsDriveOtherCarFirstName"));

    public Task WaitForFirstNameAsync(string expected) =>
        _ui.WaitAsync(_locators.FirstName, expected, new ControlIntent("Navigation", "FirstName"));

    public Task EnterFirstNameAsync(string value) =>
        _ui.FillAsync(_locators.FirstName, value, new ControlIntent("Navigation", "FirstName"));

    public Task PressFirstNameAsync(string key) =>
        _ui.PressAsync(_locators.FirstName, key, new ControlIntent("Navigation", "FirstName"));

    public Task EnterGCWAsync(string value) =>
        _ui.FillAsync(_locators.GCW, value, new ControlIntent("Navigation", "GCW"));

    public Task PressGCWAsync(string key) =>
        _ui.PressAsync(_locators.GCW, key, new ControlIntent("Navigation", "GCW"));

    public Task ClickGLDetailAsync() =>
        _ui.ClickAsync(_locators.GLDetail, new ControlIntent("Navigation", "GLDetail"));

    public Task ClickGLUWQuestionsAsync() =>
        _ui.ClickAsync(_locators.GLUWQuestions, new ControlIntent("Navigation", "GLUWQuestions"));

    public Task WaitForGeneralLiabAsync(string expected) =>
        _ui.WaitAsync(_locators.GeneralLiab, expected, new ControlIntent("Navigation", "GeneralLiab"));

    public Task PressGeneralLiabAsync(string key) =>
        _ui.PressAsync(_locators.GeneralLiab, key, new ControlIntent("Navigation", "GeneralLiab"));

    public Task ClickGeneralLiabAsync() =>
        _ui.ClickAsync(_locators.GeneralLiab, new ControlIntent("Navigation", "GeneralLiab"));

    public Task WaitForGeneralLiabilityInformationAsync(string expected) =>
        _ui.WaitAsync(_locators.PageTitle, expected, new ControlIntent("Navigation", "GeneralLiabilityInformation"));

    public Task ClickGeneralLiabilityInformationAsync() =>
        _ui.ClickAsync(_locators.PageTitle, new ControlIntent("Navigation", "GeneralLiabilityInformation"));

    public Task WaitForGeneralUWQuestionsAsync(string expected) =>
        _ui.WaitAsync(_locators.GeneralUWQuestions, expected, new ControlIntent("Navigation", "GeneralUWQuestions"));

    public Task ClickGetCalculatedValueAsync() =>
        _ui.ClickAsync(_locators.GetCalculatedValue, new ControlIntent("Navigation", "GetCalculatedValue"));

    public Task EnterGroupClassAsync(string value) =>
        _ui.FillAsync(_locators.GroupClass, value, new ControlIntent("Navigation", "GroupClass"));

    public Task PressGroupClassAsync(string key) =>
        _ui.PressAsync(_locators.GroupClass, key, new ControlIntent("Navigation", "GroupClass"));

    public Task VerifyHasAnyApplicantBeenConvictedOfAFelonyOrBeenInvolvedInAnyIncidentsOrClaimsRelatingToSexualAbuseOrMolestationAllegationsDiscriminationArsonFraudBriberyOrNegligentHiringAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.HasAnyApplicantBeenConvictedOfAFelonyOrBeenInvolvedInAnyIncidentsOrClaimsRelatingToSexualAbuseOrMolestationAllegationsDiscriminationArsonFraudBriberyOrNegligentHiring, expected, property, new ControlIntent("Navigation", "HasAnyApplicantBeenConvictedOfAFelonyOrBeenInvolvedInAnyIncidentsOrClaimsRelatingToSexualAbuseOrMolestationAllegationsDiscriminationArsonFraudBriberyOrNegligentHiring"));

    public Task EnterHasAnyApplicantBeenConvictedOfAFelonyOrBeenInvolvedInAnyIncidentsOrClaimsRelatingToSexualAbuseOrMolestationAllegationsDiscriminationArsonFraudBriberyOrNegligentHiringAsync(string value) =>
        _ui.FillAsync(_locators.HasAnyApplicantBeenConvictedOfAFelonyOrBeenInvolvedInAnyIncidentsOrClaimsRelatingToSexualAbuseOrMolestationAllegationsDiscriminationArsonFraudBriberyOrNegligentHiring, value, new ControlIntent("Navigation", "HasAnyApplicantBeenConvictedOfAFelonyOrBeenInvolvedInAnyIncidentsOrClaimsRelatingToSexualAbuseOrMolestationAllegationsDiscriminationArsonFraudBriberyOrNegligentHiring"));

    public Task PressHasAnyApplicantBeenConvictedOfAFelonyOrBeenInvolvedInAnyIncidentsOrClaimsRelatingToSexualAbuseOrMolestationAllegationsDiscriminationArsonFraudBriberyOrNegligentHiringAsync(string key) =>
        _ui.PressAsync(_locators.HasAnyApplicantBeenConvictedOfAFelonyOrBeenInvolvedInAnyIncidentsOrClaimsRelatingToSexualAbuseOrMolestationAllegationsDiscriminationArsonFraudBriberyOrNegligentHiring, key, new ControlIntent("Navigation", "HasAnyApplicantBeenConvictedOfAFelonyOrBeenInvolvedInAnyIncidentsOrClaimsRelatingToSexualAbuseOrMolestationAllegationsDiscriminationArsonFraudBriberyOrNegligentHiring"));

    public Task WaitForHaveYouHadAnyLiabilityLossesInTheLast5YearsOnAnyPrimaryOrExcessPolicyAsync(string expected) =>
        _ui.WaitAsync(_locators.HaveYouHadAnyLiabilityLossesInTheLast5YearsOnAnyPrimaryOrExcessPolicy, expected, new ControlIntent("Navigation", "HaveYouHadAnyLiabilityLossesInTheLast5YearsOnAnyPrimaryOrExcessPolicy"));

    public Task EnterHiredAutoCA2001AddressAsync(string value) =>
        _ui.FillAsync(_locators.HiredAutoCA2001Address, value, new ControlIntent("Navigation", "HiredAutoCA2001Address"));

    public Task PressHiredAutoCA2001AddressAsync(string key) =>
        _ui.PressAsync(_locators.HiredAutoCA2001Address, key, new ControlIntent("Navigation", "HiredAutoCA2001Address"));

    public Task EnterHiredAutoCA2001FirstNameAsync(string value) =>
        _ui.FillAsync(_locators.HiredAutoCA2001FirstName, value, new ControlIntent("Navigation", "HiredAutoCA2001FirstName"));

    public Task PressHiredAutoCA2001FirstNameAsync(string key) =>
        _ui.PressAsync(_locators.HiredAutoCA2001FirstName, key, new ControlIntent("Navigation", "HiredAutoCA2001FirstName"));

    public Task EnterHiredAutoCA2001LastNameAsync(string value) =>
        _ui.FillAsync(_locators.HiredAutoCA2001LastName, value, new ControlIntent("Navigation", "HiredAutoCA2001LastName"));

    public Task PressHiredAutoCA2001LastNameAsync(string key) =>
        _ui.PressAsync(_locators.HiredAutoCA2001LastName, key, new ControlIntent("Navigation", "HiredAutoCA2001LastName"));

    public Task EnterHiredAutoCA2001ZipCodeAsync(string value) =>
        _ui.FillAsync(_locators.HiredAutoCA2001ZipCode, value, new ControlIntent("Navigation", "HiredAutoCA2001ZipCode"));

    public Task PressHiredAutoCA2001ZipCodeAsync(string key) =>
        _ui.PressAsync(_locators.HiredAutoCA2001ZipCode, key, new ControlIntent("Navigation", "HiredAutoCA2001ZipCode"));

    public Task VerifyHiredAutoExtAddlInsuredAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.HiredAutoExtAddlInsured, expected, property, new ControlIntent("Navigation", "HiredAutoExtAddlInsured"));

    public Task EnterHiredAutoExtAddlInsuredAsync(string value) =>
        _ui.FillAsync(_locators.HiredAutoExtAddlInsured, value, new ControlIntent("Navigation", "HiredAutoExtAddlInsured"));

    public Task PressHiredAutoExtAddlInsuredAsync(string key) =>
        _ui.PressAsync(_locators.HiredAutoExtAddlInsured, key, new ControlIntent("Navigation", "HiredAutoExtAddlInsured"));

    public Task WaitForHiredAutoOKAsync(string expected) =>
        _ui.WaitAsync(_locators.HiredAutoOK, expected, new ControlIntent("Navigation", "HiredAutoOK"));

    public Task EnterHiredAutoOKAsync(string value) =>
        _ui.FillAsync(_locators.HiredAutoOK, value, new ControlIntent("Navigation", "HiredAutoOK"));

    public Task PressHiredAutoOKAsync(string key) =>
        _ui.PressAsync(_locators.HiredAutoOK, key, new ControlIntent("Navigation", "HiredAutoOK"));

    public Task ClickHiredAutoLiabilityAsync() =>
        _ui.ClickAsync(_locators.HiredAutoLiability, new ControlIntent("Navigation", "HiredAutoLiability"));

    public Task ClickHiredAutoOKAsync() =>
        _ui.ClickAsync(_locators.HiredAutoOK, new ControlIntent("Navigation", "HiredAutoOK"));

    public Task ClickHiredAutoPhysicalDamageWithDriverAsync() =>
        _ui.ClickAsync(_locators.HiredAutoPhysicalDamageWithDriver, new ControlIntent("Navigation", "HiredAutoPhysicalDamageWithDriver"));

    public Task ClickHiredAutoPhysicalDamageWithoutDriverAsync() =>
        _ui.ClickAsync(_locators.HiredAutoPhysicalDamageWithoutDriver, new ControlIntent("Navigation", "HiredAutoPhysicalDamageWithoutDriver"));

    public Task EnterHiredEquipmentAsync(string value) =>
        _ui.FillAsync(_locators.HiredEquipment, value, new ControlIntent("Navigation", "HiredEquipment"));

    public Task PressHiredEquipmentAsync(string key) =>
        _ui.PressAsync(_locators.HiredEquipment, key, new ControlIntent("Navigation", "HiredEquipment"));

    public Task EnterHowOftenIsDataBackedUpAsync(string value) =>
        _ui.FillAsync(_locators.HowOftenIsDataBackedUp, value, new ControlIntent("Navigation", "HowOftenIsDataBackedUp"));

    public Task PressHowOftenIsDataBackedUpAsync(string key) =>
        _ui.PressAsync(_locators.HowOftenIsDataBackedUp, key, new ControlIntent("Navigation", "HowOftenIsDataBackedUp"));

    public Task WaitForAdditionalInterestsScheduleIFRAMEAsync(string expected) =>
        _ui.WaitAsync(_locators.AdditionalInterestsScheduleIFRAME, expected, new ControlIntent("Navigation", "AdditionalInterestsScheduleIFRAME"));

    public Task VerifyAdditionalInterestsScheduleIFRAMEAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.AdditionalInterestsScheduleIFRAME, expected, property, new ControlIntent("Navigation", "AdditionalInterestsScheduleIFRAME"));

    public Task WaitForDriverDetailIFRAMEAsync(string expected) =>
        _ui.WaitAsync(_locators.DriverDetailIFRAME, expected, new ControlIntent("Navigation", "DriverDetailIFRAME"));

    public Task EnterIFRAMEDuckCreekPolicyAddressEsOrDescriptionSOfDesignatedFarmLocationSAsync(string value) =>
        _ui.FillAsync(_locators.IFRAMEDuckCreekPolicyAddressEsOrDescriptionSOfDesignatedFarmLocationS, value, new ControlIntent("Navigation", "IFRAMEDuckCreekPolicyAddressEsOrDescriptionSOfDesignatedFarmLocationS"));

    public Task PressIFRAMEDuckCreekPolicyAddressEsOrDescriptionSOfDesignatedFarmLocationSAsync(string key) =>
        _ui.PressAsync(_locators.IFRAMEDuckCreekPolicyAddressEsOrDescriptionSOfDesignatedFarmLocationS, key, new ControlIntent("Navigation", "IFRAMEDuckCreekPolicyAddressEsOrDescriptionSOfDesignatedFarmLocationS"));

    public Task EnterIFRAMEDuckCreekPolicyAddressEsOrDescriptionSOfDesignatedPremisesAsync(string value) =>
        _ui.FillAsync(_locators.IFRAMEDuckCreekPolicyAddressEsOrDescriptionSOfDesignatedPremises, value, new ControlIntent("Navigation", "IFRAMEDuckCreekPolicyAddressEsOrDescriptionSOfDesignatedPremises"));

    public Task PressIFRAMEDuckCreekPolicyAddressEsOrDescriptionSOfDesignatedPremisesAsync(string key) =>
        _ui.PressAsync(_locators.IFRAMEDuckCreekPolicyAddressEsOrDescriptionSOfDesignatedPremises, key, new ControlIntent("Navigation", "IFRAMEDuckCreekPolicyAddressEsOrDescriptionSOfDesignatedPremises"));

    public Task EnterIFRAMEDuckCreekPolicyDescriptionOfPremisesOrActivitiesAsync(string value) =>
        _ui.FillAsync(_locators.IFRAMEDuckCreekPolicyDescriptionOfPremisesOrActivities, value, new ControlIntent("Navigation", "IFRAMEDuckCreekPolicyDescriptionOfPremisesOrActivities"));

    public Task PressIFRAMEDuckCreekPolicyDescriptionOfPremisesOrActivitiesAsync(string key) =>
        _ui.PressAsync(_locators.IFRAMEDuckCreekPolicyDescriptionOfPremisesOrActivities, key, new ControlIntent("Navigation", "IFRAMEDuckCreekPolicyDescriptionOfPremisesOrActivities"));

    public Task EnterIFRAMEDuckCreekPolicyExcludedDriverAsync(string value) =>
        _ui.FillAsync(_locators.IFRAMEDuckCreekPolicyExcludedDriver, value, new ControlIntent("Navigation", "IFRAMEDuckCreekPolicyExcludedDriver"));

    public Task PressIFRAMEDuckCreekPolicyExcludedDriverAsync(string key) =>
        _ui.PressAsync(_locators.IFRAMEDuckCreekPolicyExcludedDriver, key, new ControlIntent("Navigation", "IFRAMEDuckCreekPolicyExcludedDriver"));

    public Task EnterIFRAMEDuckCreekPolicyNameSOrDescriptionSOfDesignatedAnimalSAsync(string value) =>
        _ui.FillAsync(_locators.IFRAMEDuckCreekPolicyNameSOrDescriptionSOfDesignatedAnimalS, value, new ControlIntent("Navigation", "IFRAMEDuckCreekPolicyNameSOrDescriptionSOfDesignatedAnimalS"));

    public Task PressIFRAMEDuckCreekPolicyNameSOrDescriptionSOfDesignatedAnimalSAsync(string key) =>
        _ui.PressAsync(_locators.IFRAMEDuckCreekPolicyNameSOrDescriptionSOfDesignatedAnimalS, key, new ControlIntent("Navigation", "IFRAMEDuckCreekPolicyNameSOrDescriptionSOfDesignatedAnimalS"));

    public Task WaitForIFRAMEDuckCreekPolicyVehicleAssociationAsync(string expected) =>
        _ui.WaitAsync(_locators.IFRAMEDuckCreekPolicyVehicleAssociation, expected, new ControlIntent("Navigation", "IFRAMEDuckCreekPolicyVehicleAssociation"));

    public Task PressIFRAMEDuckCreekPolicyVehicleAssociationAsync(string key) =>
        _ui.PressAsync(_locators.IFRAMEDuckCreekPolicyVehicleAssociation, key, new ControlIntent("Navigation", "IFRAMEDuckCreekPolicyVehicleAssociation"));

    public Task ClickIFRAMEDuckCreekPolicyVehicleAssociationAsync() =>
        _ui.ClickAsync(_locators.IFRAMEDuckCreekPolicyVehicleAssociation, new ControlIntent("Navigation", "IFRAMEDuckCreekPolicyVehicleAssociation"));

    public Task WaitForBAPEndorsementsIFRAMEAsync(string expected) =>
        _ui.WaitAsync(_locators.BAPEndorsementsIFRAME, expected, new ControlIntent("Navigation", "BAPEndorsementsIFRAME"));

    public Task VerifyBAPEndorsementsIFRAMEAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.BAPEndorsementsIFRAME, expected, property, new ControlIntent("Navigation", "BAPEndorsementsIFRAME"));

    public Task EnterIfYesDescribeAsync(string value) =>
        _ui.FillAsync(_locators.IfYesDescribe, value, new ControlIntent("Navigation", "IfYesDescribe"));

    public Task PressIfYesDescribeAsync(string key) =>
        _ui.PressAsync(_locators.IfYesDescribe, key, new ControlIntent("Navigation", "IfYesDescribe"));

    public Task EnterIfYesExplainAsync(string value) =>
        _ui.FillAsync(_locators.IfYesExplain, value, new ControlIntent("Navigation", "IfYesExplain"));

    public Task PressIfYesExplainAsync(string key) =>
        _ui.PressAsync(_locators.IfYesExplain, key, new ControlIntent("Navigation", "IfYesExplain"));

    public Task ClickImportPolicyDataAsync() =>
        _ui.ClickAsync(_locators.ImportPolicyData, new ControlIntent("Navigation", "ImportPolicyData"));

    public Task ClickImportPolicyDataButtonAsync() =>
        _ui.ClickAsync(_locators.ImportPolicyData, new ControlIntent("Navigation", "ImportPolicyDataButton"));

    public Task EnterIncreasedPollutantCleanupAsync(string value) =>
        _ui.FillAsync(_locators.IncreasedPollutantCleanup, value, new ControlIntent("Navigation", "IncreasedPollutantCleanup"));

    public Task PressIncreasedPollutantCleanupAsync(string key) =>
        _ui.PressAsync(_locators.IncreasedPollutantCleanup, key, new ControlIntent("Navigation", "IncreasedPollutantCleanup"));

    public Task EnterIndicateTheBuildingSAgeTypeOfConstructionAndProtectionClassAndOtherTenantsInTheBuildingSWhereTheComputerEquipmentIsLocatedAsync(string value) =>
        _ui.FillAsync(_locators.IndicateTheBuildingSAgeTypeOfConstructionAndProtectionClassAndOtherTenantsInTheBuildingSWhereTheComputerEquipmentIsLocated, value, new ControlIntent("Navigation", "IndicateTheBuildingSAgeTypeOfConstructionAndProtectionClassAndOtherTenantsInTheBuildingSWhereTheComputerEquipmentIsLocated"));

    public Task PressIndicateTheBuildingSAgeTypeOfConstructionAndProtectionClassAndOtherTenantsInTheBuildingSWhereTheComputerEquipmentIsLocatedAsync(string key) =>
        _ui.PressAsync(_locators.IndicateTheBuildingSAgeTypeOfConstructionAndProtectionClassAndOtherTenantsInTheBuildingSWhereTheComputerEquipmentIsLocated, key, new ControlIntent("Navigation", "IndicateTheBuildingSAgeTypeOfConstructionAndProtectionClassAndOtherTenantsInTheBuildingSWhereTheComputerEquipmentIsLocated"));

    public Task ClickInsuranceHistoryAsync() =>
        _ui.ClickAsync(_locators.InsuranceHistory, new ControlIntent("Navigation", "InsuranceHistory"));

    public Task WaitForInsuredTypeAsync(string expected) =>
        _ui.WaitAsync(_locators.InsuredType, expected, new ControlIntent("Navigation", "InsuredType"));

    public Task EnterInterestAsync(string value) =>
        _ui.FillAsync(_locators.Interest, value, new ControlIntent("Navigation", "Interest"));

    public Task PressInterestAsync(string key) =>
        _ui.PressAsync(_locators.Interest, key, new ControlIntent("Navigation", "Interest"));

    public Task WaitForIntrastateRiskIDAsync(string expected) =>
        _ui.WaitAsync(_locators.IntrastateRiskID, expected, new ControlIntent("Navigation", "IntrastateRiskID"));

    public Task EnterIsTheBuildingCooledAsync(string value) =>
        _ui.FillAsync(_locators.IsTheBuildingCooled, value, new ControlIntent("Navigation", "IsTheBuildingCooled"));

    public Task PressIsTheBuildingCooledAsync(string key) =>
        _ui.PressAsync(_locators.IsTheBuildingCooled, key, new ControlIntent("Navigation", "IsTheBuildingCooled"));

    public Task EnterIsTheBuildingHeatedWithASolidFuelHeatingDeviceAsync(string value) =>
        _ui.FillAsync(_locators.IsTheBuildingHeatedWithASolidFuelHeatingDevice, value, new ControlIntent("Navigation", "IsTheBuildingHeatedWithASolidFuelHeatingDevice"));

    public Task PressIsTheBuildingHeatedWithASolidFuelHeatingDeviceAsync(string key) =>
        _ui.PressAsync(_locators.IsTheBuildingHeatedWithASolidFuelHeatingDevice, key, new ControlIntent("Navigation", "IsTheBuildingHeatedWithASolidFuelHeatingDevice"));

    public Task EnterIsTheInsuredEngagedInAnySnowOrIceRemovalOperationsAsync(string value) =>
        _ui.FillAsync(_locators.IsTheInsuredEngagedInAnySnowOrIceRemovalOperations, value, new ControlIntent("Navigation", "IsTheInsuredEngagedInAnySnowOrIceRemovalOperations"));

    public Task PressIsTheInsuredEngagedInAnySnowOrIceRemovalOperationsAsync(string key) =>
        _ui.PressAsync(_locators.IsTheInsuredEngagedInAnySnowOrIceRemovalOperations, key, new ControlIntent("Navigation", "IsTheInsuredEngagedInAnySnowOrIceRemovalOperations"));

    public Task WaitForIsThereAPriorCarrierAsync(string expected) =>
        _ui.WaitAsync(_locators.IsThereAPriorCarrier, expected, new ControlIntent("Navigation", "IsThereAPriorCarrier"));

    public Task EnterIsThereAPriorCarrierAsync(string value) =>
        _ui.FillAsync(_locators.IsThereAPriorCarrier, value, new ControlIntent("Navigation", "IsThereAPriorCarrier"));

    public Task PressIsThereAPriorCarrierAsync(string key) =>
        _ui.PressAsync(_locators.IsThereAPriorCarrier, key, new ControlIntent("Navigation", "IsThereAPriorCarrier"));

    public Task EnterIsThisCoverageBoundAsync(string value) =>
        _ui.FillAsync(_locators.IsThisCoverageBound, value, new ControlIntent("Navigation", "IsThisCoverageBound"));

    public Task PressIsThisCoverageBoundAsync(string key) =>
        _ui.PressAsync(_locators.IsThisCoverageBound, key, new ControlIntent("Navigation", "IsThisCoverageBound"));

    public Task VerifyIsThisPolicyBeingFullyCancelledAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.IsThisPolicyBeingFullyCancelled, expected, property, new ControlIntent("Navigation", "IsThisPolicyBeingFullyCancelled"));

    public Task VerifyIsThisVehicleUsedInSnowPlowOperationsAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, expected, property, new ControlIntent("Navigation", "IsThisVehicleUsedInSnowPlowOperations"));

    public Task EnterIsThisVehicleUsedInSnowPlowOperationsAsync(string value) =>
        _ui.FillAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, value, new ControlIntent("Navigation", "IsThisVehicleUsedInSnowPlowOperations"));

    public Task PressIsThisVehicleUsedInSnowPlowOperationsAsync(string key) =>
        _ui.PressAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, key, new ControlIntent("Navigation", "IsThisVehicleUsedInSnowPlowOperations"));

    public Task EnterJavaScriptAsync(string value) =>
        _ui.FillAsync(_locators.JavaScript, value, new ControlIntent("Navigation", "JavaScript"));

    public Task EnterLastNameAsync(string value) =>
        _ui.FillAsync(_locators.LastName, value, new ControlIntent("Navigation", "LastName"));

    public Task PressLastNameAsync(string key) =>
        _ui.PressAsync(_locators.LastName, key, new ControlIntent("Navigation", "LastName"));

    public Task EnterStateDetailsDriveOtherCarLastNameAsync(string value) =>
        _ui.FillAsync(_locators.StateDetailsDriveOtherCarLastName, value, new ControlIntent("Navigation", "StateDetailsDriveOtherCarLastName"));

    public Task PressStateDetailsDriveOtherCarLastNameAsync(string key) =>
        _ui.PressAsync(_locators.StateDetailsDriveOtherCarLastName, key, new ControlIntent("Navigation", "StateDetailsDriveOtherCarLastName"));

    public Task EnterLaundryAsync(string value) =>
        _ui.FillAsync(_locators.Laundry, value, new ControlIntent("Navigation", "Laundry"));

    public Task PressLaundryAsync(string key) =>
        _ui.PressAsync(_locators.Laundry, key, new ControlIntent("Navigation", "Laundry"));

    public Task EnterLetteringAsync(string value) =>
        _ui.FillAsync(_locators.Lettering, value, new ControlIntent("Navigation", "Lettering"));

    public Task PressLetteringAsync(string key) =>
        _ui.PressAsync(_locators.Lettering, key, new ControlIntent("Navigation", "Lettering"));

    public Task EnterCommercialAutoLiabilityLimitAsync(string value) =>
        _ui.FillAsync(_locators.CommercialAutoLiabilityLimit, value, new ControlIntent("Navigation", "CommercialAutoLiabilityLimit"));

    public Task PressCommercialAutoLiabilityLimitAsync(string key) =>
        _ui.PressAsync(_locators.CommercialAutoLiabilityLimit, key, new ControlIntent("Navigation", "CommercialAutoLiabilityLimit"));

    public Task EnterSFP10LiabilityFarmLiabilityLimitAsync(string value) =>
        _ui.FillAsync(_locators.CommercialAutoLiabilityLimit, value, new ControlIntent("Navigation", "SFP10LiabilityFarmLiabilityLimit"));

    public Task PressSFP10LiabilityFarmLiabilityLimitAsync(string key) =>
        _ui.PressAsync(_locators.CommercialAutoLiabilityLimit, key, new ControlIntent("Navigation", "SFP10LiabilityFarmLiabilityLimit"));

    public Task EnterPolicyCovgBaileesPropertyAwayFromYourPremisesLimitAsync(string value) =>
        _ui.FillAsync(_locators.PolicyCovgBaileesPropertyAwayFromYourPremisesLimit, value, new ControlIntent("Navigation", "PolicyCovgBaileesPropertyAwayFromYourPremisesLimit"));

    public Task PressPolicyCovgBaileesPropertyAwayFromYourPremisesLimitAsync(string key) =>
        _ui.PressAsync(_locators.PolicyCovgBaileesPropertyAwayFromYourPremisesLimit, key, new ControlIntent("Navigation", "PolicyCovgBaileesPropertyAwayFromYourPremisesLimit"));

    public Task EnterEndorsementIF0002WaterborneEquipmentLimitAsync(string value) =>
        _ui.FillAsync(_locators.EndorsementIF0002WaterborneEquipmentLimit, value, new ControlIntent("Navigation", "EndorsementIF0002WaterborneEquipmentLimit"));

    public Task PressEndorsementIF0002WaterborneEquipmentLimitAsync(string key) =>
        _ui.PressAsync(_locators.EndorsementIF0002WaterborneEquipmentLimit, key, new ControlIntent("Navigation", "EndorsementIF0002WaterborneEquipmentLimit"));

    public Task EnterRiskBaileesCustomersLimitAsync(string value) =>
        _ui.FillAsync(_locators.RiskBaileesCustomersLimit, value, new ControlIntent("Navigation", "RiskBaileesCustomersLimit"));

    public Task PressRiskBaileesCustomersLimitAsync(string key) =>
        _ui.PressAsync(_locators.RiskBaileesCustomersLimit, key, new ControlIntent("Navigation", "RiskBaileesCustomersLimit"));

    public Task EnterLimitOfInsuranceAsync(string value) =>
        _ui.FillAsync(_locators.LimitOfInsurance, value, new ControlIntent("Navigation", "LimitOfInsurance"));

    public Task PressLimitOfInsuranceAsync(string key) =>
        _ui.PressAsync(_locators.LimitOfInsurance, key, new ControlIntent("Navigation", "LimitOfInsurance"));

    public Task EnterLineConditionerAsync(string value) =>
        _ui.FillAsync(_locators.LineConditioner, value, new ControlIntent("Navigation", "LineConditioner"));

    public Task PressLineConditionerAsync(string key) =>
        _ui.PressAsync(_locators.LineConditioner, key, new ControlIntent("Navigation", "LineConditioner"));

    public Task EnterListAllPoliciesWithAmericanNationalAsync(string value) =>
        _ui.FillAsync(_locators.ListAllPoliciesWithAmericanNational, value, new ControlIntent("Navigation", "ListAllPoliciesWithAmericanNational"));

    public Task PressListAllPoliciesWithAmericanNationalAsync(string key) =>
        _ui.PressAsync(_locators.ListAllPoliciesWithAmericanNational, key, new ControlIntent("Navigation", "ListAllPoliciesWithAmericanNational"));

    public Task WaitForLoadingMessageAsync(string expected) =>
        _ui.WaitAsync(_locators.LoadingMessage, expected, new ControlIntent("Navigation", "LoadingMessage"));

    public Task VerifyLoadingMessageAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.LoadingMessage, expected, property, new ControlIntent("Navigation", "LoadingMessage"));

    public Task EnterLoanLeaseGapAsync(string value) =>
        _ui.FillAsync(_locators.LoanLeaseGap, value, new ControlIntent("Navigation", "LoanLeaseGap"));

    public Task PressLoanLeaseGapAsync(string key) =>
        _ui.PressAsync(_locators.LoanLeaseGap, key, new ControlIntent("Navigation", "LoanLeaseGap"));

    public Task WaitForLocationAsync(string expected) =>
        _ui.WaitAsync(_locators.PageTitle, expected, new ControlIntent("Navigation", "Location"));

    public Task ClickWCNavigationLinksLocationAsync() =>
        _ui.ClickAsync(_locators.PageTitle, new ControlIntent("Navigation", "WCNavigationLinksLocation"));

    public Task WaitForWCNavigationLinksLocationAsync(string expected) =>
        _ui.WaitAsync(_locators.PageTitle, expected, new ControlIntent("Navigation", "WCNavigationLinksLocation"));

    public Task WaitForLocationAssignmentAsync(string expected) =>
        _ui.WaitAsync(_locators.LocationAssignment, expected, new ControlIntent("Navigation", "LocationAssignment"));

    public Task WaitForLocationIDAsync(string expected) =>
        _ui.WaitAsync(_locators.LocationID, expected, new ControlIntent("Navigation", "LocationID"));

    public Task VerifyLocationIDAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.LocationID, expected, property, new ControlIntent("Navigation", "LocationID"));

    public Task EnterLocationIDAsync(string value) =>
        _ui.FillAsync(_locators.LocationID, value, new ControlIntent("Navigation", "LocationID"));

    public Task PressLocationIDAsync(string key) =>
        _ui.PressAsync(_locators.LocationID, key, new ControlIntent("Navigation", "LocationID"));

    public Task ClickLocationIDAsync() =>
        _ui.ClickAsync(_locators.LocationID, new ControlIntent("Navigation", "LocationID"));

    public Task EnterLocationOfCoveredOperationsAsync(string value) =>
        _ui.FillAsync(_locators.LocationOfCoveredOperations, value, new ControlIntent("Navigation", "LocationOfCoveredOperations"));

    public Task PressLocationOfCoveredOperationsAsync(string key) =>
        _ui.PressAsync(_locators.LocationOfCoveredOperations, key, new ControlIntent("Navigation", "LocationOfCoveredOperations"));

    public Task ClickLossExperienceAsync() =>
        _ui.ClickAsync(_locators.PageTitle, new ControlIntent("Navigation", "LossExperience"));

    public Task WaitForLossExperienceHeadingAsync(string expected) =>
        _ui.WaitAsync(_locators.PageTitle, expected, new ControlIntent("Navigation", "LossExperienceHeading"));

    public Task EnterMakeAsync(string value) =>
        _ui.FillAsync(_locators.Make, value, new ControlIntent("Navigation", "Make"));

    public Task PressMakeAsync(string key) =>
        _ui.PressAsync(_locators.Make, key, new ControlIntent("Navigation", "Make"));

    public Task EnterMaritalStatusAsync(string value) =>
        _ui.FillAsync(_locators.MaritalStatus, value, new ControlIntent("Navigation", "MaritalStatus"));

    public Task PressMaritalStatusAsync(string key) =>
        _ui.PressAsync(_locators.MaritalStatus, key, new ControlIntent("Navigation", "MaritalStatus"));

    public Task EnterMedicalAsync(string value) =>
        _ui.FillAsync(_locators.Medical, value, new ControlIntent("Navigation", "Medical"));

    public Task PressMedicalAsync(string key) =>
        _ui.PressAsync(_locators.Medical, key, new ControlIntent("Navigation", "Medical"));

    public Task EnterMeritRatingAsync(string value) =>
        _ui.FillAsync(_locators.MeritRating, value, new ControlIntent("Navigation", "MeritRating"));

    public Task EnterMilesFromFireDepartmentAsync(string value) =>
        _ui.FillAsync(_locators.MilesFromFireDepartment, value, new ControlIntent("Navigation", "MilesFromFireDepartment"));

    public Task PressMilesFromFireDepartmentAsync(string key) =>
        _ui.PressAsync(_locators.MilesFromFireDepartment, key, new ControlIntent("Navigation", "MilesFromFireDepartment"));

    public Task EnterMiscItemsBlanketCoverageAsync(string value) =>
        _ui.FillAsync(_locators.MiscItemsBlanketCoverage, value, new ControlIntent("Navigation", "MiscItemsBlanketCoverage"));

    public Task PressMiscItemsBlanketCoverageAsync(string key) =>
        _ui.PressAsync(_locators.MiscItemsBlanketCoverage, key, new ControlIntent("Navigation", "MiscItemsBlanketCoverage"));

    public Task EnterModelAsync(string value) =>
        _ui.FillAsync(_locators.Model, value, new ControlIntent("Navigation", "Model"));

    public Task PressModelAsync(string key) =>
        _ui.PressAsync(_locators.Model, key, new ControlIntent("Navigation", "Model"));

    public Task EnterModificationFactorAsync(string value) =>
        _ui.FillAsync(_locators.ModificationFactor, value, new ControlIntent("Navigation", "ModificationFactor"));

    public Task PressModificationFactorAsync(string key) =>
        _ui.PressAsync(_locators.ModificationFactor, key, new ControlIntent("Navigation", "ModificationFactor"));

    public Task ClickMotorTruckCargoUWQuestionsAsync() =>
        _ui.ClickAsync(_locators.PageTitle, new ControlIntent("Navigation", "MotorTruckCargoUWQuestions"));

    public Task WaitForMotorcycleLiabilityAsync(string expected) =>
        _ui.WaitAsync(_locators.PageTitle, expected, new ControlIntent("Navigation", "MotorcycleLiability"));

    public Task PressMotorcycleLiabilityAsync(string key) =>
        _ui.PressAsync(_locators.PageTitle, key, new ControlIntent("Navigation", "MotorcycleLiability"));

    public Task ClickMotorcycleLiabilityAsync() =>
        _ui.ClickAsync(_locators.PageTitle, new ControlIntent("Navigation", "MotorcycleLiability"));

    public Task EnterN10AreThePremisesEquippedWithARecognizedApprovedCentralStationFireAlarmFireExtinguishersOrSmokeAlarmsAsync(string value) =>
        _ui.FillAsync(_locators.N10AreThePremisesEquippedWithARecognizedApprovedCentralStationFireAlarmFireExtinguishersOrSmokeAlarms, value, new ControlIntent("Navigation", "N10AreThePremisesEquippedWithARecognizedApprovedCentralStationFireAlarmFireExtinguishersOrSmokeAlarms"));

    public Task PressN10AreThePremisesEquippedWithARecognizedApprovedCentralStationFireAlarmFireExtinguishersOrSmokeAlarmsAsync(string key) =>
        _ui.PressAsync(_locators.N10AreThePremisesEquippedWithARecognizedApprovedCentralStationFireAlarmFireExtinguishersOrSmokeAlarms, key, new ControlIntent("Navigation", "N10AreThePremisesEquippedWithARecognizedApprovedCentralStationFireAlarmFireExtinguishersOrSmokeAlarms"));

    public Task EnterN10HowAreTheGoodsBeingTransportedProtectedFromDamageAndTheftAsync(string value) =>
        _ui.FillAsync(_locators.N10HowAreTheGoodsBeingTransportedProtectedFromDamageAndTheft, value, new ControlIntent("Navigation", "N10HowAreTheGoodsBeingTransportedProtectedFromDamageAndTheft"));

    public Task PressN10HowAreTheGoodsBeingTransportedProtectedFromDamageAndTheftAsync(string key) =>
        _ui.PressAsync(_locators.N10HowAreTheGoodsBeingTransportedProtectedFromDamageAndTheft, key, new ControlIntent("Navigation", "N10HowAreTheGoodsBeingTransportedProtectedFromDamageAndTheft"));

    public Task EnterN11AreDriversMVRsAndTripLogsMaintainedAsync(string value) =>
        _ui.FillAsync(_locators.N11AreDriversMVRsAndTripLogsMaintained, value, new ControlIntent("Navigation", "N11AreDriversMVRsAndTripLogsMaintained"));

    public Task PressN11AreDriversMVRsAndTripLogsMaintainedAsync(string key) =>
        _ui.PressAsync(_locators.N11AreDriversMVRsAndTripLogsMaintained, key, new ControlIntent("Navigation", "N11AreDriversMVRsAndTripLogsMaintained"));

    public Task EnterN11WhatIsTheProcedureForTransportingPropertyIncludeTheTransitMethodsUsedAndTheProtectionClassProvidedWhileInTransitAsync(string value) =>
        _ui.FillAsync(_locators.N11WhatIsTheProcedureForTransportingPropertyIncludeTheTransitMethodsUsedAndTheProtectionClassProvidedWhileInTransit, value, new ControlIntent("Navigation", "N11WhatIsTheProcedureForTransportingPropertyIncludeTheTransitMethodsUsedAndTheProtectionClassProvidedWhileInTransit"));

    public Task PressN11WhatIsTheProcedureForTransportingPropertyIncludeTheTransitMethodsUsedAndTheProtectionClassProvidedWhileInTransitAsync(string key) =>
        _ui.PressAsync(_locators.N11WhatIsTheProcedureForTransportingPropertyIncludeTheTransitMethodsUsedAndTheProtectionClassProvidedWhileInTransit, key, new ControlIntent("Navigation", "N11WhatIsTheProcedureForTransportingPropertyIncludeTheTransitMethodsUsedAndTheProtectionClassProvidedWhileInTransit"));

    public Task EnterN12AreDriversMVRsReviewedOnARegularBasisAndMaintainedAsync(string value) =>
        _ui.FillAsync(_locators.N12AreDriversMVRsReviewedOnARegularBasisAndMaintained, value, new ControlIntent("Navigation", "N12AreDriversMVRsReviewedOnARegularBasisAndMaintained"));

    public Task PressN12AreDriversMVRsReviewedOnARegularBasisAndMaintainedAsync(string key) =>
        _ui.PressAsync(_locators.N12AreDriversMVRsReviewedOnARegularBasisAndMaintained, key, new ControlIntent("Navigation", "N12AreDriversMVRsReviewedOnARegularBasisAndMaintained"));

    public Task EnterN12HowOftenAreTheseLogsReviewedOrUpdatedAsync(string value) =>
        _ui.FillAsync(_locators.N12HowOftenAreTheseLogsReviewedOrUpdated, value, new ControlIntent("Navigation", "N12HowOftenAreTheseLogsReviewedOrUpdated"));

    public Task PressN12HowOftenAreTheseLogsReviewedOrUpdatedAsync(string key) =>
        _ui.PressAsync(_locators.N12HowOftenAreTheseLogsReviewedOrUpdated, key, new ControlIntent("Navigation", "N12HowOftenAreTheseLogsReviewedOrUpdated"));

    public Task EnterN13LiveAnimalInTransitCoverageAsync(string value) =>
        _ui.FillAsync(_locators.N13LiveAnimalInTransitCoverage, value, new ControlIntent("Navigation", "N13LiveAnimalInTransitCoverage"));

    public Task PressN13LiveAnimalInTransitCoverageAsync(string key) =>
        _ui.PressAsync(_locators.N13LiveAnimalInTransitCoverage, key, new ControlIntent("Navigation", "N13LiveAnimalInTransitCoverage"));

    public Task EnterN13WhatTypesOfVehiclesDoYouOperateAndWhatProtectiveDevicesAreOnEachVehicleAsync(string value) =>
        _ui.FillAsync(_locators.N13WhatTypesOfVehiclesDoYouOperateAndWhatProtectiveDevicesAreOnEachVehicle, value, new ControlIntent("Navigation", "N13WhatTypesOfVehiclesDoYouOperateAndWhatProtectiveDevicesAreOnEachVehicle"));

    public Task PressN13WhatTypesOfVehiclesDoYouOperateAndWhatProtectiveDevicesAreOnEachVehicleAsync(string key) =>
        _ui.PressAsync(_locators.N13WhatTypesOfVehiclesDoYouOperateAndWhatProtectiveDevicesAreOnEachVehicle, key, new ControlIntent("Navigation", "N13WhatTypesOfVehiclesDoYouOperateAndWhatProtectiveDevicesAreOnEachVehicle"));

    public Task EnterN14LegalLiabilityCoverageAsync(string value) =>
        _ui.FillAsync(_locators.N14LegalLiabilityCoverage, value, new ControlIntent("Navigation", "N14LegalLiabilityCoverage"));

    public Task PressN14LegalLiabilityCoverageAsync(string key) =>
        _ui.PressAsync(_locators.N14LegalLiabilityCoverage, key, new ControlIntent("Navigation", "N14LegalLiabilityCoverage"));

    public Task EnterN14WhatIsYourProcedureForProtectingSmallItemsFromBreakageOrDisappearanceWhileInStorageAsync(string value) =>
        _ui.FillAsync(_locators.N14WhatIsYourProcedureForProtectingSmallItemsFromBreakageOrDisappearanceWhileInStorage, value, new ControlIntent("Navigation", "N14WhatIsYourProcedureForProtectingSmallItemsFromBreakageOrDisappearanceWhileInStorage"));

    public Task PressN14WhatIsYourProcedureForProtectingSmallItemsFromBreakageOrDisappearanceWhileInStorageAsync(string key) =>
        _ui.PressAsync(_locators.N14WhatIsYourProcedureForProtectingSmallItemsFromBreakageOrDisappearanceWhileInStorage, key, new ControlIntent("Navigation", "N14WhatIsYourProcedureForProtectingSmallItemsFromBreakageOrDisappearanceWhileInStorage"));

    public Task EnterN15WhatMeasuresDoesTheInsuredTakeToProtectCustomerSPropertyAgainstTheftAsync(string value) =>
        _ui.FillAsync(_locators.N15WhatMeasuresDoesTheInsuredTakeToProtectCustomerSPropertyAgainstTheft, value, new ControlIntent("Navigation", "N15WhatMeasuresDoesTheInsuredTakeToProtectCustomerSPropertyAgainstTheft"));

    public Task PressN15WhatMeasuresDoesTheInsuredTakeToProtectCustomerSPropertyAgainstTheftAsync(string key) =>
        _ui.PressAsync(_locators.N15WhatMeasuresDoesTheInsuredTakeToProtectCustomerSPropertyAgainstTheft, key, new ControlIntent("Navigation", "N15WhatMeasuresDoesTheInsuredTakeToProtectCustomerSPropertyAgainstTheft"));

    public Task EnterN16DoesTheRiskUseReleaseFormsAsync(string value) =>
        _ui.FillAsync(_locators.N16DoesTheRiskUseReleaseForms, value, new ControlIntent("Navigation", "N16DoesTheRiskUseReleaseForms"));

    public Task PressN16DoesTheRiskUseReleaseFormsAsync(string key) =>
        _ui.PressAsync(_locators.N16DoesTheRiskUseReleaseForms, key, new ControlIntent("Navigation", "N16DoesTheRiskUseReleaseForms"));

    public Task EnterN1WhatAreTheDistancesTheShipmentsWillTravelAndTheTimeRequiredToCompleteTheShipmentAsync(string value) =>
        _ui.FillAsync(_locators.N1WhatAreTheDistancesTheShipmentsWillTravelAndTheTimeRequiredToCompleteTheShipment, value, new ControlIntent("Navigation", "N1WhatAreTheDistancesTheShipmentsWillTravelAndTheTimeRequiredToCompleteTheShipment"));

    public Task PressN1WhatAreTheDistancesTheShipmentsWillTravelAndTheTimeRequiredToCompleteTheShipmentAsync(string key) =>
        _ui.PressAsync(_locators.N1WhatAreTheDistancesTheShipmentsWillTravelAndTheTimeRequiredToCompleteTheShipment, key, new ControlIntent("Navigation", "N1WhatAreTheDistancesTheShipmentsWillTravelAndTheTimeRequiredToCompleteTheShipment"));

    public Task EnterN2IndicateTheAgeTypeOfConstructionAndProtectionClassOfThePremisesAsync(string value) =>
        _ui.FillAsync(_locators.N2IndicateTheAgeTypeOfConstructionAndProtectionClassOfThePremises, value, new ControlIntent("Navigation", "N2IndicateTheAgeTypeOfConstructionAndProtectionClassOfThePremises"));

    public Task PressN2IndicateTheAgeTypeOfConstructionAndProtectionClassOfThePremisesAsync(string key) =>
        _ui.PressAsync(_locators.N2IndicateTheAgeTypeOfConstructionAndProtectionClassOfThePremises, key, new ControlIntent("Navigation", "N2IndicateTheAgeTypeOfConstructionAndProtectionClassOfThePremises"));

    public Task EnterN2WhatAreTheTypesAndAgesOfTheVehiclesTrailersUsedToTransportYourCommoditiesAsync(string value) =>
        _ui.FillAsync(_locators.N2WhatAreTheTypesAndAgesOfTheVehiclesTrailersUsedToTransportYourCommodities, value, new ControlIntent("Navigation", "N2WhatAreTheTypesAndAgesOfTheVehiclesTrailersUsedToTransportYourCommodities"));

    public Task PressN2WhatAreTheTypesAndAgesOfTheVehiclesTrailersUsedToTransportYourCommoditiesAsync(string key) =>
        _ui.PressAsync(_locators.N2WhatAreTheTypesAndAgesOfTheVehiclesTrailersUsedToTransportYourCommodities, key, new ControlIntent("Navigation", "N2WhatAreTheTypesAndAgesOfTheVehiclesTrailersUsedToTransportYourCommodities"));

    public Task EnterN2ndClassCategoryAsync(string value) =>
        _ui.FillAsync(_locators.N2ndClassCategory, value, new ControlIntent("Navigation", "N2ndClassCategory"));

    public Task PressN2ndClassCategoryAsync(string key) =>
        _ui.PressAsync(_locators.N2ndClassCategory, key, new ControlIntent("Navigation", "N2ndClassCategory"));

    public Task EnterN2ndClassCodeAsync(string value) =>
        _ui.FillAsync(_locators.N2ndClassCode, value, new ControlIntent("Navigation", "N2ndClassCode"));

    public Task PressN2ndClassCodeAsync(string key) =>
        _ui.PressAsync(_locators.N2ndClassCode, key, new ControlIntent("Navigation", "N2ndClassCode"));

    public Task EnterN3DoesTheApplicantHaulForOthersAsync(string value) =>
        _ui.FillAsync(_locators.N3DoesTheApplicantHaulForOthers, value, new ControlIntent("Navigation", "N3DoesTheApplicantHaulForOthers"));

    public Task PressN3DoesTheApplicantHaulForOthersAsync(string key) =>
        _ui.PressAsync(_locators.N3DoesTheApplicantHaulForOthers, key, new ControlIntent("Navigation", "N3DoesTheApplicantHaulForOthers"));

    public Task EnterN3WhatIsThePercentageOfAnnualGrossReceiptsDerivedFromServiceOrRepairAsync(string value) =>
        _ui.FillAsync(_locators.N3WhatIsThePercentageOfAnnualGrossReceiptsDerivedFromServiceOrRepair, value, new ControlIntent("Navigation", "N3WhatIsThePercentageOfAnnualGrossReceiptsDerivedFromServiceOrRepair"));

    public Task PressN3WhatIsThePercentageOfAnnualGrossReceiptsDerivedFromServiceOrRepairAsync(string key) =>
        _ui.PressAsync(_locators.N3WhatIsThePercentageOfAnnualGrossReceiptsDerivedFromServiceOrRepair, key, new ControlIntent("Navigation", "N3WhatIsThePercentageOfAnnualGrossReceiptsDerivedFromServiceOrRepair"));

    public Task EnterN4WhatMethodDoYouUseForKeepingRecordsOfPropertyInYourCareAndHowOftenAreTheRecordsUpdatedAsync(string value) =>
        _ui.FillAsync(_locators.N4WhatMethodDoYouUseForKeepingRecordsOfPropertyInYourCareAndHowOftenAreTheRecordsUpdated, value, new ControlIntent("Navigation", "N4WhatMethodDoYouUseForKeepingRecordsOfPropertyInYourCareAndHowOftenAreTheRecordsUpdated"));

    public Task PressN4WhatMethodDoYouUseForKeepingRecordsOfPropertyInYourCareAndHowOftenAreTheRecordsUpdatedAsync(string key) =>
        _ui.PressAsync(_locators.N4WhatMethodDoYouUseForKeepingRecordsOfPropertyInYourCareAndHowOftenAreTheRecordsUpdated, key, new ControlIntent("Navigation", "N4WhatMethodDoYouUseForKeepingRecordsOfPropertyInYourCareAndHowOftenAreTheRecordsUpdated"));

    public Task EnterN4WhatProtectiveDevicesAreInstalledOnEachVehicleOrTrailerAsync(string value) =>
        _ui.FillAsync(_locators.N4WhatProtectiveDevicesAreInstalledOnEachVehicleOrTrailer, value, new ControlIntent("Navigation", "N4WhatProtectiveDevicesAreInstalledOnEachVehicleOrTrailer"));

    public Task PressN4WhatProtectiveDevicesAreInstalledOnEachVehicleOrTrailerAsync(string key) =>
        _ui.PressAsync(_locators.N4WhatProtectiveDevicesAreInstalledOnEachVehicleOrTrailer, key, new ControlIntent("Navigation", "N4WhatProtectiveDevicesAreInstalledOnEachVehicleOrTrailer"));

    public Task EnterN5AreRecognizedApprovedCentralStationBurglarAlarmsInstalledAndMaintainedAsync(string value) =>
        _ui.FillAsync(_locators.N5AreRecognizedApprovedCentralStationBurglarAlarmsInstalledAndMaintained, value, new ControlIntent("Navigation", "N5AreRecognizedApprovedCentralStationBurglarAlarmsInstalledAndMaintained"));

    public Task PressN5AreRecognizedApprovedCentralStationBurglarAlarmsInstalledAndMaintainedAsync(string key) =>
        _ui.PressAsync(_locators.N5AreRecognizedApprovedCentralStationBurglarAlarmsInstalledAndMaintained, key, new ControlIntent("Navigation", "N5AreRecognizedApprovedCentralStationBurglarAlarmsInstalledAndMaintained"));

    public Task EnterN5DeductibleAsync(string value) =>
        _ui.FillAsync(_locators.N5Deductible, value, new ControlIntent("Navigation", "N5Deductible"));

    public Task PressN5DeductibleAsync(string key) =>
        _ui.PressAsync(_locators.N5Deductible, key, new ControlIntent("Navigation", "N5Deductible"));

    public Task EnterN5DoAnyVehiclesHaveSpecialEquipmentMountedOrAttachedAsync(string value) =>
        _ui.FillAsync(_locators.N5DoAnyVehiclesHaveSpecialEquipmentMountedOrAttached, value, new ControlIntent("Navigation", "N5DoAnyVehiclesHaveSpecialEquipmentMountedOrAttached"));

    public Task PressN5DoAnyVehiclesHaveSpecialEquipmentMountedOrAttachedAsync(string key) =>
        _ui.PressAsync(_locators.N5DoAnyVehiclesHaveSpecialEquipmentMountedOrAttached, key, new ControlIntent("Navigation", "N5DoAnyVehiclesHaveSpecialEquipmentMountedOrAttached"));

    public Task EnterN6AreAllStorageAreasLockedAtAllTimesWhenUnoccupiedAsync(string value) =>
        _ui.FillAsync(_locators.N6AreAllStorageAreasLockedAtAllTimesWhenUnoccupied, value, new ControlIntent("Navigation", "N6AreAllStorageAreasLockedAtAllTimesWhenUnoccupied"));

    public Task PressN6AreAllStorageAreasLockedAtAllTimesWhenUnoccupiedAsync(string key) =>
        _ui.PressAsync(_locators.N6AreAllStorageAreasLockedAtAllTimesWhenUnoccupied, key, new ControlIntent("Navigation", "N6AreAllStorageAreasLockedAtAllTimesWhenUnoccupied"));

    public Task EnterN6DoesTheApplicantPullDoubleOrTripleTrailersAsync(string value) =>
        _ui.FillAsync(_locators.N6DoesTheApplicantPullDoubleOrTripleTrailers, value, new ControlIntent("Navigation", "N6DoesTheApplicantPullDoubleOrTripleTrailers"));

    public Task PressN6DoesTheApplicantPullDoubleOrTripleTrailersAsync(string key) =>
        _ui.PressAsync(_locators.N6DoesTheApplicantPullDoubleOrTripleTrailers, key, new ControlIntent("Navigation", "N6DoesTheApplicantPullDoubleOrTripleTrailers"));

    public Task EnterN7AreThereAnyHazardousOrFlammableMaterialsUsedOrStoredOnThePremisesAsync(string value) =>
        _ui.FillAsync(_locators.N7AreThereAnyHazardousOrFlammableMaterialsUsedOrStoredOnThePremises, value, new ControlIntent("Navigation", "N7AreThereAnyHazardousOrFlammableMaterialsUsedOrStoredOnThePremises"));

    public Task PressN7AreThereAnyHazardousOrFlammableMaterialsUsedOrStoredOnThePremisesAsync(string key) =>
        _ui.PressAsync(_locators.N7AreThereAnyHazardousOrFlammableMaterialsUsedOrStoredOnThePremises, key, new ControlIntent("Navigation", "N7AreThereAnyHazardousOrFlammableMaterialsUsedOrStoredOnThePremises"));

    public Task EnterN7DoesTheApplicantLeaveTheTruckWindowsDoorsAndCompartmentsClosedAndLockedWhenUnattendedAsync(string value) =>
        _ui.FillAsync(_locators.N7DoesTheApplicantLeaveTheTruckWindowsDoorsAndCompartmentsClosedAndLockedWhenUnattended, value, new ControlIntent("Navigation", "N7DoesTheApplicantLeaveTheTruckWindowsDoorsAndCompartmentsClosedAndLockedWhenUnattended"));

    public Task PressN7DoesTheApplicantLeaveTheTruckWindowsDoorsAndCompartmentsClosedAndLockedWhenUnattendedAsync(string key) =>
        _ui.PressAsync(_locators.N7DoesTheApplicantLeaveTheTruckWindowsDoorsAndCompartmentsClosedAndLockedWhenUnattended, key, new ControlIntent("Navigation", "N7DoesTheApplicantLeaveTheTruckWindowsDoorsAndCompartmentsClosedAndLockedWhenUnattended"));

    public Task EnterN8DoYouProvideScheduledMaintenanceForTheVehiclesAndTrailersYouOperateAsync(string value) =>
        _ui.FillAsync(_locators.N8DoYouProvideScheduledMaintenanceForTheVehiclesAndTrailersYouOperate, value, new ControlIntent("Navigation", "N8DoYouProvideScheduledMaintenanceForTheVehiclesAndTrailersYouOperate"));

    public Task PressN8DoYouProvideScheduledMaintenanceForTheVehiclesAndTrailersYouOperateAsync(string key) =>
        _ui.PressAsync(_locators.N8DoYouProvideScheduledMaintenanceForTheVehiclesAndTrailersYouOperate, key, new ControlIntent("Navigation", "N8DoYouProvideScheduledMaintenanceForTheVehiclesAndTrailersYouOperate"));

    public Task EnterN9AreTheEmployeesThatPackLoadAndUnloadTrainedInProperHandlingOfTheCommoditiesAsync(string value) =>
        _ui.FillAsync(_locators.N9AreTheEmployeesThatPackLoadAndUnloadTrainedInProperHandlingOfTheCommodities, value, new ControlIntent("Navigation", "N9AreTheEmployeesThatPackLoadAndUnloadTrainedInProperHandlingOfTheCommodities"));

    public Task PressN9AreTheEmployeesThatPackLoadAndUnloadTrainedInProperHandlingOfTheCommoditiesAsync(string key) =>
        _ui.PressAsync(_locators.N9AreTheEmployeesThatPackLoadAndUnloadTrainedInProperHandlingOfTheCommodities, key, new ControlIntent("Navigation", "N9AreTheEmployeesThatPackLoadAndUnloadTrainedInProperHandlingOfTheCommodities"));

    public Task EnterN9AreThePremisesOrAnyPortionOfThePremisesEquippedWithASprinklerSystemAsync(string value) =>
        _ui.FillAsync(_locators.N9AreThePremisesOrAnyPortionOfThePremisesEquippedWithASprinklerSystem, value, new ControlIntent("Navigation", "N9AreThePremisesOrAnyPortionOfThePremisesEquippedWithASprinklerSystem"));

    public Task PressN9AreThePremisesOrAnyPortionOfThePremisesEquippedWithASprinklerSystemAsync(string key) =>
        _ui.PressAsync(_locators.N9AreThePremisesOrAnyPortionOfThePremisesEquippedWithASprinklerSystem, key, new ControlIntent("Navigation", "N9AreThePremisesOrAnyPortionOfThePremisesEquippedWithASprinklerSystem"));

    public Task WaitForNAICSCodeSearchValueAsync(string expected) =>
        _ui.WaitAsync(_locators.NAICSCodeSearchValue, expected, new ControlIntent("Navigation", "NAICSCodeSearchValue"));

    public Task EnterNAICSCodeSearchValueAsync(string value) =>
        _ui.FillAsync(_locators.NAICSCodeSearchValue, value, new ControlIntent("Navigation", "NAICSCodeSearchValue"));

    public Task PressNAICSCodeSearchValueAsync(string key) =>
        _ui.PressAsync(_locators.NAICSCodeSearchValue, key, new ControlIntent("Navigation", "NAICSCodeSearchValue"));

    public Task ClickNAICSCodeSearchValueAsync() =>
        _ui.ClickAsync(_locators.NAICSCodeSearchValue, new ControlIntent("Navigation", "NAICSCodeSearchValue"));

    public Task EnterNameSOrDescriptionSAndDateSOfDesignatedActivitiesOrServicesAsync(string value) =>
        _ui.FillAsync(_locators.NameSOrDescriptionSAndDateSOfDesignatedActivitiesOrServices, value, new ControlIntent("Navigation", "NameSOrDescriptionSAndDateSOfDesignatedActivitiesOrServices"));

    public Task PressNameSOrDescriptionSAndDateSOfDesignatedActivitiesOrServicesAsync(string key) =>
        _ui.PressAsync(_locators.NameSOrDescriptionSAndDateSOfDesignatedActivitiesOrServices, key, new ControlIntent("Navigation", "NameSOrDescriptionSAndDateSOfDesignatedActivitiesOrServices"));

    public Task EnterNamesAsync(string value) =>
        _ui.FillAsync(_locators.Names, value, new ControlIntent("Navigation", "Names"));

    public Task PressNamesAsync(string key) =>
        _ui.PressAsync(_locators.Names, key, new ControlIntent("Navigation", "Names"));

    public Task WaitForNoKnownLossesAsync(string expected) =>
        _ui.WaitAsync(_locators.NoKnownLosses, expected, new ControlIntent("Navigation", "NoKnownLosses"));

    public Task SetNoKnownLossesAsync(string value) =>
        _ui.SmartSetAsync(_locators.NoKnownLosses, value, new ControlIntent("Navigation", "NoKnownLosses"));

    public Task PressNoKnownLossesAsync(string key) =>
        _ui.PressAsync(_locators.NoKnownLosses, key, new ControlIntent("Navigation", "NoKnownLosses"));

    public Task ClickNoKnownLossesAsync() =>
        _ui.ClickAsync(_locators.NoKnownLosses, new ControlIntent("Navigation", "NoKnownLosses"));

    public Task EnterNonOwnedAutoAsync(string value) =>
        _ui.FillAsync(_locators.NonOwnedAuto, value, new ControlIntent("Navigation", "NonOwnedAuto"));

    public Task PressNonOwnedAutoAsync(string key) =>
        _ui.PressAsync(_locators.NonOwnedAuto, key, new ControlIntent("Navigation", "NonOwnedAuto"));

    public Task ClickNotepadAsync() =>
        _ui.ClickAsync(_locators.PageTitle, new ControlIntent("Navigation", "Notepad"));

    public Task WaitForNotepadHeadingAsync(string expected) =>
        _ui.WaitAsync(_locators.PageTitle, expected, new ControlIntent("Navigation", "NotepadHeading"));

    public Task EnterNumberOfEmployeesAsync(string value) =>
        _ui.FillAsync(_locators.NumberOfEmployees, value, new ControlIntent("Navigation", "NumberOfEmployees"));

    public Task PressNumberOfEmployeesAsync(string key) =>
        _ui.PressAsync(_locators.NumberOfEmployees, key, new ControlIntent("Navigation", "NumberOfEmployees"));

    public Task EnterNumberOfFullTimeEmployeesAsync(string value) =>
        _ui.FillAsync(_locators.NumberOfFullTimeEmployees, value, new ControlIntent("Navigation", "NumberOfFullTimeEmployees"));

    public Task PressNumberOfFullTimeEmployeesAsync(string key) =>
        _ui.PressAsync(_locators.NumberOfFullTimeEmployees, key, new ControlIntent("Navigation", "NumberOfFullTimeEmployees"));

    public Task EnterNumberOfPartTimeEmployeesAsync(string value) =>
        _ui.FillAsync(_locators.NumberOfPartTimeEmployees, value, new ControlIntent("Navigation", "NumberOfPartTimeEmployees"));

    public Task PressNumberOfPartTimeEmployeesAsync(string key) =>
        _ui.PressAsync(_locators.NumberOfPartTimeEmployees, key, new ControlIntent("Navigation", "NumberOfPartTimeEmployees"));

    public Task EnterNumberOfVehiclesAsync(string value) =>
        _ui.FillAsync(_locators.NumberOfVehicles, value, new ControlIntent("Navigation", "NumberOfVehicles"));

    public Task PressNumberOfVehiclesAsync(string key) =>
        _ui.PressAsync(_locators.NumberOfVehicles, key, new ControlIntent("Navigation", "NumberOfVehicles"));

    public Task ClickOCPAsync() =>
        _ui.ClickAsync(_locators.OCP, new ControlIntent("Navigation", "OCP"));

    public Task WaitForOKAsync(string expected) =>
        _ui.WaitAsync(_locators.OK, expected, new ControlIntent("Navigation", "OK"));

    public Task WaitForOKClassCodeAsync(string expected) =>
        _ui.WaitAsync(_locators.OKControl, expected, new ControlIntent("Navigation", "OKClassCode"));

    public Task VerifyOKClassCodeAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.OKControl, expected, property, new ControlIntent("Navigation", "OKClassCode"));

    public Task ClickOKClassCodeAsync() =>
        _ui.ClickAsync(_locators.OKControl, new ControlIntent("Navigation", "OKClassCode"));

    public Task ClickOKDetailsAsync() =>
        _ui.ClickAsync(_locators.OKControl, new ControlIntent("Navigation", "OKDetails"));

    public Task PressOKFirstAsync(string key) =>
        _ui.PressAsync(_locators.OKControl, key, new ControlIntent("Navigation", "OKFirst"));

    public Task ClickOKFirstAsync() =>
        _ui.ClickAsync(_locators.OKControl, new ControlIntent("Navigation", "OKFirst"));

    public Task WaitForOKSecondAsync(string expected) =>
        _ui.WaitAsync(_locators.OKControl, expected, new ControlIntent("Navigation", "OKSecond"));

    public Task EnterOTCCausesOfLossAsync(string value) =>
        _ui.FillAsync(_locators.OTCCausesOfLoss, value, new ControlIntent("Navigation", "OTCCausesOfLoss"));

    public Task PressOTCCausesOfLossAsync(string key) =>
        _ui.PressAsync(_locators.OTCCausesOfLoss, key, new ControlIntent("Navigation", "OTCCausesOfLoss"));

    public Task EnterStateDetailsHiredAutoPDWithoutDriverOTCDeductibleAsync(string value) =>
        _ui.FillAsync(_locators.StateDetailsHiredAutoPDWithoutDriverOTCDeductible, value, new ControlIntent("Navigation", "StateDetailsHiredAutoPDWithoutDriverOTCDeductible"));

    public Task PressStateDetailsHiredAutoPDWithoutDriverOTCDeductibleAsync(string key) =>
        _ui.PressAsync(_locators.StateDetailsHiredAutoPDWithoutDriverOTCDeductible, key, new ControlIntent("Navigation", "StateDetailsHiredAutoPDWithoutDriverOTCDeductible"));

    public Task WaitForStateDetailsDriveOtherCarOTCDeductibleAsync(string expected) =>
        _ui.WaitAsync(_locators.StateDetailsDriveOtherCarOTCDeductible, expected, new ControlIntent("Navigation", "StateDetailsDriveOtherCarOTCDeductible"));

    public Task ClickStateDetailsHiredAutoPDWithoutDriverIfAnyFieldAsync() =>
        _ui.ClickAsync(_locators.StateDetailsHiredAutoPDWithoutDriverIfAnyField, new ControlIntent("Navigation", "StateDetailsHiredAutoPDWithoutDriverIfAnyField"));

    public Task ClickStateDetailsHiredAutoPhysicalDamageWithDriverIfAnyFieldAsync() =>
        _ui.ClickAsync(_locators.StateDetailsHiredAutoPhysicalDamageWithDriverIfAnyField, new ControlIntent("Navigation", "StateDetailsHiredAutoPhysicalDamageWithDriverIfAnyField"));

    public Task EnterOccupancyTypeAsync(string value) =>
        _ui.FillAsync(_locators.OccupancyType, value, new ControlIntent("Navigation", "OccupancyType"));

    public Task PressOccupancyTypeAsync(string key) =>
        _ui.PressAsync(_locators.OccupancyType, key, new ControlIntent("Navigation", "OccupancyType"));

    public Task EnterOccupiedAsync(string value) =>
        _ui.FillAsync(_locators.Occupied, value, new ControlIntent("Navigation", "Occupied"));

    public Task PressOccupiedAsync(string key) =>
        _ui.PressAsync(_locators.Occupied, key, new ControlIntent("Navigation", "Occupied"));

    public Task EnterOccurenceLimitAsync(string value) =>
        _ui.FillAsync(_locators.OccurenceLimit, value, new ControlIntent("Navigation", "OccurenceLimit"));

    public Task PressOccurenceLimitAsync(string key) =>
        _ui.PressAsync(_locators.OccurenceLimit, key, new ControlIntent("Navigation", "OccurenceLimit"));

    public Task WaitForOfEmployeesAsync(string expected) =>
        _ui.WaitAsync(_locators.OfEmployees, expected, new ControlIntent("Navigation", "OfEmployees"));

    public Task EnterOfEmployeesAsync(string value) =>
        _ui.FillAsync(_locators.OfEmployees, value, new ControlIntent("Navigation", "OfEmployees"));

    public Task PressOfEmployeesAsync(string key) =>
        _ui.PressAsync(_locators.OfEmployees, key, new ControlIntent("Navigation", "OfEmployees"));

    public Task EnterOfFullTimeEmployeesAsync(string value) =>
        _ui.FillAsync(_locators.OfFullTimeEmployees, value, new ControlIntent("Navigation", "OfFullTimeEmployees"));

    public Task PressOfFullTimeEmployeesAsync(string key) =>
        _ui.PressAsync(_locators.OfFullTimeEmployees, key, new ControlIntent("Navigation", "OfFullTimeEmployees"));

    public Task EnterOfPartTimeEmployeesAsync(string value) =>
        _ui.FillAsync(_locators.OfPartTimeEmployees, value, new ControlIntent("Navigation", "OfPartTimeEmployees"));

    public Task PressOfPartTimeEmployeesAsync(string key) =>
        _ui.PressAsync(_locators.OfPartTimeEmployees, key, new ControlIntent("Navigation", "OfPartTimeEmployees"));

    public Task EnterOfPartnersAsync(string value) =>
        _ui.FillAsync(_locators.OfPartners, value, new ControlIntent("Navigation", "OfPartners"));

    public Task PressOfPartnersAsync(string key) =>
        _ui.PressAsync(_locators.OfPartners, key, new ControlIntent("Navigation", "OfPartners"));

    public Task EnterOfSeasonalTemporaryEmployeesAsync(string value) =>
        _ui.FillAsync(_locators.OfSeasonalTemporaryEmployees, value, new ControlIntent("Navigation", "OfSeasonalTemporaryEmployees"));

    public Task PressOfSeasonalTemporaryEmployeesAsync(string key) =>
        _ui.PressAsync(_locators.OfSeasonalTemporaryEmployees, key, new ControlIntent("Navigation", "OfSeasonalTemporaryEmployees"));

    public Task EnterOfficersAsync(string value) =>
        _ui.FillAsync(_locators.Officers, value, new ControlIntent("Navigation", "Officers"));

    public Task PressOfficersAsync(string key) =>
        _ui.PressAsync(_locators.Officers, key, new ControlIntent("Navigation", "Officers"));

    public Task EnterOfficersPositionHeldAsync(string value) =>
        _ui.FillAsync(_locators.OfficersPositionHeld, value, new ControlIntent("Navigation", "OfficersPositionHeld"));

    public Task PressOfficersPositionHeldAsync(string key) =>
        _ui.PressAsync(_locators.OfficersPositionHeld, key, new ControlIntent("Navigation", "OfficersPositionHeld"));

    public Task ClickOptionACheckBoxAsync() =>
        _ui.ClickAsync(_locators.OptionACheckBox, new ControlIntent("Navigation", "OptionACheckBox"));

    public Task WaitForOptionAScheduleButtonAsync(string expected) =>
        _ui.WaitAsync(_locators.OptionAScheduleButton, expected, new ControlIntent("Navigation", "OptionAScheduleButton"));

    public Task ClickOptionAScheduleButtonAsync() =>
        _ui.ClickAsync(_locators.OptionAScheduleButton, new ControlIntent("Navigation", "OptionAScheduleButton"));

    public Task VerifyOrderAuditAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.OrderAudit, expected, property, new ControlIntent("Navigation", "OrderAudit"));

    public Task EnterOrderAuditAsync(string value) =>
        _ui.FillAsync(_locators.OrderAudit, value, new ControlIntent("Navigation", "OrderAudit"));

    public Task PressOrderAuditAsync(string key) =>
        _ui.PressAsync(_locators.OrderAudit, key, new ControlIntent("Navigation", "OrderAudit"));

    public Task EnterOriginalCostNewAsync(string value) =>
        _ui.FillAsync(_locators.RiskVehicleInputValueEstimate, value, new ControlIntent("Navigation", "OriginalCostNew"));

    public Task PressOriginalCostNewAsync(string key) =>
        _ui.PressAsync(_locators.RiskVehicleInputValueEstimate, key, new ControlIntent("Navigation", "OriginalCostNew"));

    public Task EnterOthersAsync(string value) =>
        _ui.FillAsync(_locators.Others, value, new ControlIntent("Navigation", "Others"));

    public Task PressOthersAsync(string key) =>
        _ui.PressAsync(_locators.Others, key, new ControlIntent("Navigation", "Others"));

    public Task EnterPartnersAsync(string value) =>
        _ui.FillAsync(_locators.Partners, value, new ControlIntent("Navigation", "Partners"));

    public Task PressPartnersAsync(string key) =>
        _ui.PressAsync(_locators.Partners, key, new ControlIntent("Navigation", "Partners"));

    public Task WaitForPayPlanAsync(string expected) =>
        _ui.WaitAsync(_locators.PayPlan, expected, new ControlIntent("Navigation", "PayPlan"));

    public Task EnterPayPlanAsync(string value) =>
        _ui.FillAsync(_locators.PayPlan, value, new ControlIntent("Navigation", "PayPlan"));

    public Task PressPayPlanAsync(string key) =>
        _ui.PressAsync(_locators.PayPlan, key, new ControlIntent("Navigation", "PayPlan"));

    public Task VerifyPendingRateChangeAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.PendingRateChange, expected, property, new ControlIntent("Navigation", "PendingRateChange"));

    public Task EnterPerVehicleLimitAsync(string value) =>
        _ui.FillAsync(_locators.PerVehicleLimit, value, new ControlIntent("Navigation", "PerVehicleLimit"));

    public Task PressPerVehicleLimitAsync(string key) =>
        _ui.PressAsync(_locators.PerVehicleLimit, key, new ControlIntent("Navigation", "PerVehicleLimit"));

    public Task EnterPersAdvInjAsync(string value) =>
        _ui.FillAsync(_locators.PersAdvInj, value, new ControlIntent("Navigation", "PersAdvInj"));

    public Task PressPersAdvInjAsync(string key) =>
        _ui.PressAsync(_locators.PersAdvInj, key, new ControlIntent("Navigation", "PersAdvInj"));

    public Task EnterPersonalPortableComputersAsync(string value) =>
        _ui.FillAsync(_locators.PersonalPortableComputers, value, new ControlIntent("Navigation", "PersonalPortableComputers"));

    public Task PressPersonalPortableComputersAsync(string key) =>
        _ui.PressAsync(_locators.PersonalPortableComputers, key, new ControlIntent("Navigation", "PersonalPortableComputers"));

    public Task EnterPersonalPropertyLimitAsync(string value) =>
        _ui.FillAsync(_locators.PersonalPropertyLimit, value, new ControlIntent("Navigation", "PersonalPropertyLimit"));

    public Task PressPersonalPropertyLimitAsync(string key) =>
        _ui.PressAsync(_locators.PersonalPropertyLimit, key, new ControlIntent("Navigation", "PersonalPropertyLimit"));

    public Task EnterPersonalPropertyRatingGroupAsync(string value) =>
        _ui.FillAsync(_locators.RiskInputRatingGroupID, value, new ControlIntent("Navigation", "PersonalPropertyRatingGroup"));

    public Task PressPersonalPropertyRatingGroupAsync(string key) =>
        _ui.PressAsync(_locators.RiskInputRatingGroupID, key, new ControlIntent("Navigation", "PersonalPropertyRatingGroup"));

    public Task EnterPierOrWharfAsync(string value) =>
        _ui.FillAsync(_locators.PierOrWharf, value, new ControlIntent("Navigation", "PierOrWharf"));

    public Task PressPierOrWharfAsync(string key) =>
        _ui.PressAsync(_locators.PierOrWharf, key, new ControlIntent("Navigation", "PierOrWharf"));

    public Task WaitForPierOrWharfCOLOptionsAsync(string expected) =>
        _ui.WaitAsync(_locators.PierOrWharfCOLOptions, expected, new ControlIntent("Navigation", "PierOrWharfCOLOptions"));

    public Task EnterPierOrWharfCOLOptionsAsync(string value) =>
        _ui.FillAsync(_locators.PierOrWharfCOLOptions, value, new ControlIntent("Navigation", "PierOrWharfCOLOptions"));

    public Task PressPierOrWharfCOLOptionsAsync(string key) =>
        _ui.PressAsync(_locators.PierOrWharfCOLOptions, key, new ControlIntent("Navigation", "PierOrWharfCOLOptions"));

    public Task EnterPierOrWharfCauseOfLossAsync(string value) =>
        _ui.FillAsync(_locators.PierOrWharfCauseOfLoss, value, new ControlIntent("Navigation", "PierOrWharfCauseOfLoss"));

    public Task PressPierOrWharfCauseOfLossAsync(string key) =>
        _ui.PressAsync(_locators.PierOrWharfCauseOfLoss, key, new ControlIntent("Navigation", "PierOrWharfCauseOfLoss"));

    public Task EnterPierOrWharfConstructionAsync(string value) =>
        _ui.FillAsync(_locators.PierOrWharfConstruction, value, new ControlIntent("Navigation", "PierOrWharfConstruction"));

    public Task PressPierOrWharfConstructionAsync(string key) =>
        _ui.PressAsync(_locators.PierOrWharfConstruction, key, new ControlIntent("Navigation", "PierOrWharfConstruction"));

    public Task EnterPleaseProvideWebsiteAddressEsAsync(string value) =>
        _ui.FillAsync(_locators.PleaseProvideWebsiteAddressEs, value, new ControlIntent("Navigation", "PleaseProvideWebsiteAddressEs"));

    public Task ClickPolicyCovgerageAsync() =>
        _ui.ClickAsync(_locators.PolicyCovgerage, new ControlIntent("Navigation", "PolicyCovgerage"));

    public Task WaitForPolicyCovgGLPolicyCovgAsync(string expected) =>
        _ui.WaitAsync(_locators.PageTitle, expected, new ControlIntent("Navigation", "PolicyCovgGLPolicyCovg"));

    public Task ClickIMNavigationLinksPolicyCovgAsync() =>
        _ui.ClickAsync(_locators.PolicyCovgerage, new ControlIntent("Navigation", "IMNavigationLinksPolicyCovg"));

    public Task WaitForPolicyCovgMainPolicyCovgAsync(string expected) =>
        _ui.WaitAsync(_locators.PageTitle, expected, new ControlIntent("Navigation", "PolicyCovgMainPolicyCovg"));

    public Task WaitForPolicyCovgAsync(string expected) =>
        _ui.WaitAsync(_locators.PolicyCovg, expected, new ControlIntent("Navigation", "PolicyCovg"));

    public Task WaitForPolicyCovgerageAsync(string expected) =>
        _ui.WaitAsync(_locators.PolicyCovgerage, expected, new ControlIntent("Navigation", "PolicyCovgerage"));

    public Task EnterPolicyHolderNameAsync(string value) =>
        _ui.FillAsync(_locators.PolicyHolderName, value, new ControlIntent("Navigation", "PolicyHolderName"));

    public Task PressPolicyHolderNameAsync(string key) =>
        _ui.PressAsync(_locators.PolicyHolderName, key, new ControlIntent("Navigation", "PolicyHolderName"));

    public Task ClickPolicyInfoAsync() =>
        _ui.ClickAsync(_locators.PageTitle, new ControlIntent("Navigation", "PolicyInfo"));

    public Task WaitForPolicyInfoHeaderAsync(string expected) =>
        _ui.WaitAsync(_locators.PageTitle, expected, new ControlIntent("Navigation", "PolicyInfoHeader"));

    public Task EnterCommercialAutoPolicyNumberAsync(string value) =>
        _ui.FillAsync(_locators.BusinessownersPolicyNumber, value, new ControlIntent("Navigation", "CommercialAutoPolicyNumber"));

    public Task PressCommercialAutoPolicyNumberAsync(string key) =>
        _ui.PressAsync(_locators.BusinessownersPolicyNumber, key, new ControlIntent("Navigation", "CommercialAutoPolicyNumber"));

    public Task EnterBusinessownersPolicyNumberAsync(string value) =>
        _ui.FillAsync(_locators.BusinessownersPolicyNumber, value, new ControlIntent("Navigation", "BusinessownersPolicyNumber"));

    public Task PressBusinessownersPolicyNumberAsync(string key) =>
        _ui.PressAsync(_locators.BusinessownersPolicyNumber, key, new ControlIntent("Navigation", "BusinessownersPolicyNumber"));

    public Task EnterGeneralLiabilityPolicyNumberAsync(string value) =>
        _ui.FillAsync(_locators.BusinessownersPolicyNumber, value, new ControlIntent("Navigation", "GeneralLiabilityPolicyNumber"));

    public Task PressGeneralLiabilityPolicyNumberAsync(string key) =>
        _ui.PressAsync(_locators.BusinessownersPolicyNumber, key, new ControlIntent("Navigation", "GeneralLiabilityPolicyNumber"));

    public Task EnterPolicyTypeAsync(string value) =>
        _ui.FillAsync(_locators.PolicyType, value, new ControlIntent("Navigation", "PolicyType"));

    public Task PressPolicyTypeAsync(string key) =>
        _ui.PressAsync(_locators.PolicyType, key, new ControlIntent("Navigation", "PolicyType"));

    public Task EnterPowerSuppressorVoltageRegulatorAsync(string value) =>
        _ui.FillAsync(_locators.PowerSuppressorVoltageRegulator, value, new ControlIntent("Navigation", "PowerSuppressorVoltageRegulator"));

    public Task PressPowerSuppressorVoltageRegulatorAsync(string key) =>
        _ui.PressAsync(_locators.PowerSuppressorVoltageRegulator, key, new ControlIntent("Navigation", "PowerSuppressorVoltageRegulator"));

    public Task EnterPremOpDedAsync(string value) =>
        _ui.FillAsync(_locators.PremOpDed, value, new ControlIntent("Navigation", "PremOpDed"));

    public Task PressPremOpDedAsync(string key) =>
        _ui.PressAsync(_locators.PremOpDed, key, new ControlIntent("Navigation", "PremOpDed"));

    public Task EnterPremOpPDDedAsync(string value) =>
        _ui.FillAsync(_locators.PremOpPDDed, value, new ControlIntent("Navigation", "PremOpPDDed"));

    public Task EnterPremisesTypeAsync(string value) =>
        _ui.FillAsync(_locators.PremisesType, value, new ControlIntent("Navigation", "PremisesType"));

    public Task PressPremisesTypeAsync(string key) =>
        _ui.PressAsync(_locators.PremisesType, key, new ControlIntent("Navigation", "PremisesType"));

    public Task VerifyPremiumAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.Premium, expected, property, new ControlIntent("Navigation", "Premium"));

    public Task ClickPricingAsync() =>
        _ui.ClickAsync(_locators.PageTitle, new ControlIntent("Navigation", "Pricing"));

    public Task WaitForPricingDetailAsync(string expected) =>
        _ui.WaitAsync(_locators.PricingDetail, expected, new ControlIntent("Navigation", "PricingDetail"));

    public Task ClickPricingDetailAsync() =>
        _ui.ClickAsync(_locators.PricingDetail, new ControlIntent("Navigation", "PricingDetail"));

    public Task ClickPricingDetailOKAsync() =>
        _ui.ClickAsync(_locators.OKControl, new ControlIntent("Navigation", "PricingDetailOK"));

    public Task WaitForPricingAsync(string expected) =>
        _ui.WaitAsync(_locators.PageTitle, expected, new ControlIntent("Navigation", "Pricing"));

    public Task WaitForPricingHeadingAsync(string expected) =>
        _ui.WaitAsync(_locators.PricingHeading, expected, new ControlIntent("Navigation", "PricingHeading"));

    public Task ClickPrimaryLiabilityIfAnyAsync() =>
        _ui.ClickAsync(_locators.PrimaryLiabilityIfAny, new ControlIntent("Navigation", "PrimaryLiabilityIfAny"));

    public Task WaitForPrimaryLocationStateAsync(string expected) =>
        _ui.WaitAsync(_locators.PrimaryLocationState, expected, new ControlIntent("Navigation", "PrimaryLocationState"));

    public Task VerifyPrimaryLocationStateAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.PrimaryLocationState, expected, property, new ControlIntent("Navigation", "PrimaryLocationState"));

    public Task WaitForPrimaryRatingStateAsync(string expected) =>
        _ui.WaitAsync(_locators.PrimaryRatingState, expected, new ControlIntent("Navigation", "PrimaryRatingState"));

    public Task EnterPrimaryRatingStateAsync(string value) =>
        _ui.FillAsync(_locators.PrimaryRatingState, value, new ControlIntent("Navigation", "PrimaryRatingState"));

    public Task PressPrimaryRatingStateAsync(string key) =>
        _ui.PressAsync(_locators.PrimaryRatingState, key, new ControlIntent("Navigation", "PrimaryRatingState"));

    public Task ClickPrimaryRatingStateAsync() =>
        _ui.ClickAsync(_locators.PrimaryRatingState, new ControlIntent("Navigation", "PrimaryRatingState"));

    public Task VerifyPriorAmericanNationalPolicyAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.PriorAmericanNationalPolicy, expected, property, new ControlIntent("Navigation", "PriorAmericanNationalPolicy"));

    public Task EnterProdBIDedAsync(string value) =>
        _ui.FillAsync(_locators.ProdBIDed, value, new ControlIntent("Navigation", "ProdBIDed"));

    public Task PressProdBIDedAsync(string key) =>
        _ui.PressAsync(_locators.ProdBIDed, key, new ControlIntent("Navigation", "ProdBIDed"));

    public Task EnterProdPDDedAsync(string value) =>
        _ui.FillAsync(_locators.ProdPDDed, value, new ControlIntent("Navigation", "ProdPDDed"));

    public Task EnterProduceCarriedAsync(string value) =>
        _ui.FillAsync(_locators.ProduceCarried, value, new ControlIntent("Navigation", "ProduceCarried"));

    public Task PressProduceCarriedAsync(string key) =>
        _ui.PressAsync(_locators.ProduceCarried, key, new ControlIntent("Navigation", "ProduceCarried"));

    public Task EnterProductsAggLimitAsync(string value) =>
        _ui.FillAsync(_locators.ProductsAggLimit, value, new ControlIntent("Navigation", "ProductsAggLimit"));

    public Task PressProductsAggLimitAsync(string key) =>
        _ui.PressAsync(_locators.ProductsAggLimit, key, new ControlIntent("Navigation", "ProductsAggLimit"));

    public Task VerifyProductsCompletedOperationsAggregateLimitAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.ProductsCompletedOperationsAggregateLimit, expected, property, new ControlIntent("Navigation", "ProductsCompletedOperationsAggregateLimit"));

    public Task EnterProductsCompletedOperationsAggregateLimitAsync(string value) =>
        _ui.FillAsync(_locators.ProductsCompletedOperationsAggregateLimit, value, new ControlIntent("Navigation", "ProductsCompletedOperationsAggregateLimit"));

    public Task PressProductsCompletedOperationsAggregateLimitAsync(string key) =>
        _ui.PressAsync(_locators.ProductsCompletedOperationsAggregateLimit, key, new ControlIntent("Navigation", "ProductsCompletedOperationsAggregateLimit"));

    public Task ClickProductsCompletedOpsButtonAsync() =>
        _ui.ClickAsync(_locators.PageTitle, new ControlIntent("Navigation", "ProductsCompletedOpsButton"));

    public Task ClickPropertyAsync() =>
        _ui.ClickAsync(_locators.PageTitle, new ControlIntent("Navigation", "Property"));

    public Task ClickPropertyAwayFromYourPremisesScheduleAsync() =>
        _ui.ClickAsync(_locators.PropertyAwayFromYourPremisesSchedule, new ControlIntent("Navigation", "PropertyAwayFromYourPremisesSchedule"));

    public Task EnterPolicyCovgComputerSystemsPropertyInTransitAsync(string value) =>
        _ui.FillAsync(_locators.PolicyCovgComputerSystemsPropertyInTransit, value, new ControlIntent("Navigation", "PolicyCovgComputerSystemsPropertyInTransit"));

    public Task PressPolicyCovgComputerSystemsPropertyInTransitAsync(string key) =>
        _ui.PressAsync(_locators.PolicyCovgComputerSystemsPropertyInTransit, key, new ControlIntent("Navigation", "PolicyCovgComputerSystemsPropertyInTransit"));

    public Task EnterPolicyCovgBaileesCutomersPropertyInTransitAsync(string value) =>
        _ui.FillAsync(_locators.PolicyCovgBaileesCutomersPropertyInTransit, value, new ControlIntent("Navigation", "PolicyCovgBaileesCutomersPropertyInTransit"));

    public Task PressPolicyCovgBaileesCutomersPropertyInTransitAsync(string key) =>
        _ui.PressAsync(_locators.PolicyCovgBaileesCutomersPropertyInTransit, key, new ControlIntent("Navigation", "PolicyCovgBaileesCutomersPropertyInTransit"));

    public Task EnterPropertyOfOthersLimitAsync(string value) =>
        _ui.FillAsync(_locators.PropertyOfOthersLimit, value, new ControlIntent("Navigation", "PropertyOfOthersLimit"));

    public Task PressPropertyOfOthersLimitAsync(string key) =>
        _ui.PressAsync(_locators.PropertyOfOthersLimit, key, new ControlIntent("Navigation", "PropertyOfOthersLimit"));

    public Task EnterPropertyOfOthersRatingGroupAsync(string value) =>
        _ui.FillAsync(_locators.RiskInputRatingGroupID, value, new ControlIntent("Navigation", "PropertyOfOthersRatingGroup"));

    public Task PressPropertyOfOthersRatingGroupAsync(string key) =>
        _ui.PressAsync(_locators.RiskInputRatingGroupID, key, new ControlIntent("Navigation", "PropertyOfOthersRatingGroup"));

    public Task ClickPropertyUWQuestionsAsync() =>
        _ui.ClickAsync(_locators.PageTitle, new ControlIntent("Navigation", "PropertyUWQuestions"));

    public Task EnterProvideAListOfSurroundingExposureOtherOccupanciesWithin100FtIncludingNorthEastSouthAndWestAsync(string value) =>
        _ui.FillAsync(_locators.ProvideAListOfSurroundingExposureOtherOccupanciesWithin100FtIncludingNorthEastSouthAndWest, value, new ControlIntent("Navigation", "ProvideAListOfSurroundingExposureOtherOccupanciesWithin100FtIncludingNorthEastSouthAndWest"));

    public Task PressProvideAListOfSurroundingExposureOtherOccupanciesWithin100FtIncludingNorthEastSouthAndWestAsync(string key) =>
        _ui.PressAsync(_locators.ProvideAListOfSurroundingExposureOtherOccupanciesWithin100FtIncludingNorthEastSouthAndWest, key, new ControlIntent("Navigation", "ProvideAListOfSurroundingExposureOtherOccupanciesWithin100FtIncludingNorthEastSouthAndWest"));

    public Task EnterProvideInformationRegardingAntivirusMethodsAndCopyrightProtectionOfDataAndMediaAsync(string value) =>
        _ui.FillAsync(_locators.ProvideInformationRegardingAntivirusMethodsAndCopyrightProtectionOfDataAndMedia, value, new ControlIntent("Navigation", "ProvideInformationRegardingAntivirusMethodsAndCopyrightProtectionOfDataAndMedia"));

    public Task PressProvideInformationRegardingAntivirusMethodsAndCopyrightProtectionOfDataAndMediaAsync(string key) =>
        _ui.PressAsync(_locators.ProvideInformationRegardingAntivirusMethodsAndCopyrightProtectionOfDataAndMedia, key, new ControlIntent("Navigation", "ProvideInformationRegardingAntivirusMethodsAndCopyrightProtectionOfDataAndMedia"));

    public Task ClickRatingGroupsAsync() =>
        _ui.ClickAsync(_locators.PageTitle, new ControlIntent("Navigation", "RatingGroups"));

    public Task WaitForRentalOwnersLiabilityAsync(string expected) =>
        _ui.WaitAsync(_locators.PageTitle, expected, new ControlIntent("Navigation", "RentalOwnersLiability"));

    public Task PressRentalOwnersLiabilityAsync(string key) =>
        _ui.PressAsync(_locators.PageTitle, key, new ControlIntent("Navigation", "RentalOwnersLiability"));

    public Task ClickRentalOwnersLiabilityAsync() =>
        _ui.ClickAsync(_locators.PageTitle, new ControlIntent("Navigation", "RentalOwnersLiability"));

    public Task EnterRentalReimbursementAsync(string value) =>
        _ui.FillAsync(_locators.RentalReimbursement, value, new ControlIntent("Navigation", "RentalReimbursement"));

    public Task PressRentalReimbursementAsync(string key) =>
        _ui.PressAsync(_locators.RentalReimbursement, key, new ControlIntent("Navigation", "RentalReimbursement"));

    public Task EnterRentedEquipmentExpenseAsync(string value) =>
        _ui.FillAsync(_locators.RentedEquipmentExpense, value, new ControlIntent("Navigation", "RentedEquipmentExpense"));

    public Task PressRentedEquipmentExpenseAsync(string key) =>
        _ui.PressAsync(_locators.RentedEquipmentExpense, key, new ControlIntent("Navigation", "RentedEquipmentExpense"));

    public Task EnterRequestedUmbrellaLimitAsync(string value) =>
        _ui.FillAsync(_locators.RequestedUmbrellaLimit, value, new ControlIntent("Navigation", "RequestedUmbrellaLimit"));

    public Task PressRequestedUmbrellaLimitAsync(string key) =>
        _ui.PressAsync(_locators.RequestedUmbrellaLimit, key, new ControlIntent("Navigation", "RequestedUmbrellaLimit"));

    public Task VerifyResultAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.Result, expected, property, new ControlIntent("Navigation", "Result"));

    public Task ClickReturnToQuoteAsync() =>
        _ui.ClickAsync(_locators.ReturnToQuote, new ControlIntent("Navigation", "ReturnToQuote"));

    public Task ClickRiskAsync() =>
        _ui.ClickAsync(_locators.PageTitle, new ControlIntent("Navigation", "Risk"));

    public Task ClickRiskAccountsReceivableOKAsync() =>
        _ui.ClickAsync(_locators.OK, new ControlIntent("Navigation", "RiskAccountsReceivableOK"));

    public Task ClickRiskBaileesCustomersOKAsync() =>
        _ui.ClickAsync(_locators.OK, new ControlIntent("Navigation", "RiskBaileesCustomersOK"));

    public Task ClickRiskComputerSystemsOKAsync() =>
        _ui.ClickAsync(_locators.OK, new ControlIntent("Navigation", "RiskComputerSystemsOK"));

    public Task WaitForRiskScheduleAsync(string expected) =>
        _ui.WaitAsync(_locators.RiskSchedule, expected, new ControlIntent("Navigation", "RiskSchedule"));

    public Task ClickRiskScheduleAsync() =>
        _ui.ClickAsync(_locators.RiskSchedule, new ControlIntent("Navigation", "RiskSchedule"));

    public Task EnterRiskTypeAsync(string value) =>
        _ui.FillAsync(_locators.RiskType, value, new ControlIntent("Navigation", "RiskType"));

    public Task PressRiskTypeAsync(string key) =>
        _ui.PressAsync(_locators.RiskType, key, new ControlIntent("Navigation", "RiskType"));

    public Task EnterRoofTypeAsync(string value) =>
        _ui.FillAsync(_locators.RoofType, value, new ControlIntent("Navigation", "RoofType"));

    public Task PressRoofTypeAsync(string key) =>
        _ui.PressAsync(_locators.RoofType, key, new ControlIntent("Navigation", "RoofType"));

    public Task ClickSFP10LiabilityFarmAsync() =>
        _ui.ClickAsync(_locators.PageTitle, new ControlIntent("Navigation", "SFP10LiabilityFarm"));

    public Task ClickSaveForLaterAsync() =>
        _ui.ClickAsync(_locators.SaveForLater, new ControlIntent("Navigation", "SaveForLater"));

    public Task EnterScheduledCoverageAsync(string value) =>
        _ui.FillAsync(_locators.ScheduledCoverage, value, new ControlIntent("Navigation", "ScheduledCoverage"));

    public Task PressScheduledCoverageAsync(string key) =>
        _ui.PressAsync(_locators.ScheduledCoverage, key, new ControlIntent("Navigation", "ScheduledCoverage"));

    public Task EnterRiskComputerSystemsSearchResultAsync(string value) =>
        _ui.FillAsync(_locators.RiskComputerSystemsSearchResult, value, new ControlIntent("Navigation", "RiskComputerSystemsSearchResult"));

    public Task PressRiskComputerSystemsSearchResultAsync(string key) =>
        _ui.PressAsync(_locators.RiskComputerSystemsSearchResult, key, new ControlIntent("Navigation", "RiskComputerSystemsSearchResult"));

    public Task EnterRiskBaileesCustomersSearchResultAsync(string value) =>
        _ui.FillAsync(_locators.RiskBaileesCustomersSearchResult, value, new ControlIntent("Navigation", "RiskBaileesCustomersSearchResult"));

    public Task PressRiskBaileesCustomersSearchResultAsync(string key) =>
        _ui.PressAsync(_locators.RiskBaileesCustomersSearchResult, key, new ControlIntent("Navigation", "RiskBaileesCustomersSearchResult"));

    public Task EnterRiskAccountsReceivableSearchResultAsync(string value) =>
        _ui.FillAsync(_locators.RiskAccountsReceivableSearchResult, value, new ControlIntent("Navigation", "RiskAccountsReceivableSearchResult"));

    public Task PressRiskAccountsReceivableSearchResultAsync(string key) =>
        _ui.PressAsync(_locators.RiskAccountsReceivableSearchResult, key, new ControlIntent("Navigation", "RiskAccountsReceivableSearchResult"));

    public Task EnterSearchResultsAsync(string value) =>
        _ui.FillAsync(_locators.SearchResults, value, new ControlIntent("Navigation", "SearchResults"));

    public Task PressSearchResultsAsync(string key) =>
        _ui.PressAsync(_locators.SearchResults, key, new ControlIntent("Navigation", "SearchResults"));

    public Task WaitForSearchValueAsync(string expected) =>
        _ui.WaitAsync(_locators.SearchValue, expected, new ControlIntent("Navigation", "SearchValue"));

    public Task EnterSearchValueAsync(string value) =>
        _ui.FillAsync(_locators.SearchValue, value, new ControlIntent("Navigation", "SearchValue"));

    public Task PressSearchValueAsync(string key) =>
        _ui.PressAsync(_locators.SearchValue, key, new ControlIntent("Navigation", "SearchValue"));

    public Task EnterPropertyAddClassSearchValueAsync(string value) =>
        _ui.FillAsync(_locators.PropertyAddClassSearchValue, value, new ControlIntent("Navigation", "PropertyAddClassSearchValue"));

    public Task PressPropertyAddClassSearchValueAsync(string key) =>
        _ui.PressAsync(_locators.PropertyAddClassSearchValue, key, new ControlIntent("Navigation", "PropertyAddClassSearchValue"));

    public Task EnterRiskAccountsReceivableSearchValueAsync(string value) =>
        _ui.FillAsync(_locators.RiskAccountsReceivableSearchValue, value, new ControlIntent("Navigation", "RiskAccountsReceivableSearchValue"));

    public Task PressRiskAccountsReceivableSearchValueAsync(string key) =>
        _ui.PressAsync(_locators.RiskAccountsReceivableSearchValue, key, new ControlIntent("Navigation", "RiskAccountsReceivableSearchValue"));

    public Task EnterRiskComputerSystemsSearchValueAsync(string value) =>
        _ui.FillAsync(_locators.RiskComputerSystemsSearchValue, value, new ControlIntent("Navigation", "RiskComputerSystemsSearchValue"));

    public Task PressRiskComputerSystemsSearchValueAsync(string key) =>
        _ui.PressAsync(_locators.RiskComputerSystemsSearchValue, key, new ControlIntent("Navigation", "RiskComputerSystemsSearchValue"));

    public Task EnterRiskBaileesCustomersSearchValueAsync(string value) =>
        _ui.FillAsync(_locators.RiskBaileesCustomersSearchValue, value, new ControlIntent("Navigation", "RiskBaileesCustomersSearchValue"));

    public Task PressRiskBaileesCustomersSearchValueAsync(string key) =>
        _ui.PressAsync(_locators.RiskBaileesCustomersSearchValue, key, new ControlIntent("Navigation", "RiskBaileesCustomersSearchValue"));

    public Task EnterSeasonalProduceTrailersAsync(string value) =>
        _ui.FillAsync(_locators.SeasonalProduceTrailers, value, new ControlIntent("Navigation", "SeasonalProduceTrailers"));

    public Task PressSeasonalProduceTrailersAsync(string key) =>
        _ui.PressAsync(_locators.SeasonalProduceTrailers, key, new ControlIntent("Navigation", "SeasonalProduceTrailers"));

    public Task ClickSelectAsync() =>
        _ui.ClickAsync(_locators.Select, new ControlIntent("Navigation", "Select"));

    public Task VerifySelectAppropriateCodeAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.SelectAppropriateCode, expected, property, new ControlIntent("Navigation", "SelectAppropriateCode"));

    public Task EnterSelectAppropriateCodeAsync(string value) =>
        _ui.FillAsync(_locators.SelectAppropriateCode, value, new ControlIntent("Navigation", "SelectAppropriateCode"));

    public Task PressSelectAppropriateCodeAsync(string key) =>
        _ui.PressAsync(_locators.SelectAppropriateCode, key, new ControlIntent("Navigation", "SelectAppropriateCode"));

    public Task VerifySelectClassCodeAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.SelectClassCode, expected, property, new ControlIntent("Navigation", "SelectClassCode"));

    public Task EnterSelectClassCodeAsync(string value) =>
        _ui.FillAsync(_locators.SelectClassCode, value, new ControlIntent("Navigation", "SelectClassCode"));

    public Task PressSelectClassCodeAsync(string key) =>
        _ui.PressAsync(_locators.SelectClassCode, key, new ControlIntent("Navigation", "SelectClassCode"));

    public Task WaitForSelectEndorsementAsync(string expected) =>
        _ui.WaitAsync(_locators.SelectEndorsement, expected, new ControlIntent("Navigation", "SelectEndorsement"));

    public Task VerifySelectEndorsementAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.SelectEndorsement, expected, property, new ControlIntent("Navigation", "SelectEndorsement"));

    public Task EnterSelectEndorsementAsync(string value) =>
        _ui.FillAsync(_locators.SelectEndorsement, value, new ControlIntent("Navigation", "SelectEndorsement"));

    public Task PressSelectEndorsementAsync(string key) =>
        _ui.PressAsync(_locators.SelectEndorsement, key, new ControlIntent("Navigation", "SelectEndorsement"));

    public Task ClickSelectNAICSCodeAsync() =>
        _ui.ClickAsync(_locators.SelectNAICSCode, new ControlIntent("Navigation", "SelectNAICSCode"));

    public Task ClickSelectPPCAsync() =>
        _ui.ClickAsync(_locators.SelectPPC, new ControlIntent("Navigation", "SelectPPC"));

    public Task EnterSexAsync(string value) =>
        _ui.FillAsync(_locators.Sex, value, new ControlIntent("Navigation", "Sex"));

    public Task PressSexAsync(string key) =>
        _ui.PressAsync(_locators.Sex, key, new ControlIntent("Navigation", "Sex"));

    public Task WaitForShowAllLocationsAsync(string expected) =>
        _ui.WaitAsync(_locators.ShowAllLocations, expected, new ControlIntent("Navigation", "ShowAllLocations"));

    public Task EnterSignLocationAsync(string value) =>
        _ui.FillAsync(_locators.SignLocation, value, new ControlIntent("Navigation", "SignLocation"));

    public Task PressSignLocationAsync(string key) =>
        _ui.PressAsync(_locators.SignLocation, key, new ControlIntent("Navigation", "SignLocation"));

    public Task ClickSignsUWQuestionsAsync() =>
        _ui.ClickAsync(_locators.SignsUWQuestions, new ControlIntent("Navigation", "SignsUWQuestions"));

    public Task EnterSmallDeductibleAsync(string value) =>
        _ui.FillAsync(_locators.SmallDeductible, value, new ControlIntent("Navigation", "SmallDeductible"));

    public Task PressSmallDeductibleAsync(string key) =>
        _ui.PressAsync(_locators.SmallDeductible, key, new ControlIntent("Navigation", "SmallDeductible"));

    public Task EnterSoleProprietorsAsync(string value) =>
        _ui.FillAsync(_locators.SoleProprietors, value, new ControlIntent("Navigation", "SoleProprietors"));

    public Task PressSoleProprietorsAsync(string key) =>
        _ui.PressAsync(_locators.SoleProprietors, key, new ControlIntent("Navigation", "SoleProprietors"));

    public Task ClickSpecificUnderwritingQuestionsAsync() =>
        _ui.ClickAsync(_locators.SpecificUnderwritingQuestions, new ControlIntent("Navigation", "SpecificUnderwritingQuestions"));

    public Task SetSplitBIDedAsync(string value) =>
        _ui.SmartSetAsync(_locators.SplitBIDed, value, new ControlIntent("Navigation", "SplitBIDed"));

    public Task PressSplitBIDedAsync(string key) =>
        _ui.PressAsync(_locators.SplitBIDed, key, new ControlIntent("Navigation", "SplitBIDed"));

    public Task EnterSplitPDDedAsync(string value) =>
        _ui.FillAsync(_locators.SplitPDDed, value, new ControlIntent("Navigation", "SplitPDDed"));

    public Task EnterSquareFeetAsync(string value) =>
        _ui.FillAsync(_locators.SquareFeet, value, new ControlIntent("Navigation", "SquareFeet"));

    public Task PressSquareFeetAsync(string key) =>
        _ui.PressAsync(_locators.SquareFeet, key, new ControlIntent("Navigation", "SquareFeet"));

    public Task EnterPolicyHolderStateAsync(string value) =>
        _ui.FillAsync(_locators.PolicyHolderState, value, new ControlIntent("Navigation", "PolicyHolderState"));

    public Task PressPolicyHolderStateAsync(string key) =>
        _ui.PressAsync(_locators.PolicyHolderState, key, new ControlIntent("Navigation", "PolicyHolderState"));

    public Task WaitForStateAsync(string expected) =>
        _ui.WaitAsync(_locators.State, expected, new ControlIntent("Navigation", "State"));

    public Task EnterEndorsementsDesignatedWorkplacesExclusionStateAsync(string value) =>
        _ui.FillAsync(_locators.EndorsementsDesignatedWorkplacesExclusionState, value, new ControlIntent("Navigation", "EndorsementsDesignatedWorkplacesExclusionState"));

    public Task PressEndorsementsDesignatedWorkplacesExclusionStateAsync(string key) =>
        _ui.PressAsync(_locators.EndorsementsDesignatedWorkplacesExclusionState, key, new ControlIntent("Navigation", "EndorsementsDesignatedWorkplacesExclusionState"));

    public Task WaitForStateDetailsAsync(string expected) =>
        _ui.WaitAsync(_locators.PageTitle, expected, new ControlIntent("Navigation", "StateDetails"));

    public Task ClickStateDetailsAsync() =>
        _ui.ClickAsync(_locators.PageTitle, new ControlIntent("Navigation", "StateDetails"));

    public Task WaitForSelectAsync(string expected) =>
        _ui.WaitAsync(_locators.Select, expected, new ControlIntent("Navigation", "Select"));

    public Task EnterStateLicensedAsync(string value) =>
        _ui.FillAsync(_locators.StateLicensed, value, new ControlIntent("Navigation", "StateLicensed"));

    public Task PressStateLicensedAsync(string key) =>
        _ui.PressAsync(_locators.StateLicensed, key, new ControlIntent("Navigation", "StateLicensed"));

    public Task EnterStateOrPoliticalSubdivisionAsync(string value) =>
        _ui.FillAsync(_locators.StateOrPoliticalSubdivision, value, new ControlIntent("Navigation", "StateOrPoliticalSubdivision"));

    public Task PressStateOrPoliticalSubdivisionAsync(string key) =>
        _ui.PressAsync(_locators.StateOrPoliticalSubdivision, key, new ControlIntent("Navigation", "StateOrPoliticalSubdivision"));

    public Task EnterStatedAmountAsync(string value) =>
        _ui.FillAsync(_locators.RiskVehicleInputValueEstimate, value, new ControlIntent("Navigation", "StatedAmount"));

    public Task PressStatedAmountAsync(string key) =>
        _ui.PressAsync(_locators.RiskVehicleInputValueEstimate, key, new ControlIntent("Navigation", "StatedAmount"));

    public Task WaitForStoplightMessageTotalSubjectPremiumAsync(string expected) =>
        _ui.WaitAsync(_locators.StoplightMessageTotalSubjectPremium, expected, new ControlIntent("Navigation", "StoplightMessageTotalSubjectPremium"));

    public Task EnterStorageLimitAsync(string value) =>
        _ui.FillAsync(_locators.StorageLimit, value, new ControlIntent("Navigation", "StorageLimit"));

    public Task PressStorageLimitAsync(string key) =>
        _ui.PressAsync(_locators.StorageLimit, key, new ControlIntent("Navigation", "StorageLimit"));

    public Task EnterStoriesAsync(string value) =>
        _ui.FillAsync(_locators.Stories, value, new ControlIntent("Navigation", "Stories"));

    public Task PressStoriesAsync(string key) =>
        _ui.PressAsync(_locators.Stories, key, new ControlIntent("Navigation", "Stories"));

    public Task WaitForSubmissionAsync(string expected) =>
        _ui.WaitAsync(_locators.PageTop, expected, new ControlIntent("Navigation", "Submission"));

    public Task PressSubmissionAsync(string key) =>
        _ui.PressAsync(_locators.PageTop, key, new ControlIntent("Navigation", "Submission"));

    public Task ClickSubmissionAsync() =>
        _ui.ClickAsync(_locators.PageTop, new ControlIntent("Navigation", "Submission"));

    public Task WaitForSubmissionHeadingAsync(string expected) =>
        _ui.WaitAsync(_locators.PageTop, expected, new ControlIntent("Navigation", "SubmissionHeading"));

    public Task VerifySubmissionHeadingAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.PageTop, expected, property, new ControlIntent("Navigation", "SubmissionHeading"));

    public Task EnterTapesCoverageAsync(string value) =>
        _ui.FillAsync(_locators.TapesCoverage, value, new ControlIntent("Navigation", "TapesCoverage"));

    public Task PressTapesCoverageAsync(string key) =>
        _ui.PressAsync(_locators.TapesCoverage, key, new ControlIntent("Navigation", "TapesCoverage"));

    public Task EnterTextBoxAsync(string value) =>
        _ui.FillAsync(_locators.TextBox, value, new ControlIntent("Navigation", "TextBox"));

    public Task ClickThirdPartyDesigneeAsync() =>
        _ui.ClickAsync(_locators.ThirdPartyDesignee, new ControlIntent("Navigation", "ThirdPartyDesignee"));

    public Task EnterTitleAsync(string value) =>
        _ui.FillAsync(_locators.Title, value, new ControlIntent("Navigation", "Title"));

    public Task EnterToolsAndClothingBelongingToYourEmployeesAsync(string value) =>
        _ui.FillAsync(_locators.ToolsAndClothingBelongingToYourEmployees, value, new ControlIntent("Navigation", "ToolsAndClothingBelongingToYourEmployees"));

    public Task PressToolsAndClothingBelongingToYourEmployeesAsync(string key) =>
        _ui.PressAsync(_locators.ToolsAndClothingBelongingToYourEmployees, key, new ControlIntent("Navigation", "ToolsAndClothingBelongingToYourEmployees"));

    public Task EnterTotalCostOfWorkAsync(string value) =>
        _ui.FillAsync(_locators.TotalCostOfWork, value, new ControlIntent("Navigation", "TotalCostOfWork"));

    public Task PressTotalCostOfWorkAsync(string key) =>
        _ui.PressAsync(_locators.TotalCostOfWork, key, new ControlIntent("Navigation", "TotalCostOfWork"));

    public Task EnterTotalPayrollEstimatedAsync(string value) =>
        _ui.FillAsync(_locators.TotalPayrollEstimated, value, new ControlIntent("Navigation", "TotalPayrollEstimated"));

    public Task PressTotalPayrollEstimatedAsync(string key) =>
        _ui.PressAsync(_locators.TotalPayrollEstimated, key, new ControlIntent("Navigation", "TotalPayrollEstimated"));

    public Task EnterTotalPremiumAsync(string value) =>
        _ui.FillAsync(_locators.TotalPremium, value, new ControlIntent("Navigation", "TotalPremium"));

    public Task PressTotalPremiumAsync(string key) =>
        _ui.PressAsync(_locators.TotalPremium, key, new ControlIntent("Navigation", "TotalPremium"));

    public Task EnterGeneralLiabilityTotalSubjectPremiumAsync(string value) =>
        _ui.FillAsync(_locators.BusinessownersTotalSubjectPremium, value, new ControlIntent("Navigation", "GeneralLiabilityTotalSubjectPremium"));

    public Task PressGeneralLiabilityTotalSubjectPremiumAsync(string key) =>
        _ui.PressAsync(_locators.BusinessownersTotalSubjectPremium, key, new ControlIntent("Navigation", "GeneralLiabilityTotalSubjectPremium"));

    public Task EnterBusinessownersTotalSubjectPremiumAsync(string value) =>
        _ui.FillAsync(_locators.BusinessownersTotalSubjectPremium, value, new ControlIntent("Navigation", "BusinessownersTotalSubjectPremium"));

    public Task PressBusinessownersTotalSubjectPremiumAsync(string key) =>
        _ui.PressAsync(_locators.BusinessownersTotalSubjectPremium, key, new ControlIntent("Navigation", "BusinessownersTotalSubjectPremium"));

    public Task EnterTowingAsync(string value) =>
        _ui.FillAsync(_locators.Towing, value, new ControlIntent("Navigation", "Towing"));

    public Task EnterTrailerInterchangeCollisionDeductibleAsync(string value) =>
        _ui.FillAsync(_locators.TrailerInterchangeCollisionDeductible, value, new ControlIntent("Navigation", "TrailerInterchangeCollisionDeductible"));

    public Task PressTrailerInterchangeCollisionDeductibleAsync(string key) =>
        _ui.PressAsync(_locators.TrailerInterchangeCollisionDeductible, key, new ControlIntent("Navigation", "TrailerInterchangeCollisionDeductible"));

    public Task EnterTrailerInterchangeCompDeductibleAsync(string value) =>
        _ui.FillAsync(_locators.TrailerInterchangeCompDeductible, value, new ControlIntent("Navigation", "TrailerInterchangeCompDeductible"));

    public Task PressTrailerInterchangeCompDeductibleAsync(string key) =>
        _ui.PressAsync(_locators.TrailerInterchangeCompDeductible, key, new ControlIntent("Navigation", "TrailerInterchangeCompDeductible"));

    public Task EnterTrailerInterchangeEnterDaysInsuredAsync(string value) =>
        _ui.FillAsync(_locators.TrailerInterchangeEnterDaysInsured, value, new ControlIntent("Navigation", "TrailerInterchangeEnterDaysInsured"));

    public Task PressTrailerInterchangeEnterDaysInsuredAsync(string key) =>
        _ui.PressAsync(_locators.TrailerInterchangeEnterDaysInsured, key, new ControlIntent("Navigation", "TrailerInterchangeEnterDaysInsured"));

    public Task EnterTrailerInterchangeEnterOfTrailersAsync(string value) =>
        _ui.FillAsync(_locators.TrailerInterchangeEnterOfTrailers, value, new ControlIntent("Navigation", "TrailerInterchangeEnterOfTrailers"));

    public Task PressTrailerInterchangeEnterOfTrailersAsync(string key) =>
        _ui.PressAsync(_locators.TrailerInterchangeEnterOfTrailers, key, new ControlIntent("Navigation", "TrailerInterchangeEnterOfTrailers"));

    public Task EnterFG0013AutomaticAdditionalInsuredSpecificRelationshipTypeAsync(string value) =>
        _ui.FillAsync(_locators.FG0013AutomaticAdditionalInsuredSpecificRelationshipType, value, new ControlIntent("Navigation", "FG0013AutomaticAdditionalInsuredSpecificRelationshipType"));

    public Task PressFG0013AutomaticAdditionalInsuredSpecificRelationshipTypeAsync(string key) =>
        _ui.PressAsync(_locators.FG0013AutomaticAdditionalInsuredSpecificRelationshipType, key, new ControlIntent("Navigation", "FG0013AutomaticAdditionalInsuredSpecificRelationshipType"));

    public Task EnterEndorsementMainTypeAsync(string value) =>
        _ui.FillAsync(_locators.EndorsementMainType, value, new ControlIntent("Navigation", "EndorsementMainType"));

    public Task PressEndorsementMainTypeAsync(string key) =>
        _ui.PressAsync(_locators.EndorsementMainType, key, new ControlIntent("Navigation", "EndorsementMainType"));

    public Task EnterGLOCPRiskTypeAsync(string value) =>
        _ui.FillAsync(_locators.GLOCPRiskType, value, new ControlIntent("Navigation", "GLOCPRiskType"));

    public Task PressGLOCPRiskTypeAsync(string key) =>
        _ui.PressAsync(_locators.GLOCPRiskType, key, new ControlIntent("Navigation", "GLOCPRiskType"));

    public Task EnterCG2007AddLInsuredEngineersArchitectsTypeAsync(string value) =>
        _ui.FillAsync(_locators.CG2007AddLInsuredEngineersArchitectsType, value, new ControlIntent("Navigation", "CG2007AddLInsuredEngineersArchitectsType"));

    public Task PressCG2007AddLInsuredEngineersArchitectsTypeAsync(string key) =>
        _ui.PressAsync(_locators.CG2007AddLInsuredEngineersArchitectsType, key, new ControlIntent("Navigation", "CG2007AddLInsuredEngineersArchitectsType"));

    public Task EnterRiskSignsTypeAsync(string value) =>
        _ui.FillAsync(_locators.RiskSignsType, value, new ControlIntent("Navigation", "RiskSignsType"));

    public Task PressRiskSignsTypeAsync(string key) =>
        _ui.PressAsync(_locators.RiskSignsType, key, new ControlIntent("Navigation", "RiskSignsType"));

    public Task WaitForCG2007AddLInsuredEngineersArchitectsTypeAsync(string expected) =>
        _ui.WaitAsync(_locators.CG2007AddLInsuredEngineersArchitectsType, expected, new ControlIntent("Navigation", "CG2007AddLInsuredEngineersArchitectsType"));

    public Task ClickCG2007AddLInsuredEngineersArchitectsTypeAsync() =>
        _ui.ClickAsync(_locators.CG2007AddLInsuredEngineersArchitectsType, new ControlIntent("Navigation", "CG2007AddLInsuredEngineersArchitectsType"));

    public Task VerifyCG2007AddLInsuredEngineersArchitectsTypeAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.CG2007AddLInsuredEngineersArchitectsType, expected, property, new ControlIntent("Navigation", "CG2007AddLInsuredEngineersArchitectsType"));

    public Task EnterTypeOfContractorAsync(string value) =>
        _ui.FillAsync(_locators.TypeOfContractor, value, new ControlIntent("Navigation", "TypeOfContractor"));

    public Task PressTypeOfContractorAsync(string key) =>
        _ui.PressAsync(_locators.TypeOfContractor, key, new ControlIntent("Navigation", "TypeOfContractor"));

    public Task EnterTypeOfEquipmentAsync(string value) =>
        _ui.FillAsync(_locators.TypeOfEquipment, value, new ControlIntent("Navigation", "TypeOfEquipment"));

    public Task PressTypeOfEquipmentAsync(string key) =>
        _ui.PressAsync(_locators.TypeOfEquipment, key, new ControlIntent("Navigation", "TypeOfEquipment"));

    public Task WaitForTypeOfInterestAsync(string expected) =>
        _ui.WaitAsync(_locators.TypeOfInterest, expected, new ControlIntent("Navigation", "TypeOfInterest"));

    public Task EnterTypeOfInterestAsync(string value) =>
        _ui.FillAsync(_locators.TypeOfInterest, value, new ControlIntent("Navigation", "TypeOfInterest"));

    public Task PressTypeOfInterestAsync(string key) =>
        _ui.PressAsync(_locators.TypeOfInterest, key, new ControlIntent("Navigation", "TypeOfInterest"));

    public Task EnterTypeOfLicenseAsync(string value) =>
        _ui.FillAsync(_locators.TypeOfLicense, value, new ControlIntent("Navigation", "TypeOfLicense"));

    public Task PressTypeOfLicenseAsync(string key) =>
        _ui.PressAsync(_locators.TypeOfLicense, key, new ControlIntent("Navigation", "TypeOfLicense"));

    public Task EnterUMBILimitAsync(string value) =>
        _ui.FillAsync(_locators.UMBILimit, value, new ControlIntent("Navigation", "UMBILimit"));

    public Task PressUMBILimitAsync(string key) =>
        _ui.PressAsync(_locators.UMBILimit, key, new ControlIntent("Navigation", "UMBILimit"));

    public Task EnterUMTypeDefaultSelectionsAsync(string value) =>
        _ui.FillAsync(_locators.UMTypeDefaultSelections, value, new ControlIntent("Navigation", "UMTypeDefaultSelections"));

    public Task PressUMTypeDefaultSelectionsAsync(string key) =>
        _ui.PressAsync(_locators.UMTypeDefaultSelections, key, new ControlIntent("Navigation", "UMTypeDefaultSelections"));

    public Task VerifyOKAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.OK, expected, property, new ControlIntent("Navigation", "OK"));

    public Task ClickUWQuestionsAsync() =>
        _ui.ClickAsync(_locators.PageTitle, new ControlIntent("Navigation", "UWQuestions"));

    public Task PressUWQuestionsUmbrellaAsync(string key) =>
        _ui.PressAsync(_locators.PageTitle, key, new ControlIntent("Navigation", "UWQuestionsUmbrella"));

    public Task ClickUWQuestionsUmbrellaAsync() =>
        _ui.ClickAsync(_locators.PageTitle, new ControlIntent("Navigation", "UWQuestionsUmbrella"));

    public Task ClickUWQuestionsWorkersCompAsync() =>
        _ui.ClickAsync(_locators.UWQuestionsWorkersComp, new ControlIntent("Navigation", "UWQuestionsWorkersComp"));

    public Task VerifyUmbrellaLimitAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.UmbrellaLimit, expected, property, new ControlIntent("Navigation", "UmbrellaLimit"));

    public Task EnterUmbrellaLimitAsync(string value) =>
        _ui.FillAsync(_locators.UmbrellaLimit, value, new ControlIntent("Navigation", "UmbrellaLimit"));

    public Task PressUmbrellaLimitAsync(string key) =>
        _ui.PressAsync(_locators.UmbrellaLimit, key, new ControlIntent("Navigation", "UmbrellaLimit"));

    public Task ClickUnderwritingInfoAsync() =>
        _ui.ClickAsync(_locators.UnderwritingInfo, new ControlIntent("Navigation", "UnderwritingInfo"));

    public Task EnterUninterruptiblePowerSourceAsync(string value) =>
        _ui.FillAsync(_locators.UninterruptiblePowerSource, value, new ControlIntent("Navigation", "UninterruptiblePowerSource"));

    public Task PressUninterruptiblePowerSourceAsync(string key) =>
        _ui.PressAsync(_locators.UninterruptiblePowerSource, key, new ControlIntent("Navigation", "UninterruptiblePowerSource"));

    public Task EnterUnnamedPremisesAsync(string value) =>
        _ui.FillAsync(_locators.UnnamedPremises, value, new ControlIntent("Navigation", "UnnamedPremises"));

    public Task PressUnnamedPremisesAsync(string key) =>
        _ui.PressAsync(_locators.UnnamedPremises, key, new ControlIntent("Navigation", "UnnamedPremises"));

    public Task EnterUnnamedTerminalsLimitAsync(string value) =>
        _ui.FillAsync(_locators.UnnamedTerminalsLimit, value, new ControlIntent("Navigation", "UnnamedTerminalsLimit"));

    public Task PressUnnamedTerminalsLimitAsync(string key) =>
        _ui.PressAsync(_locators.UnnamedTerminalsLimit, key, new ControlIntent("Navigation", "UnnamedTerminalsLimit"));

    public Task ClickSpecificUnderwritingQuestionsContractorsEquipmentUpdateAnswersAsync() =>
        _ui.ClickAsync(_locators.UpdateAnswers, new ControlIntent("Navigation", "SpecificUnderwritingQuestionsContractorsEquipmentUpdateAnswers"));

    public Task PressUWQuestionsUmbrellaUpdateAnswersAsync(string key) =>
        _ui.PressAsync(_locators.UpdateAnswers, key, new ControlIntent("Navigation", "UWQuestionsUmbrellaUpdateAnswers"));

    public Task ClickUWQuestionsUmbrellaUpdateAnswersAsync() =>
        _ui.ClickAsync(_locators.UpdateAnswers, new ControlIntent("Navigation", "UWQuestionsUmbrellaUpdateAnswers"));

    public Task WaitForUWQuestionsUmbrellaUpdateAnswersAsync(string expected) =>
        _ui.WaitAsync(_locators.UpdateAnswers, expected, new ControlIntent("Navigation", "UWQuestionsUmbrellaUpdateAnswers"));

    public Task PressPropertyUWQuestionsUpdateAnswersAsync(string key) =>
        _ui.PressAsync(_locators.UpdateAnswers, key, new ControlIntent("Navigation", "PropertyUWQuestionsUpdateAnswers"));

    public Task ClickPropertyUWQuestionsUpdateAnswersAsync() =>
        _ui.ClickAsync(_locators.UpdateAnswers, new ControlIntent("Navigation", "PropertyUWQuestionsUpdateAnswers"));

    public Task PressUpdateAnswersButtonAsync(string key) =>
        _ui.PressAsync(_locators.UpdateAnswers, key, new ControlIntent("Navigation", "UpdateAnswersButton"));

    public Task ClickUpdateAnswersButtonAsync() =>
        _ui.ClickAsync(_locators.UpdateAnswers, new ControlIntent("Navigation", "UpdateAnswersButton"));

    public Task EnterUsedAsShowroomAsync(string value) =>
        _ui.FillAsync(_locators.UsedAsShowroom, value, new ControlIntent("Navigation", "UsedAsShowroom"));

    public Task PressUsedAsShowroomAsync(string key) =>
        _ui.PressAsync(_locators.UsedAsShowroom, key, new ControlIntent("Navigation", "UsedAsShowroom"));

    public Task WaitForVINAsync(string expected) =>
        _ui.WaitAsync(_locators.VIN, expected, new ControlIntent("Navigation", "VIN"));

    public Task EnterVINAsync(string value) =>
        _ui.FillAsync(_locators.VIN, value, new ControlIntent("Navigation", "VIN"));

    public Task PressVINAsync(string key) =>
        _ui.PressAsync(_locators.VIN, key, new ControlIntent("Navigation", "VIN"));

    public Task EnterVacancyPermitAsync(string value) =>
        _ui.FillAsync(_locators.VacancyPermit, value, new ControlIntent("Navigation", "VacancyPermit"));

    public Task PressVacancyPermitAsync(string key) =>
        _ui.PressAsync(_locators.VacancyPermit, key, new ControlIntent("Navigation", "VacancyPermit"));

    public Task EnterVacantBuildingAsync(string value) =>
        _ui.FillAsync(_locators.VacantBuilding, value, new ControlIntent("Navigation", "VacantBuilding"));

    public Task PressVacantBuildingAsync(string key) =>
        _ui.PressAsync(_locators.VacantBuilding, key, new ControlIntent("Navigation", "VacantBuilding"));

    public Task EnterValuationAsync(string value) =>
        _ui.FillAsync(_locators.Valuation, value, new ControlIntent("Navigation", "Valuation"));

    public Task PressValuationAsync(string key) =>
        _ui.PressAsync(_locators.Valuation, key, new ControlIntent("Navigation", "Valuation"));

    public Task EnterValuationTypeAsync(string value) =>
        _ui.FillAsync(_locators.ValuationType, value, new ControlIntent("Navigation", "ValuationType"));

    public Task PressValuationTypeAsync(string key) =>
        _ui.PressAsync(_locators.ValuationType, key, new ControlIntent("Navigation", "ValuationType"));

    public Task EnterValueBasisAsync(string value) =>
        _ui.FillAsync(_locators.ValueBasis, value, new ControlIntent("Navigation", "ValueBasis"));

    public Task PressValueBasisAsync(string key) =>
        _ui.PressAsync(_locators.ValueBasis, key, new ControlIntent("Navigation", "ValueBasis"));

    public Task EnterVehicleInformationAsync(string value) =>
        _ui.FillAsync(_locators.VehicleInformation, value, new ControlIntent("Navigation", "VehicleInformation"));

    public Task PressVehicleInformationAsync(string key) =>
        _ui.PressAsync(_locators.VehicleInformation, key, new ControlIntent("Navigation", "VehicleInformation"));

    public Task VerifyVehicleSchedule1VehAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.VehicleSchedule1Veh, expected, property, new ControlIntent("Navigation", "VehicleSchedule1Veh"));

    public Task WaitForVehicleTypeAsync(string expected) =>
        _ui.WaitAsync(_locators.VehicleType, expected, new ControlIntent("Navigation", "VehicleType"));

    public Task VerifyVehicleTypeAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.VehicleType, expected, property, new ControlIntent("Navigation", "VehicleType"));

    public Task EnterVehicleTypeAsync(string value) =>
        _ui.FillAsync(_locators.VehicleType, value, new ControlIntent("Navigation", "VehicleType"));

    public Task PressVehicleTypeAsync(string key) =>
        _ui.PressAsync(_locators.VehicleType, key, new ControlIntent("Navigation", "VehicleType"));

    public Task EnterVirusHarmfulCodeOrSimilarInstructionAsync(string value) =>
        _ui.FillAsync(_locators.VirusHarmfulCodeOrSimilarInstruction, value, new ControlIntent("Navigation", "VirusHarmfulCodeOrSimilarInstruction"));

    public Task PressVirusHarmfulCodeOrSimilarInstructionAsync(string key) =>
        _ui.PressAsync(_locators.VirusHarmfulCodeOrSimilarInstruction, key, new ControlIntent("Navigation", "VirusHarmfulCodeOrSimilarInstruction"));

    public Task ClickVolunteerHiredAutosCheckBoxAsync() =>
        _ui.ClickAsync(_locators.VolunteerHiredAutosCheckBox, new ControlIntent("Navigation", "VolunteerHiredAutosCheckBox"));

    public Task ClickWCScheduleAsync() =>
        _ui.ClickAsync(_locators.WCSchedule, new ControlIntent("Navigation", "WCSchedule"));

    public Task VerifyWaitonPricingHeadingAndFillOutRequiredFieldsAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.WaitonPricingHeadingAndFillOutRequiredFields, expected, property, new ControlIntent("Navigation", "WaitonPricingHeadingAndFillOutRequiredFields"));

    public Task EnterWaiverOfSubrogationAsync(string value) =>
        _ui.FillAsync(_locators.WaiverOfSubrogation, value, new ControlIntent("Navigation", "WaiverOfSubrogation"));

    public Task PressWaiverOfSubrogationAsync(string key) =>
        _ui.PressAsync(_locators.WaiverOfSubrogation, key, new ControlIntent("Navigation", "WaiverOfSubrogation"));

    public Task EnterWaiverOfSubrogationExposureAsync(string value) =>
        _ui.FillAsync(_locators.WaiverOfSubrogationExposure, value, new ControlIntent("Navigation", "WaiverOfSubrogationExposure"));

    public Task PressWaiverOfSubrogationExposureAsync(string key) =>
        _ui.PressAsync(_locators.WaiverOfSubrogationExposure, key, new ControlIntent("Navigation", "WaiverOfSubrogationExposure"));

    public Task EnterWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync(string value) =>
        _ui.FillAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, value, new ControlIntent("Navigation", "WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days"));

    public Task PressWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync(string key) =>
        _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, key, new ControlIntent("Navigation", "WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days"));

    public Task EnterWhatAreTheProceduresAndMethodsForKeepingTheEDPAreasSecuredAsync(string value) =>
        _ui.FillAsync(_locators.WhatAreTheProceduresAndMethodsForKeepingTheEDPAreasSecured, value, new ControlIntent("Navigation", "WhatAreTheProceduresAndMethodsForKeepingTheEDPAreasSecured"));

    public Task PressWhatAreTheProceduresAndMethodsForKeepingTheEDPAreasSecuredAsync(string key) =>
        _ui.PressAsync(_locators.WhatAreTheProceduresAndMethodsForKeepingTheEDPAreasSecured, key, new ControlIntent("Navigation", "WhatAreTheProceduresAndMethodsForKeepingTheEDPAreasSecured"));

    public Task EnterWhatAreTheProceduresAndScheduleForBackingUpTheMediaAndDataAndTheirStorageAsync(string value) =>
        _ui.FillAsync(_locators.WhatAreTheProceduresAndScheduleForBackingUpTheMediaAndDataAndTheirStorage, value, new ControlIntent("Navigation", "WhatAreTheProceduresAndScheduleForBackingUpTheMediaAndDataAndTheirStorage"));

    public Task PressWhatAreTheProceduresAndScheduleForBackingUpTheMediaAndDataAndTheirStorageAsync(string key) =>
        _ui.PressAsync(_locators.WhatAreTheProceduresAndScheduleForBackingUpTheMediaAndDataAndTheirStorage, key, new ControlIntent("Navigation", "WhatAreTheProceduresAndScheduleForBackingUpTheMediaAndDataAndTheirStorage"));

    public Task EnterWhatIsTheConstructionOfEachSignAsync(string value) =>
        _ui.FillAsync(_locators.WhatIsTheConstructionOfEachSign, value, new ControlIntent("Navigation", "WhatIsTheConstructionOfEachSign"));

    public Task PressWhatIsTheConstructionOfEachSignAsync(string key) =>
        _ui.PressAsync(_locators.WhatIsTheConstructionOfEachSign, key, new ControlIntent("Navigation", "WhatIsTheConstructionOfEachSign"));

    public Task EnterWhatIsTheConstructionOfThePremisesWhereTheReceivablesAreStoredAsync(string value) =>
        _ui.FillAsync(_locators.WhatIsTheConstructionOfThePremisesWhereTheReceivablesAreStored, value, new ControlIntent("Navigation", "WhatIsTheConstructionOfThePremisesWhereTheReceivablesAreStored"));

    public Task PressWhatIsTheConstructionOfThePremisesWhereTheReceivablesAreStoredAsync(string key) =>
        _ui.PressAsync(_locators.WhatIsTheConstructionOfThePremisesWhereTheReceivablesAreStored, key, new ControlIntent("Navigation", "WhatIsTheConstructionOfThePremisesWhereTheReceivablesAreStored"));

    public Task EnterWhatIsTheDistanceInFeetToTheNearestFireHydrantAsync(string value) =>
        _ui.FillAsync(_locators.WhatIsTheDistanceInFeetToTheNearestFireHydrant, value, new ControlIntent("Navigation", "WhatIsTheDistanceInFeetToTheNearestFireHydrant"));

    public Task PressWhatIsTheDistanceInFeetToTheNearestFireHydrantAsync(string key) =>
        _ui.PressAsync(_locators.WhatIsTheDistanceInFeetToTheNearestFireHydrant, key, new ControlIntent("Navigation", "WhatIsTheDistanceInFeetToTheNearestFireHydrant"));

    public Task EnterWhatIsTheDistanceInMilesToTheNearestRespondingFireDepartmentAsync(string value) =>
        _ui.FillAsync(_locators.WhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment, value, new ControlIntent("Navigation", "WhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment"));

    public Task PressWhatIsTheDistanceInMilesToTheNearestRespondingFireDepartmentAsync(string key) =>
        _ui.PressAsync(_locators.WhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment, key, new ControlIntent("Navigation", "WhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment"));

    public Task VerifyWhatIsThePrimaryReasonThisNewPolicyIsBeingRewrittenWithFarmFamilyAmericanNationalAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.WhatIsThePrimaryReasonThisNewPolicyIsBeingRewrittenWithFarmFamilyAmericanNational, expected, property, new ControlIntent("Navigation", "WhatIsThePrimaryReasonThisNewPolicyIsBeingRewrittenWithFarmFamilyAmericanNational"));

    public Task EnterWhatIsTheProcedureForTransportingTheComputerEquipmentAsync(string value) =>
        _ui.FillAsync(_locators.WhatIsTheProcedureForTransportingTheComputerEquipment, value, new ControlIntent("Navigation", "WhatIsTheProcedureForTransportingTheComputerEquipment"));

    public Task PressWhatIsTheProcedureForTransportingTheComputerEquipmentAsync(string key) =>
        _ui.PressAsync(_locators.WhatIsTheProcedureForTransportingTheComputerEquipment, key, new ControlIntent("Navigation", "WhatIsTheProcedureForTransportingTheComputerEquipment"));

    public Task EnterWhatIsThePublicProtectionClassRatingAsync(string value) =>
        _ui.FillAsync(_locators.WhatIsThePublicProtectionClassRating, value, new ControlIntent("Navigation", "WhatIsThePublicProtectionClassRating"));

    public Task PressWhatIsThePublicProtectionClassRatingAsync(string key) =>
        _ui.PressAsync(_locators.WhatIsThePublicProtectionClassRating, key, new ControlIntent("Navigation", "WhatIsThePublicProtectionClassRating"));

    public Task EnterWhatSafeguardsAreInPlaceForReceivablesToProtectAgainstDamageOrTheftAsync(string value) =>
        _ui.FillAsync(_locators.WhatSafeguardsAreInPlaceForReceivablesToProtectAgainstDamageOrTheft, value, new ControlIntent("Navigation", "WhatSafeguardsAreInPlaceForReceivablesToProtectAgainstDamageOrTheft"));

    public Task PressWhatSafeguardsAreInPlaceForReceivablesToProtectAgainstDamageOrTheftAsync(string key) =>
        _ui.PressAsync(_locators.WhatSafeguardsAreInPlaceForReceivablesToProtectAgainstDamageOrTheft, key, new ControlIntent("Navigation", "WhatSafeguardsAreInPlaceForReceivablesToProtectAgainstDamageOrTheft"));

    public Task EnterWhichFormAreYouCompletingAsync(string value) =>
        _ui.FillAsync(_locators.WhichFormAreYouCompleting, value, new ControlIntent("Navigation", "WhichFormAreYouCompleting"));

    public Task PressWhichFormAreYouCompletingAsync(string key) =>
        _ui.PressAsync(_locators.WhichFormAreYouCompleting, key, new ControlIntent("Navigation", "WhichFormAreYouCompleting"));

    public Task EnterWhyIsThisCoverageDesiredAsync(string value) =>
        _ui.FillAsync(_locators.WhyIsThisCoverageDesired, value, new ControlIntent("Navigation", "WhyIsThisCoverageDesired"));

    public Task PressWhyIsThisCoverageDesiredAsync(string key) =>
        _ui.PressAsync(_locators.WhyIsThisCoverageDesired, key, new ControlIntent("Navigation", "WhyIsThisCoverageDesired"));

    public Task EnterYearAsync(string value) =>
        _ui.FillAsync(_locators.Year, value, new ControlIntent("Navigation", "Year"));

    public Task PressYearAsync(string key) =>
        _ui.PressAsync(_locators.Year, key, new ControlIntent("Navigation", "Year"));

    public Task EnterYearBuiltAsync(string value) =>
        _ui.FillAsync(_locators.YearBuilt, value, new ControlIntent("Navigation", "YearBuilt"));

    public Task PressYearBuiltAsync(string key) =>
        _ui.PressAsync(_locators.YearBuilt, key, new ControlIntent("Navigation", "YearBuilt"));

    public Task EnterYearLicensedAsync(string value) =>
        _ui.FillAsync(_locators.YearLicensed, value, new ControlIntent("Navigation", "YearLicensed"));

    public Task PressYearLicensedAsync(string key) =>
        _ui.PressAsync(_locators.YearLicensed, key, new ControlIntent("Navigation", "YearLicensed"));

    public Task EnterYearsInBusinessAsync(string value) =>
        _ui.FillAsync(_locators.YearsInBusiness, value, new ControlIntent("Navigation", "YearsInBusiness"));

    public Task PressYearsInBusinessAsync(string key) =>
        _ui.PressAsync(_locators.YearsInBusiness, key, new ControlIntent("Navigation", "YearsInBusiness"));

    public Task EnterLocationZipCodeAsync(string value) =>
        _ui.FillAsync(_locators.LocationZipCode, value, new ControlIntent("Navigation", "LocationZipCode"));

    public Task PressLocationZipCodeAsync(string key) =>
        _ui.PressAsync(_locators.LocationZipCode, key, new ControlIntent("Navigation", "LocationZipCode"));

    public Task EnterThirdPartyDesigneeZipCodeAsync(string value) =>
        _ui.FillAsync(_locators.ThirdPartyDesigneeZipCode, value, new ControlIntent("Navigation", "ThirdPartyDesigneeZipCode"));

    public Task PressThirdPartyDesigneeZipCodeAsync(string key) =>
        _ui.PressAsync(_locators.ThirdPartyDesigneeZipCode, key, new ControlIntent("Navigation", "ThirdPartyDesigneeZipCode"));

    public Task EnterGLOCPRiskZipCodeAsync(string value) =>
        _ui.FillAsync(_locators.GLOCPRiskZipCode, value, new ControlIntent("Navigation", "GLOCPRiskZipCode"));

    public Task PressGLOCPRiskZipCodeAsync(string key) =>
        _ui.PressAsync(_locators.GLOCPRiskZipCode, key, new ControlIntent("Navigation", "GLOCPRiskZipCode"));

    public Task VerifyLocationZipCodeAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.LocationZipCode, expected, property, new ControlIntent("Navigation", "LocationZipCode"));

    public Task PauseAsync(int milliseconds) =>
        Task.Delay(milliseconds);
public Task<string> CaptureDescriptionOfSpecifiedOperationAsync(string property = "") =>
        _ui.CaptureAsync(_locators.DescriptionOfSpecifiedOperation, property, new ControlIntent("Navigation", "DescriptionOfSpecifiedOperation"));

    public Task<string> CaptureVehicleSchedule1VehAsync(string property = "") =>
        _ui.CaptureAsync(_locators.VehicleSchedule1Veh, property, new ControlIntent("Navigation", "VehicleSchedule1Veh"));

    public Task EnterAdditionalOtherInterestInputLastNameAsync(string value) =>
        _ui.FillAsync(_locators.AdditionalOtherInterestInputLastName, value, new ControlIntent("Navigation", "AdditionalOtherInterestInputLastName"));

    public Task EnterEntityInfoFrameEntityInfoWindowFaxAsync(string value) =>
        _ui.FillAsync(_locators.EntityInfoFrameEntityInfoWindowFax, value, new ControlIntent("Navigation", "EntityInfoFrameEntityInfoWindowFax"));

    public Task EnterEntityInfoFrameEntityInfoWindowBureauNumberAsync(string value) =>
        _ui.FillAsync(_locators.EntityInfoFrameEntityInfoWindowBureauNumber, value, new ControlIntent("Navigation", "EntityInfoFrameEntityInfoWindowBureauNumber"));

    public Task EnterEntityInfoFrameEntityInfoWindowStateUnemploymentNumberDefaultAsync(string value) =>
        _ui.FillAsync(_locators.EntityInfoFrameEntityInfoWindowStateUnemploymentNumberDefault, value, new ControlIntent("Navigation", "EntityInfoFrameEntityInfoWindowStateUnemploymentNumberDefault"));


    public Task EnterAVCostNewSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.AVCostNew, value, new ControlIntent("Navigation", "AVCostNew"), delayMs);

    public Task EnterAWhatIsThePublicProtectionClassRatingSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.AWhatIsThePublicProtectionClassRating, value, new ControlIntent("Navigation", "AWhatIsThePublicProtectionClassRating"), delayMs);

    public Task EnterAddDriverNameSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.AddDriverName, value, new ControlIntent("Navigation", "AddDriverName"), delayMs);

    public Task EnterAdditionalOtherInterestAddressSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.AdditionalOtherInterestAddress, value, new ControlIntent("Navigation", "AdditionalOtherInterestAddress"), delayMs);

    public Task EnterAdditionalOtherInterestInputFirstNameSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.AdditionalOtherInterestInputFirstName, value, new ControlIntent("Navigation", "AdditionalOtherInterestInputFirstName"), delayMs);

    public Task EnterAddressSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.Address, value, new ControlIntent("Navigation", "Address"), delayMs);

    public Task EnterCG2935AddLInsuredStateOrPoliticalPermitsAddressSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.CG2935AddLInsuredStateOrPoliticalPermitsAddress, value, new ControlIntent("Navigation", "CG2935AddLInsuredStateOrPoliticalPermitsAddress"), delayMs);

    public Task EnterGLOCPRiskAddressSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.GLOCPRiskAddress, value, new ControlIntent("Navigation", "GLOCPRiskAddress"), delayMs);

    public Task EnterAddressStreetCityStateZipSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.AddressStreetCityStateZip, value, new ControlIntent("Navigation", "AddressStreetCityStateZip"), delayMs);

    public Task EnterAggregateLimitSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.AggregateLimit, value, new ControlIntent("Navigation", "AggregateLimit"), delayMs);

    public Task EnterAnnualGrossReceiptsSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.AnnualGrossReceipts, value, new ControlIntent("Navigation", "AnnualGrossReceipts"), delayMs);

    public Task EnterAnyPersonalAutoPolicyListingNameInsuredSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.AnyPersonalAutoPolicyListingNameInsured, value, new ControlIntent("Navigation", "AnyPersonalAutoPolicyListingNameInsured"), delayMs);

    public Task EnterAnyVehicleCoveredRegisteredInNotPrimaryStateSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.AnyVehicleCoveredRegisteredInNotPrimaryState, value, new ControlIntent("Navigation", "AnyVehicleCoveredRegisteredInNotPrimaryState"), delayMs);

    public Task EnterAreAnySignsOffPremisesOrNotAttachedToBuildingSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.AreAnySignsOffPremisesOrNotAttachedToBuilding, value, new ControlIntent("Navigation", "AreAnySignsOffPremisesOrNotAttachedToBuilding"), delayMs);

    public Task EnterAreThereAnyCommercialVehiclesOwnedByTheApplicantNotInsuredOnThePolicySequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.AreThereAnyCommercialVehiclesOwnedByTheApplicantNotInsuredOnThePolicy, value, new ControlIntent("Navigation", "AreThereAnyCommercialVehiclesOwnedByTheApplicantNotInsuredOnThePolicy"), delayMs);

    public Task EnterAreThereAnyOfficersThatShouldBeExcludedSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.AreThereAnyOfficersThatShouldBeExcluded, value, new ControlIntent("Navigation", "AreThereAnyOfficersThatShouldBeExcluded"), delayMs);

    public Task EnterAudioVisualSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.AudioVisual, value, new ControlIntent("Navigation", "AudioVisual"), delayMs);

    public Task EnterAvailableClassificationsSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.AvailableClassifications, value, new ControlIntent("Navigation", "AvailableClassifications"), delayMs);

    public Task EnterAverageNumberOfDaysServiceSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.AverageNumberOfDaysService, value, new ControlIntent("Navigation", "AverageNumberOfDaysService"), delayMs);

    public Task EnterAverageNumberOfWorkingDaysSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.AverageNumberOfWorkingDays, value, new ControlIntent("Navigation", "AverageNumberOfWorkingDays"), delayMs);

    public Task EnterAverageServiceChargeSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.AverageServiceCharge, value, new ControlIntent("Navigation", "AverageServiceCharge"), delayMs);

    public Task EnterAverageValuePerOrderSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.AverageValuePerOrder, value, new ControlIntent("Navigation", "AverageValuePerOrder"), delayMs);

    public Task EnterBAreThereAnyPrivateProtectionImprovementsSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.BAreThereAnyPrivateProtectionImprovements, value, new ControlIntent("Navigation", "BAreThereAnyPrivateProtectionImprovements"), delayMs);

    public Task EnterBG2SymbolSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.BG2Symbol, value, new ControlIntent("Navigation", "BG2Symbol"), delayMs);

    public Task EnterBG2SymbolPrefixSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.BG2SymbolPrefix, value, new ControlIntent("Navigation", "BG2SymbolPrefix"), delayMs);

    public Task EnterBillTypeSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.BillType, value, new ControlIntent("Navigation", "BillType"), delayMs);

    public Task EnterBodyStyleSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.BodyStyle, value, new ControlIntent("Navigation", "BodyStyle"), delayMs);

    public Task EnterBoomDeductibleSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.BoomDeductible, value, new ControlIntent("Navigation", "BoomDeductible"), delayMs);

    public Task EnterBorrowingHiringOrLeasingWithinYearSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.BorrowingHiringOrLeasingWithinYear, value, new ControlIntent("Navigation", "BorrowingHiringOrLeasingWithinYear"), delayMs);

    public Task EnterBuildingLimitSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.BuildingLimit, value, new ControlIntent("Navigation", "BuildingLimit"), delayMs);

    public Task EnterBuildingRatingGroupSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.RiskInputRatingGroupID, value, new ControlIntent("Navigation", "BuildingRatingGroup"), delayMs);

    public Task EnterBusinessInterruptionDescriptionOfScheduledPropertySequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.BusinessInterruptionDescriptionOfScheduledProperty, value, new ControlIntent("Navigation", "BusinessInterruptionDescriptionOfScheduledProperty"), delayMs);

    public Task EnterBusinessInterruptionEndorsementSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.BusinessInterruptionEndorsement, value, new ControlIntent("Navigation", "BusinessInterruptionEndorsement"), delayMs);

    public Task EnterBusinessInterruptionLimitOfInsuranceSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.BusinessInterruptionLimitOfInsurance, value, new ControlIntent("Navigation", "BusinessInterruptionLimitOfInsurance"), delayMs);

    public Task EnterCA9940ContractProvisionsSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.CA9940ContractProvisions, value, new ControlIntent("Navigation", "CA9940ContractProvisions"), delayMs);

    public Task EnterCA9940MakeSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.CA9940Make, value, new ControlIntent("Navigation", "CA9940Make"), delayMs);

    public Task EnterCA9940ModelSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.CA9940Model, value, new ControlIntent("Navigation", "CA9940Model"), delayMs);

    public Task EnterCA9940VINSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.CA9940VIN, value, new ControlIntent("Navigation", "CA9940VIN"), delayMs);

    public Task EnterCA9940YearSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.CA9940Year, value, new ControlIntent("Navigation", "CA9940Year"), delayMs);

    public Task EnterCA9948ClassesOfCommoditiesTransportedSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.CA9948ClassesOfCommoditiesTransported, value, new ControlIntent("Navigation", "CA9948ClassesOfCommoditiesTransported"), delayMs);

    public Task EnterCGLLimitsSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.CGLLimits, value, new ControlIntent("Navigation", "CGLLimits"), delayMs);

    public Task EnterCWhatIsTheDistanceInFeetToTheNearestHydrantSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.CWhatIsTheDistanceInFeetToTheNearestHydrant, value, new ControlIntent("Navigation", "CWhatIsTheDistanceInFeetToTheNearestHydrant"), delayMs);

    public Task EnterCarrierSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.Carrier, value, new ControlIntent("Navigation", "Carrier"), delayMs);

    public Task EnterCauseOfLossSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.CauseOfLoss, value, new ControlIntent("Navigation", "CauseOfLoss"), delayMs);

    public Task EnterCitySequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.City, value, new ControlIntent("Navigation", "City"), delayMs);

    public Task EnterClassCodeSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.ClassCode, value, new ControlIntent("Navigation", "ClassCode"), delayMs);

    public Task EnterClassCodeFrameClassCodeWindowSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.ClassCodeFrameClassCodeWindow, value, new ControlIntent("Navigation", "ClassCodeFrameClassCodeWindow"), delayMs);

    public Task EnterClassificationOfRiskSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.ClassificationOfRisk, value, new ControlIntent("Navigation", "ClassificationOfRisk"), delayMs);

    public Task EnterAddClientSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.AddClient, value, new ControlIntent("Navigation", "AddClient"), delayMs);

    public Task EnterPolicyCovgComputerSystemsCoinsuranceSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.PolicyCovgComputerSystemsCoinsurance, value, new ControlIntent("Navigation", "PolicyCovgComputerSystemsCoinsurance"), delayMs);

    public Task EnterRatingGroupsCoinsuranceSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.RatingGroupsCoinsurance, value, new ControlIntent("Navigation", "RatingGroupsCoinsurance"), delayMs);

    public Task EnterPolicyCovgContractorsEquipmentCoinsuranceSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.PolicyCovgContractorsEquipmentCoinsurance, value, new ControlIntent("Navigation", "PolicyCovgContractorsEquipmentCoinsurance"), delayMs);

    public Task EnterCollisionCoverageSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.CollisionCoverage, value, new ControlIntent("Navigation", "CollisionCoverage"), delayMs);

    public Task EnterHiredAutoCollisionDeductibleSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.HiredAutoCollisionDeductible, value, new ControlIntent("Navigation", "HiredAutoCollisionDeductible"), delayMs);

    public Task EnterCompanyNameSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.CompanyName, value, new ControlIntent("Navigation", "CompanyName"), delayMs);

    public Task EnterComputerEquipmentSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.ComputerEquipment, value, new ControlIntent("Navigation", "ComputerEquipment"), delayMs);

    public Task EnterBuildingDetailConstructionSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.BuildingDetailConstruction, value, new ControlIntent("Navigation", "BuildingDetailConstruction"), delayMs);

    public Task EnterRiskBaileesCustomersConstructionSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.RiskBaileesCustomersConstruction, value, new ControlIntent("Navigation", "RiskBaileesCustomersConstruction"), delayMs);

    public Task EnterConstructionCodeSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.ConstructionCode, value, new ControlIntent("Navigation", "ConstructionCode"), delayMs);

    public Task EnterRiskAccountsReceivableConstructionSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.RiskAccountsReceivableConstruction, value, new ControlIntent("Navigation", "RiskAccountsReceivableConstruction"), delayMs);

    public Task EnterCoverageEndDateSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.CoverageEndDate, value, new ControlIntent("Navigation", "CoverageEndDate"), delayMs);

    public Task EnterPolicyCovgGLCoverageFormSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.PolicyCovgGLCoverageForm, value, new ControlIntent("Navigation", "PolicyCovgGLCoverageForm"), delayMs);

    public Task EnterRiskMainCoverageFormSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.RiskMainCoverageForm, value, new ControlIntent("Navigation", "RiskMainCoverageForm"), delayMs);

    public Task EnterCoverageFormToBeAddedSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.CoverageFormToBeAdded, value, new ControlIntent("Navigation", "CoverageFormToBeAdded"), delayMs);

    public Task EnterCoverageTypeSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.CoverageType, value, new ControlIntent("Navigation", "CoverageType"), delayMs);

    public Task EnterCoveredPropertyConsistingPrincipallyOfSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.CoveredPropertyConsistingPrincipallyOf, value, new ControlIntent("Navigation", "CoveredPropertyConsistingPrincipallyOf"), delayMs);

    public Task EnterDWhatIsTheDistanceInMilesToTheNearestRespondingFireDepartmentSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.DWhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment, value, new ControlIntent("Navigation", "DWhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment"), delayMs);

    public Task EnterDataAndMediaSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.DataAndMedia, value, new ControlIntent("Navigation", "DataAndMedia"), delayMs);

    public Task EnterDateOfBirthSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.DateOfBirth, value, new ControlIntent("Navigation", "DateOfBirth"), delayMs);

    public Task EnterDateOfHireSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.DateOfHire, value, new ControlIntent("Navigation", "DateOfHire"), delayMs);

    public Task EnterDebrisRemovalAdditionalSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.DebrisRemovalAdditional, value, new ControlIntent("Navigation", "DebrisRemovalAdditional"), delayMs);

    public Task EnterDebrisRemovalAdditionalLimitSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.DebrisRemovalAdditionalLimit, value, new ControlIntent("Navigation", "DebrisRemovalAdditionalLimit"), delayMs);

    public Task EnterDedTypeSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.DedType, value, new ControlIntent("Navigation", "DedType"), delayMs);

    public Task EnterDedicatedLineSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.DedicatedLine, value, new ControlIntent("Navigation", "DedicatedLine"), delayMs);

    public Task EnterRatingGroupsDeductibleSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.RatingGroupsDeductible, value, new ControlIntent("Navigation", "RatingGroupsDeductible"), delayMs);

    public Task EnterEndorsementIF0002WaterborneEquipmentDeductibleSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.EndorsementIF0002WaterborneEquipmentDeductible, value, new ControlIntent("Navigation", "EndorsementIF0002WaterborneEquipmentDeductible"), delayMs);

    public Task EnterPolicyCovgMotorTruckCargoDeductibleSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.PolicyCovgMotorTruckCargoDeductible, value, new ControlIntent("Navigation", "PolicyCovgMotorTruckCargoDeductible"), delayMs);

    public Task EnterRiskBaileesCustomersDeductibleSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.RiskBaileesCustomersDeductible, value, new ControlIntent("Navigation", "RiskBaileesCustomersDeductible"), delayMs);

    public Task EnterBuildingDetailDeductibleSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.BuildingDetailDeductible, value, new ControlIntent("Navigation", "BuildingDetailDeductible"), delayMs);

    public Task EnterDeductibleBasisSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.DeductibleBasis, value, new ControlIntent("Navigation", "DeductibleBasis"), delayMs);

    public Task EnterPolicyCovgContractorsEquipmentDeductibleSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.PolicyCovgContractorsEquipmentDeductible, value, new ControlIntent("Navigation", "PolicyCovgContractorsEquipmentDeductible"), delayMs);

    public Task EnterPolicyCovgComputerSystemsDeductibleSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.PolicyCovgComputerSystemsDeductible, value, new ControlIntent("Navigation", "PolicyCovgComputerSystemsDeductible"), delayMs);

    public Task EnterBuildingDetailDeductibleIncreasedTheftSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.BuildingDetailDeductibleIncreasedTheft, value, new ControlIntent("Navigation", "BuildingDetailDeductibleIncreasedTheft"), delayMs);

    public Task EnterRatingGroupsDeductibleIncreasedTheftSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.RatingGroupsDeductibleIncreasedTheft, value, new ControlIntent("Navigation", "RatingGroupsDeductibleIncreasedTheft"), delayMs);

    public Task EnterBuildingDetailDeductibleWindHailSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.BuildingDetailDeductibleWindHail, value, new ControlIntent("Navigation", "BuildingDetailDeductibleWindHail"), delayMs);

    public Task EnterRatingGroupsDeductibleWindHailSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.RatingGroupsDeductibleWindHail, value, new ControlIntent("Navigation", "RatingGroupsDeductibleWindHail"), delayMs);

    public Task EnterDefaultExpModTypeSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.DefaultExpModType, value, new ControlIntent("Navigation", "DefaultExpModType"), delayMs);

    public Task EnterDescribeAllHoldHarmlessAgreementsAndPleaseProvideACopySequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.DescribeAllHoldHarmlessAgreementsAndPleaseProvideACopy, value, new ControlIntent("Navigation", "DescribeAllHoldHarmlessAgreementsAndPleaseProvideACopy"), delayMs);

    public Task EnterPolicyCovgContractorsEquipmentDescriptionSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.PolicyCovgContractorsEquipmentDescription, value, new ControlIntent("Navigation", "PolicyCovgContractorsEquipmentDescription"), delayMs);

    public Task EnterPolicyCovgBaileesCutomersDescriptionSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.PolicyCovgBaileesCutomersDescription, value, new ControlIntent("Navigation", "PolicyCovgBaileesCutomersDescription"), delayMs);

    public Task EnterPolicyCovgComputerSystemsDescriptionSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.PolicyCovgComputerSystemsDescription, value, new ControlIntent("Navigation", "PolicyCovgComputerSystemsDescription"), delayMs);

    public Task EnterRatingGroupsDescriptionSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.RatingGroupsDescription, value, new ControlIntent("Navigation", "RatingGroupsDescription"), delayMs);

    public Task EnterPolicyCovgSignsDescriptionSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.PolicyCovgSignsDescription, value, new ControlIntent("Navigation", "PolicyCovgSignsDescription"), delayMs);

    public Task EnterPolicyCovgMotorTruckCargoDescriptionSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.PolicyCovgMotorTruckCargoDescription, value, new ControlIntent("Navigation", "PolicyCovgMotorTruckCargoDescription"), delayMs);

    public Task EnterDescriptionOfBusinessActivitesSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.DescriptionOfBusinessActivites, value, new ControlIntent("Navigation", "DescriptionOfBusinessActivites"), delayMs);

    public Task EnterDescriptionOfOperationSSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.DescriptionOfOperationS, value, new ControlIntent("Navigation", "DescriptionOfOperationS"), delayMs);

    public Task EnterDescriptionOfOperationsSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.DescriptionOfOperations, value, new ControlIntent("Navigation", "DescriptionOfOperations"), delayMs);

    public Task EnterDescriptionOfSpecifiedOperationSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.DescriptionOfSpecifiedOperation, value, new ControlIntent("Navigation", "DescriptionOfSpecifiedOperation"), delayMs);

    public Task EnterDoYouHaveACDLLicenseSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.DoYouHaveACDLLicense, value, new ControlIntent("Navigation", "DoYouHaveACDLLicense"), delayMs);

    public Task EnterDoesAnyRiskGeneratePowerOtherThanPrivateWindmillsOrEmergencyBackupSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.DoesAnyRiskGeneratePowerOtherThanPrivateWindmillsOrEmergencyBackup, value, new ControlIntent("Navigation", "DoesAnyRiskGeneratePowerOtherThanPrivateWindmillsOrEmergencyBackup"), delayMs);

    public Task EnterDoesTheApplicantWishToCoverAnySignsInsideTheirPremisesSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.DoesTheApplicantWishToCoverAnySignsInsideTheirPremises, value, new ControlIntent("Navigation", "DoesTheApplicantWishToCoverAnySignsInsideTheirPremises"), delayMs);

    public Task EnterDoesTheInsuredApplicantRequestAdditionalInsuredStatusWithoutAWrittenContractRequirementSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.DoesTheInsuredApplicantRequestAdditionalInsuredStatusWithoutAWrittenContractRequirement, value, new ControlIntent("Navigation", "DoesTheInsuredApplicantRequestAdditionalInsuredStatusWithoutAWrittenContractRequirement"), delayMs);

    public Task EnterDoesTheInsuredEnterIntoContractsInvolvingCommercialSnowRemovalIncludingSnowRemovalFromResidentialRoofsSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.DoesTheInsuredEnterIntoContractsInvolvingCommercialSnowRemovalIncludingSnowRemovalFromResidentialRoofs, value, new ControlIntent("Navigation", "DoesTheInsuredEnterIntoContractsInvolvingCommercialSnowRemovalIncludingSnowRemovalFromResidentialRoofs"), delayMs);

    public Task EnterDoesTheInsuredEverEnterIntoContractsForTasksNotContemplatedInTheCurrentLiabilityClassificationsOnThePolicySequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.DoesTheInsuredEverEnterIntoContractsForTasksNotContemplatedInTheCurrentLiabilityClassificationsOnThePolicy, value, new ControlIntent("Navigation", "DoesTheInsuredEverEnterIntoContractsForTasksNotContemplatedInTheCurrentLiabilityClassificationsOnThePolicy"), delayMs);

    public Task EnterDryCleaningSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.DryCleaning, value, new ControlIntent("Navigation", "DryCleaning"), delayMs);

    public Task EnterDuplicatedRecordsSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.DuplicatedRecords, value, new ControlIntent("Navigation", "DuplicatedRecords"), delayMs);

    public Task EnterEAreNoSmokingRulesPostedAndEnforcedSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.EAreNoSmokingRulesPostedAndEnforced, value, new ControlIntent("Navigation", "EAreNoSmokingRulesPostedAndEnforced"), delayMs);

    public Task EnterEMailSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.EMail, value, new ControlIntent("Navigation", "EMail"), delayMs);

    public Task EnterEarthquakeSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.Earthquake, value, new ControlIntent("Navigation", "Earthquake"), delayMs);

    public Task EnterEasyPaySequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.EasyPay, value, new ControlIntent("Navigation", "EasyPay"), delayMs);

    public Task EnterCommercialAutoEffectiveDateSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.BusinessownersEffectiveDate, value, new ControlIntent("Navigation", "CommercialAutoEffectiveDate"), delayMs);

    public Task EnterBusinessownersEffectiveDateSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.BusinessownersEffectiveDate, value, new ControlIntent("Navigation", "BusinessownersEffectiveDate"), delayMs);

    public Task EnterPolicyInfoRequiredAndOptionalFieldsEffectiveDateSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.PolicyInfoRequiredAndOptionalFieldsEffectiveDate, value, new ControlIntent("Navigation", "PolicyInfoRequiredAndOptionalFieldsEffectiveDate"), delayMs);

    public Task EnterEligibleForEnhancedWindRatingProgramSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.EligibleForEnhancedWindRatingProgram, value, new ControlIntent("Navigation", "EligibleForEnhancedWindRatingProgram"), delayMs);

    public Task EnterCG2401NonBindingArbitrationEndorsementTypeSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.CG2401NonBindingArbitrationEndorsementType, value, new ControlIntent("Navigation", "CG2401NonBindingArbitrationEndorsementType"), delayMs);

    public Task EnterBAPEndorsementsEndorsementTypeSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.BAPEndorsementsEndorsementType, value, new ControlIntent("Navigation", "BAPEndorsementsEndorsementType"), delayMs);

    public Task EnterEndorsementsPartnersOfficersAndOthersExclusionEndorsementTypeSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.EndorsementsPartnersOfficersAndOthersExclusionEndorsementType, value, new ControlIntent("Navigation", "EndorsementsPartnersOfficersAndOthersExclusionEndorsementType"), delayMs);

    public Task EnterEngineSizeCcSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.EngineSizeCc, value, new ControlIntent("Navigation", "EngineSizeCc"), delayMs);

    public Task EnterEstimatedHighestValueSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.EstimatedHighestValue, value, new ControlIntent("Navigation", "EstimatedHighestValue"), delayMs);

    public Task EnterEstimatorTypeSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.EstimatorType, value, new ControlIntent("Navigation", "EstimatorType"), delayMs);

    public Task EnterExcludedLiabilityConfidentialInformationSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.ExcludedLiabilityConfidentialInformation, value, new ControlIntent("Navigation", "ExcludedLiabilityConfidentialInformation"), delayMs);

    public Task EnterExperienceModTypeSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.ExperienceModType, value, new ControlIntent("Navigation", "ExperienceModType"), delayMs);

    public Task EnterExperienceRatedSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.ExperienceRated, value, new ControlIntent("Navigation", "ExperienceRated"), delayMs);

    public Task EnterExperienceRatingOptionsSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.ExperienceRatingOptions, value, new ControlIntent("Navigation", "ExperienceRatingOptions"), delayMs);

    public Task EnterGeneralLiabilityExpirationDateSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.BusinessownersExpirationDate, value, new ControlIntent("Navigation", "GeneralLiabilityExpirationDate"), delayMs);

    public Task EnterBusinessownersExpirationDateSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.BusinessownersExpirationDate, value, new ControlIntent("Navigation", "BusinessownersExpirationDate"), delayMs);

    public Task EnterExposureSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.Exposure, value, new ControlIntent("Navigation", "Exposure"), delayMs);

    public Task EnterExtendedEmployeeCoverageSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.ExtendedEmployeeCoverage, value, new ControlIntent("Navigation", "ExtendedEmployeeCoverage"), delayMs);

    public Task EnterExtraExpenseSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.ExtraExpense, value, new ControlIntent("Navigation", "ExtraExpense"), delayMs);

    public Task EnterFeetFromHydrantSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.FeetFromHydrant, value, new ControlIntent("Navigation", "FeetFromHydrant"), delayMs);

    public Task EnterFireDamageSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.FireDamage, value, new ControlIntent("Navigation", "FireDamage"), delayMs);

    public Task EnterStateDetailsDriveOtherCarFirstNameSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.StateDetailsDriveOtherCarFirstName, value, new ControlIntent("Navigation", "StateDetailsDriveOtherCarFirstName"), delayMs);

    public Task EnterFirstNameSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.FirstName, value, new ControlIntent("Navigation", "FirstName"), delayMs);

    public Task EnterGCWSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.GCW, value, new ControlIntent("Navigation", "GCW"), delayMs);

    public Task EnterGroupClassSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.GroupClass, value, new ControlIntent("Navigation", "GroupClass"), delayMs);

    public Task EnterHasAnyApplicantBeenConvictedOfAFelonyOrBeenInvolvedInAnyIncidentsOrClaimsRelatingToSexualAbuseOrMolestationAllegationsDiscriminationArsonFraudBriberyOrNegligentHiringSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.HasAnyApplicantBeenConvictedOfAFelonyOrBeenInvolvedInAnyIncidentsOrClaimsRelatingToSexualAbuseOrMolestationAllegationsDiscriminationArsonFraudBriberyOrNegligentHiring, value, new ControlIntent("Navigation", "HasAnyApplicantBeenConvictedOfAFelonyOrBeenInvolvedInAnyIncidentsOrClaimsRelatingToSexualAbuseOrMolestationAllegationsDiscriminationArsonFraudBriberyOrNegligentHiring"), delayMs);

    public Task EnterHiredAutoCA2001AddressSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.HiredAutoCA2001Address, value, new ControlIntent("Navigation", "HiredAutoCA2001Address"), delayMs);

    public Task EnterHiredAutoCA2001FirstNameSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.HiredAutoCA2001FirstName, value, new ControlIntent("Navigation", "HiredAutoCA2001FirstName"), delayMs);

    public Task EnterHiredAutoCA2001LastNameSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.HiredAutoCA2001LastName, value, new ControlIntent("Navigation", "HiredAutoCA2001LastName"), delayMs);

    public Task EnterHiredAutoCA2001ZipCodeSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.HiredAutoCA2001ZipCode, value, new ControlIntent("Navigation", "HiredAutoCA2001ZipCode"), delayMs);

    public Task EnterHiredAutoExtAddlInsuredSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.HiredAutoExtAddlInsured, value, new ControlIntent("Navigation", "HiredAutoExtAddlInsured"), delayMs);

    public Task EnterHiredAutoOKSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.HiredAutoOK, value, new ControlIntent("Navigation", "HiredAutoOK"), delayMs);

    public Task EnterHiredEquipmentSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.HiredEquipment, value, new ControlIntent("Navigation", "HiredEquipment"), delayMs);

    public Task EnterHowOftenIsDataBackedUpSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.HowOftenIsDataBackedUp, value, new ControlIntent("Navigation", "HowOftenIsDataBackedUp"), delayMs);

    public Task EnterIFRAMEDuckCreekPolicyAddressEsOrDescriptionSOfDesignatedFarmLocationSSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.IFRAMEDuckCreekPolicyAddressEsOrDescriptionSOfDesignatedFarmLocationS, value, new ControlIntent("Navigation", "IFRAMEDuckCreekPolicyAddressEsOrDescriptionSOfDesignatedFarmLocationS"), delayMs);

    public Task EnterIFRAMEDuckCreekPolicyAddressEsOrDescriptionSOfDesignatedPremisesSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.IFRAMEDuckCreekPolicyAddressEsOrDescriptionSOfDesignatedPremises, value, new ControlIntent("Navigation", "IFRAMEDuckCreekPolicyAddressEsOrDescriptionSOfDesignatedPremises"), delayMs);

    public Task EnterIFRAMEDuckCreekPolicyDescriptionOfPremisesOrActivitiesSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.IFRAMEDuckCreekPolicyDescriptionOfPremisesOrActivities, value, new ControlIntent("Navigation", "IFRAMEDuckCreekPolicyDescriptionOfPremisesOrActivities"), delayMs);

    public Task EnterIFRAMEDuckCreekPolicyExcludedDriverSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.IFRAMEDuckCreekPolicyExcludedDriver, value, new ControlIntent("Navigation", "IFRAMEDuckCreekPolicyExcludedDriver"), delayMs);

    public Task EnterIFRAMEDuckCreekPolicyNameSOrDescriptionSOfDesignatedAnimalSSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.IFRAMEDuckCreekPolicyNameSOrDescriptionSOfDesignatedAnimalS, value, new ControlIntent("Navigation", "IFRAMEDuckCreekPolicyNameSOrDescriptionSOfDesignatedAnimalS"), delayMs);

    public Task EnterIfYesDescribeSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.IfYesDescribe, value, new ControlIntent("Navigation", "IfYesDescribe"), delayMs);

    public Task EnterIfYesExplainSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.IfYesExplain, value, new ControlIntent("Navigation", "IfYesExplain"), delayMs);

    public Task EnterIncreasedPollutantCleanupSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.IncreasedPollutantCleanup, value, new ControlIntent("Navigation", "IncreasedPollutantCleanup"), delayMs);

    public Task EnterIndicateTheBuildingSAgeTypeOfConstructionAndProtectionClassAndOtherTenantsInTheBuildingSWhereTheComputerEquipmentIsLocatedSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.IndicateTheBuildingSAgeTypeOfConstructionAndProtectionClassAndOtherTenantsInTheBuildingSWhereTheComputerEquipmentIsLocated, value, new ControlIntent("Navigation", "IndicateTheBuildingSAgeTypeOfConstructionAndProtectionClassAndOtherTenantsInTheBuildingSWhereTheComputerEquipmentIsLocated"), delayMs);

    public Task EnterInterestSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.Interest, value, new ControlIntent("Navigation", "Interest"), delayMs);

    public Task EnterIsTheBuildingCooledSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.IsTheBuildingCooled, value, new ControlIntent("Navigation", "IsTheBuildingCooled"), delayMs);

    public Task EnterIsTheBuildingHeatedWithASolidFuelHeatingDeviceSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.IsTheBuildingHeatedWithASolidFuelHeatingDevice, value, new ControlIntent("Navigation", "IsTheBuildingHeatedWithASolidFuelHeatingDevice"), delayMs);

    public Task EnterIsTheInsuredEngagedInAnySnowOrIceRemovalOperationsSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.IsTheInsuredEngagedInAnySnowOrIceRemovalOperations, value, new ControlIntent("Navigation", "IsTheInsuredEngagedInAnySnowOrIceRemovalOperations"), delayMs);

    public Task EnterIsThereAPriorCarrierSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.IsThereAPriorCarrier, value, new ControlIntent("Navigation", "IsThereAPriorCarrier"), delayMs);

    public Task EnterIsThisCoverageBoundSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.IsThisCoverageBound, value, new ControlIntent("Navigation", "IsThisCoverageBound"), delayMs);

    public Task EnterIsThisVehicleUsedInSnowPlowOperationsSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, value, new ControlIntent("Navigation", "IsThisVehicleUsedInSnowPlowOperations"), delayMs);

    public Task EnterJavaScriptSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.JavaScript, value, new ControlIntent("Navigation", "JavaScript"), delayMs);

    public Task EnterLastNameSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.LastName, value, new ControlIntent("Navigation", "LastName"), delayMs);

    public Task EnterStateDetailsDriveOtherCarLastNameSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.StateDetailsDriveOtherCarLastName, value, new ControlIntent("Navigation", "StateDetailsDriveOtherCarLastName"), delayMs);

    public Task EnterLaundrySequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.Laundry, value, new ControlIntent("Navigation", "Laundry"), delayMs);

    public Task EnterLetteringSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.Lettering, value, new ControlIntent("Navigation", "Lettering"), delayMs);

    public Task EnterCommercialAutoLiabilityLimitSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.CommercialAutoLiabilityLimit, value, new ControlIntent("Navigation", "CommercialAutoLiabilityLimit"), delayMs);

    public Task EnterSFP10LiabilityFarmLiabilityLimitSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.CommercialAutoLiabilityLimit, value, new ControlIntent("Navigation", "SFP10LiabilityFarmLiabilityLimit"), delayMs);

    public Task EnterPolicyCovgBaileesPropertyAwayFromYourPremisesLimitSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.PolicyCovgBaileesPropertyAwayFromYourPremisesLimit, value, new ControlIntent("Navigation", "PolicyCovgBaileesPropertyAwayFromYourPremisesLimit"), delayMs);

    public Task EnterEndorsementIF0002WaterborneEquipmentLimitSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.EndorsementIF0002WaterborneEquipmentLimit, value, new ControlIntent("Navigation", "EndorsementIF0002WaterborneEquipmentLimit"), delayMs);

    public Task EnterRiskBaileesCustomersLimitSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.RiskBaileesCustomersLimit, value, new ControlIntent("Navigation", "RiskBaileesCustomersLimit"), delayMs);

    public Task EnterLimitOfInsuranceSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.LimitOfInsurance, value, new ControlIntent("Navigation", "LimitOfInsurance"), delayMs);

    public Task EnterLineConditionerSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.LineConditioner, value, new ControlIntent("Navigation", "LineConditioner"), delayMs);

    public Task EnterListAllPoliciesWithAmericanNationalSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.ListAllPoliciesWithAmericanNational, value, new ControlIntent("Navigation", "ListAllPoliciesWithAmericanNational"), delayMs);

    public Task EnterLoanLeaseGapSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.LoanLeaseGap, value, new ControlIntent("Navigation", "LoanLeaseGap"), delayMs);

    public Task EnterLocationIDSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.LocationID, value, new ControlIntent("Navigation", "LocationID"), delayMs);

    public Task EnterLocationOfCoveredOperationsSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.LocationOfCoveredOperations, value, new ControlIntent("Navigation", "LocationOfCoveredOperations"), delayMs);

    public Task EnterMakeSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.Make, value, new ControlIntent("Navigation", "Make"), delayMs);

    public Task EnterMaritalStatusSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.MaritalStatus, value, new ControlIntent("Navigation", "MaritalStatus"), delayMs);

    public Task EnterMedicalSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.Medical, value, new ControlIntent("Navigation", "Medical"), delayMs);

    public Task EnterMeritRatingSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.MeritRating, value, new ControlIntent("Navigation", "MeritRating"), delayMs);

    public Task EnterMilesFromFireDepartmentSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.MilesFromFireDepartment, value, new ControlIntent("Navigation", "MilesFromFireDepartment"), delayMs);

    public Task EnterMiscItemsBlanketCoverageSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.MiscItemsBlanketCoverage, value, new ControlIntent("Navigation", "MiscItemsBlanketCoverage"), delayMs);

    public Task EnterModelSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.Model, value, new ControlIntent("Navigation", "Model"), delayMs);

    public Task EnterModificationFactorSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.ModificationFactor, value, new ControlIntent("Navigation", "ModificationFactor"), delayMs);

    public Task EnterN10AreThePremisesEquippedWithARecognizedApprovedCentralStationFireAlarmFireExtinguishersOrSmokeAlarmsSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.N10AreThePremisesEquippedWithARecognizedApprovedCentralStationFireAlarmFireExtinguishersOrSmokeAlarms, value, new ControlIntent("Navigation", "N10AreThePremisesEquippedWithARecognizedApprovedCentralStationFireAlarmFireExtinguishersOrSmokeAlarms"), delayMs);

    public Task EnterN10HowAreTheGoodsBeingTransportedProtectedFromDamageAndTheftSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.N10HowAreTheGoodsBeingTransportedProtectedFromDamageAndTheft, value, new ControlIntent("Navigation", "N10HowAreTheGoodsBeingTransportedProtectedFromDamageAndTheft"), delayMs);

    public Task EnterN11AreDriversMVRsAndTripLogsMaintainedSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.N11AreDriversMVRsAndTripLogsMaintained, value, new ControlIntent("Navigation", "N11AreDriversMVRsAndTripLogsMaintained"), delayMs);

    public Task EnterN11WhatIsTheProcedureForTransportingPropertyIncludeTheTransitMethodsUsedAndTheProtectionClassProvidedWhileInTransitSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.N11WhatIsTheProcedureForTransportingPropertyIncludeTheTransitMethodsUsedAndTheProtectionClassProvidedWhileInTransit, value, new ControlIntent("Navigation", "N11WhatIsTheProcedureForTransportingPropertyIncludeTheTransitMethodsUsedAndTheProtectionClassProvidedWhileInTransit"), delayMs);

    public Task EnterN12AreDriversMVRsReviewedOnARegularBasisAndMaintainedSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.N12AreDriversMVRsReviewedOnARegularBasisAndMaintained, value, new ControlIntent("Navigation", "N12AreDriversMVRsReviewedOnARegularBasisAndMaintained"), delayMs);

    public Task EnterN12HowOftenAreTheseLogsReviewedOrUpdatedSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.N12HowOftenAreTheseLogsReviewedOrUpdated, value, new ControlIntent("Navigation", "N12HowOftenAreTheseLogsReviewedOrUpdated"), delayMs);

    public Task EnterN13LiveAnimalInTransitCoverageSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.N13LiveAnimalInTransitCoverage, value, new ControlIntent("Navigation", "N13LiveAnimalInTransitCoverage"), delayMs);

    public Task EnterN13WhatTypesOfVehiclesDoYouOperateAndWhatProtectiveDevicesAreOnEachVehicleSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.N13WhatTypesOfVehiclesDoYouOperateAndWhatProtectiveDevicesAreOnEachVehicle, value, new ControlIntent("Navigation", "N13WhatTypesOfVehiclesDoYouOperateAndWhatProtectiveDevicesAreOnEachVehicle"), delayMs);

    public Task EnterN14LegalLiabilityCoverageSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.N14LegalLiabilityCoverage, value, new ControlIntent("Navigation", "N14LegalLiabilityCoverage"), delayMs);

    public Task EnterN14WhatIsYourProcedureForProtectingSmallItemsFromBreakageOrDisappearanceWhileInStorageSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.N14WhatIsYourProcedureForProtectingSmallItemsFromBreakageOrDisappearanceWhileInStorage, value, new ControlIntent("Navigation", "N14WhatIsYourProcedureForProtectingSmallItemsFromBreakageOrDisappearanceWhileInStorage"), delayMs);

    public Task EnterN15WhatMeasuresDoesTheInsuredTakeToProtectCustomerSPropertyAgainstTheftSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.N15WhatMeasuresDoesTheInsuredTakeToProtectCustomerSPropertyAgainstTheft, value, new ControlIntent("Navigation", "N15WhatMeasuresDoesTheInsuredTakeToProtectCustomerSPropertyAgainstTheft"), delayMs);

    public Task EnterN16DoesTheRiskUseReleaseFormsSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.N16DoesTheRiskUseReleaseForms, value, new ControlIntent("Navigation", "N16DoesTheRiskUseReleaseForms"), delayMs);

    public Task EnterN1WhatAreTheDistancesTheShipmentsWillTravelAndTheTimeRequiredToCompleteTheShipmentSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.N1WhatAreTheDistancesTheShipmentsWillTravelAndTheTimeRequiredToCompleteTheShipment, value, new ControlIntent("Navigation", "N1WhatAreTheDistancesTheShipmentsWillTravelAndTheTimeRequiredToCompleteTheShipment"), delayMs);

    public Task EnterN2IndicateTheAgeTypeOfConstructionAndProtectionClassOfThePremisesSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.N2IndicateTheAgeTypeOfConstructionAndProtectionClassOfThePremises, value, new ControlIntent("Navigation", "N2IndicateTheAgeTypeOfConstructionAndProtectionClassOfThePremises"), delayMs);

    public Task EnterN2WhatAreTheTypesAndAgesOfTheVehiclesTrailersUsedToTransportYourCommoditiesSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.N2WhatAreTheTypesAndAgesOfTheVehiclesTrailersUsedToTransportYourCommodities, value, new ControlIntent("Navigation", "N2WhatAreTheTypesAndAgesOfTheVehiclesTrailersUsedToTransportYourCommodities"), delayMs);

    public Task EnterN2ndClassCategorySequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.N2ndClassCategory, value, new ControlIntent("Navigation", "N2ndClassCategory"), delayMs);

    public Task EnterN2ndClassCodeSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.N2ndClassCode, value, new ControlIntent("Navigation", "N2ndClassCode"), delayMs);

    public Task EnterN3DoesTheApplicantHaulForOthersSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.N3DoesTheApplicantHaulForOthers, value, new ControlIntent("Navigation", "N3DoesTheApplicantHaulForOthers"), delayMs);

    public Task EnterN3WhatIsThePercentageOfAnnualGrossReceiptsDerivedFromServiceOrRepairSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.N3WhatIsThePercentageOfAnnualGrossReceiptsDerivedFromServiceOrRepair, value, new ControlIntent("Navigation", "N3WhatIsThePercentageOfAnnualGrossReceiptsDerivedFromServiceOrRepair"), delayMs);

    public Task EnterN4WhatMethodDoYouUseForKeepingRecordsOfPropertyInYourCareAndHowOftenAreTheRecordsUpdatedSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.N4WhatMethodDoYouUseForKeepingRecordsOfPropertyInYourCareAndHowOftenAreTheRecordsUpdated, value, new ControlIntent("Navigation", "N4WhatMethodDoYouUseForKeepingRecordsOfPropertyInYourCareAndHowOftenAreTheRecordsUpdated"), delayMs);

    public Task EnterN4WhatProtectiveDevicesAreInstalledOnEachVehicleOrTrailerSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.N4WhatProtectiveDevicesAreInstalledOnEachVehicleOrTrailer, value, new ControlIntent("Navigation", "N4WhatProtectiveDevicesAreInstalledOnEachVehicleOrTrailer"), delayMs);

    public Task EnterN5AreRecognizedApprovedCentralStationBurglarAlarmsInstalledAndMaintainedSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.N5AreRecognizedApprovedCentralStationBurglarAlarmsInstalledAndMaintained, value, new ControlIntent("Navigation", "N5AreRecognizedApprovedCentralStationBurglarAlarmsInstalledAndMaintained"), delayMs);

    public Task EnterN5DeductibleSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.N5Deductible, value, new ControlIntent("Navigation", "N5Deductible"), delayMs);

    public Task EnterN5DoAnyVehiclesHaveSpecialEquipmentMountedOrAttachedSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.N5DoAnyVehiclesHaveSpecialEquipmentMountedOrAttached, value, new ControlIntent("Navigation", "N5DoAnyVehiclesHaveSpecialEquipmentMountedOrAttached"), delayMs);

    public Task EnterN6AreAllStorageAreasLockedAtAllTimesWhenUnoccupiedSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.N6AreAllStorageAreasLockedAtAllTimesWhenUnoccupied, value, new ControlIntent("Navigation", "N6AreAllStorageAreasLockedAtAllTimesWhenUnoccupied"), delayMs);

    public Task EnterN6DoesTheApplicantPullDoubleOrTripleTrailersSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.N6DoesTheApplicantPullDoubleOrTripleTrailers, value, new ControlIntent("Navigation", "N6DoesTheApplicantPullDoubleOrTripleTrailers"), delayMs);

    public Task EnterN7AreThereAnyHazardousOrFlammableMaterialsUsedOrStoredOnThePremisesSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.N7AreThereAnyHazardousOrFlammableMaterialsUsedOrStoredOnThePremises, value, new ControlIntent("Navigation", "N7AreThereAnyHazardousOrFlammableMaterialsUsedOrStoredOnThePremises"), delayMs);

    public Task EnterN7DoesTheApplicantLeaveTheTruckWindowsDoorsAndCompartmentsClosedAndLockedWhenUnattendedSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.N7DoesTheApplicantLeaveTheTruckWindowsDoorsAndCompartmentsClosedAndLockedWhenUnattended, value, new ControlIntent("Navigation", "N7DoesTheApplicantLeaveTheTruckWindowsDoorsAndCompartmentsClosedAndLockedWhenUnattended"), delayMs);

    public Task EnterN8DoYouProvideScheduledMaintenanceForTheVehiclesAndTrailersYouOperateSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.N8DoYouProvideScheduledMaintenanceForTheVehiclesAndTrailersYouOperate, value, new ControlIntent("Navigation", "N8DoYouProvideScheduledMaintenanceForTheVehiclesAndTrailersYouOperate"), delayMs);

    public Task EnterN9AreTheEmployeesThatPackLoadAndUnloadTrainedInProperHandlingOfTheCommoditiesSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.N9AreTheEmployeesThatPackLoadAndUnloadTrainedInProperHandlingOfTheCommodities, value, new ControlIntent("Navigation", "N9AreTheEmployeesThatPackLoadAndUnloadTrainedInProperHandlingOfTheCommodities"), delayMs);

    public Task EnterN9AreThePremisesOrAnyPortionOfThePremisesEquippedWithASprinklerSystemSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.N9AreThePremisesOrAnyPortionOfThePremisesEquippedWithASprinklerSystem, value, new ControlIntent("Navigation", "N9AreThePremisesOrAnyPortionOfThePremisesEquippedWithASprinklerSystem"), delayMs);

    public Task EnterNAICSCodeSearchValueSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.NAICSCodeSearchValue, value, new ControlIntent("Navigation", "NAICSCodeSearchValue"), delayMs);

    public Task EnterNameSOrDescriptionSAndDateSOfDesignatedActivitiesOrServicesSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.NameSOrDescriptionSAndDateSOfDesignatedActivitiesOrServices, value, new ControlIntent("Navigation", "NameSOrDescriptionSAndDateSOfDesignatedActivitiesOrServices"), delayMs);

    public Task EnterNamesSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.Names, value, new ControlIntent("Navigation", "Names"), delayMs);

    public Task EnterNonOwnedAutoSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.NonOwnedAuto, value, new ControlIntent("Navigation", "NonOwnedAuto"), delayMs);

    public Task EnterNumberOfEmployeesSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.NumberOfEmployees, value, new ControlIntent("Navigation", "NumberOfEmployees"), delayMs);

    public Task EnterNumberOfFullTimeEmployeesSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.NumberOfFullTimeEmployees, value, new ControlIntent("Navigation", "NumberOfFullTimeEmployees"), delayMs);

    public Task EnterNumberOfPartTimeEmployeesSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.NumberOfPartTimeEmployees, value, new ControlIntent("Navigation", "NumberOfPartTimeEmployees"), delayMs);

    public Task EnterNumberOfVehiclesSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.NumberOfVehicles, value, new ControlIntent("Navigation", "NumberOfVehicles"), delayMs);

    public Task EnterOTCCausesOfLossSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.OTCCausesOfLoss, value, new ControlIntent("Navigation", "OTCCausesOfLoss"), delayMs);

    public Task EnterStateDetailsHiredAutoPDWithoutDriverOTCDeductibleSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.StateDetailsHiredAutoPDWithoutDriverOTCDeductible, value, new ControlIntent("Navigation", "StateDetailsHiredAutoPDWithoutDriverOTCDeductible"), delayMs);

    public Task EnterOccupancyTypeSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.OccupancyType, value, new ControlIntent("Navigation", "OccupancyType"), delayMs);

    public Task EnterOccupiedSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.Occupied, value, new ControlIntent("Navigation", "Occupied"), delayMs);

    public Task EnterOccurenceLimitSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.OccurenceLimit, value, new ControlIntent("Navigation", "OccurenceLimit"), delayMs);

    public Task EnterOfEmployeesSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.OfEmployees, value, new ControlIntent("Navigation", "OfEmployees"), delayMs);

    public Task EnterOfFullTimeEmployeesSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.OfFullTimeEmployees, value, new ControlIntent("Navigation", "OfFullTimeEmployees"), delayMs);

    public Task EnterOfPartTimeEmployeesSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.OfPartTimeEmployees, value, new ControlIntent("Navigation", "OfPartTimeEmployees"), delayMs);

    public Task EnterOfPartnersSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.OfPartners, value, new ControlIntent("Navigation", "OfPartners"), delayMs);

    public Task EnterOfSeasonalTemporaryEmployeesSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.OfSeasonalTemporaryEmployees, value, new ControlIntent("Navigation", "OfSeasonalTemporaryEmployees"), delayMs);

    public Task EnterOfficersSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.Officers, value, new ControlIntent("Navigation", "Officers"), delayMs);

    public Task EnterOfficersPositionHeldSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.OfficersPositionHeld, value, new ControlIntent("Navigation", "OfficersPositionHeld"), delayMs);

    public Task EnterOrderAuditSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.OrderAudit, value, new ControlIntent("Navigation", "OrderAudit"), delayMs);

    public Task EnterOriginalCostNewSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.RiskVehicleInputValueEstimate, value, new ControlIntent("Navigation", "OriginalCostNew"), delayMs);

    public Task EnterOthersSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.Others, value, new ControlIntent("Navigation", "Others"), delayMs);

    public Task EnterPartnersSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.Partners, value, new ControlIntent("Navigation", "Partners"), delayMs);

    public Task EnterPayPlanSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.PayPlan, value, new ControlIntent("Navigation", "PayPlan"), delayMs);

    public Task EnterPerVehicleLimitSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.PerVehicleLimit, value, new ControlIntent("Navigation", "PerVehicleLimit"), delayMs);

    public Task EnterPersAdvInjSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.PersAdvInj, value, new ControlIntent("Navigation", "PersAdvInj"), delayMs);

    public Task EnterPersonalPortableComputersSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.PersonalPortableComputers, value, new ControlIntent("Navigation", "PersonalPortableComputers"), delayMs);

    public Task EnterPersonalPropertyLimitSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.PersonalPropertyLimit, value, new ControlIntent("Navigation", "PersonalPropertyLimit"), delayMs);

    public Task EnterPersonalPropertyRatingGroupSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.RiskInputRatingGroupID, value, new ControlIntent("Navigation", "PersonalPropertyRatingGroup"), delayMs);

    public Task EnterPierOrWharfSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.PierOrWharf, value, new ControlIntent("Navigation", "PierOrWharf"), delayMs);

    public Task EnterPierOrWharfCOLOptionsSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.PierOrWharfCOLOptions, value, new ControlIntent("Navigation", "PierOrWharfCOLOptions"), delayMs);

    public Task EnterPierOrWharfCauseOfLossSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.PierOrWharfCauseOfLoss, value, new ControlIntent("Navigation", "PierOrWharfCauseOfLoss"), delayMs);

    public Task EnterPierOrWharfConstructionSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.PierOrWharfConstruction, value, new ControlIntent("Navigation", "PierOrWharfConstruction"), delayMs);

    public Task EnterPleaseProvideWebsiteAddressEsSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.PleaseProvideWebsiteAddressEs, value, new ControlIntent("Navigation", "PleaseProvideWebsiteAddressEs"), delayMs);

    public Task EnterPolicyHolderNameSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.PolicyHolderName, value, new ControlIntent("Navigation", "PolicyHolderName"), delayMs);

    public Task EnterCommercialAutoPolicyNumberSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.BusinessownersPolicyNumber, value, new ControlIntent("Navigation", "CommercialAutoPolicyNumber"), delayMs);

    public Task EnterBusinessownersPolicyNumberSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.BusinessownersPolicyNumber, value, new ControlIntent("Navigation", "BusinessownersPolicyNumber"), delayMs);

    public Task EnterGeneralLiabilityPolicyNumberSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.BusinessownersPolicyNumber, value, new ControlIntent("Navigation", "GeneralLiabilityPolicyNumber"), delayMs);

    public Task EnterPolicyTypeSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.PolicyType, value, new ControlIntent("Navigation", "PolicyType"), delayMs);

    public Task EnterPowerSuppressorVoltageRegulatorSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.PowerSuppressorVoltageRegulator, value, new ControlIntent("Navigation", "PowerSuppressorVoltageRegulator"), delayMs);

    public Task EnterPremOpDedSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.PremOpDed, value, new ControlIntent("Navigation", "PremOpDed"), delayMs);

    public Task EnterPremOpPDDedSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.PremOpPDDed, value, new ControlIntent("Navigation", "PremOpPDDed"), delayMs);

    public Task EnterPremisesTypeSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.PremisesType, value, new ControlIntent("Navigation", "PremisesType"), delayMs);

    public Task EnterPrimaryRatingStateSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.PrimaryRatingState, value, new ControlIntent("Navigation", "PrimaryRatingState"), delayMs);

    public Task EnterProdBIDedSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.ProdBIDed, value, new ControlIntent("Navigation", "ProdBIDed"), delayMs);

    public Task EnterProdPDDedSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.ProdPDDed, value, new ControlIntent("Navigation", "ProdPDDed"), delayMs);

    public Task EnterProduceCarriedSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.ProduceCarried, value, new ControlIntent("Navigation", "ProduceCarried"), delayMs);

    public Task EnterProductsAggLimitSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.ProductsAggLimit, value, new ControlIntent("Navigation", "ProductsAggLimit"), delayMs);

    public Task EnterProductsCompletedOperationsAggregateLimitSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.ProductsCompletedOperationsAggregateLimit, value, new ControlIntent("Navigation", "ProductsCompletedOperationsAggregateLimit"), delayMs);

    public Task EnterPolicyCovgComputerSystemsPropertyInTransitSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.PolicyCovgComputerSystemsPropertyInTransit, value, new ControlIntent("Navigation", "PolicyCovgComputerSystemsPropertyInTransit"), delayMs);

    public Task EnterPolicyCovgBaileesCutomersPropertyInTransitSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.PolicyCovgBaileesCutomersPropertyInTransit, value, new ControlIntent("Navigation", "PolicyCovgBaileesCutomersPropertyInTransit"), delayMs);

    public Task EnterPropertyOfOthersLimitSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.PropertyOfOthersLimit, value, new ControlIntent("Navigation", "PropertyOfOthersLimit"), delayMs);

    public Task EnterPropertyOfOthersRatingGroupSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.RiskInputRatingGroupID, value, new ControlIntent("Navigation", "PropertyOfOthersRatingGroup"), delayMs);

    public Task EnterProvideAListOfSurroundingExposureOtherOccupanciesWithin100FtIncludingNorthEastSouthAndWestSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.ProvideAListOfSurroundingExposureOtherOccupanciesWithin100FtIncludingNorthEastSouthAndWest, value, new ControlIntent("Navigation", "ProvideAListOfSurroundingExposureOtherOccupanciesWithin100FtIncludingNorthEastSouthAndWest"), delayMs);

    public Task EnterProvideInformationRegardingAntivirusMethodsAndCopyrightProtectionOfDataAndMediaSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.ProvideInformationRegardingAntivirusMethodsAndCopyrightProtectionOfDataAndMedia, value, new ControlIntent("Navigation", "ProvideInformationRegardingAntivirusMethodsAndCopyrightProtectionOfDataAndMedia"), delayMs);

    public Task EnterRentalReimbursementSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.RentalReimbursement, value, new ControlIntent("Navigation", "RentalReimbursement"), delayMs);

    public Task EnterRentedEquipmentExpenseSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.RentedEquipmentExpense, value, new ControlIntent("Navigation", "RentedEquipmentExpense"), delayMs);

    public Task EnterRequestedUmbrellaLimitSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.RequestedUmbrellaLimit, value, new ControlIntent("Navigation", "RequestedUmbrellaLimit"), delayMs);

    public Task EnterRiskTypeSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.RiskType, value, new ControlIntent("Navigation", "RiskType"), delayMs);

    public Task EnterRoofTypeSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.RoofType, value, new ControlIntent("Navigation", "RoofType"), delayMs);

    public Task EnterScheduledCoverageSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.ScheduledCoverage, value, new ControlIntent("Navigation", "ScheduledCoverage"), delayMs);

    public Task EnterRiskComputerSystemsSearchResultSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.RiskComputerSystemsSearchResult, value, new ControlIntent("Navigation", "RiskComputerSystemsSearchResult"), delayMs);

    public Task EnterRiskBaileesCustomersSearchResultSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.RiskBaileesCustomersSearchResult, value, new ControlIntent("Navigation", "RiskBaileesCustomersSearchResult"), delayMs);

    public Task EnterRiskAccountsReceivableSearchResultSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.RiskAccountsReceivableSearchResult, value, new ControlIntent("Navigation", "RiskAccountsReceivableSearchResult"), delayMs);

    public Task EnterSearchResultsSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.SearchResults, value, new ControlIntent("Navigation", "SearchResults"), delayMs);

    public Task EnterSearchValueSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.SearchValue, value, new ControlIntent("Navigation", "SearchValue"), delayMs);

    public Task EnterPropertyAddClassSearchValueSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.PropertyAddClassSearchValue, value, new ControlIntent("Navigation", "PropertyAddClassSearchValue"), delayMs);

    public Task EnterRiskAccountsReceivableSearchValueSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.RiskAccountsReceivableSearchValue, value, new ControlIntent("Navigation", "RiskAccountsReceivableSearchValue"), delayMs);

    public Task EnterRiskComputerSystemsSearchValueSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.RiskComputerSystemsSearchValue, value, new ControlIntent("Navigation", "RiskComputerSystemsSearchValue"), delayMs);

    public Task EnterRiskBaileesCustomersSearchValueSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.RiskBaileesCustomersSearchValue, value, new ControlIntent("Navigation", "RiskBaileesCustomersSearchValue"), delayMs);

    public Task EnterSeasonalProduceTrailersSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.SeasonalProduceTrailers, value, new ControlIntent("Navigation", "SeasonalProduceTrailers"), delayMs);

    public Task EnterSelectAppropriateCodeSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.SelectAppropriateCode, value, new ControlIntent("Navigation", "SelectAppropriateCode"), delayMs);

    public Task EnterSelectClassCodeSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.SelectClassCode, value, new ControlIntent("Navigation", "SelectClassCode"), delayMs);

    public Task EnterSelectEndorsementSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.SelectEndorsement, value, new ControlIntent("Navigation", "SelectEndorsement"), delayMs);

    public Task EnterSexSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.Sex, value, new ControlIntent("Navigation", "Sex"), delayMs);

    public Task EnterSignLocationSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.SignLocation, value, new ControlIntent("Navigation", "SignLocation"), delayMs);

    public Task EnterSmallDeductibleSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.SmallDeductible, value, new ControlIntent("Navigation", "SmallDeductible"), delayMs);

    public Task EnterSoleProprietorsSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.SoleProprietors, value, new ControlIntent("Navigation", "SoleProprietors"), delayMs);

    public Task EnterSplitPDDedSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.SplitPDDed, value, new ControlIntent("Navigation", "SplitPDDed"), delayMs);

    public Task EnterSquareFeetSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.SquareFeet, value, new ControlIntent("Navigation", "SquareFeet"), delayMs);

    public Task EnterPolicyHolderStateSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.PolicyHolderState, value, new ControlIntent("Navigation", "PolicyHolderState"), delayMs);

    public Task EnterEndorsementsDesignatedWorkplacesExclusionStateSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.EndorsementsDesignatedWorkplacesExclusionState, value, new ControlIntent("Navigation", "EndorsementsDesignatedWorkplacesExclusionState"), delayMs);

    public Task EnterStateLicensedSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.StateLicensed, value, new ControlIntent("Navigation", "StateLicensed"), delayMs);

    public Task EnterStateOrPoliticalSubdivisionSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.StateOrPoliticalSubdivision, value, new ControlIntent("Navigation", "StateOrPoliticalSubdivision"), delayMs);

    public Task EnterStatedAmountSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.RiskVehicleInputValueEstimate, value, new ControlIntent("Navigation", "StatedAmount"), delayMs);

    public Task EnterStorageLimitSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.StorageLimit, value, new ControlIntent("Navigation", "StorageLimit"), delayMs);

    public Task EnterStoriesSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.Stories, value, new ControlIntent("Navigation", "Stories"), delayMs);

    public Task EnterTapesCoverageSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.TapesCoverage, value, new ControlIntent("Navigation", "TapesCoverage"), delayMs);

    public Task EnterTextBoxSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.TextBox, value, new ControlIntent("Navigation", "TextBox"), delayMs);

    public Task EnterTitleSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.Title, value, new ControlIntent("Navigation", "Title"), delayMs);

    public Task EnterToolsAndClothingBelongingToYourEmployeesSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.ToolsAndClothingBelongingToYourEmployees, value, new ControlIntent("Navigation", "ToolsAndClothingBelongingToYourEmployees"), delayMs);

    public Task EnterTotalCostOfWorkSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.TotalCostOfWork, value, new ControlIntent("Navigation", "TotalCostOfWork"), delayMs);

    public Task EnterTotalPayrollEstimatedSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.TotalPayrollEstimated, value, new ControlIntent("Navigation", "TotalPayrollEstimated"), delayMs);

    public Task EnterTotalPremiumSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.TotalPremium, value, new ControlIntent("Navigation", "TotalPremium"), delayMs);

    public Task EnterGeneralLiabilityTotalSubjectPremiumSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.BusinessownersTotalSubjectPremium, value, new ControlIntent("Navigation", "GeneralLiabilityTotalSubjectPremium"), delayMs);

    public Task EnterBusinessownersTotalSubjectPremiumSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.BusinessownersTotalSubjectPremium, value, new ControlIntent("Navigation", "BusinessownersTotalSubjectPremium"), delayMs);

    public Task EnterTowingSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.Towing, value, new ControlIntent("Navigation", "Towing"), delayMs);

    public Task EnterTrailerInterchangeCollisionDeductibleSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.TrailerInterchangeCollisionDeductible, value, new ControlIntent("Navigation", "TrailerInterchangeCollisionDeductible"), delayMs);

    public Task EnterTrailerInterchangeCompDeductibleSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.TrailerInterchangeCompDeductible, value, new ControlIntent("Navigation", "TrailerInterchangeCompDeductible"), delayMs);

    public Task EnterTrailerInterchangeEnterDaysInsuredSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.TrailerInterchangeEnterDaysInsured, value, new ControlIntent("Navigation", "TrailerInterchangeEnterDaysInsured"), delayMs);

    public Task EnterTrailerInterchangeEnterOfTrailersSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.TrailerInterchangeEnterOfTrailers, value, new ControlIntent("Navigation", "TrailerInterchangeEnterOfTrailers"), delayMs);

    public Task EnterFG0013AutomaticAdditionalInsuredSpecificRelationshipTypeSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.FG0013AutomaticAdditionalInsuredSpecificRelationshipType, value, new ControlIntent("Navigation", "FG0013AutomaticAdditionalInsuredSpecificRelationshipType"), delayMs);

    public Task EnterEndorsementMainTypeSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.EndorsementMainType, value, new ControlIntent("Navigation", "EndorsementMainType"), delayMs);

    public Task EnterGLOCPRiskTypeSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.GLOCPRiskType, value, new ControlIntent("Navigation", "GLOCPRiskType"), delayMs);

    public Task EnterCG2007AddLInsuredEngineersArchitectsTypeSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.CG2007AddLInsuredEngineersArchitectsType, value, new ControlIntent("Navigation", "CG2007AddLInsuredEngineersArchitectsType"), delayMs);

    public Task EnterRiskSignsTypeSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.RiskSignsType, value, new ControlIntent("Navigation", "RiskSignsType"), delayMs);

    public Task EnterTypeOfContractorSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.TypeOfContractor, value, new ControlIntent("Navigation", "TypeOfContractor"), delayMs);

    public Task EnterTypeOfEquipmentSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.TypeOfEquipment, value, new ControlIntent("Navigation", "TypeOfEquipment"), delayMs);

    public Task EnterTypeOfInterestSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.TypeOfInterest, value, new ControlIntent("Navigation", "TypeOfInterest"), delayMs);

    public Task EnterTypeOfLicenseSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.TypeOfLicense, value, new ControlIntent("Navigation", "TypeOfLicense"), delayMs);

    public Task EnterUMBILimitSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.UMBILimit, value, new ControlIntent("Navigation", "UMBILimit"), delayMs);

    public Task EnterUMTypeDefaultSelectionsSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.UMTypeDefaultSelections, value, new ControlIntent("Navigation", "UMTypeDefaultSelections"), delayMs);

    public Task EnterUmbrellaLimitSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.UmbrellaLimit, value, new ControlIntent("Navigation", "UmbrellaLimit"), delayMs);

    public Task EnterUninterruptiblePowerSourceSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.UninterruptiblePowerSource, value, new ControlIntent("Navigation", "UninterruptiblePowerSource"), delayMs);

    public Task EnterUnnamedPremisesSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.UnnamedPremises, value, new ControlIntent("Navigation", "UnnamedPremises"), delayMs);

    public Task EnterUnnamedTerminalsLimitSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.UnnamedTerminalsLimit, value, new ControlIntent("Navigation", "UnnamedTerminalsLimit"), delayMs);

    public Task EnterUsedAsShowroomSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.UsedAsShowroom, value, new ControlIntent("Navigation", "UsedAsShowroom"), delayMs);

    public Task EnterVINSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.VIN, value, new ControlIntent("Navigation", "VIN"), delayMs);

    public Task EnterVacancyPermitSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.VacancyPermit, value, new ControlIntent("Navigation", "VacancyPermit"), delayMs);

    public Task EnterVacantBuildingSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.VacantBuilding, value, new ControlIntent("Navigation", "VacantBuilding"), delayMs);

    public Task EnterValuationSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.Valuation, value, new ControlIntent("Navigation", "Valuation"), delayMs);

    public Task EnterValuationTypeSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.ValuationType, value, new ControlIntent("Navigation", "ValuationType"), delayMs);

    public Task EnterValueBasisSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.ValueBasis, value, new ControlIntent("Navigation", "ValueBasis"), delayMs);

    public Task EnterVehicleInformationSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.VehicleInformation, value, new ControlIntent("Navigation", "VehicleInformation"), delayMs);

    public Task EnterVehicleTypeSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.VehicleType, value, new ControlIntent("Navigation", "VehicleType"), delayMs);

    public Task EnterVirusHarmfulCodeOrSimilarInstructionSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.VirusHarmfulCodeOrSimilarInstruction, value, new ControlIntent("Navigation", "VirusHarmfulCodeOrSimilarInstruction"), delayMs);

    public Task EnterWaiverOfSubrogationSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.WaiverOfSubrogation, value, new ControlIntent("Navigation", "WaiverOfSubrogation"), delayMs);

    public Task EnterWaiverOfSubrogationExposureSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.WaiverOfSubrogationExposure, value, new ControlIntent("Navigation", "WaiverOfSubrogationExposure"), delayMs);

    public Task EnterWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, value, new ControlIntent("Navigation", "WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days"), delayMs);

    public Task EnterWhatAreTheProceduresAndMethodsForKeepingTheEDPAreasSecuredSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.WhatAreTheProceduresAndMethodsForKeepingTheEDPAreasSecured, value, new ControlIntent("Navigation", "WhatAreTheProceduresAndMethodsForKeepingTheEDPAreasSecured"), delayMs);

    public Task EnterWhatAreTheProceduresAndScheduleForBackingUpTheMediaAndDataAndTheirStorageSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.WhatAreTheProceduresAndScheduleForBackingUpTheMediaAndDataAndTheirStorage, value, new ControlIntent("Navigation", "WhatAreTheProceduresAndScheduleForBackingUpTheMediaAndDataAndTheirStorage"), delayMs);

    public Task EnterWhatIsTheConstructionOfEachSignSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.WhatIsTheConstructionOfEachSign, value, new ControlIntent("Navigation", "WhatIsTheConstructionOfEachSign"), delayMs);

    public Task EnterWhatIsTheConstructionOfThePremisesWhereTheReceivablesAreStoredSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.WhatIsTheConstructionOfThePremisesWhereTheReceivablesAreStored, value, new ControlIntent("Navigation", "WhatIsTheConstructionOfThePremisesWhereTheReceivablesAreStored"), delayMs);

    public Task EnterWhatIsTheDistanceInFeetToTheNearestFireHydrantSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.WhatIsTheDistanceInFeetToTheNearestFireHydrant, value, new ControlIntent("Navigation", "WhatIsTheDistanceInFeetToTheNearestFireHydrant"), delayMs);

    public Task EnterWhatIsTheDistanceInMilesToTheNearestRespondingFireDepartmentSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.WhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment, value, new ControlIntent("Navigation", "WhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment"), delayMs);

    public Task EnterWhatIsTheProcedureForTransportingTheComputerEquipmentSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.WhatIsTheProcedureForTransportingTheComputerEquipment, value, new ControlIntent("Navigation", "WhatIsTheProcedureForTransportingTheComputerEquipment"), delayMs);

    public Task EnterWhatIsThePublicProtectionClassRatingSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.WhatIsThePublicProtectionClassRating, value, new ControlIntent("Navigation", "WhatIsThePublicProtectionClassRating"), delayMs);

    public Task EnterWhatSafeguardsAreInPlaceForReceivablesToProtectAgainstDamageOrTheftSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.WhatSafeguardsAreInPlaceForReceivablesToProtectAgainstDamageOrTheft, value, new ControlIntent("Navigation", "WhatSafeguardsAreInPlaceForReceivablesToProtectAgainstDamageOrTheft"), delayMs);

    public Task EnterWhichFormAreYouCompletingSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.WhichFormAreYouCompleting, value, new ControlIntent("Navigation", "WhichFormAreYouCompleting"), delayMs);

    public Task EnterWhyIsThisCoverageDesiredSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.WhyIsThisCoverageDesired, value, new ControlIntent("Navigation", "WhyIsThisCoverageDesired"), delayMs);

    public Task EnterYearSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.Year, value, new ControlIntent("Navigation", "Year"), delayMs);

    public Task EnterYearBuiltSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.YearBuilt, value, new ControlIntent("Navigation", "YearBuilt"), delayMs);

    public Task EnterYearLicensedSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.YearLicensed, value, new ControlIntent("Navigation", "YearLicensed"), delayMs);

    public Task EnterYearsInBusinessSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.YearsInBusiness, value, new ControlIntent("Navigation", "YearsInBusiness"), delayMs);

    public Task EnterLocationZipCodeSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.LocationZipCode, value, new ControlIntent("Navigation", "LocationZipCode"), delayMs);

    public Task EnterThirdPartyDesigneeZipCodeSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.ThirdPartyDesigneeZipCode, value, new ControlIntent("Navigation", "ThirdPartyDesigneeZipCode"), delayMs);

    public Task EnterGLOCPRiskZipCodeSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.GLOCPRiskZipCode, value, new ControlIntent("Navigation", "GLOCPRiskZipCode"), delayMs);

    public Task EnterAdditionalOtherInterestInputLastNameSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.AdditionalOtherInterestInputLastName, value, new ControlIntent("Navigation", "AdditionalOtherInterestInputLastName"), delayMs);

    public Task EnterEntityInfoFrameEntityInfoWindowFaxSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.EntityInfoFrameEntityInfoWindowFax, value, new ControlIntent("Navigation", "EntityInfoFrameEntityInfoWindowFax"), delayMs);

    public Task EnterEntityInfoFrameEntityInfoWindowBureauNumberSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.EntityInfoFrameEntityInfoWindowBureauNumber, value, new ControlIntent("Navigation", "EntityInfoFrameEntityInfoWindowBureauNumber"), delayMs);

    public Task EnterEntityInfoFrameEntityInfoWindowStateUnemploymentNumberDefaultSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.EntityInfoFrameEntityInfoWindowStateUnemploymentNumberDefault, value, new ControlIntent("Navigation", "EntityInfoFrameEntityInfoWindowStateUnemploymentNumberDefault"), delayMs);
}
