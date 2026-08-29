using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class LossHistoryLocators
{
    private readonly IPage _page;
    public LossHistoryLocators(IPage page) => _page = page;

    public ILocator AddAddlInterest => _page.GetByRole(AriaRole.Link, new() { Name = "Add Addl Interest", Exact = true });

    public ILocator AddlInterests => _page.GetByRole(AriaRole.Link, new() { Name = "Addl Interests", Exact = true });

    public ILocator AddlInterestsMainOK => _page.GetByRole(AriaRole.Link, new() { Name = "Addl Interests Main - OK", Exact = true });

    public ILocator LossAddress => _page.GetByRole(AriaRole.Textbox, new() { Name = "Address 1*", Exact = true });

    public ILocator AssignLocations => _page.GetByRole(AriaRole.Link, new() { Name = "Assign Locations...", Exact = true });

    public ILocator AssignmentScheduleFor => _page.GetByText("Assignment Schedule for:", new() { Exact = true });

    public ILocator AssignmentScheduleForOK => _page.GetByRole(AriaRole.Link, new() { Name = "Assignment Schedule for - OK", Exact = true });

    public ILocator DescriptionOfProperty => _page.GetByRole(AriaRole.Textbox, new() { Name = "Description Of Property*", Exact = true });

    public ILocator FirstName => _page.GetByRole(AriaRole.Textbox, new() { Name = "First Name*", Exact = true });

    public ILocator InsuredType => _page.GetByRole(AriaRole.Textbox, new() { Name = "Insured Type*", Exact = true });

    public ILocator LastName => _page.GetByRole(AriaRole.Textbox, new() { Name = "Last Name*", Exact = true });

    public ILocator LoanNumber => _page.GetByRole(AriaRole.Textbox, new() { Name = "Loan Number", Exact = true });

    public ILocator MI => _page.GetByRole(AriaRole.Textbox, new() { Name = "MI", Exact = true });

    public ILocator NewAssignment => _page.GetByRole(AriaRole.Link, new() { Name = "New Assignment...", Exact = true });

    public ILocator OtherInterestPremisesDetailOK => _page.GetByRole(AriaRole.Link, new() { Name = "Other Interest Premises Detail - OK", Exact = true });

    public ILocator OtherInterestPremisesSchedule => _page.Locator("[id=\"pageTitle\"]");

    public ILocator OtherInterestPremisesScheduleOK => _page.GetByRole(AriaRole.Link, new() { Name = "Other Interest Premises Schedule - OK", Exact = true });

    public ILocator ProvisionsApplicable => _page.GetByRole(AriaRole.Textbox, new() { Name = "Provisions Applicable*", Exact = true });

    public ILocator Type => _page.GetByRole(AriaRole.Textbox, new() { Name = "Type", Exact = true });

    public ILocator ZipCode => _page.GetByRole(AriaRole.Textbox, new() { Name = "Zip Code*", Exact = true });
}
