using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split();
            List<IBirthday> residents = new List<IBirthday>();
            while (command[0]!="End")
            {
                if (command[0]=="Citizen")
                {
                    Citizen citizen = new Citizen(command[1], int.Parse(command[2]),command[3],command[4]);
                    residents.Add(citizen);
                }
                else if (command[0]=="Pet")
                {
                    Pet pet = new Pet(command[1], command[2]);
                    residents.Add(pet);
                }
                command = Console.ReadLine().Split();
            }
            string year = Console.ReadLine();
            List<IBirthday> residentsToBeFound = new List<IBirthday>();
            foreach (var resident in residents)
            {
                if (resident.Check(year)==true)
                {
                    residentsToBeFound.Add(resident);
                }
            }
            foreach (var resident in residentsToBeFound)
            {
                Console.WriteLine(resident.Birthday);
            }
        }
    }
}
