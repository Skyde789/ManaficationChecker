using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;

namespace ManaficationChecker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool userInput = true;
            int input = 0;

            FightSimulator sim = new FightSimulator();

            if (!userInput)
            {
                // Faster way than userinput
                // input killtime and how many seconds in are you casting manafication
                sim.StartSimulation("7:50", 8);
                Environment.Exit(0);
            }

            while (input != 2)
            {
                Console.Clear();
                Console.WriteLine("Welcome to manafication calculator!\n[1] Start simulation\n[2] Exit");
                try
                {
                    input = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("\nParse error!\n\nPress Enter to continue...");
                    Console.ReadLine();
                    continue;
                }
                


                switch (input)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Write the estimated killtime as XX:YY (ie. 7:05)");
                        string killtime = Console.ReadLine();

                        Console.WriteLine("How many seconds in are you casting manafication? (ie. 8)");
                        int cast = 0;
                        try
                        {
                            cast = int.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("\nParse error!\n\nPress Enter to continue...");
                            Console.ReadLine();
                            continue;
                        }
                        
                        sim.StartSimulation(killtime, cast);
                        
                        break;
                    case 2:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("\nWrong command!\n\nPress Enter to continue...");
                        Console.ReadLine();
                        continue;
                }
            }
            
        }
    }
}
