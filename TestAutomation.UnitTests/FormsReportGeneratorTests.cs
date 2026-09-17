using NUnit.Framework;
using PnCTestAutomation.Models;
using PnCTestAutomation.Services;

namespace PnCTestAutomation.UnitTests;

[TestFixture]
public class FormsReportGeneratorTests
{
    [TestCase(true)]
    [TestCase(false)]
    public void ResultFilesDoNotUseSummaryDataInFileNames(bool writeTrx)
    {
        var outputDirectory = Path.Combine(
            Path.GetTempPath(),
            $"FormsReportGeneratorTests_{Guid.NewGuid():N}");
        var summary = new FormsValidationSummary
        {
            LOB = @"..\Outside",
            State = @"..\Secret",
            Timestamp = DateTime.UtcNow
        };

        try
        {
            if (writeTrx)
                FormsReportGenerator.WriteTrxResults(
                    summary,
                    Path.Combine(outputDirectory, "forms-results.trx"));
            else
                FormsReportGenerator.WritePipelineSummary(
                    summary,
                    Path.Combine(outputDirectory, "forms-summary.md"));

            var outputPath = Directory.GetFiles(outputDirectory).Single();
            Assert.Multiple(() =>
            {
                Assert.That(Path.GetDirectoryName(outputPath), Is.EqualTo(outputDirectory));
                Assert.That(Path.GetFileName(outputPath), Does.Not.Contain("Outside"));
                Assert.That(Path.GetFileName(outputPath), Does.Not.Contain("Secret"));
            });
        }
        finally
        {
            if (Directory.Exists(outputDirectory))
                Directory.Delete(outputDirectory, recursive: true);
        }
    }
}
