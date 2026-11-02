namespace Questions
{
    internal class Q01
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== INVOICE VALUE EXCHANGE REPORT ===\n");

            int originalInvoiceNumber = 1001;
            decimal originalTotal = 2499.50m;
            bool originalPaidStatus = true;

            //Boxing
            object boxedInvoiceNumber = originalInvoiceNumber; 
            object boxedTotal = originalTotal;                
            object boxedPaidStatus = originalPaidStatus;      


            //UnBoxing
            int recoveredInvoiceNumber = (int)boxedInvoiceNumber;
            decimal recoveredTotal = (decimal)boxedTotal;
            bool recoveredPaidStatus = (bool)boxedPaidStatus;

            Console.WriteLine("..................................................");


            //CONSOLE REPORT
            Console.WriteLine("{0,-20} | {1,-15} | {2,-15}", "Original Type", "Stored Value", "Recovered Type");
            Console.WriteLine(new string('-', 56));

            Console.WriteLine("{0,-20} | {1,-15} | {2,-15}",
                originalInvoiceNumber.GetType().Name, recoveredInvoiceNumber, recoveredInvoiceNumber.GetType().Name);

            Console.WriteLine("{0,-20} | {1,-15} | {2,-15}",
                originalTotal.GetType().Name, recoveredTotal, recoveredTotal.GetType().Name);

            Console.WriteLine("{0,-20} | {1,-15} | {2,-15}",
                originalPaidStatus.GetType().Name, recoveredPaidStatus, recoveredPaidStatus.GetType().Name);


            //THE DEMONSTRATION CHALLENGE
            Console.WriteLine("\n\nINCORRECT UNBOXING DEMONSTRATION");
            Console.WriteLine("Attempting to unbox an internal 'int' directly into a 'long' variable...");

            try
            {
                long invalidRecoveredValue = (long)boxedInvoiceNumber;
                Console.WriteLine($"Success: {invalidRecoveredValue}");
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine($"\n[Captured Exception]: {ex.Message}");
                Console.WriteLine("\nApplication status: Still Running. Exception was handled gracefully.");
            }
        }
    }
}
