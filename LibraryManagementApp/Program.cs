using LibraryManagementApp.Models;
using Utils.Enums;

namespace LibraryManagementApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user1 = new User("Nurlan", "Nurlans434@gmail.com", Role.Admin);


            Library library = new Library(10);

            while (true)
            {
                Console.WriteLine("\n--- MENU ---");
                Console.WriteLine("1. Add book");
                Console.WriteLine("2. Get book by id");
                Console.WriteLine("3. Get all books");
                Console.WriteLine("4. Delete book by id");
                Console.WriteLine("5. Edit book name");
                Console.WriteLine("6. Filter by page count");
                Console.WriteLine("0. Quit");

                Console.Write("Secim edin: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Add book secildi");
                        break;

                    case 2:
                        Console.WriteLine("Get book by id secildi");
                        break;

                    case 3:
                        Console.WriteLine("Get all books secildi");
                        break;

                    case 4:
                        Console.WriteLine("Delete book by id secildi");
                        break;

                    case 5:
                        Console.WriteLine("Edit book name secildi");
                        break;

                    case 6:
                        Console.WriteLine("Filter by page count secildi");
                        break;

                    case 0:
                        Console.WriteLine("Proqram bitdi.");
                        return;

                    default:
                        Console.WriteLine("Yanlis secim etdiniz.");
                        break;
                }
            }
        }
    }
}
