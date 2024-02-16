public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;
    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }
    public abstract int GetPoints();
    
    public string GetName()
    {
        return _shortName;
    }
    public virtual int GetBonus()
    {
        return 0;
    }
    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public virtual string GetDetailsString()
    {
        if (IsComplete())
        {
            return $"[x] {_shortName} ({_description})";
        }
        else
        {
            return $"[ ] {_shortName} ({_description})";
        }
    }
    public abstract string GetStringRepresentation();
    
    // public abstract Goal CreateGoal(string goalDetails);
}