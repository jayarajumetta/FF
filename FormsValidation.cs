using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace FormsValidation
{
    public class FormItem
    {
        public string name { get; set; }
        public string caption { get; set; }
        public string printDefault { get; set; }
    }

    public class ApiResponse
    {
        public List<FormItem> forms { get; set; }
    }

    public class FormsValidator
    {
        public async Task<ApiResponse> GetFormsFromApi(string policyNumber, string clientId)
        {
            var url = $"https://apigpwga.americannational.com/american-national/qa/clapi/policies/{policyNumber}";
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-ibm-client-id", clientId);
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonSerializer.Deserialize<ApiResponse>(json);
            return apiResponse;
        }

        public List<FormItem> ReadExpectedForms(string csvPath)
        {
            var forms = new List<FormItem>();
            using var reader = new StreamReader(csvPath);
            string header = reader.ReadLine();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var parts = line.Split(',');
                forms.Add(new FormItem
                {
                    name = parts[0],
                    caption = parts[1],
                    printDefault = parts[2]
                });
            }
            return forms;
        }

        public void ValidateForms(List<FormItem> expected, List<FormItem> actual)
        {
            foreach (var exp in expected)
            {
                var match = actual.Find(a => a.name == exp.name && a.caption == exp.caption && a.printDefault == exp.printDefault);
                if (match != null)
                {
                    Console.WriteLine($"PASS: {exp.name} found and matches");
                }
                else
                {
                    Console.WriteLine($"FAIL: {exp.name} not found or does not match");
                }
            }
        }
    }

    // Commented out to avoid multiple Main entry point conflict
    // class Program
    // {
    //     static async Task Main(string[] args)
    //     {
    //         var policyNumber = "4201C2088"; // Example
    //         var clientId = "7142b7b0819eb9be6e2334aa4b51e9f7"; // Example
    //         var csvPath = "expected_forms.csv"; // Path to your expected forms CSV
    //
    //         var validator = new FormsValidator();
    //         var apiResponse = await validator.GetFormsFromApi(policyNumber, clientId);
    //         var expectedForms = validator.ReadExpectedForms(csvPath);
    //         validator.ValidateForms(expectedForms, apiResponse.forms);
    //     }
    // }
}
