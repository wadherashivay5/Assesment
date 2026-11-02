using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Questions
{
    namespace Q23
    {
        public class RoomBooking
        {
            public string Room { get; set; }
            public DateTime StartTime { get; set; }
            public int DurationMinutes { get; set; }
            public string Organizer { get; set; }

            public RoomBooking(string room, DateTime startTime, int durationMinutes, string organizer)
            {
                if (string.IsNullOrWhiteSpace(room))
                {
                    throw new ArgumentException("Room identifier cannot be empty.");
                }
                if (durationMinutes <= 0)
                {
                    throw new ArgumentException("Duration must be a positive number of minutes.");
                }

                Room = room;
                StartTime = startTime;
                DurationMinutes = durationMinutes;
                Organizer = organizer;
            }

            public RoomBooking(string room, DateTime startTime)
                : this(room, startTime, 30, "Unassigned")
            {
            }

            public RoomBooking(string room, DateTime startTime, int durationMinutes)
                : this(room, startTime, durationMinutes, "Unassigned")
            {
            }

            public void DisplayDetails()
            {
                Console.WriteLine("Room: " + Room +
                                  " | Start: " + StartTime.ToString("yyyy-MM-dd HH:mm") +
                                  " | Duration: " + DurationMinutes + " mins" +
                                  " | Organizer: " + Organizer);
            }
        }

        internal class Program
        {
            static void Main(string[] args)
            {
                DateTime baseTime = DateTime.Now;

                RoomBooking b1 = new RoomBooking("Conference Room A", baseTime);
                RoomBooking b2 = new RoomBooking("Boardroom", baseTime.AddHours(1), 60);
                RoomBooking b3 = new RoomBooking("Huddle Space 1", baseTime.AddHours(2), 45, "Rahul Sharma");

                Console.WriteLine("=== MEETING ROOM RESERVATIONS ===");
                b1.DisplayDetails();
                b2.DisplayDetails();
                b3.DisplayDetails();
            }
        }
    }
}
