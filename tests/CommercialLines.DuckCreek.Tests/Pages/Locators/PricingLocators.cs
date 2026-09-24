using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class PricingLocators
{
    private readonly IPage _page;
    public PricingLocators(IPage page) => _page = page;

    public ILocator EstimatedPremium => _page.Locator("input[fieldref=\"PolicyInput.EstimatedPremium\"]");

    public ILocator FullTermPremium => _page.Locator("div[fieldref=\"PolicyOutput.Premium\"]");

    public ILocator JavaScript => _page.Locator("xpath=(//*[@id = //label[normalize-space(string(.))='JavaScript']/@for] | //label[normalize-space(string(.))='JavaScript']//*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1] | //label[normalize-space(string(.))='JavaScript']/following-sibling::*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1])");

    public ILocator Premium => _page.Locator("xpath=(//*[@id = //label[normalize-space(string(.))='Premium']/@for] | //label[normalize-space(string(.))='Premium']//*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1] | //label[normalize-space(string(.))='Premium']/following-sibling::*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1])");

    public ILocator PremiumChange => _page.Locator("div[fieldref=\"PolicyOutput.PremiumChange\"]");

    public ILocator PremiumWritten => _page.Locator("div[fieldref=\"PolicyOutput.PremiumWritten\"]");

    public ILocator PriorPremium => _page.Locator("div[fieldref=\"PolicyOutput.PremiumPrior\"]");

    public ILocator Result => _page.Locator("xpath=(//*[@id = //label[normalize-space(string(.))='Result']/@for] | //label[normalize-space(string(.))='Result']//*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1] | //label[normalize-space(string(.))='Result']/following-sibling::*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1])");

    public ILocator Title => _page.Locator("xpath=(//*[@id = //label[normalize-space(string(.))='Title']/@for] | //label[normalize-space(string(.))='Title']//*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1] | //label[normalize-space(string(.))='Title']/following-sibling::*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1])");
}
