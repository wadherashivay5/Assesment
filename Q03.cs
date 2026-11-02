using System;

namespace Questions
{
    internal class Q03
    {
        public static void Main(string[] args)
        {
            decimal[,] product = new decimal[3, 4]
                                 { { 12000, 9000, 5000, 7000 },
                                   { 8000, 11000, 6000, 9500 },
                                   { 15000, 7000, 8500, 4000 } };

            int branches = product.GetLength(0);  
            int categories = product.GetLength(1);

            decimal[] branchTotals = new decimal[branches];
            decimal[] categoryTotals = new decimal[categories];

            for (int i = 0; i < branches; i++)
            {
                for (int j = 0; j < categories; j++)
                {
                    branchTotals[i] += product[i, j];     
                    categoryTotals[j] += product[i, j];  
                }
            }


            Console.WriteLine("=== BRANCH PERFORMANCE REPORT ===");
            for (int i = 0; i < branches; i++)
            {
                Console.WriteLine($"Branch {i} Total Sales: ₹{branchTotals[i]}");
            }

            Console.WriteLine("\n=== CATEGORY PERFORMANCE REPORT ===");
            for (int j = 0; j < categories; j++)
            {
                Console.WriteLine($"Category {j} Total Sales: ₹{categoryTotals[j]}");
            }

            int topBranchIndex = 0;
            decimal highestSalesValue = branchTotals[0];

            for (int i = 1; i < branches; i++)
            {
                if (branchTotals[i] > highestSalesValue)
                {
                    highestSalesValue = branchTotals[i];
                    topBranchIndex = i;
                }
            }
            Console.WriteLine($"\n Highest Performing Unit: Branch {topBranchIndex} with a total of ₹{highestSalesValue}");
            Console.WriteLine("\n=== MODIFY DATA CELL ===");

            Console.Write($"Enter Branch Row Index (0 to {branches - 1}): ");
            int rowInput = Convert.ToInt32(Console.ReadLine());

            Console.Write($"Enter Category Column Index (0 to {categories - 1}): ");
            int colInput = Convert.ToInt32(Console.ReadLine());

            // Check if selected coordinate indices fit cleanly inside current array boundaries
            if (rowInput >= 0 && rowInput < branches && colInput >= 0 && colInput < categories)
            {
                Console.Write("Enter new non-negative sales amount: ");
                decimal amountInput = Convert.ToDecimal(Console.ReadLine());

                if (amountInput >= 0)
                {
                    product[rowInput, colInput] = amountInput;
                    Console.WriteLine($"\nSuccessfully updated cell [{rowInput},{colInput}] to ₹{amountInput}");
                }
                else
                {
                    Console.WriteLine("Update aborted: Amount cannot be negative.");
                }
            }
            else
            {
                Console.WriteLine("Update aborted: Selected row or column index out of matrix bounds.");
            }
        }
    }
}
