using InsuranceAutomation.Core;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using NUnit.Framework.Internal.Commands;

namespace InsuranceAutomation.NUnit;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
public sealed class ConfiguredRetryAttribute : NUnitAttribute, IWrapSetUpTearDown
{
    public TestCommand Wrap(TestCommand command) => new ConfiguredRetryCommand(command);
}

public sealed class ConfiguredRetryCommand : DelegatingTestCommand
{
    private readonly Func<int> _retryCount;
    private static readonly string[] RetryExcludedFeatureNames =
    {
        ".WCBasicPolicyFeature."
    };

    public ConfiguredRetryCommand(TestCommand innerCommand, Func<int>? retryCount = null) : base(innerCommand)
    {
        _retryCount = retryCount ?? (() => FrameworkConfig.Load().Execution.RetryCount);
    }

    public override TestResult Execute(TestExecutionContext context)
    {
        var retries = ShouldBypassRetry(context) ? 0 : _retryCount();
        if (retries < 0 || retries == int.MaxValue)
            throw new InvalidOperationException("Retry count must be nonnegative and leave room for the initial attempt.");

        var previous = ScenarioAttemptContext.Current;
        var attempts = new ScenarioAttemptContext(context.CurrentTest.FullName, retries + 1);
        ScenarioAttemptContext.Current = attempts;
        try
        {
            for (var attempt = 1; attempt <= attempts.MaxAttempts; attempt++)
            {
                attempts.AttemptNumber = attempt;
                context.CurrentRepeatCount = attempt - 1;
                try
                {
                    context.CurrentResult = innerCommand.Execute(context);
                }
                catch (Exception error)
                {
                    context.CurrentResult.RecordException(error);
                }

                foreach (var report in attempts.Reports.Where(report => report.AttemptNumber == attempt))
                    report.CompleteAttempt(context.CurrentResult.ResultState.Status switch
                    {
                        TestStatus.Passed => "PASS",
                        TestStatus.Failed => "FAIL",
                        _ => "SKIP"
                    }, context.CurrentResult.Message);

                if (context.CurrentResult.ResultState.Status != TestStatus.Failed ||
                    context.ExecutionStatus != TestExecutionStatus.Running || attempt == attempts.MaxAttempts)
                    break;

                TestContext.Progress.WriteLine($"RETRY: {context.CurrentTest.FullName}; attempt {attempt} failed; starting {attempt + 1}/{attempts.MaxAttempts}.");
                context.CurrentResult = context.CurrentTest.MakeTestResult();
            }
            return context.CurrentResult;
        }
        finally
        {
            try
            {
                foreach (var report in attempts.Reports) report.RefreshAttemptLinks();
            }
            finally { ScenarioAttemptContext.Current = previous; }
        }
    }

    private static bool ShouldBypassRetry(TestExecutionContext context)
    {
        var fullName = context.CurrentTest.FullName;
        foreach (var excludedFeatureName in RetryExcludedFeatureNames)
        {
            if (fullName.Contains(excludedFeatureName, StringComparison.Ordinal))
                return true;
        }

        return false;
    }
}
