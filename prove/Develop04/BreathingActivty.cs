
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
