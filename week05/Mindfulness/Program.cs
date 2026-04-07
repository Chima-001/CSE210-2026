// 1. I added _LogActivity() in the Activity.cs base class (lines 73-83) method to track and count every activity the user engages
//    and also added ShowEllipsis() method for animation (lines 48-62).

// 2. I also added the SaveActivityLog(), LoadActivityLog() and DisplayActivityLog() in the Activity class to save, load, and
//    display the user activities (lines 84-121) which i put in use in the Program.cs class.

// 3. In the ReflectingActivity.cs class, I added _usedPrompts and _usedQuestions lists to track prompts and questions already
//    displayed and then modified the GetRandomPrompt() and GetRandomQuestions() methods to avoid repetition until every other 
//    prompt and question has been displayed.

// 4. Also, in the ListingActivity.cs class, I added _usedPrompts list to track already shown prompts and modified the 
//    GetRandomPrompt() to prevent repetition of already displayed prompts until every other prompt has been displayed.


using System;

class Program
{
    static void Main(string[] args)
    {
        Activity.LoadActivityLog();
        string userChoice = "";
        while (userChoice != "5")
        {
            Console.WriteLine("\n::::: Mindfulness Program :::::");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflecting Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. View Activity Log");
            Console.WriteLine("5. Quit");
            Console.Write("Select a choice from the menu: ");
            userChoice = Console.ReadLine();

            if (userChoice == "1")
            {
                BreathingActivity breathing = new();
                breathing.Run();
            }

            else if (userChoice == "2")
            {
                ReflectingActivity reflecting = new();
                reflecting.Run();
            }

            else if (userChoice == "3")
            {
                ListingActivity listing = new();
                listing.Run();
            }

            else if (userChoice == "4")
            {
                Activity.DisplayActivityLog();
            }
        }
        Activity.SaveActivityLog();
        Console.Write("\nThank you for using the Mindfulness Program. Goodbye!");
        Activity.ShowEllipsis(5);
        Console.WriteLine();
    }
}