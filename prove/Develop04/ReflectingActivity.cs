
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
