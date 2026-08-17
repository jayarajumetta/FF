using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.CLDC.Pages.Locators;

namespace InsuranceAutomation.CLDC.Pages;

public sealed class CoveragesPage
{
    private readonly BrowserSession _browser;
    private readonly CoveragesLocators _locators;
    private readonly UiActions _ui;

    public CoveragesPage(BrowserSession browser, UiActions ui)
    {
        _browser = browser;
        _locators = new CoveragesLocators(browser.Page);
        _ui = ui;
    }

    public Task ClickAddCoverageFormAsync() =>
        _ui.ClickAsync(_locators.AddCoverageForm, new ControlIntent("Coverages", "AddCoverageForm"));

    public Task ClickAddEndorsementAsync() =>
        _ui.ClickAsync(_locators.AddEndorsement, new ControlIntent("Coverages", "AddEndorsement"));

    public Task EnterAwayFromPremisesDescAsync(string value) =>
        _ui.FillAsync(_locators.AwayFromPremisesDesc, value, new ControlIntent("Coverages", "AwayFromPremisesDesc"));

    public Task PressAwayFromPremisesDescAsync(string key) =>
        _ui.PressAsync(_locators.AwayFromPremisesDesc, key, new ControlIntent("Coverages", "AwayFromPremisesDesc"));

    public Task EnterAwayFromPremisesLmtAsync(string value) =>
        _ui.FillAsync(_locators.AwayFromPremisesLmt, value, new ControlIntent("Coverages", "AwayFromPremisesLmt"));

    public Task PressAwayFromPremisesLmtAsync(string key) =>
        _ui.PressAsync(_locators.AwayFromPremisesLmt, key, new ControlIntent("Coverages", "AwayFromPremisesLmt"));

    public Task ClickCG3132LimitedFungiOrBacteriaCoverageOKAsync() =>
        _ui.ClickAsync(_locators.CG3132LimitedFungiOrBacteriaCoverageOK, new ControlIntent("Coverages", "CG3132LimitedFungiOrBacteriaCoverageOK"));

    public Task ClickCPAsync() =>
        _ui.ClickAsync(_locators.CP, new ControlIntent("Coverages", "CP"));

    public Task EnterCoinsuranceAsync(string value) =>
        _ui.FillAsync(_locators.Coinsurance, value, new ControlIntent("Coverages", "Coinsurance"));

    public Task PressCoinsuranceAsync(string key) =>
        _ui.PressAsync(_locators.Coinsurance, key, new ControlIntent("Coverages", "Coinsurance"));

    public Task EnterCoverageFormToBeAddedAsync(string value) =>
        _ui.FillAsync(_locators.CoverageFormToBeAdded, value, new ControlIntent("Coverages", "CoverageFormToBeAdded"));

    public Task PressCoverageFormToBeAddedAsync(string key) =>
        _ui.PressAsync(_locators.CoverageFormToBeAdded, key, new ControlIntent("Coverages", "CoverageFormToBeAdded"));

    public Task EnterDescriptionAsync(string value) =>
        _ui.FillAsync(_locators.Description, value, new ControlIntent("Coverages", "Description"));

    public Task PressDescriptionAsync(string key) =>
        _ui.PressAsync(_locators.Description, key, new ControlIntent("Coverages", "Description"));

    public Task WaitForDescriptionOfSpecifiedOperationAsync(string expected) =>
        _ui.WaitAsync(_locators.DescriptionOfSpecifiedOperation, expected, new ControlIntent("Coverages", "DescriptionOfSpecifiedOperation"));

