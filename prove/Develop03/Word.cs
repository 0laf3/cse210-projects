public class Word
{
    private string _text;
    private string _initText;

    public Word(string text)
    {
        _initText = text;
        Reset();
    }

    public void Hide()
    {
        _text = new string('_', _text.Length);
    }

    public void Show()
    {
        Reset();
    }

    public bool IsHidden()
    {
        return _text.StartsWith("_");
    }

    public string GetDisplayText()
    {
        return _text;
    }

    private void Reset()
    {
        _text = _initText;
    }
}
