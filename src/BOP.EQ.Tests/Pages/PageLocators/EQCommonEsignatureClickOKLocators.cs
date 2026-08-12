using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQCommonEsignatureClickOKLocators
{
        public static ILocator OkToUpdateFromChecklist(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Ok", Exact = true });

}
