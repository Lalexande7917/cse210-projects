using System;
using System.Threading;

public class ReflectionActivity : Activity
{
    private static readonly string[] Prompts = {
        "Think about a time when you overcame a significant challenge.",
        "Reflect on a moment when you felt truly proud of yourself.",
        "Recall a situation where you helped someone in need.",
        "Consider a period in your life when you faced a difficult decision.",
        "Think about a goal you achieved through hard work and determination."
    };

    private static readonly string[] Questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity() : base("Reflection", "Reflect on past experiences and think about how you grew because of them.") { }

    protected override void RunActivity()
    {
        Random random = new Random();
        string prompt = Prompts[random.Next(Prompts.Length)];

        Console.WriteLine(prompt);
        Console.WriteLine("Press enter when you are ready to start your reflection on this prompt.");
        Console.ReadLine();

        DateTime startTime = DateTime.Now;
        int durationInSeconds = _duration;
        int questionIndex = 0;

        while ((DateTime.Now - startTime).TotalSeconds < durationInSeconds && questionIndex < Questions.Length)
        {
            string question = Questions[questionIndex];

            Console.Clear();
            Console.WriteLine(prompt);
            Console.WriteLine();
            Console.WriteLine(question);
            Console.WriteLine();

            Console.WriteLine("Press any key for the next question...");

            Console.ReadKey(true);

            questionIndex++;
        }

        Console.Clear();
        Console.WriteLine("Way to go! The reflecting activity is now complete.");
    }
}