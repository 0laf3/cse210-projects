// Added logic to ensure that no prompt or question is ever repeated before exhausting the available list.
//I added a Statistics class to keep track of activity counts using a dictionary.
//Modified the ExecuteUserChoice method to increment the count for the chosen activity.
//Added a DisplayStatistics method to show the statistics at the end of the program
//Added an option 5 in the menu to display the statistics at any time.

using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Mindfulness Program\n");

        bool play = true;
        do
        {
            DisplayMenu();
            if (int.TryParse(Console.ReadLine(), out int usrChoice))
            {
                play = ExecuteUserChoice(usrChoice);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }

        } while (play);

        Console.Clear();
        Console.WriteLine("Goodbye");
    }

    static void DisplayMenu()
    {
        Console.WriteLine("Menu Options:");
        Console.WriteLine("1. Start Breathing Activity");
        Console.WriteLine("2. Start Reflecting Activity");
        Console.WriteLine("3. Start Listing Activity");
        Console.WriteLine("4. Quit");
        Console.WriteLine("5. Display Statistics");
        Console.Write("Choose an option from the menu: ");
    }

    static bool ExecuteUserChoice(int usrChoice)
    {
        switch (usrChoice)
        {
            case 1:
                RunActivity(new BreathingActivity());
                Statistics.IncrementActivityCount("Breathing Activity");
                break;
            case 2:
                RunActivity(new ReflectingActivity());
                Statistics.IncrementActivityCount("Reflecting Activity");
                break;
            case 3:
                RunActivity(new ListingActivity());
                Statistics.IncrementActivityCount("Listing Activity");
                break;
            case 4:
                Console.WriteLine("Goodbye");
                return false;
            case 5:
                Statistics.DisplayStatistics();
                break;
            default:
                Console.WriteLine("Invalid choice. Please choose a valid option.");
                break;
        }
        return true;
    }
    static void RunActivity(IActivity activity)
    {
        activity.Run();
    }
}
interface IActivity
{
    void Run();
}