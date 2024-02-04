// I added a "hold your breath" section to complete the belly breathing activity
public class BreathingActivity : Activity
{
    public BreathingActivity(string name, string description) : base(name, description)
    {
        
    }

    public void Run()
    {
        
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(base.GetDuration());
        
        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe in...");
            base.ShowCountDown(4);
            Console.Write("\nHold your breath...");
            base.ShowCountDown(7);
            Console.Write("\nBreathe out...");
            base.ShowCountDown(8);
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}