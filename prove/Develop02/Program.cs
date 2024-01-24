class Program
{
    static void Main(string[] args)
    {
        string divizer = "<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>\n";
        Console.WriteLine($"\n{divizer}");

        Journal journal = new Journal();
        PromptGenerator prompts = new PromptGenerator();
        prompts.AddPrompts();

        bool write = true;

        do
        {
            Entry entry = new Entry();

         
            Console.WriteLine("\nPlease choose one of the following:");
            Console.WriteLine("1. Write\n2. Display\n3. Save\n4. Load\n5. Quit");
            Console.WriteLine("What Would you Like to do?\n> ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        entry.PromptText = prompts.GetRandomPrompt();
                        entry.Display();
                        journal.AddEntry(entry);
                        prompts._prompts.Remove(entry.PromptText);
                        break;

                    case 2:
                        journal.DisplayAll();
                        break;

                    case 3:
                        SaveToFile(journal);
                        break;

                    case 4:
                        LoadFromFile(journal);
                        break;

                    case 5:
                        write = false;
                        Console.WriteLine("\nThank you Goodbaye");
                        Console.WriteLine(divizer);
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nInvalid choice, please enter a number.\n");
            }

        } while (write);
    }

    static void SaveToFile(Journal journal)
    {
        Console.Write("\nfilename: ");
        string file = Console.ReadLine();
        journal.SaveToFile(file);
        Console.WriteLine($"{file} saved successfully\n");
    }

    static void LoadFromFile(Journal journal)
    {
        Console.Write("\nfilename: ");
        string file = Console.ReadLine();
        journal.LoadFromFile(file);
        Console.WriteLine($"{file} successfully loaded\n");
    }
}
