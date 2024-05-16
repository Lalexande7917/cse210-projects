using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int numberToAdd;
        int sum = 0;
        do
        {
            Console.Write("Enter a number: ");
            string num = Console.ReadLine();
            numberToAdd = int.Parse(num);
            if (numberToAdd != 0 )
            {
                numbers.Add(numberToAdd);
                sum += numberToAdd;
            }
        }   while (numberToAdd != 0);
        Console.WriteLine("You entered the following numbers: ");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
        Console.WriteLine($"The sum of all these numbers is: {sum}");
    }
}