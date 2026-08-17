using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class VehiclesLocators
{
    private readonly IPage _page;
    public VehiclesLocators(IPage page) => _page = page;

    // Source modules: EQ|SFP|DIV 4|Scheduled Personal Property|Bicycles | confidence=High score=130
    public ILocator AddCoverage => _page.GetByTestId("*ddBicycles*");

    // Source modules: EQ|Common|Client Info | confidence=Medium score=113
    public ILocator ClientInfoSearch => _page.GetByRole(AriaRole.Button, new() { Name = "Search", Exact = true });

    // Source modules: EQ|BOP|Building|Personal Property|Add Inventory | confidence=High score=127
    public ILocator Description => _page.GetByRole(AriaRole.Textbox, new() { Name = "Description", Exact = true });

    // Source modules: EQ|SFP|DIV 4|Scheduled Personal Property|Bicycles | confidence=High score=127
    public ILocator Limit => _page.GetByRole(AriaRole.Textbox, new() { Name = "Limit", Exact = true });

    // Source modules: EQ |Common|Loading Indicator Wait | confidence=Medium score=78
    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    // Source modules: EQ|SFP|DIV V|Optional Liability Coverage|Workers' Compensation - Residence EmployeesExpertQuote | confidence=High score=130
    public ILocator Save => _page.GetByTestId("fields.line.save");

    // Source modules: EQ|SFP|DIV 4|Scheduled Personal Property|Bicycles | confidence=Medium score=78
    public ILocator ScheduledPersonalPropertyHeader => _page.GetByLabel("Scheduled Personal Property Header", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator ScreenHeading => _page.GetByText("Screen Heading", new() { Exact = true });

    // Source modules: EQ|SFP|DIV 4|Scheduled Personal Property|Bicycles | confidence=High score=127
    public ILocator SearchByNameOrCode => _page.GetByRole(AriaRole.Textbox, new() { Name = "Search by Name or Code", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator True => _page.GetByText("True", new() { Exact = true });

    // Source modules: EQ|SFP|DIV 4|Scheduled Personal Property|Bicycles | confidence=High score=127
    public ILocator YearOfLastAppraisal => _page.GetByRole(AriaRole.Textbox, new() { Name = "Year Of Last Appraisal", Exact = true });

}
