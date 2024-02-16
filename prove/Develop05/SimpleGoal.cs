public class SimpleGoal : Goal
{
    private bool _isComplete;
    
    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
    }
    public override void RecordEvent()
    {
        _isComplete = true;
        Console.WriteLine($"Congratulations, you earned {_points} points!");
    }
    public bool GetIsComplete()
    {
        return _isComplete;    }
    public override int GetPoints()
    {
        return _points;
    }
    
    public override bool IsComplete()
    {
        return _isComplete;
    }
    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{_shortName}||{_description}||{_points}||{_isComplete}";
    }
    public void SetCompletedStatus(bool completeStatus)
    {
        _isComplete = completeStatus;
    }
}