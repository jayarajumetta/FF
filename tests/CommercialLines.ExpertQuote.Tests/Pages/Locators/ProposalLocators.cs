using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class ProposalLocators
{
    private readonly IPage _page;
    public ProposalLocators(IPage page) => _page = page;

    // Source: EQ|Common|Proposal Start.
    public ILocator ProposalDetailsHeader => _page.GetByRole(AriaRole.Heading, new() { Name = "Proposal Details", Exact = true });
    public ILocator ProposalDetails => ProposalDetailsHeader;

    // Product ModuleAttribute is a DIV with data-testid=proposal.product-chip-item-wrapper.
    public ILocator BusinessOwnersChip =>
        _page.Locator("[data-testid='proposal.product-chip-item-wrapper']").Filter(new() { HasText = "Business Owners" });
    public ILocator SpecialFarmPackageChip =>
        _page.Locator("[data-testid='proposal.product-chip-item-wrapper']").Filter(new() { HasText = "Special Farm Package" });
    public ILocator PersonalAutoChip =>
        _page.Locator("[data-testid='proposal.product-chip-item-wrapper']").Filter(new() { HasText = "Personal Auto" });
    public ILocator MotorcycleChip =>
        _page.Locator("[data-testid='proposal.product-chip-item-wrapper']").Filter(new() { HasText = "Motorcycle" });
    public ILocator RecreationalVehicleChip =>
        _page.Locator("[data-testid='proposal.product-chip-item-wrapper']").Filter(new() { HasText = "Recreational Vehicle" });
    public ILocator HomeChip =>
        _page.Locator("[data-testid='proposal.product-chip-item-wrapper']").Filter(new() { HasText = "Home" });

    public ILocator BusinessNameSearchField => _page.Locator("[id='business.search.businessName']");
    public ILocator IndividuallyOwnedDbaCheckbox => _page.Locator("[id='business.isIndividualDba-checkbox']");
    public ILocator DbaOrTaNameField => _page.Locator("[id='business.individualDba']");
    public ILocator EffectiveDate => _page.Locator("[id='proposal.effectiveDate']");

    // Source is INPUT with mat-autocomplete behavior.
    public ILocator AgentPC => _page.Locator("[id='proposal.agentPC']");

    // Source is MAT-SELECT. UiActions.SelectAsync performs trigger click + option click.
    public ILocator RatingStateDropdown => _page.Locator("[id='proposal.ratingState']");

    // Source is a clickable DIV chip wrapper, not <select>.
    public ILocator LessorsRiskNoChip =>
        _page.Locator("[data-testid='proposal.LessorsRiskExposure-chip-wrapper']").Filter(new() { HasText = "No" });

    // Source ModuleAttribute: input radio Id=proposal.riskAddressSelection-0-input.
    public ILocator AccountAddressRadio => _page.Locator("[id='proposal.riskAddressSelection-0-input']");
    public ILocator NewAddressRadio => _page.Locator("[id='proposal.riskAddressSelection-1-input']");

    public ILocator StartQuoteButton => _page.Locator("[id='startQuote']");

    // Other supported proposal controls retained for shared flows.
    public ILocator PolicyTermDropdown => _page.Locator("[data-testid='proposal.term']");
    public ILocator AssociatePC => _page.Locator("[id='proposal.associatePC']");
    public ILocator InsuranceProductsHeader => _page.GetByRole(AriaRole.Heading, new() { Name = "Insurance Products", Exact = true });
    public ILocator QuoteDetailsHeader => _page.GetByRole(AriaRole.Heading, new() { Name = "Quote Details", Exact = true });

    public ILocator GetDropdownOption(string optionText) =>
        _page.GetByRole(AriaRole.Option, new() { Name = optionText, Exact = true });

    // Compatibility aliases. No duplicate locator definitions.
    public ILocator BusinessOwners => BusinessOwnersChip;
    public ILocator EffectiveDate6F16B => EffectiveDate;
    public ILocator EffectiveDate78F67 => EffectiveDate;
    public ILocator PolicyTerm => PolicyTermDropdown;
    public ILocator SpecialFarmPackage => SpecialFarmPackageChip;
    public ILocator StartQuote => StartQuoteButton;
    public ILocator State => RatingStateDropdown;
    public ILocator StateDropdown => RatingStateDropdown;
    public ILocator NewAccountAddress => AccountAddressRadio;
    public ILocator IndividualDBA => DbaOrTaNameField;
    public ILocator IndividuallyOwnedDBAOrTA => IndividuallyOwnedDbaCheckbox;
    public ILocator LessorsRiskNo => LessorsRiskNoChip;
    public ILocator SearchBusinessName => BusinessNameSearchField;

    // These source values are orchestration parameters, not editable UI controls.
    // Kept only for legacy method compatibility and should not be used with FillAsync.
    public ILocator Individual => _page.GetByText("Individual", new() { Exact = true });
    public ILocator Missouri => _page.GetByText("Missouri", new() { Exact = true });
    public ILocator No => LessorsRiskNoChip;
    public ILocator SelectSFPCE => _page.GetByRole(AriaRole.Button, new() { Name = "Select -SFP CE", Exact = true });
    public ILocator True => AccountAddressRadio;
}
