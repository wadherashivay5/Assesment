using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Questions
{
    internal class Q02
    {
        public static void Main (string[] args)
        {
        // Sales Array
        int[] sales = { 12500, 9800, 15400, 8700, 19100, 16800, 11200 };
        int sum = 0;

        Console.WriteLine("Enter The Sales Target");
        int target = int.Parse(Console.ReadLine());

            for (int i = 0; i < sales.Length; i++)
            {
                if (sales[i] == target)
                {
                    Console.WriteLine($"Sales Target succefuly met on day {i} !!");
                }
                else if (sales[i] > target)
                {
                    Console.WriteLine($"Sales Target Exceeded on day {i} !!!");
                }
            }
            int high = sales[0];
            int low = sales[1];
            for (int i = 0; i < sales.Length; i++)
            {
                sum += sales[i];
                
                if (sales[i] > high)
                {
                    high = sales[i];
                }
                else if (sales[i] < low)
                {
                    low = sales[i];
                }

            }
            decimal avg = sum / sales.Length;


            Console.WriteLine($"Total Sales : {sum}");
            Console.WriteLine($"Average of week :{avg}");
            Console.WriteLine($"Lowest sales :{low}");
            Console.WriteLine($"Highest Sales :{high}");

            // 4. TEST CASE: Repeated highest values setup
            Console.WriteLine("\n\n=== TEST CASE: REPEATED HIGHEST VALUES ===");

            int[] testSales = { 12500, 9800, 15400, 8700, 22000, 22000, 22000 };

            int testHighest = testSales[0];
            for (int i = 1; i < testSales.Length; i++)
            {
                if (testSales[i] > testHighest)
                {
                    testHighest = testSales[i];
                }
            }

            Console.WriteLine($"Peak test sales record found: {testHighest:C0}");
            Console.WriteLine("Identifying every matching record day:");

            // Loop 2: Identify every matching index location
            for (int i = 0; i < testSales.Length; i++)
            {
                if (testSales[i] == testHighest)
                {
                    Console.WriteLine($"- Match identified on: ({testSales[i]:C0})");
                }
            }
        }   
    }
}
