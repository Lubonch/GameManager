using GameManager.Server.Models;

namespace GameManager.Server.Services;

public interface IPeopleService
{
    Task<List<People>> GetAllPeoplesAsync();
    Task<People?> GetByIdAsync(int id);
    Task SaveOrUpdateAsync(People people);
    Task DeleteAsync(int id);
}