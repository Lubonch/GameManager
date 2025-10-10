namespace GameManagerWebAPI.Domain
{
    public class Game
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime Year { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual Console Console { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual int Quantity { get; set; }
        public virtual float Price { get; set; }
    }
}
