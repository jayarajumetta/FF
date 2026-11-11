using Microsoft.Playwright;
namespace InsuranceAutomation.CLDC.Pages.Locators;
public sealed class RegressionPolicyChangeLocators
{
    private readonly IPage _page;
    public RegressionPolicyChangeLocators(IPage page) => _page = page;
    public ILocator PolicyCoverage => _page.GetByText("Policy Covg", new() { Exact = true }).First;
    public ILocator Property => _page.GetByText("Property", new() { Exact = true }).First;
    public ILocator Risk => _page.GetByText("Risk", new() { Exact = true }).First;
    public ILocator RiskSchedule => _page.GetByText("Risk Schedule", new() { Exact = true }).First;
    public ILocator Schedule => _page.GetByText("Schedule", new() { Exact = true }).First;
    public ILocator Detail => _page.GetByText("Detail", new() { Exact = true });
    public ILocator OK => _page.GetByText("OK", new() { Exact = true }).First;
    public ILocator BapLiabilityLimit => _page.Locator("input[fieldref='RiskDefaultsInput.LiabilityLimit']");
    public ILocator BapMedicalLimit => _page.Locator("input[fieldref='RiskDefaultsInput.MedicalLimit']");
    public ILocator GlOccurrenceLimit => _page.Locator("input[fieldref='LineInput.PolicyPerOccurenceLimit']");
    public ILocator GlProductsAggregateLimit => _page.Locator("input[fieldref='LineInput.ProductsAggregateLimit']");
    public ILocator PollutantCleanupLimit => _page.Locator("input[fieldref='LocationPropertyInput.PollutantCleanupLimit']");
    public ILocator InlandMarineSignsLimit => _page.Locator("input[fieldref='CoverageSignsIteratorInput.PremiumBase']");
    public ILocator UmbrellaLimit => _page.Locator("input[fieldref='LineInput.UmbrellaLimit']");
    public ILocator ContractorExposure => _page.Locator("input[fieldref='LineInput.PolicyContractorExposure']");
    public ILocator WebsiteAddress => _page.Locator("input[fieldref='AccountInput.WebsiteAddress']");
    public ILocator MailingAddress => _page.Locator("input[fieldref='AccountInput.Address1']");
    public ILocator MailingZip => _page.Locator("input[fieldref='AccountInput.ZipCode']");
    public ILocator SelectAllRisks => _page.Locator("input[fieldref='LocationSelectInput.SelectAllRisks']");
    public IFrameLocator Popup => _page.FrameLocator("iframe[id^='dctPopup_dctPopupWindow']");
    public ILocator WorkersCompPayroll => Popup.Locator("input[fieldref='CoverageInput.UnitsOfExposureEstimated']");
    public ILocator PopupOK => Popup.GetByText("OK", new() { Exact = true }).First;
}
