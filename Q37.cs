using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Questions
{
    interface IApprovalSummary
    {
        string GetSummary();
    }

    abstract class LeavePolicy
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public LeavePolicy(string employeeId, string employeeName)
        {
            EmployeeId = employeeId;
            EmployeeName = employeeName;
        }

        // Abstract validation method
        public abstract bool ValidateRequest(int days);
    }

    class AnnualLeavePolicy : LeavePolicy, IApprovalSummary
    {
        private const int MaxDays = 20;

        public AnnualLeavePolicy(string employeeId, string employeeName)
            : base(employeeId, employeeName)
        {
        }

        public override bool ValidateRequest(int days)
        {
            if (days <= 0)
                throw new ArgumentException("Leave days must be greater than zero.");

            return days <= MaxDays;
        }

        public string GetSummary()
        {
            return $"Annual Leave Policy - Limit: {MaxDays} days";
        }
    }

    class SickLeavePolicy : LeavePolicy, IApprovalSummary
    {
        private const int MaxDays = 10;

        public SickLeavePolicy(string employeeId, string employeeName)
            : base(employeeId, employeeName)
        {
        }

        public override bool ValidateRequest(int days)
        {
            if (days <= 0)
                throw new ArgumentException("Leave days must be greater than zero.");

            return days <= MaxDays;
        }

        public string GetSummary()
        {
            return $"Sick Leave Policy - Limit: {MaxDays} days";
        }
    }
    public class Question_37
    {
        public static void Run()
        {
            int[] requests = { 0, 5, 25 };

            // Base-class references
            LeavePolicy[] policies =
            {
            new AnnualLeavePolicy("E101", "Shivay"),
            new SickLeavePolicy("E102", "Dhruvika")
            };

            foreach (LeavePolicy policy in policies)
            {
                Console.WriteLine($"\nEmployee: {policy.EmployeeName}");

                foreach (int days in requests)
                {
                    try
                    {
                        bool approved = policy.ValidateRequest(days);

                        Console.WriteLine(
                            $"{days} day(s): {(approved ? "Approved" : "Rejected")}");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(
                            $"{days} day(s): Rejected - {ex.Message}");
                    }
                }
            }

            Console.WriteLine("\nApproval Summaries:");

            // Interface references
            IApprovalSummary[] summaries =
            {
            new AnnualLeavePolicy("E101", "Shivay"),
            new SickLeavePolicy("E102", "Dhruvika")
            };

            foreach (IApprovalSummary summary in summaries)
            {
                Console.WriteLine(summary.GetSummary());
            }
        }
    }
}
