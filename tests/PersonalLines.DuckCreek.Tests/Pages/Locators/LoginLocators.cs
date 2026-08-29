using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class LoginLocators
{
    private readonly IPage _page;
    public LoginLocators(IPage page) => _page = page;

    public ILocator AddEditAdditionalInterestFirstMortgageeSearch => _page.Locator("input[id=\"temp.searchName\"][name=\"temp.searchName\"]");

    public ILocator BtnApprove => _page.GetByText("Btn_Approve", new() { Exact = true });

    public ILocator BypassLevel9BRules => _page.Locator("[id=\"checkbox_3\"]");

    public ILocator BypassLevel9BRulesComments => _page.Locator("[id='tf_27']");

    public ILocator BypassLevel9Comments1 => _page.GetByText("Bypass Level 9 Comments_1", new() { Exact = true });

    public ILocator ChkBoxBypassLevel9Rules => _page.GetByText("ChkBox_Bypass Level 9 Rules", new() { Exact = true });

    public ILocator Home => _page.GetByText("Home", new() { Exact = true });

    public ILocator LblLoginID => _page.GetByText("Lbl_Login ID", new() { Exact = true });

    public ILocator LnkHome => _page.GetByText("Lnk_Home", new() { Exact = true });

    public ILocator LnkLOGIN => _page.Locator("a[id=\"signInBtn\"]");

    public ILocator LnkMotorcycle => _page.GetByText("Lnk_Motorcycle", new() { Exact = true });

    public ILocator LnkPersonalAuto => _page.GetByText("Lnk_PersonalAuto", new() { Exact = true });

    public ILocator LnkPricing => _page.GetByText("Lnk_Pricing", new() { Exact = true });

    public ILocator LnkRV => _page.GetByText("Lnk_RV", new() { Exact = true });

    public ILocator Password => _page.Locator("[id=\"password\"]");

    public ILocator PolicyQuote => _page.GetByText("Policy #", new() { Exact = true });

    public ILocator TxtLoginID1 => _page.Locator("[id=\"username\"]");

    public ILocator TxtSearchText => _page.Locator("[id='tf_0']");

    public ILocator TxtSearchType => _page.Locator("[id=\"cb_0\"]");

    public ILocator TxtUnderwritingNotes => _page.GetByText("Txt_Underwriting Notes *", new() { Exact = true });

}
