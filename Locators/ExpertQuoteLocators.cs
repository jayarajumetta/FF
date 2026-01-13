using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_POC.Locators
{
    public static class GlobalLocators
    {
        public const string NextButton = "//button[contains(text(), 'Next')]";
        public const string DialogSubmitButton = "//mat-dialog-container//a[text()='Submit']";
        public const string DialogCancelButton = "//mat-dialog-container//a[text()='Cancel']";
        public const string SaveAndContinueButton = "xpath=.//button[contains(text(), 'Save and Continue')]";
        public const string CancelButton = "xpath=.//button[contains(text(), 'Cancel')]";
        public const string QuoteNumber = "xpath=//div[contains(@class, 'mat-tab-label-container')]//span";
        public const string SaveButton = "xpath=.//button[contains(text(), 'Save')]";
    }

    public static class LoginLocators
    {
        public const string UsernameInput = "input[name='pf.username']";
        public const string PasswordInput = "input[name='pf.pass']";
        public const string LoginButton = "button[title='Sign On']";
    }
   
    public static class ClientSearchLocators
    {
        public const string DashboardElement = "//strong[text()='Quote']";
        public const string ClientSearchPage = "//div[text()='Search / Recently Accessed']";
        public const string IndividualSearchField = "input[name='quoteSearchInput']";
        public const string ClientSearchButton = "button[data-testid='quoteSearchButton']";
        public const string NewQuoteButton = "//button[text()='New Quote']";
    }

    public static class NewExistingClientSearchLocators
    {
        public const string FirstNameInput = "input[name='customer.name.first']";
        public const string LastNameInput = "input[name='customer.name.last']";
        public const string DateOfBirthInput = "input[name='customer.dateOfBirth']";
        public const string DateOfBirthCalendarIcon = "button[aria-label='Open calendar']";
        public const string BestPhoneInput = "input[name='customer.phone']";
        public const string EmailAddressInput = "input[name='customer.email']";
        public const string SearchButton = "//button[text()='Search']";
        public const string CreateNewClientButton = "//button[.//div[text()='Create New Client']]";
    }

    public static class AccountInformationConstLocators
    {
        // Account Owner Information
        public const string PageHeader = "//h1[text()='Account Information']";
        public const string FirstName = "input[name='owner.name.first']";
        public const string LastName = "input[name='owner.name.last']";
        public const string DateOfBirth = "input[name='owner.dateOfBirth']";
        public const string BestPhone = "input[name='owner.phone']";
        public const string EmailAddress = "input[name='owner.email']";
        public const string MoreOptionsButton = "//button[.//div[text()='More Options']]"; // Make a Global Locator


        // Account/Mailing Address Information
        public const string StreetAddressInput = "input[name='owner.address.line1']";
        public const string AptNumberInput = "input[name='owner.address.line2']";
        public const string CityInput = "input[name='owner.address.city']";
        public const string StateDropdown = "mat-select[id='owner.address.state']";
        public const string ZipCodeInput = "input[name='owner.address.zip']";

    }

    public static class ClaimsPriorInsuranceConstLocators
    {
        public const string YearsInBusinessInput = "input[name='policy.yearsInBusiness']";
        public const string LatestPolicyExpirationDateInput = "input[name='fields.data.policy.policyUnderwriting.policyUnderwritingInput$priorInsuranceLatestExpirationDate.value']";
        public const string PriorCarrierNameInput = "input[name='fields.data.policy.policyUnderwriting.policyUnderwritingInput$priorInsuranceLatestCarrier.value']";
        public const string NameOfCarrierInput = "input[contains(@name, 'otherInsuranceHistoryInput$carrierName')]";
        public const string PriorPolicyEffectiveDateInput = "input[contains(@name, 'otherInsuranceHistoryInput$effectiveDate.value')]";
        public const string PriorPolicyExpirationDateInput = "input[contains(@name, 'otherInsuranceHistoryInput$expirationDate.value')]";
        public const string AddRowButton = "//button[contains(@data-testid, 'otherInsuranceHistory.addOtherInsurance')]";
        public const string AddPriorClaimButton = "//button[contains(@data-testid, 'fields.data.policy.policyUnderwriting.underwritingLossExperience.addClaim')]";

    }

    public static class ClientDetailsPageConstLocators
    {
        public const string AddEntityButton = "xpath=.//button[contains(text(), 'Add Entity')]";
        public const string SelectAuditContactCheckbox = "xpath=.//mat-checkbox[contains(@data-testid, 'fields.primaryInsured.accountInput$isAuditContact.value')]";
        public const string SelectInspectionContactCheckbox = "xpath=.//mat-checkbox[contains(@data-testid, 'fields.primaryInsured.accountInput$isInspectionContact.value')]";
    }

    public static class NarrativePageConstLocators
    {
        public const string AddNarrativeButton = "xpath=.//button[contains(text(), 'Add Narrative')]";
        public const string CreateNarrativeInput = "textarea[contains(@name, 'notesInput$remarks')]";
    }
    public static class ProposalDetailsPageLocators
    {
        public const string PageHeader = "//h1[text()='Proposal Details']";

        // Insurance Products
        public const string PersonalAutoButton = "[id='proposal.product-0']";
        public const string MotorcycleButton = "[id='proposal.product-1']";
        public const string RecreationalVehicleButton = "[id='proposal.product-2']";
        public const string HomeButton = "[id='proposal.product-3']";
        public const string BusinessOwnerButton = "[id='proposal.product-4']";
        public const string FarmPackageButton = "[id='proposal.product-5']";

        // Quote Details
        public const string EffDateInput = "input[name='proposal.effectiveDate']";
        public const string ExpandPolicyTermDropdown = "xpath=.//mat-select[contains(@data-testid, 'proposal.term')]";
        public const string PolicyTermDropdownValue = "span.mat-select-value-text";
        public const string AgentPCCodeInput = "input[name='proposal.agentPC']";
        public const string SalesAssociatePCCodeInput = "input[name='proposal.associatePC']";
        public const string RatingStateDropdown = "mat-select[id='proposal.ratingState']";
        public const string WritingCompanyDropdownValue = "#proposal\\.writingCompany .mat-select-value-text .mat-select-min-line";// FIX THIS LOCATOR*******
        public const string RiskAddressRadioButton = "mat-radio-button[id='proposal.riskAddressSelection-0']";
        public const string AddNewRiskAddressRadioButton = "mat-radio-button[id='proposal.riskAddressSelection-1']";
        public const string StartQuoteButton = "//button[@id='startQuote']";
        public const string BusinessEntitySearchInput = "xpath=.//input[name='business.search.businessName']";
        public const string BusinessEntitySearchButton = "xpath=.//button[text()='Search']";
        public const string IndividuallyOwnedCheckbox = "xpath=.//mat-checkbox[contains(@data-testid, 'business.isIndividualDba')]";
        public const string DBANameInput = "xpath=.//input[contains(@name, 'business.individualDba')]";

        // Special Farm Package
        public const string FarmPackageSelectedIndicator = "xpath=.//button[contains(text(), 'Selected')]";
        public const string GrossFarmIncomeInput = "input[contains(@data-testid, 'grossFarmIncome']";
    }

    public static class BOPPrequalificationPageLocators
    {
        public const string PageHeader = "//h1[text()='Pre-Qualification']";
        public const string EligibilityRestrictionsSectionHeader = "//div[text()='Eligibility Restrictions']";
        // Have you or any household member ever had any of the following?
        public const string ClientHistoryQuestionText = "//div[text()='Have you or any household member ever had any of the following?']";
        public const string SearchAddClassCodeButton = "xpath=.//button[text()='Search/Add Class Code']";

        // Class Code Search
        public const string ClassCodeSearchInput = "input[name='temp.filter']";
        public const string ClassCodeSearchButton = "//button[data-testid='temp.filter--search']";
        public const string AddClassCodeButton = "//a[text()='Add']";
        public const string CancelClassCodeButton = "//a[text()='Cancel']";

        // Primary Occupancy Slider
        public const string PrimaryOccupancySlider = "xpath=.//mat-slide-toggle[contains(@data-testid, 'occupancyClass$isPrimaryClass')]";

    }

    public static class PrimaryInsuredPageLocators
    {
        public const string SelectPrimaryInsured = "xpath=.//button//div[contains(text(), 'Existing Client')]";
        public const string SearchPrimaryInsuredFirstNameInput = "input[name='temp.clientSearchFirstName']";
        public const string SearchPrimaryInsuredLastNameInput = "input[name='temp.clientSearchLastName']";
        public const string PrimaryInsuredSearchButton = "//button[text()='Search']";
    }

    public static class AddPrimaryInsuredPageLocators
    {
        public const string AddPrimaryInsuredFirstNameInput = "input[name='fields.data.account.accountInput$nameFirst.value']";
        public const string AddPrimaryInsuredMiddleNameInput = "input[name='fields.data.account.accountInput$nameMI.value']";
        public const string AddPrimaryInsuredLastNameInput = "input[name='fields.data.account.accountInput$nameLast.value']";
        public const string ExpandSuffixDropDown = "mat-select[data-testid='fields.data.account.accountInput$nameSuffix.value']";
        public const string AddPrimaryInsuredDOBInput = "input[name='fields.data.account.accountInput$dateOfBirth.value']";
        public const string ExpandCountryDropdown = "mat-select[data-testid='fields.data.account.accountInput$country.value']";
        public const string AddPrimaryInsuredMailingAddressInput = "input[name='fields.data.account.accountInput$address1.value']";
        public const string AddPrimaryInsuredAddress2Input = "input[name='fields.data.account.accountInput$address2.value']";
        public const string AddPrimaryInsuredCityInput = "input[name='fields.data.account.accountInput$address2.value']";
        public const string ExpandStateDropdown = "mat-select[data-testid='fields.data.account.accountInput$state.value']";
        public const string AddPrimaryInsuredZipCodeInput = "input[name='fields.data.account.accountInput$zipCode.value']";
        public const string AddPrimaryInsuredMobilePhoneInput = "input[name='fields.data.account.accountInput$mobilePhoneNumber.value']";
        public const string AddPrimaryInsuredBusinessPhoneInpute = "input[name='fields.data.account.accountInput$primaryPhone.value']";
        public const string AddPrimaryInsuredEmailAddressInput = "input[name='fields.data.account.accountInput$email.value']";
        public const string AddPrimaryInsuredFEINInput = "input[data-testid='fields.data.account.accountInput$fEIN.value']";
        public const string ClientSSNOnFile = "xpath=.//div[contains(@id, 'SSNDisplay')]"; // Read Only Field
    }
    
    public static class EditGeneralInformationPgeLocators
    {
        public const string DBAOrTANameInput = "input[name='fields.data.account.accountInput$dBAName.value']";
        public const string WebsiteInput = "input[name='fields.data.account.accountInput$websiteAddress.value']";
        public const string DescriptionOfSpecifiedOperationInput = "input[name='fields.data.account.policyOutput$descriptionOfOperations.value']";
        public const string NumberOfFullTimeEmployeesInput = "input[name='fields.data.account.lineInputNonShredded$numberOfEmployees.value']";
        public const string NumberOfPartTimeEmployeesInput = "input[name='fields.data.account.lineInputNonShredded$numberOfPartTimeEmployees.value']";
        public const string NumberOfSeasonalEmployeesInput = "input[name='fields.data.account.lineInputNonShredded$numberOfSeasonalEmployees.value']";

    }

    public static class EditLocationPageConstLocators
    {
        // Location #1 (Primary) section
        public const string LocationNicknameInput = "input[name='fields.data.account.location.locationInput$description.value']";
        public const string LocationAddress1Input = "input[data-testid='fields.data.account.location.locationInput$address1.value']";
        public const string LocationAddress2Input = "input[data-testid='fields.data.account.location.locationInput$address2.value']";
        public const string LocationCityInput = "input[data-testid='fields.data.account.location.locationInput$city.value']";
        public const string ExpandLocationStateDropdown = "mat-select[data-testid='fields.data.account.location.locationInput$state.value']";
        public const string LocationZipCodeInput = "input[data-testid='fields.data.account.location.locationInput$zipCode.value']";
        public const string LocationCountyInput = "input[data-testid='fields.data.account.location.locationInput$county.value']";
        public const string ExpandTerritoryDropdown = "mat-select[data-testid='fields.data.account.location.locationBusinessOwnersInput$territory.value']";
        public const string MilesFromFireDeptInput = "input[data-testid='fields.data.account.location.locationBusinessOwnersInput$milesFromFireDepartment.value']";
        public const string ExpandFeetFromHydrantDropdown = "mat-select[data-testid='fields.data.account.location.locationBusinessOwnersInput$feetFromHydrant.value']";
        public const string ExpandDistanceFromCoastDropdown = "mat-select[data-testid='fields.data.account.location.locationInput$coastDistanceCode.value']";
        public const string ExpandDistanceToBodyOfWaterDropdown = "mat-select[data-testid='fields.data.account.location.locationInput$waterDistanceCode.value']";
        public const string PublicProtectionClassInformation = "button[contains(@data-testid='PPC_AddressEntity')]";
    }

    public static class AddBuildingPageConstLocators
    {
        // Building #1 Section
        public const string ExpandLocationDropdown = "mat-select[contains(@data-testid, 'buildingInput$buildingLocationID.value']";
        public const string LableForReferenceInput = "input[contains(@name, 'buildingInput$labelForReference.value')]";
        public const string InsuredOccupancySqFtInput = "input[contains(@name, 'buildingInput$insuredOccupancySqFt.value')]";
        public const string TotalBuildingSqFtInput = "input[contains(@name, 'buildingInput$squareFtEq.value')]"; 
        public const string InsuredOccupancyPercentageInput = "input[contains(@data-testid, 'buildingOutput$insuredOccupancyPercentage.value')]";
        public const string SelectIncludeBuildingCoverageCheckbox = "button[contains(@data-testid, 'buildingInput$includeBuildingCoverage.value')]";
        public const string SelectFunctionalPersonalPropertyCheckbox = "button[contains(@data-testid, 'buildingInput$includeFunctionalPersonalProperty.value')]";
        public const string SelectHabitationalOccupancyCheckbox = "button[contains(@data-testid, 'buildingInput$habitationalOccupancyExists.value')]";

        // Personal Property Limit Calculator Section
        public const string AddInventoryButton = "button[contains(@data-testid, 'businessPersonalPropertyInventorySheet.addBPPInventory')]";

        // Class Codes Section
        public const string SelectAllCheckbox = "button[contains(@data-testid, '_temp.SelectAll')]";
        
        // Building Details Section
        public const string ExpandMoreOptionsDropdown = "button[contains(@data-testid, 'buildingInput$constructionCode.value-other')]";
        public const string ExpandFireBurglarAlarmDropdown = "mat-select[contains(@data-testid, 'buildingInput$fireBurglarAlarm.value')]";

        // Select any of the following which apply to this building 
        public const string SelectAmusementAreasCheckbox = "button[contains(@data-testid, 'covAmusementAreasInput$selected.value')]";
        public const string NumberOfAmusementAreasInput = "input[contains(@name, 'covAmusementAreasInput$numberOfAmusementAreas.value')]";
        public const string DescriptionOfAmusementAreaInput = "input[contains(@name, 'covAmusementAreasInput$descriptionOfAmusementArea.value')]";
        public const string SelectPlaygroundsCheckbox = "button[contains(@data-testid, 'covPlaygroundsInput$selected.value')]";
        public const string NumberOfPlaygroundsInput = "input[contains(@name, 'covPlaygroundsInput$numberOfPlaygrounds.value')]";
        public const string SelectSwimmingPoolsCheckbox = "button[contains(@data-testid, 'covSwimmingPoolInput$pools.value')]";
        public const string NumberOfSwimmingPoolsInput = "input[contains(@name, 'covSwimmingPoolInput$numberOfSwimmingPools.value')]";
        public const string SelectNoneOfTheAboveCheckbox = "button[contains(@data-testid, 'riskInput$amusementPlaygroundsPoolsNoneOfTheAbove.value')]";

        // Building Eligibility Questions Section
        public const string RestaurantsOrCookingFacilitiesCheckbox = "button[contains(@data-testid, 'buildingInput$anyRestaurantsOrCookingFacilitiesBuilding.value')]";
        public const string ApplicantInsuredNotSoleOccupantCheckbox = "button[contains(@data-testid, 'buildingInput$soleOccupantBuilding.value')]";
        public const string NoneOfTheAboveCheckbox = "button[contains(@data-testid, 'buildingInput$noneOfTheAboveUWQuestions.value')]";

    

    }

    public static class  BOPPolicyCoveragesPageConstLocators
    {
        public const string ExpandExtensionEndorsementDropdown = "input[data-testid='fields.data.policy.line.lineInput$extensionEndorsement.value']";
        public const string SelectAffinityGroupButton = "button[contains(@data-testid, 'fields.data.policy.line.lineInput$affinityGroupDiscount.value-0')]";
        public const string ExpandPerOccLiabLimitDropdown = "mat-select[data-testid='fields.data.policy.line.lineInput$liabilityPerOccurenceLimit.value']";
        public const string ExpandProdCompOpsAggDropdown = "mat-select[data-testid='fields.data.policy.line.lineInput$productsCompletedAggregateLimit.value']";
        public const string ExpandGenAggLimitDropdown = "mat-select[data-testid='fields.data.policy.line.lineInput$generalAggregateLimit.value']";
        public const string ExpandMedicalLimitDropdown = "mat-select[data-testid='fields.data.policy.line.lineInput$medicalExpensesLimit.value']";
        public const string ExpandLiabilityPropertyDamageDedDropdown = "mat-select[data-testid='fields.data.policy.line.lineInput$propertyDamageDeductible.value']";
        public const string ExpandPersonalAdvertisementLimitDropdown = "mat-select[data-testid='fields.data.policy.line.lineInput$personalAndAdvertisementLimit.value']";
        public const string ElectronicDataLimitInput = "input[data-testid='fields.data.policy.line.covLineElectronicDataInput$limit.value']";
        public const string SelectSellsLPGCheckbox = "button[data-testid='fields.data.policy.line.lineInput$liquefiedPetroleumTransportVM.value']";
        public const string SelectSnowOrIceRemovalCheckbox = "button[data-testid='fields.data.policy.line.lineInput$snowplowOperationVM.value']";
        public const string ExpandEmployeeDishonestyLimitDropdown = "mat-select[data-testid='fields.data.policy.line.covLineEmployeeDishonestyInput$limit.value']";
        public const string InterruptionOfComputerOperationsLimitInput = "input[data-testid='fields.data.policy.line.endLineInterruptionOfComputerOperationsBusinessIncomeAndExtraExpenseInput$limit.value']";
        public const string ExpandYear2000EndorsementDropdown = "mat-select[data-testid='fields.data.policy.line.endLineYear2000EndorsementInput$year2000EndorsementOption.value']";
        public const string AddBlanketCoverageButton = "button[data-testid='fields.data.policy.lineBlanket.goToBlanketCoverage']";
        public const string EditByLocationCheckbox = "mat-checkbox[data-testid='temp.EditLimitsByLocation']";
        public const string ExpandDeductibleFixedDollarDropdown = "mat-select[data-testid='fields.data.policy.line.lineInput$deductibleFixedDollar.value']";
        public const string ExpandWindstormHailPercentageDropdown = "mat-select[contains(@data-testid, 'locationBusinessOwnersInput$deductibleWindstormHailPercentage.value')]";
        public const string ExpandFireDepartmentServiceChargeDropdown = "mat-select[contains(@data-testid, 'locationBusinessOwnersInput$fireDepartmentServiceChargeLimit.value')]";
        public const string MoneyAndSecuritiesOnPremisesInput = "input[contains(@data-testid, 'locationBusinessOwnersInput$moneyAndSecuritiesOnPremisesLimit.value')]";
        public const string OffPremisesInput = "input[contains(@data-testid, 'locationBusinessOwnersInput$moneyAndSecuritiesOffPremisesLimit.value')]";
        public const string OutdoorSignsLimitInput = "input[contains(@data-testid, 'locationBusinessOwnersInput$outdoorSignsLimit.value')]";
        public const string WaterBackupSumpOverflowLimitInput = "input[contains(@data-testid, 'covLocWaterBackupAndSumpOverflowInput$limit.value')]";
        public const string BusinessIncomeExtraExpenseLimitInput = "input[contains(@data-testid, 'covLocWaterBackupAndSumpOverflowInput$businessIncomeExtraExpense.value')]";

    }
    public static class SSNPopUpLocators
    {
        public const string SSNPopup = "//mat-dialog-container//h2[text()=\"Enter the Client's Full SSN#\"]";
        public const string SSNInput = "input[id='ssn']";
        public const string SSNConfirmPopup = "//mat-dialog-container//h2[text()=\"Confirm the Client's SSN#\"]";
        public const string SSNConfirmButton = "//mat-dialog-container//a[contains(text(), 'Confirm')]";
        public const string SSNEditButton = "//mat-dialog-container//a[contains(text(), 'Edit')]";
    }

    public static class ClientExistsPopUpLocators
    {
        public const string ClientExistsPopup = "//mat-dialog-container//h2[text()=\"Client Already Exists\"]";
        public const string CreateNewClientButton = "//mat-dialog-container//a[contains(text(), 'Create New Account')]";
        public const string UseExistingAccountButton = "//mat-dialog-container//a[contains(text(), 'Use Existing Account')]";
    }


    public static class DriverSelectionPageLocators
    {
        public const string ExistingClientButton = "//button[.//div[text()='(Existing Client)']]";
        public const string AdditionalDriverButton = "/button[id='unlistedDriver']";
    }

    public static class DriverSummaryConstLocators
    {
        public const string PageHeader = "//h1[text()='Driver Summary']";
        public const string DriverNameSectionHeader = "//div[id='Driver_Headless.FullName-0-layout']";
        public const string FirstNameInput = "input[name='fields.line.driver.rows[0].driverInput$firstName.value']";
        public const string MiddleNameInput = "input[name='fields.line.driver.rows[0].driverInput$firstMiddleName.value']";
        public const string LastNameInput = "input[name='fields.line.driver.rows[0].driverInput$lastName.value']";
        public const string DateOfBirthInput = "input[name='fields.line.driver.rows[0].driverInput$dateOfBirth.value']";
        public const string PhoneNumberInput = "input[name='fields.line.driver.rows[0].driverInput$phoneNumber.value']";
        public const string EmailAddressInput = "input[name='fields.line.driver.rows[0].driverInput$email.value']";

        public const string EditSSNButton = "button[text()='Edit SSN#']";
        public const string DLStateDropdown = "mat-select[id='fields.line.driver.rows[0].driverInput$driversLicenseState.value']";
        public const string DLNumberInput = "input[name='fields.line.driver.rows[0].driverInput$driversLicenseNumber.value']";


        // Total Time Licensed in Current State
        public const string YearsLicensedInput = "input[name='fields.line.driver.rows[0].driverInput$yearsLicensedCurrentState.value']";
        public const string MonthsLicensedInput = "input[name='fields.line.driver.rows[0].driverInput$monthsLicensedCurrentState.value']";

        // Suffix Dropdown and Values
        public const string SuffixDropdown = "mat-select[id='fields.line.driver.rows[0].driverInput$suffix.value']";

        // Marital Status More Options Dropdown
        public const string MoreOptionsMaritalStatus = "xpath=.//*[contains(text(), 'Marital Status')]/following::button[.//div[text()='More Options']]";

        // Operator Status More Options Dropdown
        public const string MoreOptionsOperatorStatus = "xpath=.//label[contains(text(), 'Operator Status')]following-sibling::div//button[contains(., 'More Options']";

        // Prior Insurance
        public const string PriorCarrierNameInput = "xpath=//input[contains(@name, 'priorCarrierName')]";
        public const string PriorPolicyNumberInput = "xpath=.//mat-label[contains(text(), 'Prior Policy Number')]/following::input[1]";
        public const string PriorCarrierPrefill = "xpath=//div[contains(@id, 'PriorCarrierName')]//span[contains(@class, 'readonly-value')]";

        //Time with Prior Carrier
        public const string PriorYearsWithCarrierInput = "xpath=//input[contains(@id, 'yearsWithPriorCarrier')]";
        public const string PriorMonthsWithCarrierInput = "xpath=//input[contains(@id, 'monthsWithPriorCarrier')]";


        // MVR Pop-Up Window
        public const string MVRPopUpWindow = "xpath=//*[@id=\"mat-dialog-1\"]/ng-component/mat-dialog-content//*[@id=\"mat-dialog-1\"]";
        public const string MVRPopUpContinueButton = "xpath=//mat-dialog-container//a[contains(text(), 'Continue')]";
        public const string MVRPopUpBackToDetailsButton = "xpath=//button[@id='btnConfirmNo']";

        public const string PrefillDriverPageHeader = "xpath=/html/body/app-root/app-home/app-multi-quote-viewer/mat-tab-group/div/mat-tab-body[1]/div/app-quote-viewer/section/main/div/div/eq-dynamic-form/anico-form/ng-component/section/header/h1";
    }

    public static class VehicleSummaryConstLocators
    {

        // Vehicle info
        public const string SelectVehicles = "xpath=//button[contains(@id, 'unlistedVehicle')]";
        public const string Vehicle1Header = "xpath=//div[contains(text(), 'Vehicle 1')]";
        public const string VINNumber = "//*[@id='fields.line.risk.rows[0].vehicleInput$vIN.value']";
        public const string VehicleYearInput = "input[name='fields.line.risk.rows[0].vehicleInput$year.value']";
        public const string MakeInput = "input[name='fields.line.risk.rows[0].vehicleInput$make.value']";
        public const string ModelInput = "input[name='fields.line.risk.rows[0].vehicleInput$model.value']";
        public const string TrimInput = "input[name='fields.line.risk.rows[0].vehicleInput$description.value']";
        public const string PurchaseDateInput = "input[name='fields.line.risk.rows[0].vehicleInput$purchaseDate.value']";
        public const string OdometerReadingInput = "input[name='fields.line.risk.rows[0].vehicleInput$odometer.value']";
        public const string TotalAnnualMileageInput = "input[name='fields.line.risk.rows[0].vehicleInput$annualMileage.value']";
        

        // VIN Populated Vehicle Information (Read Only Fields)
        public const string VehicleYearReadOnly = "xpath=//span[contains(text(), 'Year:')]/following-sibling::span[@class='readonly-value']";
        public const string MakeReadOnly = "xpath=//span[contains(text(), 'Make:')]/following-sibling::span[@class='readonly-value']";
        public const string ModelReadOnly = "xpath=//span[contains(text(), 'Model:')]/following-sibling::span[@class='readonly-value']";
        public const string TrimReadOnly = "xpath=//span[contains(text(), 'Trim:')]/following-sibling::span[@class='readonly-value']";
        /// <summary>
        /// ^^^ Check locators for read only fields above ^^^
        /// </summary>
    }

    public static class ClaimsAndViolationsConstLocators
    {
        public const string NoClaimsBanner = "xpath=//main[contains(., 'Claims')]//div[contains(text(), 'No claims were found on reports')]";
        public const string NoViolationsBanner = "xpath=//main[contains(., 'Violations')]//div[contains(text(), 'No violations were found on reports')]";
        public const string AddClaimsButton = "xpath=//button[contains(@data-testid, 'add_Claim')]";
        public const string AddViolationsButton = "xpath=//button[contains(@data-testid, 'add_Violation')]";
    }

    public static class PolicyCoveragesConstLocators
    {
        public const string ViewPriorCarrierDetailsButton = "xpath=.//button[contains(text(), 'VIEW PRIOR CARRIER DETAILS')]";
    }

    public static class AdditionalCoveragesConstLocators
    {
        public const string RentedMotorHomesCheckbox = "xpath=.//button[contains(@data-testid, 'RentedMotorHomeTravelTrailer')]";
        public const string AddedCoverageEndorsementCheckbox = "xpath=.//button[contains(@data-testid, 'addedCoverageEndorsement')]";
        public const string SoundReceivingEquipmentCheckbox = "xpath=.//button[contains(@data-testid, 'SoundRec')]";
    }

    internal class PricingDetailsConstLocators
    {
        public const string AccountOwner = "xpath=.//div[contains(@id, 'AccountOwner')]//span[contains(@class, 'readonly-value')]";
        public const string AccountAddress = "xpath=.//div[contains(@id, 'FullAccountAddress')]//span[contains(@class, 'readonly-value')]";
        public const string ProposalButton = "xpath=.//button[contains(text(), 'Proposal')]";
        public const string CoverageOptionOverviewButton = "xpath=.//button[contains(text(), 'Coverage Option Overview')]";
    }

    public static class AdditionalInterestLocators
    {
        public const string AddAdditionalInterestButton = "xpath=.//button[contains(@data-testid, 'add_Additional_Interest')]";
        public const string AdditionalInterestNameInput = "input[name='fields.account.additionalOtherInterest.additionalOtherInterestInput$name.value']";
        public const string AdditionalInterestAddressInput = "input[name='fields.account.additionalOtherInterest.additionalOtherInterestInput$address1.value']";
        public const string AdditionalInterestCityInput = "input[name='fields.account.additionalOtherInterest.additionalOtherInterestInput$city.value']";
        public const string AdditionalInterestStateDropdown = "xpath=//mat-select[contains(@id, 'additionalOtherInterestInput$state.value')]//div[contains(@class, 'mat-select-arrow')]";
        public const string AdditionalInterestZipInput = "input[name='fields.account.additionalOtherInterest.additionalOtherInterestInput$zipCode.value']";
        public const string AdditionalInterestPhoneInput = "input[name='fields.account.additionalOtherInterest.additionalOtherInterestInput$primaryPhone.value']";
        public const string RelationshipToAccountHolderInput = "input[name='fields.account.additionalOtherInterest.additionalOtherInterestInput$relationshipToInsured.value']";
        public const string AdditionalInterestDOBInput = "input[name='fields.account.additionalOtherInterest.additionalOtherInterestInput$ownerDateOfBirth.value']";
        public const string AdditionalInterestDLNumberInput = "input[name='fields.account.additionalOtherInterest.additionalOtherInterestInput$ownerDriversLicenseNumber.value']";
        public const string AdditionalInterestLicenseState = "xpath=//mat-select[contains(@id, 'ownerLicenseState')]//div[contains(@class, 'mat-select-arrow')]";
        public const string UWRulesDialogContinueButton = "xpath=//mat-dialog-container//a[contains(text(), 'Continue')]";
    }

    public static class BillingInformationConstLocators
    {
        public const string CreateNewBillingAccountButton = "xpath=.//button//div[contains(text(), 'Create New Billing Account')]";
        public const string PaymentDueDateInput = "input[name='fields._PolicyPaymentInputDoc.subsequentPaymentData$dueDate.value']";
        public const string ApplyRefundChecbox = "xpath=.//mat-checkbox//div[contains(text(), 'Apply Refund')]";
        public const string CheckNumberInput = "input[name='fields._PolicyPaymentInputDoc.initialPaymentData$checkNumber.value']";
    }

   
}
