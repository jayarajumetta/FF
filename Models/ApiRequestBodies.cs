using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PnCTestAutomation.Models
{
    internal class ApiRequestBodies
    {
        public static string ClientSearchBody(string firstName, string lastName, string dob, string emailAddress, string phoneNumber)
        {
            return $@"{{
                ""exactSearch"": false,
                ""includePhoneticMatch"": true,
                ""includeAgentGrants"": true,
                ""firstName"": ""{firstName}"",
                ""lastName"": ""{lastName}"",
                ""dateOfBirth"": ""{dob}"",
                ""emailAddress"": ""{emailAddress}"",
                ""phoneNumber"": ""{phoneNumber}""
            }}";
        }
    }
}
