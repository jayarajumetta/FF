using Microsoft.Playwright;

namespace InsuranceAutomation.Core;

public interface IRuntimeLocatorResolver
{
    Task<ILocator?> ResolveAsync(IPage page, ILocator seed, ControlIntent intent, string action);
}
