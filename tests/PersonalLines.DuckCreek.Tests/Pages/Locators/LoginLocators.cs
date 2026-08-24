using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class LoginLocators
{
    private readonly IPage _page;
    public LoginLocators(IPage page) => _page = page;

    // Source modules: EQH||Add/Edit Additional Interest-First Mortgagee | confidence=Medium score=113
    public ILocator AddEditAdditionalInterestFirstMortgageeSearch => _page.GetByRole(AriaRole.Button, new() { Name = "Btn_Search", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator BtnApprove => _page.GetByText("Btn_Approve", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator BypassLevel9BRules => _page.GetByText("Bypass Level 9B Rules", new() { Exact = true });

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
    public ILocator LnkLOGIN => _page.GetByText("Lnk_LOGIN", new() { Exact = true });

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
    public ILocator Password => _page.GetByText("Password", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator PolicyQuote => _page.GetByText("Policy/Quote#", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator TxtLoginID1 => _page.Locator("[id='username']");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator TxtSearchText => _page.Locator("[id='tf_0']");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator TxtSearchType => _page.GetByText("Txt_Search Type", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator TxtUnderwritingNotes => _page.GetByText("Txt_Underwriting Notes *", new() { Exact = true });

}
