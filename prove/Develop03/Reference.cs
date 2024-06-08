class Reference
{
    public string Book { get; }
    public int Chapter { get; }
    public int StartVerse { get; }
    public int? EndVerse { get; }

    // Constructor for a reference with a single verse
    public Reference(string book, int chapter, int verse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = verse;
        EndVerse = null;
    }

    // Constructor for a reference with a range of verses
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }

    // Override ToString method to return the reference in a readable format
    public override string ToString()
    {
        return EndVerse.HasValue ? $"{Book} {Chapter}:{StartVerse}-{EndVerse}" : $"{Book} {Chapter}:{StartVerse}";
    }
}