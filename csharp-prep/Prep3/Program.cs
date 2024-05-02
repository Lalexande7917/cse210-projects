using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is the magic number? ");
        string magicNumber = Console.ReadLine();
        int num = int.Parse(magicNumber);

        int guess;
        do 
        {
        Console.Write("What is your guess? ");
        string g = Console.ReadLine();
        guess = int.Parse(g);


            if (guess > num)
            {
                Console.WriteLine("The number is Lower");
            }
            else if (guess < num)
            {
                Console.WriteLine("The number is Higher");
            }
            else
            {
                Console.WriteLine("You have guessed the correct number! ");
            }
        } while (guess != num);
    }
}