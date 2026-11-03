using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Questions
{


    struct Dimensions
    {
        public double Length;
        public double Width;
        public double Height;

        public Dimensions(double length, double width, double height)
        {
            Length = length > 0 ? length : 1;
            Width = width > 0 ? width : 1;
            Height = height > 0 ? height : 1;
        }

        public double CalculateVolume()
        {
            return Length * Width * Height;
        }

        public void Display()
        {
            Console.WriteLine($"Length={Length}, Width={Width}, Height={Height}");
        }
    }

    class Parcel
    {
        public Dimensions Size;

        public Parcel(Dimensions size)
        {
            Size = size;
        }
    }

    class Q16
    {
        static void Main()
        {
            Dimensions d1 = new Dimensions(10, 5, 2);
            Dimensions d2 = d1;

            d2.Length = 20;

            Console.WriteLine("Original Dimensions:");
            d1.Display();
            Console.WriteLine("Volume: " + d1.CalculateVolume());

            Console.WriteLine("Copied Dimensions:");
            d2.Display();
            Console.WriteLine("Volume: " + d2.CalculateVolume());

            Parcel p1 = new Parcel(new Dimensions(8, 4, 2));
            Parcel p2 = p1;

            p2.Size.Length = 15;

            Console.WriteLine("Parcel 1 Dimensions:");
            p1.Size.Display();

            Console.WriteLine("Parcel 2 Dimensions:");
            p2.Size.Display();
        }
    }


}
