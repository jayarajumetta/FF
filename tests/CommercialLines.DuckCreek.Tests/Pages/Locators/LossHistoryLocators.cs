using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class LossHistoryLocators
{
    private readonly IPage _page;
    public LossHistoryLocators(IPage page) => _page = page;

    // Source modules: Addl Interests - Main | confidence=High score=125
    public ILocator AddAddlInterest => _page.GetByRole(AriaRole.Button, new() { Name = "Add Addl Interest", Exact = true });

    // Source modules: CP Navigation Links | confidence=Medium score=113
    public ILocator AddlInterests => _page.GetByRole(AriaRole.Link, new() { Name = "Addl Interests", Exact = true });

    // Source modules: Addl Interests - Loss Payee | confidence=High score=95
    public ILocator AddlInterestsMainOK => _page.GetByRole(AriaRole.Button, new() { Name = "Addl Interests Main - OK", Exact = true });

    // Source modules: Addl Interests - Loss Payee | confidence=High score=125
    public ILocator Address1 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Address 1*", Exact = true });

    // Source modules: Addl Interests - Loss Payee | confidence=High score=125
    public ILocator AssignLocations => _page.GetByRole(AriaRole.Button, new() { Name = "Assign Locations...", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator AssignmentScheduleFor => _page.GetByText("Assignment Schedule for:", new() { Exact = true });

    // Source modules: Addl Interests - Loss Payee | confidence=High score=125
    public ILocator AssignmentScheduleForOK => _page.GetByRole(AriaRole.Button, new() { Name = "Assignment Schedule for - OK", Exact = true });

    // Source modules: Addl Interests - Loss Payee | confidence=High score=125
    public ILocator DescriptionOfProperty => _page.GetByRole(AriaRole.Textbox, new() { Name = "Description Of Property*", Exact = true });

    // Source modules: Addl Interests - Loss Payee | confidence=High score=125
    public ILocator FirstName => _page.GetByRole(AriaRole.Textbox, new() { Name = "First Name*", Exact = true });

    // Source modules: Addl Interests - Loss Payee | confidence=High score=125
    public ILocator InsuredType => _page.GetByRole(AriaRole.Textbox, new() { Name = "Insured Type*", Exact = true });

    // Source modules: Addl Interests - Loss Payee | confidence=High score=125
    public ILocator LastName => _page.GetByRole(AriaRole.Textbox, new() { Name = "Last Name*", Exact = true });

    // Source modules: Addl Interests - Loss Payee | confidence=High score=125
    public ILocator LoanNumber => _page.GetByRole(AriaRole.Textbox, new() { Name = "Loan Number", Exact = true });

    // Source modules: Addl Interests - Loss Payee | confidence=High score=125
    public ILocator MI => _page.GetByRole(AriaRole.Textbox, new() { Name = "MI", Exact = true });

    // Source modules: Addl Interests - Loss Payee | confidence=High score=125
    public ILocator NewAssignment => _page.GetByRole(AriaRole.Button, new() { Name = "New Assignment...", Exact = true });

    // Source modules: Addl Interests - Loss Payee | confidence=High score=125
    public ILocator OtherInterestPremisesDetailOK => _page.GetByRole(AriaRole.Button, new() { Name = "Other Interest Premises Detail - OK", Exact = true });

    // Source modules: Addl Interests - Loss Payee | confidence=High score=97
    public ILocator OtherInterestPremisesSchedule => _page.GetByLabel("Other Interest Premises Schedule", new() { Exact = true });

    // Source modules: Addl Interests - Loss Payee | confidence=High score=125
    public ILocator OtherInterestPremisesScheduleOK => _page.GetByRole(AriaRole.Button, new() { Name = "Other Interest Premises Schedule - OK", Exact = true });

    // Source modules: Addl Interests - Loss Payee | confidence=High score=125
    public ILocator ProvisionsApplicable => _page.GetByRole(AriaRole.Textbox, new() { Name = "Provisions Applicable*", Exact = true });

    // Source modules: Addl Interests - Loss Payee | confidence=High score=125
    public ILocator Type => _page.GetByRole(AriaRole.Textbox, new() { Name = "Type", Exact = true });

    // Source modules: Addl Interests - Loss Payee | confidence=High score=125
    public ILocator ZipCode => _page.GetByRole(AriaRole.Textbox, new() { Name = "Zip Code*", Exact = true });

}
