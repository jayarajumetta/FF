using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class PolicyInformationLocators
{
    private readonly IPage _page;
    public PolicyInformationLocators(IPage page) => _page = page;

    public ILocator AddSecondaryFarmTypeToggle => _page.GetByTestId("toggles-toggle-text");

    public ILocator GrossFarmIncome => _page.GetByTestId("fields.account.policyInput$grossFarmIncome.value");

    public ILocator IndustrialHempNo => _page.GetByTestId("fields.account.policyInput$industrialHemp.value-chip-wrapper");


    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    public ILocator PrimaryFarmCategory => _page.GetByTestId("fields.account.policyInput$farmTypeCategory.value-chip-wrapper");

    public ILocator PrimaryFarmType => _page.Locator("input[id=\"fields.account.policyInput$grossFarmIncome.value\"][name=\"fields.account.policyInput$grossFarmIncome.value\"][data-testid=\"fields.account.policyInput$grossFarmIncome.value\"]");

    public ILocator ScreenHeading => _page.GetByText("Screen Heading", new() { Exact = true });

    public ILocator SecondaryFarmCategory => _page.GetByTestId("fields.account.policyInput$farmTypeSecondaryCategory.value-chip-wrapper");

    public ILocator SecondaryFarmType => _page.Locator("[duckcreekid=\"PolicyInput.FarmTypeSecondary\"], [data-duckcreekid=\"PolicyInput.FarmTypeSecondary\"]");

}
