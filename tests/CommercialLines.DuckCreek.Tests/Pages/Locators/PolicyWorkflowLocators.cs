using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class PolicyWorkflowLocators
{
    private readonly IPage _page;
    public PolicyWorkflowLocators(IPage page) => _page = page;

    // Source modules: AJAX Error | confidence=Medium score=100
    public ILocator AJAXErrorCheck => _page.GetByLabel("AJAX Error Check", new() { Exact = true });

    // Source modules: Specific Underwriting Questions - Accounts Receivable | confidence=High score=97
    // v56 raw Tosca primary: Specific Underwriting Questions - Accounts Receivable | Accounts Receivable Heading | Id
    public ILocator AccountsReceivableHeading => _page.Locator("[id=\"pageTitle\"]");

    // Source modules: Client|Add Associated Client | confidence=High score=125
    // v56 raw Tosca primary:  | Add Client | DuckCreekId | frame=iframe
    public ILocator AddClient => _page.FrameLocator("iframe").Locator("[duckcreekid=\"Add Client\"], [data-duckcreekid=\"Add Client\"]");

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v56 raw Tosca primary: Policy Covg|GL | Aggregate Limit | DuckCreekId
    public ILocator AggregateLimit => _page.Locator("[duckcreekid=\"LineInput.PolicyAggregateLimit\"], [data-duckcreekid=\"LineInput.PolicyAggregateLimit\"]");

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator Businessowners => _page.GetByRole(AriaRole.Link, new() { Name = "Businessowners", Exact = true });

    // Source modules: Policy Info|CPP Specific Fields | confidence=High score=95
    // CPP Only
    // v56 raw Tosca primary: Policy Info|CPP Specific Fields | CP Detail | DuckCreekId
    public ILocator CPDetail => _page.Locator("[duckcreekid=\"Detail\"], [data-duckcreekid=\"Detail\"]");

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator CPPLiability => _page.GetByRole(AriaRole.Link, new() { Name = "CPP Liability", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    // v56 raw Tosca primary:  | -- Limit | DuckCreekId
    public ILocator CTStraightThroughLiabilityLimitTo1M => _page.Locator("[duckcreekid=\"EndInstallationToolsAndEquipmentInput.NonOwnedToolsAndEquipmentLimit\"], [data-duckcreekid=\"EndInstallationToolsAndEquipmentInput.NonOwnedToolsAndEquipmentLimit\"]");

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator CommercialAuto => _page.GetByRole(AriaRole.Link, new() { Name = "Commercial Auto", Exact = true });

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v56 raw Tosca primary: Policy Covg|GL | Ded Type | DuckCreekId
    public ILocator DedType => _page.Locator("[duckcreekid=\"LineInput.DeductibleType\"], [data-duckcreekid=\"LineInput.DeductibleType\"]");

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v56 raw Tosca primary: Policy Covg|GL | Deductible Basis | DuckCreekId
    public ILocator DeductibleBasis => _page.Locator("[duckcreekid=\"LineInput.DeductibleScope\"], [data-duckcreekid=\"LineInput.DeductibleScope\"]");

    // Source modules: Policy Info|Required and Optional Fields | confidence=High score=125
    public ILocator DescriptionOfSpecifiedOperation => _page.GetByRole(AriaRole.Textbox, new() { Name = "Description of Specified Operation", Exact = true });

    // Source modules: Policy Covg | confidence=High score=125
    // v56 raw Tosca primary: Policy Covg | Does any Risk generate power other than Private Windmills or Emergency Backup?* | DuckCreekId
    public ILocator DoesAnyRiskGeneratePowerOtherThanPrivateWindmillsOrEmergencyBackup => _page.Locator("[duckcreekid=\"PolicyInput.AnyRiskPowerUnitOtherThanWindmillOrBackup\"], [data-duckcreekid=\"PolicyInput.AnyRiskPowerUnitOtherThanWindmillOrBackup\"]");

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator EmployersLiab => _page.GetByRole(AriaRole.Link, new() { Name = "Employers Liab", Exact = true });

    // Source modules: Endorsement - Main | confidence=High score=97
    // v56 raw Tosca primary: Endorsement - Main |  Endorsement Heading | Id | frame=iframe
    public ILocator EndorsementHeading => _page.FrameLocator("iframe").Locator("[id=\"pageTitle\"]");

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v56 raw Tosca primary: Policy Covg|GL | Fire Damage | DuckCreekId
    public ILocator FireDamage => _page.Locator("[duckcreekid=\"CovFireDamageInput.FireDamage\"], [data-duckcreekid=\"CovFireDamageInput.FireDamage\"]");

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator GeneralLiab => _page.GetByRole(AriaRole.Link, new() { Name = "General Liab", Exact = true });

    // Source modules: Policy Info|WC Specific Fields | confidence=High score=125
    // WC only
    // v56 raw Tosca primary: Policy Info|WC Specific Fields | Has the applicant been in business for at least 3 years with continuous Workers Compensation Coverage?* | DuckCreekId
    public ILocator HasTheApplicantBeenInBusinessForAtLeast3YearsWithContinuousWorkersCompensationCoverage => _page.Locator("[duckcreekid=\"PolicyInput.ContinuousWCCoverageForAtLeast3Years\"], [data-duckcreekid=\"PolicyInput.ContinuousWCCoverageForAtLeast3Years\"]");

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator HomeownerSLiability => _page.GetByRole(AriaRole.Link, new() { Name = "Homeowner's Liability", Exact = true });

    // Source modules: Http Error Msg | confidence=Medium score=113
    // v56 raw Tosca primary:  | OK | Id+DuckCreekId | frame=iframe
    public ILocator HttpErrorMsgOK => _page.FrameLocator("iframe").Locator("a[id=\"ext-element-18\"][duckcreekid=\"OK\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    // v56 raw Tosca primary:  | Description of Other | attributes_fieldref | frame=iframe
    public ILocator IFRAMEDuckCreekPolicyDescriptionOfOther => _page.FrameLocator("iframe").Locator("[fieldref=\"CovExclusionDesignatedWorkInput.OtherDescription\"], [data-fieldref=\"CovExclusionDesignatedWorkInput.OtherDescription\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    // v56 raw Tosca primary:  | Other CheckBox | attributes_fieldref | frame=iframe
    public ILocator IFRAMEDuckCreekPolicyOtherCheckBox => _page.FrameLocator("iframe").Locator("[fieldref=\"CovExclusionDesignatedWorkInput.Other\"], [data-fieldref=\"CovExclusionDesignatedWorkInput.Other\"]");

    // Source modules: Policy Info|CPP Specific Fields | confidence=High score=95
    // CPP Only
    // v56 raw Tosca primary: Policy Info|CPP Specific Fields | IM Detail | DuckCreekId
    // v56 semantic alias: same physical raw-Tosca control as CPDetail
    public ILocator IMDetail => CPDetail;

    // Source modules: Policy Covg | confidence=High score=124
    // v56 raw Tosca primary: Policy Covg | Include Businessowners | attributes_fieldref
    public ILocator IncludeBusinessowners => _page.Locator("[fieldref=\"LineUmbrellaBusinessOwners.IncludeBusinessOwners\"], [data-fieldref=\"LineUmbrellaBusinessOwners.IncludeBusinessOwners\"]");

    // Source modules: Policy Covg | confidence=High score=124
    // v56 raw Tosca primary: Policy Covg | Include Commercial Auto | attributes_fieldref
    public ILocator IncludeCommercialAuto => _page.Locator("[fieldref=\"LineUmbrellaCommercialAuto.IncludeCommercialAuto\"], [data-fieldref=\"LineUmbrellaCommercialAuto.IncludeCommercialAuto\"]");

    // Source modules: Policy Covg | confidence=High score=124
    // v56 raw Tosca primary: Policy Covg | Include Commercial Package Policy Liability | attributes_fieldref
    public ILocator IncludeCommercialPackagePolicyLiability => _page.Locator("[fieldref=\"LineUmbrellaCPPLiability.IncludeCPPLiability\"], [data-fieldref=\"LineUmbrellaCPPLiability.IncludeCPPLiability\"]");

    // Source modules: Policy Covg | confidence=High score=124
    // v56 raw Tosca primary: Policy Covg | Include Employers Liability | attributes_fieldref
    public ILocator IncludeEmployersLiability => _page.Locator("[fieldref=\"LineUmbrellaEmployersLiability.IncludeEmployersLiability\"], [data-fieldref=\"LineUmbrellaEmployersLiability.IncludeEmployersLiability\"]");

    // Source modules: Policy Covg | confidence=High score=124
    // v56 raw Tosca primary: Policy Covg | Include General Liability | attributes_fieldref
    public ILocator IncludeGeneralLiability => _page.Locator("[fieldref=\"LineUmbrellaGeneralLiability.IncludeGeneralLiability\"], [data-fieldref=\"LineUmbrellaGeneralLiability.IncludeGeneralLiability\"]");

    // Source modules: Policy Covg | confidence=High score=124
    // v56 raw Tosca primary: Policy Covg | Include Homeowner's Liability | attributes_fieldref
    public ILocator IncludeHomeownerSLiability => _page.Locator("[fieldref=\"LineUmbrellaHomeownersLiability.IncludeHomeownersLiability\"], [data-fieldref=\"LineUmbrellaHomeownersLiability.IncludeHomeownersLiability\"]");

    // Source modules: Policy Covg | confidence=High score=124
    // v56 raw Tosca primary: Policy Covg | Include Personal Auto Liability | attributes_fieldref
    public ILocator IncludePersonalAutoLiability => _page.Locator("[fieldref=\"LineUmbrellaPersonalAutoLiability.IncludePersonalAutoLiability\"], [data-fieldref=\"LineUmbrellaPersonalAutoLiability.IncludePersonalAutoLiability\"]");

    // Source modules: Policy Covg | confidence=High score=124
    // v56 raw Tosca primary: Policy Covg | Include Rental Owner's Liability | attributes_fieldref
    public ILocator IncludeRentalOwnerSLiability => _page.Locator("[fieldref=\"LineUmbrellaRentalOwnersLiability.IncludeRentalOwnersLiability\"], [data-fieldref=\"LineUmbrellaRentalOwnersLiability.IncludeRentalOwnersLiability\"]");

    // Source modules: Policy Covg | confidence=High score=124
    // v56 raw Tosca primary: Policy Covg | Include SFP - 10 Liability/Farm | attributes_fieldref
    public ILocator IncludeSFP10LiabilityFarm => _page.Locator("[fieldref=\"LineUmbrellaSFP10Liability.IncludeSFP10Liability\"], [data-fieldref=\"LineUmbrellaSFP10Liability.IncludeSFP10Liability\"]");

    // Source modules: Policy Covg | confidence=High score=124
    // v56 raw Tosca primary: Policy Covg | Include Watercraft Liability | attributes_fieldref
    public ILocator IncludeWatercraftLiability => _page.Locator("[fieldref=\"LineUmbrellaWatercraftLiability.IncludeWatercraftLiability\"], [data-fieldref=\"LineUmbrellaWatercraftLiability.IncludeWatercraftLiability\"]");

    // Source modules: Client|Add Associated Client | confidence=High score=125
    // v56 raw Tosca primary:  | IndividualType | DuckCreekId | frame=iframe
    public ILocator IndividualType => _page.FrameLocator("iframe").Locator("[duckcreekid=\"AdditionalOtherInterestAssociatedClientInput.IndividualType\"], [data-duckcreekid=\"AdditionalOtherInterestAssociatedClientInput.IndividualType\"]");

    // Source modules: Policy Covg|GL | confidence=High score=125
    // v56 raw Tosca primary: Policy Covg|GL | Is the Insured engaged in any Snow or Ice Removal Operations?* | DuckCreekId
    public ILocator IsTheInsuredEngagedInAnySnowOrIceRemovalOperations => _page.Locator("[duckcreekid=\"LineInput.InsuredEngaged\"], [data-duckcreekid=\"LineInput.InsuredEngaged\"]");

    // Source modules: Indicators and Errors | confidence=High score=127
    // This DIV appears during a refresh of the screen (working in the background) and can be used as a WaitOn for stability.
    public ILocator LoadingMessage => _page.GetByLabel("Loading Message", new() { Exact = true });

    // Source modules: Logout | confidence=Review score=97
    public ILocator LoggedInUser => _page.GetByLabel("Logged In User", new() { Exact = true });

    // Source modules:  | confidence=High score=97
    public ILocator Logout => _page.GetByRole(AriaRole.Link, new() { Name = "Logout", Exact = true });

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v56 raw Tosca primary: Policy Covg|GL | Medical | DuckCreekId
    public ILocator Medical => _page.Locator("[duckcreekid=\"CovMedicalInput.Medical\"], [data-duckcreekid=\"CovMedicalInput.Medical\"]");

    // Source modules:  | confidence=High score=125
    public ILocator OK => HttpErrorMsgOK; // semantic alias; locator defined once

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v56 raw Tosca primary: Policy Covg|GL | Occurence Limit | DuckCreekId
    public ILocator OccurenceLimit => _page.Locator("[duckcreekid=\"LineInput.PolicyPerOccurenceLimit\"], [data-duckcreekid=\"LineInput.PolicyPerOccurenceLimit\"]");

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v56 raw Tosca primary: Policy Covg|GL | # of Full-Time Employees* | Id+Name+DuckCreekId
    public ILocator OfFullTimeEmployees => _page.Locator("input[id=\"f_l5E228A3F9AC041EBB7129353068D3F69165_3_1-inputEl\"][name=\"int_165\"][duckcreekid=\"LineInput.NumberOfFullTimeEmployees\"]");

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v56 raw Tosca primary: Policy Covg|GL | # of Part-Time Employees* | Id+Name+DuckCreekId
    public ILocator OfPartTimeEmployees => _page.Locator("input[id=\"f_l5E228A3F9AC041EBB7129353068D3F69166_3_1-inputEl\"][name=\"int_166\"][duckcreekid=\"LineInput.NumberOfPartTimeEmployees\"]");

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v56 raw Tosca primary: Policy Covg|GL | # of Seasonal/Temporary Employees* | Id+Name+DuckCreekId
    public ILocator OfSeasonalTemporaryEmployees => _page.Locator("input[id=\"f_l5E228A3F9AC041EBB7129353068D3F69167_3_1-inputEl\"][name=\"int_167\"][duckcreekid=\"LineInput.NumberOfSeasonalTemporaryEmployees\"]");

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v56 raw Tosca primary: Policy Covg|GL | Pers Adv Inj | DuckCreekId
    public ILocator PersAdvInj => _page.Locator("[duckcreekid=\"CovPersonalAdvertisingInjuryInput.PersonalAdvertisingInjury\"], [data-duckcreekid=\"CovPersonalAdvertisingInjuryInput.PersonalAdvertisingInjury\"]");

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator PersonalAuto => _page.GetByRole(AriaRole.Link, new() { Name = "Personal Auto", Exact = true });

    // Source modules: Policy Covg|GL | confidence=High score=127
    // v56 raw Tosca primary: Policy Covg|GL | Policy Covg | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountsReceivableHeading
    public ILocator PolicyCovg6B651 => AccountsReceivableHeading;

    // Source modules: Policy Covg | confidence=High score=127
    public ILocator PolicyCovgFF145 => PolicyCovg6B651; // semantic alias; locator defined once

    // Source modules: Policy Info|Required and Optional Fields | confidence=High score=97
    public ILocator PolicyInfoHeader => _page.GetByLabel("Policy Info Header", new() { Exact = true });

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v56 raw Tosca primary: Policy Covg|GL | PremOp Ded | DuckCreekId
    public ILocator PremOpDed => _page.Locator("[duckcreekid=\"LineInput.Deductible\"], [data-duckcreekid=\"LineInput.Deductible\"]");

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v56 raw Tosca primary: Policy Covg|GL | PremOp PD Ded | DuckCreekId
    public ILocator PremOpPDDed => _page.Locator("[duckcreekid=\"LineInput.DeductiblePD\"], [data-duckcreekid=\"LineInput.DeductiblePD\"]");

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v56 raw Tosca primary: Policy Covg|GL | Prod BI Ded | DuckCreekId
    public ILocator ProdBIDed => _page.Locator("[duckcreekid=\"LineInput.DeductibleProducts\"], [data-duckcreekid=\"LineInput.DeductibleProducts\"]");

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v56 raw Tosca primary: Policy Covg|GL | Prod PD Ded | DuckCreekId
    public ILocator ProdPDDed => _page.Locator("[duckcreekid=\"LineInput.DeductiblePDProducts\"], [data-duckcreekid=\"LineInput.DeductiblePDProducts\"]");

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v56 raw Tosca primary: Policy Covg|GL | Products Agg Limit | DuckCreekId
    public ILocator ProductsAggLimit => _page.Locator("[duckcreekid=\"LineInput.ProductsAggregateLimit\"], [data-duckcreekid=\"LineInput.ProductsAggregateLimit\"]");

    // Source modules: Property Add Class | confidence=High score=125
    // v56 raw Tosca primary: Property Add Class | Property of Others Rating Group | DuckCreekId
    public ILocator PropertyOfOthersRatingGroup => _page.Locator("[duckcreekid=\"RiskInput.RatingGroupID\"], [data-duckcreekid=\"RiskInput.RatingGroupID\"]");

    // Source modules: Dashboard|QuickSearch | confidence=High score=127
    public ILocator QuickSearchButton => _page.GetByRole(AriaRole.Link, new() { Name = "QuickSearch Button", Exact = true });

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator RentalOwnersLiability => _page.GetByRole(AriaRole.Link, new() { Name = "Rental Owners Liability", Exact = true });

    // Source modules: Restart Microsoft Edge Message | confidence=Medium score=116
    public ILocator RestartMicrosoftEdgeMessageOK => HttpErrorMsgOK; // semantic alias; locator defined once

    // Source modules: Common Navigation Links | confidence=Medium score=113
    public ILocator ReturnToAdmin => _page.GetByRole(AriaRole.Link, new() { Name = "Return To Admin", Exact = true });

    // Source modules: Common Navigation Links | confidence=High score=125
    public ILocator ReturnToCPP => _page.GetByRole(AriaRole.Button, new() { Name = "Return To CPP", Exact = true });

    // Source modules: Risk - Accounts Receivable | confidence=High score=125
    public ILocator RiskAccountsReceivableOK => HttpErrorMsgOK; // semantic alias; locator defined once

    // Source modules: Risk - Bailees Customers | confidence=High score=125
    public ILocator RiskBaileesCustomersOK => HttpErrorMsgOK; // semantic alias; locator defined once

    // Source modules: Risk - Computer Systems | confidence=High score=125
    public ILocator RiskComputerSystemsOK => HttpErrorMsgOK; // semantic alias; locator defined once

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator SFP10LiabilityFarm => _page.GetByRole(AriaRole.Link, new() { Name = "SFP - 10 Liability/Farm", Exact = true });

    // Source modules: Common Navigation Links | confidence=Medium score=113
    // v56 raw Tosca primary: Insurance Designee | Save for Later | DuckCreekId
    public ILocator SaveForLater => _page.Locator("[duckcreekid=\"Save for Later\"], [data-duckcreekid=\"Save for Later\"]");

    // Source modules: Common Navigation Links | confidence=Medium score=113
    public ILocator SaveForLaterOK => _page.GetByRole(AriaRole.Link, new() { Name = "Save for Later - OK", Exact = true });

    // Source modules: Dashboard|Search for Policies / Quotes | confidence=High score=125
    // v56 raw Tosca primary: Submission|Policy Forms | Search Button | DuckCreekId
    public ILocator SearchButton => _page.Locator("[duckcreekid=\"Search\"], [data-duckcreekid=\"Search\"]");

    // Source modules: Dashboard|Search for Policies / Quotes | confidence=High score=127
    public ILocator SearchMethodEGDescriptionPolicy => _page.Locator("[id='_keynameAdvSearch1-inputEl']");

    // Source modules: Risk - Computer Systems | confidence=High score=125
    // v56 raw Tosca primary: Risk - Computer Systems | Search Result | Id+Name+DuckCreekId
    public ILocator SearchResult4E620 => _page.Locator("input[id=\"f_c7EF1BABFA5C74E4E875A7BF40793DEB111_1_1-inputEl\"][name=\"f_c7EF1BABFA5C74E4E875A7BF40793DEB111_1_1-inputEl\"][duckcreekid=\"CovComputerSystemsInput.SearchResult\"]");

    // Source modules: Risk - Bailees Customers | confidence=High score=125
    public ILocator SearchResultA1BFB => SearchResult4E620; // semantic alias; locator defined once

    // Source modules: Risk - Accounts Receivable | confidence=High score=125
    public ILocator SearchResultEAFB8 => SearchResult4E620; // semantic alias; locator defined once

    // Source modules: Dashboard|QuickSearch | confidence=High score=127
    public ILocator SearchText => _page.Locator("[id='quickSearchTextId-inputEl']");

    // Source modules: Risk - Accounts Receivable | confidence=High score=125
    // v56 raw Tosca primary: Risk - Accounts Receivable | Search Value | Id+Name+DuckCreekId | frame=iframe
    public ILocator SearchValue79E46 => _page.FrameLocator("iframe").Locator("input[id=\"f_rFE68631942E64B1BA3A954F11A424A139_1_1-inputEl\"][name=\"string_9|\"][duckcreekid=\"RiskInlandMarineInput.SearchValue\"]");

    // Source modules: Risk - Computer Systems | confidence=High score=125
    public ILocator SearchValue9FCD1 => SearchValue79E46; // semantic alias; locator defined once

    // Source modules: Risk - Bailees Customers | confidence=High score=125
    public ILocator SearchValueCA6A6 => SearchValue79E46; // semantic alias; locator defined once

    // Source modules: Duck Creek Policy | confidence=Medium score=113
    public ILocator ShowMe => _page.GetByRole(AriaRole.Link, new() { Name = "Show me", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    // v56 raw Tosca primary: Policy Covg|GL | Split BI Ded | attributes_fieldref
    public ILocator SplitBIDed => _page.Locator("[fieldref=\"LineInput.SeparateProductsDeductible\"], [data-fieldref=\"LineInput.SeparateProductsDeductible\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    // v56 raw Tosca primary: Policy Covg|GL | Split PD Ded | attributes_fieldref
    public ILocator SplitPDDed => _page.Locator("[fieldref=\"LineInput.SeparateProductsPDDeductible\"], [data-fieldref=\"LineInput.SeparateProductsPDDeductible\"]");

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
