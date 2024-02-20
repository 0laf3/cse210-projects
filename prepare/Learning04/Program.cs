using System;

class Program
{
    static void Main(string[] args)
    {
        MathAssignment assignment = new MathAssignment("6", "6-10", "Velem Rath", "Mensuration");
        Console.WriteLine(assignment.GetSummary());
        Console.WriteLine(assignment.GetHomeworkList());

        Console.WriteLine();

        WritingAssignment assignment1 = new WritingAssignment("Mary Poppins", "LowKey Magic 101", "Housekeeping down right");
        Console.WriteLine(assignment1.GetSummary());
        Console.WriteLine(assignment1.GetWritingInfo());

    }
}