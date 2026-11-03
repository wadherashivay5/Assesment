using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Questions
{
    public class RoomBooking
    {
        public string Room { get; set; }
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }
        public string Organizer { get; set; }

        // Centralized Validation
        public RoomBooking(string room, DateTime startTime, int duration, string organizer)
        {
            if (string.IsNullOrWhiteSpace(room))
                Console.WriteLine("Room cannot be empty.");

            if (duration <= 0)
                Console.WriteLine("Duration must be positive.");

            Room = room;
            StartTime = startTime;
            Duration = duration;
            Organizer = organizer;
        }

        // Duration and organizer not given
        public RoomBooking(string room, DateTime startTime)
        {
            Room = room;
            StartTime = startTime;
            Duration = 30;
            Organizer = "Unassigned";
        }

        // Organizer not given
        public RoomBooking(string room, DateTime startTime, int duration)
        {
            Room = room;
            StartTime = startTime;
            Duration = duration;
            Organizer = "Unassigned";
        }
        public void Display()
        {
            Console.WriteLine(
                $"Room: {Room}, Start: {StartTime}, Duration: {Duration} mins, Organizer: {Organizer}");
        }
    }

    public class Question_23
    {
        public static void Run()
        {
            // Constructor 1: Room + Start Time
            RoomBooking b1 = new RoomBooking(
                "Conference A",
                new DateTime(2025, 6, 1, 9, 0, 0));

            // Constructor 2: Room + Start Time + Duration
            RoomBooking b2 = new RoomBooking(
                "Conference B",
                new DateTime(2025, 6, 1, 10, 0, 0),
                60);

            // Constructor 3: Room + Start Time + Duration + Organizer
            RoomBooking b3 = new RoomBooking(
                "Conference C",
                new DateTime(2025, 6, 1, 11, 0, 0),
                90,
                "Shivay");

            Console.WriteLine("Booking Details:\n");

            b1.Display();
            b2.Display();
            b3.Display();
        }
    }
}
