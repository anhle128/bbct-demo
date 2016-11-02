using System;

namespace BattleSimulator
{ 
    public class RandomHelper
    {
        private static Random rnd;

        private static Random GetRnd()
        {
            if (rnd == null)
            {
                rnd = new Random();
            }
            return rnd;
        }

        public static bool RandomPercent(int percent)
        {
            if (GetRnd().Next(100) < percent)
            {
                return true;
            }
            return false;
        }

        public static int RandomRange(int min, int max)
        {
            return GetRnd().Next(min, max + 1);
        }

        public static float RandomFloat(double min, double max)
        {
            return (float)(min + (GetRnd().NextDouble() * (max - min)));
        }
    }
}
