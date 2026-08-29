using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class PolicyWorkflowLocators
{
    private readonly IPage _page;
    public PolicyWorkflowLocators(IPage page) => _page = page;

    public ILocator AJAXErrorCheck => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "AJAX Error Check");

    public ILocator AccountsReceivableHeading => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-d12e-b14d-c5c2d366b2bb");

    public ILocator AddClient => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1679-21d3-307d-9ac2d420ffb8");

    public ILocator AggregateLimit => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-7505-61ee-35ff4430c9d2");

    public ILocator Businessowners => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-10a4-df69-6f4dc21706f3");

    public ILocator CPDetail => _page.GetByRole(AriaRole.Link, new() { Name = "CP Detail", Exact = true });

    public ILocator CPPLiability => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-b124-eb68-7d72e20b1cb2");

    public ILocator CTStraightThroughLiabilityLimitTo1M => _page.GetByText("CT StraightThrough Liability Limit to 1M", new() { Exact = true });

    public ILocator CommercialAuto => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-50ef-718a-9eff146a551c");

    public ILocator DedType => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-a97e-db29-b634782f5f0c");

    public ILocator DeductibleBasis => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-b6ea-5343-993db0eb88bd");

    public ILocator DescriptionOfSpecifiedOperation => _page.GetByRole(AriaRole.Textbox, new() { Name = "Description of Specified Operation", Exact = true });

    public ILocator DoesAnyRiskGeneratePowerOtherThanPrivateWindmillsOrEmergencyBackup => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-f4d8-335f-cea3f953bf5e");

    public ILocator EmployersLiab => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-9599-a2ea-9374855150e2");

    public ILocator EndorsementHeading => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-9372-feda-ed7f73106a12");

    public ILocator FireDamage => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-2650-8f24-19c05dba284b");

    public ILocator GeneralLiab => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-0f88-b883-20bf5c0d330f");

    public ILocator HasTheApplicantBeenInBusinessForAtLeast3YearsWithContinuousWorkersCompensationCoverage => _page.GetByRole(AriaRole.Textbox, new() { Name = "Has the applicant been in business for at least 3 years with continuous Workers Compensation Coverage?*", Exact = true });

    public ILocator HomeownerSLiability => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-b30f-c867-596198679155");

    public ILocator OK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    public ILocator IFRAMEDuckCreekPolicyDescriptionOfOther => _page.GetByText("Description of Other", new() { Exact = true });

    public ILocator IFRAMEDuckCreekPolicyOtherCheckBox => _page.GetByText("Other CheckBox", new() { Exact = true });

    public ILocator IMDetail => _page.GetByRole(AriaRole.Link, new() { Name = "IM Detail", Exact = true });

    public ILocator IncludeBusinessowners => _page.Locator("[fieldref=\"LineUmbrellaBusinessOwners.IncludeBusinessOwners\"], [data-fieldref=\"LineUmbrellaBusinessOwners.IncludeBusinessOwners\"]");

    public ILocator IncludeCommercialAuto => _page.Locator("[fieldref=\"LineUmbrellaCommercialAuto.IncludeCommercialAuto\"], [data-fieldref=\"LineUmbrellaCommercialAuto.IncludeCommercialAuto\"]");

    public ILocator IncludeCommercialPackagePolicyLiability => _page.Locator("[fieldref=\"LineUmbrellaCPPLiability.IncludeCPPLiability\"], [data-fieldref=\"LineUmbrellaCPPLiability.IncludeCPPLiability\"]");

    public ILocator IncludeEmployersLiability => _page.Locator("[fieldref=\"LineUmbrellaEmployersLiability.IncludeEmployersLiability\"], [data-fieldref=\"LineUmbrellaEmployersLiability.IncludeEmployersLiability\"]");

    public ILocator IncludeGeneralLiability => _page.Locator("[fieldref=\"LineUmbrellaGeneralLiability.IncludeGeneralLiability\"], [data-fieldref=\"LineUmbrellaGeneralLiability.IncludeGeneralLiability\"]");

    public ILocator IncludeHomeownerSLiability => _page.Locator("[fieldref=\"LineUmbrellaHomeownersLiability.IncludeHomeownersLiability\"], [data-fieldref=\"LineUmbrellaHomeownersLiability.IncludeHomeownersLiability\"]");

    public ILocator IncludePersonalAutoLiability => _page.Locator("[fieldref=\"LineUmbrellaPersonalAutoLiability.IncludePersonalAutoLiability\"], [data-fieldref=\"LineUmbrellaPersonalAutoLiability.IncludePersonalAutoLiability\"]");

    public ILocator IncludeRentalOwnerSLiability => _page.Locator("[fieldref=\"LineUmbrellaRentalOwnersLiability.IncludeRentalOwnersLiability\"], [data-fieldref=\"LineUmbrellaRentalOwnersLiability.IncludeRentalOwnersLiability\"]");

    public ILocator IncludeSFP10LiabilityFarm => _page.Locator("[fieldref=\"LineUmbrellaSFP10Liability.IncludeSFP10Liability\"], [data-fieldref=\"LineUmbrellaSFP10Liability.IncludeSFP10Liability\"]");

    public ILocator IncludeWatercraftLiability => _page.Locator("[fieldref=\"LineUmbrellaWatercraftLiability.IncludeWatercraftLiability\"], [data-fieldref=\"LineUmbrellaWatercraftLiability.IncludeWatercraftLiability\"]");

    public ILocator IndividualType => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1679-a316-96ce-ca532c48906e");

    public ILocator IsTheInsuredEngagedInAnySnowOrIceRemovalOperations => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-9844-6210-6e05ab67ffc8");

    public ILocator LoadingMessage => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Loading Message");

    public ILocator LoggedInUser => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Logged In User");

    public ILocator Logout => _page.GetByRole(AriaRole.Link, new() { Name = "Logout", Exact = true });

    public ILocator Medical => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-1b2e-8774-90d2b00bf944");

    public ILocator OccurenceLimit => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-6910-f085-905e20437cbe");

    public ILocator OfFullTimeEmployees => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-6b9e-7a82-759a0390c142");

    public ILocator OfPartTimeEmployees => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-d1b3-1a9a-5519e5296a7f");

    public ILocator OfSeasonalTemporaryEmployees => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-4cec-e5f0-b402c1b9fc50");

    public ILocator PersAdvInj => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-88fd-c07c-9f9ab9138604");

    public ILocator PersonalAuto => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-ae5b-45b5-df53d1fb9b8f");

    public ILocator PolicyCovgGLPolicyCovg => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-769e-b228-7a3436bb62eb");

    public ILocator PolicyCovg => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Policy Covg");

    public ILocator PolicyInfoHeader => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Policy Info Header");

    public ILocator PremOpDed => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-277f-f8c3-5a7e01456e49");

    public ILocator PremOpPDDed => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-3255-282f-15a94c7a106d");

    public ILocator ProdBIDed => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-930b-1ff7-13efbf42ac65");

    public ILocator ProdPDDed => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-0ca0-26e9-1f003690dc99");

    public ILocator ProductsAggLimit => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-7641-373b-5b21ae14d400");

    public ILocator PropertyOfOthersRatingGroup => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-702f-ab45-977a2cd5409c");

    public ILocator QuickSearchButton => _page.GetByRole(AriaRole.Link, new() { Name = "QuickSearch Button", Exact = true });

    public ILocator RentalOwnersLiability => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-f99b-bc35-ce694290718a");

    public ILocator ReturnToAdmin => _page.GetByRole(AriaRole.Link, new() { Name = "Return To Admin", Exact = true });

    public ILocator ReturnToCPP => _page.GetByRole(AriaRole.Button, new() { Name = "Return To CPP", Exact = true });

    public ILocator RiskAccountsReceivableOK => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-87fd-649f-1d8b0fc57589");

    public ILocator RiskBaileesCustomersOK => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-73c0-91ea-b7991fa97b13");

    public ILocator RiskComputerSystemsOK => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-ecfb-0d38-ef21709415e3");

    public ILocator SFP10LiabilityFarm => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-6bf0-f011-0c6b89932520");

    public ILocator SaveForLater => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-171e-cfec-8c22-a2e5f7a16ea9");

    public ILocator SaveForLaterOK => _page.GetByRole(AriaRole.Link, new() { Name = "Save for Later - OK", Exact = true });

    public ILocator SearchButton => _page.GetByRole(AriaRole.Link, new() { Name = "Search Button", Exact = true });

    public ILocator SearchMethodEGDescriptionPolicy => _page.Locator("[id='_keynameAdvSearch1-inputEl']");

    public ILocator RiskComputerSystemsSearchResult => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-64b2-5e0b-f700919e536b");

    public ILocator RiskBaileesCustomersSearchResult => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-993e-d4b4-b6589f8b3c4f");

    public ILocator RiskAccountsReceivableSearchResult => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-357f-0e66-b5c4938eeda1");

    public ILocator SearchText => _page.Locator("[id='quickSearchTextId-inputEl']");

    public ILocator RiskAccountsReceivableSearchValue => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-5b3b-bf4a-564b4d225f8b");

    public ILocator RiskComputerSystemsSearchValue => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-ee80-e28d-fc69f13515c2");

    public ILocator RiskBaileesCustomersSearchValue => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-481d-8ffc-b47cce97273a");

    public ILocator ShowMe => _page.GetByRole(AriaRole.Link, new() { Name = "Show me", Exact = true });

    public ILocator SplitBIDed => _page.GetByText("Split BI Ded", new() { Exact = true });

    public ILocator SplitPDDed => _page.GetByText("Split PD Ded", new() { Exact = true });

    public ILocator Start => _page.GetByRole(AriaRole.Button, new() { Name = "Start", Exact = true });

    public ILocator BrowserCommunicationHTTPStatusZero => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0");

    public ILocator Value => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1688-9e6e-3bd3-33b0fdcf5ebc");

    public ILocator ViewPolicy => _page.GetByRole(AriaRole.Link, new() { Name = "View Policy", Exact = true });

    public ILocator WatercraftLiability => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-3ef2-a3f1-10c0a03b8675");
}
