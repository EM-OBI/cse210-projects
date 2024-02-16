using System.IO; 
public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        Start();
    }
    public void Start()
    {
        int userChoice;
        while(true)
        {
            Console.WriteLine($"You have {_score} points.");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("\t1. Create New Goal \n\t2. List Goals \n\t3. Save Goals \n\t4. Load Goals \n\t5. Record Event \n\t6. Quit");
            Console.Write("Select an option from the menu: ");
            userChoice = int.Parse(Console.ReadLine());
            if (userChoice == 1)
            {
                CreateGoal();
            }
            else if (userChoice == 2)
            {
                ListGoalDetails();
            }
            else if (userChoice == 3)
            {
                SaveGoals();
            }
            else if (userChoice == 4)
            {
                LoadGoals();
            }
            else if (userChoice == 5)
            {
                foreach (Goal goal in _goals)
                {
                    if (goal.IsComplete())
                    {
                        Console.WriteLine($"{goal.GetName()} XXX - You have completed this task - XXX");
                    }
                    else
                    {
                        RecordEvent();
                    }
                }
                
            }
            else if (userChoice == 6)
            {
                break;
            }
            
        }   
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine(_score);
    }
    public void ListGoalNames()
    {
        int goalCount = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{goalCount}. {goal.GetName()}");
            goalCount++;
        }
    }
    public void ListGoalDetails()
    {
        int goalCount = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{goalCount}. {goal.GetDetailsString()}");
            goalCount++;
        }
    }
    public void CreateGoal()
    {
        Console.WriteLine("The types of goals are: \n\t1. Simple Goal \n\t2. Eternal Goal \n\t3. Checklist Goal");
        Console.Write("What kind of goal would you like to create? ");
        int userChoiceGoal = int.Parse(Console.ReadLine());
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("Write a short description of it: ");
        string description = Console.ReadLine();
        Console.Write("How many points do you want associated with this goal? ");
        int points = int.Parse(Console.ReadLine());
        if (userChoiceGoal == 1)
        {
            SimpleGoal simpleGoal = new SimpleGoal(name, description, points);
            _goals.Add(simpleGoal);
        }
        else if (userChoiceGoal == 2)
        {
            EternalGoal eternalGoal = new EternalGoal(name, description, points);
            _goals.Add(eternalGoal);
        }
        else if (userChoiceGoal == 3)
        {
            Console.Write("How many times should the goal be completed to get a bonus? ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("What is the amount of bonus points for completing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());
            ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, target, bonus);
            _goals.Add(checklistGoal);
        }
    }
    public void RecordEvent()
    {
        Console.WriteLine("Your goals are: ");
        ListGoalNames();
        Console.WriteLine("What goal did you accomplish? ");
        int goalRecord = int.Parse(Console.ReadLine());
        Type objectType = _goals[goalRecord - 1].GetType();
        if (objectType == typeof(ChecklistGoal))
        {
            _goals[goalRecord - 1].RecordEvent();
            _score += _goals[goalRecord - 1].GetPoints();
            if (_goals[goalRecord - 1].IsComplete())
            {
                _score += _goals[goalRecord - 1].GetBonus();
            }
        }
        else
        {
            _goals[goalRecord - 1].RecordEvent();
            _score += _goals[goalRecord - 1].GetPoints();
        }

    }
    public void SaveGoals()
    {
        Console.Write("What would you like to call your file? ");
        string fileName = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine($"{goal.GetStringRepresentation()}");
            }
        }
    }
    public void LoadGoals()
    {
        Console.Write("What file would you like to load? ");
        string fileName = Console.ReadLine();
        try
        {
            string[] lines = System.IO.File.ReadAllLines(fileName);
        
            List<Goal> _goals = new List<Goal>();
            _score = 0;
            foreach (string line in lines.Skip<string>(1))
            {
                string[] partsLine = line.Split(":");

                string goalType = partsLine[0];
                string goalDetails = partsLine[1];
                string[] partsDetails = goalDetails.Split("||");
                string name = partsDetails[0];
                string description = partsDetails[1];
                int points = int.Parse(partsDetails[2]);
                if (goalType == "SimpleGoal")
                {
                    SimpleGoal simpleGoal = new SimpleGoal(name, description, points);
                    simpleGoal.SetCompletedStatus(bool.Parse(partsDetails[3]));
        
                    _goals.Add(simpleGoal);
                }
                else if(goalType == "EternalGoal")
                {
                    EternalGoal eternalGoal = new EternalGoal(name, description, points);
                    
                    _goals.Add(eternalGoal);
                }
                else if(goalType == "ChecklistGoal")
                {
                    int bonus = int.Parse(partsDetails[3]);
                    int target = int.Parse(partsDetails[4]);
                    ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, target, bonus);
                    
                    checklistGoal.SetAmountCompleted(int.Parse(partsDetails[5]));
                    _goals.Add(checklistGoal);
                }
                _score += points;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured: {ex.Message}");
        }

    }
}