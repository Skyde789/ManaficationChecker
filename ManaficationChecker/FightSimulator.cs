using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManaficationChecker
{
    class FightSimulator
    {
        int m_iManafication = 110;
        int m_iEmbolden = 120;

        int killTimeSeconds = 0;

        string killTime = "XX:XX";
        public FightSimulator() { }
        public void StartSimulation(string ktime, int startTime)
        {
            killTime = ktime;

            killTimeSeconds = StringToSeconds(killTime);

            SimulateFights(startTime);
        }

        void SimulateFights(int manaficStart)
        {
            Console.Clear();
            int internalSeconds = manaficStart;

            Rotation onCD = new Rotation(killTimeSeconds);
            Rotation holdVariant = new Rotation(killTimeSeconds);

            while (true)
            {
                onCD.AddCast(internalSeconds);

                internalSeconds += m_iManafication;

                if (internalSeconds > killTimeSeconds)
                    break;
            }

            int x = onCD.GetDeadTime() / 10;

            if (x > 0)
            {
                internalSeconds = manaficStart;

                while (true)
                {
                    holdVariant.AddCast(internalSeconds);

                    internalSeconds += x > 0 ? m_iEmbolden : m_iManafication;
                    x--;
                    if (internalSeconds > killTimeSeconds)
                        break;
                }
            }

            if (holdVariant.GetManaficationCasts >= onCD.GetManaficationCasts)
            {
                Console.WriteLine($"Kill time: {killTime}\nCasts: {holdVariant.GetManaficationCasts}\nHolds: {holdVariant.GetHoldAmount()}\nManafication casts:");
                Console.WriteLine(holdVariant.ToString());
            }
            else
            {
                Console.WriteLine($"Kill time: {killTime}\nCasts: {onCD.GetManaficationCasts}\nHolds: {onCD.GetHoldAmount()}\nManafication casts:");
                Console.WriteLine(onCD.ToString());
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        int StringToSeconds(string text)
        {
            string[] test = text.Split(":");
            int x = 0;

            try
            {
                x = int.Parse(test[1]);
                x += int.Parse(test[0]) * 60;
            }
            catch
            {
                Console.WriteLine("Couldn't parse the killtime correctly.\nPlease write the killtime in the following format: MM:SS");
            }

            return x;
        }

        string SecondsToString(int amount)
        {
            return (amount / 60) + ":" + (amount % 60 < 10 ? "0" + amount % 60 : amount % 60);
        }

    }
}
