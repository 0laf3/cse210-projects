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
