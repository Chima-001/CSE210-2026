using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");

        string userInput = Console.ReadLine();
        int gradePercentage = int.Parse(userInput);
        
        string letter = "";
        string sign = "";

        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        if (gradePercentage % 10 < 3 && letter != "F")
        {
            sign = "-";
        }
        else if (gradePercentage % 10 >= 7 && letter != "A" && letter != "F")
        {
            sign = "+";
        }

        if (gradePercentage >= 90)
        {
            Console.WriteLine($"You got an {letter}{sign}.");
        }
        else
        {
            Console.WriteLine($"You got a {letter}{sign}.");
        }

        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed this class.");
        }
        else
        {
            Console.WriteLine("Sorry, you did not pass this class. Study harder next term.");
        }
    }
}