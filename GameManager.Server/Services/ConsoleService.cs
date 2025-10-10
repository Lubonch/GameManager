using GameManager.Server.Data;
using GameManager.Server.Models;
using Microsoft.EntityFrameworkCore;
using Console = GameManager.Server.Models.Console;

namespace GameManager.Server.Services;

public class ConsoleService : IConsoleService
{
    private readonly GameManagerContext _context;

    public ConsoleService(GameManagerContext context)
    {
        _context = context;
    }

    public async Task<List<Console>> GetAllConsolesAsync()
    {
        return await _context.Consoles.ToListAsync();
    }

    public async Task<Console?> GetByIdAsync(int id)
    {
        return await _context.Consoles.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task SaveOrUpdateAsync(Console console)
    {
        if (console.Id == 0)
        {
            _context.Consoles.Add(console);
        }
        else
        {
            _context.Consoles.Update(console);
        }
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var console = await _context.Consoles.FindAsync(id);
        if (console != null)
        {
            _context.Consoles.Remove(console);
            await _context.SaveChangesAsync();
        }
    }
}