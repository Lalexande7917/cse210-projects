using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string gradeLetter = Console.ReadLine();
        int grade = int.Parse(gradeLetter);
        
        if (grade >= 90)
        {
            Console.WriteLine("Your grade is an A");
        }
        else if (grade >= 80)
        {
            Console.WriteLine("Your grade is a B");
        }
        else if (grade >= 70)
        {
            Console.WriteLine("Your grade is a C");
        }
        else if (grade >= 60)
        {
            Console.WriteLine("Your grade is a D");
        }
        else
        {
            Console.WriteLine("Your Grade is an F");
        }
    }
}