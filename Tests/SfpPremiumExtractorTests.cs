using NUnit.Framework;
using System;
using System.Diagnostics;
using System.IO;

namespace PnCTestAutomation.Tests
{
    [TestFixture]
    public class SfpPremiumExtractorTests
    {
        private string _testDirectory;

        [SetUp]
        public void CreateTestDirectory()
        {
            _testDirectory = Path.Combine(
                TestContext.CurrentContext.WorkDirectory,
                "SfpPremiumExtractorTests",
                Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(_testDirectory);
        }

        [TearDown]
        public void RemoveTestDirectory()
        {
            if (Directory.Exists(_testDirectory))
                Directory.Delete(_testDirectory, recursive: true);
        }

        [Test]
        public void Extractor_WritesOneGeneratedSfpResult()
        {
            var trxPath = WriteTrx(
                UnitTestResult(
                    "SFPBasicPolicy_State(Maryland)",
                    "Passed",
                    "*** QUOTE NUMBER: 01070001 ***\r\n*** ANNUAL PREMIUM: $1,234.00 ***"));

            var result = RunExtractor(trxPath);
            var csvPath = Path.ChangeExtension(trxPath, "premiums.csv");

            Assert.Multiple(() =>
            {
                Assert.That(result.ExitCode, Is.Zero, result.Output);
                Assert.That(File.Exists(csvPath), Is.True);
                Assert.That(File.ReadAllLines(csvPath), Has.Length.EqualTo(2));
                Assert.That(File.ReadAllText(csvPath),
                    Does.Contain("\"BASIC\",\"MD\",\"1234.00\",\"01070001\",\"Passed\""));
            });
        }

        [Test]
        public void Extractor_WritesMultipleGeneratedSfpResultsInStableOrder()
        {
            var trxPath = WriteTrx(
                UnitTestResult(
                    "SFPCountryEstatePolicy_State(Pennsylvania)",
                    "Passed",
                    "*** QUOTE NUMBER: 01070003 ***\r\n*** ANNUAL PREMIUM: $2,778.00 ***"),
                UnitTestResult(
                    "SFPBasicPolicy_State(&quot;Vermont&quot;,&quot;VT&quot;,&quot;69 Old River Road&quot;," +
                    "&quot;&quot;,&quot;Woodstock&quot;,&quot;05091&quot;,&quot;Washington&quot;)",
                    "Failed",
                    "*** QUOTE NUMBER: 01070002 ***"));

            var result = RunExtractor(trxPath);
            var lines = File.ReadAllLines(Path.ChangeExtension(trxPath, "premiums.csv"));

            Assert.Multiple(() =>
            {
                Assert.That(result.ExitCode, Is.Zero, result.Output);
                Assert.That(lines, Has.Length.EqualTo(3));
                Assert.That(lines[1], Does.StartWith("\"BASIC\",\"VT\""));
                Assert.That(lines[2], Does.StartWith("\"CE\",\"PA\""));
                Assert.That(lines[1], Does.Contain("\"\",\"01070002\",\"Failed\""));
            });
        }

        [Test]
        public void Extractor_NoSfpResultsFailsWithoutCreatingCsv()
        {
            var trxPath = WriteTrx(UnitTestResult("UnrelatedTest", "Passed", "No premium"));
            var csvPath = Path.ChangeExtension(trxPath, "premiums.csv");

            var result = RunExtractor(trxPath);

            Assert.Multiple(() =>
            {
                Assert.That(result.ExitCode, Is.Not.Zero);
                Assert.That(result.Output, Does.Contain("No SFP workflow results"));
                Assert.That(File.Exists(csvPath), Is.False);
            });
        }

        private string WriteTrx(params string[] results)
        {
            var path = Path.Combine(_testDirectory, "capture.trx");
            File.WriteAllText(
                path,
                $"<?xml version=\"1.0\" encoding=\"utf-8\"?><TestRun><Results>{string.Join("", results)}</Results></TestRun>");
            return path;
        }

        private static string UnitTestResult(string name, string outcome, string stdout) =>
            $"<UnitTestResult testName=\"{name}\" outcome=\"{outcome}\"><Output><StdOut>" +
            System.Security.SecurityElement.Escape(stdout) +
            "</StdOut></Output></UnitTestResult>";

        private static (int ExitCode, string Output) RunExtractor(string trxPath)
        {
            var scriptPath = Path.Combine(ProjectRoot(), "Scripts", "Extract-SFPPremiums.ps1");
            var startInfo = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = $"-NoProfile -NonInteractive -ExecutionPolicy Bypass -File \"{scriptPath}\" -TrxPath \"{trxPath}\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using var process = Process.Start(startInfo)
                ?? throw new InvalidOperationException("Could not start powershell.exe.");
            var stdout = process.StandardOutput.ReadToEnd();
            var stderr = process.StandardError.ReadToEnd();
            process.WaitForExit();
            return (process.ExitCode, stdout + Environment.NewLine + stderr);
        }

        private static string ProjectRoot()
        {
            var directory = new DirectoryInfo(TestContext.CurrentContext.TestDirectory);
            while (directory != null && !File.Exists(Path.Combine(directory.FullName, "TestAutomation.csproj")))
                directory = directory.Parent;
            return directory?.FullName
                ?? throw new InvalidOperationException("Cannot locate TestAutomation.csproj.");
        }
    }
}
