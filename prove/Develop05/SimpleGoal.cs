using System;

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points) : base(name, points) { }

    public override int RecordEvent()
    {
        if (!IsCompleted)
        {
            SetIsCompleted(true);
            return Points;
        }
        return 0;
    }
}
