using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class ClientSearchLocators
{
    private readonly IPage _page;
    public ClientSearchLocators(IPage page) => _page = page;

    public ILocator AddNamedInsuredIndividual => _page.Locator("a[fieldref=\"Add Named Insured - Individual\"]");

    public ILocator AdditionalInsuredFirstName => _page.Locator("input[fieldref=\"AdditionalNamedInsuredInput.FirstName\"]");

    public ILocator AdditionalInsuredMiddleName => _page.Locator("input[fieldref=\"AdditionalNamedInsuredInput.MiddleName\"]");

    public ILocator AdditionalNamedInsured => _page.Locator("a[fieldref=\"Additional Named Insured\"]");

    public ILocator AdditionalNamedInsuredHeading => _page.Locator("[id=\"pageTop\"]");

    public ILocator Address => _page.Locator("input[fieldref=\"AccountInput.Address1\"]");

    public ILocator AdditionalInsuredIndividualAddress => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Address 1*");

    public ILocator AddressLineTwo => _page.Locator("input[fieldref=\"AccountInput.Address2\"]");

    public ILocator BusinessName => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Business Name");

    public ILocator City => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "City");

    public ILocator AddClient => _page.Locator("a[fieldref=\"Add Client\"]");

    public ILocator ClientSearch => _page.Locator("a[fieldref=\"Client Search\"]");

    public ILocator Complete => _page.Locator("a[fieldref=\"Complete\"]");

    public ILocator DOB => _page.Locator("input[fieldref=\"AccountInput.DateOfBirth\"]");

    public ILocator AddAssociatedClientDateOfBirth => _page.Locator("[id=\"f_c174FBAF5A7CF4DFEA3CDA0B3A89411D010CF_1_1-inputEl\"]");

    public ILocator AdditionalInsuredIndividualDateOfBirth => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Date Of Birth*");

    public ILocator AddAssociatedClientDetail => _page.Locator("[id=\"dctGridLink\"]");


    public ILocator NamedInsuredIndividualEnterSSN => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Enter SSN");

    public ILocator AddAssociatedClientEnterSSN => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Enter SSN*");

    public ILocator EntityType => _page.Locator("input[fieldref=\"AccountInput.EntityType\"]");

    public ILocator FirstName => _page.Locator("input[fieldref=\"AccountInput.NameFirst\"]");

    public ILocator Gender => _page.Locator("input[fieldref=\"AccountInput.Gender\"]");

    public ILocator OK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    public ILocator IndividualType => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "IndividualType");

    public ILocator InsuredEMailAddress => _page.Locator("input[fieldref=\"AccountInput.Email\"]");

    public ILocator InsuredType => _page.Locator("input[fieldref=\"AccountInput.InsuredType\"]");

    public ILocator JavaScript => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "JavaScript");

    public ILocator LastName => _page.Locator("input[fieldref=\"AccountInput.NameLast\"]");

    public ILocator MiddleName => _page.Locator("input[fieldref=\"AccountInput.NameMI\"]");

    public ILocator NameOfAuditContact => _page.Locator("input[fieldref=\"AccountInput.AuditContact\"]");

    public ILocator NameOfInspectionContact => _page.Locator("input[fieldref=\"AccountInput.InspectionContact\"]");

    public ILocator OrderSSN => _page.Locator("a[fieldref=\"Order SSN\"]");

    public ILocator PleaseVerifySSN => _page.GetByText("Please verify SSN*", new() { Exact = true });

    public ILocator QuickQuote => _page.GetByRole(AriaRole.Checkbox, new() { Name = "Quick Quote", Exact = true });

    public ILocator Result => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Result");

    public ILocator ReturnToClient => _page.Locator("a[fieldref=\"Return to Client\"]");

    public ILocator SSNWasNotReturned => _page.GetByText("SSN was not returned*", new() { Exact = true });

    public ILocator SearchResultsDuckCreekPolicyFirstCheckbox => _page.GetByText("First Checkbox", new() { Exact = true });

    public ILocator SocialSecurity => _page.Locator("div[fieldref=\"Social Security #\"]");

    public ILocator State => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "State");

    public ILocator Title => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Title");

    public ILocator UnderwritingInfo => _page.GetByRole(AriaRole.Link, new() { Name = "Underwriting Info", Exact = true });

    public ILocator Verify => _page.Locator("a[fieldref=\"Verify\"]");

    public ILocator WebsiteAddress => _page.Locator("input[fieldref=\"AccountInput.WebsiteAddress\"]");

    public ILocator YearsInBusiness => _page.Locator("input[fieldref=\"AccountInput.YearsInBusiness\"]");

    public ILocator NamedInsuredZipCode => _page.Locator("input[fieldref=\"AccountInput.ZipCode\"]");

    public ILocator AdditionalInsuredIndividualZipCode => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Zip code*");

    public ILocator PrimaryPhone => _page.Locator("input[fieldref=\"AccountInput.PrimaryPhone\"]");

    public ILocator FEIN => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "FEIN*");

    public ILocator AuditTelephone => _page.Locator("input[fieldref=\"AccountInput.AuditContactPhone\"]");

    public ILocator InspectionTelephone => _page.Locator("input[fieldref=\"AccountInput.InspectionContactPhone\"]");
}
