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
        public static ILocator MoreOptionsButton(IPage page) => page.GetByTestId("owner.maritalStatus-other");
        public static ILocator DialogSubmitButton(IPage page) => page.GetByTestId("btnConfirmYes");
        public static ILocator DialogCancelButton(IPage page) => page.GetByTestId("btnConfirmNo");
        public static ILocator SaveAndContinueButton(IPage page) => page.GetByTestId("fields.line.save_and_Continue");
        public const string CancelButton = "xpath=.//button[contains(text(), 'Cancel')]";
        public const string QuoteNumber = "xpath=//div[contains(@class, 'mat-tab-label-container')]//span";
        public static ILocator SaveButton(IPage page) => page.GetByTestId("fields.data_Actions.save") ;
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
        public static ILocator NewQuoteButton(IPage page) => page.GetByRole(AriaRole.Button, new() { Name = "New Quote" });
    }

    public static class NewExistingClientSearchLocators
    {
        public static ILocator FirstNameInput(IPage page) => page.GetByTestId("customer.name.first");
        public static ILocator LastNameInput(IPage page) => page.GetByTestId("customer.name.last");
        public static ILocator DateOfBirthInput(IPage page) => page.Locator("input[name='customer.dateOfBirth']");
        public static ILocator DateOfBirthCalendarIcon(IPage page) => page.GetByLabel("Open calendar");
        public static ILocator BestPhoneInput(IPage page) => page.GetByTestId("customer.phone");
        public static ILocator EmailAddressInput(IPage page) => page.GetByTestId("customer.email");
        public static ILocator SearchButton(IPage page) => page.GetByTestId("clientSearch");
        public static ILocator CreateNewClientButton(IPage page) => page.GetByRole(AriaRole.Button, new() { Name = "CREATE NEW CLIENT" });
    }

    public static class AccountInformationConstLocators
    {
        // Account Owner Information
        public static ILocator PageHeader(IPage page) => page.GetByRole(AriaRole.Heading, new() {  Name = "Account Information", Exact = true});
        public static ILocator FirstName(IPage page) => page.GetByTestId("owner.name.first");
        public static ILocator MiddelName(IPage page) => page.GetByTestId("owner.name.middle");
        public static ILocator LastName(IPage page) => page.GetByTestId("owner.name.last");
        public static ILocator DateOfBirth(IPage page) => page.Locator("input[name='owner.dateOfBirth']");
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
        public static ILocator EffDateInput(IPage page) => page.Locator("input[name='proposal.effectiveDate']");
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
        public static ILocator GrossFarmIncomeInput(IPage page) => page.GetByTestId("fields.account.policyInput$grossFarmIncome.value");
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

    public static class PrimaryInsuredPageConstLocators
    {
        public static ILocator SelectExistingClient(IPage page) => page.GetByTestId("temp.clientSuggestions-0");
        public const string SearchPrimaryInsuredFirstNameInput = "input[name='temp.clientSearchFirstName']";
        public const string SearchPrimaryInsuredLastNameInput = "input[name='temp.clientSearchLastName']";
        public const string PrimaryInsuredSearchButton = "//button[text()='Search']";
    }

    public static class AddPrimaryInsuredPageLocators
    {
        public static ILocator AddPrimaryInsuredFirstNameInput(IPage page) => page.GetByTestId("fields.account.accountInput$nameFirst.value");
        public static ILocator AddPrimaryInsuredMiddleNameInput(IPage page) => page.GetByTestId("fields.account.accountInput$nameMiddle.value");
        public static ILocator AddPrimaryInsuredLastNameInput(IPage page) => page.GetByTestId("fields.account.accountInput$nameLast.value");
        public static ILocator ExpandSuffixDropDown(IPage page) => page.GetByTestId("fields.account.accountInput$nameSuffix.value");
        public static ILocator AddPrimaryInsuredDOBInput(IPage page) => page.Locator("input[name='fields.account.accountInput$dateOfBirth.value']");
        public static ILocator ExpandCountryDropdown(IPage page) => page.GetByTestId("fields.account.accountInput$country.value");
        public static ILocator AddPrimaryInsuredMailingAddressInput(IPage page) => page.Locator("input[name='fields.account.accountInput$address1.value']");
        public static ILocator AddPrimaryInsuredAddress2Input(IPage page) => page.GetByTestId("fields.account.accountInput$address2.value");
        public static ILocator AddPrimaryInsuredCityInput(IPage page) => page.GetByTestId("fields.account.accountInput$city.value");
        public static ILocator ExpandStateDropdown(IPage page) => page.GetByTestId("fields.account.accountInput$state.value");
        public static ILocator StateValueReadOnly(IPage page) => page.GetByTestId("fields.account.accountInput$state.value").Locator("mat-select-value");

        public static ILocator AddPrimaryInsuredZipCodeInput(IPage page) => page.GetByTestId("fields.account.accountInput$zipCode.value");
        public static ILocator AddPrimaryInsuredMobilePhoneInput(IPage page) => page.GetByTestId("fields.account.accountInput$mobilePhone.value");
        public static ILocator AddPrimaryInsuredBusinessPhoneInput(IPage page) => page.GetByTestId("fields.account.accountInput$businessPhone.value");
        public static ILocator AddPrimaryInsuredPrimaryPhoneInput(IPage page) => page.GetByTestId("fields.account.accountInput$primaryPhone.value");
        public static ILocator AddPrimaryInsuredEmailAddressInput(IPage page) => page.GetByTestId("fields.account.accountInput$email.value");
        public static ILocator AddPrimaryInsuredFEINInput(IPage page) => page.GetByTestId("fields.account.accountInput$fEIN.value");
        public static ILocator ClientSSNOnFile(IPage page) => page.GetByText("Social Security #:", new() { Exact = true })
                                                                .Locator("..")
                                                                .Locator(".readonly-value"); // Read Only Field
    }

    public static class ValidatePrimaryInsuredInfoLocators
    {

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
        public static ILocator ExistingClientButton(IPage page) => page.GetByRole(AriaRole.Button, new() { Name = "(Existing Client)" });
        public const string AdditionalDriverButton = "/button[id='unlistedDriver']";
    }

    public static class DriverSummaryConstLocators
    {
        public static ILocator PageHeader(IPage page) => page.GetByRole(AriaRole.Heading, new() { Name = "Driver Summary" });
        public static ILocator DriverNameSectionHeader(IPage page, string driverName) => page.GetByText(driverName, new() { Exact = true });

        public static ILocator FirstNameInput(IPage page) => page.GetByLabel("First Name");
        public static ILocator MiddleNameInput(IPage page) => page.GetByLabel("Middle Name");
        public static ILocator LastNameInput(IPage page) => page.GetByLabel("Last Name");
        public static ILocator DateOfBirthInput(IPage page) => page.GetByLabel("Date Of Birth");
        public static ILocator PhoneNumberInput(IPage page) => page.GetByLabel("Phone Number");
        public static ILocator EmailAddressInput(IPage page) => page.GetByLabel("Email Address");

        public static ILocator EditSSNButton(IPage page) => page.GetByRole(AriaRole.Button, new() { Name = "Edit SSN#" });
        public static ILocator DLStateDropdown(IPage page) => page.GetByRole(AriaRole.Combobox, new() { Name = "Driver's License State" });
        public static ILocator DLNumberInput(IPage page) => page.GetByLabel("Driver's License Number");


        // Total Time Licensed in Current State
        public static ILocator YearsLicensedInput(IPage page) => page.GetByLabel("Years");
        public static ILocator MonthsLicensedInput(IPage page) => page.GetByLabel("Months");

        // Suffix Dropdown and Values
        public static ILocator SuffixDropdown(IPage page) => page.GetByRole(AriaRole.Combobox, new() { Name = "Suffix" });

        // Marital Status More Options Dropdown
        public static ILocator MoreOptionsMaritalStatus(IPage page) => page.Locator("[data-testid*='maritalStatus.value-other']");

        // Operator Status More Options Dropdown
        public static ILocator MoreOptionsOperatorStatus(IPage page) => page.Locator("[data-testid*='operatorStatuc.value-other']");

        // Prior Insurance
        public static ILocator PriorCarrierNameInput(IPage page) => page.Locator("[data-testid*='priorCarrierName']");
        public static ILocator PriorPolicyNumberInput(IPage page) => page.Locator("[data-testid*='priorPolicyNumber']");
        public const string PriorCarrierPrefill = "xpath=//div[contains(@id, 'PriorCarrierName')]//span[contains(@class, 'readonly-value')]";

        //Time with Prior Carrier
        public static ILocator PriorYearsWithCarrierInput(IPage page) => page.Locator("[data-testid*='yearsWithPriorCarrier']");
        public static ILocator PriorMonthsWithCarrierInput(IPage page) => page.Locator("[data-testid*='monthsWithPriorCarrier']");


        // MVR Pop-Up Window
        public static ILocator MVRPopUpWindow(IPage page) => page.GetByRole(AriaRole.Dialog).Filter(new() { Has = page.Locator("[aria-modal='true']") });

        public static ILocator MVRPopUpContinueButton(IPage page) => page.GetByTestId("btnConfirmYes");
        public static ILocator MVRPopUpBackToDetailsButton(IPage page) => page.GetByTestId("btnConfirmNo");

        public const string PrefillDriverPageHeader = "xpath=/html/body/app-root/app-home/app-multi-quote-viewer/mat-tab-group/div/mat-tab-body[1]/div/app-quote-viewer/section/main/div/div/eq-dynamic-form/anico-form/ng-component/section/header/h1";
    }

    public static class VehicleSummaryConstLocators
    {

        // Vehicle info
        public const string SelectVehicles = "xpath=//button[contains(@id, 'unlistedVehicle')]";
        public const string Vehicle1Header = "xpath=//div[contains(text(), 'Vehicle 1')]";
        public static ILocator VINNumber(IPage page) => page.GetByLabel("VIN");
        public static ILocator VehicleYearInput(IPage page) => page.GetByLabel("Model Year");
        public static ILocator MakeInput(IPage page) => page.GetByLabel("Make");
        public static ILocator ModelInput(IPage page) => page.GetByLabel("Model");
        public static ILocator TrimInput(IPage page) => page.GetByLabel("Trim");
        public static ILocator PurchaseDateInput(IPage page) => page.GetByLabel("Purchase Date");
        public static ILocator OdometerReadingInput(IPage page) => page.GetByLabel("Odometer Reading");
        public static ILocator TotalAnnualMileageInput(IPage page) => page.Locator("[data-testid*='annualMileage']");


        // VIN Populated Vehicle Information (Read Only Fields)
        public static ILocator VehicleYearReadOnly(IPage page) => page.Locator("div.readonly-field:has(span.readonly-label:has-text('Year')) >> span.readonly-value");
        public static ILocator MakeReadOnly(IPage page) => page.Locator("div.readonly-field:has(span.readonly-label:has-text('Make')) >> span.readonly-value");
        public static ILocator ModelReadOnly(IPage page) => page.Locator("div.readonly-field:has(span.readonly-label:has-text('Model')) >> span.readonly-value");
        public static ILocator TrimReadOnly(IPage page) => page.Locator("div.readonly-field:has(span.readonly-label:has-text('Trim')) >> span.readonly-value");
        /// <summary>
        /// ^^^ Check locators for read only fields above ^^^
        /// </summary>
    }

    public static class ClaimsAndViolationsConstLocators
    {
        public static ILocator NoClaimsBanner(IPage page) => page.GetByText("No claims were found on reports");
        public static ILocator NoViolationsBanner(IPage page) => page.GetByText("No violations were found on reports");
        public static ILocator AddClaimsButton(IPage page) => page.GetByTestId("add_Claim");
        public static ILocator AddViolationsButton(IPage page) => page.GetByTestId("add_Violation");
    }

    public static class PolicyCoveragesConstLocators
    {
        public const string ViewPriorCarrierDetailsButton = "xpath=.//button[contains(text(), 'VIEW PRIOR CARRIER DETAILS')]";
    }

    public static class AdditionalCoveragesConstLocators
    {
        public static ILocator RentedMotorHomesCheckbox(IPage page) => page.GetByTestId("RentedMotorHomeTravelTrailer");
        public static ILocator AddedCoverageEndorsementCheckbox(IPage page) => page.GetByTestId("addedCoverageEndorsement");
        public static ILocator SoundReceivingEquipmentCheckbox(IPage page) => page.GetByTestId("SoundRec");
    }

    internal class PricingDetailsConstLocators
    {
        public static ILocator AccountOwner(IPage page) => page.Locator("div.readonly-field:has(span.readonly-label:has-text('Account Owner')) >> span.readonly-value");
        public static ILocator AccountAddress(IPage page) => page.Locator("div.readonly-field:has(span.readonly-label:has-text('Account Address')) >> span.readonly-value");
        public static ILocator ProposalButton(IPage page) => page.GetByTestId("fields.data.create_Proposal");
        public static ILocator CoverageOptionOverviewButton(IPage page) => page.GetByTestId("fields.data.create_CoverageOptionOverview");
    }

    public static class AdditionalInterestLocators
    {
        public static ILocator AddAdditionalInterestButton(IPage page) => page.GetByTestId("add_Additional_Interest");
        public static ILocator AdditionalInterestNameInput(IPage page) => page.GetByTestId("fields.account.additionalOtherInterest.additionalOtherInterestInput$name.value");
        public static ILocator AdditionalInterestAddressInput(IPage page) => page.GetByTestId("fields.account.additionalOtherInterest.additionalOtherInterestInput$name.value");
        public static ILocator AdditionalInterestCityInput(IPage page) => page.GetByTestId("fields.account.additionalOtherInterest.additionalOtherInterestInput$city.value");
        public static ILocator AdditionalInterestStateDropdown(IPage page) => page.GetByTestId("fields.account.additionalOtherInterest.additionalOtherInterestInput$state.value");
        public static ILocator AdditionalInterestZipInput(IPage page) => page.GetByTestId("fields.account.additionalOtherInterest.additionalOtherInterestInput$zipCode.value");
        public static ILocator AdditionalInterestPhoneInput(IPage page) => page.GetByTestId("fields.account.additionalOtherInterest.additionalOtherInterestInput$primaryPhone.value");
        public static ILocator RelationshipToAccountHolderInput(IPage page) => page.GetByTestId("fields.account.additionalOtherInterest.additionalOtherInterestInput$relationshipToInsured.value");
        public static ILocator AdditionalInterestDOBInput(IPage page) => page.GetByLabel("Owner Date Of Birth");
        public static ILocator AdditionalInterestDLNumberInput(IPage page) => page.GetByTestId("fields.account.additionalOtherInterest.additionalOtherInterestInput$ownerDriversLicenseNumber.value");
        public static ILocator AdditionalInterestLicenseState(IPage page) => page.GetByLabel(" Owner License State ");
        public static ILocator UWRulesDialogContinueButton(IPage page) => page.GetByTestId("btnConfirmYes");
    }

    public static class BillingInformationConstLocators
    {
        public static ILocator CreateNewBillingAccountButton(IPage page) => page.Locator("[data-testid*='billingCenterAccount']");
        public static ILocator PaymentDueDateInput(IPage page) => page.GetByTestId("fields._PolicyPaymentInputDoc.subsequentPaymentData$dueDate.value");
        public static ILocator ApplyRefundChecbox(IPage page) => page.GetByTestId("fields._PolicyPaymentInputDoc.initialPaymentData$applyRefund.value");
        public static ILocator CheckNumberInput(IPage page) => page.GetByTestId("fields._PolicyPaymentInputDoc.initialPaymentData$checkNumber.value");
    }

   
}
