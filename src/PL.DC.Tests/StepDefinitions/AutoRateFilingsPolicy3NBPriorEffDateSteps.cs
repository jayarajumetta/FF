using Microsoft.Playwright;
using InsuranceAutomation.Pages.PageMethods;
using InsuranceAutomation.Utils;
using InsuranceAutomation.Hooks;
using Reqnroll;

namespace InsuranceAutomation.StepDefinitions;

[Binding, Scope(Feature = "Auto Rate Filings Policy 3 NB_Prior Eff Date")]
public sealed class AutoRateFilingsPolicy3NBPriorEffDateSteps
{
    private readonly BrowserSession _browser;
    private readonly ScenarioData _data;
    public AutoRateFilingsPolicy3NBPriorEffDateSteps(BrowserSession browser, ScenarioData data) { _browser = browser; _data = data; }

    [When("I complete prequalification")]
    public async Task ICompletePrequalification_5()
    {
        var eQPreQualification = new EQPreQualification(_browser.Page, _data);
        var eQSideMenu = new EQSideMenu(_browser.Page, _data);

        await eQPreQualification.ClickBtnChkBoxCheckBoxNoneOfTheAboveAsync();
        await eQPreQualification.PressBtnChkBoxCheckBoxNoneOfTheAboveAsync("Tab");
        await eQPreQualification.ClickBtnNextAsync();
        await eQPreQualification.PressBtnNextAsync("Tab");
        await eQSideMenu.StoreQuoteNumberAsync("QuoteNum");
    
    }

    [When("I complete underwriting information")]
    public async Task ICompleteUnderwritingInformation_14()
    {
        var eQUnderwritingEligibilityRestrictions = new EQUnderwritingEligibilityRestrictions(_browser.Page, _data);
        var eQUnderwritingUnderwritingNext = new EQUnderwritingUnderwritingNext(_browser.Page, _data);

        await eQUnderwritingEligibilityRestrictions.ClickYesAsync();
        await eQUnderwritingEligibilityRestrictions.SetNoAsync(_data.Get("EQ Underwriting Eligibility Restrictions.No", "{end}"));
        await eQUnderwritingUnderwritingNext.ClickNextAsync();
    
    }
}
