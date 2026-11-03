using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Questions
{
    namespace Q32
    {
        public interface INotifier
        {
            void SendNotification(string recipient, string message);
        }

        public class EmailNotifier : INotifier
        {
            public void SendNotification(string recipient, string message)
            {
                if (string.IsNullOrWhiteSpace(recipient) || string.IsNullOrWhiteSpace(message))
                {
                    throw new ArgumentException("Recipient and message cannot be blank.");
                }
                Console.WriteLine("Channel: Email | Recipient: " + recipient + " | Message: " + message);
            }
        }

        public class SmsNotifier : INotifier
        {
            public void SendNotification(string recipient, string message)
            {
                if (string.IsNullOrWhiteSpace(recipient) || string.IsNullOrWhiteSpace(message))
                {
                    throw new ArgumentException("Recipient and message cannot be blank.");
                }
                Console.WriteLine("Channel: SMS | Recipient: " + recipient + " | Message: " + message);
            }
        }

        internal class Program
        {
            public static void ProcessAlert(INotifier notifier, string recipient, string message)
            {
                notifier.SendNotification(recipient, message);
            }

            static void Main(string[] args)
            {
                INotifier emailChannel = new EmailNotifier();
                INotifier smsChannel = new SmsNotifier();

                Console.WriteLine("=== ALERT DELIVERY PRODUCTION ===");
                ProcessAlert(emailChannel, "admin@company.com", "System disk space running low.");
                ProcessAlert(smsChannel, "+919876543210", "OTP code for login verified.");

                try
                {
                    ProcessAlert(emailChannel, "", "Missing destination text test.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Validation Block Caught: " + ex.Message);
                }
            }
        }
    }
}
