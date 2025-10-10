using GameManager.Server.Models;

namespace GameManager.Server.Services;

public interface IPublisherService
{
    Task<List<Publisher>> GetAllPublishersAsync();
    Task<Publisher?> GetByIdAsync(int id);
    Task SaveOrUpdateAsync(Publisher publisher);
    Task DeleteAsync(int id);
}