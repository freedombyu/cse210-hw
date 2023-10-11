using System;
using System.Collections;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();
        {
            new Square("Red", 4);
            
            new Rectangle("Green", 3, 5);
            new Circle("Blue", 3.5);
        }

        foreach (var shape in shapes)
        {
            Console.WriteLine($"Shape: {shape.GetType().Name}, Color: {((dynamic)shape).Color}, Area: {shape.GetArea()}");
        }
    }
}





