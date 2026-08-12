using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQBOPBuildingSubcontractorsInConnectionWithBuildingConstructionReconstructionRepairOrErectionNotBuildingsTotalCost
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQBOPBuildingSubcontractorsInConnectionWithBuildingConstructionReconstructionRepairOrErectionNotBuildingsTotalCost(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator SubcontractorsInConnectionWithBuildingConstructionReconstructionRepairOrErectionNotBuildingsTotalCost => EQBOPBuildingSubcontractorsInConnectionWithBuildingConstructionReconstructionRepairOrErectionNotBuildingsTotalCostLocators.SubcontractorsInConnectionWithBuildingConstructionReconstructionRepairOrErectionNotBuildingsTotalCost(_page);

    public Task PressSubcontractorsInConnectionWithBuildingConstructionReconstructionRepairOrErectionNotBuildingsTotalCostAsync(string key) => SubcontractorsInConnectionWithBuildingConstructionReconstructionRepairOrErectionNotBuildingsTotalCost.PressAsync(key);

    public Task DoubleClickSubcontractorsInConnectionWithBuildingConstructionReconstructionRepairOrErectionNotBuildingsTotalCostAsync() => SubcontractorsInConnectionWithBuildingConstructionReconstructionRepairOrErectionNotBuildingsTotalCost.DblClickAsync();

    public Task SetSubcontractorsInConnectionWithBuildingConstructionReconstructionRepairOrErectionNotBuildingsTotalCostAsync(string value) =>
        UiActions.ApplyInputAsync(_page, SubcontractorsInConnectionWithBuildingConstructionReconstructionRepairOrErectionNotBuildingsTotalCost, _data.Resolve(value));

    public Task TypeSubcontractorsInConnectionWithBuildingConstructionReconstructionRepairOrErectionNotBuildingsTotalCostAsync(string value, float delayMs = 40) =>
        SubcontractorsInConnectionWithBuildingConstructionReconstructionRepairOrErectionNotBuildingsTotalCost.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

}
