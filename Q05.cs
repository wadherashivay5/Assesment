using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Questions
{
    public class Q05
    {
        public class EmployeeRecord
        {
            public string Name { get; set; }
            public int? Age { get; set; }
            public decimal? Bonus { get; set; }
            public DateTime? JoiningDate { get; set; }

            public EmployeeRecord(string name, int? age, decimal? bonus, DateTime? joiningDate)
            {
                if (age.HasValue && age.Value < 0)
                {
                    throw new ArgumentException("Age cannot be negative.");
                }
                if (bonus.HasValue && bonus.Value < 0)
                {
                    throw new ArgumentException("Bonus cannot be negative.");
                }

                Name = name;
                Age = age;
                Bonus = bonus;
                JoiningDate = joiningDate;
            }

            public void UpdateBonus(decimal? newBonus)
            {
                if (newBonus.HasValue && newBonus.Value < 0)
                {
                    throw new ArgumentException("Bonus cannot be negative.");
                }
                Bonus = newBonus;
            }

            public void Display()
            {
                string ageStr = Age.HasValue ? Age.Value.ToString() : "Not Provided";
                string bonusStr = Bonus.HasValue ? "₹" + Bonus.Value : "Not Provided";
                string dateStr = JoiningDate.HasValue ? JoiningDate.Value.ToString("yyyy-MM-dd") : "Not Provided";

                Console.WriteLine("Name: " + Name + " | Age: " + ageStr + " | Bonus: " + bonusStr + " | Joining Date: " + dateStr);
            }
        }

        public static void Main(string[] args)
        {
            List<EmployeeRecord> employees = new List<EmployeeRecord>();

            employees.Add(new EmployeeRecord("Shivay Wadhera", 25, null, DateTime.Now));
            employees.Add(new EmployeeRecord("Dhruv Sharma", 30, 0m, DateTime.Now.AddDays(-5)));
            employees.Add(new EmployeeRecord("Raj Patel", null, 15000m, null));

            Console.WriteLine("=== INITIAL ONBOARDING RECORDS ===");
            decimal totalKnownBonuses = 0m;
            for (int i = 0; i < employees.Count; i++)
            {
                employees[i].Display();
                if (employees[i].Bonus.HasValue)
                {
                    totalKnownBonuses += employees[i].Bonus.Value;
                }
            }
            Console.WriteLine("Total Known Bonuses: ₹" + totalKnownBonuses);

            Console.WriteLine("\n=== UPDATING INITIAL MISSING VALUE ===");
            Console.WriteLine("Before update:");
            employees[0].Display();

            employees[0].UpdateBonus(8500m);

            Console.WriteLine("After update:");
            employees[0].Display();

            Console.WriteLine("\n=== RECALCULATED BONUS SUMMARY ===");
            totalKnownBonuses = 0m;
            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].Bonus.HasValue)
                {
                    totalKnownBonuses += employees[i].Bonus.Value;
                }
            }
            Console.WriteLine("New Total Known Bonuses: ₹" + totalKnownBonuses);
        }
    }
}
