using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using NUnit.Framework;
using PnCTestAutomation.Tools.FormsBaselineGenerator;

namespace PnCTestAutomation.Tests
{
    [TestFixture]
    [NonParallelizable]
    public class CanonicalFormsDeltaOperationalTests
    {
        private string _root;

        [SetUp]
        public void SetUp()
        {
            _root = Path.Combine(
                TestContext.CurrentContext.WorkDirectory,
                nameof(CanonicalFormsDeltaOperationalTests),
                Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(_root);
        }

        [TearDown]
        public void TearDown()
        {
            if (Directory.Exists(_root))
                Directory.Delete(_root, recursive: true);
        }

        [Test]
        public void SettingsMapExactPinnedInputsAndDefaultToNoWrite()
        {
            var values = ValidValues();

            var settings = CanonicalFormsDeltaOperation.ReadSettings(
                name => values.GetValueOrDefault(name, ""),
                _ => "",
                _root);

            Assert.Multiple(() =>
            {
                Assert.That(settings.WritePackage, Is.False);
                Assert.That(settings.AllowReviewedChanges, Is.False);
                Assert.That(settings.Request.ChangedSourceFamily,
                    Is.EqualTo(FormsMonitorSourceFamily.SFP));
                Assert.That(settings.Request.PreviousChangedSource.ExpectedSha256,
                    Is.EqualTo(Hash('A')));
                Assert.That(settings.Request.CurrentChangedSource.AcquisitionReference,
                    Is.EqualTo("site|drive|current-item|version-2"));
                Assert.That(settings.Request.CurrentCounterpartSource.ExpectedSha256,
                    Is.EqualTo(Hash('C')));
                Assert.That(settings.Request.ExpectedApprovedBaselineSha256,
                    Is.EqualTo(Hash('D')));
            });
        }

        [Test]
        public void SettingsFallBackToEnvironmentValues()
        {
            var values = ValidValues();

            var settings = CanonicalFormsDeltaOperation.ReadSettings(
                _ => "",
                name => values.GetValueOrDefault(name, ""),
                _root);

            Assert.Multiple(() =>
            {
                Assert.That(settings.EventId, Is.EqualTo("event-1"));
                Assert.That(settings.CorrelationId, Is.EqualTo("correlation-1"));
                Assert.That(settings.Request.CurrentChangedSource.Identity,
                    Is.EqualTo("current"));
                Assert.That(settings.WritePackage, Is.False);
            });
        }

        [Test]
        public void SettingsRequireExactHashesAndOpaqueReferences()
        {
            var missingHash = ValidValues();
            missingHash["DELTA_CURRENT_SOURCE_SHA256"] = "abc";
            var signedUrl = ValidValues();
            signedUrl["DELTA_CURRENT_SOURCE_REFERENCE"] =
                "https://contoso.sharepoint.com/file.xlsx?sig=secret";

            Assert.Multiple(() =>
            {
                Assert.That(
                    () => Read(missingHash),
                    Throws.InvalidOperationException.With.Message
                        .Contain("exact SHA-256"));
                Assert.That(
                    () => Read(signedUrl),
                    Throws.InvalidOperationException.With.Message
                        .Contain("not a URL"));
            });
        }

        [Test]
        public void WriteRequiresExplicitReviewedOptIn()
        {
            var values = ValidValues();
            values["DELTA_WRITE_PACKAGE"] = "true";

            Assert.That(
                () => Read(values),
                Throws.InvalidOperationException.With.Message
                    .Contain("DELTA_ALLOW_REVIEWED_CHANGES=true"));
        }

        [Test]
        public void ResultBindsReferencesAndHashesWithoutPathsOrSecrets()
        {
            var path = Path.Combine(_root, "result.json");
            var result = new CanonicalFormsDeltaOperationResult
            {
                EventId = "event-1",
                CorrelationId = "correlation-1",
                SourceFamily = FormsMonitorSourceFamily.SFP,
                PreviousSourceIdentity = "previous",
                PreviousSourceReference = "site|drive|previous|version-1",
                PreviousSourceSha256 = Hash('A'),
                CurrentSourceIdentity = "current",
                CurrentSourceReference = "site|drive|current|version-2",
                CurrentSourceSha256 = Hash('B'),
                CounterpartSourceIdentity = "counterpart",
                CounterpartSourceReference = "site|drive|counterpart|version-3",
                CounterpartSourceSha256 = Hash('C'),
                ApprovedBaselineSha256 = Hash('D'),
                Status = CanonicalFormsDeltaStatus.NoChanges
            };

            CanonicalFormsDeltaOperation.WriteResult(path, result);
            var json = File.ReadAllText(path);
            using var document = JsonDocument.Parse(json);

            Assert.Multiple(() =>
            {
                Assert.That(
                    document.RootElement.GetProperty("previousSourceReference")
                        .GetString(),
                    Is.EqualTo(result.PreviousSourceReference));
                Assert.That(
                    document.RootElement.GetProperty("counterpartSourceSha256")
                        .GetString(),
                    Is.EqualTo(Hash('C')));
                Assert.That(json, Does.Not.Contain(_root));
                Assert.That(json, Does.Not.Contain("password").IgnoreCase);
                Assert.That(json, Does.Not.Contain("clientSecret").IgnoreCase);
                Assert.That(json, Does.Not.Contain("sig=").IgnoreCase);
            });
        }

        [Test]
        public void AcquisitionScriptFailsClosedWhenIdentityIsAbsent()
        {
            var script = Path.Combine(
                ProjectRoot(),
                "Scripts",
                "Invoke-FormsDeltaReview.ps1");
            var startInfo = new ProcessStartInfo
            {
                FileName = "powershell",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };
            startInfo.ArgumentList.Add("-NoProfile");
            startInfo.ArgumentList.Add("-File");
            startInfo.ArgumentList.Add(script);
            foreach (var argument in ScriptArguments())
                startInfo.ArgumentList.Add(argument);
            foreach (var name in new[]
                     {
                         "FORMS_SHAREPOINT_ACQUISITION_PROVIDER",
                         "FORMS_SHAREPOINT_TENANT_ID",
                         "FORMS_SHAREPOINT_CLIENT_ID",
                         "FORMS_SHAREPOINT_FEDERATED_TOKEN_FILE",
                         "FORMS_SHAREPOINT_CERTIFICATE_THUMBPRINT"
                     })
            {
                startInfo.Environment.Remove(name);
            }

            using var process = Process.Start(startInfo)!;
            var output = process.StandardOutput.ReadToEnd()
                + process.StandardError.ReadToEnd();
            process.WaitForExit();

            Assert.Multiple(() =>
            {
                Assert.That(process.ExitCode, Is.Not.EqualTo(0));
                Assert.That(output, Does.Contain("FORMS_SHAREPOINT_TENANT_ID"));
                Assert.That(output, Does.Not.Contain("client_secret").IgnoreCase);
                Assert.That(output, Does.Not.Contain("sig=").IgnoreCase);
            });
        }

        [Test]
        public void PipelineAndScriptExposeOnlyTheApprovedOperationalContract()
        {
            var root = ProjectRoot();
            var yaml = File.ReadAllText(Path.Combine(
                root,
                FormsDeltaPipelineContract.PipelineYaml));
            var script = File.ReadAllText(Path.Combine(
                root,
                "Scripts",
                "Invoke-FormsDeltaReview.ps1"));
            var formsStageStart = yaml.IndexOf(
                "- stage: FormsDeltaReview",
                StringComparison.Ordinal);
            var formsStage = formsStageStart >= 0
                ? yaml[formsStageStart..]
                : "";

            Assert.Multiple(() =>
            {
                Assert.That(yaml, Does.Contain("trigger: none"));
                Assert.That(yaml, Does.Contain("pr: none"));
                Assert.That(yaml, Does.Contain("- name: pipelineMode"));
                Assert.That(yaml, Does.Contain("- FormsDelta"));
                Assert.That(yaml, Does.Contain("- stage: FormsDeltaReview"));
                Assert.That(yaml, Does.Contain(
                    "eq(parameters.pipelineMode, 'Regression')"));
                Assert.That(yaml, Does.Contain(
                    "eq(parameters.pipelineMode, 'FormsDelta')"));
                Assert.That(yaml, Does.Contain("name: \"Playwright\""));
                Assert.That(yaml, Does.Contain("writePackage"));
                Assert.That(yaml, Does.Contain("default: false"));
                Assert.That(formsStageStart, Is.GreaterThanOrEqualTo(0));
                Assert.That(
                    formsStage,
                    Does.Not.Contain("clientSecret").IgnoreCase);
                Assert.That(formsStage, Does.Not.Contain("sas").IgnoreCase);
                Assert.That(formsStage, Does.Contain(
                    "filePath: '$(Build.SourcesDirectory)" +
                    "\\Scripts\\Invoke-FormsDeltaReview.ps1'"));
                Assert.That(formsStage, Does.Not.Contain(
                    "-EventId \"${{ parameters.eventId }}\""));
                Assert.That(script, Does.Contain("finally"));
                Assert.That(script, Does.Contain("Get-VerifiedHash"));
                Assert.That(script, Does.Contain(
                    "FORMS_SHAREPOINT_ACQUISITION_PROVIDER"));
                Assert.That(script, Does.Not.Contain("Invoke-RestMethod"));
                Assert.That(
                    FormsDeltaPipelineContract.RequiredQueueParameters.All(
                        parameter => yaml.Contains(
                            $"- name: {parameter}",
                            StringComparison.Ordinal)),
                    Is.True);
            });
        }

        private CanonicalFormsDeltaOperationSettings Read(
            IReadOnlyDictionary<string, string> values) =>
            CanonicalFormsDeltaOperation.ReadSettings(
                name => values.GetValueOrDefault(name, ""),
                _ => "",
                _root);

        private Dictionary<string, string> ValidValues() =>
            new(StringComparer.Ordinal)
            {
                ["DELTA_SOURCE_FAMILY"] = "SFP",
                ["DELTA_EVENT_ID"] = "event-1",
                ["DELTA_CORRELATION_ID"] = "correlation-1",
                ["DELTA_PREVIOUS_SOURCE_IDENTITY"] = "previous",
                ["DELTA_PREVIOUS_SOURCE_REFERENCE"] =
                    "site|drive|previous-item|version-1",
                ["DELTA_PREVIOUS_SOURCE_PATH"] = Path.Combine(_root, "previous.xlsx"),
                ["DELTA_PREVIOUS_SOURCE_SHA256"] = Hash('A'),
                ["DELTA_CURRENT_SOURCE_IDENTITY"] = "current",
                ["DELTA_CURRENT_SOURCE_REFERENCE"] =
                    "site|drive|current-item|version-2",
                ["DELTA_CURRENT_SOURCE_PATH"] = Path.Combine(_root, "current.xlsx"),
                ["DELTA_CURRENT_SOURCE_SHA256"] = Hash('B'),
                ["DELTA_COUNTERPART_SOURCE_IDENTITY"] = "counterpart",
                ["DELTA_COUNTERPART_SOURCE_REFERENCE"] =
                    "site|drive|counterpart-item|version-3",
                ["DELTA_COUNTERPART_SOURCE_PATH"] =
                    Path.Combine(_root, "counterpart.xlsx"),
                ["DELTA_COUNTERPART_SOURCE_SHA256"] = Hash('C'),
                ["DELTA_APPROVED_BASELINE"] = Path.Combine(_root, "SFP.json"),
                ["DELTA_APPROVED_BASELINE_SHA256"] = Hash('D')
            };

        private string[] ScriptArguments() =>
            new[]
            {
                "-SourceFamily", "SFP",
                "-EventId", "event-1",
                "-CorrelationId", "correlation-1",
                "-PreviousSourceIdentity", "previous",
                "-PreviousSourceReference", "site|drive|previous|version-1",
                "-PreviousSourceSha256", Hash('A'),
                "-CurrentSourceIdentity", "current",
                "-CurrentSourceReference", "site|drive|current|version-2",
                "-CurrentSourceSha256", Hash('B'),
                "-CounterpartSourceIdentity", "counterpart",
                "-CounterpartSourceReference", "site|drive|counterpart|version-3",
                "-CounterpartSourceSha256", Hash('C'),
                "-ApprovedBaselineSha256", Hash('D'),
                "-ProjectRoot", ProjectRoot(),
                "-ResultRoot", Path.Combine(_root, "results")
            };

        private static string Hash(char value) => new(value, 64);

        private static string ProjectRoot() =>
            Path.GetFullPath(Path.Combine(
                TestContext.CurrentContext.TestDirectory,
                "..",
                "..",
                ".."));
    }
}
