using System;
using System.Collections.Generic;
using System.IO;

public class EternalQuest
{
    private List<Goal> _goals;
    private int _score;
    private int _level;
    private int _pointsToNextLevel;

    public EternalQuest()
    {
        _goals = new List<Goal>();
        _score = 0;
        _level = 1;
        _pointsToNextLevel = 100;
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RecordEvent(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            int pointsEarned = _goals[goalIndex].RecordEvent();
            _score += pointsEarned;
            CheckLevelUp(pointsEarned);
        }
    }

    private void CheckLevelUp(int pointsEarned)
    {
        if (_score >= _pointsToNextLevel)
        {
            _level++;
            _score -= _pointsToNextLevel;
            _pointsToNextLevel += 100;
            Console.WriteLine($"Congratulations! You've leveled up to Level {_level}!");
        }
    }

    public void DisplayGoals()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Goal goal = _goals[i];
            string status = goal.IsCompleted ? "[X]" : "[ ]";
            if (goal is ChecklistGoal checklistGoal)
            {
                status += $" Completed {checklistGoal.CurrentCount}/{checklistGoal.RequiredCount} times";
            }
            Console.WriteLine($"{i + 1}. {status} {goal.Name}");
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Score: {_score} (Level: {_level})");
    }

    public void Save(string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine(_score);
            writer.WriteLine(_level);
            writer.WriteLine(_pointsToNextLevel);
            foreach (var goal in _goals)
            {
                string goalType = goal.GetType().Name;
                if (goal is ChecklistGoal checklistGoal)
                {
                    writer.WriteLine($"{goalType}|{goal.Name}|{goal.Points}|{goal.IsCompleted}|{checklistGoal.CurrentCount}|{checklistGoal.RequiredCount}|{checklistGoal.BonusPoints}");
                }
                else
                {
                    writer.WriteLine($"{goalType}|{goal.Name}|{goal.Points}|{goal.IsCompleted}");
                }
            }
        }
    }

    public void Load(string filePath)
    {
        if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                _score = int.Parse(reader.ReadLine());
                _level = int.Parse(reader.ReadLine());
                _pointsToNextLevel = int.Parse(reader.ReadLine());
                _goals.Clear();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    string goalType = parts[0];
                    string name = parts[1];
                    int points = int.Parse(parts[2]);
                    bool isCompleted = bool.Parse(parts[3]);

                    if (goalType == nameof(SimpleGoal))
                    {
                        SimpleGoal goal = new SimpleGoal(name, points);
                        goal.GetType().GetProperty("IsCompleted").SetValue(goal, isCompleted);
                        _goals.Add(goal);
                    }
                    else if (goalType == nameof(EternalGoal))
                    {
                        EternalGoal goal = new EternalGoal(name, points);
                        goal.GetType().GetProperty("IsCompleted").SetValue(goal, isCompleted);
                        _goals.Add(goal);
                    }
                    else if (goalType == nameof(ChecklistGoal))
                    {
                        int currentCount = int.Parse(parts[4]);
                        int requiredCount = int.Parse(parts[5]);
                        int bonusPoints = int.Parse(parts[6]);
                        ChecklistGoal goal = new ChecklistGoal(name, points, requiredCount, bonusPoints);
                        goal.SetCurrentCount(currentCount);
                        goal.GetType().GetProperty("IsCompleted").SetValue(goal, isCompleted);
                        _goals.Add(goal);
                    }
                }
            }
        }
    }
}
