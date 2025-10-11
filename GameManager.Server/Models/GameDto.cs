using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameManager.Server.Models;

public class GameDto
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public DateTime Year { get; set; }
    [Column("IdPublisher")]
    public int PublisherId { get; set; }
    [Column("IdConsole")]
    public int ConsoleId { get; set; }
    [Column("IdGenre")]
    public int GenreId { get; set; }
    [Range(0, int.MaxValue)]
    public int Quantity { get; set; }
    [Range(0, double.MaxValue)]
    public double Price { get; set; }
}