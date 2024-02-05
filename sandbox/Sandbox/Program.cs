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
        Console.WriteLine("Menu options:");
        Console.WriteLine("1. Start Breathing Activity");
        Console.WriteLine("2. Start Reflecting Activity");
        Console.WriteLine("3. Start Listing Activity");
        Console.WriteLine("4. Quit");
        Console.Write("Choose an option from the menu: ");
    }

    static bool ExecuteUserChoice(int usrChoice)
    {
        switch (usrChoice)
        {
            case 1:
                RunActivity(new BreathingActivity());
                break;
            case 2:
                RunActivity(new ReflectingActivity());
                break;
            case 3:
                RunActivity(new ListingActivity());
                break;
            case 4:
                Console.WriteLine("Goodbye");
                return false;
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

public abstract class Activity : IActivity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }

    public abstract void Run();

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.Write($"Starting the {_name}. {_description}.\nPlease set the duration (seconds): ");

        if (int.TryParse(Console.ReadLine(), out int duration) && duration > 0)
        {
            _duration = duration;
            Console.WriteLine("Get ready!!!");
            ShowSpinner(5);
        }
        else
        {
            Console.WriteLine("Invalid input for duration. Starting with default duration.");
            _duration = 10; // Set default duration
            ShowSpinner(5);
        }
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("Great job!");
        ShowSpinner(3);
        Console.WriteLine($"You've completed the {_name}. Which ran for {_duration} seconds");
        ShowSpinner(5);
        Console.Clear();
    }

    public void ShowSpinner(int seconds)
    {
        List<string> spinner = new List<string> { "|", "/", "-", "\\", "|", "/", "-", "\\" };

        DateTime endTime = DateTime.Now.AddSeconds(seconds);

        while (DateTime.Now < endTime)
        {
            string s = spinner[DateTime.Now.Second % spinner.Count];
            Console.Write(s);
            Thread.Sleep(500);
            Console.Write("\b \b");
        }

        Console.WriteLine();
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}

public class BreathingActivity : Activity
{
    public BreathingActivity(string name = "Breathing Activity", string description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.", int duration = 10) : base(name, description, duration)
    {

    }

    public override void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.Write("Breathe in..");
            ShowCountDown(5);

            Console.WriteLine();

            Console.Write("Breathe out..");
            ShowCountDown(5);
        }

        Console.WriteLine("\n");
        DisplayEndingMessage();
    }
}

public class ListingActivity : Activity
{
    private int _count = 0;
    private readonly List<string> _prompts;

    public ListingActivity(string name = "Listing Activity", string description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", int duration = 60) : base(name, description, duration)
    {
        _prompts = new List<string> { "When have you felt the Holy Ghost this month?", "Who are people that you have helped this week?", "What are personal strengths of yours?", "Who are people that you appreciate?", "Who are some of your personal heroes?" };
    }

    public override void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine(GetRandomPrompt());
        Console.Write("Consider the prompt, then respond with as many entries as you can...");
        ShowCountDown(5);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        Console.WriteLine("\nBegin!!!");

        while (DateTime.Now < endTime)
        {
            GetListFromUser();
            _count++;
        }

        Console.WriteLine($"{_count} items entered.");

        Console.WriteLine("\n");
        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    private List<string> GetListFromUser()
    {
        List<string> list = new List<string>();

        Console.Write("Enter an item: ");
        string entry = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(entry))
        {
            list.Add(entry);
        }

        return list;
    }
}

public class ReflectingActivity : Activity
{
    private readonly List<string> _prompts;
    private readonly List<string> _questions;

    public ReflectingActivity(string name = "Reflecting Activity", string description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.", int duration = 5) : base(name, description, duration)
    {
        _prompts = new List<string> { "Think of a time when you stood up for someone else.", "Think of a time when you did something really difficult.", "Think of a time when you helped someone in need.", "Think of a time when you did something truly selfless." };
        _questions = new List<string> { "How can you keep this experience in mind in the future?", "What did you learn about yourself through this experience?", "What could you learn from this experience that applies to other situations?", "What is your favorite thing about this experience?", "What made this time different than other times when you were not as successful?", "How did you feel when it was complete?", "How did you get started?", "Have you ever done anything like this before?", "Why was this experience meaningful to you?" };
    }

    public override void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Clear();
            Console.WriteLine("Please ponder the following:");
            DisplayPrompt();
            ShowSpinner(4);

            while (DateTime.Now < endTime && _questions.Count > 0)
            {
                DisplayQuestions();
                ShowSpinner(5);
            }
        }

        Console.WriteLine("\n");
        DisplayEndingMessage();
    }

    private void DisplayPrompt()
    {
        Console.WriteLine(GetRandomPrompt());
        Console.WriteLine("-------------------------------------");
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    private string GetRandomQuestion()
    {
        Random random = new Random();
        int index = random.Next(_questions.Count);
        return _questions[index];
    }

    private void DisplayQuestions()
    {
        Console.WriteLine(GetRandomQuestion());
    }
}
