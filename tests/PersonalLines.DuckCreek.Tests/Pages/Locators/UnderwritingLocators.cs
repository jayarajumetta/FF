using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class UnderwritingLocators
{
    private readonly IPage _page;
    public UnderwritingLocators(IPage page) => _page = page;

    public ILocator AreAllCollectorVehiclesKeptInAFullyEnclosedAndLockedStructure => _page.GetByLabel("Are all collector vehicles kept in a fully enclosed and locked structure?", new() { Exact = true });

    public ILocator ChkBoxCheckBoxNoneOfTheAbove => _page.Locator("[id=\"fields.data.policy.preQualificationQuestionPolicy$noneOfTheAbove.value-checkbox\"]");

    public ILocator CycleUnderwritingNext => _page.Locator("[id=\"fields.pageAction.next\"]");

    public ILocator EQCommonLoadingIndicatorWait => _page.GetByText("EQ |Common|Loading Indicator Wait", new() { Exact = true });

    public ILocator HaveYouOrAnyHouseholdMemberEverBeenConvictedOfAFelony => _page.Locator("[id=\"fields.data.policy.underwritingQuestionsPolicy$vintageVehGaragedInDiffLocation.value-0\"]");

    public ILocator HeaderUnderwriting => _page.GetByText("Header Underwriting", new() { Exact = true });


    public ILocator NewQuoteSearch => _page.Locator("input[id=\"quoteSearchInput\"][name=\"quoteSearchInput\"]");


    public ILocator No43938 => _page.Locator("[id=\"fields.data.policy.underwritingQuestionsPolicy$felonyConviction.value-1\"]");

    public ILocator No77DAE => _page.GetByTestId("fields.data.policy.underwritingQuestionsPolicy$felonyConviction.value-chip-wrapper");


    public ILocator QuotePolicySearch => _page.Locator("[name=\"Txt_Quote\\\\Policy Search\"], [id=\"Txt_Quote\\\\Policy Search\"]").First;



    public ILocator Yes71588 => _page.GetByTestId("fields.data.policy.underwritingQuestionsPolicy$vehiclesKeptEnclosed.value-chip-wrapper");

}
