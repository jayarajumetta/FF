namespace InsuranceAutomation.Core;

public static class TestResultsCleaner
{
    private static int _cleaned;

    public static void CleanOnce(FrameworkConfig config)
    {
        if (Interlocked.Exchange(ref _cleaned, 1) == 1) return;

        var resultsRoot = Path.GetFullPath(config.Reporting.ResultsRoot);
        if (string.IsNullOrWhiteSpace(resultsRoot) || Path.GetPathRoot(resultsRoot) == resultsRoot)
            throw new InvalidOperationException($"Refusing to clear unsafe test results directory: {resultsRoot}");

        if (Directory.Exists(resultsRoot))
            Directory.Delete(resultsRoot, recursive: true);

        Directory.CreateDirectory(resultsRoot);
    }
}
