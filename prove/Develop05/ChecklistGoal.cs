public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;
    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;

    }
    public override void RecordEvent()
    {
        Console.WriteLine($"Congratulations, you earned {_points} points");
        _amountCompleted += 1;
        if (_amountCompleted == _target)
        {
            Console.WriteLine($"You earned {_bonus} bonus.");
        }

    }
    public override int GetPoints()
    {
        return _points;
    }
    public override int GetBonus()
    {
        return _bonus;
    }
    public int GetAmountCompleted()
    {
        return _amountCompleted;
    }
    public override bool IsComplete()
    {
        if(_amountCompleted == _target)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool GetIsComplete()
    {
        return IsComplete();
    }
    public override string GetDetailsString()
    {
        if (IsComplete())
        {
            return $"[x] {_shortName} ({_description}) -- Currently completed {_amountCompleted}/{_target}";
        }
        else
        {
            return $"[ ] {_shortName} ({_description}) -- Currently completed {_amountCompleted}/{_target}";
        };
    }
    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_shortName}||{_description}||{_points}||{_bonus}||{_target}||{_amountCompleted}";
    }
    public void SetAmountCompleted(int amountCompleted)
    {
        _amountCompleted = amountCompleted;
    }
   
}