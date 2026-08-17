using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class UnderwritingLocators
{
    private readonly IPage _page;
    public UnderwritingLocators(IPage page) => _page = page;

    // Source modules: EQ | Underwriting Collector And Vintage Information | confidence=Medium score=78
    public ILocator AreAllCollectorVehiclesKeptInAFullyEnclosedAndLockedStructure => _page.GetByLabel("Are all collector vehicles kept in a fully enclosed and locked structure?", new() { Exact = true });

    // Source modules: EQ||PreQualification | confidence=High score=127
    public ILocator ChkBoxCheckBoxNoneOfTheAbove => _page.GetByRole(AriaRole.Checkbox, new() { Name = "Btn_Chk box_check_boxNone Of The Above", Exact = true });

    // Source modules: EQ || Cycle Underwriting | confidence=High score=127
    public ILocator CycleUnderwritingNext => _page.GetByRole(AriaRole.Button, new() { Name = "Next", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator EQCommonLoadingIndicatorWait => _page.GetByText("EQ |Common|Loading Indicator Wait", new() { Exact = true });

    // Source modules: EQ || Cycle Underwriting | confidence=Medium score=78
    public ILocator HaveYouOrAnyHouseholdMemberEverBeenConvictedOfAFelony => _page.GetByLabel("Have you or any household member ever been convicted of a felony?", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator HeaderUnderwriting => _page.GetByText("Header Underwriting", new() { Exact = true });

    // Source modules: EQ || Cycle Underwriting | confidence=Medium score=78
    public ILocator IsAnyVintageCycleGaragedInADifferentLocation => _page.GetByLabel("Is any Vintage cycle garaged in a different location?", new() { Exact = true });

    // Source modules: EQ||New Quote | confidence=Medium score=113
    public ILocator NewQuoteSearch => _page.GetByRole(AriaRole.Button, new() { Name = "Btn_Search", Exact = true });

    // Source modules: EQ || Cycle Underwriting | confidence=High score=127
    public ILocator No1 => _page.GetByRole(AriaRole.Button, new() { Name = "No_1", Exact = true });

    // Source modules: EQ || Cycle Underwriting | confidence=High score=127
    public ILocator No43938 => _page.GetByRole(AriaRole.Button, new() { Name = "No", Exact = true });

    // Source modules: EQ | Underwriting Eligibility Restrictions | confidence=High score=130
    public ILocator No77DAE => _page.GetByTestId("fields.data.policy.underwritingQuestionsPolicy$felonyConviction.value-chip-wrapper");

    // Source modules: EQ||PreQualification | confidence=Medium score=113
    public ILocator PreQualificationNext => _page.GetByRole(AriaRole.Button, new() { Name = "Btn_Next", Exact = true });

    // Source modules: EQ||New Quote | confidence=High score=127
    public ILocator QuotePolicySearch => _page.GetByRole(AriaRole.Textbox, new() { Name = "Txt_Quote\\Policy Search", Exact = true });

    // Source modules: EQ | Underwriting Underwriting Next | confidence=Medium score=113
    public ILocator UnderwritingUnderwritingNextNext => _page.GetByRole(AriaRole.Button, new() { Name = "Next", Exact = true });

    // Source modules: EQ | Underwriting Eligibility Restrictions | confidence=High score=130
    public ILocator Yes707BB => _page.GetByTestId("fields.data.policy.underwritingQuestionsPolicy$felonyConviction.value-chip-wrapper");

    // Source modules: EQ | Underwriting Collector And Vintage Information | confidence=High score=130
    public ILocator Yes71588 => _page.GetByTestId("fields.data.policy.underwritingQuestionsPolicy$vehiclesKeptEnclosed.value-chip-wrapper");

}
