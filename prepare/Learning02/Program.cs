using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "System Admin";
        job1._startYear = 2001;
        job1._endYear = 2010;
        job1._company = "JEGRUPO";

        job1.Display();

        Job job2 = new Job();
        job2._jobTitle = "Web Design";
        job2._startYear = 2008;
        job2._endYear = 2012;
        job2._company = "RedFast";

        job2.Display();


        Resume resume1 = new Resume();
        resume1._name = "Joao Sebastião Capindissa";
        resume1._jobs.Add(job1);
        resume1._jobs.Add(job2);

        resume1.Display();

    }
}