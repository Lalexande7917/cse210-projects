using System;

public class ListingActivity : Activity // Subclass of Activity, Listing exercise to focus on the positives of life
{
    private static readonly string[] Prompts = { // Read only prompts that will be selected at random 
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.") { }
    // Name and description for Listing Ativity using the Activity Class framework
    protected override void RunActivity()
    {
        Random random = new Random(); // implementation of random
        string prompt = Prompts[random.Next(Prompts.Length)]; // Selection of prompts at random

        Console.WriteLine($"Prompt: {prompt}"); // display of prompt, followed by opening message
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
            if (!string.IsNullOrWhiteSpace(input)) // Checks for an entry and adds entry to item counter
                itemCounter++;
        } while (!string.IsNullOrWhiteSpace(input)); // Checks for blank, if nothing is entered it will close out the listing activity

        Console.WriteLine();
        Console.WriteLine($"You listed {itemCounter} items."); // Closing message showing how many thhings were listed

    }
}