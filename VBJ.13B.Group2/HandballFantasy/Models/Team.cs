namespace HandballFantasy.Models
{
    /// <summary>
    /// Ez az osztály egy kézilabda csapatot reprezentál.
    /// </summary>
    public class Team
    {
        public Team()
        {
            Players = new List<Player>();
        }

        public int ID { get; set; }

        public string Name { get; set; }

        public List<Player> Players { get; set; }
    }
}
