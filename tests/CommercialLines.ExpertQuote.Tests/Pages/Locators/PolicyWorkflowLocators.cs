using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class PolicyWorkflowLocators
{
    private readonly IPage _page;
    public PolicyWorkflowLocators(IPage page) => _page = page;

    public ILocator AddLiabilityYes => _page.GetByTestId("fields.policy.line.lineCoverages$isBaseLiability.value-chip-wrapper");

    public ILocator AddNarrative => _page.Locator("textarea[id=\"fields.data.notes.rows[0].notesInput$remarks.value\"][name=\"fields.data.notes.rows[0].notesInput$remarks.value\"]");

    public ILocator AlertErrorMessageBoxPolicyNumberExistsForThisQuoteNumbe => _page.GetByText(new System.Text.RegularExpressions.Regex("policy number exists for this quote", System.Text.RegularExpressions.RegexOptions.IgnoreCase)).First;

    public ILocator BODY4F40D => _page.GetByText("BODY", new() { Exact = true });


    public ILocator Button => _page.GetByText("Button", new() { Exact = true });

    public ILocator ClientInfoSearch => _page.Locator("input[id=\"customer.name.first\"][name=\"customer.name.first\"]");


    public ILocator DescriptionOfOperations => _page.Locator("input[id=\"fields.data.account.policyOutput$descriptionOfOperations.value\"][name=\"fields.data.account.policyOutput$descriptionOfOperations.value\"]");


    public ILocator EChecklistEChecklistOK => _page.Locator("[id=\"exception-note-confirm\"]");

    public ILocator EQCommonPrimaryInsuredRequired => _page.GetByText("EQ|Common|Primary Insured|Required", new() { Exact = true });

    public ILocator Edit => _page.GetByRole(AriaRole.Button, new() { Name = "edit", Exact = true });

    public ILocator ExistingClient => _page.GetByTestId("temp.clientSuggestions-cif-client-*-wrapper");

    public ILocator IFRAME => _page.GetByText("IFRAME", new() { Exact = true });

    public ILocator IFRAMEDuckCreekPolicyAlertErrorMessage => _page.GetByText("Alert Error Message", new() { Exact = true });

    public ILocator IndividualSoleProprietor => _page.GetByTestId("fields.data.account.accountInput$entityType.value-chip-wrapper");

    public ILocator InspectionContact => _page.Locator("input[id=\"fields.primaryInsured.accountInput$isInspectionContact.value-checkbox\"][name=\"fields.primaryInsured.accountInput$isInspectionContact.value\"]");

    public ILocator LiabilityLimit => _page.Locator("[id=\"fields.line.liability_D5.liabilityLimit_2.value\"]");

    public ILocator LivestockHorses => _page.Locator("input[id=\"fields.policy.line.liability.liabilityInput$livestockHorses.value\"][name=\"fields.policy.line.liability.liabilityInput$livestockHorses.value\"]");

    public ILocator LivestockLarge => _page.Locator("input[id=\"fields.policy.line.liability.liabilityInput$livestockLarge.value\"][name=\"fields.policy.line.liability.liabilityInput$livestockLarge.value\"]");

    public ILocator LivestockSmall => _page.Locator("input[id=\"fields.policy.line.liability.liabilityInput$livestockSmall.value\"][name=\"fields.policy.line.liability.liabilityInput$livestockSmall.value\"]");

    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    public ILocator LoadingMessage4DE37 => _page.Locator("[id=\"loadingMessage\"]");



    public ILocator LoggedInUser5A005 => _page.GetByText("Logged In User", new() { Exact = true });



    public ILocator Logout => _page.Locator("[id=\"id_LogOut\"]");






    public ILocator NextBOP => _page.GetByTestId("cl-bop-primary-insured-selection-next-btn");

    public ILocator NextSFP => _page.GetByTestId("next-button");

    public ILocator NoneOfTheAboveCheckbox => _page.GetByTestId("fields.underwritingQuestionsGeneralUWQuestions.generalInformationNewInput$noneOfTheAboveGeneralUWQuestions.value");

    public ILocator NumberOfFulltimeEmployees => _page.Locator("input[id=\"fields.data.account.lineInputNonShredded$numberOfEmployees.value\"][name=\"fields.data.account.lineInputNonShredded$numberOfEmployees.value\"]");

    public ILocator NumberOfPartTimeEmployees => _page.Locator("input[id=\"fields.data.account.lineInputNonShredded$numberOfPartTimeEmployees.value\"][name=\"fields.data.account.lineInputNonShredded$numberOfPartTimeEmployees.value\"]");

    public ILocator NumberOfSeasonalEmployees => _page.Locator("input[id=\"fields.data.account.lineInputNonShredded$numberOfSeasonalEmployees.value\"][name=\"fields.data.account.lineInputNonShredded$numberOfSeasonalEmployees.value\"]");

    public ILocator OkToUpdateFromChecklist => _page.GetByRole(AriaRole.Button, new() { Name = "Ok To Update from Checklist", Exact = true });

    public ILocator QuickSearchButton => _page.Locator("[id=\"id_quickSearch\"]");

    public ILocator QuoteSearchInput => _page.Locator("input[id=\"quoteSearchInput\"][name=\"quoteSearchInput\"]");

    public ILocator ResponseRequiredToContinue => _page.Locator("[id=\"fields.data.underwritingQuestions.preQualification.preQualificationInput$eqNoneOfTheAbove.value-checkbox\"]");

    public ILocator ResultsTABLE => _page.GetByText("Results TABLE", new() { Exact = true });

    public ILocator ResultsTABLERowCellExplicitNameName => _page.GetByText("(ExplicitName=Name)", new() { Exact = true });

    public ILocator ReturnToAdmin => _page.GetByText("Return To Admin", new() { Exact = true });

    public ILocator Save => _page.Locator("button[id=\"fields.data.save\"], button[id=\"fields.data.saveLocation\"], button[data-testid=\"fields.line.save\"], button:has-text(\"Save\"), a:has-text(\"Save\")").First;

    public ILocator SaveForLater => _page.GetByText("Save for Later", new() { Exact = true });

    public ILocator SaveForLaterOK => _page.GetByText("Save for Later - OK", new() { Exact = true });

    public ILocator ScreenHeading69631 => _page.GetByText("Screen Heading", new() { Exact = true });



    public ILocator SearchButton => _page.Locator("button:has-text(\"Search\"), a:has-text(\"Search\")").First;

    public ILocator SearchMethodEGDescriptionPolicy => _page.Locator("[id=\"_keynameAdvSearch1-inputEl\"]");

    public ILocator SearchText => _page.Locator("[id='quickSearchTextId-inputEl']");

    public ILocator TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus01C36B => _page.GetByText("The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0", new() { Exact = true });



    public ILocator TransactionType => _page.GetByRole(AriaRole.Textbox, new() { Name = "Transaction Type", Exact = true }).First;


    public ILocator UnlistedAcreage => _page.Locator("input[id=\"fields.policy.line.liability.lineInput$unlistedAcreage.value\"][name=\"fields.policy.line.liability.lineInput$unlistedAcreage.value\"]");

    public ILocator UserDateAndTimestamp => _page.GetByText("User Date and Timestamp", new() { Exact = true });

    public ILocator UserNameE0ACD => _page.Locator("input[id=\"username\"][name=\"pf.username\"]");


    public ILocator ViewPolicy0AC0B => _page.Locator("[id=\"returnToActiveSessionA\"]");


}
