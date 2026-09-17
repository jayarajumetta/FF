using NUnit.Framework;
using PnCTestAutomation.Models;
using PnCTestAutomation.Services;
using Reqnroll;
using System.Threading.Tasks;

[Binding]
public sealed class ApiSteps
{
    private readonly IApiService _apiService;

    public ApiSteps(IApiService apiService)
    {
        _apiService = apiService;
    }

    [Given(@"user logs in via API")]
    public void LoginViaApi()
    {
        Assert.That(
            _apiService.HasAccessToken,
            Is.True,
            "The API client was not authenticated by the scenario hook.");
    }

    [Given(@"user sends a POST request to Search For Client")]
    public async Task SearchNewOrExistingClient(Table table)
    {
        var row = table.Rows[0];
        var request = new ClientSearchRequest
        {
            FirstName = row["FirstName"],
            LastName = row["LastName"],
            DateOfBirth = row["DOB"],
            EmailAddress = row["Email"],
            PhoneNumber = row["PhoneNumber"]
        };

        var response = await _apiService.PostJsonAsync<ClientSearchRequest, ClientSearchResponse>(
            "apmi/mlsearch/search",
            request,
            ApiRetryMode.IdempotentTransient);

        Assert.Multiple(() =>
        {
            Assert.That(
                response.FirstName,
                Is.EqualTo(request.FirstName),
                "First name does not match");
            Assert.That(
                response.LastName,
                Is.EqualTo(request.LastName),
                "Last name does not match");
        });
    }
}
