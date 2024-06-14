using System;
using System.Threading;

public static class Utility // Utility class used for the timer in the breathing activity
{
    public static void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--) //Countdown timer in seconds
        {
            Console.Write(i + " ");
            Thread.Sleep(1000); 
        }
        Console.WriteLine();
    }
}