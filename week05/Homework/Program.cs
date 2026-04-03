using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment ass1 = new("Chimamkpam Nnaji", "C-Sharp");
        Console.WriteLine(ass1.GetSummary());
        Console.WriteLine();
        
        MathAssignment ass2 = new("Diego Santoz", "Fractions", "7.4", "11-4");
        Console.WriteLine(ass2.GetSummary());
        Console.WriteLine(ass2.GetHomeWorkList());
        Console.WriteLine();

        WritingAssignment ass3 = new("Abel Camia", "European History", "The Causes of World War II");
        Console.WriteLine(ass3.GetSummary());
        Console.WriteLine(ass3.GetWritingInformation());

    }
}