namespace VBJ._13B.Group2.WebApp.Models
{
    /// <summary>
    /// Ez az osztály jelképez egy elvégzendő teendőt
    /// </summary>
    public class ToDoItem
    {
        /// <summary>
        /// Az azonosítója
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Az elvégzendő teendő címe
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Azt jelöli hogy a teendő elvégzésre került vagy sem
        /// </summary>
        public bool HasCompleted { get; set; }

        public string Name => "Név";
    }
}
