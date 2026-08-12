using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQTransmitConfirmationLocators
{
    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator PolicyNumber(IPage page) =>
        page.Locator("#PolicyOutput\\\\.PolicyNumber-0-layout");

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator EffectiveDate(IPage page) =>
        page.Locator("#PolicyInput\\\\.EffectiveDate-0-layout");

}
