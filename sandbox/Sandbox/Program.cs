using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main()
    {
        var scripture = new Scripture("In the beginning, God created the heavens and the earth.");

        Console.WriteLine("Original Text:");
        Console.WriteLine(scripture.GetDisplayText());

        scripture.HideRandomWords(3);

        Console.WriteLine("\nText with Random Words Hidden:");
        Console.WriteLine(scripture.GetDisplayText());

        Console.WriteLine("\nIs Completely Hidden: " + scripture.IsCompletelyHidden());

        var reference = new Reference("Genesis 1:1");
        Console.WriteLine("\nReference Display Text: " + reference.GetDisplayText());

        Console.ReadKey();
    }
}

class Scripture
{
    private readonly List<Word> words;

    public Scripture(string text)
    {
        words = text.Split(' ').Select(wordText => new Word(wordText)).ToList();
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        for (int i = 0; i < Math.Min(numberToHide, words.Count); i++)
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
    private readonly string text;
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

    public bool IsHidden()
    {
        return hidden;
    }

    public string GetDisplayText()
    {
        return hidden ? "*****" : text;
    }
}

class Reference
{
    private readonly string referenceText;

    public Reference(string referenceText)
    {
        this.referenceText = referenceText;
    }

    public string GetDisplayText()
    {
        return referenceText;
    }
}
