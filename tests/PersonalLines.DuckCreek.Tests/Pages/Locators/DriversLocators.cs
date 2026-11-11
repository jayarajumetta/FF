using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class DriversLocators
{
    private readonly IPage _page;
    public DriversLocators(IPage page) => _page = page;

    public ILocator CLOSEQUOTE => _page.GetByTestId("btnConfirmNo").GetByText(" Close Quote ");

    public ILocator InEligibleHeading => _page.GetByText("Ineligible Quote", new() { Exact = true });


    public ILocator Btn_Next => _page.GetByRole(AriaRole.Button, new() { Name = "Next", Exact = true });

    public ILocator DriverInformationNext => _page.Locator("[data-testid='pl-auto-driver-prefill-next-btn']");

    public ILocator CONTINUE => _page.Locator("[id=\"btnConfirmYes\"]");

    public ILocator CONTINUED555D => _page.Locator("[data-testid='btnConfirmYes']").Filter(new() { HasText = "Continue" });

    public ILocator DriverAssignmentTab => _page.Locator("[id='Driver_Assignment-nav']");

    public ILocator DriverAssignmentHeader => _page.Locator("h1").Filter(new() { HasText = "Driver Assignment" });

    public ILocator Driver1PrincipalOccasional => _page.Locator("[data-testid='fields.policy.lineDriverAssignments.driverAssignments.driverAssignment.rows[0].driverAssignmentInput$assignmentType.value-chip-label']").Filter(new() { HasText = "Principal" });

    public ILocator DriverAssignmentNextAsync => _page.GetByTestId("fields.policy.next-button-label");




    public ILocator Driver1Vehicle => _page.GetByTestId("fields.policy.lineDriverAssignments.driverAssignments.driverAssignment.rows[0].driverAssignmentInput$vehicle.value-chip-wrapper").First;

    public ILocator Driver1VehicleTesla3 => _page.Locator("[data-testid='fields.policy.lineDriverAssignments.driverAssignments.driverAssignment.rows[0].driverAssignmentInput$vehicle.value-chip-label']").Filter(new() { HasText = "2022 TESLA 3" });

    public ILocator SelectVehicleToAssignDriver => _page.GetByTestId("fields.policy.lineDriverAssignments.driverAssignments.driverAssignment.rows[0].driverAssignmentInput$vehicle.value-chip-wrapper").First;

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

    public ILocator MultipleDriverAssignmentNext => _page.Locator("[data-testid='fields.policy.next-button-label']").Filter(new() { HasText = "Next" });

}
