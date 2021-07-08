using System;
using System.Linq;
using System.Collections.Generic;
using MilitaryElite.Models;

namespace MilitaryElite
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Private> privates = new List<Private>();

            while (input != "End")
            {
                string[] tokens = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string soldier = tokens[0];
                int id = int.Parse(tokens[1]);
                string firstName = tokens[2];
                string lastName = tokens[3];

                if (soldier == "Private")
                {
                    decimal salary = decimal.Parse(tokens[4]);
                    Private worrior = new Private(id, firstName, lastName, salary);
                    privates.Add(worrior);
                    Console.WriteLine(worrior.ToString());
                }
                else if (soldier == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(tokens[4]);
                    LieutenantGeneral leutenant = new LieutenantGeneral(id, firstName, lastName, salary);

                    for (int i = 5; i < tokens.Length; i++)
                    {
                        int privateId = int.Parse(tokens[i]);
                        leutenant.Set.Add(privates.FirstOrDefault(p => p.Id == privateId));
                    }

                    Console.WriteLine(leutenant.ToString());
                }
                else if (soldier == "Engineer")
                {
                    decimal salary = decimal.Parse(tokens[4]);
                    string corp = tokens[5];

                    if (corp != "Airforces" && corp != "Marines")
                    {
                        input = Console.ReadLine();
                        continue;
                    }
                    Engineer engineer = new Engineer(id, firstName, lastName, salary, corp);

                    for (int i = 6; i < tokens.Length; i += 2)
                    {
                        string repairPart = tokens[i];
                        int repairHpours = int.Parse(tokens[i + 1]);
                        Repair repair = new Repair(repairPart, repairHpours);
                        engineer.repairs.Add(repair);
                    }
                    Console.WriteLine(engineer.ToString());

                }
                else if (soldier == "Commando")
                {
                    decimal salary = decimal.Parse(tokens[4]);
                    string corp = tokens[5];

                    if (corp != "Airforces" && corp != "Marines")
                    {
                        input = Console.ReadLine();
                        continue;
                    }

                    Commando commando = new Commando(id, firstName, lastName, salary, corp);

                    for (int i = 6; i < tokens.Length; i += 2)
                    {
                        string missionName = tokens[i];
                        string missionState = tokens[i + 1];
                        Mission mission = new Mission(missionName, missionState);
                        if (missionState == "inProgress")
                        {
                            commando.missions.Add(mission);
                        }
                    }
                    Console.WriteLine(commando.ToString());

                }
                else if (soldier == "Spy")
                {
                    int codeName = int.Parse(tokens[4]);
                    Spy spy = new Spy(id, firstName, lastName, codeName);
                    Console.WriteLine(spy.ToString());
                }
                input = Console.ReadLine();
            }
        }
    }
}
