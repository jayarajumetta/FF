using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class DriversLocators
{
    private readonly IPage _page;
    public DriversLocators(IPage page) => _page = page;

    public ILocator CLOSEQUOTE => _page.GetByText("Ineligible Quote", new() { Exact = true });

    public ILocator CONTINUE => _page.Locator("[id=\"btnConfirmYes\"]");

    public ILocator Driver1PrincipalOccasional => _page.GetByTestId("fields.policy.lineDriverAssignments.driverAssignments.driverAssignment.rows[0].driverAssignmentInput$assignmentType.value-chip-wrapper");

    public ILocator Driver1Vehicle => _page.GetByTestId("fields.policy.lineDriverAssignments.driverAssignments.driverAssignment.rows[0].driverAssignmentInput$vehicle.value-chip-wrapper");

    public ILocator Driver2PrincipalOccasional => _page.GetByTestId("fields.policy.lineDriverAssignments.driverAssignments.driverAssignment.rows[1].driverAssignmentInput$assignmentType.value-chip-wrapper");

    public ILocator Driver2Vehicle => _page.GetByTestId("fields.policy.lineDriverAssignments.driverAssignments.driverAssignment.rows[1].driverAssignmentInput$vehicle.value-chip-wrapper");

    public ILocator Driver3PrincipalOccasional => _page.GetByTestId("fields.policy.lineDriverAssignments.driverAssignments.driverAssignment.rows[2].driverAssignmentInput$assignmentType.value-chip-wrapper");

    public ILocator Driver3Vehicle => _page.GetByTestId("fields.policy.lineDriverAssignments.driverAssignments.driverAssignment.rows[2].driverAssignmentInput$vehicle.value-chip-wrapper");

    public ILocator Driver4PrincipalOccasional => _page.GetByTestId("fields.policy.lineDriverAssignments.driverAssignments.driverAssignment.rows[3].driverAssignmentInput$assignmentType.value-chip-wrapper");

    public ILocator Driver4Vehicle => _page.GetByTestId("fields.policy.lineDriverAssignments.driverAssignments.driverAssignment.rows[3].driverAssignmentInput$vehicle.value-chip-wrapper");

    public ILocator Driver5PrincipalOccasional => _page.GetByTestId("fields.policy.lineDriverAssignments.driverAssignments.driverAssignment.rows[4].driverAssignmentInput$assignmentType.value-chip-wrapper");

    public ILocator Driver5Vehicle => _page.GetByTestId("fields.policy.lineDriverAssignments.driverAssignments.driverAssignment.rows[4].driverAssignmentInput$vehicle.value-chip-wrapper");


    public ILocator ExistingClient1 => _page.GetByTestId("_cifClientDriversChips-_cifClientDriversChips-driver0-chip-chip");


    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    public ILocator MultipleDriverAssignmentNext => _page.Locator("[id=\"fields.data.next\"]");

}
