using System;
using System.Collections.Generic;

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
            MaxPackageNumber = rnd.Next(10, 17);
        }

        public string Name { get; set; }

        public int ID { get; set; }

        public int MaxPackageNumber { get; set; }

        // bool -> sikerült felvenni a csomagot, vagy nem sikerült
        public bool PickUpPackage(Package package)
        {
            if (IsPackagesFull())
            {
                return false;
            }

            packages.Add(package);
            return true;
        }

        public bool IsPackagesFull()
        {
            return packages.Count >= MaxPackageNumber;
        }

        public void DeliverPackage(Package package)
        {
            packages.Remove(package);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
