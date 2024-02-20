using System;

public class MathAssignment : Assignment
{
    private string _textBookSection;
    private string _problems;

    public MathAssignment(string bookSection, string problems, string studentName, string topic) : base(studentName, topic)
    {
        _textBookSection = bookSection;
        _problems = problems;
    }

    public string GetHomeworkList()
    {
        string homework = $"Section {_textBookSection} Problems {_problems}";
        return homework;
    }
}