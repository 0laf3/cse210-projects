public class EternalGoal : Goal
{
    public EternalGoal() : base()
    {
    }

    public EternalGoal(StreamReader read) : base(read)
    {
    }

    public override void Complete()
    {
        _isCompleted = false;
        _pointsEarned += _pointsForEachCompletion;
    }

    protected override string GetFriendlyCompleteActionDescription()
    {
        return "each time this habit is repeated";
    }

    protected override string GetFriendlyGoalTypeName()
    {
        return "eternal habit";
    }
}
