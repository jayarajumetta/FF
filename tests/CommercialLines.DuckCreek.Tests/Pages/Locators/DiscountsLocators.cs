using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class DiscountsLocators
{
    private readonly IPage _page;
    public DiscountsLocators(IPage page) => _page = page;

    // Source modules: Policy Info|BAP Specific Fields | confidence=High score=95
    // v57 raw Tosca: Policy Info|BAP Specific Fields | Account Credit | guid=3a13d49c-16f1-123c-8bc7-045e6ca361ec | strategy=retained-semantic
    public ILocator AccountCredit => _page.GetByRole(AriaRole.Textbox, new() { Name = "Account Credit", Exact = true });

    // Source modules: Policy Info|BAP Specific Fields | confidence=High score=125
    // v57 raw Tosca: Policy Info|BAP Specific Fields | OK | guid=3a13d49c-16f1-8573-a6a5-43ca81310051 | strategy=role-link
    public ILocator BAPSpecificFieldsOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    // Source modules: Policy Info|BAP Specific Fields | confidence=High score=125
    // v57 raw Tosca: Policy Info|BAP Specific Fields | NAICS Code Search Results* | guid=3a13d49c-16f1-8a94-a022-db3b462218e5 | strategy=retained-semantic
    public ILocator NAICSCodeSearchResults => _page.GetByRole(AriaRole.Textbox, new() { Name = "NAICS Code Search Results*", Exact = true });

    // Source modules: Policy Info|BAP Specific Fields | confidence=High score=125
    // v57 raw Tosca: Policy Info|BAP Specific Fields | NAICS Code Search Value* | guid=3a13d49c-16f1-c8a5-f6b3-5c5a8bc6944d | strategy=retained-semantic
    public ILocator NAICSCodeSearchValue => _page.GetByRole(AriaRole.Textbox, new() { Name = "NAICS Code Search Value*", Exact = true });

}
