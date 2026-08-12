using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQBOPClientDetailsEditClientRolesLocators
{
        public static ILocator BusinessOwner(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Business Owner", Exact = true });

        public static ILocator NamedInsured(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Named Insured", Exact = true });

        public static ILocator ThirdPartyDesignee(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Third Party Designee", Exact = true });

        public static ILocator KeyIndividual(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Key Individual", Exact = true });

        public static ILocator AuditContact(IPage page) =>
        page.GetByRole(AriaRole.Checkbox, new() { Name = "Audit Contact", Exact = true });

        public static ILocator InspectionContact(IPage page) =>
        page.GetByRole(AriaRole.Checkbox, new() { Name = "Inspection Contact", Exact = true });

}
