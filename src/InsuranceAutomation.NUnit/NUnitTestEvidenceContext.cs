using NUnit.Framework;

namespace InsuranceAutomation.NUnit;

public sealed record NUnitTestEvidenceContext(
    string TestId,
    string TestName,
    string TestFullName,
    string WorkDirectory,
    string ResultDirectory)
{
    public static NUnitTestEvidenceContext Capture(string feature, string scenario, string artifactDirectory)
    {
        var id = Read(() => TestContext.CurrentContext.Test.ID);
        var name = Read(() => TestContext.CurrentContext.Test.Name);
        var fullName = Read(() => TestContext.CurrentContext.Test.FullName);
        var work = Read(() => TestContext.CurrentContext.WorkDirectory);
        if (string.IsNullOrWhiteSpace(work)) work = Read(() => TestContext.CurrentContext.TestDirectory);
        if (string.IsNullOrWhiteSpace(work)) work = AppContext.BaseDirectory;
        var resultDirectory = Path.GetFullPath(artifactDirectory);
        Directory.CreateDirectory(resultDirectory);
        return new NUnitTestEvidenceContext(id, name, fullName, work, resultDirectory);
    }

    private static string Read(Func<string> value)
    {
        try { return value() ?? string.Empty; }
        catch { return string.Empty; }
    }

    private static string Safe(string value) =>
        string.Concat((value ?? string.Empty).Select(c => char.IsLetterOrDigit(c) || c is '-' or '_' ? c : '_')).Trim('_');
}
