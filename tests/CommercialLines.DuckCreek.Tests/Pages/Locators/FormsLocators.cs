using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class FormsLocators
{
    private readonly IPage _page;
    public FormsLocators(IPage page) => _page = page;

    // Source modules: BAP Navigation Links | confidence=Medium score=113
    public ILocator AdditionalInterests => _page.GetByRole(AriaRole.Link, new() { Name = "Additional Interests", Exact = true });

    // Source modules: Additional Interests Schedule | confidence=High score=127
    public ILocator AddlInterests => _page.GetByLabel("Addl Interests", new() { Exact = true });

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator Businessowners => _page.GetByRole(AriaRole.Link, new() { Name = "Businessowners", Exact = true });

    // Source modules: Businessowners | confidence=High score=97
    public ILocator BusinessownersHeading => _page.GetByLabel("Businessowners Heading", new() { Exact = true });

    // Source modules: Businessowners | confidence=High score=125
    public ILocator EffectiveDate => _page.GetByRole(AriaRole.Textbox, new() { Name = "Effective Date", Exact = true });

    // Source modules: Businessowners | confidence=High score=94
    // Field opens if PRS is OH,WA,ND,WY
    public ILocator EmployerSLiabilityCheckBox => _page.GetByRole(AriaRole.Checkbox, new() { Name = "Employer's Liability CheckBox", Exact = true });

    // Source modules: Businessowners | confidence=High score=125
    public ILocator ExpirationDate => _page.GetByRole(AriaRole.Textbox, new() { Name = "Expiration Date", Exact = true });

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator HomeownerSLiability => _page.GetByRole(AriaRole.Link, new() { Name = "Homeowner's Liability", Exact = true });

    // Source modules: Businessowners | confidence=High score=95
    public ILocator ImportPolicyDataButton => _page.GetByRole(AriaRole.Button, new() { Name = "Import Policy Data Button", Exact = true });

    // Source modules: Commercial Auto | confidence=High score=125
    public ILocator LiabilityLimit => _page.GetByRole(AriaRole.Textbox, new() { Name = "Liability Limit*", Exact = true });

    // Source modules: Indicators and Errors | confidence=High score=127
    // This DIV appears during a refresh of the screen (working in the background) and can be used as a WaitOn for stability.
    public ILocator LoadingMessage => _page.GetByLabel("Loading Message", new() { Exact = true });

    // Source modules: Recreational Vehicle Liability | confidence=High score=95
    // May be state specific?
    public ILocator PDLimit => _page.GetByRole(AriaRole.Textbox, new() { Name = "PD Limit*", Exact = true });

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator PersonalAuto => _page.GetByRole(AriaRole.Link, new() { Name = "Personal Auto", Exact = true });

    // Source modules: Businessowners | confidence=High score=125
    public ILocator PolicyNumber => _page.GetByRole(AriaRole.Textbox, new() { Name = "Policy Number", Exact = true });

    // Source modules:  | confidence=Review score=97
    public ILocator SessionID => _page.GetByLabel("sessionID", new() { Exact = true });

    // Source modules:  | confidence=Review score=97
    public ILocator StatusCode => _page.GetByLabel("StatusCode", new() { Exact = true });

    // Source modules: Businessowners | confidence=High score=125
    public ILocator TotalSubjectPremium => _page.GetByRole(AriaRole.Textbox, new() { Name = "Total Subject Premium*", Exact = true });

    // Source modules:  | confidence=Review score=97
    public ILocator Value => _page.GetByLabel("value", new() { Exact = true });

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator WatercraftLiability => _page.GetByRole(AriaRole.Link, new() { Name = "Watercraft Liability", Exact = true });

}
