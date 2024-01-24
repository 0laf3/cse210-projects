using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\nPlease select one of the fllowing choice\n");

        Console.WriteLine("1. Write\n5. Quit\n4. Save\n3. Load\n2. Display\n");
        Console.WriteLine("What Would you Like to do?\n> ");
        string choice = Console.ReadLine();
        while (true)
        {
            switch (choice)
            {
                case "1":
                    Console.WriteLine("White a journal");
                    break;
                case "2":
                    Console.WriteLine("Display Journal");
                    break;
                case "3":
                    Console.WriteLine("Load Journal");
                    break;
                case "4":
                    Console.WriteLine("save journal");
                    break;
                case "5":
                    Console.WriteLine("Goodbaye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}