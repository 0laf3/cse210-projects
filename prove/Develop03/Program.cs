
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        // Load JSON data from a file
        string jsonFilePath = "scriptures.json";
        List<ScriptureData> scripturesData = LoadScripturesData(jsonFilePath);

        // Randomly choose a scripture
        Random random = new Random();
        ScriptureData randomScriptureData = scripturesData[random.Next(scripturesData.Count)];

        Reference reference = new Reference(randomScriptureData.BookName, randomScriptureData.ChapterNumber, randomScriptureData.StartVerse, randomScriptureData.EndVerse);
        Scripture scripture = new Scripture(reference, randomScriptureData.Text);

        string banner = $"Welcome to the scripture memorizer. Press ENTER to continue or enter 'quit' to stop.\n";
        Console.WriteLine(banner);

        if (Console.ReadLine().ToLower() == "quit")
        {
            Console.WriteLine("Have a great day.");
        }
        else
        {
            bool play = true;

            do
            {
                Console.Clear();
                scripture.GetDisplayText();
                string userInput = Console.ReadLine().ToLower();

                if (userInput == "quit")
                {
                    play = false;
                }
                else
                {
                    Console.Clear();
                    scripture.HideRandomWords(1);
                    scripture.GetDisplayText();

                    if (scripture.IsCompletelyHidden())
                    {
                        play = false;
                    }
                }

            } while (play);
            Console.WriteLine();
            Console.WriteLine("Have a great day.");
        }
    }

    static List<ScriptureData> LoadScripturesData(string jsonFilePath)
    {
        // Read JSON data from file
        string jsonContent = File.ReadAllText(jsonFilePath);

        // Deserialize JSON into a list of ScriptureData objects
        List<ScriptureData> scripturesData = JsonSerializer.Deserialize<List<ScriptureData>>(jsonContent);

        return scripturesData;
    }
}


