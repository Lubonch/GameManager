using System.ComponentModel.DataAnnotations;

namespace GameManager.Server.Models;

public class LoginTable
{
    [Key]
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}