using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQBOPPreQualificationAddAClassLocators
{
        public static ILocator PreQualificationHeading(IPage page) =>
        page.GetByText("PreQualification", new() { Exact = true });

        public static ILocator SearchAddClassCode(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Search/Add Class Code", Exact = true });

        public static ILocator AddClassTablePopup(IPage page) =>
        page.GetByText("*Find a Class Code*", new() { Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator TABLE(IPage page) =>
        page.GetByText("Class CodeIndustryDescriptionPrimary*", new() { Exact = true });

}
