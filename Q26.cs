using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Questions.Q26;

namespace Questions
{
    internal class Q26
    {
        public class Employees
        {
            public int EmpId {  get; set; }
            public string Name { get; set; }
            public string Email { get; set; }

            public Employees(int id, string name, string mail) 
            {
                EmpId = id;
                Name = name;
                Email = mail;
                
            }

            public virtual void DisplayDetails()
            {
                Console.WriteLine("ID: " + EmpId + " | Name: " + Name + " | Email: " + Email);
            }
        }
        public class Manager : Employees
        { 
            public string Department { get; set; }
            public int TeamSize { get; set; }

            public Manager(int id, string name, string mail, string department, int teamSize) : base(id, name, mail)
            {
                Department = department;
                TeamSize = teamSize;
            }

            public override void DisplayDetails()
            {
                base.DisplayDetails();
                Console.WriteLine(" -> Management -> Department: " + Department + " | Team Size: " + TeamSize);
            }

        }

        public static void Main (string[] args)
        {
            Employees emp1 = new Employees(101, "Deep", "Deep@company.com");
            Employees emp2 = new Employees(102, "Omkar", "Om@company.com");

            Manager m1 = new Manager(201,"Shivay","shivay@abc.com","Hr",5);
            Manager m2 = new Manager(202,"Shravan","shravan@xyz.com","Logistics",8);

            Employees[] directory = new Employees[] { emp1, emp2, m1, m2 };

            Console.WriteLine("-EMPLOYEE DIRECTORY-");
            for (int i = 0; i < directory.Length; i++)
            {
                directory[i].DisplayDetails();
                Console.WriteLine();
            }
        }
    }
}
