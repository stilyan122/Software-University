using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split();
            List<IResidents> residents = new List<IResidents>();
            while (command[0]!="End")
            {
                if (command.Length==3)
                {
                    Citizen citizen = new Citizen(command[0], int.Parse(command[1]),command[2]);
                    residents.Add(citizen);
                }
                else if (command.Length==2)
                {
                    Robot robot = new Robot(command[0],command[1]);
                    residents.Add(robot);
                }
                command = Console.ReadLine().Split();
            }
            int number = int.Parse(Console.ReadLine());
            List<IResidents> fakeResidents = new List<IResidents>();
            foreach (var resident in residents)
            {
                if (resident.Check(number)==true)
                {
                    fakeResidents.Add(resident);
                }
            }
            foreach (var fakeId in fakeResidents)
            {
                Console.WriteLine(fakeId.Id);
            }
        }
    }
}
