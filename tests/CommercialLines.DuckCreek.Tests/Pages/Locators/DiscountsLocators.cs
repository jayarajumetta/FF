using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class DiscountsLocators
{
    private readonly IPage _page;
    public DiscountsLocators(IPage page) => _page = page;

    // Source modules: Policy Info|BAP Specific Fields | confidence=High score=95
    // v56 raw Tosca primary: Policy Info|BAP Specific Fields | Account Credit | DuckCreekId
    public ILocator AccountCredit => _page.Locator("[duckcreekid=\"PolicyInput.AccountCredit\"], [data-duckcreekid=\"PolicyInput.AccountCredit\"]");

    // Source modules: Policy Info|BAP Specific Fields | confidence=High score=125
    // v56 raw Tosca primary: Policy Info|BAP Specific Fields | OK | DuckCreekId | frame=iframe
    public ILocator BAPSpecificFieldsOK => _page.FrameLocator("iframe").Locator("[duckcreekid=\"OK\"], [data-duckcreekid=\"OK\"]");

    // Source modules: Policy Info|BAP Specific Fields | confidence=High score=125
    // v56 raw Tosca primary: Policy Info|BAP Specific Fields | NAICS Code Search Results* | DuckCreekId
    public ILocator NAICSCodeSearchResults => _page.Locator("[duckcreekid=\"PolicyInput.NAICSCodeDesc\"], [data-duckcreekid=\"PolicyInput.NAICSCodeDesc\"]");

    // Source modules: Policy Info|BAP Specific Fields | confidence=High score=125
    // v56 raw Tosca primary: Policy Info|BAP Specific Fields | NAICS Code Search Value* | DuckCreekId | frame=iframe
    public ILocator NAICSCodeSearchValue => _page.FrameLocator("iframe").Locator("[duckcreekid=\"PolicyOutputNonShredded.NAICSCodeSearchValue\"], [data-duckcreekid=\"PolicyOutputNonShredded.NAICSCodeSearchValue\"]");

}
