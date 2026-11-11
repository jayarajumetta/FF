using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class FormsLocators
{
    private readonly IPage _page;
    public FormsLocators(IPage page) => _page = page;

    public ILocator PageTitle => _page.Locator("[id=\"pageTitle\"]");

    public ILocator HomersLiability => _page.GetByRole(AriaRole.Link, new() { Name = "Homeowner's Liability" });
    public ILocator WaterLiability => _page.GetByRole(AriaRole.Link, new() { Name = "Watercraft Liability" });

    public ILocator BusinessOwnerHeading => _page.Locator("//div[@id=\"pageTitle\" and text()='Businessowners']");

    public ILocator AddlInterests => _page.Locator("[id=\"pageTop\"]");

    public ILocator Businessowners => _page.GetByRole(AriaRole.Link, new() { Name = "Businessowners", Exact = true });

    public ILocator EffectiveDate => _page.FrameLocator("iframe").Locator("input[fieldref*=\".EffectiveDate\"]");
    public ILocator AddlInterestsLink => _page.GetByRole(AriaRole.Link, new() { Name = "Addl Interests", Exact = true });

    public ILocator LiquifiedGas => _page.Locator("input[fieldref=\"UmbrellaBusinessOwnersInput.PetroleumGasExposure\"]");

    public ILocator EmployerSLiabilityCheckBox => _page.Locator("input[fieldref=\"UmbrellaBusinessOwnersInput.EmployersLiability\"]");

    public ILocator ExpirationDate => _page.Locator("input[fieldref*=\".ExpirationDate\"]");

    public ILocator YearBuilt1980 => _page.Locator("div[fieldref=\"UmbrellaGeneralLiabilityInput.BuiltPrior1980\"], input[fieldref=\"UmbrellaSFP10LiabilityInput.BuiltPrior1980\"], div[fieldref=\"UmbrellaBusinessOwnersInput.BuiltPrior1980\"]");

    public ILocator ImportPolicyDataButton => _page.GetByRole(AriaRole.Link, new() { Name = "Import Policy Data", Exact = true });

    public ILocator LiabilityLimit => _page.Locator("input[fieldref*=\".LiabilityLimit\"]");

    public ILocator LoadingMessage => _page.Locator("[id=\"loadingMessage\"]");

    public ILocator PDLimit => _page.Locator("input[fieldref*=\".PDLimit\"]");

    public ILocator CommercialUMLimit => _page.Locator("input[fieldref*='UMLimit']");

    public ILocator PersonalAuto => _page.GetByRole(AriaRole.Link, new() { Name = "Personal Auto", Exact = true });

    public ILocator PolicyNumber => _page.Locator("input[fieldref*=\".PolicyNumber\"]");

    public ILocator SessionID => _page.Locator("xpath=(//*[@id = //label[translate(normalize-space(string(.)),'ABCDEFGHIJKLMNOPQRSTUVWXYZ ','abcdefghijklmnopqrstuvwxyz')='sessionid']/@for] | //label[translate(normalize-space(string(.)),'ABCDEFGHIJKLMNOPQRSTUVWXYZ ','abcdefghijklmnopqrstuvwxyz')='sessionid']//*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1] | //label[translate(normalize-space(string(.)),'ABCDEFGHIJKLMNOPQRSTUVWXYZ ','abcdefghijklmnopqrstuvwxyz')='sessionid']/following-sibling::*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1])");

    public ILocator StatusCode => _page.Locator("xpath=(//*[@id = //label[translate(normalize-space(string(.)),'ABCDEFGHIJKLMNOPQRSTUVWXYZ ','abcdefghijklmnopqrstuvwxyz')='statuscode']/@for] | //label[translate(normalize-space(string(.)),'ABCDEFGHIJKLMNOPQRSTUVWXYZ ','abcdefghijklmnopqrstuvwxyz')='statuscode']//*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1] | //label[translate(normalize-space(string(.)),'ABCDEFGHIJKLMNOPQRSTUVWXYZ ','abcdefghijklmnopqrstuvwxyz')='statuscode']/following-sibling::*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1])");

    public ILocator TotalSubjectPremium => _page.Locator("input[fieldref*=\".TotalSubjectPremium\"]");

    public ILocator Value => _page.FrameLocator("iframe").Locator("input[fieldref=\"NCCISearchInputNonShredded.SearchValue\"]");

}
