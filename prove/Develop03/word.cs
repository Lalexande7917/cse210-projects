class Word
{
    public string Text { get; }
    public bool IsHidden { get; private set; }

    // Constructor to initialize the word with text
    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    // Method to hide the word
    public void Hide()
    {
        IsHidden = true;
    }
}
