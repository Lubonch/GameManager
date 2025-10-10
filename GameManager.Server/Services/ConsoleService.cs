using GameManager.Server.Data;
using GameManager.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace GameManager.Server.Services;

public class ConsoleService : IConsoleService
{
    private readonly GameManagerContext _context;

    public ConsoleService(GameManagerContext context)
    {
        _context = context;
    }

    public async Task<List<GameConsole>> GetAllConsolesAsync()
    {
        return await _context.GameConsoles.ToListAsync();
    }

    public async Task<GameConsole?> GetByIdAsync(int id)
    {
        return await _context.GameConsoles.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task SaveOrUpdateAsync(GameConsole console)
    {
        if (console.Id == 0)
        {
            _context.GameConsoles.Add(console);
        }
        else
        {
            _context.GameConsoles.Update(console);
        }
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var console = await _context.GameConsoles.FindAsync(id);
        if (console != null)
        {
            _context.GameConsoles.Remove(console);
            await _context.SaveChangesAsync();
        }
    }
}