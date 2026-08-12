using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQCommonSubmissionPolicyFormsMainLocators
{
        public static ILocator PolicyForms(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Policy Forms", Exact = true });

        public static ILocator PolicyFormsHeader(IPage page) =>
        page.GetByText("Policy Forms", new() { Exact = true });

        public static ILocator FormsSearch(IPage page) =>
        page.Locator("id=temp.filter");

}
