using System.ComponentModel.DataAnnotations;

namespace GameManager.Server.Models;

public class Genre
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int? CreatedById { get; set; }
    public int? UpdatedById { get; set; }
}