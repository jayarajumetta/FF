using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class TransACTTransACTDetailPopupLocators
{
    // REVIEW: preserved original selector.
        // REVIEW: no stronger source locator.
    public static ILocator IFRAME(IPage page) =>
        page.Locator("[id^=\"dctPopup_dctPopupWindow\"]");

}