    public Task VerifyDescriptionOfSpecifiedOperationAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.DescriptionOfSpecifiedOperation, expected, property, new ControlIntent("Coverages", "DescriptionOfSpecifiedOperation"));

    public Task EnterDescriptionOfSpecifiedOperationAsync(string value) =>
        _ui.FillAsync(_locators.DescriptionOfSpecifiedOperation, value, new ControlIntent("Coverages", "DescriptionOfSpecifiedOperation"));

    public Task PressDescriptionOfSpecifiedOperationAsync(string key) =>
        _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, key, new ControlIntent("Coverages", "DescriptionOfSpecifiedOperation"));

    public Task ClickDetailAsync() =>
        _ui.ClickAsync(_locators.Detail, new ControlIntent("Coverages", "Detail"));

    public Task EnterEndorsementTypeAsync(string value) =>
        _ui.FillAsync(_locators.EndorsementType, value, new ControlIntent("Coverages", "EndorsementType"));

    public Task PressEndorsementTypeAsync(string key) =>
        _ui.PressAsync(_locators.EndorsementType, key, new ControlIntent("Coverages", "EndorsementType"));

    public Task ClickEndorsements7572EAsync() =>
        _ui.ClickAsync(_locators.Endorsements7572E, new ControlIntent("Coverages", "Endorsements7572E"));

    public Task WaitForEndorsements9626EAsync(string expected) =>
        _ui.WaitAsync(_locators.Endorsements9626E, expected, new ControlIntent("Coverages", "Endorsements9626E"));

    public Task EnterEstimatedPremiumAsync(string value) =>
        _ui.FillAsync(_locators.EstimatedPremium, value, new ControlIntent("Coverages", "EstimatedPremium"));

    public Task ClickFG0055FG0062FG0063FG0069FG0071FG0072FG0074FG0077FG0078EmploymentPracticesLiabilityInsuranceCoverageEndorsementOKAsync() =>
        _ui.ClickAsync(_locators.FG0055FG0062FG0063FG0069FG0071FG0072FG0074FG0077FG0078EmploymentPracticesLiabilityInsuranceCoverageEndorsementOK, new ControlIntent("Coverages", "FG0055FG0062FG0063FG0069FG0071FG0072FG0074FG0077FG0078EmploymentPracticesLiabilityInsuranceCoverageEndorsementOK"));

    public Task VerifyFG0055TableRowEmploymentPracticesLiabilityInsuranceCoverageEndorsementAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.FG0055TableRowEmploymentPracticesLiabilityInsuranceCoverageEndorsement, expected, property, new ControlIntent("Coverages", "FG0055TableRowEmploymentPracticesLiabilityInsuranceCoverageEndorsement"));

    public Task WaitForFG0055TableRowFG0055Async(string expected) =>
        _ui.WaitAsync(_locators.FG0055TableRowFG0055, expected, new ControlIntent("Coverages", "FG0055TableRowFG0055"));

    public Task EnterFungusAsync(string value) =>
        _ui.FillAsync(_locators.Fungus, value, new ControlIntent("Coverages", "Fungus"));

    public Task PressFungusAsync(string key) =>
        _ui.PressAsync(_locators.Fungus, key, new ControlIntent("Coverages", "Fungus"));

    public Task ClickGLAsync() =>
        _ui.ClickAsync(_locators.GL, new ControlIntent("Coverages", "GL"));

    public Task EnterHasTheInsuredEverHadAClaimForEmploymentPracticesAsync(string value) =>
        _ui.FillAsync(_locators.HasTheInsuredEverHadAClaimForEmploymentPractices, value, new ControlIntent("Coverages", "HasTheInsuredEverHadAClaimForEmploymentPractices"));

    public Task PressHasTheInsuredEverHadAClaimForEmploymentPracticesAsync(string key) =>
        _ui.PressAsync(_locators.HasTheInsuredEverHadAClaimForEmploymentPractices, key, new ControlIntent("Coverages", "HasTheInsuredEverHadAClaimForEmploymentPractices"));

    public Task ClickIMAsync() =>
        _ui.ClickAsync(_locators.IM, new ControlIntent("Coverages", "IM"));

    public Task EnterLimitDeductibleAsync(string value) =>
        _ui.FillAsync(_locators.LimitDeductible, value, new ControlIntent("Coverages", "LimitDeductible"));

    public Task PressLimitDeductibleAsync(string key) =>
        _ui.PressAsync(_locators.LimitDeductible, key, new ControlIntent("Coverages", "LimitDeductible"));

    public Task EnterPolicyCoverageAsync(string value) =>
        _ui.FillAsync(_locators.PolicyCoverage, value, new ControlIntent("Coverages", "PolicyCoverage"));

    public Task PressPolicyCoverageAsync(string key) =>
        _ui.PressAsync(_locators.PolicyCoverage, key, new ControlIntent("Coverages", "PolicyCoverage"));

    public Task ClickPolicyCovgAccountsReceivableOKAsync() =>
        _ui.ClickAsync(_locators.PolicyCovgAccountsReceivableOK, new ControlIntent("Coverages", "PolicyCovgAccountsReceivableOK"));

    public Task ClickPolicyCovgED95CAsync() =>
        _ui.ClickAsync(_locators.PolicyCovgED95C, new ControlIntent("Coverages", "PolicyCovgED95C"));

    public Task WaitForPolicyCovgF9E58Async(string expected) =>
        _ui.WaitAsync(_locators.PolicyCovgF9E58, expected, new ControlIntent("Coverages", "PolicyCovgF9E58"));

    public Task WaitForPolicyInfoHeaderAsync(string expected) =>
        _ui.WaitAsync(_locators.PolicyInfoHeader, expected, new ControlIntent("Coverages", "PolicyInfoHeader"));

    public Task EnterPropertyExtensionEndorsementsAsync(string value) =>
        _ui.FillAsync(_locators.PropertyExtensionEndorsements, value, new ControlIntent("Coverages", "PropertyExtensionEndorsements"));

    public Task PressPropertyExtensionEndorsementsAsync(string key) =>
        _ui.PressAsync(_locators.PropertyExtensionEndorsements, key, new ControlIntent("Coverages", "PropertyExtensionEndorsements"));

    public Task EnterTheInsuredAndAnyExecutiveOfficerOrOwnerHasKnowledgeOrInformationOfAnyActErrorOrOmissionWhichMightGiveRiseToAnEPLClaimSuitOrComplaintAsync(string value) =>
        _ui.FillAsync(_locators.TheInsuredAndAnyExecutiveOfficerOrOwnerHasKnowledgeOrInformationOfAnyActErrorOrOmissionWhichMightGiveRiseToAnEPLClaimSuitOrComplaint, value, new ControlIntent("Coverages", "TheInsuredAndAnyExecutiveOfficerOrOwnerHasKnowledgeOrInformationOfAnyActErrorOrOmissionWhichMightGiveRiseToAnEPLClaimSuitOrComplaint"));

    public Task PressTheInsuredAndAnyExecutiveOfficerOrOwnerHasKnowledgeOrInformationOfAnyActErrorOrOmissionWhichMightGiveRiseToAnEPLClaimSuitOrComplaintAsync(string key) =>
        _ui.PressAsync(_locators.TheInsuredAndAnyExecutiveOfficerOrOwnerHasKnowledgeOrInformationOfAnyActErrorOrOmissionWhichMightGiveRiseToAnEPLClaimSuitOrComplaint, key, new ControlIntent("Coverages", "TheInsuredAndAnyExecutiveOfficerOrOwnerHasKnowledgeOrInformationOfAnyActErrorOrOmissionWhichMightGiveRiseToAnEPLClaimSuitOrComplaint"));

    public Task EnterThirdPartyAsync(string value) =>
        _ui.FillAsync(_locators.ThirdParty, value, new ControlIntent("Coverages", "ThirdParty"));

    public Task PressThirdPartyAsync(string key) =>
        _ui.PressAsync(_locators.ThirdParty, key, new ControlIntent("Coverages", "ThirdParty"));

    public Task EnterUtilityServicesAsync(string value) =>
        _ui.FillAsync(_locators.UtilityServices, value, new ControlIntent("Coverages", "UtilityServices"));

    public Task PressUtilityServicesAsync(string key) =>
        _ui.PressAsync(_locators.UtilityServices, key, new ControlIntent("Coverages", "UtilityServices"));

}
