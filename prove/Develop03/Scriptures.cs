class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    // Constructor to initialize the scripture with a reference and text
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    // Display the scripture with hidden words represented by underscores
    public void Display()
    {
        Console.WriteLine(_reference);
        foreach (var word in _words)
        {
            Console.Write(word.IsHidden ? "____ " : word.Text + " ");
        }
        Console.WriteLine();
    }

    // Hide a specified number of random words
    public void HideRandomWords(int count)
    {
        Random random = new Random();
        for (int i = 0; i < count; i++)
        {
            var visibleWords = _words.Where(w => !w.IsHidden).ToList();
            if (visibleWords.Count == 0)
                break;
            var wordToHide = visibleWords[random.Next(visibleWords.Count)];
            wordToHide.Hide();
        }
    }

    // Check if all words are hidden
    public bool AllWordsHidden()
    {
        return _words.All(w => w.IsHidden);
    }
}