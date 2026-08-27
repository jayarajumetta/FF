using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class LoginLocators
{
    private readonly IPage _page;
    public LoginLocators(IPage page) => _page = page;

    // Source modules: EQH||Add/Edit Additional Interest-First Mortgagee | confidence=Medium score=113
    // v56 raw Tosca primary: EQH||Add/Edit Additional Interest-First Mortgagee | Txt_MortgageSearch_Mortgage Name | Id+Name
    public ILocator AddEditAdditionalInterestFirstMortgageeSearch => _page.Locator("input[id=\"temp.searchName\"][name=\"temp.searchName\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator BtnApprove => _page.GetByText("Btn_Approve", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    // v56 raw Tosca primary: EU||Applicant | Bypass Level 9B Rules | Id
    public ILocator BypassLevel9BRules => _page.Locator("[id=\"checkbox_3\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator BypassLevel9BRulesComments => _page.Locator("[id='tf_27']");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator BypassLevel9Comments1 => _page.GetByText("Bypass Level 9 Comments_1", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator ChkBoxBypassLevel9Rules => _page.GetByText("ChkBox_Bypass Level 9 Rules", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator Home => _page.GetByText("Home", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator LblLoginID => _page.GetByText("Lbl_Login ID", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator LnkHome => _page.GetByText("Lnk_Home", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    // v56 raw Tosca primary: EU||Login | Lnk_LOGIN | Id
    public ILocator LnkLOGIN => _page.Locator("a[id=\"signInBtn\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator LnkMotorcycle => _page.GetByText("Lnk_Motorcycle", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator LnkPersonalAuto => _page.GetByText("Lnk_PersonalAuto", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator LnkPricing => _page.GetByText("Lnk_Pricing", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator LnkRV => _page.GetByText("Lnk_RV", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    // v56 raw Tosca primary: EU||Login | Password | Id+Name
    public ILocator Password => _page.Locator("[id=\"password\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    // v56 raw Tosca primary:  | Policy # | Id
    public ILocator PolicyQuote => _page.Locator("[id=\"undefined\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator TxtLoginID1 => _page.Locator("[id=\"username\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator TxtSearchText => _page.Locator("[id='tf_0']");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    // v56 raw Tosca primary: EU||Home | Txt_Search Type | Id
    public ILocator TxtSearchType => _page.Locator("[id=\"cb_0\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator TxtUnderwritingNotes => _page.GetByText("Txt_Underwriting Notes *", new() { Exact = true });

}
