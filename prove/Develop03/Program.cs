using System;
class Program
{
    static void Main()
    {
        Reference reference = new Reference("Genesis 1:1");
        Scripture scripture = new Scripture("In the beginning, God created the heavens and the earth.");
        
        Console.WriteLine("Original Text:");
        Console.WriteLine($"{ reference.GetDisplayText()} {scripture.GetDisplayText()}");
        
        scripture.HideRandomWords(3);
        
        Console.WriteLine("\nText with Random Words Hidden:");
        Console.WriteLine($"{ reference.GetDisplayText()} {scripture.GetDisplayText()}");

        scripture.HideRandomWords(3);
        
        Console.WriteLine("\nText with Random Words 2 Hidden:");
        Console.WriteLine($"{ reference.GetDisplayText()} {scripture.GetDisplayText()}");

        scripture.HideRandomWords(3);
        
        Console.WriteLine("\nText with Random Words 3 Hidden:");
        Console.WriteLine($"{ reference.GetDisplayText()} {scripture.GetDisplayText()}");

        scripture.HideRandomWords(3);
        
        Console.WriteLine("\nText with Random Words 4 Hidden:");
        Console.WriteLine($"{ reference.GetDisplayText()} {scripture.GetDisplayText()}");

        scripture.HideRandomWords(3);
        
        Console.WriteLine("\nText with Random Words 5 Hidden:");
        Console.WriteLine($"{ reference.GetDisplayText()} {scripture.GetDisplayText()}");

        scripture.HideRandomWords(3);
        
        Console.WriteLine("\nText with Random Words 6 Hidden:");
        Console.WriteLine($"{ reference.GetDisplayText()} {scripture.GetDisplayText()}");

        scripture.HideRandomWords(3);
        
        Console.WriteLine("\nText with Random Words 7 Hidden:");
        Console.WriteLine($"{ reference.GetDisplayText()} {scripture.GetDisplayText()}");

        scripture.HideRandomWords(3);
        
        Console.WriteLine("\nText with Random Words 8 Hidden:");
        Console.WriteLine($"{ reference.GetDisplayText()} {scripture.GetDisplayText()}");

        scripture.HideRandomWords(3);
        
        Console.WriteLine("\nText with Random Words 9 Hidden:");
        Console.WriteLine($"{ reference.GetDisplayText()} {scripture.GetDisplayText()}");
        
        
        
        Console.WriteLine("\nPress Enter to continue or type 'quit' to finish");
        
        Console.ReadKey();
    }
}
