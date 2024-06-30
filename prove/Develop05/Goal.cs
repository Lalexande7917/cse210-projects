using System;

public abstract class Goal
{
    public string Name { get; }
    public int Points { get; }
    public bool IsCompleted { get; protected set; }

    public Goal(string name, int points)
    {
        Name = name;
        Points = points;
        IsCompleted = false;
    }

    public abstract int RecordEvent();

    protected void SetIsCompleted(bool value)
    {
        IsCompleted = value;
    }
}
