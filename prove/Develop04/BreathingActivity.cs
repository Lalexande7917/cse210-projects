using System;

public class BreathingActivity : Activity // Subclass of Activity, breathing exercise to regulate stress
{
    public BreathingActivity(string name, string description) : base(name, description) { }

    protected override void RunActivity()
    {
        int timeElapsed = 0;

        while (timeElapsed < _duration) // Timer utilizing the utility class, counts down from 5 to inhale and exhale, the intervals are easily adjustable
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
        Console.WriteLine("Nicely done! The breathing exercise is now complete."); // Default activity completion message
    }
}

