using GameManager.Server.Data;
using GameManager.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace GameManager.Server.Services;

public class LoginTableService : ILoginTableService
{
    private readonly GameManagerContext _context;

    public LoginTableService(GameManagerContext context)
    {
        _context = context;
    }

    public async Task<List<LoginTable>> GetAllLoginTablesAsync()
    {
        return await _context.LoginTables.ToListAsync();
    }

    public async Task<LoginTable?> GetByIdAsync(int id)
    {
        return await _context.LoginTables.FirstOrDefaultAsync(l => l.Id == id);
    }

    public async Task SaveOrUpdateAsync(LoginTable loginTable)
    {
        if (loginTable.Id == 0)
        {
            _context.LoginTables.Add(loginTable);
        }
        else
        {
            _context.LoginTables.Update(loginTable);
        }
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var loginTable = await _context.LoginTables.FindAsync(id);
        if (loginTable != null)
        {
            _context.LoginTables.Remove(loginTable);
            await _context.SaveChangesAsync();
        }
    }
}