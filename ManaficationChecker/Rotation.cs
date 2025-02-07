using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManaficationChecker
{
    class Rotation
    {
        List<int> manaficationCastTime = new List<int>();
        List<int> manaficationMeleeEndTime = new List<int>();

        int m_iMeleeCombo = 15;
        int m_iKillTime = 0;

        public Rotation(int killtime)
        {
            m_iKillTime = killtime;
        }
        public int GetLastMeleeEndTime => manaficationMeleeEndTime.Count > 0 ? manaficationMeleeEndTime[^1] : 0;

        /// <summary>
        /// Gets dead time between killtime and last manaficationMeleeEndTime
        /// </summary>
        /// <returns></returns>
        public int GetDeadTime()
        {
            return m_iKillTime - manaficationMeleeEndTime[^1];
        }

        public void AddCast(int time)
        {
            manaficationCastTime.Add(time);
            manaficationMeleeEndTime.Add(time + m_iMeleeCombo);
        }

        public int GetManaficationCasts => manaficationCastTime.Count;

        // How many times did we hold our manafic for 120s
        public int GetHoldAmount()
        {
            int x = 0;

            for (int i = 1; i < manaficationCastTime.Count; i++)
            {
                if (manaficationCastTime[i] - manaficationCastTime[i - 1] == 120)
                    x++;
            }

            return x;
        }

        public override string ToString()
        {
            for (int i = 0; i < manaficationCastTime.Count; i++)
            {
                Console.Write(SecondsToString(manaficationCastTime[i]));
                int castTime = manaficationCastTime[i];
                int previousCastTime = i > 0 ? manaficationCastTime[i - 1] : 0;
                int meleeEndTime = manaficationMeleeEndTime[i];

                // Checks for additional info
                if(i == 0)
                    Console.WriteLine(" | Opener");
                // If the last cast cannot cast prefulgence in time (trying to rush melee combo ASAP)
                else if (meleeEndTime > m_iKillTime)
                    Console.WriteLine(" - " + SecondsToString(meleeEndTime) + " | No Time for Prefulgence!");
                // not the first cast and the duration between casts is 120 (timed with embolden)
                else if (i > 0 && castTime - previousCastTime == 120)
                    Console.WriteLine(" | Hold");
                // If we have time to prefulgence
                else 
                    Console.WriteLine(" | OnCD");
            }

            return "";
        }

        string SecondsToString(int amount)
        {
            return (amount / 60) + ":" + (amount % 60 < 10 ? "0" + amount % 60 : amount % 60);
        }
    }
}
