using GameManager.Server.Data;
using GameManager.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace GameManager.Server.Services;

public class PublisherService : IPublisherService
{
    private readonly GameManagerContext _context;

    public PublisherService(GameManagerContext context)
    {
        _context = context;
    }

    public async Task<List<Publisher>> GetAllPublishersAsync()
    {
        return await _context.Publishers.ToListAsync();
    }

    public async Task<Publisher?> GetByIdAsync(int id)
    {
        return await _context.Publishers.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task SaveOrUpdateAsync(Publisher publisher)
    {
        if (publisher.Id == 0)
        {
            _context.Publishers.Add(publisher);
        }
        else
        {
            _context.Publishers.Update(publisher);
        }
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var publisher = await _context.Publishers.FindAsync(id);
        if (publisher != null)
        {
            _context.Publishers.Remove(publisher);
            await _context.SaveChangesAsync();
        }
    }
}