using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class LossHistoryLocators
{
    private readonly IPage _page;
    public LossHistoryLocators(IPage page) => _page = page;

    public ILocator AddAddlInterest => _page.GetByRole(AriaRole.Link, new() { Name = "Add Addl Interest", Exact = true });

    public ILocator PageTitle => _page.Locator("[id=\"pageTitle\"]");

    public ILocator OK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    public ILocator LossAddress => _page.Locator("input[fieldref=\"AdditionalOtherInterestInput.Address1\"]");

    public ILocator AssignLocations => _page.GetByRole(AriaRole.Link, new() { Name = "Assign Locations...", Exact = true });

    public ILocator AssignmentScheduleFor => _page.GetByText("Assignment Schedule for:", new() { Exact = true });


    public ILocator DescriptionOfProperty => _page.Locator("input[fieldref=\"AdditionalOtherInterestInput.PropertyDescription\"]");

    public ILocator FirstName => _page.Locator("input[fieldref=\"AdditionalOtherInterestInput.FirstName\"]");

    public ILocator InsuredType => _page.Locator("input[fieldref=\"AdditionalOtherInterestInput.InsuredType\"]");

    public ILocator LastName => _page.Locator("input[fieldref=\"AdditionalOtherInterestInput.LastName\"]");

    public ILocator LoanNumber => _page.Locator("input[fieldref=\"AdditionalOtherInterestInput.LoanNumber\"]");

    public ILocator MI => _page.Locator("input[fieldref=\"AdditionalOtherInterestInput.MiddleInitial\"]");

    public ILocator NewAssignment => _page.GetByRole(AriaRole.Link, new() { Name = "New Assignment...", Exact = true });




    public ILocator ProvisionsApplicable => _page.Locator("input[fieldref=\"AdditionalOtherInterestInput.ProvisionsApplicable\"]");

    public ILocator Type => _page.Locator("input[fieldref=\"AdditionalOtherInterestInput.Type\"]");

    public ILocator ZipCode => _page.Locator("input[fieldref=\"AdditionalOtherInterestInput.ZipCode\"]");
}
