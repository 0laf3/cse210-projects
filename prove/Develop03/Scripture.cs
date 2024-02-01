public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        InitializeWords(text);
    }

    private void InitializeWords(string text)
    {
        string[] split = text.Split(" ");
        _words.AddRange(split.Select(word => new Word(word)));
    }

    public void HideRandomWords(int numberToHide)
    {
        if (IsCompletelyHidden())
        {
            return;
        }

        Random random = new Random();

        for (int i = 0; i < numberToHide; i++)
        {
            int indx;

            do
            {
                indx = random.Next(_words.Count);
            } while (_words[indx].IsHidden());

            _words[indx].Hide();
        }
    }

    public string GetDisplayText()
    {
        string banner = $"Welcome to the scripture memorizer. Press ENTER to continue or enter 'quit' to stop.\n";
        Console.WriteLine(banner);
        string text = string.Join(" ", _words.Select(word => word.GetDisplayText()));
        string scripture = $"{_reference.GetDisplayText()}{" "}{text}";
        Console.WriteLine(scripture);

        return scripture;
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }
}
