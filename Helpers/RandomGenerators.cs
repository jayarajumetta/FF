using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_POC.Helpers
{
    public class RandomGenerators
    {
        public static string GenerateRandomSSN()
        {
            Random random = new Random();

            int part1 = random.Next(100, 899); // First three digits
            int part2 = random.Next(10, 99);   // Middle two digits
            int part3 = random.Next(1000, 9999); // Last four digits

            return $"{part1}-{part2}-{part3}";
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
            var rnd = new Random();
            int index = rnd.Next(MaleFirstNames.Length);
            return MaleFirstNames[index];
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
            var rnd = new Random();
            int index = rnd.Next(LastNames.Length);
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
            var rnd = new Random();
            int index = rnd.Next(FemaleFirstNames.Length);
            return FemaleFirstNames[index];
        }

    }
}
