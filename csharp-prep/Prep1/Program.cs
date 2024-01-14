using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is you name first name?");
        string fistname = Console.ReadLine();
        Console.WriteLine("What is your last name?");
        string lastname = Console.ReadLine();
        Console.WriteLine($"Your name is {lastname}, {fistname} {lastname}.");
    }
}