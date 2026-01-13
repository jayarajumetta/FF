using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_POC.Helpers
{
    public static class ApiHelpers
    {
        public static async Task<HttpResponseMessage> SendPostRequestAsync(
       HttpClient httpClient,
       string endpoint,
       string body,
       Dictionary<string, string> headers,
       string? token = null,
       string? cookieHeader = null,
       int maxRetries = 2)
        {
            HttpResponseMessage response = null;

            for (int attempt = 1; attempt <= maxRetries; attempt++)
            {
                var request = new HttpRequestMessage(HttpMethod.Post, endpoint)
                {
                    Content = new StringContent(body, Encoding.UTF8, "application/json")
                };

                // Add headers
                foreach (var header in headers)
                {
                    request.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }

                if (!string.IsNullOrEmpty(token))
                {
                    request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                }

                if (!string.IsNullOrEmpty(cookieHeader))
                {
                    request.Headers.Add("Cookie", cookieHeader);
                }

                // ✅ Diagnostic: Log all request headers
                Console.WriteLine($"Attempt {attempt}: Sending POST request to {endpoint}");
                Console.WriteLine("Request Headers:");
                foreach (var header in request.Headers)
                {
                    Console.WriteLine($"{header.Key}: {string.Join(", ", header.Value)}");
                }

                // Send request
                response = await httpClient.SendAsync(request);
                var content = await response.Content.ReadAsStringAsync();

                Console.WriteLine($"Response Status Code: {response.StatusCode}");
                Console.WriteLine($"Response Content (first 200 chars): {content.Substring(0, Math.Min(content.Length, 200))}");

                // ✅ Check if response is HTML (login page)
                if (!content.TrimStart().StartsWith("<!DOCTYPE html>"))
                {
                    return response; // Success
                }

                Console.WriteLine($"Attempt {attempt}: Response is HTML, retrying...");
                await Task.Delay(1000);
            }

            return response;
        }
    }
    }