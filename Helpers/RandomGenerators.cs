using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PnCTestAutomation.Helpers
{
    /// <summary>
    /// Provides random data generation methods for test automation.
    /// </summary>
    /// <remarks>
    /// Supported tokens in feature files:
    /// - {{firstName}} - Random male first name with "PW" prefix (also accepts legacy {{male}})
    /// - {{lastName}} - Random last name (also accepts legacy {{random}})
    /// - {{randomDOB}} - Random DOB for person aged 21-65
    /// - {{randomPhone}} - Random US phone number
    /// - {{randomEmail}} - Random email address
    /// - {{randomSSN}} - Random SSN in XXX-XX-XXXX format
    ///
    /// Note: First names are prefixed with "PW" (e.g., "PWMichael") to identify
    /// automated test records in the system.
    /// </remarks>
    public static class RandomGenerators
    {
        /// <summary>
        /// Prefix added to first names to identify Playwright test records.
        /// Change to "Playwright" for full prefix, or "" for no prefix.
        /// </summary>
        private const string TestNamePrefix = "PW";

        /// <summary>
        /// Generates a random SSN in XXX-XX-XXXX format.
        /// Note: This is for testing purposes only - not a valid SSN.
        /// </summary>
        public static string GenerateRandomSSN()
        {
            // 666 is the Lexis Nexis test SSN prefix — required for Dev env CLAS lookup, safe on QA too.
            int part2 = Random.Shared.Next(10, 99);     // Middle two digits
            int part3 = Random.Shared.Next(1000, 9999); // Last four digits

            return $"666-{part2:D2}-{part3}";
        }

        /// <summary>
        /// Resolves SSN token or returns literal value.
        /// Supports: {{randomSSN}}
        /// </summary>
        public static string ResolveSSNToken(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return value;

            if (string.Equals(value.Trim(), "{{randomSSN}}", StringComparison.OrdinalIgnoreCase))
                return GenerateRandomSSN();

            return value;
        }


        // List of Male First Names for random generation

        private static readonly string[] MaleFirstNames = new[]
        {
            "James", "John", "Robert", "Michael", "William", "David", "Richard", "Joseph", "Thomas", "Charles",
            "Christopher", "Daniel", "Matthew", "Anthony", "Mark", "Donald", "Steven", "Paul", "Andrew", "Joshua",
            "Kevin", "Brian", "George", "Edward", "Ronald", "Timothy", "Jason", "Jeffrey", "Ryan", "Jacob"
    // Add more names as needed
        };

        public static string GenerateRandomFirstName()
        {
            int index = Random.Shared.Next(MaleFirstNames.Length);
            return $"{TestNamePrefix}{MaleFirstNames[index]}";
        }

        // List of Last Names for random generation

        public static readonly string[] LastNames = new[]
        {
            "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Rodriguez", "Martinez",
            "Hernandez", "Lopez", "Gonzalez", "Wilson", "Anderson", "Thomas", "Taylor", "Moore", "Jackson", "Martin",
            "Lee", "Perez", "Thompson", "White", "Harris", "Sanchez", "Clark", "Ramirez", "Lewis", "Robinson",
            "Walker", "Young", "Allen", "King", "Wright", "Scott", "Torres", "Nguyen", "Hill", "Flores"
        };

        public static string GenerateRandomLastName()
        {
            int index = Random.Shared.Next(LastNames.Length);
            return LastNames[index];
        }

        // List of Female First Names for random generation

        public static readonly string[] FemaleFirstNames = new[]
        {
            "Mary", "Patricia", "Jennifer", "Linda", "Elizabeth", "Barbara", "Susan", "Jessica", "Sarah", "Karen",
            "Nancy", "Lisa", "Margaret", "Betty", "Sandra", "Ashley", "Dorothy", "Kimberly", "Emily", "Donna",
            "Michelle", "Carol", "Amanda", "Melissa", "Deborah", "Stephanie", "Rebecca", "Laura", "Sharon", "Cynthia",
            "Kathleen", "Amy", "Shirley", "Angela", "Helen", "Anna", "Brenda", "Pamela", "Nicole", "Emma"
        };

        public static string GenerateRandomFemaleFirstName()
        {
            int index = Random.Shared.Next(FemaleFirstNames.Length);
            return $"{TestNamePrefix}{FemaleFirstNames[index]}";
        }

        /// <summary>
        /// Generates a random DOB for a person between 21 and 65 years old.
        /// Returns date in MM/dd/yyyy format.
        /// </summary>
        public static string GenerateRandomDOB(int minAge = 21, int maxAge = 65)
        {
            int age = Random.Shared.Next(minAge, maxAge + 1);

            // Calculate birth year based on age
            var today = DateTime.Today;
            int birthYear = today.Year - age;

            // Random month and day
            int month = Random.Shared.Next(1, 13);
            int maxDay = DateTime.DaysInMonth(birthYear, month);
            int day = Random.Shared.Next(1, maxDay + 1);

            var dob = new DateTime(birthYear, month, day);

            // Ensure the person is actually within the age range
            var ageAtToday = today.Year - dob.Year;
            if (dob > today.AddYears(-ageAtToday)) ageAtToday--;

            if (ageAtToday < minAge || ageAtToday > maxAge)
            {
                // Adjust if edge case
                dob = today.AddYears(-Random.Shared.Next(minAge, maxAge + 1));
            }

            return dob.ToString("MM/dd/yyyy");
        }

        /// <summary>
        /// Generates a realistic looking US phone number in (XXX) XXX-XXXX format.
        /// Uses valid area codes and avoids reserved number patterns.
        /// </summary>
        public static string GenerateRandomPhoneNumber()
        {
            // Common valid US area codes
            int[] areaCodes = { 201, 202, 205, 206, 207, 208, 209, 210, 212, 213, 214, 215, 216, 217, 218, 219,
                                224, 225, 228, 229, 231, 234, 239, 240, 248, 251, 252, 253, 254, 256, 260, 262,
                                267, 269, 270, 272, 276, 281, 301, 302, 303, 304, 305, 307, 308, 309, 310, 312,
                                313, 314, 315, 316, 317, 318, 319, 320, 321, 323, 325, 330, 331, 334, 336, 337,
                                339, 347, 351, 352, 360, 361, 385, 386, 401, 402, 404, 405, 406, 407, 408, 409,
                                410, 412, 413, 414, 415, 417, 419, 423, 424, 425, 430, 432, 434, 435, 440, 442,
                                443, 469, 470, 475, 478, 479, 480, 484, 501, 502, 503, 504, 505, 507, 508, 509,
                                510, 512, 513, 515, 516, 517, 518, 520, 530, 540, 541, 551, 559, 561, 562, 563,
                                567, 570, 571, 573, 574, 575, 580, 585, 586, 601, 602, 603, 605, 606, 607, 608,
                                609, 610, 612, 614, 615, 616, 617, 618, 619, 620, 623, 626, 630, 631, 636, 641,
                                646, 650, 651, 657, 660, 661, 662, 678, 681, 682, 701, 702, 703, 704, 706, 707,
                                708, 712, 713, 714, 715, 716, 717, 718, 719, 720, 724, 727, 731, 732, 734, 737,
                                740, 747, 754, 757, 760, 762, 763, 765, 770, 772, 773, 774, 775, 779, 781, 785,
                                786, 801, 802, 803, 804, 805, 806, 808, 810, 812, 813, 814, 815, 816, 817, 818,
                                828, 830, 831, 832, 843, 845, 847, 848, 850, 856, 857, 858, 859, 860, 862, 863,
                                864, 865, 870, 872, 878, 901, 903, 904, 906, 907, 908, 909, 910, 912, 913, 914,
                                915, 916, 917, 918, 919, 920, 925, 928, 931, 936, 937, 940, 941, 947, 949, 951,
                                952, 954, 956, 970, 971, 972, 973, 978, 979, 980, 984, 985 };

            int areaCode = areaCodes[Random.Shared.Next(areaCodes.Length)];

            // Exchange code (first digit cannot be 0 or 1)
            int exchange = Random.Shared.Next(200, 999);

            // Subscriber number
            int subscriber = Random.Shared.Next(1000, 9999);

            return $"({areaCode}) {exchange}-{subscriber}";
        }

        /// <summary>
        /// Generates a fake email address using first name, last name, and random domain.
        /// </summary>
        public static string GenerateRandomEmail(string firstName = null, string lastName = null)
        {
            // Use provided names or generate random ones
            firstName = firstName ?? GenerateRandomFirstName();
            lastName = lastName ?? GenerateRandomLastName();

            // Remove spaces/special characters so local-part remains valid when names include labels.
            var safeFirst = new string(firstName.Where(char.IsLetterOrDigit).ToArray());
            var safeLast = new string(lastName.Where(char.IsLetterOrDigit).ToArray());

            if (string.IsNullOrWhiteSpace(safeFirst))
                safeFirst = GenerateRandomFirstName();
            if (string.IsNullOrWhiteSpace(safeLast))
                safeLast = GenerateRandomLastName();

            // Common fake email domains
            string[] domains = { "testmail.com", "fakemail.org", "example.com", "mailtest.net",
                                 "testuser.io", "mockmail.com", "tempmail.org", "demomail.com" };

            // Email patterns
            string[] patterns = {
                $"{safeFirst.ToLower()}.{safeLast.ToLower()}",
                $"{safeFirst.ToLower()}{safeLast.ToLower()}",
                $"{safeFirst.ToLower()[0]}{safeLast.ToLower()}",
                $"{safeFirst.ToLower()}.{safeLast.ToLower()}{Random.Shared.Next(1, 99)}",
                $"{safeFirst.ToLower()}{Random.Shared.Next(100, 999)}"
            };

            string localPart = patterns[Random.Shared.Next(patterns.Length)];
            string domain = domains[Random.Shared.Next(domains.Length)];

            return $"{localPart}@{domain}";
        }

    }
}
