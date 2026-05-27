public class Comment
{
    private string _personName;
    private string _text;

    public Comment(string personName, string text)
    {
        _personName = personName;
        _text = text;
    }

    public string GetPersonName()
    {
        return _personName;
    }

    public string GetText()
    {
        return _text;
    }
}