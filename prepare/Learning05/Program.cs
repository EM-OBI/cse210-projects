using System;

class Program
{
    static void Main(string[] args)
    {
        Square square1 = new Square();  
        Rectangle rectangle1 = new Rectangle();  
        Circle circle1 = new Circle();  
        square1.SetColor("green");
        circle1.SetColor("yellow");
        rectangle1.SetColor("pink");
        List<Shape> shapes = new List<Shape>();
        shapes.Add(square1);
        shapes.Add(circle1);
        shapes.Add(rectangle1);
        foreach (Shape shape in shapes)
        {
            Console.WriteLine(shape.GetColor());
            Console.WriteLine(shape.GetArea());
        }
    }
}