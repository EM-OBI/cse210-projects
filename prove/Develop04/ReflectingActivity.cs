public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private HashSet<int> _usedPromptIndices;
    private HashSet<int> _usedQuestionIndices;

    public ReflectingActivity(string name, string description) : base(name, description)
    {
        
    }
    public void Run()
    {
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        DisplayPrompt();
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        base.ShowCountDown(5);
        Console.Clear();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(base.GetDuration());
        while (DateTime.Now < endTime)
        {
            DisplayQuestions();
            base.ShowSpinner(10);
            Console.WriteLine();
        }
        

    }
    public string GetRandomPrompt()
    {
        Random randomGen = new Random();
        _prompts = new List<string>();
        _prompts.Add("Think of a time when you stood up for someone else.");
        _prompts.Add("Think of a time when you did something really difficult.");
        _prompts.Add("Think of a time when you helped someone in need.");
        _prompts.Add("Think of a time when you did something truly selfless.");
        _usedPromptIndices  = new HashSet<int>();

        if (_usedPromptIndices.Count == _prompts.Count)
        {
            _usedPromptIndices.Clear();
        }
        int randomIndex;

        do
        {
            randomIndex = randomGen.Next(0, _prompts.Count);
        } while (_usedPromptIndices.Contains(randomIndex));

        _usedPromptIndices.Add(randomIndex);

        return _prompts[randomIndex];
    }
    public string GetRandomQuestion()
    {
        Random randomGen = new Random();
        _questions = new List<string>();
        _questions.Add("Why was this experience meaningful to you?");
        _questions.Add("How did you get started?");
        _questions.Add("How did you feel when it was complete?");
        _questions.Add("What made this time different than other times when you were not as successful?");
        _questions.Add("What is your favorite thing about this experience?");
        _questions.Add("What could you learn from this experience that applies to other situations?");
        _questions.Add("What did you learn about yourself through this experience?");
        _questions.Add("How can you keep this experience in mind in the future?");
        _usedQuestionIndices  = new HashSet<int>();

        if (_usedQuestionIndices.Count == _questions.Count)
        {
            _usedQuestionIndices.Clear();
        }
        int randomIndex;

        do
        {
            randomIndex = randomGen.Next(0, _questions.Count);
        } while (_usedQuestionIndices.Contains(randomIndex));

        _usedQuestionIndices.Add(randomIndex);
        return _questions[randomIndex];
    }
    public void DisplayPrompt()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine($"---{prompt}---");
    }
    public void DisplayQuestions()
    {
        string question = GetRandomQuestion();
        Console.Write($"> {question}");
    }
}