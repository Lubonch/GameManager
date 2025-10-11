using GameManager.Server.Models;

namespace GameManager.Server.Services;

public interface IConsoleService
{
    Task<List<GameConsole>> GetAllConsolesAsync();
    Task<GameConsole?> GetByIdAsync(int id);
    Task SaveOrUpdateAsync(GameConsole console);
    Task DeleteAsync(int id);
}