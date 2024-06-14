public abstract class Activity //Abstract parent class that will be the framework for the 3 activity classes
{
        protected string _name;
        protected string _description;
        protected int _duration;
        public Activity(string name, string description) // Sets up the encapsulation for the varriables to protect them
        {
            _name = name;
            _description = description;
        }
    public void StartActivity() // Main activity start method that will be used by the 3 sub classes
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.WriteLine($"Please enter the activity duration in seconds: ");

        string input = Console.ReadLine();
        if (int.TryParse(input, out int duration) && duration >0)
        {
            Console.WriteLine("Clear your mind, get ready to start...");
            _duration = duration;
            RunActivity();

            Console.WriteLine($"Thank you for completing the {_name} Activity"); // Default response as an activity ends
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number for the menu option."); // Default response when receiving unexpected inputs
        }
    }

    protected abstract void RunActivity(); // Protects the method unless authority override given
}