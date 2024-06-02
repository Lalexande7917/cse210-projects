using System;
using System.Collections.Generic;
using System.IO;  // Needed for file operations
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Load scriptures from file
        List<Scripture> scriptures = LoadScripturesFromFile("scriptures.txt");

        // Add a default scripture if no scriptures are loaded
        if (scriptures.Count == 0)
        {
            scriptures.Add(new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."));
        }

        // Select a random scripture from the list
        Random random = new Random();
        Scripture scripture = scriptures[random.Next(scriptures.Count)];

        // Loop until all words in the scripture are hidden
        while (!scripture.AllWordsHidden())
        {
            Console.Clear();  // Clear the console screen
            scripture.Display();  // Display the current state of the scripture
            Console.WriteLine("\nPress Enter to hide words, or type quit to exit.");
            string input = Console.ReadLine();
            if (input.Trim().ToLower() == "quit")  // Check if the user wants to quit
            {
                break;
            }
            scripture.HideRandomWords(3);  // Hide 3 random words
        }

        Console.WriteLine("All words are hidden. Program ended.");
    }

    static List<Scripture> LoadScripturesFromFile(string fileName)
    {
        List<Scripture> scriptures = new List<Scripture>();

        // Check if the file exists
        if (File.Exists(fileName))
        {
            var lines = File.ReadAllLines(fileName);
            foreach (var line in lines)
            {
                // Split the line into reference and text parts
                var parts = line.Split(new[] { ": " }, 2, StringSplitOptions.None);
                if (parts.Length == 2)
                {
                    // Find the last space in the reference part to correctly identify the book name
                    var lastSpaceIndex = parts[0].LastIndexOf(' ');
                    var book = parts[0].Substring(0, lastSpaceIndex);
                    var chapterAndVerses = parts[0].Substring(lastSpaceIndex + 1).Split(':');
                    var chapter = int.Parse(chapterAndVerses[0]);
                    var verses = chapterAndVerses[1].Split('-');
                    var startVerse = int.Parse(verses[0]);
                    var endVerse = verses.Length > 1 ? (int?)int.Parse(verses[1]) : null;
                    var reference = endVerse.HasValue ? new Reference(book, chapter, startVerse, endVerse.Value) : new Reference(book, chapter, startVerse);
                    var text = parts[1];
                    scriptures.Add(new Scripture(reference, text));
                }
            }
        }

        return scriptures;
    }
}

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
