public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;
    private List<string> _userList;
    private HashSet<int> _usedIndices;

    public ListingActivity(string name, string description) : base(name, description)
    {
        
    }

    public void Run()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine("List as many responses as you can to the following prommpt:");
        Console.WriteLine($"--- {prompt} ---");
        Console.Write("You may begin in: ");
        base.ShowCountDown(5);
        Console.WriteLine();
        GetListFromUser();
        Console.WriteLine($"You listed {_count} items!!!");
        Console.WriteLine();
    }
    public string GetRandomPrompt()
    {
        Random randomGen = new Random();
        _prompts = new List<string>();
        _prompts.Add("Who are people that you appreciate?");
        _prompts.Add("What are personal strengths of yours?");
        _prompts.Add("Who are people that you have helped this week?");
        _prompts.Add("When have you felt the Holy Ghost this month?");
        _prompts.Add("Who are some of your personal heroes?");
        _usedIndices  = new HashSet<int>();

        if (_usedIndices.Count == _prompts.Count)
        {
            _usedIndices.Clear();
        }
        int randomIndex;

        do
        {
            randomIndex = randomGen.Next(0, _prompts.Count);
        } while (_usedIndices.Contains(randomIndex));

        _usedIndices.Add(randomIndex);

        return _prompts[randomIndex];
    }
    public List<string> GetListFromUser()
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(base.GetDuration());
        _userList = new List<string>();
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            _userList.Add(Console.ReadLine());
        }
        _count = _userList.Count;
        return _userList;
    }
}