using System.Collections.Generic;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        int number = 0;
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished. ");
        do
        {
            Console.Write("Enter number: ");
            string userInput = Console.ReadLine();
            number = int.Parse(userInput);

            if (number != 0)
            {
            numbers.Add(number);
            }
        }
        while (number != 0);

        double totalSum = 0;
        int max = 0;
        double sPostive = 9999999999999999999;
        foreach (int num in numbers)
        {
            totalSum += num;

            if (num > max)
            {
                max = num;
            }
            
            if (num < sPostive && num >= 0)
            {
                sPostive = num;
            }
        }

        double average = totalSum / numbers.Count;
        Console.WriteLine($"The sum is: {totalSum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
        Console.WriteLine($"The smallest positive number is: {sPostive}");

        Console.WriteLine($"The sorted list is:");
        numbers.Sort();
        List<int> sortedNumbers = numbers;
        foreach (int num in sortedNumbers)
        {
            Console.WriteLine(num);
        }
    }
}