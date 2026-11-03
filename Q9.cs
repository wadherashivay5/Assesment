using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Questions
{
    public class Q09
    {
        // Validation using out
        static bool ValidateQuantity(string input, out int quantity)
        {
            return int.TryParse(input, out quantity);
        }

        // Stock adjustment using ref
        static bool AdjustStock(ref int stock, int adjustment)
        {
            if (stock + adjustment < 0)
            {
                return false;
            }

            stock += adjustment;
            return true;
        }
        static void AttemptAdjustment(ref int stock, string input, int adjustment)
        {
            Console.WriteLine($"\nStock Before: {stock}");
            Console.WriteLine($"Input Quantity: {input}");
            Console.WriteLine($"Requested Adjustment: {adjustment}");

            if (!ValidateQuantity(input, out int quantity))
            {
                Console.WriteLine("Invalid quantity entered.");
                Console.WriteLine($"Stock After: {stock}");
                return;
            }

            Console.WriteLine($"Validated Quantity: {quantity}");

            bool success = AdjustStock(ref stock, adjustment);

            if (success)
            {
                Console.WriteLine("Adjustment Successful");
            }
            else
            {
                Console.WriteLine("Adjustment Rejected: Stock cannot become negative");
            }

            Console.WriteLine($"Stock After: {stock}");
        }
        public static void Run()
        {
            int stock = 100;

            // Positive adjustment
            AttemptAdjustment(ref stock, "20", 20);

            // Valid reduction
            AttemptAdjustment(ref stock, "30", -30);

            // Excessive reduction
            AttemptAdjustment(ref stock, "150", -150);

            // Invalid input
            AttemptAdjustment(ref stock, "ABC", -10);
        }
    }
}
