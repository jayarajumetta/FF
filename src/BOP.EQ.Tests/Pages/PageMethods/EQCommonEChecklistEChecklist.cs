using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQCommonEChecklistEChecklist
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQCommonEChecklistEChecklist(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator BuildingPhoto1 => EQCommonEChecklistEChecklistLocators.BuildingPhoto1(_page);

    public Task PressBuildingPhoto1Async(string key) => BuildingPhoto1.PressAsync(key);

    public Task DoubleClickBuildingPhoto1Async() => BuildingPhoto1.DblClickAsync();

    public Task SetBuildingPhoto1Async(string value) =>
        UiActions.ApplyInputAsync(_page, BuildingPhoto1, _data.Resolve(value));

    public Task TypeBuildingPhoto1Async(string value, float delayMs = 40) =>
        BuildingPhoto1.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator BuildingPhoto1Header => EQCommonEChecklistEChecklistLocators.BuildingPhoto1Header(_page);

    public Task PressBuildingPhoto1HeaderAsync(string key) => BuildingPhoto1Header.PressAsync(key);

    public Task DoubleClickBuildingPhoto1HeaderAsync() => BuildingPhoto1Header.DblClickAsync();

    public Task WaitForBuildingPhoto1HeaderAsync() =>
        BuildingPhoto1Header.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator Accept => EQCommonEChecklistEChecklistLocators.Accept(_page);

    public Task PressAcceptAsync(string key) => Accept.PressAsync(key);

    public Task DoubleClickAcceptAsync() => Accept.DblClickAsync();

    public Task ClickAcceptAsync() => Accept.ClickAsync();

    public Task WaitForAcceptAsync() =>
        Accept.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator Exception => EQCommonEChecklistEChecklistLocators.Exception(_page);

    public Task PressExceptionAsync(string key) => Exception.PressAsync(key);

    public Task DoubleClickExceptionAsync() => Exception.DblClickAsync();

    public Task ClickExceptionAsync() => Exception.ClickAsync();

    private ILocator OKAccept => EQCommonEChecklistEChecklistLocators.OKAccept(_page);

    public Task PressOKAcceptAsync(string key) => OKAccept.PressAsync(key);

    public Task DoubleClickOKAcceptAsync() => OKAccept.DblClickAsync();

    public Task ClickOKAcceptAsync() => OKAccept.ClickAsync();

    public Task WaitForOKAcceptAsync() =>
        OKAccept.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator OK => EQCommonEChecklistEChecklistLocators.OK(_page);

    public Task PressOKAsync(string key) => OK.PressAsync(key);

    public Task DoubleClickOKAsync() => OK.DblClickAsync();

    public Task ClickOKAsync() => OK.ClickAsync();

    public Task WaitForOKAsync() =>
        OK.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator ReviewComplete => EQCommonEChecklistEChecklistLocators.ReviewComplete(_page);

    public Task PressReviewCompleteAsync(string key) => ReviewComplete.PressAsync(key);

    public Task DoubleClickReviewCompleteAsync() => ReviewComplete.DblClickAsync();

    public Task ClickReviewCompleteAsync() => ReviewComplete.ClickAsync();

    public Task WaitForReviewCompleteAsync() =>
        ReviewComplete.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator PolicyHeader => EQCommonEChecklistEChecklistLocators.PolicyHeader(_page);

    public Task PressPolicyHeaderAsync(string key) => PolicyHeader.PressAsync(key);

    public Task DoubleClickPolicyHeaderAsync() => PolicyHeader.DblClickAsync();

    public Task SetPolicyHeaderAsync(string value) =>
        UiActions.ApplyInputAsync(_page, PolicyHeader, _data.Resolve(value));

    public Task TypePolicyHeaderAsync(string value, float delayMs = 40) =>
        PolicyHeader.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator BuildingPhoto2 => EQCommonEChecklistEChecklistLocators.BuildingPhoto2(_page);

    public Task PressBuildingPhoto2Async(string key) => BuildingPhoto2.PressAsync(key);

    public Task DoubleClickBuildingPhoto2Async() => BuildingPhoto2.DblClickAsync();

    public Task SetBuildingPhoto2Async(string value) =>
        UiActions.ApplyInputAsync(_page, BuildingPhoto2, _data.Resolve(value));

    public Task TypeBuildingPhoto2Async(string value, float delayMs = 40) =>
        BuildingPhoto2.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task WaitForBuildingPhoto2Async() =>
        BuildingPhoto2.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator BuildingPhoto2Header => EQCommonEChecklistEChecklistLocators.BuildingPhoto2Header(_page);

    public Task PressBuildingPhoto2HeaderAsync(string key) => BuildingPhoto2Header.PressAsync(key);

    public Task DoubleClickBuildingPhoto2HeaderAsync() => BuildingPhoto2Header.DblClickAsync();

    public Task WaitForBuildingPhoto2HeaderAsync() =>
        BuildingPhoto2Header.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator SignaturePageLink => EQCommonEChecklistEChecklistLocators.SignaturePageLink(_page);

    public Task PressSignaturePageLinkAsync(string key) => SignaturePageLink.PressAsync(key);

    public Task DoubleClickSignaturePageLinkAsync() => SignaturePageLink.DblClickAsync();

    public Task ClickSignaturePageLinkAsync() => SignaturePageLink.ClickAsync();

    private ILocator SignaturePageBoundCoverageOnlySFP => EQCommonEChecklistEChecklistLocators.SignaturePageBoundCoverageOnlySFP(_page);

    public Task PressSignaturePageBoundCoverageOnlySFPAsync(string key) => SignaturePageBoundCoverageOnlySFP.PressAsync(key);

    public Task DoubleClickSignaturePageBoundCoverageOnlySFPAsync() => SignaturePageBoundCoverageOnlySFP.DblClickAsync();

    public Task ClickSignaturePageBoundCoverageOnlySFPAsync() => SignaturePageBoundCoverageOnlySFP.ClickAsync();

    private ILocator Attach => EQCommonEChecklistEChecklistLocators.Attach(_page);

    public Task PressAttachAsync(string key) => Attach.PressAsync(key);

    public Task DoubleClickAttachAsync() => Attach.DblClickAsync();

    public Task ClickAttachAsync() => Attach.ClickAsync();

    public Task VerifyAttachAsync(string expected) =>
        Expect(Attach).ToContainTextAsync(_data.Resolve(expected));

    private ILocator DragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorer => EQCommonEChecklistEChecklistLocators.DragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorer(_page);

    public Task PressDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorerAsync(string key) => DragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorer.PressAsync(key);

    public Task DoubleClickDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorerAsync() => DragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorer.DblClickAsync();

    public Task SetDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorerAsync(string value) =>
        UiActions.ApplyInputAsync(_page, DragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorer, _data.Resolve(value));

    public Task TypeDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorerAsync(string value, float delayMs = 40) =>
        DragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorer.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task WaitForDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorerAsync() =>
        DragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorer.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator Submit => EQCommonEChecklistEChecklistLocators.Submit(_page);

    public Task PressSubmitAsync(string key) => Submit.PressAsync(key);

    public Task DoubleClickSubmitAsync() => Submit.DblClickAsync();

    public Task ClickSubmitAsync() => Submit.ClickAsync();

    private ILocator OkSubmit => EQCommonEChecklistEChecklistLocators.OkSubmit(_page);

    public Task PressOkSubmitAsync(string key) => OkSubmit.PressAsync(key);

    public Task DoubleClickOkSubmitAsync() => OkSubmit.DblClickAsync();

    public Task ClickOkSubmitAsync() => OkSubmit.ClickAsync();

    public Task WaitForOkSubmitAsync() =>
        OkSubmit.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator LossRunsHeader => EQCommonEChecklistEChecklistLocators.LossRunsHeader(_page);

    public Task PressLossRunsHeaderAsync(string key) => LossRunsHeader.PressAsync(key);

    public Task DoubleClickLossRunsHeaderAsync() => LossRunsHeader.DblClickAsync();

    public Task WaitForLossRunsHeaderAsync() =>
        LossRunsHeader.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator LossRuns3YearsHeader => EQCommonEChecklistEChecklistLocators.LossRuns3YearsHeader(_page);

    public Task PressLossRuns3YearsHeaderAsync(string key) => LossRuns3YearsHeader.PressAsync(key);

    public Task DoubleClickLossRuns3YearsHeaderAsync() => LossRuns3YearsHeader.DblClickAsync();

    public Task WaitForLossRuns3YearsHeaderAsync() =>
        LossRuns3YearsHeader.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator ULRoofTypeCredit => EQCommonEChecklistEChecklistLocators.ULRoofTypeCredit(_page);

    public Task PressULRoofTypeCreditAsync(string key) => ULRoofTypeCredit.PressAsync(key);

    public Task DoubleClickULRoofTypeCreditAsync() => ULRoofTypeCredit.DblClickAsync();

    public Task ClickULRoofTypeCreditAsync() => ULRoofTypeCredit.ClickAsync();

    public Task VerifyULRoofTypeCreditAsync(string expected) =>
        Expect(ULRoofTypeCredit).ToContainTextAsync(_data.Resolve(expected));

    private ILocator ULRoofTypeCreditHeader => EQCommonEChecklistEChecklistLocators.ULRoofTypeCreditHeader(_page);

    public Task PressULRoofTypeCreditHeaderAsync(string key) => ULRoofTypeCreditHeader.PressAsync(key);

    public Task DoubleClickULRoofTypeCreditHeaderAsync() => ULRoofTypeCreditHeader.DblClickAsync();

    public Task VerifyULRoofTypeCreditHeaderAsync(string expected) =>
        Expect(ULRoofTypeCreditHeader).ToContainTextAsync(_data.Resolve(expected));

    public Task WaitForULRoofTypeCreditHeaderAsync() =>
        ULRoofTypeCreditHeader.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator ResidencePhoto1 => EQCommonEChecklistEChecklistLocators.ResidencePhoto1(_page);

    public Task PressResidencePhoto1Async(string key) => ResidencePhoto1.PressAsync(key);

    public Task DoubleClickResidencePhoto1Async() => ResidencePhoto1.DblClickAsync();

    public Task ClickResidencePhoto1Async() => ResidencePhoto1.ClickAsync();

    public Task WaitForResidencePhoto1Async() =>
        ResidencePhoto1.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator BuildingPhoto3Header => EQCommonEChecklistEChecklistLocators.BuildingPhoto3Header(_page);

    public Task PressBuildingPhoto3HeaderAsync(string key) => BuildingPhoto3Header.PressAsync(key);

    public Task DoubleClickBuildingPhoto3HeaderAsync() => BuildingPhoto3Header.DblClickAsync();

    public Task WaitForBuildingPhoto3HeaderAsync() =>
        BuildingPhoto3Header.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator BuildingPhoto3 => EQCommonEChecklistEChecklistLocators.BuildingPhoto3(_page);

    public Task PressBuildingPhoto3Async(string key) => BuildingPhoto3.PressAsync(key);

    public Task DoubleClickBuildingPhoto3Async() => BuildingPhoto3.DblClickAsync();

    public Task WaitForBuildingPhoto3Async() =>
        BuildingPhoto3.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator BuildingPhoto4Header => EQCommonEChecklistEChecklistLocators.BuildingPhoto4Header(_page);

    public Task PressBuildingPhoto4HeaderAsync(string key) => BuildingPhoto4Header.PressAsync(key);

    public Task DoubleClickBuildingPhoto4HeaderAsync() => BuildingPhoto4Header.DblClickAsync();

    public Task WaitForBuildingPhoto4HeaderAsync() =>
        BuildingPhoto4Header.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator BuildingPhoto4 => EQCommonEChecklistEChecklistLocators.BuildingPhoto4(_page);

    public Task PressBuildingPhoto4Async(string key) => BuildingPhoto4.PressAsync(key);

    public Task DoubleClickBuildingPhoto4Async() => BuildingPhoto4.DblClickAsync();

    public Task WaitForBuildingPhoto4Async() =>
        BuildingPhoto4.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator LeadAbatementRemovalStatementHeader => EQCommonEChecklistEChecklistLocators.LeadAbatementRemovalStatementHeader(_page);

    public Task PressLeadAbatementRemovalStatementHeaderAsync(string key) => LeadAbatementRemovalStatementHeader.PressAsync(key);

    public Task DoubleClickLeadAbatementRemovalStatementHeaderAsync() => LeadAbatementRemovalStatementHeader.DblClickAsync();

    public Task WaitForLeadAbatementRemovalStatementHeaderAsync() =>
        LeadAbatementRemovalStatementHeader.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator WindstormOrHailPercentageDeductiblesSelectionForm => EQCommonEChecklistEChecklistLocators.WindstormOrHailPercentageDeductiblesSelectionForm(_page);

    public Task PressWindstormOrHailPercentageDeductiblesSelectionFormAsync(string key) => WindstormOrHailPercentageDeductiblesSelectionForm.PressAsync(key);

    public Task DoubleClickWindstormOrHailPercentageDeductiblesSelectionFormAsync() => WindstormOrHailPercentageDeductiblesSelectionForm.DblClickAsync();

    public Task ClickWindstormOrHailPercentageDeductiblesSelectionFormAsync() => WindstormOrHailPercentageDeductiblesSelectionForm.ClickAsync();

    public Task ClickBuildingPhoto1Async() => BuildingPhoto1.ClickAsync();

    public Task ClickBuildingPhoto2Async() => BuildingPhoto2.ClickAsync();

    public Task ClickDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorerAsync() => DragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorer.ClickAsync();

    public Task ClickPolicyHeaderAsync() => PolicyHeader.ClickAsync();
}
