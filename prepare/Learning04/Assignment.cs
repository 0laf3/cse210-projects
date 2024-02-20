using System;

public class Assignment
{
    private string _studentName;
    private string _topic;

    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    public string GetName()
    {
        return _studentName;
    }

    public string GetSummary()
    {
        string summary = $"Topic for {_studentName}: {_topic}";
        return summary;
    }
}