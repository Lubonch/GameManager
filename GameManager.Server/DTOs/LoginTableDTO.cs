namespace GameManager.Server.DTOs;

public class LoginTableDTO
{
    public int Id { get; set; }
    public string Username { get; set; }
    // Nota: No incluimos Password en DTO por seguridad
}