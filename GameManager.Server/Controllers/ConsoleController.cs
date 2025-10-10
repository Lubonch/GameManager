using GameManager.Server.Models;
using GameManager.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameManager.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConsoleController : ControllerBase
{
    private readonly IConsoleService _consoleService;

    public ConsoleController(IConsoleService consoleService)
    {
        _consoleService = consoleService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllConsoles()
    {
        var consoles = await _consoleService.GetAllConsolesAsync();
        return Ok(consoles);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetConsoleById(int id)
    {
        var console = await _consoleService.GetByIdAsync(id);
        if (console == null)
        {
            return NotFound();
        }
        return Ok(console);
    }

    [HttpPost]
    public async Task<IActionResult> SaveOrUpdateConsole(GameConsole console)
    {
        await _consoleService.SaveOrUpdateAsync(console);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateConsole(int id, GameConsole console)
    {
        if (id != console.Id)
        {
            return BadRequest();
        }

        await _consoleService.SaveOrUpdateAsync(console);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteConsole(int id)
    {
        await _consoleService.DeleteAsync(id);
        return Ok();
    }
}