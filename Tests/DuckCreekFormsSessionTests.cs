using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using PnCTestAutomation.Clients;
using PnCTestAutomation.Models;
using PnCTestAutomation.Parsers;

namespace PnCTestAutomation.Tests
{
    [TestFixture]
    public class DuckCreekFormsSessionTests
    {
        private sealed class StubHandler : HttpMessageHandler
        {
            public string RequestBody { get; private set; }
            public string Body { get; set; }
            public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;

            protected override async Task<HttpResponseMessage> SendAsync(
                HttpRequestMessage request, CancellationToken cancellationToken)
            {
                RequestBody = await request.Content.ReadAsStringAsync(cancellationToken);
                return new HttpResponseMessage(StatusCode) { Content = new StringContent(Body) };
            }
        }

        private static DuckCreekFormsClient CreateClient(StubHandler handler) =>
            new(new HttpClient(handler), new DuckCreekFormsConfig
            {
                ServerBaseUrl = "http://localhost",
                Username = "test",
                Password = "test"
            });

        [Test]
        public async Task FormsRequestResumesSessionAndInitializesPrintJob()
        {
            var handler = new StubHandler
            {
                Body = "<server><responses><FormsEngine.initPrintJobRs status=\"success\" /></responses></server>"
            };

            await CreateClient(handler).GetFormsAsync("session&id", "forms-manuscript", "print-job");

            Assert.That(handler.RequestBody, Does.Contain("<Session.resumeRq sessionID=\"session&amp;id\"")
                .And.Contain("<FormsEngine.initPrintJobRq manuscript=\"forms-manuscript\" printJob=\"print-job\"")
                .And.Not.Contain("Session.getElementRq"));
        }

        [Test]
        public void FormsEngineFailureIsReportedEvenIfResponseContainsForms()
        {
            const string xml = """
                <server><responses><Session.resumeRs status="success" />
                <FormsEngine.initPrintJobRs status="failure">Error: System.Xml.XPath.XPathException: Expression must evaluate to a node-set.
                stack details<printJob><printDoc name="FORM1" selected="1" /></printJob>
                </FormsEngine.initPrintJobRs></responses></server>
                """;
            var error = Assert.Throws<InvalidOperationException>(() => FormsXmlParser.Parse(xml));
            Assert.That(error.Message, Does.Contain("Forms Engine returned status='failure'"));
            Assert.That(error.Message, Does.Contain("XPathException"));
            Assert.That(error.Message, Does.Not.Contain("stack details"));
        }

        [Test]
        public void FailedResumeCannotBeAcceptedAsValidForms()
        {
            const string xml = """
                <server><responses><Session.resumeRs status="failure" />
                <FormsEngine.initPrintJobRs status="success"><printJob>
                  <printDoc name="FORM1" selected="1" />
                </printJob></FormsEngine.initPrintJobRs></responses></server>
                """;
            var error = Assert.Throws<InvalidOperationException>(() => FormsXmlParser.Parse(xml));
            Assert.That(error.Message, Does.Contain("failed to resume"));
        }

        [Test]
        public async Task FormsFailureResponseIsSavedBeforeItIsReported()
        {
            var directory = Path.Combine(Path.GetTempPath(), "forms-response-" + Guid.NewGuid().ToString("N"));
            var handler = new StubHandler
            {
                Body = "<server><responses><FormsEngine.initPrintJobRs status=\"failure\">XPathException</FormsEngine.initPrintJobRs></responses></server>"
            };
            var config = new DuckCreekFormsConfig
            {
                ServerBaseUrl = "http://localhost",
                Username = "test",
                Password = "test",
                ResultsBasePath = directory
            };
            var file = Path.Combine(directory, "SFP", "SFP_BASIC_AL_02107676.xml");
            try
            {
                var client = new DuckCreekFormsClient(new HttpClient(handler), config);
                var response = await client.GetFormsAndSaveAsync("session", "SFP", "SFP_BASIC", "AL", "02107676");
                Assert.That(File.Exists(file), Is.True);
                Assert.That(await File.ReadAllTextAsync(file), Is.EqualTo(response));
                Assert.That(Assert.Throws<InvalidOperationException>(() => FormsXmlParser.Parse(response)).Message,
                    Does.Contain("XPathException"));
            }
            finally
            {
                if (File.Exists(file))
                    File.Delete(file);
                if (Directory.Exists(Path.Combine(directory, "SFP")))
                    Directory.Delete(Path.Combine(directory, "SFP"));
                if (Directory.Exists(directory))
                    Directory.Delete(directory);
            }
        }
    }
}
