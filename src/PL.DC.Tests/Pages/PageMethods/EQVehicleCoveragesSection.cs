using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQVehicleCoveragesSection
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQVehicleCoveragesSection(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator UMPDUIMPDV1 => EQVehicleCoveragesSectionLocators.UMPDUIMPDV1(_page);

    public Task PressUMPDUIMPDV1Async(string key) => UMPDUIMPDV1.PressAsync(key);

    public Task DoubleClickUMPDUIMPDV1Async() => UMPDUIMPDV1.DblClickAsync();

    public Task ClickUMPDUIMPDV1Async() => UMPDUIMPDV1.ClickAsync();

    private ILocator UIMPDCoverageV1 => EQVehicleCoveragesSectionLocators.UIMPDCoverageV1(_page);

    public Task PressUIMPDCoverageV1Async(string key) => UIMPDCoverageV1.PressAsync(key);

    public Task DoubleClickUIMPDCoverageV1Async() => UIMPDCoverageV1.DblClickAsync();

    public Task ClickUIMPDCoverageV1Async() => UIMPDCoverageV1.ClickAsync();

    private ILocator RentalReimbursementCoverageV1 => EQVehicleCoveragesSectionLocators.RentalReimbursementCoverageV1(_page);

    public Task PressRentalReimbursementCoverageV1Async(string key) => RentalReimbursementCoverageV1.PressAsync(key);

    public Task DoubleClickRentalReimbursementCoverageV1Async() => RentalReimbursementCoverageV1.DblClickAsync();

    public Task SetRentalReimbursementCoverageV1Async(string value) =>
        UiActions.ApplyInputAsync(_page, RentalReimbursementCoverageV1, _data.Resolve(value));

    public Task TypeRentalReimbursementCoverageV1Async(string value, float delayMs = 40) =>
        RentalReimbursementCoverageV1.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator TheftDeductibleV1 => EQVehicleCoveragesSectionLocators.TheftDeductibleV1(_page);

    public Task PressTheftDeductibleV1Async(string key) => TheftDeductibleV1.PressAsync(key);

    public Task DoubleClickTheftDeductibleV1Async() => TheftDeductibleV1.DblClickAsync();

    public Task ClickTheftDeductibleV1Async() => TheftDeductibleV1.ClickAsync();

    private ILocator RoadsideAssistanceCoverageV1 => EQVehicleCoveragesSectionLocators.RoadsideAssistanceCoverageV1(_page);

    public Task PressRoadsideAssistanceCoverageV1Async(string key) => RoadsideAssistanceCoverageV1.PressAsync(key);

    public Task DoubleClickRoadsideAssistanceCoverageV1Async() => RoadsideAssistanceCoverageV1.DblClickAsync();

    public Task SetRoadsideAssistanceCoverageV1Async(string value) =>
        UiActions.ApplyInputAsync(_page, RoadsideAssistanceCoverageV1, _data.Resolve(value));

    public Task TypeRoadsideAssistanceCoverageV1Async(string value, float delayMs = 40) =>
        RoadsideAssistanceCoverageV1.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator CycleAccessoriesV1 => EQVehicleCoveragesSectionLocators.CycleAccessoriesV1(_page);

    public Task PressCycleAccessoriesV1Async(string key) => CycleAccessoriesV1.PressAsync(key);

    public Task DoubleClickCycleAccessoriesV1Async() => CycleAccessoriesV1.DblClickAsync();

    public Task ClickCycleAccessoriesV1Async() => CycleAccessoriesV1.ClickAsync();

    private ILocator OriginalPartsV1 => EQVehicleCoveragesSectionLocators.OriginalPartsV1(_page);

    public Task PressOriginalPartsV1Async(string key) => OriginalPartsV1.PressAsync(key);

    public Task DoubleClickOriginalPartsV1Async() => OriginalPartsV1.DblClickAsync();

    public Task ClickOriginalPartsV1Async() => OriginalPartsV1.ClickAsync();

    private ILocator EndorsementLimitV1 => EQVehicleCoveragesSectionLocators.EndorsementLimitV1(_page);

    public Task PressEndorsementLimitV1Async(string key) => EndorsementLimitV1.PressAsync(key);

    public Task DoubleClickEndorsementLimitV1Async() => EndorsementLimitV1.DblClickAsync();

    public Task SetEndorsementLimitV1Async(string value) =>
        EndorsementLimitV1.SelectOptionAsync(_data.Resolve(value));

    private ILocator UMPDUIMPDV2 => EQVehicleCoveragesSectionLocators.UMPDUIMPDV2(_page);

    public Task PressUMPDUIMPDV2Async(string key) => UMPDUIMPDV2.PressAsync(key);

    public Task DoubleClickUMPDUIMPDV2Async() => UMPDUIMPDV2.DblClickAsync();

    public Task ClickUMPDUIMPDV2Async() => UMPDUIMPDV2.ClickAsync();

    private ILocator UIMPDCoverageV2 => EQVehicleCoveragesSectionLocators.UIMPDCoverageV2(_page);

    public Task PressUIMPDCoverageV2Async(string key) => UIMPDCoverageV2.PressAsync(key);

    public Task DoubleClickUIMPDCoverageV2Async() => UIMPDCoverageV2.DblClickAsync();

    public Task ClickUIMPDCoverageV2Async() => UIMPDCoverageV2.ClickAsync();

    private ILocator RentalReimbursementCoverageV2 => EQVehicleCoveragesSectionLocators.RentalReimbursementCoverageV2(_page);

    public Task PressRentalReimbursementCoverageV2Async(string key) => RentalReimbursementCoverageV2.PressAsync(key);

    public Task DoubleClickRentalReimbursementCoverageV2Async() => RentalReimbursementCoverageV2.DblClickAsync();

    public Task SetRentalReimbursementCoverageV2Async(string value) =>
        UiActions.ApplyInputAsync(_page, RentalReimbursementCoverageV2, _data.Resolve(value));

    public Task TypeRentalReimbursementCoverageV2Async(string value, float delayMs = 40) =>
        RentalReimbursementCoverageV2.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator TheftDeductibleV2 => EQVehicleCoveragesSectionLocators.TheftDeductibleV2(_page);

    public Task PressTheftDeductibleV2Async(string key) => TheftDeductibleV2.PressAsync(key);

    public Task DoubleClickTheftDeductibleV2Async() => TheftDeductibleV2.DblClickAsync();

    public Task ClickTheftDeductibleV2Async() => TheftDeductibleV2.ClickAsync();

    private ILocator RoadsideAssistanceCoverageV2 => EQVehicleCoveragesSectionLocators.RoadsideAssistanceCoverageV2(_page);

    public Task PressRoadsideAssistanceCoverageV2Async(string key) => RoadsideAssistanceCoverageV2.PressAsync(key);

    public Task DoubleClickRoadsideAssistanceCoverageV2Async() => RoadsideAssistanceCoverageV2.DblClickAsync();

    public Task SetRoadsideAssistanceCoverageV2Async(string value) =>
        UiActions.ApplyInputAsync(_page, RoadsideAssistanceCoverageV2, _data.Resolve(value));

    public Task TypeRoadsideAssistanceCoverageV2Async(string value, float delayMs = 40) =>
        RoadsideAssistanceCoverageV2.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator CycleAccessoriesV2 => EQVehicleCoveragesSectionLocators.CycleAccessoriesV2(_page);

    public Task PressCycleAccessoriesV2Async(string key) => CycleAccessoriesV2.PressAsync(key);

    public Task DoubleClickCycleAccessoriesV2Async() => CycleAccessoriesV2.DblClickAsync();

    public Task ClickCycleAccessoriesV2Async() => CycleAccessoriesV2.ClickAsync();

    private ILocator OriginalPartsV2 => EQVehicleCoveragesSectionLocators.OriginalPartsV2(_page);

    public Task PressOriginalPartsV2Async(string key) => OriginalPartsV2.PressAsync(key);

    public Task DoubleClickOriginalPartsV2Async() => OriginalPartsV2.DblClickAsync();

    public Task ClickOriginalPartsV2Async() => OriginalPartsV2.ClickAsync();

    private ILocator EndorsementLimitV2 => EQVehicleCoveragesSectionLocators.EndorsementLimitV2(_page);

    public Task PressEndorsementLimitV2Async(string key) => EndorsementLimitV2.PressAsync(key);

    public Task DoubleClickEndorsementLimitV2Async() => EndorsementLimitV2.DblClickAsync();

    public Task SetEndorsementLimitV2Async(string value) =>
        EndorsementLimitV2.SelectOptionAsync(_data.Resolve(value));

    private ILocator NoCoverageV1Towing => EQVehicleCoveragesSectionLocators.NoCoverageV1Towing(_page);

    public Task PressNoCoverageV1TowingAsync(string key) => NoCoverageV1Towing.PressAsync(key);

    public Task DoubleClickNoCoverageV1TowingAsync() => NoCoverageV1Towing.DblClickAsync();

    public Task ClickNoCoverageV1TowingAsync() => NoCoverageV1Towing.ClickAsync();

    private ILocator UMPDUIMPDV3 => EQVehicleCoveragesSectionLocators.UMPDUIMPDV3(_page);

    public Task PressUMPDUIMPDV3Async(string key) => UMPDUIMPDV3.PressAsync(key);

    public Task DoubleClickUMPDUIMPDV3Async() => UMPDUIMPDV3.DblClickAsync();

    public Task ClickUMPDUIMPDV3Async() => UMPDUIMPDV3.ClickAsync();

    private ILocator UIMPDCoverageV3 => EQVehicleCoveragesSectionLocators.UIMPDCoverageV3(_page);

    public Task PressUIMPDCoverageV3Async(string key) => UIMPDCoverageV3.PressAsync(key);

    public Task DoubleClickUIMPDCoverageV3Async() => UIMPDCoverageV3.DblClickAsync();

    public Task ClickUIMPDCoverageV3Async() => UIMPDCoverageV3.ClickAsync();

    private ILocator RentalReimbursementCoverageV3 => EQVehicleCoveragesSectionLocators.RentalReimbursementCoverageV3(_page);

    public Task PressRentalReimbursementCoverageV3Async(string key) => RentalReimbursementCoverageV3.PressAsync(key);

    public Task DoubleClickRentalReimbursementCoverageV3Async() => RentalReimbursementCoverageV3.DblClickAsync();

    public Task SetRentalReimbursementCoverageV3Async(string value) =>
        UiActions.ApplyInputAsync(_page, RentalReimbursementCoverageV3, _data.Resolve(value));

    public Task TypeRentalReimbursementCoverageV3Async(string value, float delayMs = 40) =>
        RentalReimbursementCoverageV3.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator TheftDeductibleV3 => EQVehicleCoveragesSectionLocators.TheftDeductibleV3(_page);

    public Task PressTheftDeductibleV3Async(string key) => TheftDeductibleV3.PressAsync(key);

    public Task DoubleClickTheftDeductibleV3Async() => TheftDeductibleV3.DblClickAsync();

    public Task ClickTheftDeductibleV3Async() => TheftDeductibleV3.ClickAsync();

    private ILocator RoadsideAssistanceCoverageV3 => EQVehicleCoveragesSectionLocators.RoadsideAssistanceCoverageV3(_page);

    public Task PressRoadsideAssistanceCoverageV3Async(string key) => RoadsideAssistanceCoverageV3.PressAsync(key);

    public Task DoubleClickRoadsideAssistanceCoverageV3Async() => RoadsideAssistanceCoverageV3.DblClickAsync();

    public Task SetRoadsideAssistanceCoverageV3Async(string value) =>
        UiActions.ApplyInputAsync(_page, RoadsideAssistanceCoverageV3, _data.Resolve(value));

    public Task TypeRoadsideAssistanceCoverageV3Async(string value, float delayMs = 40) =>
        RoadsideAssistanceCoverageV3.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator CycleAccessoriesV3 => EQVehicleCoveragesSectionLocators.CycleAccessoriesV3(_page);

    public Task PressCycleAccessoriesV3Async(string key) => CycleAccessoriesV3.PressAsync(key);

    public Task DoubleClickCycleAccessoriesV3Async() => CycleAccessoriesV3.DblClickAsync();

    public Task ClickCycleAccessoriesV3Async() => CycleAccessoriesV3.ClickAsync();

    private ILocator OriginalPartsV3 => EQVehicleCoveragesSectionLocators.OriginalPartsV3(_page);

    public Task PressOriginalPartsV3Async(string key) => OriginalPartsV3.PressAsync(key);

    public Task DoubleClickOriginalPartsV3Async() => OriginalPartsV3.DblClickAsync();

    public Task ClickOriginalPartsV3Async() => OriginalPartsV3.ClickAsync();

    private ILocator UMPDUIMPDV4 => EQVehicleCoveragesSectionLocators.UMPDUIMPDV4(_page);

    public Task PressUMPDUIMPDV4Async(string key) => UMPDUIMPDV4.PressAsync(key);

    public Task DoubleClickUMPDUIMPDV4Async() => UMPDUIMPDV4.DblClickAsync();

    public Task ClickUMPDUIMPDV4Async() => UMPDUIMPDV4.ClickAsync();

    private ILocator UIMPDCoverageV4 => EQVehicleCoveragesSectionLocators.UIMPDCoverageV4(_page);

    public Task PressUIMPDCoverageV4Async(string key) => UIMPDCoverageV4.PressAsync(key);

    public Task DoubleClickUIMPDCoverageV4Async() => UIMPDCoverageV4.DblClickAsync();

    public Task ClickUIMPDCoverageV4Async() => UIMPDCoverageV4.ClickAsync();

    private ILocator RentalReimbursementCoverageV4 => EQVehicleCoveragesSectionLocators.RentalReimbursementCoverageV4(_page);

    public Task PressRentalReimbursementCoverageV4Async(string key) => RentalReimbursementCoverageV4.PressAsync(key);

    public Task DoubleClickRentalReimbursementCoverageV4Async() => RentalReimbursementCoverageV4.DblClickAsync();

    public Task SetRentalReimbursementCoverageV4Async(string value) =>
        UiActions.ApplyInputAsync(_page, RentalReimbursementCoverageV4, _data.Resolve(value));

    public Task TypeRentalReimbursementCoverageV4Async(string value, float delayMs = 40) =>
        RentalReimbursementCoverageV4.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator TheftDeductibleV4 => EQVehicleCoveragesSectionLocators.TheftDeductibleV4(_page);

    public Task PressTheftDeductibleV4Async(string key) => TheftDeductibleV4.PressAsync(key);

    public Task DoubleClickTheftDeductibleV4Async() => TheftDeductibleV4.DblClickAsync();

    public Task ClickTheftDeductibleV4Async() => TheftDeductibleV4.ClickAsync();

    private ILocator RoadsideAssistanceCoverageV4 => EQVehicleCoveragesSectionLocators.RoadsideAssistanceCoverageV4(_page);

    public Task PressRoadsideAssistanceCoverageV4Async(string key) => RoadsideAssistanceCoverageV4.PressAsync(key);

    public Task DoubleClickRoadsideAssistanceCoverageV4Async() => RoadsideAssistanceCoverageV4.DblClickAsync();

    public Task SetRoadsideAssistanceCoverageV4Async(string value) =>
        UiActions.ApplyInputAsync(_page, RoadsideAssistanceCoverageV4, _data.Resolve(value));

    public Task TypeRoadsideAssistanceCoverageV4Async(string value, float delayMs = 40) =>
        RoadsideAssistanceCoverageV4.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator CycleAccessoriesV4 => EQVehicleCoveragesSectionLocators.CycleAccessoriesV4(_page);

    public Task PressCycleAccessoriesV4Async(string key) => CycleAccessoriesV4.PressAsync(key);

    public Task DoubleClickCycleAccessoriesV4Async() => CycleAccessoriesV4.DblClickAsync();

    public Task ClickCycleAccessoriesV4Async() => CycleAccessoriesV4.ClickAsync();

    private ILocator OriginalPartsV4 => EQVehicleCoveragesSectionLocators.OriginalPartsV4(_page);

    public Task PressOriginalPartsV4Async(string key) => OriginalPartsV4.PressAsync(key);

    public Task DoubleClickOriginalPartsV4Async() => OriginalPartsV4.DblClickAsync();

    public Task ClickOriginalPartsV4Async() => OriginalPartsV4.ClickAsync();

    public Task ClickRoadsideAssistanceCoverageV4Async() => RoadsideAssistanceCoverageV4.ClickAsync();
}
