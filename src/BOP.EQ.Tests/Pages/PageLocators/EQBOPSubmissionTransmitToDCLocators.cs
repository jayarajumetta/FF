using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQBOPSubmissionTransmitToDCLocators
{
        public static ILocator Transmit(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Transmit", Exact = true });

}
