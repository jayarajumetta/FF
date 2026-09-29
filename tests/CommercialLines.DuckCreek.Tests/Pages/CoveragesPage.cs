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

    public Task WaitForAddCoverageFormAsync(string expected) =>
        _ui.WaitAsync(_locators.AddCoverageForm, expected, new ControlIntent("Coverages", "AddCoverageForm"));

    public Task ClickAddEndorsementAsync() =>
        _ui.ClickAsync(_locators.AddEndorsement, new ControlIntent("Coverages", "AddEndorsement"));

    public Task WaitForAwayFromPremisesDescAsync(string expected) =>
        _ui.WaitAsync(_locators.AwayFromPremisesDesc, expected, new ControlIntent("Coverages", "AwayFromPremisesDesc"));

    public Task EnterAwayFromPremisesDescAsync(string value) =>
        _ui.FillAsync(_locators.AwayFromPremisesDesc, value, new ControlIntent("Coverages", "AwayFromPremisesDesc"));

    public Task EnterAwayFromPremisesDescSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.AwayFromPremisesDesc, value, new ControlIntent("Coverages", "AwayFromPremisesDesc"), delayMs);

    public Task PressAwayFromPremisesDescAsync(string key) =>
        _ui.PressAsync(_locators.AwayFromPremisesDesc, key, new ControlIntent("Coverages", "AwayFromPremisesDesc"));

    public Task WaitForAwayFromPremisesLmtAsync(string expected) =>
        _ui.WaitAsync(_locators.AwayFromPremisesLmt, expected, new ControlIntent("Coverages", "AwayFromPremisesLmt"));

    public Task EnterAwayFromPremisesLmtAsync(string value) =>
        _ui.FillAsync(_locators.AwayFromPremisesLmt, value, new ControlIntent("Coverages", "AwayFromPremisesLmt"));

    public Task EnterAwayFromPremisesLmtSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.AwayFromPremisesLmt, value, new ControlIntent("Coverages", "AwayFromPremisesLmt"), delayMs);

    public Task PressAwayFromPremisesLmtAsync(string key) =>
        _ui.PressAsync(_locators.AwayFromPremisesLmt, key, new ControlIntent("Coverages", "AwayFromPremisesLmt"));

    public Task ClickPolicyCovgAccountsReceivableOKAsync() =>
        _ui.ClickAsync(_locators.PolicyCovgAccountsReceivableOK, new ControlIntent("Coverages", "PolicyCovgAccountsReceivableOK"));

    public Task WaitForPolicyCovgAccountsReceivableOKAsync(string expected) =>
        _ui.WaitAsync(_locators.PolicyCovgAccountsReceivableOK, expected, new ControlIntent("Coverages", "PolicyCovgAccountsReceivableOK"));

    public Task ClickCPAsync() =>
        _ui.ClickAsync(_locators.CP, new ControlIntent("Coverages", "CP"));

    public Task WaitForCoinsuranceAsync(string expected) =>
        _ui.WaitAsync(_locators.Coinsurance, expected, new ControlIntent("Coverages", "Coinsurance"));

    public Task EnterCoinsuranceAsync(string value) =>
        _ui.FillAsync(_locators.Coinsurance, value, new ControlIntent("Coverages", "Coinsurance"));

    public Task PressCoinsuranceAsync(string key) =>
        _ui.PressAsync(_locators.Coinsurance, key, new ControlIntent("Coverages", "Coinsurance"));

    public Task WaitForCoverageFormToBeAddedAsync(string expected) =>
        _ui.WaitAsync(_locators.CoverageFormToBeAdded, expected, new ControlIntent("Coverages", "CoverageFormToBeAdded"));

    public Task EnterCoverageFormToBeAddedAsync(string value) =>
        _ui.FillAsync(_locators.CoverageFormToBeAdded, value, new ControlIntent("Coverages", "CoverageFormToBeAdded"));

    public Task PressCoverageFormToBeAddedAsync(string key) =>
        _ui.PressAsync(_locators.CoverageFormToBeAdded, key, new ControlIntent("Coverages", "CoverageFormToBeAdded"));

    public async Task EnterCoverageFormToBeAddedWithRetryAsync(string value, int maxAttempts = 3, int waitBeforeMs = 1000, int delayMs = 20)
    {
        for (var attempt = 1; attempt <= maxAttempts; attempt++)
        {
            await Task.Delay(waitBeforeMs);
            if (await _ui.ExistsAsync(_locators.CoverageFormToBeAdded))
            {
                await _ui.PressSequentiallyAsync(_locators.CoverageFormToBeAdded, value, new ControlIntent("Coverages", "CoverageFormToBeAdded"), delayMs);
                return;
            }
        }
        await _ui.PressSequentiallyAsync(_locators.CoverageFormToBeAdded, value, new ControlIntent("Coverages", "CoverageFormToBeAdded"), delayMs);
    }

    public Task WaitForDescriptionAsync(string expected) =>
        _ui.WaitAsync(_locators.Description, expected, new ControlIntent("Coverages", "Description"));

    public Task EnterDescriptionAsync(string value) =>
        _ui.FillAsync(_locators.Description, value, new ControlIntent("Coverages", "Description"));

    public Task<string> CaptureDescriptionAsync(string property = "") =>
        _ui.CaptureAsync(_locators.Description, property, new ControlIntent("Coverages", "Description"));

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

    public Task Click0078DetailAsync() =>
      _ui.ClickAsync(_locators.FG0078Detail, new ControlIntent("Coverages", "FG0078Detail"));






    public Task Click0062DetailAsync() =>
     _ui.ClickAsync(_locators.FG0062, new ControlIntent("Coverages", "FG0078Detail"));

    public Task Click0069DetailAsync() =>
     _ui.ClickAsync(_locators.FG0069, new ControlIntent("Coverages", "FG0069Detail"));

    public Task Click0072DetailAsync() =>
     _ui.ClickAsync(_locators.FG0072, new ControlIntent("Coverages", "FG0072Detail"));

    public Task Click0063DetailAsync() =>
     _ui.ClickAsync(_locators.FG0063, new ControlIntent("Coverages", "FG0063Detail"));

    public Task Click0074DetailAsync() =>
     _ui.ClickAsync(_locators.FG0074, new ControlIntent("Coverages", "FG0074Detail"));

    public Task Click0077DetailAsync() =>
     _ui.ClickAsync(_locators.FG0077, new ControlIntent("Coverages", "FG0077Detail"));

    public Task Click0071DetailAsync() =>
     _ui.ClickAsync(_locators.FG0071, new ControlIntent("Coverages", "FG0071Detail"));

    public Task ClickFG0055DetailAsync() =>
        _ui.ClickAsync(_locators.FG0055Detail, new ControlIntent("Coverages", "FG0055Detail"));

    public Task EnterEndorsementTypeAsync(string value) =>
        _ui.FillAsync(_locators.EndorsementType, value, new ControlIntent("Coverages", "EndorsementType"));

    public Task PressEndorsementTypeAsync(string key) =>
        _ui.PressAsync(_locators.EndorsementType, key, new ControlIntent("Coverages", "EndorsementType"));

    public Task ClickGLNavigationLinksEndorsementsAsync() =>
        _ui.ClickAsync(_locators.GLNavigationLinksEndorsements, new ControlIntent("Coverages", "GLNavigationLinksEndorsements"));

    public Task WaitForEndorsementsAsync(string expected) =>
        _ui.WaitAsync(_locators.PageTitle, expected, new ControlIntent("Coverages", "Endorsements"));

    public Task EnterEstimatedPremiumAsync(string value) =>
        _ui.FillAsync(_locators.EstimatedPremium, value, new ControlIntent("Coverages", "EstimatedPremium"));

    public Task VerifyFG0055TableRowEmploymentPracticesLiabilityInsuranceCoverageEndorsementAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.FG0055TableRowEmploymentPracticesLiabilityInsuranceCoverageEndorsement, expected, property, new ControlIntent("Coverages", "FG0055TableRowEmploymentPracticesLiabilityInsuranceCoverageEndorsement"));

    public Task<bool> IsCG2151TableRowAmendmentOfLiquorLiabilityExclusionVisibleAsync() =>
        _ui.ExistsAsync(_locators.CG2151TableRowAmendmentOfLiquorLiabilityExclusion);

    public Task ClickCG2151DetailAsync() =>
        _ui.ClickAsync(_locators.CG2151Detail, new ControlIntent("Coverages", "CG2151Detail"));

    public Task EnterCovEndorsementsDescriptionAsync(string value) =>
        _ui.FillAsync(_locators.CovEndorsementsDescription, value, new ControlIntent("Coverages", "CovEndorsementsDescription"));

    public Task<bool> IsFG0059TableRowEmploymentPracticesLiabilityInsuranceCoverageEndorsementNYVisibleAsync() =>
        _ui.ExistsAsync(_locators.FG0059TableRowEmploymentPracticesLiabilityInsuranceCoverageEndorsementNY);

    public Task ClickFG0059DetailAsync() =>
        _ui.ClickAsync(_locators.FG0059Detail, new ControlIntent("Coverages", "FG0059Detail"));

    public Task<bool> IsFG0063TableRowEmploymentPracticesLiabilityInsuranceCoverageEndorsementMDVisibleAsync() =>
        _ui.ExistsAsync(_locators.FG0063TableRowEmploymentPracticesLiabilityInsuranceCoverageEndorsementMD);

    public Task ClickFG0063DetailAsync() =>
        _ui.ClickAsync(_locators.FG0063Detail, new ControlIntent("Coverages", "FG0063Detail"));

    public Task<bool> IsFG0062TableRowEmploymentPracticesLiabilityInsuranceCoverageEndorsementPAVisibleAsync() =>
        _ui.ExistsAsync(_locators.FG0062TableRowEmploymentPracticesLiabilityInsuranceCoverageEndorsementPA);

    public Task ClickFG0062DetailAsync() =>
        _ui.ClickAsync(_locators.FG0062Detail, new ControlIntent("Coverages", "FG0062Detail"));

    public Task<bool> IsFG0069TableRowEmploymentPracticesLiabilityInsuranceCoverageEndorsementORVisibleAsync() =>
        _ui.ExistsAsync(_locators.FG0069TableRowEmploymentPracticesLiabilityInsuranceCoverageEndorsementOR);

    public Task ClickFG0069DetailAsync() =>
        _ui.ClickAsync(_locators.FG0069Detail, new ControlIntent("Coverages", "FG0069Detail"));

    public Task<bool> IsFG0071TableRowEmploymentPracticesLiabilityInsuranceCoverageEndorsementNHVisibleAsync() =>
        _ui.ExistsAsync(_locators.FG0071TableRowEmploymentPracticesLiabilityInsuranceCoverageEndorsementNH);

    public Task ClickFG0071DetailAsync() =>
        _ui.ClickAsync(_locators.FG0071Detail, new ControlIntent("Coverages", "FG0071Detail"));

    public Task<bool> IsFG0072TableRowEmploymentPracticesLiabilityInsuranceCoverageEndorsementMEVisibleAsync() =>
        _ui.ExistsAsync(_locators.FG0072TableRowEmploymentPracticesLiabilityInsuranceCoverageEndorsementME);

    public Task ClickFG0072DetailAsync() =>
        _ui.ClickAsync(_locators.FG0072Detail, new ControlIntent("Coverages", "FG0072Detail"));

    public Task<bool> IsFG0074TableRowEmploymentPracticesLiabilityInsuranceCoverageEndorsementCTVisibleAsync() =>
        _ui.ExistsAsync(_locators.FG0074TableRowEmploymentPracticesLiabilityInsuranceCoverageEndorsementCT);

    public Task ClickFG0074DetailAsync() =>
        _ui.ClickAsync(_locators.FG0074Detail, new ControlIntent("Coverages", "FG0074Detail"));

    public Task<bool> IsFG0077TableRowEmploymentPracticesLiabilityInsuranceCoverageEndorsementVAVisibleAsync() =>
        _ui.ExistsAsync(_locators.FG0077TableRowEmploymentPracticesLiabilityInsuranceCoverageEndorsementVA);

    public Task ClickFG0077DetailAsync() =>
        _ui.ClickAsync(_locators.FG0077Detail, new ControlIntent("Coverages", "FG0077Detail"));

    public Task<bool> IsFG0078TableRowEmploymentPracticesLiabilityInsuranceCoverageEndorsementVTVisibleAsync() =>
        _ui.ExistsAsync(_locators.FG0078TableRowEmploymentPracticesLiabilityInsuranceCoverageEndorsementVT);

    public Task ClickFG0078DetailAsync() =>
        _ui.ClickAsync(_locators.FG0078Detail, new ControlIntent("Coverages", "FG0078Detail"));

    public Task VerifyFG0078TableRowEndorsementAsync(string expected, string property) =>
      _ui.VerifyAsync(_locators.FG0078Detail, expected, property, new ControlIntent("Coverages", "FG0078TableRowEndorsement"));


    public Task VerifyFG0062TableRowEndorsementAsync(string expected, string property) =>
    _ui.VerifyAsync(_locators.FG0062, expected, property, new ControlIntent("Coverages", "FG0078TableRowEndorsement"));

    public Task VerifyFG0069TableRowEndorsementAsync(string expected, string property) =>
    _ui.VerifyAsync(_locators.FG0069, expected, property, new ControlIntent("Coverages", "FG0069TableRowEndorsement"));

    public Task VerifyFG0072TableRowEndorsementAsync(string expected, string property) =>
    _ui.VerifyAsync(_locators.FG0072, expected, property, new ControlIntent("Coverages", "FG0072TableRowEndorsement"));

    public Task VerifyFG0063TableRowEndorsementAsync(string expected, string property) =>
    _ui.VerifyAsync(_locators.FG0063, expected, property, new ControlIntent("Coverages", "FG0063TableRowEndorsement"));

    public Task VerifyFG0077TableRowEndorsementAsync(string expected, string property) =>
    _ui.VerifyAsync(_locators.FG0077, expected, property, new ControlIntent("Coverages", "FG0077TableRowEndorsement"));

    public Task VerifyFG0071TableRowEndorsementAsync(string expected, string property) =>
    _ui.VerifyAsync(_locators.FG0071, expected, property, new ControlIntent("Coverages", "FG0071TableRowEndorsement"));

    public Task VerifyCG2151TableRowEndorsementAsync(string expected, string property) =>
    _ui.VerifyAsync(_locators.CG2151, expected, property, new ControlIntent("Coverages", "CG2151TableRowEndorsement"));

    public Task VerifyFG0074TableRowEndorsementAsync(string expected, string property) =>
    _ui.VerifyAsync(_locators.FG0074, expected, property, new ControlIntent("Coverages", "FG0074TableRowEndorsement"));



    public Task WaitForFGFormTableRowAsync(string expected) =>
        _ui.WaitAsync(_locators.FGFormTableRow, expected, new ControlIntent("Coverages", "FGFormTableRow"));

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

    public Task ClickIMNavigationLinksPolicyCovgAsync() =>
        _ui.ClickAsync(_locators.IMNavigationLinksPolicyCovg, new ControlIntent("Coverages", "IMNavigationLinksPolicyCovg"));

    public Task WaitForPolicyCovgMainPolicyCovgAsync(string expected) =>
        _ui.WaitAsync(_locators.PageTitle, expected, new ControlIntent("Coverages", "PolicyCovgMainPolicyCovg"));

    public Task WaitForPolicyInfoHeaderAsync(string expected) =>
        _ui.WaitAsync(_locators.PageTitle, expected, new ControlIntent("Coverages", "PolicyInfoHeader"));

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

    public Task<string> CaptureDescriptionOfSpecifiedOperationAsync(string property = "") =>
        _ui.CaptureAsync(_locators.DescriptionOfSpecifiedOperation, property, new ControlIntent("Coverages", "DescriptionOfSpecifiedOperation"));


    public Task EnterCoinsuranceSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.Coinsurance, value, new ControlIntent("Coverages", "Coinsurance"), delayMs);

    public Task EnterCoverageFormToBeAddedSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.CoverageFormToBeAdded, value, new ControlIntent("Coverages", "CoverageFormToBeAdded"), delayMs);

    public Task EnterDescriptionSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.Description, value, new ControlIntent("Coverages", "Description"), delayMs);

    public Task EnterDescriptionOfSpecifiedOperationSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.DescriptionOfSpecifiedOperation, value, new ControlIntent("Coverages", "DescriptionOfSpecifiedOperation"), delayMs);

    public Task EnterEndorsementTypeSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.EndorsementType, value, new ControlIntent("Coverages", "EndorsementType"), delayMs);

    public Task EnterEstimatedPremiumSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.EstimatedPremium, value, new ControlIntent("Coverages", "EstimatedPremium"), delayMs);

    public Task EnterFungusSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.Fungus, value, new ControlIntent("Coverages", "Fungus"), delayMs);

    public Task EnterHasTheInsuredEverHadAClaimForEmploymentPracticesSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.HasTheInsuredEverHadAClaimForEmploymentPractices, value, new ControlIntent("Coverages", "HasTheInsuredEverHadAClaimForEmploymentPractices"), delayMs);

    public Task EnterLimitDeductibleSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.LimitDeductible, value, new ControlIntent("Coverages", "LimitDeductible"), delayMs);

    public Task EnterPolicyCoverageSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.PolicyCoverage, value, new ControlIntent("Coverages", "PolicyCoverage"), delayMs);

    public Task EnterPropertyExtensionEndorsementsSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.PropertyExtensionEndorsements, value, new ControlIntent("Coverages", "PropertyExtensionEndorsements"), delayMs);

    public Task EnterTheInsuredAndAnyExecutiveOfficerOrOwnerHasKnowledgeOrInformationOfAnyActErrorOrOmissionWhichMightGiveRiseToAnEPLClaimSuitOrComplaintSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.TheInsuredAndAnyExecutiveOfficerOrOwnerHasKnowledgeOrInformationOfAnyActErrorOrOmissionWhichMightGiveRiseToAnEPLClaimSuitOrComplaint, value, new ControlIntent("Coverages", "TheInsuredAndAnyExecutiveOfficerOrOwnerHasKnowledgeOrInformationOfAnyActErrorOrOmissionWhichMightGiveRiseToAnEPLClaimSuitOrComplaint"), delayMs);

    public Task EnterThirdPartySequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.ThirdParty, value, new ControlIntent("Coverages", "ThirdParty"), delayMs);

    public Task EnterUtilityServicesSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.UtilityServices, value, new ControlIntent("Coverages", "UtilityServices"), delayMs);
}
