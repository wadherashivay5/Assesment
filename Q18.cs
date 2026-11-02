using System;

namespace Questions
{
    public class Q18
    {
        public class Book
        {
            private bool _isAvailable;
            public string Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }

            public Book(string id, string title, string description)
            {

                Id = id;
                Title = title;
                Description = description;
                _isAvailable = true;
            }

            public void BorrowBook()
            {
                if (!_isAvailable)
                {
                    Console.WriteLine("Error: '" + Title + "' is already borrowed.");
                    return;
                }

                else
                {
                    _isAvailable = false;
                    Console.WriteLine("Success: '" + Title + "' has been borrowed.");
                }
            }

            public void ReturnBook()
            {
                if (_isAvailable)
                {
                    Console.WriteLine("Error: '" + Title + "' is already available in the library.");
                    return;
                }

                _isAvailable = true;
                Console.WriteLine("Success: '" + Title + "' has been returned.");
            }

            public void DisplayStatus()
            {
                Console.WriteLine("Book: " + Title + " [ID: " + Id + "] - Available: " + _isAvailable);
            }
        }

        public static void Main(string[] args)
        {
            Book b1 = new Book("B001", "HyperFocus", "How to master focusing");
            Book b2 = new Book("B002", "The Monk Who Sold His Ferrari", "Story that will inspire you");

            Console.WriteLine("--- Initial Status ---");
            b1.DisplayStatus();
            b2.DisplayStatus();

            Console.WriteLine("\n--- Borrowing Operations ---");
            b1.BorrowBook();
            b1.BorrowBook();

            Console.WriteLine("\n--- Status Check ---");
            b1.DisplayStatus();
            b2.DisplayStatus();

            Console.WriteLine("\n--- Returning Operations ---");
            b1.ReturnBook();
            b1.ReturnBook();
        }
    }
}
