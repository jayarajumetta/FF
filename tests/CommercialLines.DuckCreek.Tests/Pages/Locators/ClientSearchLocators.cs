using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class ClientSearchLocators
{
    private readonly IPage _page;
    public ClientSearchLocators(IPage page) => _page = page;

    public ILocator AddNamedInsuredIndividual => _page.GetByRole(AriaRole.Link, new() { Name = "Add Named Insured - Individual", Exact = true });

    public ILocator AdditionalInsuredFirstName => _page.GetByRole(AriaRole.Textbox, new() { Name = "Additional Insured First Name", Exact = true });

    public ILocator AdditionalInsuredMiddleName => _page.GetByRole(AriaRole.Textbox, new() { Name = "Additional Insured Middle Name", Exact = true });

    public ILocator AdditionalNamedInsured => _page.GetByRole(AriaRole.Link, new() { Name = "Additional Named Insured", Exact = true });

    public ILocator AdditionalNamedInsuredHeading => _page.Locator("[id=\"pageTop\"]");

    public ILocator Address => _page.Locator("input[fieldref=\"AccountInput.Address1\"]");

    public ILocator AdditionalInsuredIndividualAddress => _page.GetByRole(AriaRole.Textbox, new() { Name = "Address 1*", Exact = true });

    public ILocator AddressLineTwo => _page.Locator("input[fieldref=\"AccountInput.Address2\"]");

    public ILocator BusinessName => _page.GetByRole(AriaRole.Textbox, new() { Name = "Business Name", Exact = true });

    public ILocator City => _page.GetByRole(AriaRole.Textbox, new() { Name = "City", Exact = true });

    public ILocator AddClient => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1679-21d3-307d-9ac2d420ffb8");

    public ILocator ClientSearch => _page.GetByRole(AriaRole.Link, new() { Name = "Client Search", Exact = true });

    public ILocator Complete => _page.GetByRole(AriaRole.Link, new() { Name = "Complete", Exact = true });

    public ILocator DOB => _page.Locator("input[fieldref=\"AccountInput.DateOfBirth\"]");

    public ILocator AddAssociatedClientDateOfBirth => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-16f1-5235-6ac4-b01a5f07f090");

    public ILocator AdditionalInsuredIndividualDateOfBirth => _page.GetByRole(AriaRole.Textbox, new() { Name = "Date Of Birth*", Exact = true });

    public ILocator AddAssociatedClientDetail => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-371e-c808-c1dcd0cae17d");

    public ILocator AdditionalInsuredIndividualDetail => _page.GetByRole(AriaRole.Link, new() { Name = "Detail", Exact = true });

    public ILocator NamedInsuredIndividualEnterSSN => _page.GetByRole(AriaRole.Textbox, new() { Name = "Enter SSN", Exact = true });

    public ILocator AddAssociatedClientEnterSSN => _page.GetByRole(AriaRole.Textbox, new() { Name = "Enter SSN*", Exact = true });

    public ILocator EntityType => _page.Locator("input[fieldref=\"AccountInput.EntityType\"]");

    public ILocator FirstName => _page.Locator("input[fieldref=\"AccountInput.NameFirst\"]");

    public ILocator Gender => _page.Locator("input[fieldref=\"AccountInput.Gender\"]");

    public ILocator OK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    public ILocator IndividualType => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1679-a316-96ce-ca532c48906e");

    public ILocator InsuredEMailAddress => _page.Locator("input[fieldref=\"AccountInput.Email\"]");

    public ILocator InsuredType => _page.Locator("input[fieldref=\"AccountInput.InsuredType\"]");

    public ILocator JavaScript => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "JavaScript");

    public ILocator LastName => _page.Locator("input[fieldref=\"AccountInput.NameLast\"]");

    public ILocator MiddleName => _page.Locator("input[fieldref=\"AccountInput.NameMI\"]");

    public ILocator NameOfAuditContact => _page.Locator("input[fieldref=\"AccountInput.AuditContact\"]");

    public ILocator NameOfInspectionContact => _page.Locator("input[fieldref=\"AccountInput.InspectionContact\"]");

    public ILocator OrderSSN => _page.GetByRole(AriaRole.Link, new() { Name = "Order SSN", Exact = true });

    public ILocator PleaseVerifySSN => _page.GetByText("Please verify SSN*", new() { Exact = true });

    public ILocator QuickQuote => _page.GetByRole(AriaRole.Checkbox, new() { Name = "Quick Quote", Exact = true });

    public ILocator Result => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Result");

    public ILocator ReturnToClient => _page.GetByRole(AriaRole.Link, new() { Name = "Return to Client", Exact = true });

    public ILocator SSNWasNotReturned => _page.GetByText("SSN was not returned*", new() { Exact = true });

    public ILocator SearchResultsDuckCreekPolicyFirstCheckbox => _page.GetByText("First Checkbox", new() { Exact = true });

    public ILocator SocialSecurity => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Social Security #");

    public ILocator State => _page.GetByRole(AriaRole.Textbox, new() { Name = "State", Exact = true });

    public ILocator Title => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Title");

    public ILocator UnderwritingInfo => _page.GetByRole(AriaRole.Link, new() { Name = "Underwriting Info", Exact = true });

    public ILocator Verify => _page.GetByRole(AriaRole.Link, new() { Name = "Verify", Exact = true });

    public ILocator WebsiteAddress => _page.Locator("input[fieldref=\"AccountInput.WebsiteAddress\"]");

    public ILocator YearsInBusiness => _page.Locator("input[fieldref=\"AccountInput.YearsInBusiness\"]");

    public ILocator NamedInsuredZipCode => _page.Locator("input[fieldref=\"AccountInput.ZipCode\"]");

    public ILocator AdditionalInsuredIndividualZipCode => _page.GetByRole(AriaRole.Textbox, new() { Name = "Zip code*", Exact = true });

    public ILocator PrimaryPhone => _page.Locator("input[fieldref=\"AccountInput.PrimaryPhone\"]");

    public ILocator FEIN => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "FEIN*");

    public ILocator AuditTelephone => _page.Locator("input[fieldref=\"AccountInput.AuditContactPhone\"]");

    public ILocator InspectionTelephone => _page.Locator("input[fieldref=\"AccountInput.InspectionContactPhone\"]");
}
