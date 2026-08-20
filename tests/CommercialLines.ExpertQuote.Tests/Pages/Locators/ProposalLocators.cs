using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class ProposalLocators
{
    private readonly IPage _page;
    public ProposalLocators(IPage page) => _page = page;

    // Product Selection Chips
    public ILocator PersonalAutoChip => _page.Locator("[data-testid='proposal.product-chip-label']").Filter(new() { HasText = "Personal Auto" });
    public ILocator MotorcycleChip => _page.Locator("[data-testid='proposal.product-chip-label']").Filter(new() { HasText = "Motorcycle" });
    public ILocator RecreationalVehicleChip => _page.Locator("[data-testid='proposal.product-chip-label']").Filter(new() { HasText = "Recreational Vehicle" });
    public ILocator HomeChip => _page.Locator("[data-testid='proposal.product-chip-label']").Filter(new() { HasText = "Home" });
    public ILocator BusinessOwnersChip => _page.Locator("[data-testid='proposal.product-chip-label']").Filter(new() { HasText = "Business Owners" });
    public ILocator SpecialFarmPackageChip => _page.Locator("[data-testid='proposal.product-chip-label']").Filter(new() { HasText = "Special Farm Package" });

    // Business Entity Search Section
    public ILocator BusinessNameSearchField => _page.Locator("#business\\.search\\.businessName");
    public ILocator SearchButton => _page.Locator("#button-locked-proposal-start-business-search-btn");
    public ILocator IndividuallyOwnedDbaCheckbox => _page.Locator("[data-testid='business.isIndividualDba']").Locator("input[type='checkbox']");
    public ILocator IndividuallyOwnedDbaLabel => _page.GetByText("Individually Owned, DBA, or T/A");

    // DBA/T/A Name Field
    public ILocator DbaOrTaNameField => _page.Locator("#business\\.individualDba");

    // Form Fields - Quote Details Section
    public ILocator EffectiveDate => _page.Locator("#proposal\\.effectiveDate");
    public ILocator PolicyTermDropdown => _page.Locator("[data-testid='proposal.term']");
    public ILocator AgentPC => _page.Locator("#proposal\\.agentPC");
    public ILocator AssociatePC => _page.Locator("#proposal\\.associatePC");
    public ILocator RatingStateDropdown => _page.Locator("[data-testid='proposal.ratingState']");

    // Lessor's Risk Exposure Chips
    public ILocator LessorsRiskYesChip => _page.Locator("[data-testid='proposal.LessorsRiskExposure-chip-wrapper']").Filter(new() { HasText = "Yes" });
    public ILocator LessorsRiskNoChip => _page.Locator("[data-testid='proposal.LessorsRiskExposure-chip-wrapper']").Filter(new() { HasText = "No" });

    // Risk Address Selection Radio Buttons
    public ILocator AccountAddressRadio => _page.Locator("[data-testid='proposal.riskAddressSelection-0']");
    public ILocator NewAddressRadio => _page.Locator("[data-testid='proposal.riskAddressSelection-1']");

    // Action Buttons
    public ILocator StartQuoteButton => _page.Locator("#startQuote");

    // Additional Elements
    public ILocator ProposalDetailsHeader => _page.GetByRole(AriaRole.Heading, new() { Name = "Proposal Details", Exact = true });
    public ILocator InsuranceProductsHeader => _page.GetByRole(AriaRole.Heading, new() { Name = "Insurance Products", Exact = true });
    public ILocator QuoteDetailsHeader => _page.GetByRole(AriaRole.Heading, new() { Name = "Quote Details", Exact = true });

    /// <summary>
    /// Gets a dropdown option by text for any mat-select dropdown
    /// </summary>
    /// <param name="optionText">The option text (e.g., "6 Month", "12 Month", "ALABAMA")</param>
    public ILocator GetDropdownOption(string optionText) 
        => _page.GetByRole(AriaRole.Option, new() { Name = optionText, Exact = true });

    /// <summary>
    /// Selects Policy Term from dropdown
    /// </summary>
    /// <param name="termText">The term text (e.g., "6 Month", "12 Month")</param>
    public async Task SelectPolicyTermAsync(string termText)
    {
        await PolicyTermDropdown.ClickAsync();
        await GetDropdownOption(termText).ClickAsync();
    }

    /// <summary>
    /// Selects Rating State from dropdown
    /// </summary>
    /// <param name="stateText">The state text (e.g., "ALABAMA", "MISSOURI", "TEXAS")</param>
    public async Task SelectRatingStateAsync(string stateText)
    {
        await RatingStateDropdown.ClickAsync();
        await GetDropdownOption(stateText).ClickAsync();
    }

    /// <summary>
    /// Selects Lessor's Risk Exposure option (Yes or No)
    /// </summary>
    /// <param name="answer">The answer: "Yes" or "No"</param>
    public async Task SelectLessorsRiskExposureAsync(string answer)
    {
        var chipLocator = _page.Locator("[data-testid='proposal.LessorsRiskExposure-chip-wrapper']")
            .Filter(new() { HasText = answer });
        await chipLocator.ClickAsync();
    }

    /// <summary>
    /// Selects a product chip by product name
    /// </summary>
    /// <param name="productName">The product name (e.g., "Personal Auto", "Business Owners")</param>
    public async Task SelectProductChipAsync(string productName)
    {
        var chipLocator = _page.Locator("[data-testid='proposal.product-chip-label']").Filter(new() { HasText = productName });
        await chipLocator.ClickAsync();
    }

    // Backward compatibility aliases for existing Page methods
    public ILocator BusinessOwners => BusinessOwnersChip;
    public ILocator EffectiveDate6F16B => EffectiveDate;
    public ILocator EffectiveDate78F67 => EffectiveDate6F16B; // semantic alias; locator defined once
    public ILocator PolicyTerm => PolicyTermDropdown;
    public ILocator SpecialFarmPackage => SpecialFarmPackageChip;
    public ILocator StartQuote => StartQuoteButton;
    public ILocator State => RatingStateDropdown;
    public ILocator StateDropdown => State; // semantic alias; locator defined once
    public ILocator NewAccountAddress => AccountAddressRadio;
    public ILocator IndividualDBA => DbaOrTaNameField;
    public ILocator IndividuallyOwnedDBAOrTA => IndividuallyOwnedDbaCheckbox;
    public ILocator LessorsRiskNo => LessorsRiskNoChip;
    public ILocator SearchBusinessName => BusinessNameSearchField;

    // Legacy locators that may not be in current HTML but kept for compatibility
    public ILocator Individual => _page.GetByText("Individual", new() { Exact = true });
    public ILocator Missouri => _page.GetByText("Missouri", new() { Exact = true });
    public ILocator No => _page.GetByLabel("No", new() { Exact = true });
    public ILocator ProposalDetails => _page.GetByText("Proposal Details", new() { Exact = true });
    public ILocator SelectSFPCE => _page.GetByRole(AriaRole.Button, new() { Name = "Select -SFP CE", Exact = true });
    public ILocator True => _page.GetByText("True", new() { Exact = true });

}
