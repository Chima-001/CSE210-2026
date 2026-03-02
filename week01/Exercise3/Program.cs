using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        string replay = "";

        do
        {
        int magicNumber = randomGenerator.Next(1, 101);
        int guess = 0;
        int guessCount = 0;
            do
            {
                Console.Write("What is the magic number? ");
                string userInput = Console.ReadLine();

                guess = int.Parse(userInput);
                guessCount += 1;
                
                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                    continue;
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                    continue;
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    
                }
            
            }
            while (guess != magicNumber);
            Console.WriteLine($"It took you {guessCount} guesses.");

        Console.WriteLine();

        Console.Write("Do you want to play again? ");
        replay = Console.ReadLine();
        }
        while (replay == "yes");
    }
}