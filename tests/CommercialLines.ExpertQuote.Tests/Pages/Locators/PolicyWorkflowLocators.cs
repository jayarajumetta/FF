using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class PolicyWorkflowLocators
{
    private readonly IPage _page;
    public PolicyWorkflowLocators(IPage page) => _page = page;

    // Source modules: EQ|SFP|Div V Liability | confidence=High score=130
    public ILocator AddLiabilityYes => _page.GetByTestId("fields.policy.line.lineCoverages$isBaseLiability.value-chip-wrapper");

    // Source modules: EQ|Common|Narrative | confidence=Medium score=113
    public ILocator AddNarrative => _page.GetByRole(AriaRole.Button, new() { Name = "Add Narrative", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator AlertErrorMessageBoxPolicyNumberExistsForThisQuoteNumbe => _page.GetByText("Alert Error Message Box: policy number exists for this quote numbe", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator BODY4F40D => _page.GetByText("BODY", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator BODYABC33 => BODY4F40D; // semantic alias; locator defined once

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator Button => _page.GetByText("Button", new() { Exact = true });

    // Source modules: EQ|Common|Client Info | confidence=Medium score=113
    public ILocator ClientInfoSearch => _page.GetByRole(AriaRole.Button, new() { Name = "Search", Exact = true });

    // Source modules: EQ|Common|Quote Identifying | confidence=Medium score=108
    public ILocator CloseQuote => _page.GetByLabel("Close Quote", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator DescriptionOfOperations => _page.GetByText("Description Of Operations", new() { Exact = true });

    // Source modules: EQ|Common|Narrative | confidence=High score=127
    public ILocator DescriptionOfTheBusinessExposuresActivitiesAndExperience => _page.GetByRole(AriaRole.Textbox, new() { Name = "Description of the business exposures, activities and experience", Exact = true });

    // Source modules: EQ|Common|eChecklist - eChecklist | confidence=High score=127
    public ILocator EChecklistEChecklistOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator EQCommonPrimaryInsuredRequired => _page.GetByText("EQ|Common|Primary Insured|Required", new() { Exact = true });

    // Source modules:  | confidence=Medium score=83
    public ILocator Edit => _page.GetByRole(AriaRole.Button, new() { Name = "edit", Exact = true });

    // Source modules: EQ|Common|Primary Insured|Required | confidence=High score=130
    public ILocator ExistingClient => _page.GetByTestId("temp.clientSuggestions-cif-client-*-wrapper");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator IFRAME => _page.GetByText("IFRAME", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator IFRAMEDuckCreekPolicyAlertErrorMessage => _page.GetByText("Alert Error Message", new() { Exact = true });

    // Source modules: EQ|Common|Primary Insured|Required | confidence=High score=130
    public ILocator IndividualSoleProprietor => _page.GetByTestId("fields.data.account.accountInput$entityType.value-chip-wrapper");

    // Source modules: EQ|BOP|Client Details|Edit Client Roles | confidence=High score=127
    public ILocator InspectionContact => _page.GetByRole(AriaRole.Checkbox, new() { Name = "Inspection Contact", Exact = true });

    // Source modules: EQ|SFP|CE|Coverages | confidence=High score=127
    public ILocator LiabilityLimit => _page.GetByRole(AriaRole.Combobox, new() { Name = "Liability Limit", Exact = true });

    // Source modules: EQ|SFP|Div V Liability | confidence=High score=127
    public ILocator LivestockHorses => _page.GetByRole(AriaRole.Textbox, new() { Name = "livestockHorses", Exact = true });

    // Source modules: EQ|SFP|Div V Liability | confidence=High score=127
    public ILocator LivestockLarge => _page.GetByRole(AriaRole.Textbox, new() { Name = "livestockLarge", Exact = true });

    // Source modules: EQ|SFP|Div V Liability | confidence=High score=127
    public ILocator LivestockSmall => _page.GetByRole(AriaRole.Textbox, new() { Name = "livestockSmall", Exact = true });

    // Source modules: EQ |Common|Loading Indicator Wait | confidence=Medium score=78
    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator LoadingMessage4DE37 => _page.GetByText("Loading Message", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator LoadingMessageC7A0D => LoadingMessage4DE37; // semantic alias; locator defined once

    // Source modules: EQ|Common|Narrative | confidence=Medium score=78
    public ILocator LockedThisQuoteHasBeenSubmittedAndYouCanNoLongerMakeChangesToThisText => _page.GetByLabel("Locked This quote has been submitted and you can no longer make changes to this text.", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator LoggedInUser5A005 => _page.GetByText("Logged In User", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator LoggedInUser6AD12 => LoggedInUser5A005; // semantic alias; locator defined once

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator LoggedInUser8A0DD => LoggedInUser5A005; // semantic alias; locator defined once

    // Source modules: EQ|Common|Logout of EQ | confidence=Medium score=83
    public ILocator Logout => _page.GetByRole(AriaRole.Button, new() { Name = "logout", Exact = true });

    // Source modules: EQ|Common|Logout of EQ | confidence=Medium score=83
    public ILocator LogoutLogOut => _page.GetByRole(AriaRole.Button, new() { Name = "logout Log Out", Exact = true });

    // Source modules: EQ|Common|Quote Identifying | confidence=Review score=97
    public ILocator NameAndQuote => _page.GetByLabel("Name and Quote", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator NameAndQuoteNum8EB77 => _page.GetByText("Name and Quote Num", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator NameAndQuoteNumCA893 => NameAndQuoteNum8EB77; // semantic alias; locator defined once

    // Source modules: EQ|Common|Narrative | confidence=Medium score=78
    public ILocator NarrativeScreenHeading => _page.GetByLabel("Narrative Screen Heading", new() { Exact = true });

    // Source modules: EQ|Common|Primary Insured|Required | confidence=High score=130
    public ILocator NextBOP => _page.GetByTestId("cl-bop-primary-insured-selection-next-btn");

    // Source modules: EQ|Common|Primary Insured|Required | confidence=High score=130
    public ILocator NextSFP => _page.GetByTestId("next-button");

    // Source modules: EQ|BOP|Primary Insured Details| General UW Questions | confidence=High score=130
    public ILocator NoneOfTheAboveCheckbox => _page.GetByTestId("fields.underwritingQuestionsGeneralUWQuestions.generalInformationNewInput$noneOfTheAboveGeneralUWQuestions.value");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator NumberOfFulltimeEmployees => _page.GetByText("Number Of Fulltime Employees", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator NumberOfPartTimeEmployees => _page.GetByText("Number Of PartTime Employees", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator NumberOfSeasonalEmployees => _page.GetByText("Number Of Seasonal Employees", new() { Exact = true });

    // Source modules: EQ|Common|Esignature|Click OK | confidence=Medium score=113
    public ILocator OkToUpdateFromChecklist => _page.GetByRole(AriaRole.Button, new() { Name = "Ok To Update from Checklist", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator QuickSearchButton => _page.GetByText("QuickSearch Button", new() { Exact = true });

    // Source modules: EQ|Common|Search by QuoteNum | confidence=High score=127
    public ILocator QuoteSearchInput => _page.GetByRole(AriaRole.Textbox, new() { Name = "quoteSearchInput", Exact = true });

    // Source modules: EQ|Common|PreQualification|General Eligibility Restrictions | confidence=Medium score=78
    public ILocator ResponseRequiredToContinue => _page.GetByLabel("Response required to continue", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator ResultsTABLE => _page.GetByText("Results TABLE", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator ResultsTABLERowCellExplicitNameName => _page.GetByText("(ExplicitName=Name)", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator ReturnToAdmin => _page.GetByText("Return To Admin", new() { Exact = true });

    // Source modules: EQ|SFP|DIV V|Optional Liability Coverage|Workers' Compensation - Residence EmployeesExpertQuote | confidence=High score=130
    public ILocator Save => _page.GetByTestId("fields.line.save");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator SaveForLater => _page.GetByText("Save for Later", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator SaveForLaterOK => _page.GetByText("Save for Later - OK", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator ScreenHeading69631 => _page.GetByText("Screen Heading", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator ScreenHeading9696C => ScreenHeading69631; // semantic alias; locator defined once

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator ScreenHeadingDCABF => ScreenHeading69631; // semantic alias; locator defined once

    // Source modules: EQ|Common|Search for Policy | confidence=Medium score=113
    public ILocator SearchButton => _page.GetByRole(AriaRole.Button, new() { Name = "Search Button", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator SearchMethodEGDescriptionPolicy => _page.GetByText("Search Method (e.g. Description/Policy#)", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator SearchText => _page.Locator("[id='quickSearchTextId-inputEl']");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus01C36B => _page.GetByText("The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus06F740 => TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus01C36B; // semantic alias; locator defined once

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus0B8256 => TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus01C36B; // semantic alias; locator defined once

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator TransactionType => _page.GetByText("Transaction Type", new() { Exact = true });

    // Source modules: EQ|Common|PreQualification|General Eligibility Restrictions | confidence=High score=97
    public ILocator UncheckedNoneOfTheAbove => _page.GetByRole(AriaRole.Checkbox, new() { Name = "Unchecked - None Of The Above", Exact = true });

    // Source modules: EQ|SFP|Div V Liability | confidence=High score=127
    public ILocator UnlistedAcreage => _page.GetByRole(AriaRole.Textbox, new() { Name = "unlistedAcreage", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator UserDateAndTimestamp => _page.GetByText("User Date and Timestamp", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator UserNameE0ACD => _page.GetByText("UserName", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator UserNameE65A8 => UserNameE0ACD; // semantic alias; locator defined once

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator ViewPolicy0AC0B => _page.GetByText("View Policy", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator ViewPolicy56E09 => ViewPolicy0AC0B; // semantic alias; locator defined once

}
