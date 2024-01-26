using System;
using System.Text;
class Program
{
    static void Main()
    {
        Reference reference = new Reference("Genesis 1:1");
        Scripture scripture = new Scripture("In the beginning, God created the heavens and the earth.");

        DisplayText("Original Text:", reference, scripture);

        for (int i = 1; i <= 9; i++)
        {
            scripture.HideRandomWords(3);
            DisplayHiddenText(scripture, reference, i);
        }

        Console.WriteLine("\nPress Enter to continue or type 'quit' to finish");
        Console.ReadKey();
    }

    static void DisplayHiddenText(Scripture scripture, Reference reference, int iteration)
    {
        Console.WriteLine($"\nText with Random Words {iteration} Hidden:");
        DisplayText(reference, scripture);
    }

    static void DisplayText(string message, Reference reference, Scripture scripture)
    {
        Console.WriteLine(message);
        Console.WriteLine($"{reference.GetDisplayText()} {scripture.GetDisplayText()}");
    }

    static void DisplayText(Reference reference, Scripture scripture)
    {
        DisplayText(string.Empty, reference, scripture);
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
