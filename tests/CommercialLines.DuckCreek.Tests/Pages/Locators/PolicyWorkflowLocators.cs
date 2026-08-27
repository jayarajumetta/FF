using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class PolicyWorkflowLocators
{
    private readonly IPage _page;
    public PolicyWorkflowLocators(IPage page) => _page = page;

    // Source modules: AJAX Error | confidence=Medium score=100
    public ILocator AJAXErrorCheck => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "AJAX Error Check");

    // Source modules: Specific Underwriting Questions - Accounts Receivable | confidence=High score=97
    // v57 raw Tosca: Specific Underwriting Questions - Accounts Receivable | Accounts Receivable Heading | guid=3a13d49c-172d-d12e-b14d-c5c2d366b2bb | strategy=id
    public ILocator AccountsReceivableHeading => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-d12e-b14d-c5c2d366b2bb");

    // Source modules: Client|Add Associated Client | confidence=High score=125
    // v57 raw Tosca:  | Add Client | guid=3a13d49c-1679-21d3-307d-9ac2d420ffb8 | strategy=role-link
    public ILocator AddClient => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1679-21d3-307d-9ac2d420ffb8");

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v57 raw Tosca: Policy Covg|GL | Aggregate Limit | guid=3a13d49c-1700-7505-61ee-35ff4430c9d2 | strategy=retained-semantic
    public ILocator AggregateLimit => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-7505-61ee-35ff4430c9d2");

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: UMB Navigation Links | Businessowners | guid=3a13d49c-1697-10a4-df69-6f4dc21706f3 | strategy=role-link
    public ILocator Businessowners => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-10a4-df69-6f4dc21706f3");

    // Source modules: Policy Info|CPP Specific Fields | confidence=High score=95
    // CPP Only
    // v57 raw Tosca: Policy Info|CPP Specific Fields | CP Detail | guid=3a13d49c-1697-f6cc-f905-5ee82842929f | strategy=role-link
    public ILocator CPDetail => _page.GetByRole(AriaRole.Link, new() { Name = "CP Detail", Exact = true });

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: UMB Navigation Links | CPP Liability | guid=3a13d49c-1697-b124-eb68-7d72e20b1cb2 | strategy=role-link
    public ILocator CPPLiability => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-b124-eb68-7d72e20b1cb2");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator CTStraightThroughLiabilityLimitTo1M => _page.GetByText("CT StraightThrough Liability Limit to 1M", new() { Exact = true });

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: UMB Navigation Links | Commercial Auto | guid=3a13d49c-1697-50ef-718a-9eff146a551c | strategy=role-link
    public ILocator CommercialAuto => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-50ef-718a-9eff146a551c");

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v57 raw Tosca: Policy Covg|GL | Ded Type | guid=3a13d49c-1700-a97e-db29-b634782f5f0c | strategy=retained-semantic
    public ILocator DedType => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-a97e-db29-b634782f5f0c");

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v57 raw Tosca: Policy Covg|GL | Deductible Basis | guid=3a13d49c-1700-b6ea-5343-993db0eb88bd | strategy=retained-semantic
    public ILocator DeductibleBasis => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-b6ea-5343-993db0eb88bd");

    // Source modules: Policy Info|Required and Optional Fields | confidence=High score=125
    public ILocator DescriptionOfSpecifiedOperation => _page.GetByRole(AriaRole.Textbox, new() { Name = "Description of Specified Operation", Exact = true });

    // Source modules: Policy Covg | confidence=High score=125
    // v57 raw Tosca: Policy Covg | Does any Risk generate power other than Private Windmills or Emergency Backup?* | guid=3a13d49c-1700-f4d8-335f-cea3f953bf5e | strategy=retained-semantic
    public ILocator DoesAnyRiskGeneratePowerOtherThanPrivateWindmillsOrEmergencyBackup => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-f4d8-335f-cea3f953bf5e");

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: UMB Navigation Links | Employers Liab | guid=3a13d49c-1697-9599-a2ea-9374855150e2 | strategy=role-link
    public ILocator EmployersLiab => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-9599-a2ea-9374855150e2");

    // Source modules: Endorsement - Main | confidence=High score=97
    // v57 raw Tosca: Endorsement - Main |  Endorsement Heading | guid=3a13d49c-172d-9372-feda-ed7f73106a12 | strategy=id
    public ILocator EndorsementHeading => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-9372-feda-ed7f73106a12");

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v57 raw Tosca: Policy Covg|GL | Fire Damage | guid=3a13d49c-1700-2650-8f24-19c05dba284b | strategy=retained-semantic
    public ILocator FireDamage => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-2650-8f24-19c05dba284b");

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: UMB Navigation Links | General Liab | guid=3a13d49c-1697-0f88-b883-20bf5c0d330f | strategy=role-link
    public ILocator GeneralLiab => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-0f88-b883-20bf5c0d330f");

    // Source modules: Policy Info|WC Specific Fields | confidence=High score=125
    // WC only
    // v57 raw Tosca: Policy Info|WC Specific Fields | Has the applicant been in business for at least 3 years with continuous Workers Compensation Coverage?* | guid=3a13d49c-16f1-d483-ee40-1ea35a4ec9f5 | strategy=retained-semantic
    public ILocator HasTheApplicantBeenInBusinessForAtLeast3YearsWithContinuousWorkersCompensationCoverage => _page.GetByRole(AriaRole.Textbox, new() { Name = "Has the applicant been in business for at least 3 years with continuous Workers Compensation Coverage?*", Exact = true });

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: UMB Navigation Links | Homeowner's Liability | guid=3a13d49c-1697-b30f-c867-596198679155 | strategy=role-link
    public ILocator HomeownerSLiability => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-b30f-c867-596198679155");

    // Source modules: Http Error Msg | confidence=Medium score=113
    public ILocator HttpErrorMsgOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator IFRAMEDuckCreekPolicyDescriptionOfOther => _page.GetByText("Description of Other", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator IFRAMEDuckCreekPolicyOtherCheckBox => _page.GetByText("Other CheckBox", new() { Exact = true });

    // Source modules: Policy Info|CPP Specific Fields | confidence=High score=95
    // CPP Only
    // v57 raw Tosca: Policy Info|CPP Specific Fields | IM Detail | guid=3a13d49c-1697-74b4-3007-bf2149cbc0b7 | strategy=role-link
    public ILocator IMDetail => _page.GetByRole(AriaRole.Link, new() { Name = "IM Detail", Exact = true });

    // Source modules: Policy Covg | confidence=High score=124
    // v57 raw Tosca: Policy Covg | Include Businessowners | guid=3a13d49c-16f1-5942-b2e0-ad03238a9647 | strategy=fieldref
    public ILocator IncludeBusinessowners => _page.Locator("[fieldref=\"LineUmbrellaBusinessOwners.IncludeBusinessOwners\"], [data-fieldref=\"LineUmbrellaBusinessOwners.IncludeBusinessOwners\"]");

    // Source modules: Policy Covg | confidence=High score=124
    // v57 raw Tosca: Policy Covg | Include Commercial Auto | guid=3a13d49c-16f1-76b1-4528-79390c12c3b2 | strategy=fieldref
    public ILocator IncludeCommercialAuto => _page.Locator("[fieldref=\"LineUmbrellaCommercialAuto.IncludeCommercialAuto\"], [data-fieldref=\"LineUmbrellaCommercialAuto.IncludeCommercialAuto\"]");

    // Source modules: Policy Covg | confidence=High score=124
    // v57 raw Tosca: Policy Covg | Include Commercial Package Policy Liability | guid=3a13d49c-16f1-9d22-5dd4-972a233fa226 | strategy=fieldref
    public ILocator IncludeCommercialPackagePolicyLiability => _page.Locator("[fieldref=\"LineUmbrellaCPPLiability.IncludeCPPLiability\"], [data-fieldref=\"LineUmbrellaCPPLiability.IncludeCPPLiability\"]");

    // Source modules: Policy Covg | confidence=High score=124
    // v57 raw Tosca: Policy Covg | Include Employers Liability | guid=3a13d49c-16f1-8dee-4d4a-5ef01f19a9c0 | strategy=fieldref
    public ILocator IncludeEmployersLiability => _page.Locator("[fieldref=\"LineUmbrellaEmployersLiability.IncludeEmployersLiability\"], [data-fieldref=\"LineUmbrellaEmployersLiability.IncludeEmployersLiability\"]");

    // Source modules: Policy Covg | confidence=High score=124
    // v57 raw Tosca: Policy Covg | Include General Liability | guid=3a13d49c-16f1-fafd-2d3b-1d3eafbed464 | strategy=fieldref
    public ILocator IncludeGeneralLiability => _page.Locator("[fieldref=\"LineUmbrellaGeneralLiability.IncludeGeneralLiability\"], [data-fieldref=\"LineUmbrellaGeneralLiability.IncludeGeneralLiability\"]");

    // Source modules: Policy Covg | confidence=High score=124
    // v57 raw Tosca: Policy Covg | Include Homeowner's Liability | guid=3a13d49c-16f1-041c-f7e2-55494c7baccc | strategy=fieldref
    public ILocator IncludeHomeownerSLiability => _page.Locator("[fieldref=\"LineUmbrellaHomeownersLiability.IncludeHomeownersLiability\"], [data-fieldref=\"LineUmbrellaHomeownersLiability.IncludeHomeownersLiability\"]");

    // Source modules: Policy Covg | confidence=High score=124
    // v57 raw Tosca: Policy Covg | Include Personal Auto Liability | guid=3a13d49c-16f1-276b-bb9f-de798f6f0134 | strategy=fieldref
    public ILocator IncludePersonalAutoLiability => _page.Locator("[fieldref=\"LineUmbrellaPersonalAutoLiability.IncludePersonalAutoLiability\"], [data-fieldref=\"LineUmbrellaPersonalAutoLiability.IncludePersonalAutoLiability\"]");

    // Source modules: Policy Covg | confidence=High score=124
    // v57 raw Tosca: Policy Covg | Include Rental Owner's Liability | guid=3a13d49c-16f1-0ad8-19e6-c35985d9dacd | strategy=fieldref
    public ILocator IncludeRentalOwnerSLiability => _page.Locator("[fieldref=\"LineUmbrellaRentalOwnersLiability.IncludeRentalOwnersLiability\"], [data-fieldref=\"LineUmbrellaRentalOwnersLiability.IncludeRentalOwnersLiability\"]");

    // Source modules: Policy Covg | confidence=High score=124
    // v57 raw Tosca: Policy Covg | Include SFP - 10 Liability/Farm | guid=3a13d49c-16f1-d7a7-5c25-2211e0a3c376 | strategy=fieldref
    public ILocator IncludeSFP10LiabilityFarm => _page.Locator("[fieldref=\"LineUmbrellaSFP10Liability.IncludeSFP10Liability\"], [data-fieldref=\"LineUmbrellaSFP10Liability.IncludeSFP10Liability\"]");

    // Source modules: Policy Covg | confidence=High score=124
    // v57 raw Tosca: Policy Covg | Include Watercraft Liability | guid=3a13d49c-16f1-90d4-d09c-1b4043fa218c | strategy=fieldref
    public ILocator IncludeWatercraftLiability => _page.Locator("[fieldref=\"LineUmbrellaWatercraftLiability.IncludeWatercraftLiability\"], [data-fieldref=\"LineUmbrellaWatercraftLiability.IncludeWatercraftLiability\"]");

    // Source modules: Client|Add Associated Client | confidence=High score=125
    // v57 raw Tosca:  | IndividualType | guid=3a13d49c-1679-a316-96ce-ca532c48906e | strategy=retained-semantic
    public ILocator IndividualType => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1679-a316-96ce-ca532c48906e");

    // Source modules: Policy Covg|GL | confidence=High score=125
    // v57 raw Tosca: Policy Covg|GL | Is the Insured engaged in any Snow or Ice Removal Operations?* | guid=3a13d49c-1700-9844-6210-6e05ab67ffc8 | strategy=retained-semantic
    public ILocator IsTheInsuredEngagedInAnySnowOrIceRemovalOperations => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-9844-6210-6e05ab67ffc8");

    // Source modules: Indicators and Errors | confidence=High score=127
    // This DIV appears during a refresh of the screen (working in the background) and can be used as a WaitOn for stability.
    public ILocator LoadingMessage => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Loading Message");

    // Source modules: Logout | confidence=Review score=97
    public ILocator LoggedInUser => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Logged In User");

    // Source modules:  | confidence=High score=97
    public ILocator Logout => _page.GetByRole(AriaRole.Link, new() { Name = "Logout", Exact = true });

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v57 raw Tosca: Policy Covg|GL | Medical | guid=3a13d49c-1700-1b2e-8774-90d2b00bf944 | strategy=retained-semantic
    public ILocator Medical => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-1b2e-8774-90d2b00bf944");

    // Source modules:  | confidence=High score=125
    public ILocator OK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v57 raw Tosca: Policy Covg|GL | Occurence Limit | guid=3a13d49c-1700-6910-f085-905e20437cbe | strategy=retained-semantic
    public ILocator OccurenceLimit => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-6910-f085-905e20437cbe");

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v57 raw Tosca: Policy Covg|GL | # of Full-Time Employees* | guid=3a13d49c-1700-6b9e-7a82-759a0390c142 | strategy=id
    public ILocator OfFullTimeEmployees => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-6b9e-7a82-759a0390c142");

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v57 raw Tosca: Policy Covg|GL | # of Part-Time Employees* | guid=3a13d49c-1700-d1b3-1a9a-5519e5296a7f | strategy=id
    public ILocator OfPartTimeEmployees => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-d1b3-1a9a-5519e5296a7f");

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v57 raw Tosca: Policy Covg|GL | # of Seasonal/Temporary Employees* | guid=3a13d49c-1700-4cec-e5f0-b402c1b9fc50 | strategy=id
    public ILocator OfSeasonalTemporaryEmployees => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-4cec-e5f0-b402c1b9fc50");

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v57 raw Tosca: Policy Covg|GL | Pers Adv Inj | guid=3a13d49c-1700-88fd-c07c-9f9ab9138604 | strategy=retained-semantic
    public ILocator PersAdvInj => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-88fd-c07c-9f9ab9138604");

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: UMB Navigation Links | Personal Auto | guid=3a13d49c-1697-ae5b-45b5-df53d1fb9b8f | strategy=role-link
    public ILocator PersonalAuto => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-ae5b-45b5-df53d1fb9b8f");

    // Source modules: Policy Covg|GL | confidence=High score=127
    // v57 raw Tosca: Policy Covg|GL | Policy Covg | guid=3a13d49c-1700-769e-b228-7a3436bb62eb | strategy=id
    public ILocator PolicyCovg6B651 => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-769e-b228-7a3436bb62eb");

    // Source modules: Policy Covg | confidence=High score=127
    public ILocator PolicyCovgFF145 => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Policy Covg");

    // Source modules: Policy Info|Required and Optional Fields | confidence=High score=97
    public ILocator PolicyInfoHeader => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Policy Info Header");

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v57 raw Tosca: Policy Covg|GL | PremOp Ded | guid=3a13d49c-1700-277f-f8c3-5a7e01456e49 | strategy=retained-semantic
    public ILocator PremOpDed => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-277f-f8c3-5a7e01456e49");

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v57 raw Tosca: Policy Covg|GL | PremOp PD Ded | guid=3a13d49c-1700-3255-282f-15a94c7a106d | strategy=retained-semantic
    public ILocator PremOpPDDed => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-3255-282f-15a94c7a106d");

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v57 raw Tosca: Policy Covg|GL | Prod BI Ded | guid=3a13d49c-1700-930b-1ff7-13efbf42ac65 | strategy=retained-semantic
    public ILocator ProdBIDed => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-930b-1ff7-13efbf42ac65");

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v57 raw Tosca: Policy Covg|GL | Prod PD Ded | guid=3a13d49c-1700-0ca0-26e9-1f003690dc99 | strategy=retained-semantic
    public ILocator ProdPDDed => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-0ca0-26e9-1f003690dc99");

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v57 raw Tosca: Policy Covg|GL | Products Agg Limit | guid=3a13d49c-1700-7641-373b-5b21ae14d400 | strategy=retained-semantic
    public ILocator ProductsAggLimit => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-7641-373b-5b21ae14d400");

    // Source modules: Property Add Class | confidence=High score=125
    // v57 raw Tosca: Property Add Class | Property of Others Rating Group | guid=3a13d49c-1700-702f-ab45-977a2cd5409c | strategy=retained-semantic
    public ILocator PropertyOfOthersRatingGroup => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-702f-ab45-977a2cd5409c");

    // Source modules: Dashboard|QuickSearch | confidence=High score=127
    public ILocator QuickSearchButton => _page.GetByRole(AriaRole.Link, new() { Name = "QuickSearch Button", Exact = true });

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: UMB Navigation Links | Rental Owners Liability | guid=3a13d49c-1697-f99b-bc35-ce694290718a | strategy=role-link
    public ILocator RentalOwnersLiability => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-f99b-bc35-ce694290718a");

    // Source modules: Restart Microsoft Edge Message | confidence=Medium score=116
    public ILocator RestartMicrosoftEdgeMessageOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    // Source modules: Common Navigation Links | confidence=Medium score=113
    public ILocator ReturnToAdmin => _page.GetByRole(AriaRole.Link, new() { Name = "Return To Admin", Exact = true });

    // Source modules: Common Navigation Links | confidence=High score=125
    public ILocator ReturnToCPP => _page.GetByRole(AriaRole.Button, new() { Name = "Return To CPP", Exact = true });

    // Source modules: Risk - Accounts Receivable | confidence=High score=125
    // v57 raw Tosca: Risk - Accounts Receivable | OK | guid=3a13d49c-172d-87fd-649f-1d8b0fc57589 | strategy=role-link
    public ILocator RiskAccountsReceivableOK => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-87fd-649f-1d8b0fc57589");

    // Source modules: Risk - Bailees Customers | confidence=High score=125
    // v57 raw Tosca: Risk - Bailees Customers | OK | guid=3a13d49c-172d-73c0-91ea-b7991fa97b13 | strategy=role-link
    public ILocator RiskBaileesCustomersOK => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-73c0-91ea-b7991fa97b13");

    // Source modules: Risk - Computer Systems | confidence=High score=125
    // v57 raw Tosca: Risk - Computer Systems | OK | guid=3a13d49c-172d-ecfb-0d38-ef21709415e3 | strategy=role-link
    public ILocator RiskComputerSystemsOK => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-ecfb-0d38-ef21709415e3");

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: UMB Navigation Links | SFP - 10 Liability/Farm | guid=3a13d49c-1697-6bf0-f011-0c6b89932520 | strategy=role-link
    public ILocator SFP10LiabilityFarm => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-6bf0-f011-0c6b89932520");

    // Source modules: Common Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: Insurance Designee | Save for Later | guid=3a13d49c-171e-cfec-8c22-a2e5f7a16ea9 | strategy=role-link
    public ILocator SaveForLater => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-171e-cfec-8c22-a2e5f7a16ea9");

    // Source modules: Common Navigation Links | confidence=Medium score=113
    public ILocator SaveForLaterOK => _page.GetByRole(AriaRole.Link, new() { Name = "Save for Later - OK", Exact = true });

    // Source modules: Dashboard|Search for Policies / Quotes | confidence=High score=125
    public ILocator SearchButton => _page.GetByRole(AriaRole.Link, new() { Name = "Search Button", Exact = true });

    // Source modules: Dashboard|Search for Policies / Quotes | confidence=High score=127
    public ILocator SearchMethodEGDescriptionPolicy => _page.Locator("[id='_keynameAdvSearch1-inputEl']");

    // Source modules: Risk - Computer Systems | confidence=High score=125
    // v57 raw Tosca: Risk - Computer Systems | Search Result | guid=3a13d49c-172d-64b2-5e0b-f700919e536b | strategy=id
    public ILocator SearchResult4E620 => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-64b2-5e0b-f700919e536b");

    // Source modules: Risk - Bailees Customers | confidence=High score=125
    // v57 raw Tosca: Risk - Bailees Customers | Search Result | guid=3a13d49c-172d-993e-d4b4-b6589f8b3c4f | strategy=id
    public ILocator SearchResultA1BFB => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-993e-d4b4-b6589f8b3c4f");

    // Source modules: Risk - Accounts Receivable | confidence=High score=125
    // v57 raw Tosca: Risk - Accounts Receivable | Search Result | guid=3a13d49c-172d-357f-0e66-b5c4938eeda1 | strategy=id
    public ILocator SearchResultEAFB8 => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-357f-0e66-b5c4938eeda1");

    // Source modules: Dashboard|QuickSearch | confidence=High score=127
    public ILocator SearchText => _page.Locator("[id='quickSearchTextId-inputEl']");

    // Source modules: Risk - Accounts Receivable | confidence=High score=125
    // v57 raw Tosca: Risk - Accounts Receivable | Search Value | guid=3a13d49c-172d-5b3b-bf4a-564b4d225f8b | strategy=id
    public ILocator SearchValue79E46 => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-5b3b-bf4a-564b4d225f8b");

    // Source modules: Risk - Computer Systems | confidence=High score=125
    // v57 raw Tosca: Risk - Computer Systems | Search Value | guid=3a13d49c-172d-ee80-e28d-fc69f13515c2 | strategy=id
    public ILocator SearchValue9FCD1 => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-ee80-e28d-fc69f13515c2");

    // Source modules: Risk - Bailees Customers | confidence=High score=125
    // v57 raw Tosca: Risk - Bailees Customers | Search Value | guid=3a13d49c-172d-481d-8ffc-b47cce97273a | strategy=id
    public ILocator SearchValueCA6A6 => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-481d-8ffc-b47cce97273a");

    // Source modules: Duck Creek Policy | confidence=Medium score=113
    // v57 raw Tosca: Duck Creek Policy | Show me | guid=3a13d49c-172d-7eb7-b67c-48a3db5d7efb | strategy=role-link
    public ILocator ShowMe => _page.GetByRole(AriaRole.Link, new() { Name = "Show me", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator SplitBIDed => _page.GetByText("Split BI Ded", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator SplitPDDed => _page.GetByText("Split PD Ded", new() { Exact = true });

    // Source modules: Taskbar|Start Button | confidence=Medium score=116
    public ILocator Start => _page.GetByRole(AriaRole.Button, new() { Name = "Start", Exact = true });

    // Source modules: Http Error Msg | confidence=Medium score=108
    public ILocator TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus0 => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0");

    // Source modules:  | confidence=Review score=97
    // v57 raw Tosca:  | SearchValue | guid=3a13d49c-1688-9e6e-3bd3-33b0fdcf5ebc | strategy=associatedlabel-from-v55
    public ILocator Value => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1688-9e6e-3bd3-33b0fdcf5ebc");

    // Source modules: Dashboard|Search for Policies / Quotes | confidence=High score=127
    public ILocator ViewPolicy => _page.GetByRole(AriaRole.Link, new() { Name = "View Policy", Exact = true });

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: UMB Navigation Links | Watercraft Liability | guid=3a13d49c-1697-3ef2-a3f1-10c0a03b8675 | strategy=role-link
    public ILocator WatercraftLiability => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-3ef2-a3f1-10c0a03b8675");

}
