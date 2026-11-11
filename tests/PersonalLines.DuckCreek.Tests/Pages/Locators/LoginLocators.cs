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

    public ILocator LoginOrPolicySearch => _page.Locator("input#username:visible, [id='cb_0']:visible").First;

    public ILocator PolicyLoginId => _page.GetByRole(AriaRole.Textbox, new() { Name = "Login ID", Exact = true });

    public ILocator PolicyLoginPassword => _page.GetByRole(AriaRole.Textbox, new() { Name = "Password", Exact = true });

    public ILocator PolicyLoginSubmit => _page.GetByText("LOGIN", new() { Exact = true });

    public ILocator PolicySearchText => _page.GetByRole(AriaRole.Textbox, new() { Name = "Search Text", Exact = true });

    public ILocator PolicySearchButton => _page.GetByRole(AriaRole.Button, new() { Name = "Search", Exact = true });

    public ILocator PolicyQuoteLink(string quoteNumber) => _page.GetByRole(AriaRole.Link, new() { Name = quoteNumber, Exact = true });

    public ILocator PolicyBypassLevel9BCheckbox => _page.GetByRole(AriaRole.Checkbox, new() { Name = "Bypass Level 9B Rules", Exact = true });

    public ILocator PolicyBypassLevel9BComments => _page.Locator("input[fieldref=\"PolicyInput.BypassLevel9BRulesComments\"]");

    public ILocator PolicyBypassNext => _page.GetByRole(AriaRole.Button, new() { Name = "Next", Exact = true });

    public ILocator PolicyHome => _page.GetByTitle("Home", new() { Exact = true });

    public ILocator TxtUnderwritingNotes => _page.Locator("textarea[fieldref=\"UWRulesReview.UWNotes\"]");

    public ILocator Lnk_Pricing => _page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { Name = "Pricing", Exact = true });

    public ILocator Check_UnderwritingNotes => _page.Locator("input[fieldref=\"UWRulesReview.UWReviewRequiredAfterIssuance\"]");

    public ILocator Btn_Approve => _page.GetByRole(AriaRole.Button, new PageGetByRoleOptions { Name = "Approve" });

}
