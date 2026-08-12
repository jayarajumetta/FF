using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQCommonSSNLocators
{
        public static ILocator TheSSNCouldNotBeFoundPleaseEnterAnSSN(IPage page) =>
        page.GetByText("No SSN# Found. Please Enter Full SSN#", new() { Exact = true });

        public static ILocator Ssn(IPage page) =>
        page.Locator("id=ssn");

        // REVIEW: no stronger source locator.
    public static ILocator SUBMIT(IPage page) =>
        page.GetByRole(AriaRole.Link, new() { Name = "SUBMIT", Exact = true });

        public static ILocator SubmitAngular(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Submit", Exact = true });

        public static ILocator NoPrefillMatchFound(IPage page) =>
        page.GetByText("No Prefill Match Found", new() { Exact = true });

        public static ILocator Continue(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Continue", Exact = true });

}
