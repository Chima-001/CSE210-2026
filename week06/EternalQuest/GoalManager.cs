public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private string _filename = "";

    public GoalManager()
    {
        _goals = [];
        _score = 0;
    }

    public void Start()
    {
        LoadGoals();
        
        string choice = "";

        while (choice != "5")
        {
            Console.WriteLine($"\nYou have {_score} points. Level: {GetLevel()}\n");
            Console.WriteLine("Menu Options:\n1. Create New Goal\n2. List Goals\n3. Record Event\n4. Delete Goal\n5. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            if (choice == "1") CreateGoal();
            else if (choice == "2") ListGoalDetails();
            else if (choice == "3") RecordEvent();
            else if (choice == "4") DeleteGoal();
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points. Level: {GetLevel()}");
    }
    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            string status = _goals[i].IsComplete() ? "[X]" : "[ ]";
            Console.WriteLine($"{i + 1}. {status} {_goals[i].GetDetailsString()}");
        }
    }
    public void ListGoalDetails()
    {
        ListGoalNames();
    }
    public void CreateGoal()
    {
        Console.WriteLine("The types of goals are:\n1. Simple Goal\n2. Eternal Goal\n3. Checklist Goal\n4. Negative Goal");
        Console.Write("Which type of goal would you like to create? ");

        string type = Console.ReadLine();
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        string points = Console.ReadLine();

        if (type == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (type == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
        else if (type == "4")
        {
            _goals.Add(new NegativeGoal(name, description, points));
        }
        SaveGoals();
    }
    public void RecordEvent()
    {
        Console.WriteLine("The goals are:");
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");

        int index = int.Parse(Console.ReadLine()) - 1;
        Goal selected = _goals[index];

        if (selected.IsComplete())
        {
            Console.WriteLine("This goal is already completed.");
            return;
        }
        selected.RecordEvent();

        int earned = int.Parse(selected.GetPoints());

        if (selected is NegativeGoal)
        {
            _score -= earned;
            Console.WriteLine($"You lost {earned} points for a bad habit. Score: {_score}");
        }

        else if (selected is ChecklistGoal checklist)
        {
            _score += earned;
            if (checklist.IsComplete())
            {
                int bonus = int.Parse(selected.GetStringRepresentation().Split(",")[4]);
                _score += bonus;
                Console.WriteLine($"Bonus! You completed the checklist goal! +{bonus} bonus points!");
            }
            Console.WriteLine($"Congratulations! You have earned {selected.GetPoints()} points!");
        }
        else
        {
            _score += earned;
            Console.WriteLine($"Congratulations! You have earned {selected.GetPoints()} points!");
        }
        Console.WriteLine($"You now have {_score} points. Level: {GetLevel()}.");
        SaveGoals();
    }
    public void SaveGoals()
    {
        if (_filename == "")
        {

            Console.Write("What is the filename for the goal file? ");
            _filename = Console.ReadLine();
        }
        using (StreamWriter file = new(_filename))
        {
            file.WriteLine(_score);
            foreach (Goal g in _goals)
            {
                file.WriteLine(g.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved.");
    }
    public void LoadGoals()
    {
        if (_filename == "")
        {
            
        Console.Write("Enter the filename for the goal file. If none just press enter: ");
        _filename = Console.ReadLine();
        }

        if (!File.Exists(_filename))
        {
            Console.WriteLine("No saved goals found. Starting fresh? Create a goal to begin.");
            return;
        }

        string[] lines = File.ReadAllLines(_filename);

        _score = int.Parse(lines[0]);
        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(":");
            string type = parts[0];
            string[] details = parts[1].Split(",");

            if (type == "SimpleGoal")
            {
                SimpleGoal g = new(details[0], details[1], details[2]);
                if (details[3] == "True") g.RecordEvent();
                _goals.Add(g);
            }

            else if (type == "EternalGoal")
            {
                _goals.Add(new EternalGoal(details[0], details[1], details[2]));
            }

            else if (type == "ChecklistGoal")
            {
                ChecklistGoal g = new(details[0], details[1], details[2], int.Parse(details[3]), int.Parse(details[4]));
                int completed = int.Parse(details[5]);
                for (int j = 0; j < completed; j++) g.RecordEvent();
                _goals.Add(g);
            }

            else if (type == "NegativeGoal")
            {
                _goals.Add(new NegativeGoal(details[0], details[1], details[2]));
            }
        }
        Console.WriteLine("Goals loaded.");

    }

    public void DeleteGoal()
    {
        Console.WriteLine("The goals are:");
        ListGoalNames();
        Console.WriteLine("Which goal would you like to delete? ");
        int index = int.Parse(Console.ReadLine()) - 1;
        Console.WriteLine($"Goal \"{_goals[index].GetName()}\" deleted.");
        _goals.RemoveAt(index);
        SaveGoals();
    }

    public string GetLevel()
    {
        if (_score < 1000) return "Novice";
        else if (_score < 2000) return "Apprentice";
        else if (_score < 4000) return "Knight";
        else if (_score < 7000) return "Hero";
        else return "Legend";
    }


}