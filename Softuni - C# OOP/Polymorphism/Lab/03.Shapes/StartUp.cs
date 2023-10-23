using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Rectangle shape1 = new Rectangle(10,20);
            Circle shape2 = new Circle(4);
            Console.WriteLine(shape1.Draw());
            Console.WriteLine(shape2.Draw());
            Console.WriteLine(shape1.CalculateArea());
            Console.WriteLine(shape2.CalculateArea());
            Console.WriteLine(shape1.CalculatePerimeter());
            Console.WriteLine(shape2.CalculatePerimeter());
        }
    }
}
