using System;
using System.Collections.Generic;
using System.Linq;

namespace MoneyTransactions
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(",");
            Dictionary<int, double> accounts = new Dictionary<int, double>();
            foreach (var account in input)
            {
                string[] splittedAcc = account.Split("-");
                int number = int.Parse(splittedAcc[0]);
                double balance = double.Parse(splittedAcc[1]);
                accounts.Add(number, balance);
            }
            string[] command = Console.ReadLine().Split();
            while (command[0] != "End")
            {
                try
                {
                    switch (command[0])
                    {
                        case "Deposit":
                            int number = int.Parse(command[1]);
                            if (!accounts.ContainsKey(number))
                            {
                                throw new Exception("Invalid account!");
                            }
                            else
                            {
                                double sum = double.Parse(command[2]);
                                accounts[number] += sum;
                                Console.WriteLine($"Account {number} has new balance: {accounts[number]:f2}");
                            }
                            break;
                        case "Withdraw":
                            int number1 = int.Parse(command[1]);
                            if (!accounts.ContainsKey(number1))
                            {
                                throw new Exception("Invalid account!");
                            }
                            else
                            {
                                double sum = double.Parse(command[2]);
                                if (sum > accounts[number1])
                                {
                                    throw new Exception("Insufficient balance!");
                                }
                                else
                                {
                                    accounts[number1] -= sum;
                                    Console.WriteLine($"Account {number1} has new balance: {accounts[number1]:f2}");
                                }
                            }
                            break;
                        default:
                            throw new Exception("Invalid command!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }
                command = Console.ReadLine().Split();
            }
        }
    }
}
