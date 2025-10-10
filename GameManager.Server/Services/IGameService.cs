using GameManager.Server.Models;

namespace GameManager.Server.Services;

public interface IGameService
{
    Task<List<Game>> GetAllGamesAsync();
    Task<Game?> GetByIdAsync(int id);
    Task SaveOrUpdateAsync(Game game);
    Task DeleteAsync(int id);
}