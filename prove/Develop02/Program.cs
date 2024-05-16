using System;
using System.ComponentModel.Design;
using System.Dynamic;
using System.Formats.Asn1;
using System.IO;
using System.Runtime.InteropServices.Marshalling;

public class Entry
{
    public DateTime _date{ get; set; }
    public List<Prompt> _prompts { get; set;}
    public Entry()
    {
        _date = DateTime.Now;
        _prompts = new List<Prompt>();

        AddDefaultPrompts();
    }

    private void AddDefaultPrompts()
    {
        _prompts.Add(new Prompt {_question = "What did you do today?" });
        _prompts.Add(new Prompt {_question = "What made you happy today?" });
        _prompts.Add(new Prompt {_question = "What are you grateful for today?" });
        _prompts.Add(new Prompt {_question = "What do you wish you could do better tommorrow?" });
        _prompts.Add(new Prompt {_question = "What do you regret doing today?" });
    }

    public void SaveToFile()
    {
        string fileName = "entries.txt";
        using (StreamWriter outputFile = new StreamWriter(fileName, append: true))
        {
            outputFile.WriteLine($"Date: {_date}");
            foreach (var prompt in _prompts)
            {
                outputFile.WriteLine($"{prompt._question}");
                outputFile.WriteLine($"{prompt._answer}");
            }
            outputFile.WriteLine(); // Adds an empty line between entries
        }
    }
    public void AddUserAnswers()
    {
        foreach (var prompt in _prompts)
        {
            Console.WriteLine(prompt._question);
            prompt._answer = Console.ReadLine();
        }
    }

}

public class Prompt
{
    public string _question { get; set; }
    public string _answer { get; set; }

}
public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Journal Program!");
        Console.WriteLine("Please Select one of the following Choices");
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save");
        Console.WriteLine("5. Display");
        Console.Write("What would you like to do? ");
        string optionSelection = Console.ReadLine();

        if (int.TryParse(optionSelection, out int option))
        {
            switch (option)
            {
                case 1:
                    WriteNewEntry();
                    break;
                case 2:
                    DisplayEntries();
                    break;
                case 3:
                    Console.WriteLine("Load functionality not implemented yet.");
                    break;
                case 4:
                    Console.WriteLine("Save functionality not implemented yet.");
                    break;
                case 5:
                    Console.WriteLine("Exiting the program.");
                    break;
                default:
                    Console.WriteLine("Invalid option selected. Please Try again.");
                    break;
            }

        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }
    static void WriteNewEntry()
    {
        Entry newEntry = new Entry();
        newEntry.AddUserAnswers();
        newEntry.SaveToFile();
        Console.WriteLine("Entry Saved.");
    }
    static void DisplayEntries()
    {
        string fileName = "entries.txt";
        if (File.Exists(fileName))
        {
            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
        else
        {
            Console.WriteLine("No entries found.");
        }
    }
}