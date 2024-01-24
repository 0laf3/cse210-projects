public class PromptGenerator
{
    public List<string> _prompts = new List<string>();

    public PromptGenerator()
    {

    }

    public void AddPrompts()
    {
        _prompts.Add("Who was the most interesting person I interacted with today?");
        _prompts.Add("What was the best part of my day?");
        _prompts.Add("How did I see the hand of the Lord in my life today?");
        _prompts.Add("What was the strongest emotion I felt today?");
        _prompts.Add("If I had one thing I could do over today, what would it be?");
        _prompts.Add("What was the best part about today?");
        _prompts.Add("What was the worst part about today?");
        _prompts.Add("Tell about what you watched today");
        _prompts.Add("Who did you spend the most time with today?");
        _prompts.Add("Write about a memorable experience from your childhood.");
        _prompts.Add("Describe a place you have always wanted to visit.");
        _prompts.Add("Write about a difficult decision you had to make and how you handled it.");
        _prompts.Add("What are your goals for the next year?");
        _prompts.Add("Describe a person who has had a significant impact on your life.");
        _prompts.Add("Write about a book or movie that has inspired you.");
        _prompts.Add("What are your favorite hobbies or activities?");
        _prompts.Add("Describe a challenge you have overcome and what you learned from it.");
        _prompts.Add("Write about a time when you felt proud of yourself.");
        _prompts.Add("What are your fears and how do you deal with them?");
    }

    public string GetRandomPrompt()
    {
        // geneates a random number and stores it as index 
        Console.WriteLine("Welcome to your journal!");
        Console.WriteLine("Each day, a random prompt will be generated for you to write about.");
        Console.WriteLine("Let's get started!");
        Random random = new Random();

        int index = random.Next(1, _prompts.Count) - 1;
        string prompt = _prompts[index];

        return prompt;
    }
}