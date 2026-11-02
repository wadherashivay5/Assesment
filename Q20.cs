using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions
{
    public class Q20
    {
        public class BankAccount
        {
            private decimal _balance;

            public decimal Balance
            {
                get { return _balance; }
            }

            public BankAccount(decimal initialBalance)
            {
                if (initialBalance >= 0)
                {
                    _balance = initialBalance;
                }
            }

            public void Deposit(decimal amount)
            {
                if (amount <= 0)
                {
                    Console.WriteLine("Error: Deposit amount must be positive.");
                    return;
                }

                _balance += amount;
                Console.WriteLine("Successfully deposited " + amount + ". New balance: " + _balance);
            }

            public void Withdraw(decimal amount)
            {
                if (amount <= 0)
                {
                    Console.WriteLine("Error: Withdrawal amount must be positive.");
                    return;
                }

                if (amount > _balance)
                {
                    Console.WriteLine("Error: Insufficient funds for withdrawal of " + amount + ". Current balance: " + _balance);
                    return;
                }

                _balance -= amount;
                Console.WriteLine("Successfully withdrew " + amount + ". New balance: " + _balance);
            }
        }

        public static void Main(string[] args)
        {
            BankAccount acc1 = new BankAccount(1000m);
            BankAccount acc2 = new BankAccount(500m);

            Console.WriteLine("-Initial Balances -");
            Console.WriteLine("Account 1 Balance: " + acc1.Balance);
            Console.WriteLine("Account 2 Balance: " + acc2.Balance);

            Console.WriteLine();
            Console.WriteLine("- Operations on Account 1 -");
            acc1.Deposit(250m);
            acc1.Withdraw(100m);
            acc1.Withdraw(2000m);

            Console.WriteLine();
            Console.WriteLine("-Operations on Account 2 -");
            acc2.Withdraw(150m);
            acc2.Deposit(-50m);

            Console.WriteLine() ;
            Console.WriteLine("- Final Independent Balances -");
            Console.WriteLine("Account 1 Balance: " + acc1.Balance);
            Console.WriteLine("Account 2 Balance: " + acc2.Balance);

            
        }
    }
}

