using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class PolicyWorkflowLocators
{
    private readonly IPage _page;
    public PolicyWorkflowLocators(IPage page) => _page = page;

    // Source modules: EQ|SFP|Div V Liability | confidence=High score=130
    public ILocator AddLiabilityYes => _page.GetByTestId("fields.policy.line.lineCoverages$isBaseLiability.value-chip-wrapper");

    // Source modules: EQ|Common|Narrative | confidence=Medium score=113
    // v56 raw Tosca primary: EQ|Common|Narrative | Description of the business exposures, activities and experience | Id+Name
    public ILocator AddNarrative => _page.Locator("textarea[id=\"\\\"fields.data.notes.rows[0].notesInput$remarks.value\\\"\"][name=\"\\\"fields.data.notes.rows[0].notesInput$remarks.value\\\"\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // v56 raw Tosca primary:  | Quote | DuckCreekId | frame=iframe
    public ILocator AlertErrorMessageBoxPolicyNumberExistsForThisQuoteNumbe => _page.FrameLocator("iframe").Locator("[duckcreekid=\"Quote\"], [data-duckcreekid=\"Quote\"]");

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator BODY4F40D => _page.GetByText("BODY", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator BODYABC33 => BODY4F40D; // semantic alias; locator defined once

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator Button => _page.GetByText("Button", new() { Exact = true });

    // Source modules: EQ|Common|Client Info | confidence=Medium score=113
    // v56 raw Tosca primary: EQ|Common|Client Info | customer.name.first | Id+Name
    public ILocator ClientInfoSearch => _page.Locator("input[id=\"customer.name.first\"][name=\"customer.name.first\"]");

    // Source modules: EQ|Common|Quote Identifying | confidence=Medium score=108
    // v56 raw Tosca primary:  | Quote | DuckCreekId | frame=iframe
    // v56 semantic alias: same physical raw-Tosca control as AlertErrorMessageBoxPolicyNumberExistsForThisQuoteNumbe
    public ILocator CloseQuote => AlertErrorMessageBoxPolicyNumberExistsForThisQuoteNumbe;

    // Source modules: Synthetic | confidence=Review score=40
    // v56 raw Tosca primary: EQ|Common|Primary Insured|General Info | Description Of Operations | Id+Name
    public ILocator DescriptionOfOperations => _page.Locator("input[id=\"fields.data.account.policyOutput$descriptionOfOperations.value\"][name=\"fields.data.account.policyOutput$descriptionOfOperations.value\"]");

    // Source modules: EQ|Common|Narrative | confidence=High score=127
    // v56 raw Tosca primary: EQ|Common|Narrative | Description of the business exposures, activities and experience | Id+Name
    // v56 semantic alias: same physical raw-Tosca control as AddNarrative
    public ILocator DescriptionOfTheBusinessExposuresActivitiesAndExperience => AddNarrative;

    // Source modules: EQ|Common|eChecklist - eChecklist | confidence=High score=127
    // v56 raw Tosca primary: EQ|Common|eChecklist - eChecklist | OK | Id
    public ILocator EChecklistEChecklistOK => _page.Locator("[id=\"exception-note-confirm\"]");

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator EQCommonPrimaryInsuredRequired => _page.GetByText("EQ|Common|Primary Insured|Required", new() { Exact = true });

    // Source modules:  | confidence=Medium score=83
    public ILocator Edit => _page.GetByRole(AriaRole.Button, new() { Name = "edit", Exact = true });

    // Source modules: EQ|Common|Primary Insured|Required | confidence=High score=130
    public ILocator ExistingClient => _page.GetByTestId("temp.clientSuggestions-cif-client-*-wrapper");

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator IFRAME => _page.GetByText("IFRAME", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator IFRAMEDuckCreekPolicyAlertErrorMessage => _page.GetByText("Alert Error Message", new() { Exact = true });

    // Source modules: EQ|Common|Primary Insured|Required | confidence=High score=130
    public ILocator IndividualSoleProprietor => _page.GetByTestId("fields.data.account.accountInput$entityType.value-chip-wrapper");

    // Source modules: EQ|BOP|Client Details|Edit Client Roles | confidence=High score=127
    // v56 raw Tosca primary: EQ|BOP|Client Details|Edit Client Roles | Inspection Contact | Id+Name
    public ILocator InspectionContact => _page.Locator("input[id=\"fields.primaryInsured.accountInput$isInspectionContact.value-checkbox\"][name=\"fields.primaryInsured.accountInput$isInspectionContact.value\"]");

    // Source modules: EQ|SFP|CE|Coverages | confidence=High score=127
    // v56 raw Tosca primary: EQ|SFP|CE|Coverages | Liability Limit | Id
    public ILocator LiabilityLimit => _page.Locator("[id=\"fields.line.liability_D5.liabilityLimit_2.value\"]");

    // Source modules: EQ|SFP|Div V Liability | confidence=High score=127
    // v56 raw Tosca primary: EQ|SFP|Div V Liability | livestockHorses | Id+Name
    public ILocator LivestockHorses => _page.Locator("input[id=\"fields.policy.line.liability.liabilityInput$livestockHorses.value\"][name=\"fields.policy.line.liability.liabilityInput$livestockHorses.value\"]");

    // Source modules: EQ|SFP|Div V Liability | confidence=High score=127
    // v56 raw Tosca primary: EQ|SFP|Div V Liability | livestockLarge | Id+Name
    public ILocator LivestockLarge => _page.Locator("input[id=\"fields.policy.line.liability.liabilityInput$livestockLarge.value\"][name=\"fields.policy.line.liability.liabilityInput$livestockLarge.value\"]");

    // Source modules: EQ|SFP|Div V Liability | confidence=High score=127
    // v56 raw Tosca primary: EQ|SFP|Div V Liability | livestockSmall | Id+Name
    public ILocator LivestockSmall => _page.Locator("input[id=\"fields.policy.line.liability.liabilityInput$livestockSmall.value\"][name=\"fields.policy.line.liability.liabilityInput$livestockSmall.value\"]");

    // Source modules: EQ |Common|Loading Indicator Wait | confidence=Medium score=78
    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // v56 raw Tosca primary: Indicators and Errors | Loading Message | Id
    public ILocator LoadingMessage4DE37 => _page.Locator("[id=\"loadingMessage\"]");

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator LoadingMessageC7A0D => LoadingMessage4DE37; // semantic alias; locator defined once

    // Source modules: EQ|Common|Narrative | confidence=Medium score=78
    // v56 raw Tosca primary: EQ|Common|Narrative | Description of the business exposures, activities and experience | Id+Name
    // v56 semantic alias: same physical raw-Tosca control as AddNarrative
    public ILocator LockedThisQuoteHasBeenSubmittedAndYouCanNoLongerMakeChangesToThisText => AddNarrative;

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator LoggedInUser5A005 => _page.GetByText("Logged In User", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator LoggedInUser6AD12 => LoggedInUser5A005; // semantic alias; locator defined once

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator LoggedInUser8A0DD => LoggedInUser5A005; // semantic alias; locator defined once

    // Source modules: EQ|Common|Logout of EQ | confidence=Medium score=83
    // v56 raw Tosca primary:  | Logout | Id
    public ILocator Logout => _page.Locator("[id=\"id_LogOut\"]");

    // Source modules: EQ|Common|Logout of EQ | confidence=Medium score=83
    // v56 raw Tosca primary:  | Logout | Id
    // v56 semantic alias: same physical raw-Tosca control as Logout
    public ILocator LogoutLogOut => Logout;

    // Source modules: EQ|Common|Quote Identifying | confidence=Review score=97
    // v56 raw Tosca primary:  | Quote | DuckCreekId | frame=iframe
    // v56 semantic alias: same physical raw-Tosca control as AlertErrorMessageBoxPolicyNumberExistsForThisQuoteNumbe
    public ILocator NameAndQuote => AlertErrorMessageBoxPolicyNumberExistsForThisQuoteNumbe;

    // Source modules: Synthetic | confidence=Review score=40
    // v56 raw Tosca primary:  | Quote | DuckCreekId | frame=iframe
    // v56 semantic alias: same physical raw-Tosca control as AlertErrorMessageBoxPolicyNumberExistsForThisQuoteNumbe
    public ILocator NameAndQuoteNum8EB77 => AlertErrorMessageBoxPolicyNumberExistsForThisQuoteNumbe;

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator NameAndQuoteNumCA893 => NameAndQuoteNum8EB77; // semantic alias; locator defined once

    // Source modules: EQ|Common|Narrative | confidence=Medium score=78
    // v56 raw Tosca primary: EQ|Common|Narrative | Description of the business exposures, activities and experience | Id+Name
    // v56 semantic alias: same physical raw-Tosca control as AddNarrative
    public ILocator NarrativeScreenHeading => AddNarrative;

    // Source modules: EQ|Common|Primary Insured|Required | confidence=High score=130
    public ILocator NextBOP => _page.GetByTestId("cl-bop-primary-insured-selection-next-btn");

    // Source modules: EQ|Common|Primary Insured|Required | confidence=High score=130
    public ILocator NextSFP => _page.GetByTestId("next-button");

    // Source modules: EQ|BOP|Primary Insured Details| General UW Questions | confidence=High score=130
    public ILocator NoneOfTheAboveCheckbox => _page.GetByTestId("fields.underwritingQuestionsGeneralUWQuestions.generalInformationNewInput$noneOfTheAboveGeneralUWQuestions.value");

    // Source modules: Synthetic | confidence=Review score=40
    // v56 raw Tosca primary: EQ|Common|Primary Insured|General Info | Number Of Fulltime Employees | Id+Name
    public ILocator NumberOfFulltimeEmployees => _page.Locator("input[id=\"fields.data.account.lineInputNonShredded$numberOfEmployees.value\"][name=\"fields.data.account.lineInputNonShredded$numberOfEmployees.value\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // v56 raw Tosca primary: EQ|Common|Primary Insured|General Info | Number Of PartTime Employees | Id+Name
    public ILocator NumberOfPartTimeEmployees => _page.Locator("input[id=\"fields.data.account.lineInputNonShredded$numberOfPartTimeEmployees.value\"][name=\"fields.data.account.lineInputNonShredded$numberOfPartTimeEmployees.value\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // v56 raw Tosca primary: EQ|Common|Primary Insured|General Info | Number Of Seasonal Employees | Id+Name
    public ILocator NumberOfSeasonalEmployees => _page.Locator("input[id=\"fields.data.account.lineInputNonShredded$numberOfSeasonalEmployees.value\"][name=\"fields.data.account.lineInputNonShredded$numberOfSeasonalEmployees.value\"]");

    // Source modules: EQ|Common|Esignature|Click OK | confidence=Medium score=113
    public ILocator OkToUpdateFromChecklist => _page.GetByRole(AriaRole.Button, new() { Name = "Ok To Update from Checklist", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // v56 raw Tosca primary: Dashboard|QuickSearch | QuickSearch Button | Id
    public ILocator QuickSearchButton => _page.Locator("[id=\"id_quickSearch\"]");

    // Source modules: EQ|Common|Search by QuoteNum | confidence=High score=127
    // v56 raw Tosca primary: EQ|Common|Search by QuoteNum | quoteSearchInput | Id+Name
    public ILocator QuoteSearchInput => _page.Locator("input[id=\"quoteSearchInput\"][name=\"quoteSearchInput\"]");

    // Source modules: EQ|Common|PreQualification|General Eligibility Restrictions | confidence=Medium score=78
    // v56 raw Tosca primary: EQ|Common|PreQualification|General Eligibility Restrictions | Unchecked - None Of The Above | Id
    public ILocator ResponseRequiredToContinue => _page.Locator("[id=\"fields.data.underwritingQuestions.preQualification.preQualificationInput$eqNoneOfTheAbove.value-checkbox\"]");

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator ResultsTABLE => _page.GetByText("Results TABLE", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator ResultsTABLERowCellExplicitNameName => _page.GetByText("(ExplicitName=Name)", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator ReturnToAdmin => _page.GetByText("Return To Admin", new() { Exact = true });

    // Source modules: EQ|SFP|DIV V|Optional Liability Coverage|Workers' Compensation - Residence EmployeesExpertQuote | confidence=High score=130
    // v56 raw Tosca primary:  | Save | DuckCreekId | frame=iframe
    public ILocator Save => _page.FrameLocator("iframe").Locator("[duckcreekid=\"Save\"], [data-duckcreekid=\"Save\"]");

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator SaveForLater => _page.GetByText("Save for Later", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator SaveForLaterOK => _page.GetByText("Save for Later - OK", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator ScreenHeading69631 => _page.GetByText("Screen Heading", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator ScreenHeading9696C => ScreenHeading69631; // semantic alias; locator defined once

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator ScreenHeadingDCABF => ScreenHeading69631; // semantic alias; locator defined once

    // Source modules: EQ|Common|Search for Policy | confidence=Medium score=113
    // v56 raw Tosca primary: Dashboard|Search for Policies / Quotes | Search Button | DuckCreekId
    public ILocator SearchButton => _page.Locator("[duckcreekid=\"Search\"], [data-duckcreekid=\"Search\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // v56 raw Tosca primary: Dashboard|Search for Policies / Quotes | Search Method (e.g. Description/Policy#) | Id
    public ILocator SearchMethodEGDescriptionPolicy => _page.Locator("[id=\"_keynameAdvSearch1-inputEl\"]");

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator SearchText => _page.Locator("[id='quickSearchTextId-inputEl']");

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus01C36B => _page.GetByText("The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus06F740 => TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus01C36B; // semantic alias; locator defined once

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus0B8256 => TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus01C36B; // semantic alias; locator defined once

    // Source modules: Synthetic | confidence=Review score=40
    // v56 raw Tosca primary: TransACT | Transaction Type | Id+Name+DuckCreekId
    public ILocator TransactionType => _page.Locator("input[id=\"f_tB2C8F4EC9E3041B7B52430914E990D15D2_2_1-inputEl\"][name=\"f_tB2C8F4EC9E3041B7B52430914E990D15D2_2_1-inputEl\"][duckcreekid=\"TransACTInput.TransactionTypeList\"]");

    // Source modules: EQ|Common|PreQualification|General Eligibility Restrictions | confidence=High score=97
    // v56 raw Tosca primary: EQ|Common|PreQualification|General Eligibility Restrictions | Unchecked - None Of The Above | Id
    // v56 semantic alias: same physical raw-Tosca control as ResponseRequiredToContinue
    public ILocator UncheckedNoneOfTheAbove => ResponseRequiredToContinue;

    // Source modules: EQ|SFP|Div V Liability | confidence=High score=127
    // v56 raw Tosca primary: EQ|SFP|Div V Liability | unlistedAcreage | Id+Name
    public ILocator UnlistedAcreage => _page.Locator("input[id=\"fields.policy.line.liability.lineInput$unlistedAcreage.value\"][name=\"fields.policy.line.liability.lineInput$unlistedAcreage.value\"]");

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator UserDateAndTimestamp => _page.GetByText("User Date and Timestamp", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // v56 raw Tosca primary: Login | Username | Id+Name
    public ILocator UserNameE0ACD => _page.Locator("input[id=\"username\"][name=\"pf.username\"]");

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator UserNameE65A8 => UserNameE0ACD; // semantic alias; locator defined once

    // Source modules: Synthetic | confidence=Review score=40
    // v56 raw Tosca primary: TransACT | View Policy  (*) | Id
    public ILocator ViewPolicy0AC0B => _page.Locator("[id=\"returnToActiveSessionA\"]");

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator ViewPolicy56E09 => ViewPolicy0AC0B; // semantic alias; locator defined once

}
