namespace VBJ._13B.Group2
{
    /// <summary>
    /// Csomag osztály, ezt viheti ki a Courier
    /// </summary>
    public class Package
    {
        // Field/mező -> olyan mint egy lokális változó
        // private -> csak osztályon belül látható
        // public ->akkor osztályon kívül is láthatü
        // Fontos: mezők mindig private-k
        private static int id = 1;

        // Konstruktor -> shortcut ctor után tab
        public Package()
        {
            ID = id++;
        }

        // Tulajdonság/property hozzáférhetőség a mezőhöz
        // Shortcut prop -> tab
        public int ID { get; }
    }
}
