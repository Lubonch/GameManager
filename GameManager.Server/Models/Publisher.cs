using System.ComponentModel.DataAnnotations;

namespace GameManager.Server.Models;

public class Publisher
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
}