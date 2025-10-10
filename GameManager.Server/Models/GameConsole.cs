using System.ComponentModel.DataAnnotations;

namespace GameManager.Server.Models;

public class GameConsole
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
}