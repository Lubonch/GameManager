using GameManager.Server.Data;
using GameManager.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace GameManager.Server.Services;

public class GenreService : IGenreService
{
    private readonly GameManagerContext _context;

    public GenreService(GameManagerContext context)
    {
        _context = context;
    }

    public async Task<List<Genre>> GetAllGenresAsync()
    {
        return await _context.Genres.ToListAsync();
    }

    public async Task<Genre?> GetByIdAsync(int id)
    {
        return await _context.Genres.FirstOrDefaultAsync(g => g.Id == id);
    }

    public async Task SaveOrUpdateAsync(Genre genre)
    {
        if (genre.Id == 0)
        {
            _context.Genres.Add(genre);
        }
        else
        {
            _context.Genres.Update(genre);
        }
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var genre = await _context.Genres.FindAsync(id);
        if (genre != null)
        {
            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();
        }
    }
}