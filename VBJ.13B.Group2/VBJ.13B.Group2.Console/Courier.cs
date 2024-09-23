using System;
using System.Collections.Generic;
using System.Threading;

namespace VBJ._13B.Group2
{
    public class Courier
    {
        private static int id = 1;
        private static Random rnd = new Random();

        private List<Package> packages = new List<Package>();

        public Courier(string name)
        {
            ID = id++;
            Name = name;

            // 10 és 16 között -> balról zárt és jobbról nyitott intervallum
            MaxPackageNumber = rnd.Next(2, 5);
        }

        public string Name { get; set; }

        public int ID { get; set; }

        public int MaxPackageNumber { get; set; }

        // bool -> sikerült felvenni a csomagot, vagy nem sikerült
        public bool PickUpPackage(Package package)
        {
            Thread.Sleep(1000);
            if (IsPackagesFull())
            {
                Console.WriteLine($"\t{Name} futárnak nem sikerült felvennie a #{package.ID} csomagot");
                return false;
            }

            packages.Add(package); 
            Console.WriteLine($"\t{Name} futár felvette a #{package.ID} csomagot");
            return true;
        }

        public bool IsPackagesFull()
        {
            return packages.Count >= MaxPackageNumber;
        }

        public void DeliverPackages()
        {
            Thread.Sleep(1000);
            foreach (var package in packages)
            {
                Console.WriteLine($"\t\t{package.ID} csomag ki lett szállítva {Name} által.");
            }
            packages.Clear();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
