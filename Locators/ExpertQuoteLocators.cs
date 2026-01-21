using Microsoft.Playwright;
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
        public static ILocator NextButton(IPage page) => page.GetByTestId("next");
        public static ILocator MoreOptionsButton(IPage page) => page.GetByTestId("owner.maritalStatus-other");
        public static ILocator DialogSubmitButton(IPage page) => page.GetByTestId("btnConfirmYes");
        public static ILocator DialogCancelButton(IPage page) => page.GetByTestId("btnConfirmNo");
        public const string SaveAndContinueButton = "xpath=.//button[contains(text(), 'Save and Continue')]";
        public const string CancelButton = "xpath=.//button[contains(text(), 'Cancel')]";
        public const string QuoteNumber = "xpath=//div[contains(@class, 'mat-tab-label-container')]//span";
        public const string SaveButton = "xpath=.//button[contains(text(), 'Save')]";
    }

    public static class LoginLocators
    {
        public static ILocator UsernameInput(IPage page) => page.GetByPlaceholder("Username");
        public static ILocator PasswordInput(IPage page) => page.GetByPlaceholder("Password");
        public static ILocator  LoginButton(IPage page) => page.GetByTitle("Sign On");
    }
   
    public static class ClientSearchLocators
    {
        public static ILocator DashboardElement(IPage page) => page.GetByText("Quote");
        public static ILocator ClientSearchPage(IPage page) => page.GetByText("Search / Recently Accessed");
        public static ILocator IndividualSearchField(IPage page) => page.GetByTestId("quoteSearchInput");
        public static ILocator ClientSearchButton(IPage page) => page.GetByTestId("quoteSearchButton");
        public static ILocator NewQuoteButton(IPage page) => page.GetByText("New Quote");
    }

    public static class NewExistingClientSearchLocators
    {
        public static ILocator FirstNameInput(IPage page) => page.GetByTestId("customer.name.first");
        public static ILocator LastNameInput(IPage page) => page.GetByTestId("customer.name.last");
        public static ILocator DateOfBirthInput(IPage page) => page.GetByLabel("Date of Birth");
        public static ILocator DateOfBirthCalendarIcon(IPage page) => page.GetByLabel("Open calendar");
        public static ILocator BestPhoneInput(IPage page) => page.GetByTestId("customer.phone");
        public static ILocator EmailAddressInput(IPage page) => page.GetByTestId("customer.email");
        public static ILocator SearchButton(IPage page) => page.GetByTestId("clientSearch");
        public static ILocator CreateNewClientButton(IPage page) => page.GetByText("Create New Client");
    }

    public static class AccountInformationConstLocators
    {
        // Account Owner Information
        public static ILocator PageHeader(IPage page) => page.GetByText("Account Information");
        public static ILocator FirstName(IPage page) => page.GetByTestId("owner.name.first");
        public static ILocator MiddelName(IPage page) => page.GetByTestId("owner.name.middle");
        public static ILocator LastName(IPage page) => page.GetByTestId("owner.name.last");
        public static ILocator DateOfBirth(IPage page) => page.GetByLabel("Date of Birth");
        public static ILocator BestPhone(IPage page) => page.GetByTestId("owner.phone");
        public static ILocator EmailAddress(IPage page) => page.GetByTestId("owner.email");



        // Account/Mailing Address Information
        public static ILocator StreetAddressInput(IPage page) => page.GetByPlaceholder("Enter a location");
        public static ILocator AptNumberInput(IPage page) => page.GetByTestId("owner.address.line2");
        public static ILocator CityInput(IPage page) => page.GetByTestId("owner.address.city");
        public static ILocator StateDropdown(IPage page) => page.GetByTestId("owner.address.state");
        public static ILocator ZipCodeInput(IPage page) => page.GetByTestId("owner.address.zip");

    }

    public static class ClaimsPriorInsuranceConstLocators
    {
        public const string YearsInBusinessInput = "input[name='policy.yearsInBusiness']";
        public const string LatestPolicyExpirationDateInput = "input[name='fields.data.policy.policyUnderwriting.policyUnderwritingInput$priorInsuranceLatestExpirationDate.value']";
        public const string PriorCarrierNameInput = "input[name='fields.data.policy.policyUnderwriting.policyUnderwritingInput$priorInsuranceLatestCarrier.value']";
        public const string NameOfCarrierInput = "input[contains(@name, 'otherInsuranceHistoryInput$carrierName')]";
        public const string PriorPolicyEffectiveDateInput = "input[contains(@name, 'otherInsuranceHistoryInput$effectiveDate.value')]";
        public const string PriorPolicyExpirationDateInput = "input[contains(@name, 'otherInsuranceHistoryInput$expirationDate.value')]";
        public static ILocator AddRowButton(IPage page) => page.GetByTestId("otherInsuranceHistory.addOtherInsurance");
        public static ILocator AddPriorClaimButton(IPage page) => page.GetByTestId("fields.data.policy.policyUnderwriting.underwritingLossExperience.addClaim");

    }

    public static class ClientDetailsPageConstLocators
    {
        public const string AddEntityButton = "xpath=.//button[contains(text(), 'Add Entity')]";
        public static ILocator SelectAuditContactCheckbox(IPage page) => page.GetByTestId("fields.primaryInsured.accountInput$isAuditContact.value");
        public static ILocator SelectInspectionContactCheckbox(IPage page) => page.GetByTestId("fields.primaryInsured.accountInput$isInspectionContact.value");
    }

    public static class NarrativePageConstLocators
    {
        public const string AddNarrativeButton = "xpath=.//button[contains(text(), 'Add Narrative')]";
        public const string CreateNarrativeInput = "textarea[contains(@name, 'notesInput$remarks')]";
    }
    public static class ProposalDetailsPageLocators
    {
        public static ILocator PageHeader(IPage page) => page.GetByText("Proposal Details");

        // Insurance Products
        public static ILocator PersonalAutoButton(IPage page) => page.GetByTestId("proposal.product-0");
        public static ILocator MotorcycleButton(IPage page) => page.GetByTestId("proposal.product-1");
        public static ILocator RecreationalVehicleButton(IPage page) => page.GetByTestId("proposal.product-2");
        public static ILocator HomeButton(IPage page) => page.GetByTestId("proposal.product-3");
        public static ILocator BusinessOwnerButton(IPage page) => page.GetByTestId("proposal.product-4");
        public static ILocator FarmPackageButton(IPage page) => page.GetByTestId("proposal.product-5");

        // Quote Details
        public static ILocator EffDateInput(IPage page) => page.GetByLabel("Effetive Date");
        public static ILocator ExpandPolicyTermDropdown(IPage page) => page.GetByTestId("proposal.term");
        public static ILocator PolicyTermDropdownValue(IPage page) => page.GetByTestId("proposal.term");
        public static ILocator AgentPCCodeInput(IPage page) => page.GetByTestId("proposal.agentPC");
        public static ILocator SalesAssociatePCCodeInput(IPage page) => page.GetByTestId("proposal.associatePC");
        public static ILocator RatingStateDropdown(IPage page) => page.GetByTestId("proposal.ratingState");
        public static ILocator WritingCompanyDropdownValue(IPage page) => page.GetByTestId("proposal.writingCompany");
        public const string RiskAddressRadioButton = "mat-radio-button[id='proposal.riskAddressSelection-0']"; ///REVISIT LOCATOR
        public const string AddNewRiskAddressRadioButton = "mat-radio-button[id='proposal.riskAddressSelection-1']";///REVISIT LOCATOR
        public static ILocator StartQuoteButton(IPage page) => page.GetByTestId("startQuote");
        public const string BusinessEntitySearchInput = "xpath=.//input[name='business.search.businessName']";
        public const string BusinessEntitySearchButton = "xpath=.//button[text()='Search']";
        public static ILocator IndividuallyOwnedCheckbox(IPage page) => page.GetByTestId("business.isIndividualDba");
        public static ILocator DBANameInput(IPage page) => page.GetByTestId("business.individualDba");

        // Special Farm Package
        public static ILocator FarmPackageSelectedIndicator(IPage page) => page.GetByTestId("sfp-button");
        public static ILocator GrossFarmIncomeInput(IPage page) => page.GetByTestId("grossFarmIncome");
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
        public static ILocator ClassCodeSearchButton(IPage page) => page.GetByTestId("temp.filter--search");
        public const string AddClassCodeButton = "//a[text()='Add']";
        public const string CancelClassCodeButton = "//a[text()='Cancel']";

        // Primary Occupancy Slider
        public static ILocator PrimaryOccupancySlider(IPage page) => page.GetByTestId("occupancyClass$isPrimaryClass");

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
        public static ILocator ExpandSuffixDropDown(IPage page) => page.GetByTestId("fields.data.account.accountInput$nameSuffix.value");
        public const string AddPrimaryInsuredDOBInput = "input[name='fields.data.account.accountInput$dateOfBirth.value']";
        public static ILocator ExpandCountryDropdown(IPage page) => page.GetByTestId("fields.data.account.accountInput$country.value");
        public const string AddPrimaryInsuredMailingAddressInput = "input[name='fields.data.account.accountInput$address1.value']";
        public const string AddPrimaryInsuredAddress2Input = "input[name='fields.data.account.accountInput$address2.value']";
        public const string AddPrimaryInsuredCityInput = "input[name='fields.data.account.accountInput$address2.value']";
        public static ILocator ExpandStateDropdown(IPage page) => page.GetByTestId("fields.data.account.accountInput$state.value");
        public const string AddPrimaryInsuredZipCodeInput = "input[name='fields.data.account.accountInput$zipCode.value']";
        public const string AddPrimaryInsuredMobilePhoneInput = "input[name='fields.data.account.accountInput$mobilePhoneNumber.value']";
        public const string AddPrimaryInsuredBusinessPhoneInpute = "input[name='fields.data.account.accountInput$primaryPhone.value']";
        public const string AddPrimaryInsuredEmailAddressInput = "input[name='fields.data.account.accountInput$email.value']";
        public static ILocator AddPrimaryInsuredFEINInput(IPage page) => page.GetByTestId("fields.data.account.accountInput$fEIN.value");
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
        public static ILocator LocationAddress1Input(IPage page) => page.GetByTestId("fields.data.account.location.locationInput$address1.value");
        public static ILocator LocationAddress2Input(IPage page) => page.GetByTestId("fields.data.account.location.locationInput$address2.value");
        public static ILocator LocationCityInput(IPage page) => page.GetByTestId("fields.data.account.location.locationInput$city.value");
        public static ILocator ExpandLocationStateDropdown(IPage page) => page.GetByTestId("fields.data.account.location.locationInput$state.value");
        public static ILocator LocationZipCodeInput(IPage page) => page.GetByTestId("fields.data.account.location.locationInput$zipCode.value");
        public static ILocator LocationCountyInput(IPage page) => page.GetByTestId("fields.data.account.location.locationInput$county.value");
        public static ILocator ExpandTerritoryDropdown(IPage page) => page.GetByTestId("fields.data.account.location.locationBusinessOwnersInput$territory.value");
        public static ILocator MilesFromFireDeptInput(IPage page) => page.GetByTestId("fields.data.account.location.locationBusinessOwnersInput$milesFromFireDepartment.value");
        public static ILocator ExpandFeetFromHydrantDropdown(IPage page) => page.GetByTestId("fields.data.account.location.locationBusinessOwnersInput$feetFromHydrant.value");
        public static ILocator ExpandDistanceFromCoastDropdown(IPage page) => page.GetByTestId("fields.data.account.location.locationInput$coastDistanceCode.value");
        public static ILocator ExpandDistanceToBodyOfWaterDropdown(IPage page) => page.GetByTestId("fields.data.account.location.locationInput$waterDistanceCode.value");
        public static ILocator PublicProtectionClassInformation(IPage page) => page.GetByTestId("PPC_AddressEntity");
    }

    public static class AddBuildingPageConstLocators
    {
        // Building #1 Section
        public static ILocator ExpandLocationDropdown(IPage page) => page.GetByTestId("buildingInput$buildingLocationID.value");
        public const string LableForReferenceInput = "input[contains(@name, 'buildingInput$labelForReference.value')]";
        public const string InsuredOccupancySqFtInput = "input[contains(@name, 'buildingInput$insuredOccupancySqFt.value')]";
        public const string TotalBuildingSqFtInput = "input[contains(@name, 'buildingInput$squareFtEq.value')]"; 
        public static ILocator InsuredOccupancyPercentageInput(IPage page) => page.GetByTestId("buildingOutput$insuredOccupancyPercentage.value");
        public static ILocator SelectIncludeBuildingCoverageCheckbox(IPage page) => page.GetByTestId("buildingInput$includeBuildingCoverage.value");
        public static ILocator SelectFunctionalPersonalPropertyCheckbox(IPage page) => page.GetByTestId("buildingInput$includeFunctionalPersonalProperty.value");
        public static ILocator SelectHabitationalOccupancyCheckbox(IPage page) => page.GetByTestId("buildingInput$habitationalOccupancyExists.value");

        // Personal Property Limit Calculator Section
        public static ILocator AddInventoryButton(IPage page) => page.GetByTestId("businessPersonalPropertyInventorySheet.addBPPInventory");

        // Class Codes Section
        public static ILocator SelectAllCheckbox(IPage page) => page.GetByTestId("_temp.SelectAll");
        
        // Building Details Section
        public static ILocator ExpandMoreOptionsDropdown(IPage page) => page.GetByTestId("buildingInput$constructionCode.value-other");
        public static ILocator ExpandFireBurglarAlarmDropdown(IPage page) => page.GetByTestId("buildingInput$fireBurglarAlarm.value'");

        // Select any of the following which apply to this building 
        public static ILocator SelectAmusementAreasCheckbox(IPage page) => page.GetByTestId("covAmusementAreasInput$selected.value");
        public const string NumberOfAmusementAreasInput = "input[contains(@name, 'covAmusementAreasInput$numberOfAmusementAreas.value')]";
        public const string DescriptionOfAmusementAreaInput = "input[contains(@name, 'covAmusementAreasInput$descriptionOfAmusementArea.value')]";
        public static ILocator SelectPlaygroundsCheckbox(IPage page) => page.GetByTestId("covPlaygroundsInput$selected.value");
        public const string NumberOfPlaygroundsInput = "input[contains(@name, 'covPlaygroundsInput$numberOfPlaygrounds.value')]";
        public static ILocator SelectSwimmingPoolsCheckbox(IPage page) => page.GetByTestId("covSwimmingPoolInput$pools.value");
        public const string NumberOfSwimmingPoolsInput = "input[contains(@name, 'covSwimmingPoolInput$numberOfSwimmingPools.value')]";
        public static ILocator SelectNoneOfTheAboveCheckbox(IPage page) => page.GetByTestId("riskInput$amusementPlaygroundsPoolsNoneOfTheAbove.value");

        // Building Eligibility Questions Section
        public static ILocator RestaurantsOrCookingFacilitiesCheckbox(IPage page) => page.GetByTestId("buildingInput$anyRestaurantsOrCookingFacilitiesBuilding.value");
        public static ILocator ApplicantInsuredNotSoleOccupantCheckbox(IPage page) => page.GetByTestId("buildingInput$soleOccupantBuilding.value");
        public static ILocator NoneOfTheAboveCheckbox(IPage page) => page.GetByTestId("buildingInput$noneOfTheAboveUWQuestions.value");

    

    }

    public static class  BOPPolicyCoveragesPageConstLocators
    {
        public static ILocator ExpandExtensionEndorsementDropdown(IPage page) => page.GetByTestId("fields.data.policy.line.lineInput$extensionEndorsement.value");
        public static ILocator SelectAffinityGroupButton(IPage page) => page.GetByTestId("fields.data.policy.line.lineInput$affinityGroupDiscount.value-0");
        public static ILocator ExpandPerOccLiabLimitDropdown(IPage page) => page.GetByTestId("fields.data.policy.line.lineInput$liabilityPerOccurenceLimit.value");
        public static ILocator ExpandProdCompOpsAggDropdown(IPage page) => page.GetByTestId("fields.data.policy.line.lineInput$productsCompletedAggregateLimit.value");
        public static ILocator ExpandGenAggLimitDropdown(IPage page) => page.GetByTestId("fields.data.policy.line.lineInput$generalAggregateLimit.value");
        public static ILocator ExpandMedicalLimitDropdown(IPage page) => page.GetByTestId("fields.data.policy.line.lineInput$medicalExpensesLimit.value");
        public static ILocator ExpandLiabilityPropertyDamageDedDropdown(IPage page) => page.GetByTestId("fields.data.policy.line.lineInput$propertyDamageDeductible.value");
        public static ILocator ExpandPersonalAdvertisementLimitDropdown(IPage page) => page.GetByTestId("fields.data.policy.line.lineInput$personalAndAdvertisementLimit.value");
        public static ILocator ElectronicDataLimitInput(IPage page) => page.GetByTestId("fields.data.policy.line.covLineElectronicDataInput$limit.value");
        public static ILocator SelectSellsLPGCheckbox(IPage page) => page.GetByTestId("fields.data.policy.line.lineInput$liquefiedPetroleumTransportVM.value");
        public static ILocator SelectSnowOrIceRemovalCheckbox(IPage page) => page.GetByTestId("fields.data.policy.line.lineInput$snowplowOperationVM.value");
        public static ILocator ExpandEmployeeDishonestyLimitDropdown(IPage page) => page.GetByTestId("fields.data.policy.line.covLineEmployeeDishonestyInput$limit.value");
        public static ILocator InterruptionOfComputerOperationsLimitInput(IPage page) => page.GetByTestId("fields.data.policy.line.endLineInterruptionOfComputerOperationsBusinessIncomeAndExtraExpenseInput$limit.value");
        public static ILocator ExpandYear2000EndorsementDropdown(IPage page) => page.GetByTestId("fields.data.policy.line.endLineYear2000EndorsementInput$year2000EndorsementOption.value");
        public static ILocator AddBlanketCoverageButton(IPage page) => page.GetByTestId("fields.data.policy.lineBlanket.goToBlanketCoverage");
        public static ILocator EditByLocationCheckbox(IPage page) => page.GetByTestId("temp.EditLimitsByLocation");
        public static ILocator ExpandDeductibleFixedDollarDropdown(IPage page) => page.GetByTestId("fields.data.policy.line.lineInput$deductibleFixedDollar.value");
        public static ILocator ExpandWindstormHailPercentageDropdown(IPage page) => page.GetByTestId("locationBusinessOwnersInput$deductibleWindstormHailPercentage.value");
        public static ILocator ExpandFireDepartmentServiceChargeDropdown(IPage page) => page.GetByTestId("locationBusinessOwnersInput$fireDepartmentServiceChargeLimit.value");
        public static ILocator MoneyAndSecuritiesOnPremisesInput(IPage page) => page.GetByTestId("locationBusinessOwnersInput$moneyAndSecuritiesOnPremisesLimit.value");
        public static ILocator OffPremisesInput(IPage page) => page.GetByTestId("locationBusinessOwnersInput$moneyAndSecuritiesOffPremisesLimit.value");
        public static ILocator OutdoorSignsLimitInput(IPage page) => page.GetByTestId("locationBusinessOwnersInput$outdoorSignsLimit.value");
        public static ILocator WaterBackupSumpOverflowLimitInput(IPage page) => page.GetByTestId("covLocWaterBackupAndSumpOverflowInput$limit.value");
        public static ILocator BusinessIncomeExtraExpenseLimitInput(IPage page) => page.GetByTestId("covLocWaterBackupAndSumpOverflowInput$businessIncomeExtraExpense.value");

    }
    public static class SSNPopUpLocators
    {
        public static ILocator SSNPopup(IPage page) => page.GetByRole(AriaRole.Heading, new() {Name = "Enter the Client's Full SSN#"});
        public static ILocator SSNInput(IPage page) => page.GetByTestId("ssn");
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
