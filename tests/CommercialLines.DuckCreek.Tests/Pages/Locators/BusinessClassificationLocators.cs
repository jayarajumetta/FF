using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class BusinessClassificationLocators
{
    private readonly IPage _page;
    public BusinessClassificationLocators(IPage page) => _page = page;

    public ILocator InvalidClassCodeMessage => _page.Locator("xpath=(//*[@id = //label[normalize-space(string(.))='Invalid Class Code Message']/@for] | //label[normalize-space(string(.))='Invalid Class Code Message']//*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1] | //label[normalize-space(string(.))='Invalid Class Code Message']/following-sibling::*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1])");
}
