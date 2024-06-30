using System;

public class ChecklistGoal : Goal
{
    private int _requiredCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, int points, int requiredCount, int bonusPoints)
        : base(name, points)
    {
        _requiredCount = requiredCount;
        _currentCount = 0;
        _bonusPoints = bonusPoints;
    }

    public int CurrentCount { get => _currentCount; }
    public int RequiredCount { get => _requiredCount; }
    public int BonusPoints { get => _bonusPoints; }

    public void SetCurrentCount(int count)
    {
        _currentCount = count;
    }

    public override int RecordEvent()
    {
        if (!IsCompleted)
        {
            _currentCount++;
            if (_currentCount >= _requiredCount)
            {
                SetIsCompleted(true);
                return Points + _bonusPoints;
            }
            return Points;
        }
        return 0;
    }
}
