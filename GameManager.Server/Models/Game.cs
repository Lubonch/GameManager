using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GameManager.Server.Models;

public class Game
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public DateTime Year { get; set; }
    [Column("IdPublisher")]
    public int PublisherId { get; set; }
    [BindNever]
    public Publisher Publisher { get; set; }
    [Column("IdConsole")]
    public int ConsoleId { get; set; }
    [BindNever]
    public GameConsole Console { get; set; }
    [Column("IdGenre")]
    public int GenreId { get; set; }
    [BindNever]
    public Genre Genre { get; set; }
    [Range(0, int.MaxValue)]
    public int Quantity { get; set; }
    [Range(0, double.MaxValue)]
    public double Price { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int? CreatedById { get; set; }
    public int? UpdatedById { get; set; }
}