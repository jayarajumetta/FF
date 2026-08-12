using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQCommonNarrativeLocators
{
        public static ILocator NarrativeScreenHeading(IPage page) =>
        page.GetByText("Narrative", new() { Exact = true });

        public static ILocator AddNarrative(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Add Narrative", Exact = true });

        public static ILocator Edit(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Edit", Exact = true });

        public static ILocator DescriptionOfTheBusinessExposuresActivitiesAndExperience(IPage page) =>
        page.Locator("id=\"fields.data.notes.rows[0].notesInput$remarks.value\"");

        public static ILocator Save(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true });

        public static ILocator UserDateAndTimestamp(IPage page) =>
        page.GetByText(" */*/*", new() { Exact = true });

}
