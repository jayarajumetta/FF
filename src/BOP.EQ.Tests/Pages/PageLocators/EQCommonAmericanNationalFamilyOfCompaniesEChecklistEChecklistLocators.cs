using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQCommonAmericanNationalFamilyOfCompaniesEChecklistEChecklistLocators
{
        public static ILocator AcknowledgementLetterX5201(IPage page) =>
        page.Locator("id=checklist-item-name");

        public static ILocator Attach(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Attach", Exact = true });

}
