namespace GameManager.Server.DTOs;

public class GameDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Year { get; set; }
    public int PublisherId { get; set; }
    public string PublisherName { get; set; }
    public int ConsoleId { get; set; }
    public string ConsoleName { get; set; }
    public int GenreId { get; set; }
    public string GenreName { get; set; }
    public int Quantity { get; set; }
    public float Price { get; set; }
}