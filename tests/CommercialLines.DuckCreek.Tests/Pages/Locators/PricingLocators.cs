using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class PricingLocators
{
    private readonly IPage _page;
    public PricingLocators(IPage page) => _page = page;

    public ILocator EstimatedPremium => _page.Locator("input[fieldref=\"PolicyInput.EstimatedPremium\"]");

    public ILocator FullTermPremium => _page.Locator("xpath=(//*[@id = //label[normalize-space(string(.))='Full Term Premium']/@for] | //label[normalize-space(string(.))='Full Term Premium']//*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1] | //label[normalize-space(string(.))='Full Term Premium']/following-sibling::*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1])");

    public ILocator JavaScript => _page.Locator("xpath=(//*[@id = //label[normalize-space(string(.))='JavaScript']/@for] | //label[normalize-space(string(.))='JavaScript']//*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1] | //label[normalize-space(string(.))='JavaScript']/following-sibling::*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1])");

    public ILocator Premium => _page.Locator("xpath=(//*[@id = //label[normalize-space(string(.))='Premium']/@for] | //label[normalize-space(string(.))='Premium']//*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1] | //label[normalize-space(string(.))='Premium']/following-sibling::*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1])");

    public ILocator PremiumChange => _page.Locator("xpath=(//*[@id = //label[normalize-space(string(.))='Premium Change']/@for] | //label[normalize-space(string(.))='Premium Change']//*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1] | //label[normalize-space(string(.))='Premium Change']/following-sibling::*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1])");

    public ILocator PremiumWritten => _page.Locator("xpath=(//*[@id = //label[normalize-space(string(.))='Premium Written']/@for] | //label[normalize-space(string(.))='Premium Written']//*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1] | //label[normalize-space(string(.))='Premium Written']/following-sibling::*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1])");

    public ILocator PriorPremium => _page.Locator("xpath=(//*[@id = //label[normalize-space(string(.))='Prior Premium']/@for] | //label[normalize-space(string(.))='Prior Premium']//*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1] | //label[normalize-space(string(.))='Prior Premium']/following-sibling::*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1])");

    public ILocator Result => _page.Locator("xpath=(//*[@id = //label[normalize-space(string(.))='Result']/@for] | //label[normalize-space(string(.))='Result']//*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1] | //label[normalize-space(string(.))='Result']/following-sibling::*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1])");

    public ILocator Title => _page.Locator("xpath=(//*[@id = //label[normalize-space(string(.))='Title']/@for] | //label[normalize-space(string(.))='Title']//*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1] | //label[normalize-space(string(.))='Title']/following-sibling::*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1])");
}
