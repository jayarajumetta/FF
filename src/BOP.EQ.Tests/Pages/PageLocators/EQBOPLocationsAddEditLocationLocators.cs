using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQBOPLocationsAddEditLocationLocators
{
        public static ILocator LabelNicknameForTheLocation(IPage page) =>
        page.Locator("id=fields.data.account.location.locationInput$description.value");

        public static ILocator FeetFromFireHydrant(IPage page) =>
        page.Locator("id=fields.data.account.location.locationBusinessOwnersInput$feetFromHydrant.value");

        public static ILocator OrderWildfireRiskScore(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Order Wildfire Risk Score", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator Item1100(IPage page) =>
        page.GetByText("1 - 100", new() { Exact = true });

        public static ILocator Save(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true });

        public static ILocator MilesFromFireDepartment(IPage page) =>
        page.Locator("[name=\"fields.data.account.location.locationBusinessOwnersInput$milesFromFireDepartment.value\"]");

        public static ILocator Address1(IPage page) =>
        page.Locator("id=fields.data.account.location.locationInput$address1.value");

        public static ILocator StateDropdown(IPage page) =>
        page.Locator("id=fields.data.account.location.locationInput$state.value");

        // REVIEW: no stronger source locator.
    public static ILocator State(IPage page) =>
        page.GetByText("{{buffer:State Dropdown}}", new() { Exact = true });

        public static ILocator City(IPage page) =>
        page.Locator("id=fields.data.account.location.locationInput$city.value");

        public static ILocator ZipCode(IPage page) =>
        page.Locator("id=fields.data.account.location.locationInput$zipCode.value");

        public static ILocator ValidateAddress(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Validate Address", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator Item501750(IPage page) =>
        page.GetByText("501 - 750", new() { Exact = true });

}
