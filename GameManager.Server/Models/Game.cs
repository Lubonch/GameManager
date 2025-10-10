using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameManager.Server.Models;

public class Game
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Year { get; set; }
    [Column("IdPublisher")]
    public int PublisherId { get; set; }
    public Publisher Publisher { get; set; }
    [Column("IdConsole")]
    public int ConsoleId { get; set; }
    public GameConsole Console { get; set; }
    [Column("IdGenre")]
    public int GenreId { get; set; }
    public Genre Genre { get; set; }
    public int Quantity { get; set; }
    public float Price { get; set; }
}