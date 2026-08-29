using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class PolicyWorkflowLocators
{
    private readonly IPage _page;
    public PolicyWorkflowLocators(IPage page) => _page = page;

    public ILocator AJAXErrorCheck => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "AJAX Error Check");

    public ILocator PageTitle => _page.Locator("[id=\"pageTitle\"]");

    public ILocator AddClient => _page.Locator("a[fieldref=\"Add Client\"]");

    public ILocator AggregateLimit => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Aggregate Limit");


    public ILocator Detail => _page.Locator("a[fieldref=\"Detail\"]");


    public ILocator CTStraightThroughLiabilityLimitTo1M => _page.GetByText("CT StraightThrough Liability Limit to 1M", new() { Exact = true });

    public ILocator CommercialAuto => _page.GetByRole(AriaRole.Link, new() { Name = "Commercial Auto", Exact = true });

    public ILocator DedType => _page.Locator("input[fieldref=\"LineInput.DeductibleType\"]");

    public ILocator DeductibleBasis => _page.Locator("input[fieldref=\"LineInput.DeductibleScope\"]");

    public ILocator DescriptionOfSpecifiedOperation => _page.Locator("input[fieldref=\"PolicyOutput.DescriptionOfOperations\"]");

    public ILocator DoesAnyRiskGeneratePowerOtherThanPrivateWindmillsOrEmergencyBackup => _page.Locator("input[fieldref=\"PolicyInput.AnyRiskPowerUnitOtherThanWindmillOrBackup\"]");

    public ILocator EmployersLiab => _page.GetByRole(AriaRole.Link, new() { Name = "Employers Liab", Exact = true });


    public ILocator FireDamage => _page.Locator("input[fieldref=\"CovFireDamageInput.FireDamage\"]");

    public ILocator GeneralLiab => _page.GetByRole(AriaRole.Link, new() { Name = "General Liab", Exact = true });

    public ILocator HasTheApplicantBeenInBusinessForAtLeast3YearsWithContinuousWorkersCompensationCoverage => _page.Locator("input[fieldref=\"PolicyInput.ContinuousWCCoverageForAtLeast3Years\"]");


    public ILocator OK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    public ILocator IFRAMEDuckCreekPolicyDescriptionOfOther => _page.Locator("textarea[fieldref=\"CovExclusionDesignatedWorkInput.OtherDescription\"]");

    public ILocator IFRAMEDuckCreekPolicyOtherCheckBox => _page.Locator("input[fieldref=\"CovExclusionDesignatedWorkInput.Other\"]");


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

    public ILocator IndividualType => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "IndividualType");

    public ILocator IsTheInsuredEngagedInAnySnowOrIceRemovalOperations => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Is the Insured engaged in any Snow or Ice Removal Operations?*");

    public ILocator LoadingMessage => _page.Locator("[id=\"loadingMessage\"]");

    public ILocator LoggedInUser => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Logged In User");

    public ILocator Logout => _page.Locator("[id=\"id_LogOut\"]");

    public ILocator Medical => _page.Locator("input[fieldref=\"CovMedicalInput.Medical\"]");

    public ILocator OccurenceLimit => _page.Locator("input[fieldref=\"LineInput.PolicyPerOccurenceLimit\"]");

    public ILocator OfFullTimeEmployees => _page.Locator("input[fieldref=\"LineInput.NumberOfFullTimeEmployees\"]");

    public ILocator OfPartTimeEmployees => _page.Locator("input[fieldref=\"LineInput.NumberOfPartTimeEmployees\"]");

    public ILocator OfSeasonalTemporaryEmployees => _page.Locator("input[fieldref=\"LineInput.NumberOfSeasonalTemporaryEmployees\"]");

    public ILocator PersAdvInj => _page.Locator("input[fieldref=\"CovPersonalAdvertisingInjuryInput.PersonalAdvertisingInjury\"]");

    public ILocator PersonalAuto => _page.GetByRole(AriaRole.Link, new() { Name = "Personal Auto", Exact = true });


    public ILocator PolicyCovg => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Policy Covg");


    public ILocator PremOpDed => _page.Locator("input[fieldref=\"LineInput.Deductible\"]");

    public ILocator PremOpPDDed => _page.Locator("input[fieldref=\"LineInput.DeductiblePD\"]");

    public ILocator ProdBIDed => _page.Locator("input[fieldref=\"LineInput.DeductibleProducts\"]");

    public ILocator ProdPDDed => _page.Locator("input[fieldref=\"LineInput.DeductiblePDProducts\"]");

    public ILocator ProductsAggLimit => _page.Locator("input[fieldref=\"LineInput.ProductsAggregateLimit\"]");

    public ILocator PropertyOfOthersRatingGroup => _page.Locator("input[fieldref=\"RiskInput.RatingGroupID\"]");

    public ILocator QuickSearchButton => _page.Locator("[id=\"id_quickSearch\"]");


    public ILocator ReturnToAdmin => _page.GetByRole(AriaRole.Link, new() { Name = "Return To Admin", Exact = true });

    public ILocator ReturnToCPP => _page.Locator("a[fieldref=\"Return To CPP\"]");





    public ILocator SaveForLater => _page.Locator("a[fieldref=\"Save for Later\"]");

    public ILocator SaveForLaterOK => _page.GetByRole(AriaRole.Link, new() { Name = "Save for Later - OK", Exact = true });

    public ILocator SearchButton => _page.Locator("a[fieldref=\"Search\"]");

    public ILocator SearchMethodEGDescriptionPolicy => _page.Locator("[id='_keynameAdvSearch1-inputEl']");

    public ILocator RiskComputerSystemsSearchResult => _page.Locator("[id=\"f_c7EF1BABFA5C74E4E875A7BF40793DEB111_1_1-inputEl\"]");

    public ILocator RiskBaileesCustomersSearchResult => _page.Locator("[id=\"f_c1130867FA0E9485FBAA81AF58751740889_1_1-inputEl\"]");

    public ILocator RiskAccountsReceivableSearchResult => _page.Locator("[id=\"f_rFE68631942E64B1BA3A954F11A424A13A_1_1-inputEl\"]");

    public ILocator SearchText => _page.Locator("[id='quickSearchTextId-inputEl']");

    public ILocator RiskAccountsReceivableSearchValue => _page.Locator("[id=\"f_rFE68631942E64B1BA3A954F11A424A139_1_1-inputEl\"]");

    public ILocator RiskComputerSystemsSearchValue => _page.Locator("[id=\"f_c7EF1BABFA5C74E4E875A7BF40793DEB110_1_1-inputEl\"]");

    public ILocator RiskBaileesCustomersSearchValue => _page.Locator("[id=\"f_c1130867FA0E9485FBAA81AF58751740887_1_1-inputEl\"]");

    public ILocator ShowMe => _page.GetByRole(AriaRole.Link, new() { Name = "Show me", Exact = true });

    public ILocator SplitBIDed => _page.Locator("input[fieldref=\"LineInput.SeparateProductsDeductible\"]");

    public ILocator SplitPDDed => _page.Locator("input[fieldref=\"LineInput.SeparateProductsPDDeductible\"]");

    public ILocator Start => _page.Locator("a[fieldref=\"Start\"]");

    public ILocator BrowserCommunicationHTTPStatusZero => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0");

    public ILocator Value => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "SearchValue");

    public ILocator ViewPolicy => _page.Locator("[id=\"returnToActiveSessionA\"]");

}
