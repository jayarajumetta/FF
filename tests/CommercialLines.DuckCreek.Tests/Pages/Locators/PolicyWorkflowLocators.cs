using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class PolicyWorkflowLocators
{
    private readonly IPage _page;
    public PolicyWorkflowLocators(IPage page) => _page = page;

    // Source modules: AJAX Error | confidence=Medium score=100
    public ILocator AJAXErrorCheck => _page.GetByLabel("AJAX Error Check", new() { Exact = true });

    // Source modules: Specific Underwriting Questions - Accounts Receivable | confidence=High score=97
    public ILocator AccountsReceivableHeading => _page.GetByLabel("Accounts Receivable Heading", new() { Exact = true });

    // Source modules: Client|Add Associated Client | confidence=High score=125
    public ILocator AddClient => _page.GetByRole(AriaRole.Button, new() { Name = "Add Client", Exact = true });

    // Source modules: Policy Covg|GL | confidence=High score=95
    public ILocator AggregateLimit => _page.GetByRole(AriaRole.Textbox, new() { Name = "Aggregate Limit", Exact = true });

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator Businessowners => _page.GetByRole(AriaRole.Link, new() { Name = "Businessowners", Exact = true });

    // Source modules: Policy Info|CPP Specific Fields | confidence=High score=95
    // CPP Only
    public ILocator CPDetail => _page.GetByRole(AriaRole.Button, new() { Name = "CP Detail", Exact = true });

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator CPPLiability => _page.GetByRole(AriaRole.Link, new() { Name = "CPP Liability", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator CTStraightThroughLiabilityLimitTo1M => _page.GetByText("CT StraightThrough Liability Limit to 1M", new() { Exact = true });

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator CommercialAuto => _page.GetByRole(AriaRole.Link, new() { Name = "Commercial Auto", Exact = true });

    // Source modules: Policy Covg|GL | confidence=High score=95
    public ILocator DedType => _page.GetByRole(AriaRole.Textbox, new() { Name = "Ded Type", Exact = true });

    // Source modules: Policy Covg|GL | confidence=High score=95
    public ILocator DeductibleBasis => _page.GetByRole(AriaRole.Textbox, new() { Name = "Deductible Basis", Exact = true });

    // Source modules: Policy Info|Required and Optional Fields | confidence=High score=125
    public ILocator DescriptionOfSpecifiedOperation => _page.GetByRole(AriaRole.Textbox, new() { Name = "Description of Specified Operation", Exact = true });

    // Source modules: Policy Covg | confidence=High score=125
    public ILocator DoesAnyRiskGeneratePowerOtherThanPrivateWindmillsOrEmergencyBackup => _page.GetByRole(AriaRole.Textbox, new() { Name = "Does any Risk generate power other than Private Windmills or Emergency Backup?*", Exact = true });

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator EmployersLiab => _page.GetByRole(AriaRole.Link, new() { Name = "Employers Liab", Exact = true });

    // Source modules: Endorsement - Main | confidence=High score=97
    public ILocator EndorsementHeading => _page.GetByLabel("Endorsement Heading", new() { Exact = true });

    // Source modules: Policy Covg|GL | confidence=High score=95
    public ILocator FireDamage => _page.GetByRole(AriaRole.Textbox, new() { Name = "Fire Damage", Exact = true });

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator GeneralLiab => _page.GetByRole(AriaRole.Link, new() { Name = "General Liab", Exact = true });

    // Source modules: Policy Info|WC Specific Fields | confidence=High score=125
    // WC only
    public ILocator HasTheApplicantBeenInBusinessForAtLeast3YearsWithContinuousWorkersCompensationCoverage => _page.GetByRole(AriaRole.Textbox, new() { Name = "Has the applicant been in business for at least 3 years with continuous Workers Compensation Coverage?*", Exact = true });

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator HomeownerSLiability => _page.GetByRole(AriaRole.Link, new() { Name = "Homeowner's Liability", Exact = true });

    // Source modules: Http Error Msg | confidence=Medium score=113
    public ILocator HttpErrorMsgOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator IFRAMEDuckCreekPolicyDescriptionOfOther => _page.GetByText("Description of Other", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator IFRAMEDuckCreekPolicyOtherCheckBox => _page.GetByText("Other CheckBox", new() { Exact = true });

    // Source modules: Policy Info|CPP Specific Fields | confidence=High score=95
    // CPP Only
    public ILocator IMDetail => _page.GetByRole(AriaRole.Button, new() { Name = "IM Detail", Exact = true });

    // Source modules: Policy Covg | confidence=High score=124
    public ILocator IncludeBusinessowners => _page.GetByRole(AriaRole.Checkbox, new() { Name = "Include Businessowners", Exact = true });

    // Source modules: Policy Covg | confidence=High score=124
    public ILocator IncludeCommercialAuto => _page.GetByRole(AriaRole.Checkbox, new() { Name = "Include Commercial Auto", Exact = true });

    // Source modules: Policy Covg | confidence=High score=124
    public ILocator IncludeCommercialPackagePolicyLiability => _page.GetByRole(AriaRole.Checkbox, new() { Name = "Include Commercial Package Policy Liability", Exact = true });

    // Source modules: Policy Covg | confidence=High score=124
    public ILocator IncludeEmployersLiability => _page.GetByRole(AriaRole.Checkbox, new() { Name = "Include Employers Liability", Exact = true });

    // Source modules: Policy Covg | confidence=High score=124
    public ILocator IncludeGeneralLiability => _page.GetByRole(AriaRole.Checkbox, new() { Name = "Include General Liability", Exact = true });

    // Source modules: Policy Covg | confidence=High score=124
    public ILocator IncludeHomeownerSLiability => _page.GetByRole(AriaRole.Checkbox, new() { Name = "Include Homeowner's Liability", Exact = true });

    // Source modules: Policy Covg | confidence=High score=124
    public ILocator IncludePersonalAutoLiability => _page.GetByRole(AriaRole.Checkbox, new() { Name = "Include Personal Auto Liability", Exact = true });

    // Source modules: Policy Covg | confidence=High score=124
    public ILocator IncludeRentalOwnerSLiability => _page.GetByRole(AriaRole.Checkbox, new() { Name = "Include Rental Owner's Liability", Exact = true });

    // Source modules: Policy Covg | confidence=High score=124
    public ILocator IncludeSFP10LiabilityFarm => _page.GetByRole(AriaRole.Checkbox, new() { Name = "Include SFP - 10 Liability/Farm", Exact = true });

    // Source modules: Policy Covg | confidence=High score=124
    public ILocator IncludeWatercraftLiability => _page.GetByRole(AriaRole.Checkbox, new() { Name = "Include Watercraft Liability", Exact = true });

    // Source modules: Client|Add Associated Client | confidence=High score=125
    public ILocator IndividualType => _page.GetByRole(AriaRole.Textbox, new() { Name = "IndividualType", Exact = true });

    // Source modules: Policy Covg|GL | confidence=High score=125
    public ILocator IsTheInsuredEngagedInAnySnowOrIceRemovalOperations => _page.GetByRole(AriaRole.Textbox, new() { Name = "Is the Insured engaged in any Snow or Ice Removal Operations?*", Exact = true });

    // Source modules: Indicators and Errors | confidence=High score=127
    // This DIV appears during a refresh of the screen (working in the background) and can be used as a WaitOn for stability.
    public ILocator LoadingMessage => _page.GetByLabel("Loading Message", new() { Exact = true });

    // Source modules: Logout | confidence=Review score=97
    public ILocator LoggedInUser => _page.GetByLabel("Logged In User", new() { Exact = true });

    // Source modules:  | confidence=High score=97
    public ILocator Logout => _page.GetByRole(AriaRole.Link, new() { Name = "Logout", Exact = true });

    // Source modules: Policy Covg|GL | confidence=High score=95
    public ILocator Medical => _page.GetByRole(AriaRole.Textbox, new() { Name = "Medical", Exact = true });

    // Source modules:  | confidence=High score=125
    public ILocator OK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: Policy Covg|GL | confidence=High score=95
    public ILocator OccurenceLimit => _page.GetByRole(AriaRole.Textbox, new() { Name = "Occurence Limit", Exact = true });

    // Source modules: Policy Covg|GL | confidence=High score=95
    public ILocator OfFullTimeEmployees => _page.GetByRole(AriaRole.Textbox, new() { Name = "# of Full-Time Employees*", Exact = true });

    // Source modules: Policy Covg|GL | confidence=High score=95
    public ILocator OfPartTimeEmployees => _page.GetByRole(AriaRole.Textbox, new() { Name = "# of Part-Time Employees*", Exact = true });

    // Source modules: Policy Covg|GL | confidence=High score=95
    public ILocator OfSeasonalTemporaryEmployees => _page.GetByRole(AriaRole.Textbox, new() { Name = "# of Seasonal/Temporary Employees*", Exact = true });

    // Source modules: Policy Covg|GL | confidence=High score=95
    public ILocator PersAdvInj => _page.GetByRole(AriaRole.Textbox, new() { Name = "Pers Adv Inj", Exact = true });

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator PersonalAuto => _page.GetByRole(AriaRole.Link, new() { Name = "Personal Auto", Exact = true });

    // Source modules: Policy Covg|GL | confidence=High score=127
    public ILocator PolicyCovg6B651 => _page.GetByLabel("Policy Covg", new() { Exact = true });

    // Source modules: Policy Covg | confidence=High score=127
    public ILocator PolicyCovgFF145 => _page.GetByLabel("Policy Covg", new() { Exact = true });

    // Source modules: Policy Info|Required and Optional Fields | confidence=High score=97
    public ILocator PolicyInfoHeader => _page.GetByLabel("Policy Info Header", new() { Exact = true });

    // Source modules: Policy Covg|GL | confidence=High score=95
    public ILocator PremOpDed => _page.GetByRole(AriaRole.Textbox, new() { Name = "PremOp Ded", Exact = true });

    // Source modules: Policy Covg|GL | confidence=High score=95
    public ILocator PremOpPDDed => _page.GetByRole(AriaRole.Textbox, new() { Name = "PremOp PD Ded", Exact = true });

    // Source modules: Policy Covg|GL | confidence=High score=95
    public ILocator ProdBIDed => _page.GetByRole(AriaRole.Textbox, new() { Name = "Prod BI Ded", Exact = true });

    // Source modules: Policy Covg|GL | confidence=High score=95
    public ILocator ProdPDDed => _page.GetByRole(AriaRole.Textbox, new() { Name = "Prod PD Ded", Exact = true });

    // Source modules: Policy Covg|GL | confidence=High score=95
    public ILocator ProductsAggLimit => _page.GetByRole(AriaRole.Textbox, new() { Name = "Products Agg Limit", Exact = true });

    // Source modules: Property Add Class | confidence=High score=125
    public ILocator PropertyOfOthersRatingGroup => _page.GetByRole(AriaRole.Textbox, new() { Name = "Property of Others Rating Group", Exact = true });

    // Source modules: Dashboard|QuickSearch | confidence=High score=127
    public ILocator QuickSearchButton => _page.GetByRole(AriaRole.Link, new() { Name = "QuickSearch Button", Exact = true });

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator RentalOwnersLiability => _page.GetByRole(AriaRole.Link, new() { Name = "Rental Owners Liability", Exact = true });

    // Source modules: Restart Microsoft Edge Message | confidence=Medium score=116
    public ILocator RestartMicrosoftEdgeMessageOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: Common Navigation Links | confidence=Medium score=113
    public ILocator ReturnToAdmin => _page.GetByRole(AriaRole.Link, new() { Name = "Return To Admin", Exact = true });

    // Source modules: Common Navigation Links | confidence=High score=125
    public ILocator ReturnToCPP => _page.GetByRole(AriaRole.Button, new() { Name = "Return To CPP", Exact = true });

    // Source modules: Risk - Accounts Receivable | confidence=High score=125
    public ILocator RiskAccountsReceivableOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: Risk - Bailees Customers | confidence=High score=125
    public ILocator RiskBaileesCustomersOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: Risk - Computer Systems | confidence=High score=125
    public ILocator RiskComputerSystemsOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator SFP10LiabilityFarm => _page.GetByRole(AriaRole.Link, new() { Name = "SFP - 10 Liability/Farm", Exact = true });

    // Source modules: Common Navigation Links | confidence=Medium score=113
    public ILocator SaveForLater => _page.GetByRole(AriaRole.Link, new() { Name = "Save for Later", Exact = true });

    // Source modules: Common Navigation Links | confidence=Medium score=113
    public ILocator SaveForLaterOK => _page.GetByRole(AriaRole.Link, new() { Name = "Save for Later - OK", Exact = true });

    // Source modules: Dashboard|Search for Policies / Quotes | confidence=High score=125
    public ILocator SearchButton => _page.GetByRole(AriaRole.Button, new() { Name = "Search Button", Exact = true });

    // Source modules: Dashboard|Search for Policies / Quotes | confidence=High score=127
    public ILocator SearchMethodEGDescriptionPolicy => _page.GetByRole(AriaRole.Textbox, new() { Name = "Search Method (e.g. Description/Policy#)", Exact = true });

    // Source modules: Risk - Computer Systems | confidence=High score=125
    public ILocator SearchResult4E620 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Search Result", Exact = true });

    // Source modules: Risk - Bailees Customers | confidence=High score=125
    public ILocator SearchResultA1BFB => _page.GetByRole(AriaRole.Textbox, new() { Name = "Search Result", Exact = true });

    // Source modules: Risk - Accounts Receivable | confidence=High score=125
    public ILocator SearchResultEAFB8 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Search Result", Exact = true });

    // Source modules: Dashboard|QuickSearch | confidence=High score=127
    public ILocator SearchText => _page.GetByRole(AriaRole.Textbox, new() { Name = "Search Text", Exact = true });

    // Source modules: Risk - Accounts Receivable | confidence=High score=125
    public ILocator SearchValue79E46 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Search Value", Exact = true });

    // Source modules: Risk - Computer Systems | confidence=High score=125
    public ILocator SearchValue9FCD1 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Search Value", Exact = true });

    // Source modules: Risk - Bailees Customers | confidence=High score=125
    public ILocator SearchValueCA6A6 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Search Value", Exact = true });

    // Source modules: Duck Creek Policy | confidence=Medium score=113
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
    public ILocator TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus0 => _page.GetByLabel("The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0", new() { Exact = true });

    // Source modules:  | confidence=Review score=97
    public ILocator Value => _page.GetByLabel("value", new() { Exact = true });

    // Source modules: Dashboard|Search for Policies / Quotes | confidence=High score=127
    public ILocator ViewPolicy => _page.GetByRole(AriaRole.Link, new() { Name = "View Policy", Exact = true });

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator WatercraftLiability => _page.GetByRole(AriaRole.Link, new() { Name = "Watercraft Liability", Exact = true });

}
