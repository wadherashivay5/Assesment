using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Questions
{

    namespace Q10
    {
        public class AuditEvent
        {
            public int EventId { get; set; }
            public string Message { get; set; }

            public AuditEvent(int eventId, string message)
            {
                EventId = eventId;
                Message = message;
            }

            public override string ToString()
            {
                return "AuditEvent [ID: " + EventId + ", Message: " + Message + "]";
            }
        }

        internal class Program
        {
            static void Main(string[] args)
            {
                AuditEvent eventInstance1 = new AuditEvent(5001, "User Authentication Success");
                AuditEvent eventInstance2 = new AuditEvent(5001, "User Authentication Success");

                object[] auditTimeline = new object[]
                {
                42,
                1575.50m,
                "System Checkpoint",
                new DateTime(2026, 11, 2),
                eventInstance1
                };

                Console.WriteLine("=== AUDIT TIMELINE EVENT VIEWER ===");
                for (int i = 0; i < auditTimeline.Length; i++)
                {
                    Console.WriteLine("Type: " + auditTimeline[i].GetType().Name +
                                      " | Content: " + auditTimeline[i].ToString());
                }

                Console.WriteLine("\n=== REFERENCE EVALUATION REPORT ===");

                AuditEvent aliasInstance = eventInstance1;
                bool isAliasEqual = (eventInstance1 == aliasInstance);
                Console.WriteLine("Comparison 1 (Same instance reference via alias): " + isAliasEqual);

                bool isSeparateEqual = (eventInstance1 == eventInstance2);
                Console.WriteLine("Comparison 2 (Two separate instances with identical values): " + isSeparateEqual);
            }
        }
    }

}
