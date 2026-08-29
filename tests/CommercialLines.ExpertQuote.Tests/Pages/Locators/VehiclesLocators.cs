using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class VehiclesLocators
{
    private readonly IPage _page;
    public VehiclesLocators(IPage page) => _page = page;

    // Source modules: EQ|SFP|DIV 4|Scheduled Personal Property|Bicycles | confidence=High score=130
    public ILocator AddCoverage => _page.GetByTestId("*ddBicycles*");

    // Source modules: EQ|Common|Client Info | confidence=Medium score=113
    // v56 raw Tosca primary: EQ|Common|Client Info | customer.name.first | Id+Name
    public ILocator ClientInfoSearch => _page.Locator("input[id=\"customer.name.first\"][name=\"customer.name.first\"]");

    // Source modules: EQ|BOP|Building|Personal Property|Add Inventory | confidence=High score=127
    // v56 raw Tosca primary: EQ|BOP|Building|Personal Property|Add Inventory | Description | Id+Name
    public ILocator Description => _page.Locator("input[id=\"\\\"fields.risk.rows[0].businessPersonalPropertyInventorySheet.businessPersonalPropertyInventorySheetScheduled.rows[0].businessPersonalPropertyInventorySheetScheduledInput$description.value\\\"\"][name=\"\\\"fields.risk.rows[0].businessPersonalPropertyInventorySheet.businessPersonalPropertyInventorySheetScheduled.rows[0].businessPersonalPropertyInventorySheetScheduledInput$description.value\\\"\"]");

    // Source modules: EQ|SFP|DIV 4|Scheduled Personal Property|Bicycles | confidence=High score=127
    // v56 raw Tosca primary: EQ|SFP|DIV 4|Scheduled Personal Property|Bicycles | Limit | Id+Name
    public ILocator Limit => _page.Locator("input[id=\"\\\"fields.covEndorsements.rows[0].covEndorsementsInput$limit.value\\\"\"][name=\"\\\"fields.covEndorsements.rows[0].covEndorsementsInput$limit.value\\\"\"]");

    // Source modules: EQ |Common|Loading Indicator Wait | confidence=Medium score=78
    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    // Source modules: EQ|SFP|DIV V|Optional Liability Coverage|Workers' Compensation - Residence EmployeesExpertQuote | confidence=High score=130
    // v56 raw Tosca primary:  | Save | DuckCreekId | frame=iframe
    public ILocator Save => _page.FrameLocator("iframe").Locator("[duckcreekid=\"Save\"], [data-duckcreekid=\"Save\"]");

    // Source modules: EQ|SFP|DIV 4|Scheduled Personal Property|Bicycles | confidence=Medium score=78
    // v56 raw Tosca primary: EQ|SFP|DIV 4|Scheduled Personal Property|Bicycles | CheckBox | Id+Name
    public ILocator ScheduledPersonalPropertyHeader => _page.Locator("input[id=\"\\\"fields.page.covCatEntry.rows[1].covCatEntryInput$selected.value-input\\\"\"][name=\"\\\"fields.page.covCatEntry.rows[1].covCatEntryInput$selected.value\\\"\"]");

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator ScreenHeading => _page.GetByText("Screen Heading", new() { Exact = true });

    // Source modules: EQ|SFP|DIV 4|Scheduled Personal Property|Bicycles | confidence=High score=127
    // v56 raw Tosca primary: EQ|SFP|DIV 4|Scheduled Personal Property|Bicycles | Search by Name or Code | Id+Name
    public ILocator SearchByNameOrCode => _page.Locator("input[id=\"temp.filter\"][name=\"temp.filter\"]");

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator True => _page.GetByText("True", new() { Exact = true });

    // Source modules: EQ|SFP|DIV 4|Scheduled Personal Property|Bicycles | confidence=High score=127
    // v56 raw Tosca primary: EQ|SFP|DIV 4|Scheduled Personal Property|Bicycles | Year Of Last Appraisal | Id+Name
    public ILocator YearOfLastAppraisal => _page.Locator("input[id=\"\\\"fields.covEndorsements.rows[0].covEndorsementsInput$yearOfLastAppraisal.value\\\"\"][name=\"\\\"fields.covEndorsements.rows[0].covEndorsementsInput$yearOfLastAppraisal.value\\\"\"]");

}
