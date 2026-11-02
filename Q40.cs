using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions
{
    namespace Q40
    {
        public enum VisitStatus
        {
            Pending,
            Completed,
            Cancelled
        }

        public interface IInvoice
        {
            decimal CalculateCharges();
        }

        public abstract class ServiceVisit : IInvoice
        {
            public string VisitId { get; set; }
            public string CustomerName { get; set; }
            public int Hours { get; set; }
            public VisitStatus Status { get; set; }

            public ServiceVisit(string visitId, string customerName, int hours, VisitStatus status)
            {
                VisitId = visitId;
                CustomerName = customerName;
                Hours = hours;
                Status = status;
            }

            public abstract decimal CalculateCharges();
        }

        public class HomeVisit : ServiceVisit
        {
            public HomeVisit(string visitId, string customerName, int hours, VisitStatus status)
                : base(visitId, customerName, hours, status)
            {
            }

            public override decimal CalculateCharges()
            {
                return 300m + (Hours * 200m);
            }
        }

        public class RemoteVisit : ServiceVisit
        {
            public RemoteVisit(string visitId, string customerName, int hours, VisitStatus status)
                : base(visitId, customerName, hours, status)
            {
            }

            public override decimal CalculateCharges()
            {
                return Hours * 150m;
            }
        }

        internal class Program
        {
            static void Main(string[] args)
            {
                ServiceVisit[] workflow = new ServiceVisit[3];
                int count = 0;

                while (count < 3)
                {
                    Console.WriteLine("\n--- Entry " + (count + 1) + " ---");
                    Console.Write("Enter Visit ID: ");
                    string id = Console.ReadLine();

                    Console.Write("Enter Customer Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter Visit Type (1 for Home, 2 for Remote): ");
                    string typeInput = Console.ReadLine();

                    Console.Write("Enter Hours worked: ");
                    string hoursInput = Console.ReadLine();

                    int hours;
                    if (!int.TryParse(hoursInput, out hours) || hours < 1)
                    {
                        Console.WriteLine("Rejected: Hours must be a valid whole number and at least 1.");
                        continue;
                    }

                    if (typeInput == "1")
                    {
                        workflow[count] = new HomeVisit(id, name, hours, VisitStatus.Completed);
                        count++;
                    }
                    else if (typeInput == "2")
                    {
                        workflow[count] = new RemoteVisit(id, name, hours, VisitStatus.Completed);
                        count++;
                    }
                    else
                    {
                        Console.WriteLine("Rejected: Invalid visit type selection.");
                    }
                }

                Console.WriteLine("\n=== SERVICE VISIT BILLING SUMMARY ===");
                for (int i = 0; i < workflow.Length; i++)
                {
                    string typeName = workflow[i] is HomeVisit ? "Home" : "Remote";
                    Console.WriteLine("Type: " + typeName +
                                      " | ID: " + workflow[i].VisitId +
                                      " | Customer: " + workflow[i].CustomerName +
                                      " | Hours: " + workflow[i].Hours +
                                      " | Charge: INR " + workflow[i].CalculateCharges() +
                                      " | Status: " + workflow[i].Status);
                }
            }
        }
    }
}

