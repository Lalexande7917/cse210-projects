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