public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;
    protected static Dictionary<string, int> _activityLog = new();

    public Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"\nWelcome to the {_name} Activity.\n");
        Console.WriteLine(_description);
        Console.Write("\nHow long in seconds would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("\nGet ready to begin...");
        ShowSpinner(5);

    }
    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!!\n");
        ShowSpinner(5);
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name} Activity.");
    }

    public void ShowSpinner(int seconds)
    {
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        List<string> spinner = ["|", "/", "-", "\\"];
        int i = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[i % spinner.Count]);
            Thread.Sleep(500);
            Console.Write("\b \b");
            i++;
        }
    }

    public static void ShowEllipsis(int seconds)
    {
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        List<string> ellipsis = [".", "..", "...", ".."];
        int i = 0;
         while (DateTime.Now < endTime)
        {
            Console.Write(ellipsis[i % ellipsis.Count]);
            Thread.Sleep(500);
            Console.Write(new string('\b', ellipsis[i % ellipsis.Count].Length));
            Console.Write(new string(' ', ellipsis[i % ellipsis.Count].Length));
            Console.Write(new string('\b', ellipsis[i % ellipsis.Count].Length));
            i++;
        }
    }
    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    public void LogActivity()
    {
        if (_activityLog.ContainsKey(_name))
        {
            _activityLog[_name]++;
        }
        else
        {
            _activityLog[_name] = 1;
        }
    }
    public static void DisplayActivityLog()
    {
        Console.Write("Loading Activity Log");
        ShowEllipsis(5);
        Console.WriteLine();
        Console.WriteLine("\n--- Activity Log ---");
        foreach (KeyValuePair<string, int> entry in _activityLog)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value} time(s)");
        }
    }

    public static void SaveActivityLog(string filename = "Activity-log.txt")
    {
        using (StreamWriter writer = new(filename))
        {
            foreach (KeyValuePair<string, int> entry in _activityLog)
            {
                writer.WriteLine($"{entry.Key}|{entry.Value}");
            }
        }
        Console.Write("Saving Activity Log");
        ShowEllipsis(5);
        Console.WriteLine("\nActivity Log saved.");
    }
    public static void LoadActivityLog(string filename = "Activity-log.txt")
    {
        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');

                _activityLog[parts[0]] = int.Parse(parts[1]);
            }
        }
    }
}
