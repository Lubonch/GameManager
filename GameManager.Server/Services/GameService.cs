using GameManager.Server.Data;
using GameManager.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace GameManager.Server.Services;

public class GameService : IGameService
{
    private readonly GameManagerContext _context;

    public GameService(GameManagerContext context)
    {
        _context = context;
    }

    public async Task<List<Game>> GetAllGamesAsync()
    {
        return await _context.Games.Include(g => g.Publisher).Include(g => g.Console).Include(g => g.Genre).ToListAsync();
    }

    public async Task<Game?> GetByIdAsync(int id)
    {
        return await _context.Games.Include(g => g.Publisher).Include(g => g.Console).Include(g => g.Genre).FirstOrDefaultAsync(g => g.Id == id);
    }

    public async Task SaveOrUpdateAsync(Game game)
    {
        if (game.Id == 0)
        {
            _context.Games.Add(game);
        }
        else
        {
            _context.Games.Update(game);
        }
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var game = await _context.Games.FindAsync(id);
        if (game != null)
        {
            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
        }
    }
}