using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQCommonTransmitConfirmationLocators
{
        public static ILocator NEWBUSINESSPACKET(IPage page) =>
        page.GetByRole(AriaRole.Link, new() { Name = "NEW BUSINESS PACKET", Exact = true });

}
