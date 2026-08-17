using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class PolicyInformationLocators
{
    private readonly IPage _page;
    public PolicyInformationLocators(IPage page) => _page = page;

    // Source modules: EQ|SFP|Policy Details (Optimized) | confidence=High score=130
    public ILocator AddSecondaryFarmTypeToggle => _page.GetByTestId("toggles-toggle-text");

    // Source modules: EQ|SFP|Policy Details (Optimized) | confidence=High score=130
    public ILocator GrossFarmIncome => _page.GetByTestId("fields.account.policyInput$grossFarmIncome.value");

    // Source modules: EQ|SFP|Policy Details (Optimized) | confidence=High score=100
    public ILocator IndustrialHempNo => _page.GetByTestId("fields.account.policyInput$industrialHemp.value-chip-wrapper");

    // Source modules: EQ|SFP|Policy Details (Optimized) | confidence=High score=100
    public ILocator IndustrialHempYes => _page.GetByTestId("fields.account.policyInput$industrialHemp.value-chip-wrapper");

    // Source modules: EQ |Common|Loading Indicator Wait | confidence=Medium score=78
    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    // Source modules: EQ|SFP|Policy Details (Optimized) | confidence=High score=130
    public ILocator PrimaryFarmCategory => _page.GetByTestId("fields.account.policyInput$farmTypeCategory.value-chip-wrapper");

    // Source modules: EQ|SFP|Policy Details (Optimized) | confidence=Medium score=108
    public ILocator PrimaryFarmType => _page.GetByLabel("Primary Farm Type", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator ScreenHeading => _page.GetByText("Screen Heading", new() { Exact = true });

    // Source modules: EQ|SFP|Policy Details (Optimized) | confidence=High score=130
    public ILocator SecondaryFarmCategory => _page.GetByTestId("fields.account.policyInput$farmTypeSecondaryCategory.value-chip-wrapper");

    // Source modules: EQ|SFP|Policy Details (Optimized) | confidence=Medium score=108
    public ILocator SecondaryFarmType => _page.GetByLabel("Secondary Farm Type", new() { Exact = true });

}
