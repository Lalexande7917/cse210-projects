using System;
using System.IO;

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