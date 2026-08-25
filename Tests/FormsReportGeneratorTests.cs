using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using PnCTestAutomation.Models;
using PnCTestAutomation.Services;

namespace PnCTestAutomation.Tests
{
    [TestFixture]
    public class FormsReportGeneratorTests
    {
        [Test]
        public void WriteTrxResults_DoesNotUseSummaryDataInFileName()
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
                FormsReportGenerator.WriteTrxResults(summary, outputDirectory);

                var trxPath = Directory.GetFiles(outputDirectory, "FormsValidation_*.trx").Single();
                Assert.That(Path.GetDirectoryName(trxPath), Is.EqualTo(outputDirectory));
                Assert.That(Path.GetFileName(trxPath), Does.Not.Contain("Outside"));
                Assert.That(Path.GetFileName(trxPath), Does.Not.Contain("Secret"));
            }
            finally
            {
                if (Directory.Exists(outputDirectory))
                    Directory.Delete(outputDirectory, recursive: true);
            }
        }
    }
}
