using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameManager.Server.Models;

[Table("Console")]
public class Console
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
}