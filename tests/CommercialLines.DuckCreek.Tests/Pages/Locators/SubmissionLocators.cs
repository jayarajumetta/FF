using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class SubmissionLocators
{
    private readonly IPage _page;
    public SubmissionLocators(IPage page) => _page = page;

    public ILocator AllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabs => _page.Locator("xpath=(//*[@id = //label[normalize-space(string(.))='All required fields have not been completed. Please complete highlighted tabs.']/@for] | //label[normalize-space(string(.))='All required fields have not been completed. Please complete highlighted tabs.']//*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1] | //label[normalize-space(string(.))='All required fields have not been completed. Please complete highlighted tabs.']/following-sibling::*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1])");

    public ILocator CompleteApplication => _page.GetByRole(AriaRole.Link, new() { Name = "Complete Application", Exact = true });

    public ILocator IsThisCoverageBound => _page.Locator("xpath=(//*[@id = //label[normalize-space(string(.))='Is this coverage bound?*']/@for] | //label[normalize-space(string(.))='Is this coverage bound?*']//*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1] | //label[normalize-space(string(.))='Is this coverage bound?*']/following-sibling::*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1])");

    public ILocator JavaScript => _page.Locator("xpath=(//*[@id = //label[normalize-space(string(.))='JavaScript']/@for] | //label[normalize-space(string(.))='JavaScript']//*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1] | //label[normalize-space(string(.))='JavaScript']/following-sibling::*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1])");

    public ILocator LoadingMessage => _page.Locator("[id=\"loadingMessage\"]");

    public ILocator Result => _page.Locator("xpath=(//*[@id = //label[normalize-space(string(.))='Result']/@for] | //label[normalize-space(string(.))='Result']//*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1] | //label[normalize-space(string(.))='Result']/following-sibling::*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1])");

    public ILocator StoplightWaitingWindow => _page.Locator("[id=\"stoplightWaitingWindow\"]");

    public ILocator StoplightWaitingWindowClose => _page.GetByText("Close", new() { Exact = true });

    public ILocator StoplightWaitingWindowError => _page.GetByText("Error:", new() { Exact = true });

    public ILocator StoplightWaitingWindowFirstCloseButtonOnError => _page.GetByText("First Close button on Error", new() { Exact = true });

    public ILocator Title => _page.Locator("xpath=(//*[@id = //label[normalize-space(string(.))='Title']/@for] | //label[normalize-space(string(.))='Title']//*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1] | //label[normalize-space(string(.))='Title']/following-sibling::*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1])");
}
