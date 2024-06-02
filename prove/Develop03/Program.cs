using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptures = LoadScripturesFromFile("scriptures.txt");

        if (scriptures.Count == 0)
        {
            scriptures.Add(new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."));
        }

        Random random = new Random();
        Scripture scripture = scriptures[random.Next(scriptures.Count)];

        while (!scripture.AllWordsHidden())
        {
            Console.Clear();
            scripture.Display();
            Console.WriteLine("\nPress Enter to hide words, or type quit to exit. ");
            string input = Console.ReadLine();
            if (input.Trim().ToLower() == "quit")
            {
                break;
            }
            scripture.HideRandomWords(3);
        }

        Console.WriteLine("All words are hidden. Program ended.");
    }

    static List<Scripture> LoadScripturesFromFile(string fileName)
        {
            List<Scripture> scriptures = new List<Scripture>();

            if(File.Exists(fileName))
            {
                var lines = File.ReadAllLines(fileName);
                foreach (var line in lines)
                {
                    var parts = line.Split(new[] { ": " }, 2, StringSplitOptions.None);
                    if (parts.Length == 2)
                    {
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

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    public void Display()
    {
        Console.WriteLine(_reference);
        foreach (var word in _words)
        {
            Console.Write(word.IsHidden ? "____ " : word.Text + " ");
        }
        Console.WriteLine();
    }
    
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

    public Reference(string book, int chapter, int verse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = verse;
        EndVerse = null;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }

    public override string ToString()
    {
        return EndVerse.HasValue ? $"{Book} {Chapter}:{StartVerse}-{EndVerse}" : $"{Book} {Chapter}:{StartVerse}";
    }
}

class Word
{
    public string Text { get; }
    public bool IsHidden { get; private set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public void Hide()
    {
        IsHidden = true;
    }
}