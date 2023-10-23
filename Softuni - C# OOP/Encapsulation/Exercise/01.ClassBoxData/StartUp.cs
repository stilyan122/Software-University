using System;

namespace Box
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            double length;
            double width;
            double height;
            bool thrownException = false;
            Box box = new Box(1, 1, 1);
            try
            {
                length = double.Parse(Console.ReadLine());
                width = double.Parse(Console.ReadLine());
                height = double.Parse(Console.ReadLine());
                box = new Box(length, width, height);
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
                thrownException = true;
            }
            if (thrownException==false)
            {
                Console.WriteLine($"Surface Area - {box.SurfaceArea():f2}");
                Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea():f2}");
                Console.WriteLine($"Volume - {box.Volume():f2}");
            }
        }
    }
}
