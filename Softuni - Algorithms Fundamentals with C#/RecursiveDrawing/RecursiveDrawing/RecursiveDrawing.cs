using System;

namespace RecursiveDrawing
{
    public class RecursiveDrawing
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            void Draw(int n, char value, int counter)
            {
                if(n > 0 && value == '*')
                {
                    Console.WriteLine(new string(value, n));
                    Draw(n - 1,value, 0);
                }
                else if (value == '#' && counter <= n && n > 0)
                {
                    Console.WriteLine(new string(value, counter));
                    Draw(n, value, counter++);
                }
            }
            Draw(n,'*',0);
            Draw(n,'#',0);
        }
    }
}
