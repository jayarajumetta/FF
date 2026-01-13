using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_POC.Models
{
    public class ApiHeaders
    {

        public Dictionary<string, string> GetDefaultHeaders(string? token = null)
        {
            var headers = new Dictionary<string, string>
            {
                { "accept", "application/json" },
                { "content-type", "application/json" },
                { "origin", "https://expertquote-qa.americannational.com" },
                { "referer", "https://expertquote-qa.americannational.com/expertquote/" },
                { "user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/142.0.0.0 Safari/537.36 Edg/142.0.0.0" }
            };

            if (!string.IsNullOrEmpty(token))
            {
                headers.Add("Authorization", $"Bearer {token}");
            }

            return headers;
        }

    }
}
