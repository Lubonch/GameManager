namespace GameManagerWebAPI.Domain
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Year { get; set; } 
        public Publisher Publisher { get; set; }
        public Console Console { get; set; }
        public Genre Genre { get; set; }   
        public int Quantity { get; set; }
        public float Price { get; set; }
    }
}
