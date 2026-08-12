using Microsoft.Playwright;
using InsuranceAutomation.Pages.PageMethods;
using InsuranceAutomation.Utils;
using InsuranceAutomation.Hooks;
using Reqnroll;

namespace InsuranceAutomation.StepDefinitions;

[Binding, Scope(Feature = "Cycle Rate Filings Policy 3 NB_Prior Eff Date")]
public sealed class CycleRateFilingsPolicy3NBPriorEffDateSteps
{
    private readonly BrowserSession _browser;
    private readonly ScenarioData _data;
    public CycleRateFilingsPolicy3NBPriorEffDateSteps(BrowserSession browser, ScenarioData data) { _browser = browser; _data = data; }

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
        var eQCycleUnderwriting = new EQCycleUnderwriting(_browser.Page, _data);

        await eQCycleUnderwriting.WaitForHaveYouOrAnyHouseholdMemberEverBeenConvictedOfAFelonyAsync();
        await eQCycleUnderwriting.ClickNoAsync();
        await eQCycleUnderwriting.WaitForIsAnyVintageCycleGaragedInADifferentLocationAsync();
        await eQCycleUnderwriting.ClickNo1Async();
        await eQCycleUnderwriting.ClickNextAsync();
    
    }
}
