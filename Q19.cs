using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace Questions
{
    public class Q19
    {
        public class Registration
        {
            public static int RegistrationCount = 0;
            public string StudentName { get; set; }
            public string CourseName { get; set; }

            public Registration(string studentName, string courseName)
            {
                StudentName = studentName;
                CourseName = courseName;
                RegistrationCount++;
            }

            public void DisplayInfo()
            {
                Console.WriteLine("Student: " + StudentName + ", Course: " + CourseName);
            }
        }

        public static void Main(string[] args)
        {
            Registration reg1 = new Registration("Shivay", "C# Programming");
            Registration reg2 = new Registration("Dhruv", "Database Systems");
            Registration reg3 = new Registration("Nikhil", "Web Development");

            Console.WriteLine("- Initial Shared Count -");
            Console.WriteLine("Total Registrations: " + Registration.RegistrationCount);

            Registration aliasReg = reg1;

            aliasReg.CourseName = "Advanced .NET Architecture";

            Console.WriteLine("Trial");
            reg2.DisplayInfo();

            Console.WriteLine("");
            Console.WriteLine("-Displaying Both Views -");
            Console.WriteLine("View via original variable (reg1): ");
            reg1.DisplayInfo();
            Console.WriteLine("View via alias variable (aliasReg): ");
            aliasReg.DisplayInfo();

            Console.WriteLine("");
            Console.WriteLine("- Final Shared Count -");
            Console.WriteLine("Total Registrations: " + Registration.RegistrationCount);
        }
    }
}

