public class NegativeGoal : Goal
{
   
    public NegativeGoal(string name, string description, int points) : base(name, description, points)
    {

    }
    public override void RecordEvent()
    {
        Console.WriteLine($"OOPS! you lost {_points} points.");
    }
    public override int GetPoints()
    {
        return _points;
    }
    public override bool IsComplete()
    {
        return false;
    }
    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{_shortName}||{_description}||{_points}";
    }
   
}