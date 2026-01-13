using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace Playwright_POC.Locators
{

    internal class ExpressLeftMenuConstLocators
    {
        public const string HomeButton = "xpath=.//a[contains(@title, 'Home')]";
        public const string LeftMenuSearchButton = "xpath=.//a[contains(@title, 'Search')]";
        public const string BrowseRCTExpressButton = "xpath=.//a[contians(text(), 'Browse RCT Express')]";
    }

    internal class ExpressNavigationLocators
    {
        public const string ApplicantTab = "xpath=.//a[contains(@title, 'Applicant')]";
        public const string PolicyTermTab = "xpath=.//a[contains(@title, 'Policy Term')]";
        public const string LocationTab = "xpath=.//a[contains(@title, 'Location(s)')]";
        public const string DriversTab = "xpath=.//a[contains(@title, 'Driver(s)')]";
        public const string PrefillDriversTab = "xpath=.//a[contains(@title, 'Prefill Driver(s)')]";
        public const string DriverHistoryTab = "xpath=.//a[contains(@title, 'Driver History')]";
        public const string VehiclesTab = "xpath=.//a[contains(@title, 'Vehicle(s)')]";
        public const string CoveragesTab = "xpath=.//a[contains(@title, 'Coverages')]";
        public const string DriverAssignmentTab = "xpath=.//a[contains(@title, 'Driver Assignment')]";
        public const string AdditionalInterestsTab = "xpath=.//a[contains(@title, 'Additional Interest')]";
        public const string EndorsementsTab = "xpath=.//a[contains(@title, 'Endorsements')]";
        public const string UnderwritingTab = "xpath=.//a[contains(@title, 'Underwriting')]";
        public const string InsuranceHistoryTab = "xpath=.//a[contains(@title, 'Insurance History')]";
        public const string DiscountsTab = "xpath=.//a[contains(@title, 'Discounts')]";
        public const string PricingTab = "xpath=.//a[contains(@title, 'Pricing')]";
        public const string NextButton = "xpath=.//button[contains(@title, 'Next')]";
        public const string BackButton = "xpath=.//button[contains(@title, 'Back')]";

    }

    internal class ExpressLoginConstLocators
    {
        public const string UsernameInput = "input[name='pf.username']";
        public const string PasswordInput = "input[name='pf.pass']";
        public const string LoginButton = "xpath=//a[contains(@id, 'signInBtn')]";
    }

    internal class ExpressDashboardConstLocators
    {
        public const string ApplicationButton = "xpath=.//button//div[contains(text(), 'Application')]";
        public const string SearchBarInput = "input[fieldref='PolicyHeaderInput.SearchText']";
        public const string SearchTypeDropDown = "dc-combobox[data-dc-name='PolicyHeaderInput.SearchType']";
        public const string ExpandSearchTypeDropDown = "xpath=.//button[contains(@data-toggle, 'SearchType')]";
        public const string SearchButton = "xpath=.//button[contains(@title, 'Search')]";
        public const string LogOutButton = "xpath=.//button[contians(@title, 'Log Out')]";
        public const string NewQuoteButton = "xpath=.//button[contains(@title, 'New Quote')]";

    }

    internal class ExpressSearchResultsPageConstLocators
    {
        public const string ExpandSearchFiltersPolicyDropdown = "xpath=.//button[contains(@data-toggle, 'PolicySearckKeyInput.PolicyData')]";
        public const string ExpandOperatorDropdown = "xpath=.//button[contains(@data-toggle, 'PolicySearckKeyInput.PolicyOperator')]";
        public const string ValueInput = "xpath=.//input[contains(@fieldref, 'PolicySearckKeyInput.PolicyDataValue')]";
        public const string AddButton = "xpath=.//button[contains(@title, 'Add')]";
        public const string ExpandSearchInDropdown = "xpath=.//button[contains(@data-toggle, 'SearchInput.AgencyFilter')]";
        public const string IncludePreviousTearmsCheckbox = "xpath=.//input[contains(@fieldref, 'SearchInput.HistoryFilter')]";
        public const string ShowOnlyDeletedPoliciesCheckbox = "xpath=.//input[contains(@fieldref, 'SearchInput.DeletedFilter')]";
        public const string SearchButton = "xpath=.//button[contains(@title, 'Search')]";
        public const string ExpandEllipsisButton = "xpath=.//i[contains(@class, 'icon-more')]";
        public const string SelectPolicyFromEllipsis = "xpath=.//a[contains(@actionref, 'ViewPolicy')]";
        public const string SelectViewPolicyDetailsFromEllipsis = "xpath=.//a[contains(@actionref, 'ViewPolicyDetails')]";

    }

    internal class ExpressApplicantPageConstLocators
    {
        public const string PreQualificationQuestionsButton = "xpath=.//button[contains(@title, 'Pre-Qualification Questions')]";

        // Account Info Section
        public const string CIFAccountID = "xpath=.//input[contains(@fieldref, 'CIFAccountId')]";
        public const string ForceNewAccountReason = "xpath=.//input[contains(@fieldref, 'ForceNewAccountReason')]";
        public const string CashbackId = "xpath=.//input[contains(@fieldref, 'CashbackID')]";
        public const string CashbackStatus = "xpath=.//input[contains(@fieldref, 'Status')]";

        // Account Owner Section
        public const string AccountOwnerFirstName = "xpath=.//input[contains(@fieldref, 'FirstName')]";
        public const string AccountOwnerFirstMiddleName = "xpath=.//input[contains(@fieldref, 'FirstMiddleName')]";
        public const string AccountOwnerSecondMiddleName = "xpath=.//input[contains(@fieldref, 'SecondMiddleName')]";
        public const string AccountOwnerLastName = "xpath=.//input[contains(@fieldref, 'LastName')]";
        public const string Gender = "xpath=.//input[contains(@fieldref, 'Gender')]";
        public const string DateOfBirth = "xpath=.//p[contains(@fieldref, 'DateOfBirth')]";
        public const string SocialSecurityNumber = "xpath=.//input[contains(@fieldref, 'SSN_Masked')]";
        public const string MaritalStatus = "xpath=.//input[contains(@fieldref, 'MaritalStatus')]";
        public const string ClientType = "xpath=.//input[contains(@fieldref, 'ClientType')]";
        public const string PhoneNumber = "xpath=.//input[contains(@fieldref, 'PhoneNumber')]";
        public const string PhoneType = "xpath=.//input[contains(@fieldref, 'PhoneType')]";
        public const string EmailAddress = "xpath=.//input[contains(@fieldref, 'EmailAddress')]";
        public const string EmailType = "xpath=.//input[contains(@fieldref, 'EmailType')]";

        // Named Insured Section
        public const string ClientId = "xpath=.//input[contains(@fieldref, 'ClientID')]";
        public const string NameId = "xpath=.//input[contains(@fieldref, 'NameID')]";

        // Mailing Address Section
        public const string AddressOne = "xpath=.//input[contains(@fieldref, 'Address1')]";
        public const string AddressTwo = "xpath=.//input[contains(@fieldref, 'Address2')]";
        public const string City = "xpath=.//input[contains(@fieldref, 'City')]";
        public const string State = "xpath=.//input[contains(@fieldref, 'State')]";
        public const string ZipCode = "xpath=.//input[contains(@fieldref, 'ZipCode')]";

        // Communication Preferences Section
        public const string ExpandPaperlessEnrollmentDropdown = "xpath=.//button[contains(@data-toggle, 'PaperlessCommunication')]";
        public const string ExpandNamedInsuredPaperlessDropdown = "xpath=.//button[contains(@data-toggle, 'PaperlessContactID')]";

    }

    internal class ExpressPolicyTermPageConstLocators
    {
        // Policy Information Section
        public const string PrimaryRatingState = "xpath=.//input[contains(@fieldref, 'PrimaryRatingState')]";
        public const string WritingCompany = "xpath=.//input[contains(@fieldref, 'WritingCompany')]";
        public const string EffectiveDate = "xpath=.//input[contains(@fieldref, 'EffectiveDate')]";
        public const string Term = "xpath=.//input[contains(@fieldref, 'Term')]";
        public const string ExpirationDate = "xpath=.//input[contains(@fieldref, 'ExpirationDate')]";
        public const string RateDate = "xpath=.//p[contains(@fieldref, 'RateDate')]";
        public const string OriginalInceptionDate = "xpath=.//input[contains(@fieldref, 'OriginalInceptionDate')]";
        public const string GoodDriverDate = "xpath=.//input[contains(@fieldref, 'GoodDriverDate')]";
        public const string AgencyName = "xpath=.//input[contains(@fieldref, 'AgencyInput.Name')]";

        // Agent Information Section
        public const string AgentName = "xpath=.//p[contains(@fieldref, 'AgentName')]";
        public const string AgentCode = "xpath=.//input[contains(@fieldref, 'AgentPCCode')]";
        public const string AgencyCode = "xpath=.//p[contains(@fieldref, 'AgencyCode')]";
        public const string AgentStatus = "xpath=.//p[contains(@fieldref, 'AgentStatus')]";
        public const string AgentLicenseState = "xpath=.//p[contains(@fieldref, 'AgentLicense.State')]";
        public const string LicenseStartDate = "xpath=.//p[contains(@fieldref, 'AgentLicense.EffectiveDate')]";
        public const string LicenseExpirationDate = "xpath=.//p[contains(@fieldref, 'AgentLicense.ExpirationDate')]";
        public const string AgentHierarchy = "xpath=.//p[contains(@fieldref, 'AgentHierarchy')]";
        public const string SalesAssociatePCCode = "xpath=.//input[contains(@fieldref, 'SalesAssociatePCCode')]";
        public const string AgentAddress1 = "xpath=.//p[contains(@fieldref, 'ServicingAgentInput.Address1')]";
        public const string AgentAddress2 = "xpath=.//p[contains(@fieldref, 'ServicingAgentInput.Address2')]";
        public const string AgentCity = "xpath=.//p[contains(@fieldref, 'ServicingAgentInput.City')]";
        public const string AgentState = "xpath=.//p[contains(@fieldref, 'ServicingAgentInput.State')]";
        public const string AgentZip = "xpath=.//p[contains(@fieldref, 'ServicingAgentInput.ZipCode')]";
        public const string OfficePhoneNumber = "xpath=.//p[contains(@fieldref, 'ServicingAgentInput.OfficePhoneNumber')]";
        public const string MobilePhoneNumber = "xpath=.//p[contains(@fieldref, 'ServicingAgentInput.MobilePhoneNumber')]";
        public const string AgentEmailAddress = "xpath=.//p[contains(@fieldref, 'ServicingAgentInput.Email')]";
        public const string CSCParticipating = "xpath=.//p[contains(@fieldref, 'ServicingAgentInput.CSCParticipating')]";

    }

    internal class ExpressLocationPageConstLocators
    {
        // Location Section
        public const string Description = "xpath=.//p[contains(@fieldref, 'LocationInput.Description')]";
        public const string LocationAddressOne = "xpath=.//p[contains(@fieldref, 'LocationInput.Address1')]";
        public const string LocationAddressTwo = "xpath=.//p[contains(@fieldref, 'LocationInput.Address2')]";
        public const string LocationCity = "xpath=.//p[contains(@fieldref, 'LocationInput.City')]";
        public const string LocationState = "xpath=.//p[contains(@fieldref, 'LocationInput.State')]";
        public const string LocationZipCode = "xpath=.//p[contains(@fieldref, 'LocationInput.ZipCode')]";
        public const string LocationDetailsButton = "xpath=.//a[contains(@title, 'Details')]";
    }

    internal class ExpressDriversPageConstLocators
    {
        // Driver Section
        public const string DriverName = "xpath=.//input[contains(@fieldref, 'DriverOutput.Name')]";
        public const string OperatorStatus = "xpath=.//input[contains(@fieldref, 'DriverInput.OperatorStatus')]";
        public const string DriverLicenseNumber = "xpath=.//input[contains(@fieldref, 'DriverInput.DriversLicenseNumber')]";
        public const string OperatorNeedsSR22 = "xpath=.//input[contains(@fieldref, 'DriverInputUnderwriting.SR22Indicator')]";
        public const string DriverDetailButton = "xpath=.//a[contains(@title, 'Detail')]";
        public const string DriverDeleteButton = "xpath=.//a[contains(@title, 'Delete')]";
        public const string ViewMVR = "xpath=.//a[contains(text(), 'View MVR')]";
        public const string ViewCLUE = "xpath=.//a[contains(text(), 'View CLUE')]";
        public const string AddDriverButton = "xpath=.//button[contains(@title, 'Add Driver')]";
    }

    internal class ExpressPrefillDriversPageConstLocators
    {
        // To be added in future
    }

    internal class ExpressDriverHistoryPageConstLocators
    {
        public const string AddAccidentButton = "xpath=.//button[contains(@title, 'Add Accident')]";
        public const string ViewAllClaimsButton = "xpath=.//button[contains(@title, 'View All Claims')]";


    }

    internal class ExpressVehiclesPageConstLocators
    {
      
        public const string VehicleType= "xpath=.//p[contains(@fieldref, 'VehicleInput.VehicleType')]";
        public const string VehicleYear = "xpath=.//p[contains(@fieldref, 'VehicleInput.Year')]";
        public const string VehicleMake = "xpath=.//p[contains(@fieldref, 'VehicleInput.Make')]";
        public const string VehicleModel = "xpath=.//p[contains(@fieldref, 'VehicleInput.Model')]";
        public const string VINNumber = "xpath=.//p[contains(@fieldref, 'VehicleInput.VIN')]";
        public const string VehicleDetailButton = "xpath=.//a[contains(@title, 'Detail')]";
        public const string VehicleDeleteButton = "xpath=.//a[contains(@title, 'Delete')]";
        public const string AddVehicleButton = "xpath=.//button[contains(@title, 'Add Vehicle')]";
    }

    internal class  ExpressCoveragesPageConstLocators
    {
        // Policy Coverage section
        public const string BodilyInjuryDropdown = "xpath=.//input[contains(@fieldref, 'BodilyInjuryInput.Limit')]";
        public const string PropertyDamageDropdown = "xpath=.//input[contains(@fieldref, 'PropertyDamageInput.Limit')]";
        public const string MedicalPaymentsDropdown = "xpath=.//input[contains(@fieldref, 'MedicalPaymentsInput.Limit')]";
        public const string UninsuredMotoristDropdown = "xpath=.//input[contains(@fieldref, 'UninsuredMotoristInput.Limit')]";
        public const string UnderinsuredMotoristDropdown = "xpath=.//input[contains(@fieldref, 'UnderinsuredMotoristInput.Limit')]";
        public const string ADDDropdown = "xpath=.//input[contains(@fieldref, 'Policy_AccidentalDeathInput.Limit')]";
        public const string ExpandVehicleCoverages = "xpath=.//button[contains(@title, 'expand')]";

        // Expanded Vehcicle Section
        public const string ComprehensiveOnlyCheckbox = "xpath=.//input[contains(@fieldref, 'VehicleInput.ComprehensiveOnly')]";
        public const string LiabilityOnlyCheckbox = "xpath=.//input[contains(@fieldref, 'VehicleInput.LiabilityOnly')]";
        public const string VehicleBodilyInjuryLimit = "xpath=.//p[contains(@fieldref, 'CovBodilyInjuryInput.Limit')]";
        public const string VehiclePropertyDamageLimit = "xpath=.//p[contains(@fieldref, 'CovPropertyDamageInput.Limit')]";
        public const string VehicleMedicalPaymentsLimit = "xpath=.//p[contains(@fieldref, 'CovMedicalPaymentsInput.Limit')]";
        public const string VehicleUninsuredMotoristLimit = "xpath=.//p[contains(@fieldref, 'CovUninsuredMotoristInput.Limit')]";
        public const string VehicleUnderinsuredMotoristLimit = "xpath=.//p[contains(@fieldref, 'CovUnderinsuredMotoristInput.Limit')]";
        public const string ExpandVehicleComprehensiveDropdown = "xpath=.//button[contains(@data-toggle, 'CovComprehensiveInput.Deductible')]";
        public const string ExpandVehicleCollisionDropdown = "xpath=.//button[contains(@data-toggle, 'CovCollisionInput.Deductible')]";
        public const string ExpandRentalReimbursementDropdown = "xpath=.//button[contains(@data-toggle, 'CovRentalReimbursementInput.Limit')]";

    }


}