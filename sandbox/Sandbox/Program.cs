using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main()
    {
        Scripture scripture = new Scripture("In the beginning, God created the heavens and the earth.");
        
        Console.WriteLine("Original Text:");
        Console.WriteLine(scripture.GetDisplayText());
        
        scripture.HideRandomWords(3);
        
        Console.WriteLine("\nText with Random Words Hidden:");
        Console.WriteLine(scripture.GetDisplayText());
        
        Console.WriteLine("\nIs Completely Hidden: " + scripture.IsCompletelyHidden());
        
        Console.ReadKey();
    }
}

class Scripture
{
    private List<Word> words;

    public Scripture(string text)
    {
        words = new List<Word>();
        string[] wordArray = text.Split(' ');

        foreach (string wordText in wordArray)
        {
            Word word = new Word(wordText);
            words.Add(word);
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        for (int i = 0; i < numberToHide; i++)
        {
            int index = random.Next(words.Count);
            words[index].Hide();
        }
    }

    public string GetDisplayText()
    {
        StringBuilder displayText = new StringBuilder();
        foreach (Word word in words)
        {
            displayText.Append(word.GetDisplayText());
            displayText.Append(' ');
        }
        return displayText.ToString().Trim();
    }

    public bool IsCompletelyHidden()
    {
        return words.All(word => word.IsHidden());
    }
}

class Word
{
    private string text;
    private bool hidden;

    public Word(string text)
    {
        this.text = text;
        hidden = false;
    }

    public void Hide()
    {
        hidden = true;
    }

    public void Show()
    {
        hidden = false;
    }

    public bool IsHidden()
    {
        return hidden;
    }

    public string GetDisplayText()
    {
        return hidden ? "_________" : text;
    }
}
