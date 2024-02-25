namespace Chronometer
{
    public class Program
    {
        static void Main()
        {
            string command = Console.ReadLine();
            Chronometer chronometer = new Chronometer();

            while (command != "exit")
            {
                if (command == "start")
                {
                    chronometer.Start();
                }
                else if (command == "stop")
                {
                    chronometer.Stop();
                }
                else if (command == "lap")
                {
                    Console.WriteLine(chronometer.Lap());
                }
                else if (command == "laps")
                {
                    if (chronometer.Laps.Count > 0)
                    {
                        Console.WriteLine("Laps:");
                        int counter = 0;
                        foreach (string lap in chronometer.Laps)
                        {
                            Console.WriteLine($"{counter}. {lap}");
                            counter++;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Laps: no laps");
                    }
                    
                }
                else if (command == "time")
                {
                    Console.WriteLine(chronometer.GetTime);
                }
                else if (command == "reset")
                {
                    chronometer.Reset();
                }
                command = Console.ReadLine();
            }
        }
    }
}
