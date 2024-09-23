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

        public void WorkDay()
        {
            int orderNumber = rnd.Next(10, 13);
            // ez a gls raktár
            List<Package> allPackages = new List<Package>();
            for (int i = 0; i < orderNumber; i++)
            {
                Package package = new Package();
                allPackages.Add(package);
            }

            // Végig menni a csomagokon
            PreparePackages(allPackages);

            // kiszállítani a csomagokat
            DeliverPackages();
        }

        private void DeliverPackages()
        {
            foreach (Courier courier in couriers)
            {
                courier.DeliverPackages();
            }
        }

        private void PreparePackages(List<Package> allPackages)
        {
            foreach (Package package in allPackages)
            {
                bool success = false;

                // végig menni ki tudja kivinni az adott csomagot.
                foreach (Courier courier in couriers)
                {
                    if (courier.PickUpPackage(package))
                    {
                        success = true;
                        break;
                    }
                }

            }
        }
    }
}
