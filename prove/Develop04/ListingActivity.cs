using System;

public class ListingActivity : Activity
{
    private static readonly string[] Prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.") { }

    protected override void RunActivity()
    {
        Random random = new Random();
        string prompt = Prompts[random.Next(Prompts.Length)];

        Console.WriteLine($"Prompt: {prompt}");
        Console.WriteLine($"You have some time to begin thinking about the prompt...");

        Console.WriteLine();
        Console.WriteLine($"Now, keep listing items related to '{prompt}'.");
        Console.WriteLine("When you are done, press Enter.");

        int itemCounter = 0;
        string input;

        do
        {
            Console.Write("Enter an item (or press Enter to finish): ");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                itemCounter++;
        } while (!string.IsNullOrWhiteSpace(input));

        Console.WriteLine();
        Console.WriteLine($"You listed {itemCounter} items.");

    }
}