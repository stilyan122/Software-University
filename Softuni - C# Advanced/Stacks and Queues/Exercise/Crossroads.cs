using System;
using System.Linq;
using System.Collections.Generic;

namespace Crossroads
{
    class Crossroads
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            Queue<string> waiting = new Queue<string>();
            Stack<string> passed = new Stack<string>();
            string command = Console.ReadLine();
            while (command != "END")
            {
                if (command != "green")
                {
                    waiting.Enqueue(command);
                }
                else
                {
                    int greenLight = greenLightDuration;
                    int freePass = freeWindow;
                    int counter = waiting.Count;
                    for (int i = 0; i < counter; i++)
                    {
                        if (greenLight >= waiting.Peek().Length && waiting.Any())
                        {
                            greenLight -= waiting.Peek().Length;
                            passed.Push(waiting.Dequeue());
                        }
                        else if (greenLight < waiting.Peek().Length && waiting.Any())
                        {
                            int timeLeft = greenLight + freePass;

                            if (greenLight <= 0)
                            {
                                continue;
                            }
                            else if (timeLeft > 0 && timeLeft >= waiting.Peek().Length)
                            {
                                string car = waiting.Peek();
                                timeLeft -= car.Length;
                                passed.Push(waiting.Dequeue());
                                greenLight = 0;
                                freePass = 0;
                            }
                            else if (timeLeft > 0 && timeLeft < waiting.Peek().Length)
                            {
                                string car = waiting.Peek();

                                Console.WriteLine("A crash happened!");
                                int hit = timeLeft;
                                Console.WriteLine($"{car} was hit at {car[hit]}.");
                                return;
                            }
                        }
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passed.Count} total cars passed the crossroads.");
        }
    }
}
