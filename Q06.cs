using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Questions
{
    public class Q06
    {
        public static void Main(string[] args)
        {
            var itemCode = "W105";
            var quantity = 45;
            var unitPrice = 129.50m;
            var stockQuantities = new[] { 10, 25, 45, 12, 60 };

            var inventoryValue = quantity * unitPrice;

            Console.WriteLine("=== INITIAL STOCK SNAPSHOT ===");
            Console.WriteLine("itemCode: Type = " + itemCode.GetType().Name + ", Value = " + itemCode);
            Console.WriteLine("quantity: Type = " + quantity.GetType().Name + ", Value = " + quantity);
            Console.WriteLine("unitPrice: Type = " + unitPrice.GetType().Name + ", Value = " + unitPrice);
            Console.WriteLine("stockQuantities: Type = " + stockQuantities.GetType().Name + ", Length = " + stockQuantities.Length);
            Console.WriteLine("inventoryValue: Type = " + inventoryValue.GetType().Name + ", Value = " + inventoryValue);

            quantity = 75;
            stockQuantities[2] = 75;

            var updatedInventoryValue = quantity * unitPrice;

            Console.WriteLine("\n=== UPDATED STOCK SNAPSHOT ===");
            Console.WriteLine("quantity (Updated): Type = " + quantity.GetType().Name + ", Value = " + quantity);
            Console.WriteLine("stockQuantities[2] (Updated): Value = " + stockQuantities[2]);
            Console.WriteLine("inventoryValue (Updated): Value = " + updatedInventoryValue);

            
        }
    }
}
