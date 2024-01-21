using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please select one of the fllowing choice");


        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save");
        Console.WriteLine("5.Quit");
        Console.WriteLine("What Would you Like to do? ");
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