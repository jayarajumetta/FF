using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQNamedInsOperatorStatusLocators
{
    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator FirstNameDriver1(IPage page) =>
        page.Locator("id=\"fields.line.driver.rows[0].driverInput$firstName.value\"");

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator LastNameDriver1(IPage page) =>
        page.Locator("id=\"fields.line.driver.rows[0].driverInput$lastName.value\"");

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator DOBDriver1(IPage page) =>
        page.Locator("id=\"fields.line.driver.rows[0].driverInput$dateOfBirth.value\"");

        // REVIEW: source field not uniquely resolved.
    public static ILocator MoreOptionsRelationToAccountOwner(IPage page) =>
        page.GetByTestId("\"fields.line.driver.rows[0].driverInput$relationToAccountOwner.value-menu-trigger\"").Filter(new() { HasText = "MORE OPTIONS" });

        // REVIEW: source field not uniquely resolved.
    public static ILocator AccountOwner(IPage page) =>
        page.GetByTestId("\"fields.line.driver.rows[0].driverInput$relationToAccountOwner.value-chip-wrapper\"");

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator SSN(IPage page) =>
        page.Locator("id=\"fields.line.driver.rows[0].driverInput$sSN.value\"");

        // REVIEW: source field not uniquely resolved.
    public static ILocator MTNationalGuard(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Yes", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator Gender(IPage page) =>
        page.GetByText("Gender", new() { Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator Male(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Male", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator Female(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Female", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator Single(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Single", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator Married(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Married", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator Divorced(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Divorced", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator Spouse(IPage page) =>
        page.GetByTestId("\"fields.line.driver.rows[0].driverInput$relationToAccountOwner.value-chip-wrapper\"");

        // REVIEW: source field not uniquely resolved.
    public static ILocator AccountOwnerReadOnly(IPage page) =>
        page.GetByText("Account Owner", new() { Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator IsThisDriverANamedInsured(IPage page) =>
        page.GetByText("Is this driver a named insured?", new() { Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator PrimaryNamedInsured(IPage page) =>
        page.GetByTestId("\"fields.line.driver.rows[0].driverInput$namedInsuredType.value-chip-wrapper\"");

        // REVIEW: source field not uniquely resolved.
    public static ILocator NamedInsured(IPage page) =>
        page.GetByTestId("\"fields.line.driver.rows[0].driverInput$namedInsuredType.value-chip-wrapper\"");

        // REVIEW: source field not uniquely resolved.
    public static ILocator NotANamedInsured(IPage page) =>
        page.GetByTestId("\"fields.line.driver.rows[0].driverInput$namedInsuredType.value-chip-wrapper\"");

        // REVIEW: source field not uniquely resolved.
    public static ILocator Related(IPage page) =>
        page.GetByTestId("\"fields.line.driver.rows[0].driverInput$operatorStatus.value-chip-wrapper\"");

        // REVIEW: source field not uniquely resolved.
    public static ILocator Assigned(IPage page) =>
        page.GetByTestId("\"fields.line.driver.rows[0].driverInput$operatorStatus.value-chip-wrapper\"");

        // REVIEW: source field not uniquely resolved.
    public static ILocator NoCycleLicense(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "No Cycle License", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator MoreOptionsOperatorStatus(IPage page) =>
        page.GetByTestId("\"fields.line.driver.rows[0].driverInput$operatorStatus.value-menu-trigger\"").Filter(new() { HasText = "MORE OPTIONS" });

        // REVIEW: source field not uniquely resolved.
    public static ILocator Military(IPage page) =>
        page.GetByText("Military", new() { Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator Missionary(IPage page) =>
        page.GetByText("Missionary", new() { Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator NonDriver(IPage page) =>
        page.GetByTestId("\"fields.line.driver.rows[0].driverInput$operatorStatus.value-chip-wrapper\"");

        // REVIEW: source field not uniquely resolved.
    public static ILocator OtherInsurance(IPage page) =>
        page.GetByText("Other Insurance", new() { Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator NonDriverReason(IPage page) =>
        page.GetByText("Non-Driver Reason", new() { Exact = true });

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator CycleNonDriverComboBox(IPage page) =>
        page.Locator("id=\"fields.line.driver.rows[0].driverInput$nonDriverReason.value\"");

        // REVIEW: source field not uniquely resolved.
    public static ILocator Roommate(IPage page) =>
        page.GetByText("Roommate", new() { Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator NeverLicensed(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Never Licensed", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator Underage(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Underage", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator MedicalCondition(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Medical Condition", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator MoreOptionsNonDriver(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "More Options", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator Surrendered(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Surrendered", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator PermitDriver(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Permit Driver", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator NoPreviouslyInsured(IPage page) =>
        page.GetByTestId("\"fields.line.driver.rows[0].insuranceHistoryManualInput$wasThisClientIssuedWithAN.value-chip-wrapper\"");

}
