using GameManager.Server.Models;

namespace GameManager.Server.Services;

public interface IGenreService
{
    Task<List<Genre>> GetAllGenresAsync();
    Task<Genre?> GetByIdAsync(int id);
    Task SaveOrUpdateAsync(Genre genre);
    Task DeleteAsync(int id);
}