using GameManager.Server.Models;
using Console = GameManager.Server.Models.Console;

namespace GameManager.Server.Services;

public interface IConsoleService
{
    Task<List<Console>> GetAllConsolesAsync();
    Task<Console?> GetByIdAsync(int id);
    Task SaveOrUpdateAsync(Console console);
    Task DeleteAsync(int id);
}