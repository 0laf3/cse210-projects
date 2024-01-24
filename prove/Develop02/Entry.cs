public class Entry
{
    public string Date { get; set; }
    public string Mood { get; set; }
    public string PromptText { get; set; }
    public string EntryText { get; set; }

    
    public void Display()
    {
        Console.Write("How would you describe you current mood?\n> ");
        Mood = Console.ReadLine(); 
        
        Console.WriteLine(PromptText);
        Console.Write("> ");
        EntryText = Console.ReadLine();

        DateTime date = DateTime.Now;
        Date = date.ToShortDateString();
    }
}