using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class DriversLocators
{
    private readonly IPage _page;
    public DriversLocators(IPage page) => _page = page;

    // Source modules: EQ||Driver Information | confidence=Medium score=113
    // v56 raw Tosca primary: EQ||Driver Information | Ineligible Quote | Id
    public ILocator CLOSEQUOTE => _page.Locator("[id=\"undefined\"]");

    // Source modules: (New) EQ || Multiple Driver Assignment | confidence=Medium score=113
    // v56 raw Tosca primary: EQ||Vehicle Summary Auto Additional | Continue | Id
    public ILocator CONTINUE => _page.Locator("[id=\"btnConfirmYes\"]");

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
    // v56 raw Tosca primary: EQ||Driver Information | Ineligible Quote | Id
    // v56 semantic alias: same physical raw-Tosca control as CLOSEQUOTE
    public ILocator DriverInformationNext => CLOSEQUOTE;

    // Source modules: EQ||Driver Information | confidence=High score=130
    public ILocator ExistingClient1 => _page.GetByTestId("_cifClientDriversChips-_cifClientDriversChips-driver0-chip-chip");

    // Source modules: EQ||Driver Information | confidence=High score=97
    // v56 raw Tosca primary: EQ||Driver Information | Ineligible Quote | Id
    // v56 semantic alias: same physical raw-Tosca control as CLOSEQUOTE
    public ILocator IneligibleQuote => CLOSEQUOTE;

    // Source modules: EQ |Common|Loading Indicator Wait | confidence=Medium score=78
    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    // Source modules: (New) EQ || Multiple Driver Assignment | confidence=Medium score=113
    // v56 raw Tosca primary: EQ||Discount(NEW) | Next | Id
    public ILocator MultipleDriverAssignmentNext => _page.Locator("[id=\"fields.data.next\"]");

}
