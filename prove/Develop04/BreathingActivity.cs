using System;

public class BreathingActivity : Activity
{
    public BreathingActivity(string name, string description) : base(name, description) { }

    protected override void RunActivity()
    {
        int timeElapsed = 0;

        while (timeElapsed < _duration)
        {
            Console.Clear();
            Console.WriteLine("Breath in...");
            Utility.Countdown(5);
            timeElapsed += 5;

            if (timeElapsed >= _duration) break;

            Console.Clear();
            Console.WriteLine("Breathe out...");
            Utility.Countdown(5);
            timeElapsed += 5;
        }
        Console.Clear();
        Console.WriteLine("Nicely done! The breathing exercise is now complete.");
    }
}

