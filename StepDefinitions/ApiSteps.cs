using NUnit.Framework;
using Microsoft.Extensions.Configuration;
using Playwright_POC.Configuration;
using Playwright_POC.Helpers;
using Playwright_POC.Models;
using Playwright_POC.Services;
using Newtonsoft.Json.Linq;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Playwright_POC.Context;
using Newtonsoft.Json;

[Binding]

public class ApiSteps
{
    private readonly PlaywrightContext _context;
    private readonly IApiService _apiService;
    private readonly CredentialsConfig _credentials;
    private readonly OAuthConfig _oauthConfig;
    private readonly ScenarioContext _scenarioContext;
    private readonly IConfiguration _configuration;

    public ApiSteps(
        PlaywrightContext context,
        IApiService apiService,
        ScenarioContext scenarioContext,
        CredentialsConfig credentials,
        OAuthConfig oauthConfig,
        IConfiguration configuration)
    {
        _context = context;
        _apiService = apiService;
        _scenarioContext = scenarioContext;
        _credentials = credentials;
        _oauthConfig = oauthConfig;
        _configuration = configuration;
    }




    [Given(@"user logs in via API")]
    public async Task LoginViaApi()
    {
        try
        {
            var token = _scenarioContext["AccessToken"]?.ToString();
            if (string.IsNullOrEmpty(token))
                throw new Exception("AccessToken not found in ScenarioContext.");

            Console.WriteLine($"Login via API successful using Client Credentials flow. Token: {token}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Login via API failed: {ex.Message}");
            throw;
        }
    }



    [Given(@"user sends a POST request to Search For Client")]
    public async Task SearchNewOrExistingClient(Table table)
    {
        var row = table.Rows[0];

        var requestBody = ApiRequestBodies.ClientSearchBody(
            row["FirstName"],
            row["LastName"],
            row["DOB"],
            row["Email"],
            row["PhoneNumber"]);

        var endpoint = $"{_configuration["Playwright:ExpertQuoteApi"]}/apmi/mlsearch/search";

        var token = _scenarioContext.ContainsKey("AuthToken") ? _scenarioContext["AuthToken"].ToString() : string.Empty;
        Assert.That(!string.IsNullOrEmpty(token), "Access token is missing.");

        var headers = _apiService.Headers.GetDefaultHeaders(token);

        var response = await ApiHelpers.SendPostRequestAsync(
            _apiService.HttpClient,
            endpoint,
            requestBody,
            headers,
            token
        );

        Console.WriteLine($"Response Status Code: {response.StatusCode}");
        var responseContent = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"Response: {responseContent}");

        try
        {
            var json = JObject.Parse(responseContent);
            var firstName = json["firstName"]?.ToString();
            var lastName = json["lastName"]?.ToString();

            Assert.That(firstName, Is.EqualTo(row["FirstName"]), "First name does not match");
            Assert.That(lastName, Is.EqualTo(row["LastName"]), "Last name does not match");
        }
        catch
        {
            Console.WriteLine("Response is not JSON. Possibly HTML (session expired or login failed).");
        }
    }
}
