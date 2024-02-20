public abstract class Goal
{
    private string _name = "";
    private string _shortDescription = "";
    protected bool _isCompleted = false;
    protected int _pointsForEachCompletion = 0;
    protected int _pointsEarned = 0;

    public Goal()
    {
        Console.WriteLine($"What is the name of your {GetFriendlyGoalTypeName()}? ");
        _name = Console.ReadLine();

        Console.WriteLine($"What is a short description of your {GetFriendlyGoalTypeName()}? ");
        _shortDescription = Console.ReadLine();

        Console.WriteLine($"Enter the points awarded for {GetFriendlyCompleteActionDescription()}? ");
        _pointsForEachCompletion = Program.SafeParse();
    }

    public Goal(StreamReader read)
    {
        _name = read.ReadLine();
        _shortDescription = read.ReadLine();
        _pointsForEachCompletion = int.Parse(read.ReadLine());
        _isCompleted = bool.Parse(read.ReadLine());
        _pointsEarned = int.Parse(read.ReadLine());
    }

    public int GetPointsEarned() => _pointsEarned;

    public string GetName() => _name;

    public bool IsComplete() => _isCompleted;

    protected string CompletedCheckbox() => _isCompleted ? "[X]" : "[ ]";

    public virtual string GetCompleteDisplayString() => $"{CompletedCheckbox()} {_name} ({_shortDescription})";

    public abstract void Complete();

    protected abstract string GetFriendlyGoalTypeName();

    protected abstract string GetFriendlyCompleteActionDescription();

    public virtual void WriteToStreamWriter(StreamWriter w)
    {
        w.WriteLine(_name);
        w.WriteLine(_shortDescription);
        w.WriteLine(_pointsForEachCompletion);
        w.WriteLine(_isCompleted);
        w.WriteLine(_pointsEarned);
    }
}
