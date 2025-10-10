using System.ComponentModel.DataAnnotations;

namespace GameManager.Server.Models;

public class People
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}