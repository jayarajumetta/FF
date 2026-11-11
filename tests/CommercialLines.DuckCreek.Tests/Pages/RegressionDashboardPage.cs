using InsuranceAutomation.Core;
using InsuranceAutomation.CLDC.Pages.Locators;
using Microsoft.Playwright;
namespace InsuranceAutomation.CLDC.Pages;
public sealed class RegressionDashboardPage
{
    private readonly BrowserSession _browser; private readonly UiActions _ui; private readonly RegressionDashboardLocators _locators;
    public RegressionDashboardPage(BrowserSession browser, UiActions ui) { _browser=browser; _ui=ui; _locators=new(browser.Page); }
    public async Task SearchAndOpenPolicyAsync(string policyNumber)
    {
        if (string.IsNullOrWhiteSpace(policyNumber)) throw new InvalidOperationException("The regression policy number has not been captured.");
        if (await _locators.QuickSearchText.CountAsync() > 0)
        {
            if (await _locators.QuickSearchMode.CountAsync() > 0) await _ui.SmartSetAsync(_locators.QuickSearchMode, "Policy", new ControlIntent("RegressionDashboard","QuickSearchMode"));
            await _ui.FillAsync(_locators.QuickSearchText, policyNumber, new ControlIntent("RegressionDashboard","QuickSearchText"));
            await _ui.ClickAsync(_locators.QuickSearchButton, new ControlIntent("RegressionDashboard","QuickSearchButton"));
        }
        else
        {
            await _ui.ClickAsync(_locators.Search, new ControlIntent("RegressionDashboard","Search"));
            await _ui.SmartSetAsync(_locators.AdvancedMethod, "Policy Number", new ControlIntent("RegressionDashboard","AdvancedMethod"));
            await _ui.FillAsync(_locators.AdvancedCriteria, policyNumber, new ControlIntent("RegressionDashboard","AdvancedCriteria"));
            await _ui.PressAsync(_locators.AdvancedCriteria, "Enter", new ControlIntent("RegressionDashboard","AdvancedCriteria"));
        }
        await _locators.ViewPolicy.WaitForAsync(new() { State=WaitForSelectorState.Visible, Timeout=60000 });
        await _ui.ClickAsync(_locators.ViewPolicy, new ControlIntent("RegressionDashboard","ViewPolicy"));
        await _browser.Page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
    }
}
