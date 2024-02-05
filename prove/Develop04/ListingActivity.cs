
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
