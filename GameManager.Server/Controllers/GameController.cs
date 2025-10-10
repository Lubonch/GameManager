using GameManager.Server.Models;
using GameManager.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameManager.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{
    private readonly IGameService _gameService;

    public GameController(IGameService gameService)
    {
        _gameService = gameService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllGames()
    {
        var games = await _gameService.GetAllGamesAsync();
        return Ok(games);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetGameById(int id)
    {
        var game = await _gameService.GetByIdAsync(id);
        if (game == null)
        {
            return NotFound();
        }
        return Ok(game);
    }

    [HttpPost]
    public async Task<IActionResult> SaveOrUpdateGame(Game game)
    {
        await _gameService.SaveOrUpdateAsync(game);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGame(int id)
    {
        await _gameService.DeleteAsync(id);
        return Ok();
    }
}