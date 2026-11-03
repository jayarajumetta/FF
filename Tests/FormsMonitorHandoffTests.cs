using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using NUnit.Framework;
using PnCTestAutomation.Tools.FormsBaselineGenerator;

namespace PnCTestAutomation.Tests
{
    [TestFixture]
    public class FormsMonitorHandoffTests
    {
        private const string HashA =
            "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
        private const string HashB =
            "BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB";

        [TestCase("SFP")]
        [TestCase("Common")]
        public void ValidEvent_IsAcceptedForEachSourceFamily(string sourceFamily)
        {
            var service = NewService();

            var receipt = service.ProcessJson(ValidJson(sourceFamily: sourceFamily));

            Assert.Multiple(() =>
            {
                Assert.That(receipt.Status, Is.EqualTo(FormsMonitorReceiptStatus.Accepted));
                Assert.That(receipt.SourceFamily.ToString(), Is.EqualTo(sourceFamily));
                Assert.That(receipt.ContentAnalysisRequired, Is.True);
                Assert.That(receipt.ProcessingKey, Does.Match("^[A-F0-9]{64}$"));
            });
        }

        [TestCase("eventId", "", false, "eventId is required.")]
        [TestCase("eventType", "Unknown", false, "Invalid event JSON")]
        [TestCase("eventType", null, true, "eventType is required.")]
        [TestCase("detectedAt", "not-a-date", false, "Invalid event JSON")]
        [TestCase("canonicalSourceLink", "relative/item.xlsx", false, "canonicalSourceLink must be an absolute HTTPS URI.")]
        [TestCase("currentContentHash", "not-a-hash", false, "currentContentHash must be a 64-character SHA-256 value.")]
        public void InvalidFields_ReturnInvalidEvent(
            string fieldName,
            string value,
            bool remove,
            string expectedError)
        {
            var payload = JsonNode.Parse(ValidJson())!.AsObject();
            if (remove)
                payload.Remove(fieldName);
            else
                payload[fieldName] = value;

            var receipt = NewService().ProcessJson(payload.ToJsonString());

            Assert.Multiple(() =>
            {
                Assert.That(receipt.Status, Is.EqualTo(FormsMonitorReceiptStatus.InvalidEvent));
                Assert.That(receipt.ValidationErrors.Any(error => error.Contains(expectedError)), Is.True);
            });
        }

        [Test]
        public void DuplicateConnectorReplay_ReturnsDuplicateIgnored()
        {
            var service = NewService();
            var payload = ValidJson();

            var accepted = service.ProcessJson(payload);
            var replay = service.ProcessJson(payload);

            Assert.Multiple(() =>
            {
                Assert.That(accepted.Status, Is.EqualTo(FormsMonitorReceiptStatus.Accepted));
                Assert.That(replay.Status, Is.EqualTo(FormsMonitorReceiptStatus.DuplicateIgnored));
                Assert.That(replay.ProcessingKey, Is.EqualTo(accepted.ProcessingKey));
                Assert.That(replay.ExistingProcessingKey, Is.EqualTo(accepted.ProcessingKey));
                Assert.That(replay.ContentAnalysisRequired, Is.False);
            });
        }

        [Test]
        public void MetadataOnlyEvent_WithSameHashDoesNotRequestContentAnalysis()
        {
            var service = NewService();
            var accepted = service.ProcessJson(ValidJson());
            var metadata = service.ProcessJson(ValidJson(
                eventId: "event-2",
                eventType: "MetadataChanged"));

            Assert.Multiple(() =>
            {
                Assert.That(metadata.Status, Is.EqualTo(FormsMonitorReceiptStatus.MetadataOnly));
                Assert.That(metadata.ContentAnalysisRequired, Is.False);
                Assert.That(metadata.ExistingProcessingKey, Is.EqualTo(accepted.ProcessingKey));
                Assert.That(metadata.ProcessingKey, Is.Not.EqualTo(accepted.ProcessingKey));
            });
        }

        [Test]
        public void SameFilenameAndVersion_WithChangedHashCreatesNewContentState()
        {
            var service = NewService();
            service.ProcessJson(ValidJson());

            var changed = service.ProcessJson(ValidJson(
                eventId: "event-2",
                currentHash: HashB));

            Assert.Multiple(() =>
            {
                Assert.That(changed.Status, Is.EqualTo(FormsMonitorReceiptStatus.NewContentState));
                Assert.That(changed.ContentAnalysisRequired, Is.True);
                Assert.That(changed.CurrentContentHash, Is.EqualTo(HashB));
            });
        }

