public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    public Reference(string book, int chapter, int verse, string v)
    {
        InitializeReference(book, chapter, verse);
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        InitializeReference(book, chapter, startVerse);
        _endVerse = endVerse;
    }

    private void InitializeReference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
    }

    public string GetDisplayText()
    {
        string verseText = _endVerse == 0 ? $"{_verse}" : $"{_verse}-{_endVerse}";
        return $"{_book} {_chapter}:{verseText}";
    }
}
