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
