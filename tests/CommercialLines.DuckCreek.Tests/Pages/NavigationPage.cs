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
        _ui.WaitAsync(_locators.AccountsReceivableHeading, expected, new ControlIntent("Navigation", "AccountsReceivableHeading"));

    public Task ClickAccountsReceivableUWQuestionsAsync() =>
        _ui.ClickAsync(_locators.AccountsReceivableUWQuestions, new ControlIntent("Navigation", "AccountsReceivableUWQuestions"));

    public Task ClickAddAsync() =>
        _ui.ClickAsync(_locators.Add, new ControlIntent("Navigation", "Add"));

    public Task ClickAddAddlInterestAsync() =>
        _ui.ClickAsync(_locators.AddAddlInterest, new ControlIntent("Navigation", "AddAddlInterest"));

    public Task ClickAddBuildingAsync() =>
        _ui.ClickAsync(_locators.AddBuilding, new ControlIntent("Navigation", "AddBuilding"));

    public Task ClickAddClassB04B6Async() =>
        _ui.ClickAsync(_locators.AddClassB04B6, new ControlIntent("Navigation", "AddClassB04B6"));

    public Task WaitForAddClassCodeAsync(string expected) =>
        _ui.WaitAsync(_locators.AddClassCode, expected, new ControlIntent("Navigation", "AddClassCode"));

    public Task ClickAddClassCodeAsync() =>
        _ui.ClickAsync(_locators.AddClassCode, new ControlIntent("Navigation", "AddClassCode"));

    public Task ClickAddClassDCD8FAsync() =>
        _ui.ClickAsync(_locators.AddClassDCD8F, new ControlIntent("Navigation", "AddClassDCD8F"));

    public Task ClickAddClassOKAsync() =>
        _ui.ClickAsync(_locators.AddClassOK, new ControlIntent("Navigation", "AddClassOK"));

    public Task ClickAddCoverageFormAsync() =>
        _ui.ClickAsync(_locators.AddCoverageForm, new ControlIntent("Navigation", "AddCoverageForm"));

    public Task ClickAddDriverAsync() =>
        _ui.ClickAsync(_locators.AddDriver, new ControlIntent("Navigation", "AddDriver"));

    public Task EnterAddDriverNameAsync(string value) =>
        _ui.FillAsync(_locators.AddDriverName, value, new ControlIntent("Navigation", "AddDriverName"));

    public Task PressAddDriverNameAsync(string key) =>
        _ui.PressAsync(_locators.AddDriverName, key, new ControlIntent("Navigation", "AddDriverName"));

    public Task ClickAddEndorsement04BD0Async() =>
        _ui.ClickAsync(_locators.AddEndorsement04BD0, new ControlIntent("Navigation", "AddEndorsement04BD0"));

    public Task ClickAddEndorsement34EE3Async() =>
        _ui.ClickAsync(_locators.AddEndorsement34EE3, new ControlIntent("Navigation", "AddEndorsement34EE3"));

    public Task WaitForAddEndorsement44E6AAsync(string expected) =>
        _ui.WaitAsync(_locators.AddEndorsement44E6A, expected, new ControlIntent("Navigation", "AddEndorsement44E6A"));

    public Task ClickAddEndorsement44E6AAsync() =>
        _ui.ClickAsync(_locators.AddEndorsement44E6A, new ControlIntent("Navigation", "AddEndorsement44E6A"));

    public Task ClickAddEndorsement48A9EAsync() =>
        _ui.ClickAsync(_locators.AddEndorsement48A9E, new ControlIntent("Navigation", "AddEndorsement48A9E"));

    public Task WaitForAddEndorsement9E5F4Async(string expected) =>
        _ui.WaitAsync(_locators.AddEndorsement9E5F4, expected, new ControlIntent("Navigation", "AddEndorsement9E5F4"));

    public Task ClickAddEndorsement9E5F4Async() =>
        _ui.ClickAsync(_locators.AddEndorsement9E5F4, new ControlIntent("Navigation", "AddEndorsement9E5F4"));

    public Task ClickAddEndorsementA9973Async() =>
        _ui.ClickAsync(_locators.AddEndorsementA9973, new ControlIntent("Navigation", "AddEndorsementA9973"));

    public Task WaitForAddEndorsementB6452Async(string expected) =>
        _ui.WaitAsync(_locators.AddEndorsementB6452, expected, new ControlIntent("Navigation", "AddEndorsementB6452"));

    public Task WaitForAddEndorsementCE8DDAsync(string expected) =>
        _ui.WaitAsync(_locators.AddEndorsementCE8DD, expected, new ControlIntent("Navigation", "AddEndorsementCE8DD"));

    public Task ClickAddEndorsementCE8DDAsync() =>
        _ui.ClickAsync(_locators.AddEndorsementCE8DD, new ControlIntent("Navigation", "AddEndorsementCE8DD"));

    public Task ClickAddEndorsementD15B0Async() =>
        _ui.ClickAsync(_locators.AddEndorsementD15B0, new ControlIntent("Navigation", "AddEndorsementD15B0"));

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
        _ui.ClickAsync(_locators.AdditionalInterests, new ControlIntent("Navigation", "AdditionalInterests"));

    public Task EnterAdditionalOtherInterestInputAddress1Async(string value) =>
        _ui.FillAsync(_locators.AdditionalOtherInterestInputAddress1, value, new ControlIntent("Navigation", "AdditionalOtherInterestInputAddress1"));

    public Task PressAdditionalOtherInterestInputAddress1Async(string key) =>
        _ui.PressAsync(_locators.AdditionalOtherInterestInputAddress1, key, new ControlIntent("Navigation", "AdditionalOtherInterestInputAddress1"));

    public Task WaitForAdditionalOtherInterestInputFirstNameAsync(string expected) =>
        _ui.WaitAsync(_locators.AdditionalOtherInterestInputFirstName, expected, new ControlIntent("Navigation", "AdditionalOtherInterestInputFirstName"));

    public Task EnterAdditionalOtherInterestInputFirstNameAsync(string value) =>
        _ui.FillAsync(_locators.AdditionalOtherInterestInputFirstName, value, new ControlIntent("Navigation", "AdditionalOtherInterestInputFirstName"));

    public Task PressAdditionalOtherInterestInputFirstNameAsync(string key) =>
        _ui.PressAsync(_locators.AdditionalOtherInterestInputFirstName, key, new ControlIntent("Navigation", "AdditionalOtherInterestInputFirstName"));

    public Task WaitForAdditionalOtherInterestInputLastNameAsync(string expected) =>
        _ui.WaitAsync(_locators.AdditionalOtherInterestInputLastName, expected, new ControlIntent("Navigation", "AdditionalOtherInterestInputLastName"));

    public Task WaitForAddlInterests15174Async(string expected) =>
        _ui.WaitAsync(_locators.AddlInterests15174, expected, new ControlIntent("Navigation", "AddlInterests15174"));

    public Task VerifyAddlInterests15174Async(string expected, string property) =>
        _ui.VerifyAsync(_locators.AddlInterests15174, expected, property, new ControlIntent("Navigation", "AddlInterests15174"));

    public Task WaitForAddlInterestsA10A4Async(string expected) =>
        _ui.WaitAsync(_locators.AddlInterestsA10A4, expected, new ControlIntent("Navigation", "AddlInterestsA10A4"));

    public Task ClickAddlInterestsE39FCAsync() =>
        _ui.ClickAsync(_locators.AddlInterestsE39FC, new ControlIntent("Navigation", "AddlInterestsE39FC"));

    public Task EnterAddressAsync(string value) =>
        _ui.FillAsync(_locators.Address, value, new ControlIntent("Navigation", "Address"));

    public Task PressAddressAsync(string key) =>
        _ui.PressAsync(_locators.Address, key, new ControlIntent("Navigation", "Address"));

    public Task EnterAddress193FF8Async(string value) =>
        _ui.FillAsync(_locators.Address193FF8, value, new ControlIntent("Navigation", "Address193FF8"));

    public Task PressAddress193FF8Async(string key) =>
        _ui.PressAsync(_locators.Address193FF8, key, new ControlIntent("Navigation", "Address193FF8"));

    public Task EnterAddress19B8B5Async(string value) =>
        _ui.FillAsync(_locators.Address19B8B5, value, new ControlIntent("Navigation", "Address19B8B5"));

    public Task PressAddress19B8B5Async(string key) =>
        _ui.PressAsync(_locators.Address19B8B5, key, new ControlIntent("Navigation", "Address19B8B5"));

    public Task EnterAddress1BE797Async(string value) =>
        _ui.FillAsync(_locators.Address1BE797, value, new ControlIntent("Navigation", "Address1BE797"));

    public Task PressAddress1BE797Async(string key) =>
        _ui.PressAsync(_locators.Address1BE797, key, new ControlIntent("Navigation", "Address1BE797"));

    public Task WaitForAddress1C0AF1Async(string expected) =>
        _ui.WaitAsync(_locators.Address1C0AF1, expected, new ControlIntent("Navigation", "Address1C0AF1"));

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

    public Task WaitForBaileesCustomerHeadingAsync(string expected) =>
        _ui.WaitAsync(_locators.BaileesCustomerHeading, expected, new ControlIntent("Navigation", "BaileesCustomerHeading"));

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

    public Task ClickBilling6ED79Async() =>
        _ui.ClickAsync(_locators.Billing6ED79, new ControlIntent("Navigation", "Billing6ED79"));

    public Task WaitForBillingD1518Async(string expected) =>
        _ui.WaitAsync(_locators.BillingD1518, expected, new ControlIntent("Navigation", "BillingD1518"));

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

    public Task WaitForBuilding8205FAsync(string expected) =>
        _ui.WaitAsync(_locators.Building8205F, expected, new ControlIntent("Navigation", "Building8205F"));

    public Task ClickBuilding87910Async() =>
        _ui.ClickAsync(_locators.Building87910, new ControlIntent("Navigation", "Building87910"));

    public Task ClickBuildingDetailOKAsync() =>
        _ui.ClickAsync(_locators.BuildingDetailOK, new ControlIntent("Navigation", "BuildingDetailOK"));

    public Task EnterBuildingLimitAsync(string value) =>
        _ui.FillAsync(_locators.BuildingLimit, value, new ControlIntent("Navigation", "BuildingLimit"));

    public Task PressBuildingLimitAsync(string key) =>
        _ui.PressAsync(_locators.BuildingLimit, key, new ControlIntent("Navigation", "BuildingLimit"));

    public Task EnterBuildingRatingGroupAsync(string value) =>
        _ui.FillAsync(_locators.BuildingRatingGroup, value, new ControlIntent("Navigation", "BuildingRatingGroup"));

    public Task PressBuildingRatingGroupAsync(string key) =>
        _ui.PressAsync(_locators.BuildingRatingGroup, key, new ControlIntent("Navigation", "BuildingRatingGroup"));

    public Task EnterBusinessInterruptionDescriptionOfScheduledPropertyAsync(string value) =>
        _ui.FillAsync(_locators.BusinessInterruptionDescriptionOfScheduledProperty, value, new ControlIntent("Navigation", "BusinessInterruptionDescriptionOfScheduledProperty"));

    public Task PressBusinessInterruptionDescriptionOfScheduledPropertyAsync(string key) =>
        _ui.PressAsync(_locators.BusinessInterruptionDescriptionOfScheduledProperty, key, new ControlIntent("Navigation", "BusinessInterruptionDescriptionOfScheduledProperty"));

    public Task WaitForBusinessInterruptionDetailAsync(string expected) =>
        _ui.WaitAsync(_locators.BusinessInterruptionDetail, expected, new ControlIntent("Navigation", "BusinessInterruptionDetail"));

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

    public Task ClickBusinessInterruptionOKAsync() =>
        _ui.ClickAsync(_locators.BusinessInterruptionOK, new ControlIntent("Navigation", "BusinessInterruptionOK"));

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

    public Task ClickCG0424CoverageForInjuryToLeasedWorkersOKAsync() =>
        _ui.ClickAsync(_locators.CG0424CoverageForInjuryToLeasedWorkersOK, new ControlIntent("Navigation", "CG0424CoverageForInjuryToLeasedWorkersOK"));

    public Task ClickCG0435EmployeeBenefitsLiabilityOKAsync() =>
        _ui.ClickAsync(_locators.CG0435EmployeeBenefitsLiabilityOK, new ControlIntent("Navigation", "CG0435EmployeeBenefitsLiabilityOK"));

    public Task ClickCG2007AddLInsuredEngineersArchitectsOKAsync() =>
        _ui.ClickAsync(_locators.CG2007AddLInsuredEngineersArchitectsOK, new ControlIntent("Navigation", "CG2007AddLInsuredEngineersArchitectsOK"));

    public Task ClickCG2020AddLInsuredCharitableInstitutionOKAsync() =>
        _ui.ClickAsync(_locators.CG2020AddLInsuredCharitableInstitutionOK, new ControlIntent("Navigation", "CG2020AddLInsuredCharitableInstitutionOK"));

    public Task ClickCG2142ExclusionExplosionCollapseAndUndergroundPropertyDamageHazardSpecifiedOperationsOKAsync() =>
        _ui.ClickAsync(_locators.CG2142ExclusionExplosionCollapseAndUndergroundPropertyDamageHazardSpecifiedOperationsOK, new ControlIntent("Navigation", "CG2142ExclusionExplosionCollapseAndUndergroundPropertyDamageHazardSpecifiedOperationsOK"));

    public Task ClickCG2149TotalPollutionExclusionEndorsementOKAsync() =>
        _ui.ClickAsync(_locators.CG2149TotalPollutionExclusionEndorsementOK, new ControlIntent("Navigation", "CG2149TotalPollutionExclusionEndorsementOK"));

    public Task ClickCG2401NonBindingArbitrationOKAsync() =>
        _ui.ClickAsync(_locators.CG2401NonBindingArbitrationOK, new ControlIntent("Navigation", "CG2401NonBindingArbitrationOK"));

    public Task ClickCG2812PesticideOrHerbicideApplicatorCoverageOKAsync() =>
        _ui.ClickAsync(_locators.CG2812PesticideOrHerbicideApplicatorCoverageOK, new ControlIntent("Navigation", "CG2812PesticideOrHerbicideApplicatorCoverageOK"));

    public Task ClickCG2935AddLInsuredStateOrPoliticalPermitsOKAsync() =>
        _ui.ClickAsync(_locators.CG2935AddLInsuredStateOrPoliticalPermitsOK, new ControlIntent("Navigation", "CG2935AddLInsuredStateOrPoliticalPermitsOK"));

    public Task ClickCGL08901Async() =>
        _ui.ClickAsync(_locators.CGL08901, new ControlIntent("Navigation", "CGL08901"));

    public Task WaitForCGLBA8E8Async(string expected) =>
        _ui.WaitAsync(_locators.CGLBA8E8, expected, new ControlIntent("Navigation", "CGLBA8E8"));

    public Task EnterCGLLimitsAsync(string value) =>
        _ui.FillAsync(_locators.CGLLimits, value, new ControlIntent("Navigation", "CGLLimits"));

    public Task PressCGLLimitsAsync(string key) =>
        _ui.PressAsync(_locators.CGLLimits, key, new ControlIntent("Navigation", "CGLLimits"));

    public Task WaitForCPPLiabilityAsync(string expected) =>
        _ui.WaitAsync(_locators.CPPLiability, expected, new ControlIntent("Navigation", "CPPLiability"));

    public Task PressCPPLiabilityAsync(string key) =>
        _ui.PressAsync(_locators.CPPLiability, key, new ControlIntent("Navigation", "CPPLiability"));

    public Task ClickCPPLiabilityAsync() =>
        _ui.ClickAsync(_locators.CPPLiability, new ControlIntent("Navigation", "CPPLiability"));

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
        _ui.WaitAsync(_locators.ClickAddEndorsement, expected, new ControlIntent("Navigation", "ClickAddEndorsement"));

    public Task ClickClickAddEndorsementAsync() =>
        _ui.ClickAsync(_locators.ClickAddEndorsement, new ControlIntent("Navigation", "ClickAddEndorsement"));

    public Task WaitForClickAddExcludedDriverAsync(string expected) =>
        _ui.WaitAsync(_locators.ClickAddExcludedDriver, expected, new ControlIntent("Navigation", "ClickAddExcludedDriver"));

    public Task ClickClickAddExcludedDriverAsync() =>
        _ui.ClickAsync(_locators.ClickAddExcludedDriver, new ControlIntent("Navigation", "ClickAddExcludedDriver"));

    public Task WaitForClient070F4Async(string expected) =>
        _ui.WaitAsync(_locators.Client070F4, expected, new ControlIntent("Navigation", "Client070F4"));

    public Task VerifyClient070F4Async(string expected, string property) =>
        _ui.VerifyAsync(_locators.Client070F4, expected, property, new ControlIntent("Navigation", "Client070F4"));

    public Task EnterClient35F85Async(string value) =>
        _ui.FillAsync(_locators.Client35F85, value, new ControlIntent("Navigation", "Client35F85"));

    public Task ClickClient35F85Async() =>
        _ui.ClickAsync(_locators.Client35F85, new ControlIntent("Navigation", "Client35F85"));

    public Task EnterCoinsurance01AB1Async(string value) =>
        _ui.FillAsync(_locators.Coinsurance01AB1, value, new ControlIntent("Navigation", "Coinsurance01AB1"));

    public Task PressCoinsurance01AB1Async(string key) =>
        _ui.PressAsync(_locators.Coinsurance01AB1, key, new ControlIntent("Navigation", "Coinsurance01AB1"));

    public Task EnterCoinsurance6348BAsync(string value) =>
        _ui.FillAsync(_locators.Coinsurance6348B, value, new ControlIntent("Navigation", "Coinsurance6348B"));

    public Task PressCoinsurance6348BAsync(string key) =>
        _ui.PressAsync(_locators.Coinsurance6348B, key, new ControlIntent("Navigation", "Coinsurance6348B"));

    public Task EnterCoinsuranceC9726Async(string value) =>
        _ui.FillAsync(_locators.CoinsuranceC9726, value, new ControlIntent("Navigation", "CoinsuranceC9726"));

    public Task PressCoinsuranceC9726Async(string key) =>
        _ui.PressAsync(_locators.CoinsuranceC9726, key, new ControlIntent("Navigation", "CoinsuranceC9726"));

    public Task ClickCollisionAsync() =>
        _ui.ClickAsync(_locators.Collision, new ControlIntent("Navigation", "Collision"));

    public Task VerifyCollisionCoverageAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.CollisionCoverage, expected, property, new ControlIntent("Navigation", "CollisionCoverage"));

    public Task EnterCollisionCoverageAsync(string value) =>
        _ui.FillAsync(_locators.CollisionCoverage, value, new ControlIntent("Navigation", "CollisionCoverage"));

    public Task PressCollisionCoverageAsync(string key) =>
        _ui.PressAsync(_locators.CollisionCoverage, key, new ControlIntent("Navigation", "CollisionCoverage"));

    public Task WaitForCollisionDeductible63D4CAsync(string expected) =>
        _ui.WaitAsync(_locators.CollisionDeductible63D4C, expected, new ControlIntent("Navigation", "CollisionDeductible63D4C"));

    public Task EnterCollisionDeductible9C100Async(string value) =>
        _ui.FillAsync(_locators.CollisionDeductible9C100, value, new ControlIntent("Navigation", "CollisionDeductible9C100"));

    public Task PressCollisionDeductible9C100Async(string key) =>
        _ui.PressAsync(_locators.CollisionDeductible9C100, key, new ControlIntent("Navigation", "CollisionDeductible9C100"));

    public Task EnterCollisionDeductibleAEEBBAsync(string value) =>
        _ui.FillAsync(_locators.CollisionDeductibleAEEBB, value, new ControlIntent("Navigation", "CollisionDeductibleAEEBB"));

    public Task PressCollisionDeductibleAEEBBAsync(string key) =>
        _ui.PressAsync(_locators.CollisionDeductibleAEEBB, key, new ControlIntent("Navigation", "CollisionDeductibleAEEBB"));

    public Task ClickCollisionIfAny7532DAsync() =>
        _ui.ClickAsync(_locators.CollisionIfAny7532D, new ControlIntent("Navigation", "CollisionIfAny7532D"));

    public Task ClickCollisionIfAny8AEE8Async() =>
        _ui.ClickAsync(_locators.CollisionIfAny8AEE8, new ControlIntent("Navigation", "CollisionIfAny8AEE8"));

    public Task ClickCommercialAutoAsync() =>
        _ui.ClickAsync(_locators.CommercialAuto, new ControlIntent("Navigation", "CommercialAuto"));

    public Task WaitForCommercialAutoDetailAsync(string expected) =>
        _ui.WaitAsync(_locators.CommercialAutoDetail, expected, new ControlIntent("Navigation", "CommercialAutoDetail"));

    public Task WaitForCommercialAutoRiskDetailAsync(string expected) =>
        _ui.WaitAsync(_locators.CommercialAutoRiskDetail, expected, new ControlIntent("Navigation", "CommercialAutoRiskDetail"));

    public Task ClickCommonNavigationLinksNextAsync() =>
        _ui.ClickAsync(_locators.CommonNavigationLinksNext, new ControlIntent("Navigation", "CommonNavigationLinksNext"));

    public Task ClickCommonOKAsync() =>
        _ui.ClickAsync(_locators.CommonOK, new ControlIntent("Navigation", "CommonOK"));

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

    public Task EnterConstruction39800Async(string value) =>
        _ui.FillAsync(_locators.Construction39800, value, new ControlIntent("Navigation", "Construction39800"));

    public Task PressConstruction39800Async(string key) =>
        _ui.PressAsync(_locators.Construction39800, key, new ControlIntent("Navigation", "Construction39800"));

    public Task EnterConstructionCD2DEAsync(string value) =>
        _ui.FillAsync(_locators.ConstructionCD2DE, value, new ControlIntent("Navigation", "ConstructionCD2DE"));

    public Task PressConstructionCD2DEAsync(string key) =>
        _ui.PressAsync(_locators.ConstructionCD2DE, key, new ControlIntent("Navigation", "ConstructionCD2DE"));

    public Task EnterConstructionCodeAsync(string value) =>
        _ui.FillAsync(_locators.ConstructionCode, value, new ControlIntent("Navigation", "ConstructionCode"));

    public Task PressConstructionCodeAsync(string key) =>
        _ui.PressAsync(_locators.ConstructionCode, key, new ControlIntent("Navigation", "ConstructionCode"));

    public Task EnterConstructionFB8D9Async(string value) =>
        _ui.FillAsync(_locators.ConstructionFB8D9, value, new ControlIntent("Navigation", "ConstructionFB8D9"));

    public Task PressConstructionFB8D9Async(string key) =>
        _ui.PressAsync(_locators.ConstructionFB8D9, key, new ControlIntent("Navigation", "ConstructionFB8D9"));

    public Task WaitForContractorsEquipmentHeadingAsync(string expected) =>
        _ui.WaitAsync(_locators.ContractorsEquipmentHeading, expected, new ControlIntent("Navigation", "ContractorsEquipmentHeading"));

    public Task ClickContractorsEquipmentUWQuestionsAsync() =>
        _ui.ClickAsync(_locators.ContractorsEquipmentUWQuestions, new ControlIntent("Navigation", "ContractorsEquipmentUWQuestions"));

    public Task WaitForCoverageBeginDateAsync(string expected) =>
        _ui.WaitAsync(_locators.CoverageBeginDate, expected, new ControlIntent("Navigation", "CoverageBeginDate"));

    public Task EnterCoverageEndDateAsync(string value) =>
        _ui.FillAsync(_locators.CoverageEndDate, value, new ControlIntent("Navigation", "CoverageEndDate"));

    public Task PressCoverageEndDateAsync(string key) =>
        _ui.PressAsync(_locators.CoverageEndDate, key, new ControlIntent("Navigation", "CoverageEndDate"));

    public Task WaitForCoverageForm3B382Async(string expected) =>
        _ui.WaitAsync(_locators.CoverageForm3B382, expected, new ControlIntent("Navigation", "CoverageForm3B382"));

    public Task EnterCoverageForm3B382Async(string value) =>
        _ui.FillAsync(_locators.CoverageForm3B382, value, new ControlIntent("Navigation", "CoverageForm3B382"));

    public Task PressCoverageForm3B382Async(string key) =>
        _ui.PressAsync(_locators.CoverageForm3B382, key, new ControlIntent("Navigation", "CoverageForm3B382"));

    public Task VerifyCoverageFormA7F96Async(string expected, string property) =>
        _ui.VerifyAsync(_locators.CoverageFormA7F96, expected, property, new ControlIntent("Navigation", "CoverageFormA7F96"));

    public Task EnterCoverageFormCFDD1Async(string value) =>
        _ui.FillAsync(_locators.CoverageFormCFDD1, value, new ControlIntent("Navigation", "CoverageFormCFDD1"));

    public Task PressCoverageFormCFDD1Async(string key) =>
        _ui.PressAsync(_locators.CoverageFormCFDD1, key, new ControlIntent("Navigation", "CoverageFormCFDD1"));

    public Task WaitForCoverageFormDisplay2ECD4Async(string expected) =>
        _ui.WaitAsync(_locators.CoverageFormDisplay2ECD4, expected, new ControlIntent("Navigation", "CoverageFormDisplay2ECD4"));

    public Task WaitForCoverageFormDisplay6F446Async(string expected) =>
        _ui.WaitAsync(_locators.CoverageFormDisplay6F446, expected, new ControlIntent("Navigation", "CoverageFormDisplay6F446"));

    public Task WaitForCoverageFormDisplayB69C2Async(string expected) =>
        _ui.WaitAsync(_locators.CoverageFormDisplayB69C2, expected, new ControlIntent("Navigation", "CoverageFormDisplayB69C2"));

    public Task WaitForCoverageFormDisplayC10BAAsync(string expected) =>
        _ui.WaitAsync(_locators.CoverageFormDisplayC10BA, expected, new ControlIntent("Navigation", "CoverageFormDisplayC10BA"));

    public Task WaitForCoverageFormDisplayD1A9BAsync(string expected) =>
        _ui.WaitAsync(_locators.CoverageFormDisplayD1A9B, expected, new ControlIntent("Navigation", "CoverageFormDisplayD1A9B"));

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

    public Task EnterDeductible01AB9Async(string value) =>
        _ui.FillAsync(_locators.Deductible01AB9, value, new ControlIntent("Navigation", "Deductible01AB9"));

    public Task PressDeductible01AB9Async(string key) =>
        _ui.PressAsync(_locators.Deductible01AB9, key, new ControlIntent("Navigation", "Deductible01AB9"));

    public Task EnterDeductible0CC0AAsync(string value) =>
        _ui.FillAsync(_locators.Deductible0CC0A, value, new ControlIntent("Navigation", "Deductible0CC0A"));

    public Task PressDeductible0CC0AAsync(string key) =>
        _ui.PressAsync(_locators.Deductible0CC0A, key, new ControlIntent("Navigation", "Deductible0CC0A"));

    public Task EnterDeductible320C9Async(string value) =>
        _ui.FillAsync(_locators.Deductible320C9, value, new ControlIntent("Navigation", "Deductible320C9"));

    public Task PressDeductible320C9Async(string key) =>
        _ui.PressAsync(_locators.Deductible320C9, key, new ControlIntent("Navigation", "Deductible320C9"));

    public Task EnterDeductible59155Async(string value) =>
        _ui.FillAsync(_locators.Deductible59155, value, new ControlIntent("Navigation", "Deductible59155"));

    public Task PressDeductible59155Async(string key) =>
        _ui.PressAsync(_locators.Deductible59155, key, new ControlIntent("Navigation", "Deductible59155"));

    public Task EnterDeductible592D9Async(string value) =>
        _ui.FillAsync(_locators.Deductible592D9, value, new ControlIntent("Navigation", "Deductible592D9"));

    public Task PressDeductible592D9Async(string key) =>
        _ui.PressAsync(_locators.Deductible592D9, key, new ControlIntent("Navigation", "Deductible592D9"));

    public Task EnterDeductible5F45DAsync(string value) =>
        _ui.FillAsync(_locators.Deductible5F45D, value, new ControlIntent("Navigation", "Deductible5F45D"));

    public Task EnterDeductibleBasisAsync(string value) =>
        _ui.FillAsync(_locators.DeductibleBasis, value, new ControlIntent("Navigation", "DeductibleBasis"));

    public Task PressDeductibleBasisAsync(string key) =>
        _ui.PressAsync(_locators.DeductibleBasis, key, new ControlIntent("Navigation", "DeductibleBasis"));

    public Task EnterDeductibleC227CAsync(string value) =>
        _ui.FillAsync(_locators.DeductibleC227C, value, new ControlIntent("Navigation", "DeductibleC227C"));

    public Task PressDeductibleC227CAsync(string key) =>
        _ui.PressAsync(_locators.DeductibleC227C, key, new ControlIntent("Navigation", "DeductibleC227C"));

    public Task EnterDeductibleC91E9Async(string value) =>
        _ui.FillAsync(_locators.DeductibleC91E9, value, new ControlIntent("Navigation", "DeductibleC91E9"));

    public Task PressDeductibleC91E9Async(string key) =>
        _ui.PressAsync(_locators.DeductibleC91E9, key, new ControlIntent("Navigation", "DeductibleC91E9"));

    public Task EnterDeductibleIncreasedTheft99E5FAsync(string value) =>
        _ui.FillAsync(_locators.DeductibleIncreasedTheft99E5F, value, new ControlIntent("Navigation", "DeductibleIncreasedTheft99E5F"));

    public Task PressDeductibleIncreasedTheft99E5FAsync(string key) =>
        _ui.PressAsync(_locators.DeductibleIncreasedTheft99E5F, key, new ControlIntent("Navigation", "DeductibleIncreasedTheft99E5F"));

    public Task EnterDeductibleIncreasedTheftF76DBAsync(string value) =>
        _ui.FillAsync(_locators.DeductibleIncreasedTheftF76DB, value, new ControlIntent("Navigation", "DeductibleIncreasedTheftF76DB"));

    public Task PressDeductibleIncreasedTheftF76DBAsync(string key) =>
        _ui.PressAsync(_locators.DeductibleIncreasedTheftF76DB, key, new ControlIntent("Navigation", "DeductibleIncreasedTheftF76DB"));

    public Task EnterDeductibleWindHail911AFAsync(string value) =>
        _ui.FillAsync(_locators.DeductibleWindHail911AF, value, new ControlIntent("Navigation", "DeductibleWindHail911AF"));

    public Task PressDeductibleWindHail911AFAsync(string key) =>
        _ui.PressAsync(_locators.DeductibleWindHail911AF, key, new ControlIntent("Navigation", "DeductibleWindHail911AF"));

    public Task EnterDeductibleWindHailAB1C3Async(string value) =>
        _ui.FillAsync(_locators.DeductibleWindHailAB1C3, value, new ControlIntent("Navigation", "DeductibleWindHailAB1C3"));

    public Task PressDeductibleWindHailAB1C3Async(string key) =>
        _ui.PressAsync(_locators.DeductibleWindHailAB1C3, key, new ControlIntent("Navigation", "DeductibleWindHailAB1C3"));

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

    public Task EnterDescription03789Async(string value) =>
        _ui.FillAsync(_locators.Description03789, value, new ControlIntent("Navigation", "Description03789"));

    public Task PressDescription03789Async(string key) =>
        _ui.PressAsync(_locators.Description03789, key, new ControlIntent("Navigation", "Description03789"));

    public Task EnterDescription43F2DAsync(string value) =>
        _ui.FillAsync(_locators.Description43F2D, value, new ControlIntent("Navigation", "Description43F2D"));

    public Task PressDescription43F2DAsync(string key) =>
        _ui.PressAsync(_locators.Description43F2D, key, new ControlIntent("Navigation", "Description43F2D"));

    public Task EnterDescription58EC2Async(string value) =>
        _ui.FillAsync(_locators.Description58EC2, value, new ControlIntent("Navigation", "Description58EC2"));

    public Task PressDescription58EC2Async(string key) =>
        _ui.PressAsync(_locators.Description58EC2, key, new ControlIntent("Navigation", "Description58EC2"));

    public Task EnterDescription8A08DAsync(string value) =>
        _ui.FillAsync(_locators.Description8A08D, value, new ControlIntent("Navigation", "Description8A08D"));

    public Task PressDescription8A08DAsync(string key) =>
        _ui.PressAsync(_locators.Description8A08D, key, new ControlIntent("Navigation", "Description8A08D"));

    public Task EnterDescriptionBE47EAsync(string value) =>
        _ui.FillAsync(_locators.DescriptionBE47E, value, new ControlIntent("Navigation", "DescriptionBE47E"));

    public Task PressDescriptionBE47EAsync(string key) =>
        _ui.PressAsync(_locators.DescriptionBE47E, key, new ControlIntent("Navigation", "DescriptionBE47E"));

    public Task EnterDescriptionF8E60Async(string value) =>
        _ui.FillAsync(_locators.DescriptionF8E60, value, new ControlIntent("Navigation", "DescriptionF8E60"));

    public Task PressDescriptionF8E60Async(string key) =>
        _ui.PressAsync(_locators.DescriptionF8E60, key, new ControlIntent("Navigation", "DescriptionF8E60"));

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

    public Task WaitForDetail0F8C6Async(string expected) =>
        _ui.WaitAsync(_locators.Detail0F8C6, expected, new ControlIntent("Navigation", "Detail0F8C6"));

    public Task ClickDetail10932Async() =>
        _ui.ClickAsync(_locators.Detail10932, new ControlIntent("Navigation", "Detail10932"));

    public Task ClickDetail1664BAsync() =>
        _ui.ClickAsync(_locators.Detail1664B, new ControlIntent("Navigation", "Detail1664B"));

    public Task ClickDetail238D5Async() =>
        _ui.ClickAsync(_locators.Detail238D5, new ControlIntent("Navigation", "Detail238D5"));

    public Task WaitForDetail33F0DAsync(string expected) =>
        _ui.WaitAsync(_locators.Detail33F0D, expected, new ControlIntent("Navigation", "Detail33F0D"));

    public Task WaitForDetail4A746Async(string expected) =>
        _ui.WaitAsync(_locators.Detail4A746, expected, new ControlIntent("Navigation", "Detail4A746"));

    public Task ClickDetail4A746Async() =>
        _ui.ClickAsync(_locators.Detail4A746, new ControlIntent("Navigation", "Detail4A746"));

    public Task ClickDetail7F662Async() =>
        _ui.ClickAsync(_locators.Detail7F662, new ControlIntent("Navigation", "Detail7F662"));

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

    public Task WaitForDriverDetailAsync(string expected) =>
        _ui.WaitAsync(_locators.DriverDetail, expected, new ControlIntent("Navigation", "DriverDetail"));

    public Task ClickDriverSchedule161DFAsync() =>
        _ui.ClickAsync(_locators.DriverSchedule161DF, new ControlIntent("Navigation", "DriverSchedule161DF"));

    public Task WaitForDriverSchedule79DC6Async(string expected) =>
        _ui.WaitAsync(_locators.DriverSchedule79DC6, expected, new ControlIntent("Navigation", "DriverSchedule79DC6"));

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

    public Task WaitForEffectiveDate0E335Async(string expected) =>
        _ui.WaitAsync(_locators.EffectiveDate0E335, expected, new ControlIntent("Navigation", "EffectiveDate0E335"));

    public Task EnterEffectiveDate0E335Async(string value) =>
        _ui.FillAsync(_locators.EffectiveDate0E335, value, new ControlIntent("Navigation", "EffectiveDate0E335"));

    public Task PressEffectiveDate0E335Async(string key) =>
        _ui.PressAsync(_locators.EffectiveDate0E335, key, new ControlIntent("Navigation", "EffectiveDate0E335"));

    public Task WaitForEffectiveDate68A1BAsync(string expected) =>
        _ui.WaitAsync(_locators.EffectiveDate68A1B, expected, new ControlIntent("Navigation", "EffectiveDate68A1B"));

    public Task WaitForEffectiveDate6CF3DAsync(string expected) =>
        _ui.WaitAsync(_locators.EffectiveDate6CF3D, expected, new ControlIntent("Navigation", "EffectiveDate6CF3D"));

    public Task EnterEffectiveDate6CF3DAsync(string value) =>
        _ui.FillAsync(_locators.EffectiveDate6CF3D, value, new ControlIntent("Navigation", "EffectiveDate6CF3D"));

    public Task PressEffectiveDate6CF3DAsync(string key) =>
        _ui.PressAsync(_locators.EffectiveDate6CF3D, key, new ControlIntent("Navigation", "EffectiveDate6CF3D"));

    public Task EnterEffectiveDate95094Async(string value) =>
        _ui.FillAsync(_locators.EffectiveDate95094, value, new ControlIntent("Navigation", "EffectiveDate95094"));

    public Task PressEffectiveDate95094Async(string key) =>
        _ui.PressAsync(_locators.EffectiveDate95094, key, new ControlIntent("Navigation", "EffectiveDate95094"));

    public Task WaitForEffectiveDateB3600Async(string expected) =>
        _ui.WaitAsync(_locators.EffectiveDateB3600, expected, new ControlIntent("Navigation", "EffectiveDateB3600"));

    public Task EnterEffectiveDateB3600Async(string value) =>
        _ui.FillAsync(_locators.EffectiveDateB3600, value, new ControlIntent("Navigation", "EffectiveDateB3600"));

    public Task PressEffectiveDateB3600Async(string key) =>
        _ui.PressAsync(_locators.EffectiveDateB3600, key, new ControlIntent("Navigation", "EffectiveDateB3600"));

    public Task EnterEffectiveDateB557FAsync(string value) =>
        _ui.FillAsync(_locators.EffectiveDateB557F, value, new ControlIntent("Navigation", "EffectiveDateB557F"));

    public Task PressEffectiveDateB557FAsync(string key) =>
        _ui.PressAsync(_locators.EffectiveDateB557F, key, new ControlIntent("Navigation", "EffectiveDateB557F"));

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
        _ui.ClickAsync(_locators.Endorsement, new ControlIntent("Navigation", "Endorsement"));

    public Task ClickEndorsementCM6601ExcludeNamedCustomerOKAsync() =>
        _ui.ClickAsync(_locators.EndorsementCM6601ExcludeNamedCustomerOK, new ControlIntent("Navigation", "EndorsementCM6601ExcludeNamedCustomerOK"));

    public Task WaitForEndorsementDetailAsync(string expected) =>
        _ui.WaitAsync(_locators.EndorsementDetail, expected, new ControlIntent("Navigation", "EndorsementDetail"));

    public Task WaitForEndorsementHeadingAsync(string expected) =>
        _ui.WaitAsync(_locators.EndorsementHeading, expected, new ControlIntent("Navigation", "EndorsementHeading"));

    public Task ClickEndorsementIF0002WaterborneEquipmentOKAsync() =>
        _ui.ClickAsync(_locators.EndorsementIF0002WaterborneEquipmentOK, new ControlIntent("Navigation", "EndorsementIF0002WaterborneEquipmentOK"));

    public Task VerifyEndorsementScheduleRow1Async(string expected, string property) =>
        _ui.VerifyAsync(_locators.EndorsementScheduleRow1, expected, property, new ControlIntent("Navigation", "EndorsementScheduleRow1"));

    public Task VerifyEndorsementTableRow1Async(string expected, string property) =>
        _ui.VerifyAsync(_locators.EndorsementTableRow1, expected, property, new ControlIntent("Navigation", "EndorsementTableRow1"));

    public Task VerifyEndorsementTableRow2Async(string expected, string property) =>
        _ui.VerifyAsync(_locators.EndorsementTableRow2, expected, property, new ControlIntent("Navigation", "EndorsementTableRow2"));

    public Task EnterEndorsementType3503EAsync(string value) =>
        _ui.FillAsync(_locators.EndorsementType3503E, value, new ControlIntent("Navigation", "EndorsementType3503E"));

    public Task PressEndorsementType3503EAsync(string key) =>
        _ui.PressAsync(_locators.EndorsementType3503E, key, new ControlIntent("Navigation", "EndorsementType3503E"));

    public Task WaitForEndorsementType624ADAsync(string expected) =>
        _ui.WaitAsync(_locators.EndorsementType624AD, expected, new ControlIntent("Navigation", "EndorsementType624AD"));

    public Task EnterEndorsementType624ADAsync(string value) =>
        _ui.FillAsync(_locators.EndorsementType624AD, value, new ControlIntent("Navigation", "EndorsementType624AD"));

    public Task PressEndorsementType624ADAsync(string key) =>
        _ui.PressAsync(_locators.EndorsementType624AD, key, new ControlIntent("Navigation", "EndorsementType624AD"));

    public Task ClickEndorsementType624ADAsync() =>
        _ui.ClickAsync(_locators.EndorsementType624AD, new ControlIntent("Navigation", "EndorsementType624AD"));

    public Task EnterEndorsementType8DB33Async(string value) =>
        _ui.FillAsync(_locators.EndorsementType8DB33, value, new ControlIntent("Navigation", "EndorsementType8DB33"));

    public Task PressEndorsementType8DB33Async(string key) =>
        _ui.PressAsync(_locators.EndorsementType8DB33, key, new ControlIntent("Navigation", "EndorsementType8DB33"));

    public Task EnterEndorsementTypeA2928Async(string value) =>
        _ui.FillAsync(_locators.EndorsementTypeA2928, value, new ControlIntent("Navigation", "EndorsementTypeA2928"));

    public Task PressEndorsementTypeA2928Async(string key) =>
        _ui.PressAsync(_locators.EndorsementTypeA2928, key, new ControlIntent("Navigation", "EndorsementTypeA2928"));

    public Task EnterEndorsementTypeAEC4FAsync(string value) =>
        _ui.FillAsync(_locators.EndorsementTypeAEC4F, value, new ControlIntent("Navigation", "EndorsementTypeAEC4F"));

    public Task PressEndorsementTypeAEC4FAsync(string key) =>
        _ui.PressAsync(_locators.EndorsementTypeAEC4F, key, new ControlIntent("Navigation", "EndorsementTypeAEC4F"));

    public Task EnterEndorsementTypeB210CAsync(string value) =>
        _ui.FillAsync(_locators.EndorsementTypeB210C, value, new ControlIntent("Navigation", "EndorsementTypeB210C"));

    public Task PressEndorsementTypeB210CAsync(string key) =>
        _ui.PressAsync(_locators.EndorsementTypeB210C, key, new ControlIntent("Navigation", "EndorsementTypeB210C"));

    public Task EnterEndorsementTypeC75E4Async(string value) =>
        _ui.FillAsync(_locators.EndorsementTypeC75E4, value, new ControlIntent("Navigation", "EndorsementTypeC75E4"));

    public Task PressEndorsementTypeC75E4Async(string key) =>
        _ui.PressAsync(_locators.EndorsementTypeC75E4, key, new ControlIntent("Navigation", "EndorsementTypeC75E4"));

    public Task EnterEndorsementTypeCE99FAsync(string value) =>
        _ui.FillAsync(_locators.EndorsementTypeCE99F, value, new ControlIntent("Navigation", "EndorsementTypeCE99F"));

    public Task PressEndorsementTypeCE99FAsync(string key) =>
        _ui.PressAsync(_locators.EndorsementTypeCE99F, key, new ControlIntent("Navigation", "EndorsementTypeCE99F"));

    public Task EnterEndorsementTypeD83A4Async(string value) =>
        _ui.FillAsync(_locators.EndorsementTypeD83A4, value, new ControlIntent("Navigation", "EndorsementTypeD83A4"));

    public Task PressEndorsementTypeD83A4Async(string key) =>
        _ui.PressAsync(_locators.EndorsementTypeD83A4, key, new ControlIntent("Navigation", "EndorsementTypeD83A4"));

    public Task EnterEndorsementTypeF8D4AAsync(string value) =>
        _ui.FillAsync(_locators.EndorsementTypeF8D4A, value, new ControlIntent("Navigation", "EndorsementTypeF8D4A"));

    public Task PressEndorsementTypeF8D4AAsync(string key) =>
        _ui.PressAsync(_locators.EndorsementTypeF8D4A, key, new ControlIntent("Navigation", "EndorsementTypeF8D4A"));

    public Task ClickEndorsements7572EAsync() =>
        _ui.ClickAsync(_locators.Endorsements7572E, new ControlIntent("Navigation", "Endorsements7572E"));

    public Task WaitForEndorsements9626EAsync(string expected) =>
        _ui.WaitAsync(_locators.Endorsements9626E, expected, new ControlIntent("Navigation", "Endorsements9626E"));

    public Task WaitForEndorsements9D4A5Async(string expected) =>
        _ui.WaitAsync(_locators.Endorsements9D4A5, expected, new ControlIntent("Navigation", "Endorsements9D4A5"));

    public Task PressEndorsements9D4A5Async(string key) =>
        _ui.PressAsync(_locators.Endorsements9D4A5, key, new ControlIntent("Navigation", "Endorsements9D4A5"));

    public Task ClickEndorsements9D4A5Async() =>
        _ui.ClickAsync(_locators.Endorsements9D4A5, new ControlIntent("Navigation", "Endorsements9D4A5"));

    public Task ClickEndorsementsB76E9Async() =>
        _ui.ClickAsync(_locators.EndorsementsB76E9, new ControlIntent("Navigation", "EndorsementsB76E9"));

    public Task WaitForEndorsementsC27F0Async(string expected) =>
        _ui.WaitAsync(_locators.EndorsementsC27F0, expected, new ControlIntent("Navigation", "EndorsementsC27F0"));

    public Task ClickEndorsementsC27F0Async() =>
        _ui.ClickAsync(_locators.EndorsementsC27F0, new ControlIntent("Navigation", "EndorsementsC27F0"));

    public Task WaitForEndorsementsHeading8FD33Async(string expected) =>
        _ui.WaitAsync(_locators.EndorsementsHeading8FD33, expected, new ControlIntent("Navigation", "EndorsementsHeading8FD33"));

    public Task VerifyEndorsementsHeading8FD33Async(string expected, string property) =>
        _ui.VerifyAsync(_locators.EndorsementsHeading8FD33, expected, property, new ControlIntent("Navigation", "EndorsementsHeading8FD33"));

    public Task WaitForEndorsementsHeadingA3D50Async(string expected) =>
        _ui.WaitAsync(_locators.EndorsementsHeadingA3D50, expected, new ControlIntent("Navigation", "EndorsementsHeadingA3D50"));

    public Task VerifyEndorsementsHeadingA3D50Async(string expected, string property) =>
        _ui.VerifyAsync(_locators.EndorsementsHeadingA3D50, expected, property, new ControlIntent("Navigation", "EndorsementsHeadingA3D50"));

    public Task EnterEngineSizeCcAsync(string value) =>
        _ui.FillAsync(_locators.EngineSizeCc, value, new ControlIntent("Navigation", "EngineSizeCc"));

    public Task PressEngineSizeCcAsync(string key) =>
        _ui.PressAsync(_locators.EngineSizeCc, key, new ControlIntent("Navigation", "EngineSizeCc"));

    public Task WaitForEntityInfoFrameAsync(string expected) =>
        _ui.WaitAsync(_locators.EntityInfoFrame, expected, new ControlIntent("Navigation", "EntityInfoFrame"));

    public Task WaitForEntityScheduleE6C9FAsync(string expected) =>
        _ui.WaitAsync(_locators.EntityScheduleE6C9F, expected, new ControlIntent("Navigation", "EntityScheduleE6C9F"));

    public Task ClickEntityScheduleEA671Async() =>
        _ui.ClickAsync(_locators.EntityScheduleEA671, new ControlIntent("Navigation", "EntityScheduleEA671"));

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

    public Task EnterExpirationDate34EACAsync(string value) =>
        _ui.FillAsync(_locators.ExpirationDate34EAC, value, new ControlIntent("Navigation", "ExpirationDate34EAC"));

    public Task PressExpirationDate34EACAsync(string key) =>
        _ui.PressAsync(_locators.ExpirationDate34EAC, key, new ControlIntent("Navigation", "ExpirationDate34EAC"));

    public Task EnterExpirationDate664A1Async(string value) =>
        _ui.FillAsync(_locators.ExpirationDate664A1, value, new ControlIntent("Navigation", "ExpirationDate664A1"));

    public Task PressExpirationDate664A1Async(string key) =>
        _ui.PressAsync(_locators.ExpirationDate664A1, key, new ControlIntent("Navigation", "ExpirationDate664A1"));

    public Task EnterExpirationDate82561Async(string value) =>
        _ui.FillAsync(_locators.ExpirationDate82561, value, new ControlIntent("Navigation", "ExpirationDate82561"));

    public Task PressExpirationDate82561Async(string key) =>
        _ui.PressAsync(_locators.ExpirationDate82561, key, new ControlIntent("Navigation", "ExpirationDate82561"));

    public Task EnterExpirationDateB437CAsync(string value) =>
        _ui.FillAsync(_locators.ExpirationDateB437C, value, new ControlIntent("Navigation", "ExpirationDateB437C"));

    public Task PressExpirationDateB437CAsync(string key) =>
        _ui.PressAsync(_locators.ExpirationDateB437C, key, new ControlIntent("Navigation", "ExpirationDateB437C"));

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

    public Task ClickFG0013AutomaticAdditionalInsuredSpecificRelationshipOKAsync() =>
        _ui.ClickAsync(_locators.FG0013AutomaticAdditionalInsuredSpecificRelationshipOK, new ControlIntent("Navigation", "FG0013AutomaticAdditionalInsuredSpecificRelationshipOK"));

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

    public Task EnterFirstName5059EAsync(string value) =>
        _ui.FillAsync(_locators.FirstName5059E, value, new ControlIntent("Navigation", "FirstName5059E"));

    public Task PressFirstName5059EAsync(string key) =>
        _ui.PressAsync(_locators.FirstName5059E, key, new ControlIntent("Navigation", "FirstName5059E"));

    public Task WaitForFirstName813D1Async(string expected) =>
        _ui.WaitAsync(_locators.FirstName813D1, expected, new ControlIntent("Navigation", "FirstName813D1"));

    public Task EnterFirstName813D1Async(string value) =>
        _ui.FillAsync(_locators.FirstName813D1, value, new ControlIntent("Navigation", "FirstName813D1"));

    public Task PressFirstName813D1Async(string key) =>
        _ui.PressAsync(_locators.FirstName813D1, key, new ControlIntent("Navigation", "FirstName813D1"));

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

    public Task WaitForGeneralLiabilityAsync(string expected) =>
        _ui.WaitAsync(_locators.GeneralLiability, expected, new ControlIntent("Navigation", "GeneralLiability"));

    public Task WaitForGeneralLiabilityInformationAsync(string expected) =>
        _ui.WaitAsync(_locators.GeneralLiabilityInformation, expected, new ControlIntent("Navigation", "GeneralLiabilityInformation"));

    public Task ClickGeneralLiabilityInformationOKAsync() =>
        _ui.ClickAsync(_locators.GeneralLiabilityInformationOK, new ControlIntent("Navigation", "GeneralLiabilityInformationOK"));

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

    public Task WaitForHeadingThirdPartyDesigneeAsync(string expected) =>
        _ui.WaitAsync(_locators.HeadingThirdPartyDesignee, expected, new ControlIntent("Navigation", "HeadingThirdPartyDesignee"));

    public Task EnterHiredAutoCA2001Address1Async(string value) =>
        _ui.FillAsync(_locators.HiredAutoCA2001Address1, value, new ControlIntent("Navigation", "HiredAutoCA2001Address1"));

    public Task PressHiredAutoCA2001Address1Async(string key) =>
        _ui.PressAsync(_locators.HiredAutoCA2001Address1, key, new ControlIntent("Navigation", "HiredAutoCA2001Address1"));

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

    public Task WaitForHiredAutoFormAsync(string expected) =>
        _ui.WaitAsync(_locators.HiredAutoForm, expected, new ControlIntent("Navigation", "HiredAutoForm"));

    public Task EnterHiredAutoFormAsync(string value) =>
        _ui.FillAsync(_locators.HiredAutoForm, value, new ControlIntent("Navigation", "HiredAutoForm"));

    public Task PressHiredAutoFormAsync(string key) =>
        _ui.PressAsync(_locators.HiredAutoForm, key, new ControlIntent("Navigation", "HiredAutoForm"));

    public Task ClickHiredAutoLiabilityAsync() =>
        _ui.ClickAsync(_locators.HiredAutoLiability, new ControlIntent("Navigation", "HiredAutoLiability"));

    public Task WaitForHiredAutoOKAsync(string expected) =>
        _ui.WaitAsync(_locators.HiredAutoOK, expected, new ControlIntent("Navigation", "HiredAutoOK"));

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

    public Task WaitForIFRAME280B0Async(string expected) =>
        _ui.WaitAsync(_locators.IFRAME280B0, expected, new ControlIntent("Navigation", "IFRAME280B0"));

    public Task VerifyIFRAME280B0Async(string expected, string property) =>
        _ui.VerifyAsync(_locators.IFRAME280B0, expected, property, new ControlIntent("Navigation", "IFRAME280B0"));

    public Task WaitForIFRAME59D4BAsync(string expected) =>
        _ui.WaitAsync(_locators.IFRAME59D4B, expected, new ControlIntent("Navigation", "IFRAME59D4B"));

    public Task WaitForIFRAME6D695Async(string expected) =>
        _ui.WaitAsync(_locators.IFRAME6D695, expected, new ControlIntent("Navigation", "IFRAME6D695"));

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

    public Task WaitForIFRAMEF0A48Async(string expected) =>
        _ui.WaitAsync(_locators.IFRAMEF0A48, expected, new ControlIntent("Navigation", "IFRAMEF0A48"));

    public Task VerifyIFRAMEF0A48Async(string expected, string property) =>
        _ui.VerifyAsync(_locators.IFRAMEF0A48, expected, property, new ControlIntent("Navigation", "IFRAMEF0A48"));

    public Task EnterIfYesDescribeAsync(string value) =>
        _ui.FillAsync(_locators.IfYesDescribe, value, new ControlIntent("Navigation", "IfYesDescribe"));

    public Task PressIfYesDescribeAsync(string key) =>
        _ui.PressAsync(_locators.IfYesDescribe, key, new ControlIntent("Navigation", "IfYesDescribe"));

    public Task EnterIfYesExplainAsync(string value) =>
        _ui.FillAsync(_locators.IfYesExplain, value, new ControlIntent("Navigation", "IfYesExplain"));

    public Task PressIfYesExplainAsync(string key) =>
        _ui.PressAsync(_locators.IfYesExplain, key, new ControlIntent("Navigation", "IfYesExplain"));

    public Task ClickImportPolicyDataButton89922Async() =>
        _ui.ClickAsync(_locators.ImportPolicyDataButton89922, new ControlIntent("Navigation", "ImportPolicyDataButton89922"));

    public Task ClickImportPolicyDataButtonEF44CAsync() =>
        _ui.ClickAsync(_locators.ImportPolicyDataButtonEF44C, new ControlIntent("Navigation", "ImportPolicyDataButtonEF44C"));

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

    public Task EnterLastName34FF6Async(string value) =>
        _ui.FillAsync(_locators.LastName34FF6, value, new ControlIntent("Navigation", "LastName34FF6"));

    public Task PressLastName34FF6Async(string key) =>
        _ui.PressAsync(_locators.LastName34FF6, key, new ControlIntent("Navigation", "LastName34FF6"));

    public Task EnterLastName5E149Async(string value) =>
        _ui.FillAsync(_locators.LastName5E149, value, new ControlIntent("Navigation", "LastName5E149"));

    public Task PressLastName5E149Async(string key) =>
        _ui.PressAsync(_locators.LastName5E149, key, new ControlIntent("Navigation", "LastName5E149"));

    public Task EnterLaundryAsync(string value) =>
        _ui.FillAsync(_locators.Laundry, value, new ControlIntent("Navigation", "Laundry"));

    public Task PressLaundryAsync(string key) =>
        _ui.PressAsync(_locators.Laundry, key, new ControlIntent("Navigation", "Laundry"));

    public Task EnterLetteringAsync(string value) =>
        _ui.FillAsync(_locators.Lettering, value, new ControlIntent("Navigation", "Lettering"));

    public Task PressLetteringAsync(string key) =>
        _ui.PressAsync(_locators.Lettering, key, new ControlIntent("Navigation", "Lettering"));

    public Task EnterLiabilityLimit1AE2BAsync(string value) =>
        _ui.FillAsync(_locators.LiabilityLimit1AE2B, value, new ControlIntent("Navigation", "LiabilityLimit1AE2B"));

    public Task PressLiabilityLimit1AE2BAsync(string key) =>
        _ui.PressAsync(_locators.LiabilityLimit1AE2B, key, new ControlIntent("Navigation", "LiabilityLimit1AE2B"));

    public Task EnterLiabilityLimit56E57Async(string value) =>
        _ui.FillAsync(_locators.LiabilityLimit56E57, value, new ControlIntent("Navigation", "LiabilityLimit56E57"));

    public Task PressLiabilityLimit56E57Async(string key) =>
        _ui.PressAsync(_locators.LiabilityLimit56E57, key, new ControlIntent("Navigation", "LiabilityLimit56E57"));

    public Task EnterLimit46632Async(string value) =>
        _ui.FillAsync(_locators.Limit46632, value, new ControlIntent("Navigation", "Limit46632"));

    public Task PressLimit46632Async(string key) =>
        _ui.PressAsync(_locators.Limit46632, key, new ControlIntent("Navigation", "Limit46632"));

    public Task EnterLimit887C5Async(string value) =>
        _ui.FillAsync(_locators.Limit887C5, value, new ControlIntent("Navigation", "Limit887C5"));

    public Task PressLimit887C5Async(string key) =>
        _ui.PressAsync(_locators.Limit887C5, key, new ControlIntent("Navigation", "Limit887C5"));

    public Task EnterLimitE32DCAsync(string value) =>
        _ui.FillAsync(_locators.LimitE32DC, value, new ControlIntent("Navigation", "LimitE32DC"));

    public Task PressLimitE32DCAsync(string key) =>
        _ui.PressAsync(_locators.LimitE32DC, key, new ControlIntent("Navigation", "LimitE32DC"));

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

    public Task WaitForLocation82D95Async(string expected) =>
        _ui.WaitAsync(_locators.Location82D95, expected, new ControlIntent("Navigation", "Location82D95"));

    public Task ClickLocation8DEE2Async() =>
        _ui.ClickAsync(_locators.Location8DEE2, new ControlIntent("Navigation", "Location8DEE2"));

    public Task WaitForLocationA1D91Async(string expected) =>
        _ui.WaitAsync(_locators.LocationA1D91, expected, new ControlIntent("Navigation", "LocationA1D91"));

    public Task ClickLocationA1D91Async() =>
        _ui.ClickAsync(_locators.LocationA1D91, new ControlIntent("Navigation", "LocationA1D91"));

    public Task WaitForLocationAssignmentAsync(string expected) =>
        _ui.WaitAsync(_locators.LocationAssignment, expected, new ControlIntent("Navigation", "LocationAssignment"));

    public Task ClickLocationB7B1DAsync() =>
        _ui.ClickAsync(_locators.LocationB7B1D, new ControlIntent("Navigation", "LocationB7B1D"));

    public Task ClickLocationE16BCAsync() =>
        _ui.ClickAsync(_locators.LocationE16BC, new ControlIntent("Navigation", "LocationE16BC"));

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

    public Task ClickLocationOKAsync() =>
        _ui.ClickAsync(_locators.LocationOK, new ControlIntent("Navigation", "LocationOK"));

    public Task EnterLocationOfCoveredOperationsAsync(string value) =>
        _ui.FillAsync(_locators.LocationOfCoveredOperations, value, new ControlIntent("Navigation", "LocationOfCoveredOperations"));

    public Task PressLocationOfCoveredOperationsAsync(string key) =>
        _ui.PressAsync(_locators.LocationOfCoveredOperations, key, new ControlIntent("Navigation", "LocationOfCoveredOperations"));

    public Task ClickLossExperienceAsync() =>
        _ui.ClickAsync(_locators.LossExperience, new ControlIntent("Navigation", "LossExperience"));

    public Task WaitForLossExperienceHeadingAsync(string expected) =>
        _ui.WaitAsync(_locators.LossExperienceHeading, expected, new ControlIntent("Navigation", "LossExperienceHeading"));

    public Task ClickMainPageOKAsync() =>
        _ui.ClickAsync(_locators.MainPageOK, new ControlIntent("Navigation", "MainPageOK"));

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

    public Task WaitForMotorTruckCargoHeadingAsync(string expected) =>
        _ui.WaitAsync(_locators.MotorTruckCargoHeading, expected, new ControlIntent("Navigation", "MotorTruckCargoHeading"));

    public Task ClickMotorTruckCargoUWQuestionsAsync() =>
        _ui.ClickAsync(_locators.MotorTruckCargoUWQuestions, new ControlIntent("Navigation", "MotorTruckCargoUWQuestions"));

    public Task WaitForMotorcycleLiabilityAsync(string expected) =>
        _ui.WaitAsync(_locators.MotorcycleLiability, expected, new ControlIntent("Navigation", "MotorcycleLiability"));

    public Task PressMotorcycleLiabilityAsync(string key) =>
        _ui.PressAsync(_locators.MotorcycleLiability, key, new ControlIntent("Navigation", "MotorcycleLiability"));

    public Task ClickMotorcycleLiabilityAsync() =>
        _ui.ClickAsync(_locators.MotorcycleLiability, new ControlIntent("Navigation", "MotorcycleLiability"));

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

    public Task ClickNotePadOKAsync() =>
        _ui.ClickAsync(_locators.NotePadOK, new ControlIntent("Navigation", "NotePadOK"));

    public Task ClickNotepadAsync() =>
        _ui.ClickAsync(_locators.Notepad, new ControlIntent("Navigation", "Notepad"));

    public Task WaitForNotepadHeadingAsync(string expected) =>
        _ui.WaitAsync(_locators.NotepadHeading, expected, new ControlIntent("Navigation", "NotepadHeading"));

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

    public Task ClickOKAsync() =>
        _ui.ClickAsync(_locators.OK, new ControlIntent("Navigation", "OK"));

    public Task WaitForOKClassCodeAsync(string expected) =>
        _ui.WaitAsync(_locators.OKClassCode, expected, new ControlIntent("Navigation", "OKClassCode"));

    public Task VerifyOKClassCodeAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.OKClassCode, expected, property, new ControlIntent("Navigation", "OKClassCode"));

    public Task ClickOKClassCodeAsync() =>
        _ui.ClickAsync(_locators.OKClassCode, new ControlIntent("Navigation", "OKClassCode"));

    public Task ClickOKDetailsAsync() =>
        _ui.ClickAsync(_locators.OKDetails, new ControlIntent("Navigation", "OKDetails"));

    public Task PressOKFirstAsync(string key) =>
        _ui.PressAsync(_locators.OKFirst, key, new ControlIntent("Navigation", "OKFirst"));

    public Task ClickOKFirstAsync() =>
        _ui.ClickAsync(_locators.OKFirst, new ControlIntent("Navigation", "OKFirst"));

    public Task WaitForOKSecondAsync(string expected) =>
        _ui.WaitAsync(_locators.OKSecond, expected, new ControlIntent("Navigation", "OKSecond"));

    public Task EnterOTCCausesOfLossAsync(string value) =>
        _ui.FillAsync(_locators.OTCCausesOfLoss, value, new ControlIntent("Navigation", "OTCCausesOfLoss"));

    public Task PressOTCCausesOfLossAsync(string key) =>
        _ui.PressAsync(_locators.OTCCausesOfLoss, key, new ControlIntent("Navigation", "OTCCausesOfLoss"));

    public Task EnterOTCDeductible62C21Async(string value) =>
        _ui.FillAsync(_locators.OTCDeductible62C21, value, new ControlIntent("Navigation", "OTCDeductible62C21"));

    public Task PressOTCDeductible62C21Async(string key) =>
        _ui.PressAsync(_locators.OTCDeductible62C21, key, new ControlIntent("Navigation", "OTCDeductible62C21"));

    public Task WaitForOTCDeductibleE0D59Async(string expected) =>
        _ui.WaitAsync(_locators.OTCDeductibleE0D59, expected, new ControlIntent("Navigation", "OTCDeductibleE0D59"));

    public Task EnterOTCDeductibleEF1DEAsync(string value) =>
        _ui.FillAsync(_locators.OTCDeductibleEF1DE, value, new ControlIntent("Navigation", "OTCDeductibleEF1DE"));

    public Task PressOTCDeductibleEF1DEAsync(string key) =>
        _ui.PressAsync(_locators.OTCDeductibleEF1DE, key, new ControlIntent("Navigation", "OTCDeductibleEF1DE"));

    public Task ClickOTCIfAny4EFEEAsync() =>
        _ui.ClickAsync(_locators.OTCIfAny4EFEE, new ControlIntent("Navigation", "OTCIfAny4EFEE"));

    public Task ClickOTCIfAny6A58BAsync() =>
        _ui.ClickAsync(_locators.OTCIfAny6A58B, new ControlIntent("Navigation", "OTCIfAny6A58B"));

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

    public Task WaitForOptionAAsync(string expected) =>
        _ui.WaitAsync(_locators.OptionA, expected, new ControlIntent("Navigation", "OptionA"));

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
        _ui.FillAsync(_locators.OriginalCostNew, value, new ControlIntent("Navigation", "OriginalCostNew"));

    public Task PressOriginalCostNewAsync(string key) =>
        _ui.PressAsync(_locators.OriginalCostNew, key, new ControlIntent("Navigation", "OriginalCostNew"));

    public Task ClickOtherInsuranceHistoryOKAsync() =>
        _ui.ClickAsync(_locators.OtherInsuranceHistoryOK, new ControlIntent("Navigation", "OtherInsuranceHistoryOK"));

    public Task EnterOthers9E098Async(string value) =>
        _ui.FillAsync(_locators.Others9E098, value, new ControlIntent("Navigation", "Others9E098"));

    public Task PressOthers9E098Async(string key) =>
        _ui.PressAsync(_locators.Others9E098, key, new ControlIntent("Navigation", "Others9E098"));

    public Task EnterOthersB1A1BAsync(string value) =>
        _ui.FillAsync(_locators.OthersB1A1B, value, new ControlIntent("Navigation", "OthersB1A1B"));

    public Task PressOthersB1A1BAsync(string key) =>
        _ui.PressAsync(_locators.OthersB1A1B, key, new ControlIntent("Navigation", "OthersB1A1B"));

    public Task EnterPartnersAsync(string value) =>
        _ui.FillAsync(_locators.Partners, value, new ControlIntent("Navigation", "Partners"));

    public Task PressPartnersAsync(string key) =>
        _ui.PressAsync(_locators.Partners, key, new ControlIntent("Navigation", "Partners"));

    public Task ClickPartnersOfficersAndOthersExclusionOKAsync() =>
        _ui.ClickAsync(_locators.PartnersOfficersAndOthersExclusionOK, new ControlIntent("Navigation", "PartnersOfficersAndOthersExclusionOK"));

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
        _ui.FillAsync(_locators.PersonalPropertyRatingGroup, value, new ControlIntent("Navigation", "PersonalPropertyRatingGroup"));

    public Task PressPersonalPropertyRatingGroupAsync(string key) =>
        _ui.PressAsync(_locators.PersonalPropertyRatingGroup, key, new ControlIntent("Navigation", "PersonalPropertyRatingGroup"));

    public Task WaitForPhysicalDamageOKAsync(string expected) =>
        _ui.WaitAsync(_locators.PhysicalDamageOK, expected, new ControlIntent("Navigation", "PhysicalDamageOK"));

    public Task ClickPhysicalDamageOKAsync() =>
        _ui.ClickAsync(_locators.PhysicalDamageOK, new ControlIntent("Navigation", "PhysicalDamageOK"));

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

    public Task WaitForPolicyCovg26786Async(string expected) =>
        _ui.WaitAsync(_locators.PolicyCovg26786, expected, new ControlIntent("Navigation", "PolicyCovg26786"));

    public Task VerifyPolicyCovg26786Async(string expected, string property) =>
        _ui.VerifyAsync(_locators.PolicyCovg26786, expected, property, new ControlIntent("Navigation", "PolicyCovg26786"));

    public Task ClickPolicyCovg35BE4Async() =>
        _ui.ClickAsync(_locators.PolicyCovg35BE4, new ControlIntent("Navigation", "PolicyCovg35BE4"));

    public Task ClickPolicyCovg50C98Async() =>
        _ui.ClickAsync(_locators.PolicyCovg50C98, new ControlIntent("Navigation", "PolicyCovg50C98"));

    public Task WaitForPolicyCovg6B651Async(string expected) =>
        _ui.WaitAsync(_locators.PolicyCovg6B651, expected, new ControlIntent("Navigation", "PolicyCovg6B651"));

    public Task ClickPolicyCovgBaileesCutomersOKAsync() =>
        _ui.ClickAsync(_locators.PolicyCovgBaileesCutomersOK, new ControlIntent("Navigation", "PolicyCovgBaileesCutomersOK"));

    public Task ClickPolicyCovgBaileesPropertyAwayFromYourPremisesOKAsync() =>
        _ui.ClickAsync(_locators.PolicyCovgBaileesPropertyAwayFromYourPremisesOK, new ControlIntent("Navigation", "PolicyCovgBaileesPropertyAwayFromYourPremisesOK"));

    public Task ClickPolicyCovgComputerSystemsOKAsync() =>
        _ui.ClickAsync(_locators.PolicyCovgComputerSystemsOK, new ControlIntent("Navigation", "PolicyCovgComputerSystemsOK"));

    public Task ClickPolicyCovgContractorsEquipmentOKAsync() =>
        _ui.ClickAsync(_locators.PolicyCovgContractorsEquipmentOK, new ControlIntent("Navigation", "PolicyCovgContractorsEquipmentOK"));

    public Task ClickPolicyCovgD0419Async() =>
        _ui.ClickAsync(_locators.PolicyCovgD0419, new ControlIntent("Navigation", "PolicyCovgD0419"));

    public Task ClickPolicyCovgD3CEFAsync() =>
        _ui.ClickAsync(_locators.PolicyCovgD3CEF, new ControlIntent("Navigation", "PolicyCovgD3CEF"));

    public Task ClickPolicyCovgED95CAsync() =>
        _ui.ClickAsync(_locators.PolicyCovgED95C, new ControlIntent("Navigation", "PolicyCovgED95C"));

    public Task WaitForPolicyCovgF9E58Async(string expected) =>
        _ui.WaitAsync(_locators.PolicyCovgF9E58, expected, new ControlIntent("Navigation", "PolicyCovgF9E58"));

    public Task WaitForPolicyCovgFF145Async(string expected) =>
        _ui.WaitAsync(_locators.PolicyCovgFF145, expected, new ControlIntent("Navigation", "PolicyCovgFF145"));

    public Task WaitForPolicyCovgHeaderAsync(string expected) =>
        _ui.WaitAsync(_locators.PolicyCovgHeader, expected, new ControlIntent("Navigation", "PolicyCovgHeader"));

    public Task ClickPolicyCovgMotorTruckCargoOKAsync() =>
        _ui.ClickAsync(_locators.PolicyCovgMotorTruckCargoOK, new ControlIntent("Navigation", "PolicyCovgMotorTruckCargoOK"));

    public Task ClickPolicyCovgSignsOKAsync() =>
        _ui.ClickAsync(_locators.PolicyCovgSignsOK, new ControlIntent("Navigation", "PolicyCovgSignsOK"));

    public Task WaitForPolicyCovgerageAsync(string expected) =>
        _ui.WaitAsync(_locators.PolicyCovgerage, expected, new ControlIntent("Navigation", "PolicyCovgerage"));

    public Task ClickPolicyCovgerageAsync() =>
        _ui.ClickAsync(_locators.PolicyCovgerage, new ControlIntent("Navigation", "PolicyCovgerage"));

    public Task EnterPolicyHolderNameAsync(string value) =>
        _ui.FillAsync(_locators.PolicyHolderName, value, new ControlIntent("Navigation", "PolicyHolderName"));

    public Task PressPolicyHolderNameAsync(string key) =>
        _ui.PressAsync(_locators.PolicyHolderName, key, new ControlIntent("Navigation", "PolicyHolderName"));

    public Task ClickPolicyInfoAsync() =>
        _ui.ClickAsync(_locators.PolicyInfo, new ControlIntent("Navigation", "PolicyInfo"));

    public Task WaitForPolicyInfoHeaderAsync(string expected) =>
        _ui.WaitAsync(_locators.PolicyInfoHeader, expected, new ControlIntent("Navigation", "PolicyInfoHeader"));

    public Task EnterPolicyNumber461C7Async(string value) =>
        _ui.FillAsync(_locators.PolicyNumber461C7, value, new ControlIntent("Navigation", "PolicyNumber461C7"));

    public Task PressPolicyNumber461C7Async(string key) =>
        _ui.PressAsync(_locators.PolicyNumber461C7, key, new ControlIntent("Navigation", "PolicyNumber461C7"));

    public Task EnterPolicyNumber6566FAsync(string value) =>
        _ui.FillAsync(_locators.PolicyNumber6566F, value, new ControlIntent("Navigation", "PolicyNumber6566F"));

    public Task PressPolicyNumber6566FAsync(string key) =>
        _ui.PressAsync(_locators.PolicyNumber6566F, key, new ControlIntent("Navigation", "PolicyNumber6566F"));

    public Task EnterPolicyNumber78B85Async(string value) =>
        _ui.FillAsync(_locators.PolicyNumber78B85, value, new ControlIntent("Navigation", "PolicyNumber78B85"));

    public Task PressPolicyNumber78B85Async(string key) =>
        _ui.PressAsync(_locators.PolicyNumber78B85, key, new ControlIntent("Navigation", "PolicyNumber78B85"));

    public Task EnterPolicyNumberBA28EAsync(string value) =>
        _ui.FillAsync(_locators.PolicyNumberBA28E, value, new ControlIntent("Navigation", "PolicyNumberBA28E"));

    public Task PressPolicyNumberBA28EAsync(string key) =>
        _ui.PressAsync(_locators.PolicyNumberBA28E, key, new ControlIntent("Navigation", "PolicyNumberBA28E"));

    public Task EnterPolicyNumberFDF5CAsync(string value) =>
        _ui.FillAsync(_locators.PolicyNumberFDF5C, value, new ControlIntent("Navigation", "PolicyNumberFDF5C"));

    public Task PressPolicyNumberFDF5CAsync(string key) =>
        _ui.PressAsync(_locators.PolicyNumberFDF5C, key, new ControlIntent("Navigation", "PolicyNumberFDF5C"));

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

    public Task ClickPricing900C9Async() =>
        _ui.ClickAsync(_locators.Pricing900C9, new ControlIntent("Navigation", "Pricing900C9"));

    public Task ClickPricingB84E6Async() =>
        _ui.ClickAsync(_locators.PricingB84E6, new ControlIntent("Navigation", "PricingB84E6"));

    public Task ClickPricingDCBD4Async() =>
        _ui.ClickAsync(_locators.PricingDCBD4, new ControlIntent("Navigation", "PricingDCBD4"));

    public Task WaitForPricingDetailAsync(string expected) =>
        _ui.WaitAsync(_locators.PricingDetail, expected, new ControlIntent("Navigation", "PricingDetail"));

    public Task ClickPricingDetailAsync() =>
        _ui.ClickAsync(_locators.PricingDetail, new ControlIntent("Navigation", "PricingDetail"));

    public Task ClickPricingDetailOKAsync() =>
        _ui.ClickAsync(_locators.PricingDetailOK, new ControlIntent("Navigation", "PricingDetailOK"));

    public Task WaitForPricingF3185Async(string expected) =>
        _ui.WaitAsync(_locators.PricingF3185, expected, new ControlIntent("Navigation", "PricingF3185"));

    public Task ClickPricingF3185Async() =>
        _ui.ClickAsync(_locators.PricingF3185, new ControlIntent("Navigation", "PricingF3185"));

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

    public Task WaitForProductsCompletedOpsAsync(string expected) =>
        _ui.WaitAsync(_locators.ProductsCompletedOps, expected, new ControlIntent("Navigation", "ProductsCompletedOps"));

    public Task ClickProductsCompletedOpsButtonAsync() =>
        _ui.ClickAsync(_locators.ProductsCompletedOpsButton, new ControlIntent("Navigation", "ProductsCompletedOpsButton"));

    public Task ClickProductsCompletedOpsOKAsync() =>
        _ui.ClickAsync(_locators.ProductsCompletedOpsOK, new ControlIntent("Navigation", "ProductsCompletedOpsOK"));

    public Task ClickPropertyAsync() =>
        _ui.ClickAsync(_locators.Property, new ControlIntent("Navigation", "Property"));

    public Task ClickPropertyAddClassOKAsync() =>
        _ui.ClickAsync(_locators.PropertyAddClassOK, new ControlIntent("Navigation", "PropertyAddClassOK"));

    public Task ClickPropertyAwayFromYourPremisesScheduleAsync() =>
        _ui.ClickAsync(_locators.PropertyAwayFromYourPremisesSchedule, new ControlIntent("Navigation", "PropertyAwayFromYourPremisesSchedule"));

    public Task ClickPropertyEnterBuildingRCTOKAsync() =>
        _ui.ClickAsync(_locators.PropertyEnterBuildingRCTOK, new ControlIntent("Navigation", "PropertyEnterBuildingRCTOK"));

    public Task EnterPropertyInTransit6E905Async(string value) =>
        _ui.FillAsync(_locators.PropertyInTransit6E905, value, new ControlIntent("Navigation", "PropertyInTransit6E905"));

    public Task PressPropertyInTransit6E905Async(string key) =>
        _ui.PressAsync(_locators.PropertyInTransit6E905, key, new ControlIntent("Navigation", "PropertyInTransit6E905"));

    public Task EnterPropertyInTransit710FFAsync(string value) =>
        _ui.FillAsync(_locators.PropertyInTransit710FF, value, new ControlIntent("Navigation", "PropertyInTransit710FF"));

    public Task PressPropertyInTransit710FFAsync(string key) =>
        _ui.PressAsync(_locators.PropertyInTransit710FF, key, new ControlIntent("Navigation", "PropertyInTransit710FF"));

    public Task EnterPropertyOfOthersLimitAsync(string value) =>
        _ui.FillAsync(_locators.PropertyOfOthersLimit, value, new ControlIntent("Navigation", "PropertyOfOthersLimit"));

    public Task PressPropertyOfOthersLimitAsync(string key) =>
        _ui.PressAsync(_locators.PropertyOfOthersLimit, key, new ControlIntent("Navigation", "PropertyOfOthersLimit"));

    public Task EnterPropertyOfOthersRatingGroupAsync(string value) =>
        _ui.FillAsync(_locators.PropertyOfOthersRatingGroup, value, new ControlIntent("Navigation", "PropertyOfOthersRatingGroup"));

    public Task PressPropertyOfOthersRatingGroupAsync(string key) =>
        _ui.PressAsync(_locators.PropertyOfOthersRatingGroup, key, new ControlIntent("Navigation", "PropertyOfOthersRatingGroup"));

    public Task WaitForPropertyUWQuestions790F2Async(string expected) =>
        _ui.WaitAsync(_locators.PropertyUWQuestions790F2, expected, new ControlIntent("Navigation", "PropertyUWQuestions790F2"));

    public Task ClickPropertyUWQuestions8452CAsync() =>
        _ui.ClickAsync(_locators.PropertyUWQuestions8452C, new ControlIntent("Navigation", "PropertyUWQuestions8452C"));

    public Task EnterProvideAListOfSurroundingExposureOtherOccupanciesWithin100FtIncludingNorthEastSouthAndWestAsync(string value) =>
        _ui.FillAsync(_locators.ProvideAListOfSurroundingExposureOtherOccupanciesWithin100FtIncludingNorthEastSouthAndWest, value, new ControlIntent("Navigation", "ProvideAListOfSurroundingExposureOtherOccupanciesWithin100FtIncludingNorthEastSouthAndWest"));

    public Task PressProvideAListOfSurroundingExposureOtherOccupanciesWithin100FtIncludingNorthEastSouthAndWestAsync(string key) =>
        _ui.PressAsync(_locators.ProvideAListOfSurroundingExposureOtherOccupanciesWithin100FtIncludingNorthEastSouthAndWest, key, new ControlIntent("Navigation", "ProvideAListOfSurroundingExposureOtherOccupanciesWithin100FtIncludingNorthEastSouthAndWest"));

    public Task EnterProvideInformationRegardingAntivirusMethodsAndCopyrightProtectionOfDataAndMediaAsync(string value) =>
        _ui.FillAsync(_locators.ProvideInformationRegardingAntivirusMethodsAndCopyrightProtectionOfDataAndMedia, value, new ControlIntent("Navigation", "ProvideInformationRegardingAntivirusMethodsAndCopyrightProtectionOfDataAndMedia"));

    public Task PressProvideInformationRegardingAntivirusMethodsAndCopyrightProtectionOfDataAndMediaAsync(string key) =>
        _ui.PressAsync(_locators.ProvideInformationRegardingAntivirusMethodsAndCopyrightProtectionOfDataAndMedia, key, new ControlIntent("Navigation", "ProvideInformationRegardingAntivirusMethodsAndCopyrightProtectionOfDataAndMedia"));

    public Task ClickRatingGroups46191Async() =>
        _ui.ClickAsync(_locators.RatingGroups46191, new ControlIntent("Navigation", "RatingGroups46191"));

    public Task WaitForRatingGroups46DD2Async(string expected) =>
        _ui.WaitAsync(_locators.RatingGroups46DD2, expected, new ControlIntent("Navigation", "RatingGroups46DD2"));

    public Task WaitForRentalOwnersLiabilityAsync(string expected) =>
        _ui.WaitAsync(_locators.RentalOwnersLiability, expected, new ControlIntent("Navigation", "RentalOwnersLiability"));

    public Task PressRentalOwnersLiabilityAsync(string key) =>
        _ui.PressAsync(_locators.RentalOwnersLiability, key, new ControlIntent("Navigation", "RentalOwnersLiability"));

    public Task ClickRentalOwnersLiabilityAsync() =>
        _ui.ClickAsync(_locators.RentalOwnersLiability, new ControlIntent("Navigation", "RentalOwnersLiability"));

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

    public Task ClickRisk5D6FAAsync() =>
        _ui.ClickAsync(_locators.Risk5D6FA, new ControlIntent("Navigation", "Risk5D6FA"));

    public Task WaitForRisk873E7Async(string expected) =>
        _ui.WaitAsync(_locators.Risk873E7, expected, new ControlIntent("Navigation", "Risk873E7"));

    public Task ClickRiskAccountsReceivableOKAsync() =>
        _ui.ClickAsync(_locators.RiskAccountsReceivableOK, new ControlIntent("Navigation", "RiskAccountsReceivableOK"));

    public Task ClickRiskBaileesCustomersOKAsync() =>
        _ui.ClickAsync(_locators.RiskBaileesCustomersOK, new ControlIntent("Navigation", "RiskBaileesCustomersOK"));

    public Task ClickRiskComputerSystemsOKAsync() =>
        _ui.ClickAsync(_locators.RiskComputerSystemsOK, new ControlIntent("Navigation", "RiskComputerSystemsOK"));

    public Task WaitForRiskDDE70Async(string expected) =>
        _ui.WaitAsync(_locators.RiskDDE70, expected, new ControlIntent("Navigation", "RiskDDE70"));

    public Task VerifyRiskDDE70Async(string expected, string property) =>
        _ui.VerifyAsync(_locators.RiskDDE70, expected, property, new ControlIntent("Navigation", "RiskDDE70"));

    public Task WaitForRiskHeadingAsync(string expected) =>
        _ui.WaitAsync(_locators.RiskHeading, expected, new ControlIntent("Navigation", "RiskHeading"));

    public Task WaitForRiskScheduleAsync(string expected) =>
        _ui.WaitAsync(_locators.RiskSchedule, expected, new ControlIntent("Navigation", "RiskSchedule"));

    public Task ClickRiskScheduleAsync() =>
        _ui.ClickAsync(_locators.RiskSchedule, new ControlIntent("Navigation", "RiskSchedule"));

    public Task ClickRiskSignsOKAsync() =>
        _ui.ClickAsync(_locators.RiskSignsOK, new ControlIntent("Navigation", "RiskSignsOK"));

    public Task EnterRiskTypeAsync(string value) =>
        _ui.FillAsync(_locators.RiskType, value, new ControlIntent("Navigation", "RiskType"));

    public Task PressRiskTypeAsync(string key) =>
        _ui.PressAsync(_locators.RiskType, key, new ControlIntent("Navigation", "RiskType"));

    public Task EnterRoofTypeAsync(string value) =>
        _ui.FillAsync(_locators.RoofType, value, new ControlIntent("Navigation", "RoofType"));

    public Task PressRoofTypeAsync(string key) =>
        _ui.PressAsync(_locators.RoofType, key, new ControlIntent("Navigation", "RoofType"));

    public Task ClickSFP10LiabilityFarmAsync() =>
        _ui.ClickAsync(_locators.SFP10LiabilityFarm, new ControlIntent("Navigation", "SFP10LiabilityFarm"));

    public Task WaitForSFP10LiabilityFarmHeadingAsync(string expected) =>
        _ui.WaitAsync(_locators.SFP10LiabilityFarmHeading, expected, new ControlIntent("Navigation", "SFP10LiabilityFarmHeading"));

    public Task ClickSaveForLaterAsync() =>
        _ui.ClickAsync(_locators.SaveForLater, new ControlIntent("Navigation", "SaveForLater"));

    public Task EnterScheduledCoverageAsync(string value) =>
        _ui.FillAsync(_locators.ScheduledCoverage, value, new ControlIntent("Navigation", "ScheduledCoverage"));

    public Task PressScheduledCoverageAsync(string key) =>
        _ui.PressAsync(_locators.ScheduledCoverage, key, new ControlIntent("Navigation", "ScheduledCoverage"));

    public Task EnterSearchResult4E620Async(string value) =>
        _ui.FillAsync(_locators.SearchResult4E620, value, new ControlIntent("Navigation", "SearchResult4E620"));

    public Task PressSearchResult4E620Async(string key) =>
        _ui.PressAsync(_locators.SearchResult4E620, key, new ControlIntent("Navigation", "SearchResult4E620"));

    public Task EnterSearchResultA1BFBAsync(string value) =>
        _ui.FillAsync(_locators.SearchResultA1BFB, value, new ControlIntent("Navigation", "SearchResultA1BFB"));

    public Task PressSearchResultA1BFBAsync(string key) =>
        _ui.PressAsync(_locators.SearchResultA1BFB, key, new ControlIntent("Navigation", "SearchResultA1BFB"));

    public Task EnterSearchResultEAFB8Async(string value) =>
        _ui.FillAsync(_locators.SearchResultEAFB8, value, new ControlIntent("Navigation", "SearchResultEAFB8"));

    public Task PressSearchResultEAFB8Async(string key) =>
        _ui.PressAsync(_locators.SearchResultEAFB8, key, new ControlIntent("Navigation", "SearchResultEAFB8"));

    public Task EnterSearchResults5209CAsync(string value) =>
        _ui.FillAsync(_locators.SearchResults5209C, value, new ControlIntent("Navigation", "SearchResults5209C"));

    public Task PressSearchResults5209CAsync(string key) =>
        _ui.PressAsync(_locators.SearchResults5209C, key, new ControlIntent("Navigation", "SearchResults5209C"));

    public Task EnterSearchResultsD0AA8Async(string value) =>
        _ui.FillAsync(_locators.SearchResultsD0AA8, value, new ControlIntent("Navigation", "SearchResultsD0AA8"));

    public Task PressSearchResultsD0AA8Async(string key) =>
        _ui.PressAsync(_locators.SearchResultsD0AA8, key, new ControlIntent("Navigation", "SearchResultsD0AA8"));

    public Task WaitForSearchValue53135Async(string expected) =>
        _ui.WaitAsync(_locators.SearchValue53135, expected, new ControlIntent("Navigation", "SearchValue53135"));

    public Task EnterSearchValue53135Async(string value) =>
        _ui.FillAsync(_locators.SearchValue53135, value, new ControlIntent("Navigation", "SearchValue53135"));

    public Task PressSearchValue53135Async(string key) =>
        _ui.PressAsync(_locators.SearchValue53135, key, new ControlIntent("Navigation", "SearchValue53135"));

    public Task EnterSearchValue54F3CAsync(string value) =>
        _ui.FillAsync(_locators.SearchValue54F3C, value, new ControlIntent("Navigation", "SearchValue54F3C"));

    public Task PressSearchValue54F3CAsync(string key) =>
        _ui.PressAsync(_locators.SearchValue54F3C, key, new ControlIntent("Navigation", "SearchValue54F3C"));

    public Task EnterSearchValue79E46Async(string value) =>
        _ui.FillAsync(_locators.SearchValue79E46, value, new ControlIntent("Navigation", "SearchValue79E46"));

    public Task PressSearchValue79E46Async(string key) =>
        _ui.PressAsync(_locators.SearchValue79E46, key, new ControlIntent("Navigation", "SearchValue79E46"));

    public Task EnterSearchValue9FCD1Async(string value) =>
        _ui.FillAsync(_locators.SearchValue9FCD1, value, new ControlIntent("Navigation", "SearchValue9FCD1"));

    public Task PressSearchValue9FCD1Async(string key) =>
        _ui.PressAsync(_locators.SearchValue9FCD1, key, new ControlIntent("Navigation", "SearchValue9FCD1"));

    public Task EnterSearchValueCA6A6Async(string value) =>
        _ui.FillAsync(_locators.SearchValueCA6A6, value, new ControlIntent("Navigation", "SearchValueCA6A6"));

    public Task PressSearchValueCA6A6Async(string key) =>
        _ui.PressAsync(_locators.SearchValueCA6A6, key, new ControlIntent("Navigation", "SearchValueCA6A6"));

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

    public Task WaitForSelectEndorsement0EAB0Async(string expected) =>
        _ui.WaitAsync(_locators.SelectEndorsement0EAB0, expected, new ControlIntent("Navigation", "SelectEndorsement0EAB0"));

    public Task VerifySelectEndorsement0EAB0Async(string expected, string property) =>
        _ui.VerifyAsync(_locators.SelectEndorsement0EAB0, expected, property, new ControlIntent("Navigation", "SelectEndorsement0EAB0"));

    public Task EnterSelectEndorsement0EAB0Async(string value) =>
        _ui.FillAsync(_locators.SelectEndorsement0EAB0, value, new ControlIntent("Navigation", "SelectEndorsement0EAB0"));

    public Task PressSelectEndorsement0EAB0Async(string key) =>
        _ui.PressAsync(_locators.SelectEndorsement0EAB0, key, new ControlIntent("Navigation", "SelectEndorsement0EAB0"));

    public Task EnterSelectEndorsement63E0EAsync(string value) =>
        _ui.FillAsync(_locators.SelectEndorsement63E0E, value, new ControlIntent("Navigation", "SelectEndorsement63E0E"));

    public Task PressSelectEndorsement63E0EAsync(string key) =>
        _ui.PressAsync(_locators.SelectEndorsement63E0E, key, new ControlIntent("Navigation", "SelectEndorsement63E0E"));

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

    public Task WaitForSignsHeadingAsync(string expected) =>
        _ui.WaitAsync(_locators.SignsHeading, expected, new ControlIntent("Navigation", "SignsHeading"));

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

    public Task ClickSoleProprietorsPartnersOfficersAndOthersCoverageOKAsync() =>
        _ui.ClickAsync(_locators.SoleProprietorsPartnersOfficersAndOthersCoverageOK, new ControlIntent("Navigation", "SoleProprietorsPartnersOfficersAndOthersCoverageOK"));

    public Task ClickSpecificUnderwritingQuestionsAsync() =>
        _ui.ClickAsync(_locators.SpecificUnderwritingQuestions, new ControlIntent("Navigation", "SpecificUnderwritingQuestions"));

    public Task ClickSpecificUnderwritingQuestionsAccountsReceivableOKAsync() =>
        _ui.ClickAsync(_locators.SpecificUnderwritingQuestionsAccountsReceivableOK, new ControlIntent("Navigation", "SpecificUnderwritingQuestionsAccountsReceivableOK"));

    public Task ClickSpecificUnderwritingQuestionsBaileesCustomerOKAsync() =>
        _ui.ClickAsync(_locators.SpecificUnderwritingQuestionsBaileesCustomerOK, new ControlIntent("Navigation", "SpecificUnderwritingQuestionsBaileesCustomerOK"));

    public Task ClickSpecificUnderwritingQuestionsComputerSystemsOKAsync() =>
        _ui.ClickAsync(_locators.SpecificUnderwritingQuestionsComputerSystemsOK, new ControlIntent("Navigation", "SpecificUnderwritingQuestionsComputerSystemsOK"));

    public Task ClickSpecificUnderwritingQuestionsContractorsEquipmentOKAsync() =>
        _ui.ClickAsync(_locators.SpecificUnderwritingQuestionsContractorsEquipmentOK, new ControlIntent("Navigation", "SpecificUnderwritingQuestionsContractorsEquipmentOK"));

    public Task ClickSpecificUnderwritingQuestionsMotorTruckCargoOwnersOKAsync() =>
        _ui.ClickAsync(_locators.SpecificUnderwritingQuestionsMotorTruckCargoOwnersOK, new ControlIntent("Navigation", "SpecificUnderwritingQuestionsMotorTruckCargoOwnersOK"));

    public Task ClickSpecificUnderwritingQuestionsSignsOKAsync() =>
        _ui.ClickAsync(_locators.SpecificUnderwritingQuestionsSignsOK, new ControlIntent("Navigation", "SpecificUnderwritingQuestionsSignsOK"));

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

    public Task EnterState16B92Async(string value) =>
        _ui.FillAsync(_locators.State16B92, value, new ControlIntent("Navigation", "State16B92"));

    public Task PressState16B92Async(string key) =>
        _ui.PressAsync(_locators.State16B92, key, new ControlIntent("Navigation", "State16B92"));

    public Task WaitForState64A10Async(string expected) =>
        _ui.WaitAsync(_locators.State64A10, expected, new ControlIntent("Navigation", "State64A10"));

    public Task EnterState89468Async(string value) =>
        _ui.FillAsync(_locators.State89468, value, new ControlIntent("Navigation", "State89468"));

    public Task PressState89468Async(string key) =>
        _ui.PressAsync(_locators.State89468, key, new ControlIntent("Navigation", "State89468"));

    public Task WaitForStateDetails33183Async(string expected) =>
        _ui.WaitAsync(_locators.StateDetails33183, expected, new ControlIntent("Navigation", "StateDetails33183"));

    public Task ClickStateDetails33183Async() =>
        _ui.ClickAsync(_locators.StateDetails33183, new ControlIntent("Navigation", "StateDetails33183"));

    public Task WaitForStateDetails72631Async(string expected) =>
        _ui.WaitAsync(_locators.StateDetails72631, expected, new ControlIntent("Navigation", "StateDetails72631"));

    public Task ClickStateDetailsB407BAsync() =>
        _ui.ClickAsync(_locators.StateDetailsB407B, new ControlIntent("Navigation", "StateDetailsB407B"));

    public Task WaitForStateDetailsDetailAsync(string expected) =>
        _ui.WaitAsync(_locators.StateDetailsDetail, expected, new ControlIntent("Navigation", "StateDetailsDetail"));

    public Task ClickStateDetailsDetailAsync() =>
        _ui.ClickAsync(_locators.StateDetailsDetail, new ControlIntent("Navigation", "StateDetailsDetail"));

    public Task EnterStateLicensedAsync(string value) =>
        _ui.FillAsync(_locators.StateLicensed, value, new ControlIntent("Navigation", "StateLicensed"));

    public Task PressStateLicensedAsync(string key) =>
        _ui.PressAsync(_locators.StateLicensed, key, new ControlIntent("Navigation", "StateLicensed"));

    public Task EnterStateOrPoliticalSubdivisionAsync(string value) =>
        _ui.FillAsync(_locators.StateOrPoliticalSubdivision, value, new ControlIntent("Navigation", "StateOrPoliticalSubdivision"));

    public Task PressStateOrPoliticalSubdivisionAsync(string key) =>
        _ui.PressAsync(_locators.StateOrPoliticalSubdivision, key, new ControlIntent("Navigation", "StateOrPoliticalSubdivision"));

    public Task EnterStatedAmountAsync(string value) =>
        _ui.FillAsync(_locators.StatedAmount, value, new ControlIntent("Navigation", "StatedAmount"));

    public Task PressStatedAmountAsync(string key) =>
        _ui.PressAsync(_locators.StatedAmount, key, new ControlIntent("Navigation", "StatedAmount"));

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
        _ui.WaitAsync(_locators.Submission, expected, new ControlIntent("Navigation", "Submission"));

    public Task PressSubmissionAsync(string key) =>
        _ui.PressAsync(_locators.Submission, key, new ControlIntent("Navigation", "Submission"));

    public Task ClickSubmissionAsync() =>
        _ui.ClickAsync(_locators.Submission, new ControlIntent("Navigation", "Submission"));

    public Task WaitForSubmissionHeadingAsync(string expected) =>
        _ui.WaitAsync(_locators.SubmissionHeading, expected, new ControlIntent("Navigation", "SubmissionHeading"));

    public Task VerifySubmissionHeadingAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.SubmissionHeading, expected, property, new ControlIntent("Navigation", "SubmissionHeading"));

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

    public Task EnterTotalSubjectPremium19B44Async(string value) =>
        _ui.FillAsync(_locators.TotalSubjectPremium19B44, value, new ControlIntent("Navigation", "TotalSubjectPremium19B44"));

    public Task PressTotalSubjectPremium19B44Async(string key) =>
        _ui.PressAsync(_locators.TotalSubjectPremium19B44, key, new ControlIntent("Navigation", "TotalSubjectPremium19B44"));

    public Task EnterTotalSubjectPremiumAF452Async(string value) =>
        _ui.FillAsync(_locators.TotalSubjectPremiumAF452, value, new ControlIntent("Navigation", "TotalSubjectPremiumAF452"));

    public Task PressTotalSubjectPremiumAF452Async(string key) =>
        _ui.PressAsync(_locators.TotalSubjectPremiumAF452, key, new ControlIntent("Navigation", "TotalSubjectPremiumAF452"));

    public Task EnterTotalSubjectPremiumE8AF0Async(string value) =>
        _ui.FillAsync(_locators.TotalSubjectPremiumE8AF0, value, new ControlIntent("Navigation", "TotalSubjectPremiumE8AF0"));

    public Task PressTotalSubjectPremiumE8AF0Async(string key) =>
        _ui.PressAsync(_locators.TotalSubjectPremiumE8AF0, key, new ControlIntent("Navigation", "TotalSubjectPremiumE8AF0"));

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

    public Task EnterType56F72Async(string value) =>
        _ui.FillAsync(_locators.Type56F72, value, new ControlIntent("Navigation", "Type56F72"));

    public Task PressType56F72Async(string key) =>
        _ui.PressAsync(_locators.Type56F72, key, new ControlIntent("Navigation", "Type56F72"));

    public Task EnterType715D6Async(string value) =>
        _ui.FillAsync(_locators.Type715D6, value, new ControlIntent("Navigation", "Type715D6"));

    public Task PressType715D6Async(string key) =>
        _ui.PressAsync(_locators.Type715D6, key, new ControlIntent("Navigation", "Type715D6"));

    public Task EnterType885AAAsync(string value) =>
        _ui.FillAsync(_locators.Type885AA, value, new ControlIntent("Navigation", "Type885AA"));

    public Task PressType885AAAsync(string key) =>
        _ui.PressAsync(_locators.Type885AA, key, new ControlIntent("Navigation", "Type885AA"));

    public Task EnterTypeA75B5Async(string value) =>
        _ui.FillAsync(_locators.TypeA75B5, value, new ControlIntent("Navigation", "TypeA75B5"));

    public Task PressTypeA75B5Async(string key) =>
        _ui.PressAsync(_locators.TypeA75B5, key, new ControlIntent("Navigation", "TypeA75B5"));

    public Task EnterTypeB082DAsync(string value) =>
        _ui.FillAsync(_locators.TypeB082D, value, new ControlIntent("Navigation", "TypeB082D"));

    public Task PressTypeB082DAsync(string key) =>
        _ui.PressAsync(_locators.TypeB082D, key, new ControlIntent("Navigation", "TypeB082D"));

    public Task EnterTypeCDE3BAsync(string value) =>
        _ui.FillAsync(_locators.TypeCDE3B, value, new ControlIntent("Navigation", "TypeCDE3B"));

    public Task PressTypeCDE3BAsync(string key) =>
        _ui.PressAsync(_locators.TypeCDE3B, key, new ControlIntent("Navigation", "TypeCDE3B"));

    public Task WaitForTypeD0639Async(string expected) =>
        _ui.WaitAsync(_locators.TypeD0639, expected, new ControlIntent("Navigation", "TypeD0639"));

    public Task EnterTypeD0639Async(string value) =>
        _ui.FillAsync(_locators.TypeD0639, value, new ControlIntent("Navigation", "TypeD0639"));

    public Task PressTypeD0639Async(string key) =>
        _ui.PressAsync(_locators.TypeD0639, key, new ControlIntent("Navigation", "TypeD0639"));

    public Task ClickTypeD0639Async() =>
        _ui.ClickAsync(_locators.TypeD0639, new ControlIntent("Navigation", "TypeD0639"));

    public Task VerifyTypeD972CAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.TypeD972C, expected, property, new ControlIntent("Navigation", "TypeD972C"));

    public Task EnterTypeD972CAsync(string value) =>
        _ui.FillAsync(_locators.TypeD972C, value, new ControlIntent("Navigation", "TypeD972C"));

    public Task PressTypeD972CAsync(string key) =>
        _ui.PressAsync(_locators.TypeD972C, key, new ControlIntent("Navigation", "TypeD972C"));

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

    public Task WaitForUMUIMOKAsync(string expected) =>
        _ui.WaitAsync(_locators.UMUIMOK, expected, new ControlIntent("Navigation", "UMUIMOK"));

    public Task VerifyUMUIMOKAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.UMUIMOK, expected, property, new ControlIntent("Navigation", "UMUIMOK"));

    public Task ClickUMUIMOKAsync() =>
        _ui.ClickAsync(_locators.UMUIMOK, new ControlIntent("Navigation", "UMUIMOK"));

    public Task ClickUWQuestions368CCAsync() =>
        _ui.ClickAsync(_locators.UWQuestions368CC, new ControlIntent("Navigation", "UWQuestions368CC"));

    public Task WaitForUWQuestionsF3D9FAsync(string expected) =>
        _ui.WaitAsync(_locators.UWQuestionsF3D9F, expected, new ControlIntent("Navigation", "UWQuestionsF3D9F"));

    public Task PressUWQuestionsUmbrella9F47EAsync(string key) =>
        _ui.PressAsync(_locators.UWQuestionsUmbrella9F47E, key, new ControlIntent("Navigation", "UWQuestionsUmbrella9F47E"));

    public Task ClickUWQuestionsUmbrella9F47EAsync() =>
        _ui.ClickAsync(_locators.UWQuestionsUmbrella9F47E, new ControlIntent("Navigation", "UWQuestionsUmbrella9F47E"));

    public Task WaitForUWQuestionsUmbrellaFF014Async(string expected) =>
        _ui.WaitAsync(_locators.UWQuestionsUmbrellaFF014, expected, new ControlIntent("Navigation", "UWQuestionsUmbrellaFF014"));

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

    public Task ClickUpdateAnswers3DA0BAsync() =>
        _ui.ClickAsync(_locators.UpdateAnswers3DA0B, new ControlIntent("Navigation", "UpdateAnswers3DA0B"));

    public Task PressUpdateAnswers3DDA2Async(string key) =>
        _ui.PressAsync(_locators.UpdateAnswers3DDA2, key, new ControlIntent("Navigation", "UpdateAnswers3DDA2"));

    public Task ClickUpdateAnswers3DDA2Async() =>
        _ui.ClickAsync(_locators.UpdateAnswers3DDA2, new ControlIntent("Navigation", "UpdateAnswers3DDA2"));

    public Task ClickUpdateAnswers69564Async() =>
        _ui.ClickAsync(_locators.UpdateAnswers69564, new ControlIntent("Navigation", "UpdateAnswers69564"));

    public Task WaitForUpdateAnswers6FF76Async(string expected) =>
        _ui.WaitAsync(_locators.UpdateAnswers6FF76, expected, new ControlIntent("Navigation", "UpdateAnswers6FF76"));

    public Task PressUpdateAnswers6FF76Async(string key) =>
        _ui.PressAsync(_locators.UpdateAnswers6FF76, key, new ControlIntent("Navigation", "UpdateAnswers6FF76"));

    public Task ClickUpdateAnswers6FF76Async() =>
        _ui.ClickAsync(_locators.UpdateAnswers6FF76, new ControlIntent("Navigation", "UpdateAnswers6FF76"));

    public Task PressUpdateAnswers99D68Async(string key) =>
        _ui.PressAsync(_locators.UpdateAnswers99D68, key, new ControlIntent("Navigation", "UpdateAnswers99D68"));

    public Task ClickUpdateAnswers99D68Async() =>
        _ui.ClickAsync(_locators.UpdateAnswers99D68, new ControlIntent("Navigation", "UpdateAnswers99D68"));

    public Task ClickUpdateAnswers9CB86Async() =>
        _ui.ClickAsync(_locators.UpdateAnswers9CB86, new ControlIntent("Navigation", "UpdateAnswers9CB86"));

    public Task ClickUpdateAnswersB41BEAsync() =>
        _ui.ClickAsync(_locators.UpdateAnswersB41BE, new ControlIntent("Navigation", "UpdateAnswersB41BE"));

    public Task PressUpdateAnswersButtonAsync(string key) =>
        _ui.PressAsync(_locators.UpdateAnswersButton, key, new ControlIntent("Navigation", "UpdateAnswersButton"));

    public Task ClickUpdateAnswersButtonAsync() =>
        _ui.ClickAsync(_locators.UpdateAnswersButton, new ControlIntent("Navigation", "UpdateAnswersButton"));

    public Task ClickUpdateAnswersD8A16Async() =>
        _ui.ClickAsync(_locators.UpdateAnswersD8A16, new ControlIntent("Navigation", "UpdateAnswersD8A16"));

    public Task ClickUpdateAnswersFB765Async() =>
        _ui.ClickAsync(_locators.UpdateAnswersFB765, new ControlIntent("Navigation", "UpdateAnswersFB765"));

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

    public Task EnterZipCodeB286BAsync(string value) =>
        _ui.FillAsync(_locators.ZipCodeB286B, value, new ControlIntent("Navigation", "ZipCodeB286B"));

    public Task PressZipCodeB286BAsync(string key) =>
        _ui.PressAsync(_locators.ZipCodeB286B, key, new ControlIntent("Navigation", "ZipCodeB286B"));

    public Task EnterZipCodeBCEA0Async(string value) =>
        _ui.FillAsync(_locators.ZipCodeBCEA0, value, new ControlIntent("Navigation", "ZipCodeBCEA0"));

    public Task PressZipCodeBCEA0Async(string key) =>
        _ui.PressAsync(_locators.ZipCodeBCEA0, key, new ControlIntent("Navigation", "ZipCodeBCEA0"));

    public Task EnterZipCodeC048FAsync(string value) =>
        _ui.FillAsync(_locators.ZipCodeC048F, value, new ControlIntent("Navigation", "ZipCodeC048F"));

    public Task PressZipCodeC048FAsync(string key) =>
        _ui.PressAsync(_locators.ZipCodeC048F, key, new ControlIntent("Navigation", "ZipCodeC048F"));

    public Task EnterZipCodeC7591Async(string value) =>
        _ui.FillAsync(_locators.ZipCodeC7591, value, new ControlIntent("Navigation", "ZipCodeC7591"));

    public Task PressZipCodeC7591Async(string key) =>
        _ui.PressAsync(_locators.ZipCodeC7591, key, new ControlIntent("Navigation", "ZipCodeC7591"));

    public Task VerifyZipCodeD2DBAAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.ZipCodeD2DBA, expected, property, new ControlIntent("Navigation", "ZipCodeD2DBA"));

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

}
