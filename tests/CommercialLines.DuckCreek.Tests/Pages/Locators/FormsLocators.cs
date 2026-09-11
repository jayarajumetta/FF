using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class FormsLocators
{
    private readonly IPage _page;
    public FormsLocators(IPage page) => _page = page;

    public ILocator PageTitle => _page.Locator("[id=\"pageTitle\"]");

    public ILocator AddlInterests => _page.Locator("[id=\"pageTop\"]");



    public ILocator EffectiveDate => _page.Locator("input[fieldref=\"UmbrellaBusinessOwnersInput.EffectiveDate\"]");

    public ILocator EmployerSLiabilityCheckBox => _page.Locator("input[fieldref=\"UmbrellaBusinessOwnersInput.EmployersLiability\"]");

    public ILocator ExpirationDate => _page.Locator("input[fieldref=\"UmbrellaBusinessOwnersInput.ExpirationDate\"]");


    public ILocator ImportPolicyDataButton => _page.GetByRole(AriaRole.Link, new() { Name = "Import Policy Data", Exact = true });

    public ILocator LiabilityLimit => _page.Locator("input[fieldref=\"UmbrellaCommercialAutoInput.LiabilityLimit\"]");

    public ILocator LoadingMessage => _page.Locator("[id=\"loadingMessage\"]");

    public ILocator PDLimit => _page.Locator("input[fieldref=\"UmbrellaRecreationalVehicleLiabilityInput.PDLimit\"]");

    public ILocator PersonalAuto => _page.GetByRole(AriaRole.Link, new() { Name = "Personal Auto", Exact = true });

    public ILocator PolicyNumber => _page.Locator("input[fieldref=\"UmbrellaBusinessOwnersInput.PolicyNumber\"]");

    public ILocator SessionID => _page.Locator("xpath=(//*[@id = //label[normalize-space(string(.))='sessionID']/@for] | //label[normalize-space(string(.))='sessionID']//*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1] | //label[normalize-space(string(.))='sessionID']/following-sibling::*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1])");

    public ILocator StatusCode => _page.Locator("xpath=(//*[@id = //label[normalize-space(string(.))='StatusCode']/@for] | //label[normalize-space(string(.))='StatusCode']//*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1] | //label[normalize-space(string(.))='StatusCode']/following-sibling::*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1])");

    public ILocator TotalSubjectPremium => _page.Locator("input[fieldref=\"UmbrellaBusinessOwnersInputPremiums.TotalSubjectPremium\"]");

    public ILocator Value => _page.Locator("input[fieldref=\"NCCISearchInputNonShredded.SearchValue\"]");

}
