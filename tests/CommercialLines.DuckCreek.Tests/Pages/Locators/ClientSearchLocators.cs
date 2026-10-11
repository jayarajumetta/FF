using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class ClientSearchLocators
{
    private readonly IPage _page;
    public ClientSearchLocators(IPage page) => _page = page;

    public ILocator AddNamedInsuredIndividual => _page.GetByRole(AriaRole.Link, new() { Name = "Add Named Insured - Individual", Exact = true });

    public ILocator AdditionalInsuredFirstName => _page.Locator("input[fieldref=\"AdditionalNamedInsuredInput.FirstName\"]");

    public ILocator AdditionalInsuredMiddleName => _page.Locator("input[fieldref=\"AdditionalNamedInsuredInput.MiddleName\"]");

    public ILocator AdditionalNamedInsured => _page.GetByRole(AriaRole.Link, new() { Name = "Additional Named Insured", Exact = true });

    public ILocator AdditionalNamedInsuredHeading => _page.Locator("[id=\"pageTop\"]");

    public ILocator Address => _page.Locator("input[fieldref=\"AccountInput.Address1\"]:visible, input[fieldref=\"AssociatedClientInput.Address1\"]:visible");

    public ILocator AdditionalInsuredIndividualAddress => _page.Locator("input[fieldref=\"IndividualNamedInsuredInput.Address1\"]");

    public ILocator AddressLineTwo => _page.Locator("input[fieldref=\"AccountInput.Address2\"]");

    public ILocator BusinessName => _page.Locator("input[fieldref=\"AccountInput.BusinessName\"]");

    public ILocator City => _page.Locator("input[fieldref=\"AssociatedClientInput.City\"]");

    public ILocator AddClient => _page.GetByRole(AriaRole.Link, new() { Name = "Add Client", Exact = true });

    public ILocator ClientSearch => _page.GetByRole(AriaRole.Link, new() { Name = "Client Search", Exact = true });

    public ILocator Complete => _page.GetByRole(AriaRole.Link, new() { Name = "Complete", Exact = true });

    public ILocator DOB => _page.Locator("input[fieldref=\"AccountInput.DateOfBirth\"]");

    public ILocator AddAssociatedClientDateOfBirth => _page.Locator("input[fieldref=\"AssociatedClientInput.DateOfBirth\"]");

    public ILocator AdditionalInsuredIndividualDateOfBirth => _page.Locator("input[fieldref=\"IndividualNamedInsuredInput.DateOfBirth\"]");

    public ILocator AddAssociatedClientDetail => _page.Locator("[id=\"dctGridLink\"]");


    public ILocator NamedInsuredIndividualEnterSSN => _page.Locator("input[fieldref=\"AccountSSNRetrievalInput.SSNInput\"]");

    public ILocator AddAssociatedClientEnterSSN => _page.Locator("input[fieldref=\"AssociatedClientSSNRetrievalInput.SSNInput\"]");

    public ILocator EntityType => _page.Locator("input[fieldref=\"AccountInput.EntityType\"]");

    public ILocator FirstName => _page.Locator("input[fieldref=\"AccountInput.NameFirst\"]:visible, input[fieldref=\"AssociatedClientInput.FirstName\"]:visible");

    public ILocator Gender => _page.Locator("input[fieldref=\"AccountInput.Gender\"]:visible, input[fieldref=\"AssociatedClientInput.Gender\"]:visible");

    public ILocator OK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    public ILocator IndividualType => _page.Locator("input[fieldref=\"AssociatedClientInput.IndividualType\"]");

    public ILocator InsuredEMailAddress => _page.Locator("input[fieldref=\"AccountInput.Email\"]");

    public ILocator InsuredType => _page.Locator("input[fieldref=\"AccountInput.InsuredType\"]");

    public ILocator JavaScript => _page.Locator("xpath=(//*[@id = //label[normalize-space(string(.))='JavaScript']/@for] | //label[normalize-space(string(.))='JavaScript']//*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1] | //label[normalize-space(string(.))='JavaScript']/following-sibling::*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1])");

    public ILocator LastName => _page.Locator("input[fieldref=\"AccountInput.NameLast\"]:visible, input[fieldref=\"AssociatedClientInput.LastName\"]:visible");

    public ILocator MiddleName => _page.Locator("input[fieldref=\"AccountInput.NameMI\"]:visible, input[fieldref=\"AssociatedClientInput.MiddleName\"]:visible");

    public ILocator NameOfAuditContact => _page.Locator("input[fieldref=\"AccountInput.AuditContact\"]");

    public ILocator NameOfInspectionContact => _page.Locator("input[fieldref=\"AccountInput.InspectionContact\"]");

    public ILocator OrderSSN => _page.GetByRole(AriaRole.Link, new() { Name = "Order SSN", Exact = true });

    public ILocator PleaseVerifySSN => _page.GetByText("Please verify SSN*", new() { Exact = true });

    public ILocator QuickQuote => _page.Locator("input[fieldref=\"PolicyOutputNonShredded.QuoteQuick\"]");

    public ILocator Result => _page.Locator("xpath=(//*[@id = //label[normalize-space(string(.))='Result']/@for] | //label[normalize-space(string(.))='Result']//*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1] | //label[normalize-space(string(.))='Result']/following-sibling::*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1])");

    public ILocator ReturnToClient => _page.GetByRole(AriaRole.Link, new() { Name = "Return to Client", Exact = true });

    public ILocator SSNWasNotReturned => _page.GetByText("SSN was not returned*", new() { Exact = true });

    public ILocator SearchResultsDuckCreekPolicyFirstCheckbox => _page.GetByText("First Checkbox", new() { Exact = true });

    public ILocator SocialSecurity => _page.GetByText("Social Security #", new() { Exact = true });
    public ILocator VerifySocialSecurity => _page.Locator("div[fieldref=\"AccountSSNRetrievalOuput.SSNDisplay\"]");

    public ILocator State => _page.Locator("input[fieldref=\"AssociatedClientInput.State\"]");

    public ILocator Title => _page.Locator("xpath=(//*[@id = //label[normalize-space(string(.))='Title']/@for] | //label[normalize-space(string(.))='Title']//*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1] | //label[normalize-space(string(.))='Title']/following-sibling::*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1])");

    public ILocator UnderwritingInfo => _page.GetByRole(AriaRole.Link, new() { Name = "Underwriting Info", Exact = true });

    public ILocator Verify => _page.GetByRole(AriaRole.Link, new() { Name = "Verify", Exact = true });

    public ILocator WebsiteAddress => _page.Locator("input[fieldref=\"AccountInput.WebsiteAddress\"]");

    public ILocator YearsInBusiness => _page.Locator("input[fieldref=\"AccountInput.YearsInBusiness\"]");

    public ILocator NamedInsuredZipCode => _page.Locator("input[fieldref=\"AccountInput.ZipCode\"]:visible, input[fieldref=\"AssociatedClientInput.ZipCode\"]:visible");

    public ILocator AdditionalInsuredIndividualZipCode => _page.Locator("input[fieldref=\"IndividualNamedInsuredInput.ZipCode\"]");

    public ILocator PrimaryPhone => _page.Locator("input[fieldref=\"AccountInput.PrimaryPhone\"]");

    public ILocator FEIN => _page.Locator("input[fieldref=\"AccountInput.FEIN\"]");

    public ILocator AuditTelephone => _page.Locator("input[fieldref=\"AccountInput.AuditContactPhone\"]");

    public ILocator InspectionTelephone => _page.Locator("input[fieldref=\"AccountInput.InspectionContactPhone\"]");
}
