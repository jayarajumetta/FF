using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class UnderwritingLocators
{
    private readonly IPage _page;
    public UnderwritingLocators(IPage page) => _page = page;

    // Source modules: EQ | Underwriting Collector And Vintage Information | confidence=Medium score=78
    public ILocator AreAllCollectorVehiclesKeptInAFullyEnclosedAndLockedStructure => _page.GetByLabel("Are all collector vehicles kept in a fully enclosed and locked structure?", new() { Exact = true });

    // Source modules: EQ||PreQualification | confidence=High score=127
    // v56 raw Tosca primary: EQ||PreQualification | Btn_Chk box_check_boxNone Of The Above | Id
    public ILocator ChkBoxCheckBoxNoneOfTheAbove => _page.Locator("[id=\"fields.data.policy.preQualificationQuestionPolicy$noneOfTheAbove.value-checkbox\"]");

    // Source modules: EQ || Cycle Underwriting | confidence=High score=127
    // v56 raw Tosca primary: EQ || Cycle Underwriting | Next | Id
    public ILocator CycleUnderwritingNext => _page.Locator("[id=\"fields.pageAction.next\"]");

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator EQCommonLoadingIndicatorWait => _page.GetByText("EQ |Common|Loading Indicator Wait", new() { Exact = true });

    // Source modules: EQ || Cycle Underwriting | confidence=Medium score=78
    // v56 raw Tosca primary: EQ || Cycle Underwriting | No_1 | Id
    public ILocator HaveYouOrAnyHouseholdMemberEverBeenConvictedOfAFelony => _page.Locator("[id=\"fields.data.policy.underwritingQuestionsPolicy$vintageVehGaragedInDiffLocation.value-0\"]");

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator HeaderUnderwriting => _page.GetByText("Header Underwriting", new() { Exact = true });

    // Source modules: EQ || Cycle Underwriting | confidence=Medium score=78
    // v56 raw Tosca primary: EQ || Cycle Underwriting | No_1 | Id
    // v56 semantic alias: same physical raw-Tosca control as HaveYouOrAnyHouseholdMemberEverBeenConvictedOfAFelony
    public ILocator IsAnyVintageCycleGaragedInADifferentLocation => HaveYouOrAnyHouseholdMemberEverBeenConvictedOfAFelony;

    // Source modules: EQ||New Quote | confidence=Medium score=113
    // v56 raw Tosca primary: EQ||New Quote | Txt_Quote\Policy Search | Id+Name
    public ILocator NewQuoteSearch => _page.Locator("input[id=\"quoteSearchInput\"][name=\"quoteSearchInput\"]");

    // Source modules: EQ || Cycle Underwriting | confidence=High score=127
    // v56 raw Tosca primary: EQ || Cycle Underwriting | No_1 | Id
    // v56 semantic alias: same physical raw-Tosca control as HaveYouOrAnyHouseholdMemberEverBeenConvictedOfAFelony
    public ILocator No1 => HaveYouOrAnyHouseholdMemberEverBeenConvictedOfAFelony;

    // Source modules: EQ || Cycle Underwriting | confidence=High score=127
    // v56 raw Tosca primary: EQ || Cycle Underwriting | No | Id
    public ILocator No43938 => _page.Locator("[id=\"fields.data.policy.underwritingQuestionsPolicy$felonyConviction.value-1\"]");

    // Source modules: EQ | Underwriting Eligibility Restrictions | confidence=High score=130
    public ILocator No77DAE => _page.GetByTestId("fields.data.policy.underwritingQuestionsPolicy$felonyConviction.value-chip-wrapper");

    // Source modules: EQ||PreQualification | confidence=Medium score=113
    // v56 raw Tosca primary: EQ||PreQualification | Btn_Chk box_check_boxNone Of The Above | Id
    // v56 semantic alias: same physical raw-Tosca control as ChkBoxCheckBoxNoneOfTheAbove
    public ILocator PreQualificationNext => ChkBoxCheckBoxNoneOfTheAbove;

    // Source modules: EQ||New Quote | confidence=High score=127
    public ILocator QuotePolicySearch => _page.Locator("[name=\"Txt_Quote\\\\Policy Search\"], [id=\"Txt_Quote\\\\Policy Search\"]").First;

    // Source modules: EQ | Underwriting Underwriting Next | confidence=Medium score=113
    public ILocator UnderwritingUnderwritingNextNext => CycleUnderwritingNext; // semantic alias; locator defined once

    // Source modules: EQ | Underwriting Eligibility Restrictions | confidence=High score=130
    public ILocator Yes707BB => No77DAE; // semantic alias; locator defined once

    // Source modules: EQ | Underwriting Collector And Vintage Information | confidence=High score=130
    public ILocator Yes71588 => _page.GetByTestId("fields.data.policy.underwritingQuestionsPolicy$vehiclesKeptEnclosed.value-chip-wrapper");

}
