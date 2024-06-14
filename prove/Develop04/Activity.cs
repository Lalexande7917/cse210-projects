public abstract class Activity
{
        protected string _name;
        protected string _description;
        protected int _duration;
        public Activity(string name, string description)
        {
            _name = name;
            _description = description;
        }
    public void StartActivity()
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

            Console.WriteLine($"Thank you for completing the {_name} Activity");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number for the menu option.");
        }
    }

    protected abstract void RunActivity();
}