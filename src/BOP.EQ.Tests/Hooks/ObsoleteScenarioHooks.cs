using NUnit.Framework;
using Reqnroll;

namespace InsuranceAutomation.Hooks;

[Binding]
public sealed class ObsoleteScenarioHooks
{
    [BeforeScenario("@obsolete", Order = -100)]
    public void SkipObsoleteScenario() => Assert.Ignore("Obsolete source test retained for traceability; run only after explicit reactivation.");
}
