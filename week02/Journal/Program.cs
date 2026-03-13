// 1. I added 10 prompts instead of the minimum 5 to reduce the repetition of prompts.

// 2. In the Journal.cs class (line 15), I added a total entry count, displayed before 
//    listing entries to give the user a quick overview.

// 3. Also, In the Journal.cs class (line 36-40), I added error handling from 
//    LoadFromFile() method to check if file exists before attempting to load it.

// 4. Lastly, In the Entry.cs class (line 21-24), I added a GetSaveString() method to the 
//    entry class to handle its own save formatting.

using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator generator = new PromptGenerator();

        Console.WriteLine("Welcome to the Journal Program!");
        
        while (true)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();
            if (choice == "1")
            {
                string prompt = generator.GetRandomPrompt();
                Console.WriteLine(prompt);
                Console.Write("> ");
                string response = Console.ReadLine();
                string date = DateTime.Now.ToShortDateString();

                Entry entry = new Entry(date, prompt, response);
                journal.AddEntry(entry);
            }

            else if (choice == "2")
            {
                journal.DisplayAll();

            }

            else if (choice == "3")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                journal.LoadFromFile(filename);
            }

            else if (choice == "4")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                journal.SaveToFile(filename);
            }

            else if (choice == "5")
            {
                break;
            }

            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }
}