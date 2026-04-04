public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private List<string> _usedPrompts = [];
    private List<string> _usedQuestions = [];
    public ReflectingActivity() : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.", 0)
    {
        _prompts =
        [
            "Think of a time when you stood up for someone else",
            "Think of a time when you did something really difficult",
            "Think of a time when you helped someone in need",
            "Think of a time when you did something truly selfless",
            "Think of a time when you overcame a fear",
            "Think of a time when you made someone smile",
            "Think of a time when you kept going despite wanting to quit",
            "Think of a time when you made a hard decision and it paid off"
        ];

        _questions =
        [
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?",
            "Who else was impacted by what you did?",
            "What strengths did you discover about yourself?",
            "How did this experience change your perspective?",
            "What would you do differently if you faced this again?",
            "How did this experience affect your relationships with others?"
        ];
    }

    public void Run()
    {
        DisplayStartingMessage();
        DisplayPrompt();
        Console.ReadLine();
        Console.WriteLine("Now ponder on each of the following questions as they relate to your experience.");
        Console.Write($"You may begin in: ");
        ShowCountDown(5);
        Console.Clear();
        DisplayQuestions();
        Console.WriteLine();
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
    public string GetRandomQuestion()
    {
        if (_usedQuestions.Count == _questions.Count)
        {
            _usedQuestions = [];
        }
        Random random = new();
        string question = _questions[random.Next(_questions.Count)];
        while (_usedQuestions.Contains(question))
        {
            question = _questions[random.Next(_questions.Count)];

        }
        _usedQuestions.Add(question);
        return question;
    }

    public void DisplayPrompt()
    {
        Console.WriteLine("\nConsider the following prompt:");
        Console.WriteLine($"––– {GetRandomPrompt()} –––");
        Console.WriteLine("\nWhen you have something in mind, press enter to continue.");
    }
    public void DisplayQuestions()
    {
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.Write($"\n> {GetRandomQuestion()} ");
            ShowSpinner(10);
        }

    }

}