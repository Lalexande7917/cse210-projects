using System;

class Program
{
    static void Main(string[] args)
    {
        {   
            while (true)
            { // Activity menu to choose which activity you would like to do
                Console.Clear();
                Console.WriteLine("Welcome to the mindfulness program");
                Console.WriteLine("Menu Options: ");
                Console.WriteLine("1. Start breathing activity");
                Console.WriteLine("2. Start reflecting activity");
                Console.WriteLine("3. Start listing activity");
                Console.WriteLine("4. Quit");
                Console.Write("Select a choice from the menu: ");
                string optionSelection = Console.ReadLine();

                if (int.TryParse(optionSelection, out int option)) // Parses out the strings as integers for the activity selections
                {
                    switch (option)
                    {
                        case 1:
                            new BreathingActivity("Breathing", "Regulate your stress by controlling your breath.").StartActivity();
                            break; // Runs through the Breathing activity if selected, and then returns back to the menu
                        case 2:
                            new ReflectionActivity().StartActivity();
                            break; // Runs through the Reflection Activity if selected and then returns back to the menu
                        case 3:
                            new ListingActivity().StartActivity();
                            break; // Runs through the Listing Activity if selected and then returns back to the menu
                        case 4: 
                            Console.Clear();
                            Console.WriteLine("Quitting the program. Goodbye!");
                            return; // Quits the program
                        default:
                            Console.Clear();
                            Console.WriteLine("Invalid Choice. Please select a valid option.");
                            break; // Default response if any unexpected inputs are given
                    }
                }
                else
                {   
                    Console.Clear();
                    Console.WriteLine("Invalid input. Please enter a valid number for the menu option.");
                }

                Console.WriteLine("Press any key to return to the menu...");
                Console.ReadKey(); // Waits for key press at the end of each activity to return to the menu
            }    
        }
    }
}
