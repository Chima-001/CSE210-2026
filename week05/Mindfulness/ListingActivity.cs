public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;
    private List<string> _usedPrompts = [];
    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", 0)
    {
        _count = 0;
        _prompts =
        [
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?",
            "What are things you are grateful for today?",
            "What talents do you have that you often overlook?",
            "Who has made a positive difference in your life?",
            "What are some simple things that bring you joy?",
            "What good habits have you developed over time?",
            "Who are people that believe in you?",
            "What challenges have you overcome this year?"
        ];
    }

    public void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine($"\nList as many responses as you can to the following prompt. Press enter after each one:");
        Console.WriteLine($"––– {GetRandomPrompt()} –––");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();
        List<string> items = GetListFromUser();
        _count = items.Count;
        Console.WriteLine($"You listed {_count} item(s).");
        LogActivity();
        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        if (_usedPrompts.Count == _prompts.Count)
        {
            _usedPrompts = [];
        }
        Random random = new();
        string prompt = _prompts[random.Next(_prompts.Count)];
        while (_usedPrompts.Contains(prompt))
        {
            prompt = _prompts[random.Next(_prompts.Count)];
        }
        _usedPrompts.Add(prompt);
        return prompt;
    }

    public List<string> GetListFromUser()
    {
        List<string> items = [];

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            items.Add(input);
        }
        return items;
    }
}