using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class QueueInCLASQLTY
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public QueueInCLASQLTY(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator Queue => QueueInCLASQLTYLocators.Queue(_page);

    public Task PressQueueAsync(string key) => Queue.PressAsync(key);

    public Task DoubleClickQueueAsync() => Queue.DblClickAsync();

    public Task ClickQueueAsync() => Queue.ClickAsync();

    private ILocator ClearAll => QueueInCLASQLTYLocators.ClearAll(_page);

    public Task PressClearAllAsync(string key) => ClearAll.PressAsync(key);

    public Task DoubleClickClearAllAsync() => ClearAll.DblClickAsync();

    public Task ClickClearAllAsync() => ClearAll.ClickAsync();

    public Task WaitForClearAllAsync() =>
        ClearAll.WaitForAsync(new() { State = WaitForSelectorState.Visible });

}
