public class ChecklistGoal : Goal
{
    private int _completedCount;
    private int _targetCount;
    private int _bonus;

    public ChecklistGoal(
        string name,
        string description,
        int points,
        int targetCount,
        int bonus)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonus = bonus;
        _completedCount = 0;
    }

    public ChecklistGoal(
        string name,
        string description,
        int points,
        int targetCount,
        int bonus,
        int completedCount)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonus = bonus;
        _completedCount = completedCount;
    }

    public override int RecordEvent()
    {
        if (_completedCount < _targetCount)
        {
            _completedCount++;

            if (_completedCount == _targetCount)
            {
                return _points + _bonus;
            }

            return _points;
        }

        return 0;
    }

    public override bool IsComplete()
    {
        return _completedCount >= _targetCount;
    }

    public override string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";

        return $"{status} {_name} ({_description}) -- Completed {_completedCount}/{_targetCount}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{_name}|{_description}|{_points}|{_bonus}|{_targetCount}|{_completedCount}";
    }
}