        [Test]
        public void HashPending_IsAcquisitionPendingAndCannotBeContentDuplicate()
        {
            var service = NewService();

            var pending = service.ProcessJson(ValidJson(hashPending: true));
            var acquired = service.ProcessJson(ValidJson(
                eventId: "event-2",
                currentHash: HashA));

            Assert.Multiple(() =>
            {
                Assert.That(pending.Status, Is.EqualTo(FormsMonitorReceiptStatus.AcquisitionPending));
                Assert.That(pending.CurrentContentHash, Is.EqualTo("HASH_PENDING"));
                Assert.That(pending.ContentAnalysisRequired, Is.False);
                Assert.That(acquired.Status, Is.EqualTo(FormsMonitorReceiptStatus.Accepted));
            });
        }

        [Test]
        public void ProcessingContractVersion_ChangesProcessingIdentity()
        {
            var store = new InMemoryFormsMonitorReceiptStore();
            var v1 = new FormsMonitorHandoffService(store, "1.0").ProcessJson(ValidJson());
            var v2 = new FormsMonitorHandoffService(store, "2.0").ProcessJson(ValidJson());

            Assert.Multiple(() =>
            {
                Assert.That(v1.Status, Is.EqualTo(FormsMonitorReceiptStatus.Accepted));
                Assert.That(v2.Status, Is.EqualTo(FormsMonitorReceiptStatus.Accepted));
                Assert.That(v2.ProcessingKey, Is.Not.EqualTo(v1.ProcessingKey));
            });
        }

        [TestCase("clientSecret")]
        [TestCase("accessToken")]
        [TestCase("cookie")]
        [TestCase("serviceConnectionId")]
        public void SecretLikeField_IsRejected(string fieldName)
        {
            var payload = JsonNode.Parse(ValidJson())!.AsObject();
            payload[fieldName] = "do-not-store";

            var receipt = NewService().ProcessJson(payload.ToJsonString());

            Assert.Multiple(() =>
            {
                Assert.That(receipt.Status, Is.EqualTo(FormsMonitorReceiptStatus.InvalidEvent));
                Assert.That(receipt.ValidationErrors.Single(),
                    Does.Contain("Secret-like fields are not allowed").And.Contain(fieldName));
            });
        }

        [Test]
        public void KeyAndSerialization_AreDeterministicAcrossJsonPropertyOrder()
        {
            var firstService = NewService();
            var secondService = NewService();
            var payload = ValidJson();
            using var document = JsonDocument.Parse(payload);
            var reversed = "{" + string.Join(
                ",",
                document.RootElement.EnumerateObject().Reverse().Select(property =>
                    JsonSerializer.Serialize(property.Name) + ":" + property.Value.GetRawText())) + "}";

            var first = firstService.ProcessJson(payload);
            var second = secondService.ProcessJson(reversed);

            Assert.Multiple(() =>
            {
                Assert.That(second.ProcessingKey, Is.EqualTo(first.ProcessingKey));
                Assert.That(
                    FormsMonitorHandoffService.SerializeReceipt(second),
                    Is.EqualTo(FormsMonitorHandoffService.SerializeReceipt(first)));
            });
        }

        private static FormsMonitorHandoffService NewService() =>
            new(new InMemoryFormsMonitorReceiptStore());

        private static string ValidJson(
            string sourceFamily = "SFP",
            string eventId = "event-1",
            string eventType = "ContentModified",
            string currentHash = HashA,
            string priorHash = null,
            bool hashPending = false) =>
            $$"""
            {
              "contractVersion": "1.0",
              "eventId": "{{eventId}}",
              "correlationId": "correlation-1",
              "eventType": "{{eventType}}",
              "sourceFamily": "{{sourceFamily}}",
              "siteId": "site-1",
              "libraryId": "library-1",
              "folderIdentity": "Forms/Masterlists",
              "itemId": "item-1",
              "sharePointVersion": "87.0",
              "sharePointChangeToken": "change-42",
              "eTag": "\"etag-42\"",
              "currentFileName": "SFP Forms Masterlist.xlsx",
              "priorFileName": "SFP Forms Masterlist.xlsx",
              "currentLogicalVersion": "87",
              "priorLogicalVersion": "86",
              "canonicalSourceLink": "https://contoso.sharepoint.com/sites/forms/item.xlsx",
              "detectedAt": "2026-11-03T15:00:00Z",
              "modifiedAt": "2026-11-03T14:59:00Z",
              "modifier": "Forms Owner",
              "currentContentHash": {{(hashPending ? "null" : $"\"{currentHash}\"")}},
              "priorContentHash": {{(priorHash == null ? "null" : $"\"{priorHash}\"")}},
              "hashPending": {{hashPending.ToString().ToLowerInvariant()}},
              "expectedArtifact": "Excel workbook",
              "retrievalMechanism": "SharePoint driveItem content",
              "retrievalReference": "drive-1/item-1",
              "recommendedNextAction": "Acquire workbook"
            }
            """;
    }
}
