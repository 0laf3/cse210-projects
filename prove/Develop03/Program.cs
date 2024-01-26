using System;
using System.Collections.Generic;
using System.Text;
class Program
{
    static void Main()
    {
        Scripture scripture = new Scripture("In the beginning, God created the heavens and the earth.");
        
        Console.WriteLine("Original Text:");
        Console.WriteLine(scripture.GetDisplayText());
        
        scripture.HideRandomWords(3);
        
        Console.WriteLine("\nText with Random Words Hidden:");
        Console.WriteLine(scripture.GetDisplayText());
        
        Console.WriteLine("\nIs Completely Hidden: " + scripture.IsCompletelyHidden());
        
        Reference reference = new Reference("Genesis 1:1");
        Console.WriteLine("\nReference Display Text: " + reference.GetDisplayText());
        
        Console.ReadKey();
    }
}
