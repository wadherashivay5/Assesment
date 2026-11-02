using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Questions
{
    public class Shipment
    {
        public string TrackingId { get; set; }
        public string Status { get; set; }
    }

    public class Question_7
    {
        public static void Run()
        {
            // Strongly typed object accessed through var
            var shipment = new Shipment
            {
                TrackingId = "TRK1001",
                Status = "Delivered"
            };

            Console.WriteLine($"Shipment: {shipment.TrackingId} - {shipment.Status}");

            // Invalid member access on var-based object
            // Console.WriteLine(shipment.Location);
            // Detected at COMPILE TIME because Shipment has no Location property.

            dynamic payload1 = new ExpandoObject();
            payload1.TrackingId = "TRK2001";
            payload1.Status = "In Transit";

            dynamic payload2 = new ExpandoObject();
            payload2.TrackingId = "TRK2002";
            // Status intentionally missing

            dynamic[] payloads = { payload1, payload2 };

            foreach (dynamic payload in payloads)
            {
                try
                {
                    Console.WriteLine(
                        $"TrackingId: {payload.TrackingId}, Status: {payload.Status}");
                }
                catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException ex)
                {
                    Console.WriteLine(
                        $"Missing member detected at RUN TIME: {ex.Message}");

                    Console.WriteLine(
                        $"Processing continues for TrackingId: {payload.TrackingId}");
                }
            }

            Console.WriteLine("\nDetection Summary:");
            Console.WriteLine("var mistake -> Compile Time");
            Console.WriteLine("dynamic mistake -> Run Time");
        }
    }
}
