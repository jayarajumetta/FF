using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class DriversLocators
{
    private readonly IPage _page;
    public DriversLocators(IPage page) => _page = page;

    // Source modules: EQ||Driver Information | confidence=Medium score=113
    public ILocator CLOSEQUOTE => _page.GetByRole(AriaRole.Link, new() { Name = "CLOSE QUOTE", Exact = true });

    // Source modules: (New) EQ || Multiple Driver Assignment | confidence=Medium score=113
    public ILocator CONTINUE => _page.GetByRole(AriaRole.Link, new() { Name = "CONTINUE", Exact = true });

    // Source modules: (New) EQ || Multiple Driver Assignment | confidence=High score=130
    public ILocator Driver1PrincipalOccasional => _page.GetByTestId("fields.policy.lineDriverAssignments.driverAssignments.driverAssignment.rows[0].driverAssignmentInput$assignmentType.value-chip-wrapper");

    // Source modules: (New) EQ || Multiple Driver Assignment | confidence=High score=130
    public ILocator Driver1Vehicle => _page.GetByTestId("fields.policy.lineDriverAssignments.driverAssignments.driverAssignment.rows[0].driverAssignmentInput$vehicle.value-chip-wrapper");

    // Source modules: (New) EQ || Multiple Driver Assignment | confidence=High score=100
    public ILocator Driver2PrincipalOccasional => _page.GetByTestId("fields.policy.lineDriverAssignments.driverAssignments.driverAssignment.rows[1].driverAssignmentInput$assignmentType.value-chip-wrapper");

    // Source modules: (New) EQ || Multiple Driver Assignment | confidence=High score=100
    public ILocator Driver2Vehicle => _page.GetByTestId("fields.policy.lineDriverAssignments.driverAssignments.driverAssignment.rows[1].driverAssignmentInput$vehicle.value-chip-wrapper");

    // Source modules: (New) EQ || Multiple Driver Assignment | confidence=High score=100
    public ILocator Driver3PrincipalOccasional => _page.GetByTestId("fields.policy.lineDriverAssignments.driverAssignments.driverAssignment.rows[2].driverAssignmentInput$assignmentType.value-chip-wrapper");

    // Source modules: (New) EQ || Multiple Driver Assignment | confidence=High score=100
    public ILocator Driver3Vehicle => _page.GetByTestId("fields.policy.lineDriverAssignments.driverAssignments.driverAssignment.rows[2].driverAssignmentInput$vehicle.value-chip-wrapper");

    // Source modules: (New) EQ || Multiple Driver Assignment | confidence=High score=100
    public ILocator Driver4PrincipalOccasional => _page.GetByTestId("fields.policy.lineDriverAssignments.driverAssignments.driverAssignment.rows[3].driverAssignmentInput$assignmentType.value-chip-wrapper");

    // Source modules: (New) EQ || Multiple Driver Assignment | confidence=High score=100
    public ILocator Driver4Vehicle => _page.GetByTestId("fields.policy.lineDriverAssignments.driverAssignments.driverAssignment.rows[3].driverAssignmentInput$vehicle.value-chip-wrapper");

    // Source modules: (New) EQ || Multiple Driver Assignment | confidence=High score=100
    public ILocator Driver5PrincipalOccasional => _page.GetByTestId("fields.policy.lineDriverAssignments.driverAssignments.driverAssignment.rows[4].driverAssignmentInput$assignmentType.value-chip-wrapper");

    // Source modules: (New) EQ || Multiple Driver Assignment | confidence=High score=100
    public ILocator Driver5Vehicle => _page.GetByTestId("fields.policy.lineDriverAssignments.driverAssignments.driverAssignment.rows[4].driverAssignmentInput$vehicle.value-chip-wrapper");

    // Source modules: EQ||Driver Information | confidence=Medium score=113
    public ILocator DriverInformationNext => _page.GetByRole(AriaRole.Button, new() { Name = "Btn_Next", Exact = true });

    // Source modules: EQ||Driver Information | confidence=High score=130
    public ILocator ExistingClient1 => _page.GetByTestId("_cifClientDriversChips-_cifClientDriversChips-driver0-chip-chip");

    // Source modules: EQ||Driver Information | confidence=High score=97
    public ILocator IneligibleQuote => _page.GetByLabel("Ineligible Quote", new() { Exact = true });

    // Source modules: EQ |Common|Loading Indicator Wait | confidence=Medium score=78
    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    // Source modules: (New) EQ || Multiple Driver Assignment | confidence=Medium score=113
    public ILocator MultipleDriverAssignmentNext => _page.GetByRole(AriaRole.Button, new() { Name = "Next", Exact = true });

}