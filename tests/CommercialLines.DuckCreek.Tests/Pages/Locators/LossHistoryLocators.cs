using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class LossHistoryLocators
{
    private readonly IPage _page;
    public LossHistoryLocators(IPage page) => _page = page;

    public ILocator AddAddlInterest => _page.Locator("a[fieldref=\"Add Addl Interest\"]");

    public ILocator PageTitle => _page.Locator("[id=\"pageTitle\"]");

    public ILocator OK => _page.Locator("a[fieldref=\"OK\"]");

    public ILocator LossAddress => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Address 1*");

    public ILocator AssignLocations => _page.GetByRole(AriaRole.Link, new() { Name = "Assign Locations...", Exact = true });

    public ILocator AssignmentScheduleFor => _page.GetByText("Assignment Schedule for:", new() { Exact = true });


    public ILocator DescriptionOfProperty => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Description Of Property*");

    public ILocator FirstName => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "First Name*");

    public ILocator InsuredType => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Insured Type*");

    public ILocator LastName => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Last Name*");

    public ILocator LoanNumber => _page.Locator("input[fieldref=\"AdditionalOtherInterestInput.LoanNumber\"]");

    public ILocator MI => _page.Locator("input[fieldref=\"AdditionalOtherInterestInput.MiddleInitial\"]");

    public ILocator NewAssignment => _page.Locator("a[fieldref=\"New Assignment...\"]");




    public ILocator ProvisionsApplicable => _page.Locator("input[fieldref=\"AdditionalOtherInterestInput.ProvisionsApplicable\"]");

    public ILocator Type => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Type");

    public ILocator ZipCode => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Zip Code*");
}
