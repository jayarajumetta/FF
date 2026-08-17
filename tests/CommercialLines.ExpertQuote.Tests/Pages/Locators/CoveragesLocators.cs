using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class CoveragesLocators
{
    private readonly IPage _page;
    public CoveragesLocators(IPage page) => _page = page;

    // Source modules: EQ|SFP|DIV 4|Scheduled Personal Property|Bicycles | confidence=High score=130
    public ILocator AddCoverage => _page.GetByTestId("*ddBicycles*");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator Approve => _page.GetByText("Approve", new() { Exact = true });

    // Source modules: EQ|SFP|CE|Coverages | confidence=High score=127
    public ILocator BlanketFPP => _page.GetByRole(AriaRole.Textbox, new() { Name = "Blanket FPP", Exact = true });

    // Source modules: EQ|SFP|PolicyWide Coverage|CE | confidence=High score=127
    public ILocator CECoverage => _page.GetByRole(AriaRole.Checkbox, new() { Name = "CE Coverage", Exact = true });

    // Source modules: EQ|BOP|Building|Class|Enter supplemental data for selected Class Code(s) | confidence=High score=127
    public ILocator CheckBox => _page.GetByRole(AriaRole.Checkbox, new() { Name = "CheckBox", Exact = true });

    // Source modules: EQ|SFP|CE|Coverages | confidence=Medium score=83
    public ILocator Choice => _page.GetByRole(AriaRole.Radio, new() { Name = "Choice", Exact = true });

    // Source modules: EQ|SFP|CE|Coverages | confidence=Medium score=83
    public ILocator ChoiceWithHorse => _page.GetByRole(AriaRole.Radio, new() { Name = "ChoiceWithHorse", Exact = true });

    // Source modules: EQ|SFP|Div I - Add Residence|Add Residence Covg | confidence=High score=127
    public ILocator Deductible => _page.GetByLabel("Deductible", new() { Exact = true });

    // Source modules: EQ|BOP|Building|Personal Property|Add Inventory | confidence=High score=127
    public ILocator Description => _page.GetByRole(AriaRole.Textbox, new() { Name = "Description", Exact = true });

    // Source modules: EQ|BOP|Additional Coverages|Answer EPLI Questions | confidence=High score=127
    public ILocator DoesTheInsuredAndAnyExecutiveOfficerOrOwnerHaveAnyKnowledgeOrInformationOfAnyActErrorOrOmissionWhichMightGiveRiseToAnEPLClaimSuitOrComplaint => _page.GetByRole(AriaRole.Combobox, new() { Name = "Does the insured and any executive, officer or owner have any knowledge or information of any act, error or omission which might give rise to an EPL claim, suit or complaint?", Exact = true });

    // Source modules: EQ|BOP|Additional Coverages|Answer EPLI Questions | confidence=High score=127
    public ILocator HaveThereBeenAnyEPLClaimsSuitsOrComplaintsOrAreThereAnyNowPendingAgainstTheInsuredOrAnyExecutiveOfficerOrOwner => _page.GetByRole(AriaRole.Combobox, new() { Name = "Have there been any EPL claims, suits or complaints or are there any now pending against the insured or any executive, officer or owner?", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator IFRAME => _page.GetByText("IFRAME", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator IFRAMEDuckCreekPolicyIFRAMEOK => _page.GetByText("IFRAME - OK", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator IsThisCoverageBound => _page.GetByText("Is this coverage bound?*", new() { Exact = true });

    // Source modules: EQ|SFP|CE|Coverages | confidence=High score=127
    public ILocator LiabilityLimit => _page.GetByRole(AriaRole.Combobox, new() { Name = "Liability Limit", Exact = true });

    // Source modules: EQ|SFP|DIV 4|Scheduled Personal Property|Bicycles | confidence=High score=127
    public ILocator Limit => _page.GetByRole(AriaRole.Textbox, new() { Name = "Limit", Exact = true });

    // Source modules: EQ |Common|Loading Indicator Wait | confidence=Medium score=78
    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    // Source modules: EQ|SFP|CE|Coverages | confidence=Medium score=83
    public ILocator Premier => _page.GetByRole(AriaRole.Radio, new() { Name = "Premier", Exact = true });

    // Source modules: EQ|SFP|CE|Coverages | confidence=Medium score=83
    public ILocator PremierWithHorse => _page.GetByRole(AriaRole.Radio, new() { Name = "PremierWithHorse", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator ReferRequestIssuance => _page.GetByText("Refer/Request Issuance", new() { Exact = true });

    // Source modules: EQ|SFP|DIV V|Optional Liability Coverage|Workers' Compensation - Residence EmployeesExpertQuote | confidence=High score=130
    public ILocator Save => _page.GetByTestId("fields.line.save");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator ScreenHeading => _page.GetByText("Screen Heading", new() { Exact = true });

    // Source modules: EQ|SFP|DIV 4|Scheduled Personal Property|Bicycles | confidence=High score=127
    public ILocator SearchByNameOrCode => _page.GetByRole(AriaRole.Textbox, new() { Name = "Search by Name or Code", Exact = true });

    // Source modules: EQ|SFP|CE|Coverages | confidence=Medium score=83
    public ILocator Select => _page.GetByRole(AriaRole.Radio, new() { Name = "Select", Exact = true });

    // Source modules: EQ|SFP|CE|Coverages | confidence=Medium score=83
    public ILocator SelectWithHorse => _page.GetByRole(AriaRole.Radio, new() { Name = "SelectWithHorse", Exact = true });

    // Source modules: EQ|SFP|CE|Coverages | confidence=High score=127
    public ILocator UnscheduledStructures => _page.GetByRole(AriaRole.Combobox, new() { Name = "Unscheduled Structures", Exact = true });

    // Source modules: EQ|SFP|CE|Coverages | confidence=High score=127
    public ILocator WaterDamage => _page.GetByRole(AriaRole.Combobox, new() { Name = "Water Damage", Exact = true });

}