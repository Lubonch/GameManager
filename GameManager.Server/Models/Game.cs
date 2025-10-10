using System.ComponentModel.DataAnnotations;

namespace GameManager.Server.Models;

public class Game
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Year { get; set; }
    public int PublisherId { get; set; }
    public Publisher Publisher { get; set; }
    public int ConsoleId { get; set; }
    public Console Console { get; set; }
    public int GenreId { get; set; }
    public Genre Genre { get; set; }
    public int Quantity { get; set; }
    public float Price { get; set; }
}