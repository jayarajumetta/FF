using Microsoft.Playwright;
using System.Text.RegularExpressions;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class ProposalLocators
{
    private readonly IPage _page;
    public ProposalLocators(IPage page) => _page = page;

    public ILocator AgentCode => _page.Locator("input[id='proposal.agentPC']");

    public ILocator CONFIRM => _page.GetByText("Proceed");

    public ILocator ClientExists => _page.GetByText(new Regex(@"Client Already Exists", RegexOptions.IgnoreCase));
    public ILocator PotentialInvalidAddress => _page.GetByText("Potential Invalid Address");


    public ILocator ConfirmBtn => _page.Locator("[id='btnConfirmYes']");

    public ILocator ConfirmSSN => _page.GetByText(new Regex(@"Confirm the Client's SSN#", RegexOptions.IgnoreCase));

    public ILocator SubmitAngular => _page.Locator("[id='btnConfirmYes']");


    public ILocator CREATENEWACCOUNT => _page.Locator("[id=\"btnConfirmNo\"]");

    public ILocator ClientAlreadyExists => _page.GetByText("Client Already Exists", new() { Exact = true });

    public ILocator CountyComboBox => _page.Locator("[name=\"County_ComboBox\"], [id=\"County_ComboBox\"]").First;


    public ILocator EffectiveDate => _page.Locator("input[id='proposal.effectiveDate']");

    public ILocator Motorcycle => _page.Locator("[data-testid='proposal.product-chip-item-wrapper'].chip-item-wrapper, [data-testid='proposal.product-chip-item-wrapper'] > .chip-wrapper").Filter(new() { HasText = "Motorcycle" }).First;

    public ILocator NewQuote => _page.GetByRole(AriaRole.Button, new() { Name = "New Quote", Exact = true });
    public ILocator NameAndQuote => _page.Locator(".mdc-tab.mdc-tab--active .mdc-tab__text-label > span, mat-tab-header [role='tab'][aria-selected='true'] .mdc-tab__text-label > span").First;


    public ILocator RecreationalVehicleChip =>
      _page.Locator("[data-testid='proposal.product-chip-item-wrapper'].chip-item-wrapper, [data-testid='proposal.product-chip-item-wrapper'] > .chip-wrapper").Filter(new() { HasText = "Recreational Vehicle" }).First;


    public ILocator PersonalAuto =>
      _page.Locator("[data-testid='proposal.product-chip-item-wrapper'].chip-item-wrapper, [data-testid='proposal.product-chip-item-wrapper'] > .chip-wrapper").Filter(new() { HasText = "Personal Auto" }).First;

    public ILocator QuoteNumber => _page.GetByText("Quote Number", new() { Exact = true });


    public ILocator SSN => _page.GetByText(new Regex(@"No SSN# Found|SSN.*could not be found", RegexOptions.IgnoreCase));

    public ILocator SsnInput => _page.Locator("[id='ssn']");

    public ILocator SameAsMailingAddress => _page.Locator("[id='proposal.riskAddressSelection-0-input']");

    public ILocator StartQuote => _page.Locator("[id='startQuote']");

    public ILocator State => _page.Locator("[id='proposal.ratingState']");

    public ILocator StateMONTANA => _page.GetByText("State == \"MONTANA", new() { Exact = true });



    public ILocator WritingCompany => _page.Locator("div[id='mat-select-value-4']");

}
