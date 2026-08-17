using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class LoginLocators
{
    private readonly IPage _page;
    public LoginLocators(IPage page) => _page = page;

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator BODY => _page.GetByText("BODY", new() { Exact = true });

    // Source modules: Logout | confidence=Review score=97
    public ILocator LoggedInUser => _page.GetByLabel("Logged In User", new() { Exact = true });

    // Source modules: Login | confidence=High score=125
    public ILocator Login => _page.GetByRole(AriaRole.Button, new() { Name = "Login", Exact = true });

    // Source modules: Login | confidence=High score=127
    public ILocator Password => _page.GetByRole(AriaRole.Textbox, new() { Name = "Password", Exact = true });

    // Source modules: Login | confidence=High score=127
    public ILocator UserName => _page.GetByRole(AriaRole.Textbox, new() { Name = "UserName", Exact = true });

}