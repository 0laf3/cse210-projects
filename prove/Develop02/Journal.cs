public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        Console.WriteLine("Entries:");
        foreach (Entry entry in _entries)
        {
            DisplayEntry(entry);
        }
    }

    private static void DisplayEntry(Entry entry)
    {
        Console.WriteLine("");
        Console.WriteLine($"Date: {entry.Date}");
        Console.WriteLine($"Mood: {entry.Mood}");
        Console.WriteLine($"Prompt: {entry.PromptText}");
        Console.WriteLine($"Entry: {entry.EntryText}");
        Console.WriteLine("");
    }

    public void SaveToFile(string file, string separator = "|")
    {
        File.WriteAllLines(file, _entries.Select(entry => $"{entry.Date}{separator}{entry.Mood}{separator}{entry.PromptText}{separator}{entry.EntryText}"));
    }

    public void LoadFromFile(string file, string separator = "|")
    {
        _entries.Clear();

        string[] lines = File.ReadAllLines(file);

        foreach (string line in lines)
        {
            string[] parts = line.Split(separator);

            string date = parts[0];
            string mood = parts[1];
            string prompt = parts[2];
            string entryText = parts[3];

            Entry entry = new Entry
            {
                Date = date,
                Mood = mood,
                PromptText = prompt,
                EntryText = entryText
            };

            AddEntry(entry);
        }
    }
}
