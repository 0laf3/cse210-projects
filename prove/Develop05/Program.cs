public class Program
{
    private static List<Goal> _goals = new List<Goal>();

    public static void Main()
    {
        bool exit = false;

        while (!exit)
        {
            DisplayGoalsAndScore();

            Console.WriteLine("Menu Options:\n 1. Create New Goal\n 2. List Goals\n 3. Save Goals\n 4. Load Goals\n 5. Record Event\n 6. Quit\n Select a choice from the menu: ");
            int choice = SafeParse();
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    CreateGoal();
                    break;
                case 2:
                    DisplayGoalsAndScore();
                    break;
                case 3:
                    SaveGoals();
                    break;
                case 4:
                    LoadGoals();
                    break;
                case 5:
                    RecordEvent();
                    break;
                case 6:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private static void CreateGoal()
    {
        Console.WriteLine("The types of goals are:\n1. Simple Goal\n2. Eternal Goal\n3. Checklist Goal\nEnter your choice: ");
        int choice = SafeParse();

        switch (choice)
        {
            case 1:
                _goals.Add(new SimpleGoal());
                break;
            case 2:
                _goals.Add(new EternalGoal());
                break;
            case 3:
                _goals.Add(new ChecklistGoal());
                break;
            default:
                Console.WriteLine("Invalid choice. Goal creation cancelled.");
                break;
        }
    }

    public static bool AreThereGoalsToRecordEventsFor() => _goals.Any(goal => !goal.IsComplete());

    public static int DisplayGoalsThatAreNotYetCompleteAndReturnMaxIndex()
    {
        int index = 1;
        foreach (Goal goal in _goals.Where(goal => !goal.IsComplete()))
        {
            Console.WriteLine($"{index++}. {goal.GetName()}");
        }
        return index - 1;
    }

    public static Goal GetGoalToCompleteFromOneBasedIndex(int indexToSelect)
    {
        int index = 1;
        foreach (Goal goal in _goals.Where(goal => !goal.IsComplete()))
        {
            if (index == indexToSelect)
            {
                return goal;
            }
            index++;
        }
        return null;
    }

    private static void RecordEvent()
    {
        if (!AreThereGoalsToRecordEventsFor())
        {
            Console.WriteLine("There are no goals available to record events for.");
            return;
        }

        int choice = 0;
        int maxIndex = -1;
        while (choice <= 0 || choice > maxIndex)
        {
            Console.WriteLine("The goals available to complete are:");
            maxIndex = DisplayGoalsThatAreNotYetCompleteAndReturnMaxIndex();

            Console.WriteLine("Which goal did you accomplish? ");
            choice = SafeParse();
        }

        Goal theGoalToComplete = GetGoalToCompleteFromOneBasedIndex(choice);
        System.Diagnostics.Debug.Assert(theGoalToComplete != null);
        theGoalToComplete.Complete();
    }

    private static void DisplayGoalsAndScore()
    {
        Console.Clear();

        int score = 0;
        if (_goals.Count > 0)
        {
            Console.WriteLine("The goals are:");
            foreach (Goal goal in _goals)
            {
                Console.WriteLine(goal.GetCompleteDisplayString());
                score += goal.GetPointsEarned();
            }
        }
        else
        {
            Console.WriteLine("No goals have been created or loaded yet.");
        }

        Console.WriteLine();
        Console.WriteLine($"You have {score} points.");
        Console.WriteLine();
    }

    private static void SaveGoals()
    {
        Console.Write("Enter Filename to save to: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetType().Name);
                goal.WriteToStreamWriter(writer);
            }
        }
    }

    private static void LoadGoals()
    {
        Console.Write("Enter filename to load from: ");
        string filename = Console.ReadLine();
        _goals.Clear();

        using (StreamReader reader = new StreamReader(filename))
        {
            while (!reader.EndOfStream)
            {
                string typeLine = reader.ReadLine();
                switch (typeLine)
                {
                    case "SimpleGoal":
                        _goals.Add(new SimpleGoal(reader));
                        break;
                    case "ChecklistGoal":
                        _goals.Add(new ChecklistGoal(reader));
                        break;
                    case "EternalGoal":
                        _goals.Add(new EternalGoal(reader));
                        break;
                    default:
                        throw new Exception("Unknown type found in file");
                }
            }
        }
    }

    public static int SafeParse()
    {
        if (int.TryParse(Console.ReadLine(), out int result))
        {
            return result;
        }

        Console.WriteLine("Invalid input. Defaulting to 0.");
        return 0;
    }
}
