using System;
using System.Collections.Generic;

namespace VBJ._13B.Group2
{
    public class GLS
    {
        List<Courier> couriers = new List<Courier>();

        private static Random rnd = new Random();
        private static string[] names = new string[]
        {
            "Dóra", "Zsombor", "Balázs", "Péter"
        };

        public GLS()
        {
            
        }

        /// <summary>
        /// Alkalmazza egy futárt
        /// </summary>
        public void HireCourier()
        {
            couriers.Add(new Courier(names[rnd.Next(0, names.Length)]));
        }

        public void WorkDay(DateTime date)
        {
        }
    }
}
