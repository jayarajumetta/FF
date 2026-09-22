using System.Collections.Immutable;
using PnCTestAutomation.Artifacts;
using PnCTestAutomation.Reporting;

namespace PnCTestAutomation.SgsReport;

public static class Program
{
    public static int Main(string[] args) => Run(args, Console.Out, Console.Error);

    public static int Run(string[] args, TextWriter output, TextWriter error)
    {
        var redactor = new ReportRedactor();
        try
        {
            var values = new Dictionary<string, string>(StringComparer.Ordinal);
            var roots = ImmutableArray.CreateBuilder<string>();
            for (var index = 0; index < args.Length; index++)
            {
                var key = args[index];
                if (key is not ("--evidence-root" or "--canonical-result" or "--output-dir" or "--scenario-root") ||
                    ++index >= args.Length || string.IsNullOrWhiteSpace(args[index]))
                    throw new ArgumentException("Expected --evidence-root, --canonical-result, --output-dir and optional repeatable --scenario-root values.");
                if (key == "--scenario-root")
                    roots.Add(args[index]);
                else if (!values.TryAdd(key, args[index]))
                    throw new ArgumentException("A report option was supplied more than once.");
            }
            if (!values.TryGetValue("--evidence-root", out var root) ||
                !values.TryGetValue("--canonical-result", out var canonical) ||
                !values.TryGetValue("--output-dir", out var destination))
                throw new ArgumentException("--evidence-root, --canonical-result and --output-dir are required.");
            var result = new ReportAggregator(redactor).Generate(new SgsReportOptions(root, canonical, destination)
            {
                ScenarioRoots = roots.ToImmutable()
            });
            foreach (var issue in result.Report.Issues)
                error.WriteLine($"{issue.Code}: {redactor.Text(issue.Message)} {redactor.Text(issue.TestIdentity)}");
            output.WriteLine($"{ConsolidatedReportRenderer.OverallStatus(result.Report).Text()}: {redactor.Text(result.ReportPath)}");
            return result.ExitCode;
        }
        catch (Exception exception) when (exception is ArgumentException or IOException or UnauthorizedAccessException or ArtifactEvidenceException)
        {
            error.WriteLine("Report generation failed: " + redactor.Text(exception.Message));
            return 2;
        }
    }
}
