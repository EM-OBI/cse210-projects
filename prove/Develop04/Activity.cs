public class Activity
{
    private string _name;
    private string _description;
    private int _duration;
    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        
    }
    public int GetDuration()
    {
        return _duration;
    }
    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to {_name} Activity.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("Get Ready!");
        ShowSpinner(5);
        Console.WriteLine();
    }
    public void DisplayEndingMessage()
    {
        Console.WriteLine("Well done!");
        ShowSpinner(5);
        Console.WriteLine();
        Console.WriteLine($"You have completed {_duration} seconds of the {_name} activity.");
        ShowSpinner(5);
    }
    public void ShowSpinner(int seconds)
    {
        List<string> spinnerItems = new List<string>();
        spinnerItems.Add("|");
        spinnerItems.Add("/");
        spinnerItems.Add("-");
        spinnerItems.Add("\\");
        // spinnerItems.Add("|");
        // spinnerItems.Add("\\");
        // spinnerItems.Add("-");
        // spinnerItems.Add("/");
        int i = 0;
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);
        while (DateTime.Now < endTime)
        {
            Console.Write(spinnerItems[i]);
            Thread.Sleep(1000);
            Console.Write("\b \b");

            i++;
            if(i >= spinnerItems.Count)
            {
                i = 0;
            }
        }
    }
    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i --)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");

        }
    }
}
