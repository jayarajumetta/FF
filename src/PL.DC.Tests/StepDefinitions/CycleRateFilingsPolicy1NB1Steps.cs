using Microsoft.Playwright;
using InsuranceAutomation.Pages.PageMethods;
using InsuranceAutomation.Utils;
using InsuranceAutomation.Hooks;
using Reqnroll;

namespace InsuranceAutomation.StepDefinitions;

[Binding, Scope(Feature = "Cycle Rate Filings Policy 1 NB_1")]
public sealed class CycleRateFilingsPolicy1NB1Steps
{
    private readonly BrowserSession _browser;
    private readonly ScenarioData _data;
    public CycleRateFilingsPolicy1NB1Steps(BrowserSession browser, ScenarioData data) { _browser = browser; _data = data; }

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

    [When("I cycle Summary")]
    public async Task ICycleSummary_7()
    {
        var eQ1stCycle = new EQ1stCycle(_browser.Page, _data);
        var eQAddCycleNext = new EQAddCycleNext(_browser.Page, _data);
        var eQVintageCycle = new EQVintageCycle(_browser.Page, _data);

        await eQ1stCycle.WaitForVINAsync();
        await eQ1stCycle.SetVINAsync(_data.Get("EQ 1st Cycle.VIN", "{{data:VIN}}"));
        await eQ1stCycle.PressVINAsync("Tab");
        await eQ1stCycle.WaitForPleaseSelectTheVehicleAsync();
        await eQ1stCycle.ClickCycle1Async();
        await eQ1stCycle.ClickPleasureUseAsync();
        await eQ1stCycle.ClickNotPleasureUseAsync();
        await eQ1stCycle.ClickUnderConstructionAsync();
        await eQ1stCycle.ClickLoanAsync();
        await eQ1stCycle.ClickLeasedAsync();
        await eQ1stCycle.ClickOwnAsync();
        await eQ1stCycle.ClickNoRegisteredFedTribeAsync();
        await eQ1stCycle.WaitForDoesThisVehicleHaveAnyNonFactoryAdditionsAlterationsOrModificationsAsync();
        await eQ1stCycle.ClickYesAsync();
        await eQ1stCycle.ClickNoAsync();
        await eQ1stCycle.SetDescriptionOfModsAsync(_data.Get("EQ 1st Cycle.Description of Mods", "Misc"));
        await eQ1stCycle.SetCurrentValueAsync(_data.Get("EQ 1st Cycle.Current Value", "{{data:Current Value(UnderConstruction)}}"));
        await eQ1stCycle.SetAnnualMileageAsync(_data.Get("EQ 1st Cycle.Annual Mileage", "{{data:Annual Mileage(NY,NJ,CA)}}"));
        await eQ1stCycle.ClickSaveAndContinueAsync();
        await eQAddCycleNext.ClickAddAdditionalVehicleAsync();
        await eQAddCycleNext.ClickNextAsync();
        await eQVintageCycle.WaitForCycleVINAsync();
        await eQVintageCycle.SetCycleVINAsync(_data.Get("EQ Vintage Cycle.Cycle VIN", "{{data:VIN}}"));
        await eQVintageCycle.PressCycleVINAsync("Tab");
        await eQVintageCycle.WaitForPleaseSelectTheVehicleAsync();
        await eQVintageCycle.WaitForVehicleTypeAsync();
        await eQVintageCycle.ClickVintageAsync();
        await eQVintageCycle.WaitForIsThisVehicleOwnedOrFinancedAsync();
        await eQVintageCycle.ClickLoanAsync();
        await eQVintageCycle.ClickLeasedAsync();
        await eQVintageCycle.ClickOwnAsync();
        await eQVintageCycle.WaitForDoesThisVehicleHaveAnyNonFactoryAdditionsAlterationsOrModificationsAsync();
        await eQVintageCycle.ClickNoAsync();
        await eQVintageCycle.SetAgreedValueAsync(_data.Get("EQ Vintage Cycle.Agreed Value", "{{data:Agreed Value}}"));
        await eQVintageCycle.SetAppraisalDateAsync(_data.Get("EQ Vintage Cycle.Appraisal Date", "{{data:Appraisal Date}}"));
        await eQVintageCycle.ClickSaveAndContinueAsync();
        await eQAddCycleNext.ClickAddAdditionalVehicleAsync();
        await eQAddCycleNext.ClickNextAsync();
    
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
