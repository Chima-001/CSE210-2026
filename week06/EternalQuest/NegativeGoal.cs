public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, string points) : base(name, description, points)
    {
    }
    public override void RecordEvent()
    {
        
    }

    public override bool IsComplete()
    {
        return false;
    }
    
    public override string GetStringRepresentation()
    {
        return $"NegativeGoal:{_shortName},{_description},{_points}";
    }
}
