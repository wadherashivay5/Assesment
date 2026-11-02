using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Questions
{

    namespace Q11
    {
        public class Customer
        {
            public string Name { get; set; }
            public string Code { get; set; }

            public Customer(string name, string code)
            {
                Name = name;
                Code = code;
            }
        }

        internal class Program
        {
            static void Main(string[] args)
            {
                Customer cust1 = new Customer("John Doe", "C1001");
                Customer cust2 = new Customer("John Doe", "C1001");
                Customer cust3 = cust1;

                Console.WriteLine("=== CUSTOMER OBJECT COMPARISONS ===");
                Console.WriteLine("cust1 == cust2: " + (cust1 == cust2));
                Console.WriteLine("cust1.Equals(cust2): " + cust1.Equals(cust2));
                Console.WriteLine("cust1 == cust3: " + (cust1 == cust3));
                Console.WriteLine("cust1.Equals(cust3): " + cust1.Equals(cust3));

                // EXPLANATION OF OBJECT COMPARISONS:
                // For custom reference types like Customer, both the '==' operator and the '.Equals()' method
                // default to checking "Reference Equality". They look at whether the variables point to the exact same
                // memory address on the heap.
                // - cust1 == cust2 is False because they are two distinct objects occupying different memory locations, 
                //   even though their inner property fields contain identical values.
                // - cust1 == cust3 is True because cust3 is an alias pointing directly to the exact same object location as cust1.

                string rawCode1 = "C1001";
                string rawCode2 = new string(new char[] { 'C', '1', '0', '0', '1' });

                object boxedCode1 = rawCode1;
                object boxedCode2 = rawCode2;

                Console.WriteLine("\n=== STRING AND OBJECT COMPARISONS ===");
                Console.WriteLine("rawCode1 == rawCode2: " + (rawCode1 == rawCode2));
                Console.WriteLine("rawCode1.Equals(rawCode2): " + rawCode1.Equals(rawCode2));
                Console.WriteLine("boxedCode1 == boxedCode2: " + (boxedCode1 == boxedCode2));
                Console.WriteLine("boxedCode1.Equals(boxedCode2): " + boxedCode1.Equals(boxedCode2));

          
            }
        }
    }


}
