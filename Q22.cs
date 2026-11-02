using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Questions
{
    namespace Q22
    {
        public abstract class InsurancePolicy
        {
            public string PolicyNumber { get; set; }
            public string CustomerName { get; set; }

            public InsurancePolicy(string policyNumber, string customerName)
            {
                if (string.IsNullOrWhiteSpace(policyNumber) || string.IsNullOrWhiteSpace(customerName))
                {
                    throw new ArgumentException("Required details cannot be empty.");
                }
                PolicyNumber = policyNumber;
                CustomerName = customerName;
            }

            public abstract decimal CalculatePremium();
        }

        public class HealthPolicy : InsurancePolicy
        {
            public decimal BasePremium { get; set; }
            public int CoveredMembers { get; set; }

            public HealthPolicy(string policyNumber, string customerName, decimal basePremium, int coveredMembers)
                : base(policyNumber, customerName)
            {
                if (basePremium < 0)
                {
                    throw new ArgumentException("Base premium cannot be negative.");
                }
                if (coveredMembers <= 0)
                {
                    throw new ArgumentException("Covered members count must be positive.");
                }
                BasePremium = basePremium;
                CoveredMembers = coveredMembers;
            }

            public override decimal CalculatePremium()
            {
                return BasePremium + (CoveredMembers * 500m);
            }
        }

        public class MotorPolicy : InsurancePolicy
        {
            public decimal DeclaredVehicleValue { get; set; }

            public MotorPolicy(string policyNumber, string customerName, decimal declaredVehicleValue)
                : base(policyNumber, customerName)
            {
                if (declaredVehicleValue < 0)
                {
                    throw new ArgumentException("Declared vehicle value cannot be negative.");
                }
                DeclaredVehicleValue = declaredVehicleValue;
            }

            public override decimal CalculatePremium()
            {
                return DeclaredVehicleValue * 0.03m;
            }
        }

        internal class Program
        {
            static void Main(string[] args)
            {
                InsurancePolicy[] portfolio = new InsurancePolicy[]
                {
                new HealthPolicy("HP101", "Rahul Sharma", 5000m, 4),
                new MotorPolicy("MP202", "Priya Patel", 600000m)
                };

                Console.WriteLine("=== INSURANCE POLICY PREMIUM SUMMARY ===");
                for (int i = 0; i < portfolio.Length; i++)
                {
                    Console.WriteLine("Policy: " + portfolio[i].PolicyNumber +
                                      " | Holder: " + portfolio[i].CustomerName +
                                      " | Calculated Premium: INR " + portfolio[i].CalculatePremium());
                }
            }
        }
    }
}
}
