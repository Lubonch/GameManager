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
    public async Task<IActionResult> SaveOrUpdateGame(GameDto gameDto)
    {
        var currentUserId = int.Parse(Request.Headers["Current-User-Id"].ToString() ?? "0");
        var game = new Game
        {
            Id = gameDto.Id,
            Name = gameDto.Name,
            Year = gameDto.Year,
            PublisherId = gameDto.PublisherId,
            ConsoleId = gameDto.ConsoleId,
            GenreId = gameDto.GenreId,
            Quantity = gameDto.Quantity,
            Price = gameDto.Price,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            CreatedById = currentUserId,
            UpdatedById = currentUserId
        };
        await _gameService.SaveOrUpdateAsync(game);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGame(int id)
    {
        await _gameService.DeleteAsync(id);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateGame(int id, GameDto gameDto)
    {
        if (id != gameDto.Id)
        {
            return BadRequest();
        }

        var currentUserId = int.Parse(Request.Headers["Current-User-Id"].ToString() ?? "0");
        var existingGame = await _gameService.GetByIdAsync(id);
        if (existingGame == null)
        {
            return NotFound();
        }

        existingGame.Name = gameDto.Name;
        existingGame.Year = gameDto.Year;
        existingGame.PublisherId = gameDto.PublisherId;
        existingGame.ConsoleId = gameDto.ConsoleId;
        existingGame.GenreId = gameDto.GenreId;
        existingGame.Quantity = gameDto.Quantity;
        existingGame.Price = gameDto.Price;
        existingGame.UpdatedAt = DateTime.Now;
        existingGame.UpdatedById = currentUserId;

        await _gameService.SaveOrUpdateAsync(existingGame);
        return Ok();
    }
}