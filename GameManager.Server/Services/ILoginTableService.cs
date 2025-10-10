using GameManager.Server.Models;

namespace GameManager.Server.Services;

public interface ILoginTableService
{
    Task<List<LoginTable>> GetAllLoginTablesAsync();
    Task<LoginTable?> GetByIdAsync(int id);
    Task SaveOrUpdateAsync(LoginTable loginTable);
    Task DeleteAsync(int id);
}