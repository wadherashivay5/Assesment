using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Questions
{
    class CardPayment
    {
        public string CardNumber { get; set; }

        public CardPayment(string cardNumber)
        {
            CardNumber = cardNumber;
        }
    }

    class WalletPayment
    {
        public string WalletName { get; set; }

        public WalletPayment(string walletName)
        {
            WalletName = walletName;
        }
    }

    class Q08
    {
        static void Main()
        {
            object[] payments =
            {
            new CardPayment("1234-5678-9012"),
            new WalletPayment("Paytm"),
            "Invalid Payment",
            null
        };

            foreach (object payment in payments)
            {
                if (payment is CardPayment card)
                {
                    Console.WriteLine("Card Payment: " + card.CardNumber);
                }
                else if (payment is WalletPayment wallet)
                {
                    Console.WriteLine("Wallet Payment: " + wallet.WalletName);
                }
                else if (payment == null)
                {
                    Console.WriteLine("Null payment");
                }
                else
                {
                    Console.WriteLine("Unsupported payment type");
                }
            }

            object obj = new CardPayment("9999-8888-7777");

            WalletPayment wp = obj as WalletPayment;

            if (wp != null)
            {
                Console.WriteLine(wp.WalletName);
            }
            else
            {
                Console.WriteLine("Safe conversion failed");
            }
        }
    }
}
