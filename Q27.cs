using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions
{
    internal class Q27
    {
        public class OrderLine
        {
            public string ItemName { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
            public string SpecialInstruction { get; set; }

            public OrderLine(string itemName, int quantity, decimal price, string instruction = null)
            {
                ItemName = itemName;
                Quantity = quantity;
                Price = price * quantity;
                SpecialInstruction = instruction;
            }

            public void Display()
            {
                string line = "Item: " + ItemName + " x" + Quantity + " - Total: ₹" + Price;
                Console.WriteLine(line);
            }

        }

        public class OrderSystem
        {
            private Dictionary<string, decimal> _menu = new Dictionary<string, decimal>()
            {
                { "Burger", 150m },
                { "Pizza", 350m },
                { "Pasta", 220m },
                { "Fries", 80m }
            };

            private List<OrderLine> _orderLines = new List<OrderLine>();

            private decimal GetPrice(string itemName)
            {
                if (!_menu.ContainsKey(itemName))
                {
                    return -1m;
                }
                return _menu[itemName];
            }

            // Overload 1: Item alone
            public void AddItem(string itemName)
            {
                AddItem(itemName, 1, null);
            }

            // Overload 2: Item with quantity
            public void AddItem(string itemName, int quantity)
            {
                AddItem(itemName, quantity, null);
            }

            // Overload 3: Item with quantity and special instruction
            public void AddItem(string itemName, int quantity, string specialInstruction)
            {
                decimal itemPrice = GetPrice(itemName);
                if (itemPrice == -1m)
                {
                    Console.WriteLine("Rejected: '" + itemName + "' is not on the menu.");
                    return;
                }

                if (quantity <= 0)
                {
                    Console.WriteLine("Rejected: Quantity for '" + itemName + "' must be greater than zero.");
                    return;
                }

                _orderLines.Add(new OrderLine(itemName, quantity, itemPrice, specialInstruction));
                Console.WriteLine("Accepted: Added " + itemName + " (Qty: " + quantity + ")");
            }

            public void PrintReceipt()
            {
                Console.WriteLine("\n=== RESTAURANT RECEIPT ===");
                decimal finalGrandTotal = 0m;

                for (int i = 0; i < _orderLines.Count; i++)
                {
                    _orderLines[i].Display();
                    finalGrandTotal += _orderLines[i].Price;
                }

                Console.WriteLine(new string('-', 40));
                Console.WriteLine("Grand Total: ₹" + finalGrandTotal);
            }
        }

        public static void Main(string[] args)
        {
            OrderSystem system = new OrderSystem();

            Console.WriteLine("--- Submitting Orders ---");

            // Calling Overload 1
            system.AddItem("Pizza");

            // Calling Overload 2
            system.AddItem("Burger", 2);

            // Calling Overload 3
            system.AddItem("Pasta", 1, "Make it extra spicy");

            // Testing validation filters
            system.AddItem("IceCream");
            system.AddItem("Fries", 0);

            // Displaying the output receipt
            system.PrintReceipt();
        }
    }

}

