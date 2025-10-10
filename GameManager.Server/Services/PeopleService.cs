using GameManager.Server.Data;
using GameManager.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace GameManager.Server.Services;

public class PeopleService : IPeopleService
{
    private readonly GameManagerContext _context;

    public PeopleService(GameManagerContext context)
    {
        _context = context;
    }

    public async Task<List<People>> GetAllPeoplesAsync()
    {
        return await _context.Peoples.ToListAsync();
    }

    public async Task<People?> GetByIdAsync(int id)
    {
        return await _context.Peoples.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task SaveOrUpdateAsync(People people)
    {
        if (people.Id == 0)
        {
            _context.Peoples.Add(people);
        }
        else
        {
            _context.Peoples.Update(people);
        }
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var people = await _context.Peoples.FindAsync(id);
        if (people != null)
        {
            _context.Peoples.Remove(people);
            await _context.SaveChangesAsync();
        }
    }
}