using System;

class Program
{
    static void Main(string[] args)
    {
        EternalQuest quest = new EternalQuest();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nEternal Quest Program");
            Console.WriteLine("1. Display Goals");
            Console.WriteLine("2. Add Goal");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Display Score");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    quest.DisplayGoals();
                    break;
                case 2:
                    AddGoal(quest);
                    break;
                case 3:
                    RecordEvent(quest);
                    break;
                case 4:
                    quest.DisplayScore();
                    break;
                case 5:
                    SaveGoals(quest);
                    break;
                case 6:
                    LoadGoals(quest);
                    break;
                case 7:
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void AddGoal(EternalQuest quest)
    {
        Console.WriteLine("Choose goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        int goalType = int.Parse(Console.ReadLine());

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());

        switch (goalType)
        {
            case 1:
                quest.AddGoal(new SimpleGoal(name, points));
                break;
            case 2:
                quest.AddGoal(new EternalGoal(name, points));
                break;
            case 3:
                Console.Write("Enter required count: ");
                int requiredCount = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonusPoints = int.Parse(Console.ReadLine());
                quest.AddGoal(new ChecklistGoal(name, points, requiredCount, bonusPoints));
                break;
            default:
                Console.WriteLine("Invalid goal type. Please try again.");
                break;
        }
    }

    static void RecordEvent(EternalQuest quest)
    {
        quest.DisplayGoals();
        Console.Write("Choose a goal to record an event: ");
        int goalIndex = int.Parse(Console.ReadLine()) - 1;
        quest.RecordEvent(goalIndex);
    }

    static void SaveGoals(EternalQuest quest)
    {
        Console.Write("Enter file path to save goals: ");
        string filePath = Console.ReadLine();
        quest.Save(filePath);
    }

    static void LoadGoals(EternalQuest quest)
    {
        Console.Write("Enter file path to load goals: ");
        string filePath = Console.ReadLine();
        quest.Load(filePath);
    }
}