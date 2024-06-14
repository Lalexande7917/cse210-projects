using System;

class Program
{
    static void Main(string[] args)
    {
        {   
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the mindfulness program");
                Console.WriteLine("Menu Options: ");
                Console.WriteLine("1. Start breathing activity");
                Console.WriteLine("2. Start reflecting activity");
                Console.WriteLine("3. Start listing activity");
                Console.WriteLine("4. Quit");
                Console.Write("Select a choice from the menu: ");
                string optionSelection = Console.ReadLine();

                if (int.TryParse(optionSelection, out int option))
                {
                    switch (option)
                    {
                        case 1:
                            new BreathingActivity("Breathing", "Regulate your stress by controlling your breath.").StartActivity();
                            break;
                        case 2:
                            new ReflectionActivity().StartActivity();
                            break;
                        case 3:
                            new ListingActivity().StartActivity();
                            break;
                        case 4: 
                            Console.Clear();
                            Console.WriteLine("Quitting the program. Goodbye!");
                            return;
                        default:
                            Console.Clear();
                            Console.WriteLine("Invalid Choice. Please select a valid option.");
                            break;   
                    }
                }
                else
                {   
                    Console.Clear();
                    Console.WriteLine("Invalid input. Please enter a valid number for the menu option.");
                }

                Console.WriteLine("Press any key to return to the menu...");
                Console.ReadKey();
            }    
        }
    }
}
