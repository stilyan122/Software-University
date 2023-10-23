using System;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split();
            List<ISoldier> soldiers = new List<ISoldier>();
            List<Private> leutenantPrivates = new List<Private>();
            while (command[0]!="End")
            {
                switch (command[0])
                {
                    case "Private":
                        Private person = new Private(int.Parse(command[1]), command[2], command[3], decimal.Parse(command[4]));
                        leutenantPrivates.Add(person);
                        soldiers.Add(person);
                        break;
                    case "LieutenantGeneral":
                        int id2 = int.Parse(command[1]);
                        string firstName2 = command[2];
                        string lastName2 = command[3];
                        decimal salary2 = decimal.Parse(command[4]);
                        List<Private> privates = new List<Private>();
                        List<int> ids = new List<int>();
                        for (int i = 5; i < command.Length; i++)
                        {
                            ids.Add(int.Parse(command[i]));
                        }
                        foreach (var idNum in ids)
                        {
                            foreach (var privatePerson in leutenantPrivates)
                            {
                                if (idNum==privatePerson.Id)
                                {
                                    privates.Add(privatePerson);
                                }
                            }
                        }
                        LieutenantGeneral general = new LieutenantGeneral(id2,firstName2,lastName2,salary2,privates);
                        soldiers.Add(general);
                        break;
                    case "Engineer":
                        int id = int.Parse(command[1]);
                        string firstName = command[2];
                        string lastName = command[3];
                        decimal salary = decimal.Parse(command[4]);
                        string corps = command[5];
                        List<Repair> repairs = new List<Repair>();
                        for (int i = 6; i < command.Length; i+=2)
                        {
                            string namePart = command[i];
                            int hours = int.Parse(command[i + 1]);
                            Repair repair = new Repair(namePart,hours);
                            repairs.Add(repair);
                        }
                        if (corps == "Airforces" || corps == "Marines")
                        {
                            Engineer engineer = new Engineer(id, firstName, lastName, salary, corps, repairs);
                            soldiers.Add(engineer);
                        }
                        break;
                    case "Commando":
                        int id1 = int.Parse(command[1]);
                        string firstName1 = command[2];
                        string lastName1 = command[3];
                        decimal salary1 = decimal.Parse(command[4]);
                        string corps1 = command[5];
                        List<Mission> missions = new List<Mission>();
                        for (int i = 6; i < command.Length; i += 2)
                        {
                            string codeName = command[i];
                            string state = command[i + 1];
                            if (state == "inProgress" || state == "Finished")
                            {
                                Mission mission = new Mission(codeName, state);
                                missions.Add(mission);
                            }
                        }
                        if (corps1 == "Airforces" || corps1 == "Marines")
                        {
                            Commando commando = new Commando(id1, firstName1, lastName1, salary1, corps1, missions);
                            soldiers.Add(commando);
                        }
                        break;
                    case "Spy":
                        Spy spy = new Spy(int.Parse(command[1]), command[2], command[3], int.Parse(command[4]));
                        soldiers.Add(spy);
                        break;
                        default:
                        break;
                }
                command = Console.ReadLine().Split();
            }
            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier.ToString());
            }
        }
    }
}
