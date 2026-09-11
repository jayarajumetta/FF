using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class PolicyWorkflowLocators
{
    private readonly IPage _page;
    public PolicyWorkflowLocators(IPage page) => _page = page;

    public ILocator AJAXErrorCheck => _page.Locator("xpath=(//*[@id = //label[normalize-space(string(.))='AJAX Error Check']/@for] | //label[normalize-space(string(.))='AJAX Error Check']//*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1] | //label[normalize-space(string(.))='AJAX Error Check']/following-sibling::*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1])");

    public ILocator PageTitle => _page.Locator("[id=\"pageTitle\"]");

    public ILocator AddClient => _page.GetByRole(AriaRole.Link, new() { Name = "Add Client", Exact = true });

    public ILocator AggregateLimit => _page.Locator("input[fieldref=\"LineInput.PolicyAggregateLimit\"]");


    public ILocator Detail => _page.GetByRole(AriaRole.Link, new() { Name = "Detail", Exact = true });


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


    public ILocator IncludeBusinessowners => _page.Locator("input[fieldref=\"LineUmbrellaBusinessOwners.IncludeBusinessOwners\"]");

    public ILocator IncludeCommercialAuto => _page.Locator("input[fieldref=\"LineUmbrellaCommercialAuto.IncludeCommercialAuto\"]");

    public ILocator IncludeCommercialPackagePolicyLiability => _page.Locator("input[fieldref=\"LineUmbrellaCPPLiability.IncludeCPPLiability\"]");

    public ILocator IncludeEmployersLiability => _page.Locator("input[fieldref=\"LineUmbrellaEmployersLiability.IncludeEmployersLiability\"]");

    public ILocator IncludeGeneralLiability => _page.Locator("input[fieldref=\"LineUmbrellaGeneralLiability.IncludeGeneralLiability\"]");

    public ILocator IncludeHomeownerSLiability => _page.Locator("input[fieldref=\"LineUmbrellaHomeownersLiability.IncludeHomeownersLiability\"]");

    public ILocator IncludePersonalAutoLiability => _page.Locator("input[fieldref=\"LineUmbrellaPersonalAutoLiability.IncludePersonalAutoLiability\"]");

    public ILocator IncludeRentalOwnerSLiability => _page.Locator("input[fieldref=\"LineUmbrellaRentalOwnersLiability.IncludeRentalOwnersLiability\"]");

    public ILocator IncludeSFP10LiabilityFarm => _page.Locator("input[fieldref=\"LineUmbrellaSFP10Liability.IncludeSFP10Liability\"]");

    public ILocator IncludeWatercraftLiability => _page.Locator("input[fieldref=\"LineUmbrellaWatercraftLiability.IncludeWatercraftLiability\"]");

    public ILocator IndividualType => _page.Locator("input[fieldref=\"AssociatedClientInput.IndividualType\"]");

    public ILocator IsTheInsuredEngagedInAnySnowOrIceRemovalOperations => _page.Locator("input[fieldref=\"LineInput.InsuredEngaged\"]");

    public ILocator LoadingMessage => _page.Locator("[id=\"loadingMessage\"]");

    public ILocator LoggedInUser => _page.Locator("xpath=(//*[@id = //label[normalize-space(string(.))='Logged In User']/@for] | //label[normalize-space(string(.))='Logged In User']//*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1] | //label[normalize-space(string(.))='Logged In User']/following-sibling::*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1])");

    public ILocator Logout => _page.Locator("[id=\"id_LogOut\"]");

    public ILocator Medical => _page.Locator("input[fieldref=\"CovMedicalInput.Medical\"]");

    public ILocator OccurenceLimit => _page.Locator("input[fieldref=\"LineInput.PolicyPerOccurenceLimit\"]");

    public ILocator OfFullTimeEmployees => _page.Locator("input[fieldref=\"LineInput.NumberOfFullTimeEmployees\"]");

    public ILocator OfPartTimeEmployees => _page.Locator("input[fieldref=\"LineInput.NumberOfPartTimeEmployees\"]");

    public ILocator OfSeasonalTemporaryEmployees => _page.Locator("input[fieldref=\"LineInput.NumberOfSeasonalTemporaryEmployees\"]");

    public ILocator PersAdvInj => _page.Locator("input[fieldref=\"CovPersonalAdvertisingInjuryInput.PersonalAdvertisingInjury\"]");

    public ILocator PersonalAuto => _page.GetByRole(AriaRole.Link, new() { Name = "Personal Auto", Exact = true });


    public ILocator PolicyCovg => _page.Locator("xpath=(//*[@id = //label[normalize-space(string(.))='Policy Covg']/@for] | //label[normalize-space(string(.))='Policy Covg']//*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1] | //label[normalize-space(string(.))='Policy Covg']/following-sibling::*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1])");


    public ILocator PremOpDed => _page.Locator("input[fieldref=\"LineInput.Deductible\"]");

    public ILocator PremOpPDDed => _page.Locator("input[fieldref=\"LineInput.DeductiblePD\"]");

    public ILocator ProdBIDed => _page.Locator("input[fieldref=\"LineInput.DeductibleProducts\"]");

    public ILocator ProdPDDed => _page.Locator("input[fieldref=\"LineInput.DeductiblePDProducts\"]");

    public ILocator ProductsAggLimit => _page.Locator("input[fieldref=\"LineInput.ProductsAggregateLimit\"]");

    public ILocator PropertyOfOthersRatingGroup => _page.Locator("input[fieldref=\"RiskInput.RatingGroupID\"]");

    public ILocator QuickSearchButton => _page.Locator("[id=\"id_quickSearch\"]");


    public ILocator ReturnToAdmin => _page.GetByRole(AriaRole.Link, new() { Name = "Return To Admin", Exact = true });

    public ILocator ReturnToCPP => _page.GetByRole(AriaRole.Link, new() { Name = "Return To CPP", Exact = true });





    public ILocator SaveForLater => _page.GetByRole(AriaRole.Link, new() { Name = "Save for Later", Exact = true });

    public ILocator SaveForLaterOK => _page.GetByRole(AriaRole.Link, new() { Name = "Save for Later - OK", Exact = true });

    public ILocator SearchButton => _page.GetByRole(AriaRole.Link, new() { Name = "Search", Exact = true });

    public ILocator SearchMethodEGDescriptionPolicy => _page.Locator("[id='_keynameAdvSearch1-inputEl']");

    public ILocator RiskComputerSystemsSearchResult => _page.Locator("input[fieldref=\"CovComputerSystemsInput.SearchResult\"]");

    public ILocator RiskBaileesCustomersSearchResult => _page.Locator("input[fieldref=\"CovBaileesCustomersInput.SearchResult\"]");

    public ILocator RiskAccountsReceivableSearchResult => _page.Locator("input[fieldref=\"RiskInlandMarineInput.SearchResult\"]");

    public ILocator SearchText => _page.Locator("[id='quickSearchTextId-inputEl']");

    public ILocator RiskAccountsReceivableSearchValue => _page.Locator("input[fieldref=\"RiskInlandMarineInput.SearchValue\"]");

    public ILocator RiskComputerSystemsSearchValue => _page.Locator("input[fieldref=\"CovComputerSystemsInput.SearchValue\"]");

    public ILocator RiskBaileesCustomersSearchValue => _page.Locator("input[fieldref=\"CovBaileesCustomersInput.SearchValue\"]");

    public ILocator ShowMe => _page.GetByRole(AriaRole.Link, new() { Name = "Show me", Exact = true });

    public ILocator SplitBIDed => _page.Locator("input[fieldref=\"LineInput.SeparateProductsDeductible\"]");

    public ILocator SplitPDDed => _page.Locator("input[fieldref=\"LineInput.SeparateProductsPDDeductible\"]");

    public ILocator Start => _page.GetByRole(AriaRole.Link, new() { Name = "Start", Exact = true });

    public ILocator BrowserCommunicationHTTPStatusZero => _page.Locator("xpath=(//*[@id = //label[normalize-space(string(.))='The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0']/@for] | //label[normalize-space(string(.))='The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0']//*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1] | //label[normalize-space(string(.))='The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0']/following-sibling::*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1])");

    public ILocator Value => _page.Locator("input[fieldref=\"NCCISearchInputNonShredded.SearchValue\"]");

    public ILocator ViewPolicy => _page.Locator("[id=\"returnToActiveSessionA\"]");

}
