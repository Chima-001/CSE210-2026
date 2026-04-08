using System;

class Program
{
    static void Main(string[] args)
    {

        Square square1 =  new ("Red", 5);
        Rectangle rect1 =  new ("Blue", 4, 6);
        Circle circle1 =  new ("Green", 3);

        List<Shape> shapes = [
            square1,
            rect1,
            circle1
        ];

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Shape: {shape.GetName()}");
            Console.WriteLine($"Color: {shape.GetColor()}");
            Console.WriteLine($"Area: {shape.GetArea()}");
            Console.WriteLine();
        }
    }
}