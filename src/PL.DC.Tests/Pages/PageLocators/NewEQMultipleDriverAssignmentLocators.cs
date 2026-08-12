using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class NewEQMultipleDriverAssignmentLocators
{
        // REVIEW: source field not uniquely resolved.
    public static ILocator CONTINUE(IPage page) =>
        page.GetByRole(AriaRole.Link, new() { Name = "CONTINUE", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator Driver1Vehicle(IPage page) =>
        page.GetByTestId("\"fields.policy.lineDriverAssignments.driverAssignments.driverAssignment.rows[0].driverAssignmentInput$vehicle.value-chip-wrapper\"");

        // REVIEW: source field not uniquely resolved.
    public static ILocator Driver1PrincipalOccasional(IPage page) =>
        page.GetByTestId("\"fields.policy.lineDriverAssignments.driverAssignments.driverAssignment.rows[0].driverAssignmentInput$assignmentType.value-chip-wrapper\"");

        // REVIEW: source field not uniquely resolved.
    public static ILocator Driver2Vehicle(IPage page) =>
        page.GetByTestId("\"fields.policy.lineDriverAssignments.driverAssignments.driverAssignment.rows[1].driverAssignmentInput$vehicle.value-chip-wrapper\"");

        // REVIEW: source field not uniquely resolved.
    public static ILocator Driver2PrincipalOccasional(IPage page) =>
        page.GetByTestId("\"fields.policy.lineDriverAssignments.driverAssignments.driverAssignment.rows[1].driverAssignmentInput$assignmentType.value-chip-wrapper\"");

        // REVIEW: source field not uniquely resolved.
    public static ILocator Driver3Vehicle(IPage page) =>
        page.GetByTestId("\"fields.policy.lineDriverAssignments.driverAssignments.driverAssignment.rows[2].driverAssignmentInput$vehicle.value-chip-wrapper\"");

        // REVIEW: source field not uniquely resolved.
    public static ILocator Driver3PrincipalOccasional(IPage page) =>
        page.GetByTestId("\"fields.policy.lineDriverAssignments.driverAssignments.driverAssignment.rows[2].driverAssignmentInput$assignmentType.value-chip-wrapper\"");

        // REVIEW: source field not uniquely resolved.
    public static ILocator Driver4Vehicle(IPage page) =>
        page.GetByTestId("\"fields.policy.lineDriverAssignments.driverAssignments.driverAssignment.rows[3].driverAssignmentInput$vehicle.value-chip-wrapper\"");

        // REVIEW: source field not uniquely resolved.
    public static ILocator Driver4PrincipalOccasional(IPage page) =>
        page.GetByTestId("\"fields.policy.lineDriverAssignments.driverAssignments.driverAssignment.rows[3].driverAssignmentInput$assignmentType.value-chip-wrapper\"");

        // REVIEW: source field not uniquely resolved.
    public static ILocator Driver5Vehicle(IPage page) =>
        page.GetByTestId("\"fields.policy.lineDriverAssignments.driverAssignments.driverAssignment.rows[4].driverAssignmentInput$vehicle.value-chip-wrapper\"");

        // REVIEW: source field not uniquely resolved.
    public static ILocator Driver5PrincipalOccasional(IPage page) =>
        page.GetByTestId("\"fields.policy.lineDriverAssignments.driverAssignments.driverAssignment.rows[4].driverAssignmentInput$assignmentType.value-chip-wrapper\"");

        // REVIEW: source field not uniquely resolved.
    public static ILocator Next(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Next", Exact = true });

}
