using System.Net;
using System.Net.Http;
using System.Text;
using NUnit.Framework;
using PnCTestAutomation.Clients;
using PnCTestAutomation.Models;

namespace PnCTestAutomation.UnitTests;

[TestFixture]
public class DuckCreekFormsClientTests
{
    [Test]
    public async Task Http500WithFormsXmlPreservesDuckCreekCompatibility()
    {
        var client = CreateClient(
            HttpStatusCode.InternalServerError,
            "<server><responses /></server>");

        var response = await client.GetFormsAsync(
            "session",
            "manuscript",
            "print-job");

        Assert.That(response, Does.StartWith("<server>"));
    }

    [Test]
    public void NonSupportedStatusFailsWithoutLeakingResponseBody()
    {
        const string sensitiveBody = "password=do-not-log";
        var client = CreateClient(HttpStatusCode.BadGateway, sensitiveBody);

        var exception = Assert.ThrowsAsync<HttpRequestException>(
            async () => await client.GetFormsAsync(
                "session",
                "manuscript",
                "print-job"));

        Assert.That(exception!.ToString(), Does.Not.Contain(sensitiveBody));
    }

    [Test]
    public void HtmlErrorPayloadFailsWithoutLeakingResponseBody()
    {
        const string sensitiveBody = "<html>password=do-not-log</html>";
        var client = CreateClient(
            HttpStatusCode.InternalServerError,
            sensitiveBody);

        var exception = Assert.ThrowsAsync<InvalidOperationException>(
            async () => await client.GetFormsAsync(
                "session",
                "manuscript",
                "print-job"));

        Assert.That(exception!.ToString(), Does.Not.Contain(sensitiveBody));
    }

    private static DuckCreekFormsClient CreateClient(
        HttpStatusCode statusCode,
        string body)
    {
        var handler = new StubHttpMessageHandler(
            new HttpResponseMessage(statusCode)
            {
                Content = new StringContent(body, Encoding.UTF8, "text/xml")
            });
        return new DuckCreekFormsClient(
            new HttpClient(handler),
            new DuckCreekFormsConfig
            {
                ServerBaseUrl = "https://forms.example.test",
                Endpoint = "/forms",
                Username = "configured-user",
                Password = "configured-secret"
            });
    }

    private sealed class StubHttpMessageHandler : HttpMessageHandler
    {
        private readonly HttpResponseMessage _response;

        public StubHttpMessageHandler(HttpResponseMessage response)
        {
            _response = response;
        }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken) =>
            Task.FromResult(_response);
    }
}
